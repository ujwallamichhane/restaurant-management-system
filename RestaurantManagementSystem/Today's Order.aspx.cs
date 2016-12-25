using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Today_s_Order : System.Web.UI.Page
{
    GlobalConnection gc = new GlobalConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["username"] != null)
        //{
        //    ltrmsg.Text = "Welcome" + Session["username"].ToString() + "To Admin Panel";
        //}
        //else
        //{
        //    Response.Redirect("Home.aspx");
        //}

        DataTable dt = getcustomerorders();
        if(dt.Rows.Count>0)
        gvonlineorder.DataSource = dt;
        gvonlineorder.DataBind();
        DataTable dtt=getrestaurantrorders();
        if(dtt.Rows.Count>0)
        gvrestaurantorders.DataSource = dtt;
        gvrestaurantorders.DataBind();
    }

    public DataTable getcustomerorders() {
        DateTime d = DateTime.Now.Date;
        string data = "SELECT customerorder.Cust_FName,customerorder.Cust_LName,customerorder.contact,customerorder.MenuId,  food.foodname, foodcategory.Type,menu.price,customerorder.quantity, customerorder.totalamount,convert(varchar,customerorder.orderdate,101)as orderdate FROM customerorder AS customerorder INNER JOIN menu AS menu ON customerorder.menuid = menu.MENUID INNER JOIN food AS food ON menu.FOODID = food.FOODID INNER JOIN foodcategory AS foodcategory ON menu.FCID = foodcategory.FCID  where customerorder.orderdate='" + d + "'";
        SqlDataAdapter sda = new SqlDataAdapter(data,gc.cn);
        DataSet ds = new DataSet();
        sda.Fill(ds, "custorders");
        return ds.Tables[0];
       
    }
    public DataTable getrestaurantrorders()
    {
        DateTime d = DateTime.Now.Date;
        string data = "SELECT  stafforder.menuid, food.foodname, foodcategory.Type, menu.price,stafforder.quantity, stafforder.totalamount,Convert(darchar,stafforder.orderdate,101)as order date,staff.firstname as Order Taken By FROM stafforder AS stafforder INNER JOIN menu AS menu ON stafforder.menuid = menu.MENUID INNER JOIN staff AS staff ON stafforder.StaffID = staff.STAFFID INNER JOIN tables AS tables ON stafforder.Tableid = tables.TableId INNER JOIN food AS food ON menu.FOODID = food.FOODID INNER JOIN foodcategory AS foodcategory ON menu.FCID = foodcategory.FCID  where  stafforder.orderdate= '" + d+ "'";
        SqlDataAdapter sda = new SqlDataAdapter(data, gc.cn);
        DataSet ds = new DataSet();
        sda.Fill(ds, "restaurantorders");
        return ds.Tables[0];
        
    }
}