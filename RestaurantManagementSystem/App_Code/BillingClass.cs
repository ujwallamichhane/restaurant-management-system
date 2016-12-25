using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Billing
/// </summary>
public class BillingClass
{
    GlobalConnection gc = new GlobalConnection();
    private  int _tableid;
    private string _customername;
    private DateTime _ordereddate;
    private long _phone;

    public  int Tableid {
        get { return _tableid; }
            set { _tableid = value; }
    }
    public string Customername
    {
        get { return _customername; }
        set { _customername= value; }
    }
    public DateTime Ordereddate
    {
        get { return _ordereddate; }
        set { _ordereddate= value; }
    }
    public long Phone
    {
        get { return _phone; }
        set { _phone = value; }
    }



    //this method is used to get the bill of online order
    public DataTable getcustomerorder() {
        string data = "SELECT customerorder.Cust_FName,customerorder.Cust_LName,customerorder.MenuId,customerorder.contact, menu.price, food.foodname, foodcategory.Type,customerorder.quantity, customerorder.totalamount,customerorder.orderdate FROM customerorder AS customerorder INNER JOIN menu AS menu ON customerorder.menuid = menu.MENUID INNER JOIN food AS food ON menu.FOODID = food.FOODID INNER JOIN foodcategory AS foodcategory ON menu.FCID = foodcategory.FCID  where customerorder.cust_FName = '" + _customername+"' and customerorder.orderdate='"+_ordereddate+"'and customerorder.contact='"+_phone+"'";
        SqlDataAdapter sda = new SqlDataAdapter(data,gc.cn);
        DataSet ds = new DataSet();
        sda.Fill(ds,"stafforder");
        return ds.Tables[0];
    }

    //this method is used to get the bill of the customer in the restaurant billing
    public DataTable gettheorder()
    {
        string data = "SELECT staff.firstname, stafforder.menuid, food.foodname, foodcategory.Type, menu.price,stafforder.quantity, stafforder.totalamount FROM stafforder AS stafforder INNER JOIN menu AS menu ON stafforder.menuid = menu.MENUID INNER JOIN staff AS staff ON stafforder.StaffID = staff.STAFFID INNER JOIN tables AS tables ON stafforder.Tableid = tables.TableId INNER JOIN food AS food ON menu.FOODID = food.FOODID INNER JOIN foodcategory AS foodcategory ON menu.FCID = foodcategory.FCID  where tables.Tableid = '" + _tableid + "'";
        SqlDataAdapter sda = new SqlDataAdapter(data, gc.cn);
        DataSet ds = new DataSet();
        sda.Fill(ds, "stafforder");
        return ds.Tables[0];
    }
    //add the data to ordertable from customer data after we print the bill
    public void addfromcustomerorder(string name, DateTime orderdate,long phone) {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "addfromcustorders";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@custfname", name);
        cmd.Parameters.AddWithValue("@orderdate", orderdate);
        cmd.Parameters.AddWithValue("@contact", phone);
        cmd.ExecuteNonQuery();
    }
    //deletes the data from customerorder table after bill is print
    public void deletefromcustomerorder(string name, DateTime orderdate, long phone)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "deletefromcustorder";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@Orderdate", orderdate);
        cmd.Parameters.AddWithValue("@contact", phone);
        cmd.ExecuteNonQuery();
    }
    //add the data to ordertable from the stafforder table after we print the bill
    public void addfromstafforder(int tableid)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "addfromstafforders";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tableid", tableid);        
        cmd.ExecuteNonQuery();
    }
    //deletes the data from stafforder after we print the bill
    public void deletefromstafforder(int tableid)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "deletefromstafforders";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tableid", tableid);
        cmd.ExecuteNonQuery();
    }
    //this method get the orderid that has been inserted from customeroeder table to insert into billing table.
    public DataTable getcustorderid(string name,DateTime date,long phone) {
        string data = "select orderid from ordertable where custfname='"+name+"' and orderdate='"+date+"' and custcontact='"+phone+"'";
        SqlDataAdapter sda = new SqlDataAdapter(data,gc.cn);
        DataSet ds = new DataSet();
        sda.Fill(ds,"orderid");
        return ds.Tables[0];
    }
    //this method get the order that has been inserted from stafforder table to insert into billing table.
    public DataTable getstafforderid(int tableid, DateTime date)
    {
        string data = "select orderid from ordertable where tableid='"+tableid+"' and orderdate='" + date + "'";
        SqlDataAdapter sda = new SqlDataAdapter(data, gc.cn);
        DataSet ds = new DataSet();
        sda.Fill(ds, "orderid");
        return ds.Tables[0];
    }

    //add the orderid into the billing table and finally billing is complete
    public void addbill(int orderid) {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "addbills";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@orderid", orderid);
        cmd.ExecuteNonQuery();
    }
    
}