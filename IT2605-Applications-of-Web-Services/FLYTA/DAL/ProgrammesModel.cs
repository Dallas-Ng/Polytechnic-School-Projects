using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FLYTA.DAL
{
    public class ProgrammesModel
    {
        public ProgrammesModel()
        {

        }

        SqlConnection CONNECTION = FLYTASqlConn.GetConnection();

        public DataSet getProgramme(string Id)
        {
            DataSet programmes = new DataSet();
            SqlDataAdapter da;

            string queryString = "SELECT * FROM OSEP where Id = @Id";

            try
            {
                da = new SqlDataAdapter(queryString, CONNECTION);
                da.SelectCommand.Parameters.AddWithValue("@Id", Id);
                da.Fill(programmes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CONNECTION.Close();
            }

            return programmes;
        }

        public DataSet getAllProgrammes()
        {
            DataSet programmes = new DataSet();
            SqlDataAdapter da;

            string queryString = "SELECT * FROM OSEP";

            try
            {
                da = new SqlDataAdapter(queryString, CONNECTION);
                da.Fill(programmes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CONNECTION.Close();
            }

            return programmes;
        }

        public DataSet getAllAvailableProgrammes()
        {
            DataSet programmes = new DataSet();
            SqlDataAdapter da;

            string queryString = "SELECT * FROM OSEP WHERE Quota-No_Of_Registered != 0";

            try
            {
                da = new SqlDataAdapter(queryString, CONNECTION);
                da.Fill(programmes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CONNECTION.Close();
            }

            return programmes;
        }

        public int InsertProgramme(string title, string description, string duration, string type, int quota, int registered, int fees)
        {
            int output = 0;
            string queryStr = "INSERT INTO OSEP VALUES(@title, @description, @duration, @type, @quota, @registered, @fees)";

            try
            {
                CONNECTION.Open();
                using (SqlCommand cmd = new SqlCommand(queryStr, CONNECTION))
                {
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@duration", duration);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@quota", quota);
                    cmd.Parameters.AddWithValue("@registered", registered);
                    cmd.Parameters.AddWithValue("@fees", fees);
                    output += cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                output = 2;
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                CONNECTION.Close();
            }
            return output;
        }

        public int IncrementSeat(int progId)
        {
            int output = 0;
            string queryStr = "UPDATE OSEP SET No_Of_Registered = No_Of_Registered + 1 WHERE Id=@id";

            try
            {
                CONNECTION.Open();
                using (SqlCommand cmd = new SqlCommand(queryStr, CONNECTION))
                {
                    cmd.Parameters.AddWithValue("@id", progId);
                    output += cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                CONNECTION.Close();
            }
            return output;
        }
    }
}