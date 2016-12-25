using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for FoodCategory
/// </summary>
public class FoodCategoryClass
{
    GlobalConnection gc = new GlobalConnection();
    private int _id;
    private String _foodcategory;
    public String Foodcategory
    {
        get { return _foodcategory; }
        set { _foodcategory = value; }
    }
    public int id
    {
        get { return _id; }
        set { _id = value; }
    }

    public void savefoodcategory(String foodcategory)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "addfooodcategory";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@type", foodcategory);
        cmd.ExecuteNonQuery();
    }
    public DataTable checkFoodcategory()
    {
        string data = "Select*from foodcategory where  Type='" + _foodcategory + "'";
        SqlDataAdapter da = new SqlDataAdapter(data, gc.cn);
        DataSet ds = new DataSet();
        da.Fill(ds, "foodcategory");
        return ds.Tables[0];
    }
    public DataTable checkfoodcategory()
    {
        string data = "Select*from foodcategory where  FCID='" + _id + "'";
        SqlDataAdapter da = new SqlDataAdapter(data, gc.cn);
        DataSet ds = new DataSet();
        da.Fill(ds, "foodcategory");
        return ds.Tables[0];
    }
    public void updateFoodCategory(int FCID, String foodcategory)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "updatefoodcategory";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FCID", FCID);
        cmd.Parameters.AddWithValue("@type", foodcategory);
        cmd.ExecuteNonQuery();
    }
    public void deletefoodcategory(int fcid) {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "deletefoodcategory";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@fcid", fcid);
        cmd.ExecuteNonQuery();

    }
}