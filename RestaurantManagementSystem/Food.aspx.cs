using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Food : System.Web.UI.Page
{
    ValidataionClass isvalid = new ValidataionClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            ltrmsg.Text = "Welcome" + Session["username"].ToString() + "To Admin Panel";
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }

    private bool Checkvalidation()
    {
        //int age = Convert.ToInt32(txtAge.Text);
        bool Valid = true;
        if (!isvalid.checkValidation(txtfoodname.Text)||isvalid.isAlldigit(txtfoodname.Text))
        {
            ltrmsg.Text = "Give proper food name";
            txtfoodname.Focus();
            Valid = false;
        }
      
        return Valid;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        FoodClass fc = new FoodClass();
        fc.Foodname = txtfoodname.Text;
        //fc.id = Convert.ToInt32(txtfoodid.Text);
        try {
            if (!Checkvalidation())
                return;
            using (DataTable dt = fc.getfood()){
                if( dt.Rows.Count>0){
                    ltrmsg.Text = "Record Already Exist.Please Create another group";
                }
                else {
                    fc.savefood(txtfoodname.Text);
                    ltrmsg.Text = "Food Item Created Successfully.";
                }
            }
            
        }
        catch(Exception ex) {
            ltrmsg.Text = ex.Message;
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        FoodClass fc = new FoodClass();
        try {
            if (!Checkvalidation())
                return;
            fc.updateFood(Convert.ToInt16(txtfoodid.Text), txtfoodname.Text);
            ltrmsg.Text = "Record Updated successfully.";
        }
        catch (Exception ex) {
            ltrmsg.Text = ex.Message;
        }
    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
        FoodClass fc = new FoodClass();
        int id = Convert.ToInt16(txtfoodid);
        try {
            fc.deleteFood(id);
            ltrmsg.Text = "Record Deleted Successfully";

        }
        catch (Exception ex) {
            ltrmsg.Text = ex.Message;
        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        FoodClass fc = new FoodClass();
        fc.Foodname = txtfoodname.Text;
        fc.id = Convert.ToInt16(txtfoodid.Text);
        using (DataTable dt = fc.checkFood()) {

            if (dt.Rows.Count>0) {
                //txtfoodid.Text = dt.Rows[0]["FOODID"].ToString();
                txtfoodname.Text = dt.Rows[0]["foodname"].ToString();
            }
            else { ltrmsg.Text = "Record Not Found"; }
        } 
    }
}