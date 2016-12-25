using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class FoodCategory : System.Web.UI.Page
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
        if (!isvalid.checkValidation(txtcategory.Text))
        {
            ltrmsg.Text = "Give proper first name";
            txtcategory.Focus();
            Valid = false;
        }
       



        return Valid;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ltrmsg.Text = "";
        FoodCategoryClass fc = new FoodCategoryClass();
        //fc.id = Convert.ToInt16(txtid.Text);
        fc.Foodcategory = txtcategory.Text;
        try {
            if (!Checkvalidation())
                return;
               using (DataTable dt = fc.checkFoodcategory()) {
                if (dt.Rows.Count>0) {
                    ltrmsg.Text = "Food category defined already.Please create another category";
                }
                else {
                    fc.savefoodcategory(txtcategory.Text);
                        ltrmsg.Text = "New Food Category Created.";
                }
            }
        }
        catch (Exception ex) {
            ltrmsg.Text = ex.Message;
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        ltrmsg.Text = "";
        FoodCategoryClass fc = new FoodCategoryClass();
        try {
            fc.updateFoodCategory(Convert.ToInt16(txtid.Text), txtcategory.Text);
            ltrmsg.Text = "Record updated successfully.";
        }
        catch (Exception ex) {
            ltrmsg.Text = ex.Message;
        }
       
    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
        ltrmsg.Text = "";
        FoodCategoryClass fc = new FoodCategoryClass();
        int fcid = Convert.ToInt16(txtid.Text);
        try {

            fc.deletefoodcategory(fcid);
            ltrmsg.Text = "Record deleted";
        }
        catch (Exception ex) {
            ltrmsg.Text = ex.Message;
        }
        
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        ltrmsg.Text = "";
        FoodCategoryClass fc = new FoodCategoryClass();
        fc.id = Convert.ToInt16(txtid.Text);

        try
        {
            using (DataTable dt = fc.checkfoodcategory())
            {
                if (dt.Rows.Count > 0) {

                    txtcategory.Text = dt.Rows[0]["type"].ToString();
                }
                else
                {
                    ltrmsg.Text = "Record Not Found";
                }
            }
        }
        catch (Exception ex)
        {
            ltrmsg.Text = ex.Message;
        }
        

        }
    
}