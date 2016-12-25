using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Menu : System.Web.UI.Page
{
    MenuClass mc = new MenuClass();
    ValidataionClass isvalid = new ValidataionClass();
    int x, y;
    
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
        if (!isvalid.isAlldigit(txtprice.Text))
        {
            ltrmsg.Text = "Price should be integer .Cannot accept characters or decimal value.";
            txtprice.Focus();
            Valid = false;
        }
        else
            if (txtprice.Text.Trim().Length<1 ||txtprice.Text.Trim().Length>4)
        {
            ltrmsg.Text = "Price should be reasonable";
            txtprice.Focus();
            Valid = false;
        }



        return Valid;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Checkvalidation())
                return;
            mc.foodcategory = ddlfoodcategory.SelectedItem.ToString();
            mc.Foodname = ddlfoodname.SelectedItem.ToString();
            using (DataTable dt = mc.checkFood())
            {
                if (dt.Rows.Count > 0)
                {
                    x = Convert.ToInt16(dt.Rows[0]["FOODID"].ToString());
                    using (DataTable dtt = mc.checkFoodCategory())
                    {
                        if (dtt.Rows.Count > 0)
                        {
                            y = Convert.ToInt16(dtt.Rows[0]["FCID"].ToString());
                            using (DataTable D=mc.checkmenu(y,x)) {
                                if (D.Rows.Count>0) {
                                    ltrmsg.Text = "This Menu Item Alredy Exist.Please! Create New One.";
                                }
                                else {
                                    mc.savemenu(Convert.ToInt16(ddlfoodcategory.SelectedItem.Value),Convert.ToInt16(ddlfoodname.SelectedItem.Value), Convert.ToInt16(txtprice.Text));
                                    ltrmsg.Text = "New Menu Item Created.";
                                }
                            }
                                
                        }
                        else
                        {
                            ltrmsg.Text = "Food category data not found.Please! check the food category.";
                        }
                    }
                }
                else
                {
                    ltrmsg.Text = "Food data not found.Please! check the food name.";
                }
            }
        }
        catch (Exception Ex)
        {

            ltrmsg.Text = Ex.Message;
            
        }
        
       


    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try {
            if (!Checkvalidation())
                return;
            mc.updatemenu(Convert.ToInt16(ddlfoodcategory.SelectedItem.Value),Convert.ToInt16(ddlfoodname.SelectedItem.Value),Convert.ToInt16(txtprice.Text));
            ltrmsg.Text = "Record Updated";
        }
        catch (Exception Ex) {
            ltrmsg.Text = Ex.Message;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        using (DataTable dt=mc.checkmenu(Convert.ToInt16(ddlfoodcategory.SelectedItem.Value),Convert.ToInt16(ddlfoodname.SelectedItem.Value))) {
            if (dt.Rows.Count>0) {
                txtprice.Text =dt.Rows[0]["price"].ToString();
            }
        }
    }
}