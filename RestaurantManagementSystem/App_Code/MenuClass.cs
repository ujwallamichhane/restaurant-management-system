using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Menu
/// </summary>
public class MenuClass

{
    GlobalConnection gc = new GlobalConnection();
    private int _id;
    private String _foodname;
    private string _foodcategory;
    
    public String Foodname
    {
        get { return _foodname; }
        set { _foodname = value; }
    }
    public int id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string foodcategory {
        get { return _foodcategory; }
        set { _foodcategory = value; }
    }

    public void savemenu(int FCID,int FOODID,int price)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "addmenu";
        cmd.CommandType = CommandType.StoredProcedure;        
        cmd.Parameters.AddWithValue("@FCID",FCID);
        cmd.Parameters.AddWithValue("@FOODID", FOODID);
        cmd.Parameters.AddWithValue("@price", price);
        cmd.ExecuteNonQuery();
    }
    public DataTable checkmenu(int fcid,int fid)
    {
        string data = "Select *from menu where  FCID='" + fcid+ "' and FOODID='"+fid+"'";
        SqlDataAdapter da = new SqlDataAdapter(data, gc.cn);
        DataSet ds = new DataSet();
        da.Fill(ds, "food");
        return ds.Tables[0];
    }
    public DataTable getmenuid( int fid)
    {
        string data = "Select MENUID from menu where  FOODID='" + fid + "'";
        SqlDataAdapter da = new SqlDataAdapter(data, gc.cn);
        DataSet ds = new DataSet();
        da.Fill(ds, "food");
        return ds.Tables[0];
    }
    public DataTable checkFood()
    {
        string data = "Select FOODID from food where  foodname='" + _foodname + "'";
        SqlDataAdapter da = new SqlDataAdapter(data, gc.cn);
        DataSet ds = new DataSet();
        da.Fill(ds, "food");
        return ds.Tables[0];
    }

    public DataTable checkFoodCategory()
    {
        string data = "Select FCID from foodcategory where  type='" + _foodcategory + "'";
        SqlDataAdapter da = new SqlDataAdapter(data, gc.cn);
        DataSet ds = new DataSet();
        da.Fill(ds, "foodcategory");
        return ds.Tables[0];
    }
    public void updatemenu(int FCID,int FOODID,int price)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "updatemenu";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FCID", FCID);
        cmd.Parameters.AddWithValue("@FOODID", FOODID);
        cmd.Parameters.AddWithValue("@Price",price);
        cmd.ExecuteNonQuery();
    }
}