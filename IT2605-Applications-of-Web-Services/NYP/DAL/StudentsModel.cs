using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace NYP.DAL
{
    public class StudentsModel
    {
        private String errMsg;
        NYPSqlConn sqlConn = new NYPSqlConn();

        public DataSet getStudents(int OSEP_ID) //List of Students in FLYTA
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet studentsData;

            SqlConnection conn = NYPSqlConn.GetConnection();
            studentsData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT * FROM Registration WHERE OSEP_ID =@OSEP_ID");

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.SelectCommand.Parameters.AddWithValue("@OSEP_ID", OSEP_ID);
                da.Fill(studentsData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return studentsData;
        }

        public int InsertStudent(string Name, string Admin_No, string Course, string Contact_No, string PEM_Group, string Emergency_Person, string Emergency_Contact, string OSEP_ID)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;

            sql = new StringBuilder();
            sql.AppendLine("INSERT INTO Registration VALUES(@Name, @Admin_No, @Course, @Contact_No, @PEM_Group, @Emergency_Person, @Emergency_Contact, @OSEP_ID)");
            SqlConnection conn = NYPSqlConn.GetConnection();
            try
            {
                conn.Open();
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@Name", Name);
                sqlCmd.Parameters.AddWithValue("@Admin_No", Admin_No);
                sqlCmd.Parameters.AddWithValue("@Course", Course);
                sqlCmd.Parameters.AddWithValue("@Contact_No", Contact_No);
                sqlCmd.Parameters.AddWithValue("@PEM_Group", PEM_Group);
                sqlCmd.Parameters.AddWithValue("@Emergency_Person", Emergency_Person);
                sqlCmd.Parameters.AddWithValue("@Emergency_Contact", Emergency_Contact);
                sqlCmd.Parameters.AddWithValue("@OSEP_ID", OSEP_ID);
                result = sqlCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;

            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }
}