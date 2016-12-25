using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Food
/// </summary>
public class FoodClass

{
    GlobalConnection gc = new GlobalConnection();
    private int _id;
    private String _foodname;
    public String Foodname {
        get { return _foodname; }
        set { _foodname = value; }
    } 
    public int id {
        get { return _id; }
        set { _id = value; }
    }

    public void savefood(String foodname) {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "addfood";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@foodname",foodname);
        cmd.ExecuteNonQuery();
    }
    public DataTable checkFood() {
        string data = "Select*from food where FOODID='" + _id + "'";
        SqlDataAdapter da = new SqlDataAdapter(data, gc.cn);
        DataSet ds = new DataSet();
        da.Fill(ds,"food");
        return ds.Tables[0];
    }
    public DataTable getfood()
    {
        string data = "Select*from food where foodname='" + _foodname +"'";
        SqlDataAdapter da = new SqlDataAdapter(data, gc.cn);
        DataSet ds = new DataSet();
        da.Fill(ds, "food");
        return ds.Tables[0];
    }
    public void updateFood(int Fid,String foodname) {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "updatefood";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FOODID",Fid);
        cmd.Parameters.AddWithValue("@foodname",foodname);
        cmd.ExecuteNonQuery();
    }
    public void deleteFood(int fid) {

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "deletefood";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FOODID", fid);        
        cmd.ExecuteNonQuery();
    }
}