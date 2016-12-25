using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for UserClass
/// </summary>
public class UserClass
{
    GlobalConnection gc = new GlobalConnection();
    private int _uid;
    private string _password;
    private string _role;
    private string _username;
    public string username
    {
        get { return _username; }
        set { _username = value; }
        }
        public string password {
        get { return _password; }
        set { _password = value; }
    }
    public string role {
        get { return _role; }
        set { _role = value; }
    }
    public int id {
        get { return _uid; }
        set { _uid = value; }
    }
   
    public DataTable checkUsers() {
        String data = "Select*from users where username='"+_username+"'and password='"+_password+"'";
        SqlDataAdapter da = new SqlDataAdapter(data,gc.cn);
        DataSet ds = new DataSet();
        da.Fill(ds,"users");
        return ds.Tables[0];
    }
    public DataTable checkroleid() {
        String data = "Select RID from role where rolename='" + role + "'";
        SqlDataAdapter da = new SqlDataAdapter(data,gc.cn);
        DataSet ds = new DataSet();
        da.Fill(ds,"roleid");
        return ds.Tables[0];
    }
    public DataTable checkrole(int x)
    {
        String data = "Select rolename from role where RID='"+ x+ "'";
        SqlDataAdapter da = new SqlDataAdapter(data, gc.cn);
        DataSet ds = new DataSet();
        da.Fill(ds, "role");
        return ds.Tables[0];
    }
    public DataTable searchuser()
    {
        String data = "Select * from users where UID='"+_uid+"'";
        SqlDataAdapter da = new SqlDataAdapter(data, gc.cn);
        DataSet ds = new DataSet();
        da.Fill(ds, "user");
        return ds.Tables[0];
    }
    public DataTable searchuserfromstaffid()
    {
        String data = "Select * from users where StaffID='" +_uid + "'";
        SqlDataAdapter da = new SqlDataAdapter(data, gc.cn);
        DataSet ds = new DataSet();
        da.Fill(ds, "user");
        return ds.Tables[0];
    }

    public void  saveusers(String username,string password,int RID) {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "adduser";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@username",username);
        cmd.Parameters.AddWithValue("@password",password);
        cmd.Parameters.AddWithValue("@RID", RID);
        cmd.ExecuteNonQuery();


    }
    public void addusers(String username, string password, int RID,int Staffid)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "adduser2";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@password", password);
        cmd.Parameters.AddWithValue("@RID", RID);
        cmd.Parameters.AddWithValue("@staffId",Staffid);
        cmd.ExecuteNonQuery();


    }

    public void updateusers(int UID,String username,string password,int RID) {

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "updateuser";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UID",UID);
        cmd.Parameters.AddWithValue("@username",username);
        cmd.Parameters.AddWithValue("@Password",password);
        cmd.Parameters.AddWithValue("@RID",RID);
        cmd.ExecuteNonQuery();
    }
    public void adduserrole(int UID, int RID) {

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "adduserrole";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UID",UID);
        cmd.Parameters.AddWithValue("@RID",RID);
        cmd.ExecuteNonQuery();

    }
    public void updateuserrole(int UID, int RID)
    {

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "updateuserrole";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UID", UID);
        cmd.Parameters.AddWithValue("@RID", RID);
        cmd.ExecuteNonQuery();

    }



}