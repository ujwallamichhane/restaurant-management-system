using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Staff
/// </summary>
public class Staff
{
    public Staff()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private string _name;
    private int _id;
    private string _post;
    public string Name {
        get { return _name; }
        set { _name = value; }
    }
    public int ID {
        get { return _id; }
        set { _id = value; }
    }
    public string Post {
        get { return _post; }
        set { _post = value; }
    }
    GlobalConnection gc = new GlobalConnection();

    public DataTable searchstaff() {
        string data = "Select *from staff where staffid='"+_id+"'";
        SqlDataAdapter sdr = new SqlDataAdapter(data,gc.cn);
        DataSet ds = new DataSet();
        sdr.Fill(ds,"search");
        return ds.Tables[0];
    }
    public DataTable getstaff()
    {
        string data = "Select *from staff where firstname='" + _name+ "' and post='"+_post+"'";
        SqlDataAdapter sdr = new SqlDataAdapter(data, gc.cn);
        DataSet ds = new DataSet();
        sdr.Fill(ds, "search");
        return ds.Tables[0];
    }

    public void addstaff(string fname,string mname,string lname,string gender,string dob, int contact,string father,string mother,string gfather,string address,int experience,string trainings,string post,int salary,string photo) {
        SqlCommand sql = new SqlCommand();
        sql.Connection = gc.cn;
        sql.CommandText = "addstaff";
        sql.CommandType = CommandType.StoredProcedure;
        sql.Parameters.AddWithValue("@firstname",fname);
        sql.Parameters.AddWithValue("@midname", mname);
        sql.Parameters.AddWithValue("@lastname", lname);
        sql.Parameters.AddWithValue("@gender", gender);
        sql.Parameters.AddWithValue("@dob", dob);
        sql.Parameters.AddWithValue("@contactnumber",contact);
        sql.Parameters.AddWithValue("@fathername", father);
        sql.Parameters.AddWithValue("@mothername", mother);
        sql.Parameters.AddWithValue("@grandfathername", gfather);
        sql.Parameters.AddWithValue("@address", address);
        sql.Parameters.AddWithValue("@experience", experience);
        sql.Parameters.AddWithValue("@trainings", trainings);
        sql.Parameters.AddWithValue("@post", post);
        sql.Parameters.AddWithValue("@salary", salary);
        sql.Parameters.AddWithValue("@photo", photo);
        sql.ExecuteNonQuery();

    }
    public void updatestaff(int staffid,string fname, string mname, string lname, string gender, string dob, int contact,string father, string mother, string gfather, string address, int experience, string trainings, string post, int salary, string photo) {
        SqlCommand sql = new SqlCommand();
        sql.Connection = gc.cn;
        sql.CommandText = "updatestaff";
        sql.CommandType = CommandType.StoredProcedure;
        sql.Parameters.AddWithValue("@staffid",staffid);
        sql.Parameters.AddWithValue("@fname",fname);
        sql.Parameters.AddWithValue("@midname", mname);
        sql.Parameters.AddWithValue("@lastname", lname);
        sql.Parameters.AddWithValue("@gender", gender);
        sql.Parameters.AddWithValue("@dob", dob);
        sql.Parameters.AddWithValue("@contact",contact);
        sql.Parameters.AddWithValue("@fathername", father);
        sql.Parameters.AddWithValue("@mothername", mother);
        sql.Parameters.AddWithValue("@grandfathername", gfather);
        sql.Parameters.AddWithValue("@address", address);
        sql.Parameters.AddWithValue("@experience", experience);
        sql.Parameters.AddWithValue("@trainings", trainings);
        sql.Parameters.AddWithValue("@post", post);
        sql.Parameters.AddWithValue("@salary", salary);
        sql.Parameters.AddWithValue("@photo", photo);
        sql.ExecuteNonQuery();


    }
    public void deletestaff(int x) {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = gc.cn;
        cmd.CommandText = "deletestaff";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@staffid",x);
        cmd.ExecuteNonQuery();

    }

}