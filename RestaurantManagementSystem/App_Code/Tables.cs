using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Tables
/// </summary>
public class Tables
{
    GlobalConnection gc = new GlobalConnection();
    private int _id;
    private String _tablename;
    public String Tablename
    {
        get { return _tablename; }
        set { _tablename = value; }
    }
    public int id
    {
        get { return _id; }
        set { _id = value; }
    }

    public void savetables(String table)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "addtables";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@name", table);
        cmd.ExecuteNonQuery();
    }
    public DataTable checktable()
    {
        string data = "Select*from tables where  name='" + _tablename + "'";
        SqlDataAdapter da = new SqlDataAdapter(data, gc.cn);
        DataSet ds = new DataSet();
        da.Fill(ds, "tables");
        return ds.Tables[0];
    }
    public DataTable gettable()
    {
        string data = "Select*from tables where  TableId='" + _id + "'";
        SqlDataAdapter da = new SqlDataAdapter(data, gc.cn);
        DataSet ds = new DataSet();
        da.Fill(ds, "tablename");
        return ds.Tables[0];
    }
    public void updatetables(int FCID, String foodcategory)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "updatetables";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tableid", FCID);
        cmd.Parameters.AddWithValue("@name", foodcategory);
        cmd.ExecuteNonQuery();
    }
    public void deletetable(int tableid)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "deletefoodcategory";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tableid", tableid);
        cmd.ExecuteNonQuery();

    }
}