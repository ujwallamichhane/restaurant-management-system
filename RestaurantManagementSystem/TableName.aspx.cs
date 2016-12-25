using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class TableName : System.Web.UI.Page
{
    Tables tbl = new Tables();
    ValidataionClass isValid = new ValidataionClass();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            ltrmsg2.Text = "Welcome" + Session["username"].ToString() + "To Admin Panel";
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }

    protected bool CheckValidation() {
        bool Valid = true;
        if (!isValid.checkValidation(txttablename.Text) || isValid.isAlldigit(txttablename.Text)) {
            ltrmsg.Text = "Enter Proper Name for the Table.";
            txttablename.Focus();
            Valid = false;
        }
        return Valid;
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!CheckValidation())
                return;            
                //tbl.id = Convert.ToInt16(txtid.Text);
                tbl.Tablename = txttablename.Text;
                using (DataTable dt = tbl.checktable())
                {
                    if (dt.Rows.Count > 0)
                    {
                        ltrmsg.Text = "Record already exist with same Table name.Please! create new one.";
                    }
                    else
                    {
                        tbl.savetables(txttablename.Text);
                        ltrmsg.Text = "Record Saved.";
                    }

                }
            
           
        }
        catch (Exception Ex)
        {

            ltrmsg.Text=Ex.Message;
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (!CheckValidation())
                return;
            if (txtid.Text.Equals(null) && txttablename.Text.Equals(null))
            {
                ltrmsg.Text = "Record Couldnot be Updated";
                txtid.Focus();
                
            }
            else {
                tbl.updatetables(tbl.id = Convert.ToInt16(txtid.Text), txttablename.Text);
                ltrmsg.Text = "Record Updated";
            }
           

         }
        catch (Exception Ex)
        {

            ltrmsg.Text = Ex.Message;
        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            tbl.id = Convert.ToInt16(txtid.Text);            
            using (DataTable dt = tbl.gettable())
            {
                if (dt.Rows.Count > 0)
                {
                    txttablename.Text = dt.Rows[0]["Name"].ToString();
                    
                }
                else
                {
                    
                    ltrmsg.Text = "Record Not Found.";
                }

            }
        }
        catch (Exception Ex)
        {

            ltrmsg.Text = Ex.Message;
        }
    }
}