using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FLYTA.DAL
{
    public class FLYTASqlConn
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection dbConn;
            String connString = ConfigurationManager.ConnectionStrings["FLYDB"].ConnectionString;
            dbConn = new SqlConnection(connString);
            return dbConn;
        }
    }
}