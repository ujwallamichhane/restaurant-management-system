using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class User : System.Web.UI.Page
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
        if (!isvalid.checkValidation(txtusername.Text))
        {
            ltrmsg.Text = "Give proper first name";
            txtusername.Focus();
            Valid = false;
        }
        else
            if (!isvalid.checkValidation(txtpassword.Text))
        {
            ltrmsg.Text = "Give proper middle name";
            txtpassword.Focus();
            Valid = false;
        }
        


        return Valid;
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        UserClass uc = new UserClass();
        uc.role = ddlrole.Text;
        uc.username = txtusername.Text;
        uc.password = txtpassword.Text;
        int x;
        int y;
        
        using (DataTable dt = uc.checkroleid()) {
          
            
            try {
                if (!Checkvalidation())
                    return;
                if (dt.Rows.Count>0) {
                     x = Convert.ToInt16(dt.Rows[0]["RID"]);
                    UserClass ucc = new UserClass();
                    ucc.saveusers(txtusername.Text, txtpassword.Text, x);
                    //ltrmsg.Text = "User created Successfully";
                    using (DataTable dtt=uc.checkUsers()){
                        try {
                            if (dtt.Rows.Count > 0)
                            {
                                 y = Convert.ToInt16(dtt.Rows[0]["UID"]);
                                UserClass u = new UserClass();
                                u.adduserrole(y,x);
                                ltrmsg.Text = "User created Successfully.";                                                                
                            }
                            else
                            {
                                ltrmsg.Text = "Error in User Creation!";
                            }
                        }
                        catch (Exception ex) {
                            ltrmsg.Text = ex.Message;
                        } 
                    
                    } 
                }
                else {
                    ltrmsg.Text = "Sorry Something went Wrong";
                }
            }
            catch (Exception Ex) {
                ltrmsg.Text = Ex.Message;
            }
            
        }
           
        
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        UserClass uc = new UserClass();
        uc.username = txtusername.Text;
        uc.password = txtpassword.Text;
        uc.role = ddlrole.Text;
        uc.id = Convert.ToInt16(txtuid.Text);
        int x;
        int y;
        using (DataTable dt = uc.checkUsers()) {
            try {
                if (!Checkvalidation())
                    return;
                if (dt.Rows.Count>0) {
                    y = Convert.ToInt16(dt.Rows[0]["UID"]);
                    using (DataTable dtt=uc.checkroleid()) {
                        try {
                            if (dtt.Rows.Count > 0)
                            {
                                x = Convert.ToInt16(dtt.Rows[0]["RID"]);
                                uc.updateusers(y, txtusername.Text, txtpassword.Text, x);
                                uc.updateuserrole(y,x);
                                ltrmsg.Text = "Record Updated";
                            }
                            else {
                                ltrmsg.Text = "RID Couldnot Be Found For the Corresponding UID";
                            }
                        }
                        catch (Exception ex) {
                            ltrmsg.Text = ex.Message;
                        }
                    }
                       // x = Convert.ToInt16(dt.Rows.[0]["RID"]);

                       
                }
                else {
                    ltrmsg.Text = "Sorry! Couldnot update Information Supplied.";
                }
            }
            catch (Exception Ex) {
                ltrmsg.Text = Ex.Message;
            } 

        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        UserClass uc = new UserClass();
         uc.id= Convert.ToInt16(txtuid.Text);
        uc.username = txtusername.Text;
        int x;
        using (DataTable dt = uc.searchuser()) {
            try {
                if (dt.Rows.Count > 0)
                {
                    //txtuid.Text = dt.Rows[0]["uid"].ToString();
                    txtusername.Text = dt.Rows[0]["username"].ToString();
                    txtpassword.Text = dt.Rows[0]["password"].ToString();
                     x = Convert.ToInt16(dt.Rows[0]["RID"].ToString());                    
                    using (DataTable dtt = uc.checkrole(x)) {
                        if (dtt.Rows.Count > 0) {
                           ddlrole.Text = dtt.Rows[0]["rolename"].ToString();
                        }
                        else {
                            ltrmsg.Text = "Role Could not be synced properly";
                        }
                    }

                }
                else {
                    ltrmsg.Text = "Sorry ! Record Not Found";
                }
            }
            catch (Exception ex) {
                ltrmsg.Text = ex.Message;
            }
        
    

        }
    }
}