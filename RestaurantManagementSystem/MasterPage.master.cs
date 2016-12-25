using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            imageslideshow();
        }
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        int i = (int)ViewState["Imagedisplayed"];
        i = i + 1;
        ViewState["Imagedisplayed"]= i;
        DataRow imagerow = ((DataSet)ViewState["ImageData"]).Tables["image"].Select().FirstOrDefault(x => x["order"].ToString() == i.ToString());
        if (imagerow != null)
        {
            Image1.ImageUrl = "~/Data/Images/" + imagerow["name"].ToString();
        }
        else {
            imageslideshow();
        }
        
        
    }
    private void imageslideshow()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("~/Data/imagexml.xml"));
        ViewState["ImageData"] = ds;
        ViewState["Imagedisplayed"] = 1;
       DataRow imagerow= ds.Tables["image"].Select().FirstOrDefault(x => x["order"].ToString() == "1");
        Image1.ImageUrl = "~/Images/" + imagerow["name"].ToString(); 
    }
}
