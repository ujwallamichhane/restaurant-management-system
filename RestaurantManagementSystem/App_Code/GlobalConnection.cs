using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for GlobalConnection
/// </summary>
public class GlobalConnection
{
    public SqlConnection cn;
    public static string username;
    public static int uid;
    public static int staffid;
    public GlobalConnection()
    {
        String mycon = System.Configuration.ConfigurationManager.AppSettings.Get("MyConnection").ToString();
        cn = new SqlConnection(mycon);
        cn.Open();

    }
}