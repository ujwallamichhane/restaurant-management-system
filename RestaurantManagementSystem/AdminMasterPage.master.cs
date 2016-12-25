using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (Session["username"] != null)
        {
           // ltrmsg.Text = "Welcome" + Session["username"].ToString() + "To Admin Panel";
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }

    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();       
        Response.Redirect("Home.aspx");
    }
}
