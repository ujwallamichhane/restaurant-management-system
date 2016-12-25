using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Order
/// </summary>
public class OrderClass

{
    GlobalConnection gc = new GlobalConnection();
    public DataTable checkTableorder() {
        string data = "select *from ordertablereplica";
        SqlDataAdapter sda = new SqlDataAdapter(data,gc.cn);
        DataSet ds = new DataSet();
        sda.Fill(ds,"orders");
        return ds.Tables[0];
    }

    public void getorder(string fname,string lname,string address,int menuid, int qunatity,int totalamount,string orderdate,int contact) {

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "addcustorder";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@custfname",fname);
        cmd.Parameters.AddWithValue("@custlname",lname);
        cmd.Parameters.AddWithValue("@custaddress",address);
        cmd.Parameters.AddWithValue("@menuid",menuid);
        cmd.Parameters.AddWithValue("@quantity",qunatity);
        cmd.Parameters.AddWithValue("@totalamount",totalamount);
        cmd.Parameters.AddWithValue("@orderdate",orderdate);
        cmd.Parameters.AddWithValue("@contact",contact);
        cmd.ExecuteNonQuery();
    }
    public void getStafforder( int menuid,int quantity,int totalamount, string orderdate, int tableid,int staffid)
    {

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "staforders";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@menuid", menuid);
        cmd.Parameters.AddWithValue("@quantity", quantity);
        cmd.Parameters.AddWithValue("@totalamount",totalamount);
        cmd.Parameters.AddWithValue("@orderdate", orderdate);
        cmd.Parameters.AddWithValue("@tableid", tableid);
        cmd.Parameters.AddWithValue("@staffid", staffid);
        cmd.ExecuteNonQuery();
    }
}