using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NYP.DAL
{
    public class NYPSqlConn
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection dbConn;
            String connString = ConfigurationManager.ConnectionStrings["NYPDB"].ConnectionString;
            dbConn = new SqlConnection(connString);
            return dbConn;
        }
    }
}