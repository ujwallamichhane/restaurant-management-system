using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class login : System.Web.UI.Page
{
    String Role1, Role2, Role3, Role4,Role5,Role6;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        UserClass uc = new UserClass();
        GlobalConnection.username = txtusername.Text;
        uc.username = txtusername.Text;
        uc.password = txtpassword.Text;
        int roleid;
        using (DataTable dt = uc.checkUsers()) {
            try {
                if (dt.Rows.Count > 0)
                {
                    Session["username"]= txtusername.Text;
                    roleid = Convert.ToInt32(dt.Rows[0]["RID"].ToString());
                    GlobalConnection.uid = Convert.ToInt16(dt.Rows[0]["UID"].ToString());

                   GlobalConnection.staffid = Convert.ToInt16(dt.Rows[0]["StaffID"].ToString());
                    Role1 = "admin";
                    Role2 = "receptionist";
                    Role3 = "helper";
                    Role4 = "waiter";
                    Role5 = "chef";
                    Role6 = "manager";
                    using (DataTable dtt = uc.checkrole(roleid)) {
                        if (dtt.Rows[0]["rolename"].ToString().Trim().Equals(Role1) == true)
                        {

                            Response.Redirect("admin.aspx");
                        }
                        if (dtt.Rows[0]["rolename"].ToString().Trim().Equals(Role2) == true)
                        {
                            Response.Redirect("Billing.aspx");


                        }
                        if (dtt.Rows[0]["rolename"].ToString().Trim().Equals(Role3) == true)
                        {


                            Response.Redirect("StaffOrders.aspx");

                        }
                        if (dtt.Rows[0]["rolename"].ToString().Trim().Equals(Role4) == true)
                        {
                            Response.Redirect("StaffOrders.aspx");
                        }
                        if (dtt.Rows[0]["rolename"].ToString().Trim().Equals(Role5) == true)
                        {
                            Response.Redirect("Today's Order.aspx");
                        }
                        if (dtt.Rows[0]["rolename"].ToString().Trim().Equals(Role6) == true)
                        {
                            Response.Redirect("admin.aspx");
                        }
                    }
                    
                }
                else {
                    ltrmsg.Text = "Invalid Username or Password!";
                }
            }
            catch (Exception ex){
                ltrmsg.Text = ex.Message;
            }
        }

    }
}