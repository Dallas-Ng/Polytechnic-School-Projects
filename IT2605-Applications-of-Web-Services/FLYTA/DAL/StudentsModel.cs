using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FLYTA.NYP_API;
using System.Data;
using System.Data.SqlClient;

namespace FLYTA.DAL
{
    public class StudentsModel
    {
        NYP_WSClient stud = new NYP_WSClient();
        SqlConnection CONNECTION = FLYTASqlConn.GetConnection();

        public DataSet getStudents(int OSEP_ID)
        {
            return stud.getStudents(OSEP_ID);
        }
    }
}