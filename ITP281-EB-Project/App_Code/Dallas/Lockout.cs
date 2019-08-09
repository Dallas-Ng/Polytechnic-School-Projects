using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Lockout
/// </summary>
public class Lockout
{
    private string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;

    private string _isLockoutEnabled, _LockoutIncrement, _LockoutEndDate, _Login_ID;

    public string isLockoutEnabled
    {
        get { return _isLockoutEnabled; }
        set { _isLockoutEnabled = value; }
    }

    public string LockoutIncrement
    {
        get { return _LockoutIncrement; }
        set { _LockoutIncrement = value; }
    }
    public string LockoutEndDate
    {
        get { return _LockoutEndDate; }
        set { _LockoutEndDate = value; }
    }
    public string Login_ID
    {
        get { return _Login_ID; }
        set { _Login_ID = value; }
    }

    public Lockout(string Login_ID, bool isLockoutEnabled, int LockoutIncrement, DateTime LockoutEndDate)
    {
        this.Login_ID = Login_ID;
        
        if (isLockoutEnabled)
        {
            this.isLockoutEnabled = "Locked Out";
        }
        else
        {
            this.isLockoutEnabled = "Not Locked";
        }

        this.LockoutIncrement = LockoutIncrement.ToString();

        this.LockoutEndDate = LockoutEndDate.ToString();
    }



    /// <summary>
    /// Increase the increment count by 1
    /// </summary>
    /// <returns>
    /// Returns 1 if successful
    /// </returns>
    public static int AddIncrement(string Login_ID)
    {
        int output = 0;

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE Users SET LockoutIncrement = LockoutIncrement + 1 WHERE Login_ID = @Login_ID", conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID);
                output += cmd.ExecuteNonQuery();
            }
        }
        return output;
    }





    /// <summary>
    /// Gets increment from database of the user
    /// </summary>
    /// <returns>
    /// Returns the increment count
    /// Else 0
    /// </returns>
    public static int GetIncrement(string Login_ID)
    {
        int output = 0;

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT LockoutIncrement FROM Users WHERE Login_ID = @Login_ID", conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        output = int.Parse(reader["LockoutIncrement"].ToString());
                    }
                }
            }
        }
        return output;
    }



    /// <summary>
    /// Resets increment of the user
    /// </summary>
    public static int ResetIncrement(string Login_ID)
    {
        int output = 0;

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE Users SET LockoutIncrement = 0 WHERE Login_ID = @Login_ID", conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID);
                output += cmd.ExecuteNonQuery();
            }
        }
        return output;
    }



    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static int CheckAccounts()
    {
        int output = 0;

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE Users SET isLockoutEnabled = 1, LockoutEndDate = @LockoutEndDate, LockoutIncrement = 0 WHERE LockoutIncrement >= 4 ", conn))
            {
                cmd.Parameters.AddWithValue("@LockoutEndDate", DateTime.Now.AddMinutes(10));
                output += cmd.ExecuteNonQuery();
            }
        }
        return output;
    }



    /// <summary>
    /// Returns boolean of isLockedoutEnabled of User
    /// </summary>
    public static bool CheckAccount(string Login_ID)
    {
        bool output = false;

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT isLockoutEnabled FROM Users WHERE Login_ID = @Login_ID", conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        output = Boolean.Parse(reader["isLockoutEnabled"].ToString());
                    }
                }
            }
        }
        return output;
    }



    /// <summary>
    /// Cchecks if lockout end date is over, then reset those accounts
    /// </summary>
    public static int ResetAccounts()
    {
        int output = 0;

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE Users SET isLockoutEnabled = 0, LockoutEndDate = @LockoutEndDate WHERE LockoutEndDate < @Date", conn))
            {
                cmd.Parameters.AddWithValue("@LockoutEndDate", DateTime.Now.AddDays(-1));
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                output += cmd.ExecuteNonQuery();
            }
        }
        return output;
    }


    public List<Lockout> retrieveAdmin(string foo, string bar)
    {
        List<Lockout> data = new List<Lockout>();


        string queryStr = "";

        if (foo != null && bar != null)
        {
            if (foo == "'student'" || foo == "'admin'" || foo == "'teacher'")
            {
                queryStr = "SELECT * FROM Users WHERE IsDeleted = 0 and Role = " + foo + " ORDER BY " + bar;
            }
            else if (foo == "all")
            {
                queryStr = "SELECT * FROM Users ORDER BY " + bar;
            }
            else if (foo == "'deleted'")
            {
                queryStr = "SELECT * FROM Users WHERE IsDeleted = 1 ORDER BY " + bar;

            }
            else
            {
                foo = foo.Substring(1, foo.Length - 2);
                queryStr = "SELECT * FROM Users WHERE Login_ID = @Login_ID";
            }
        }
        else if (foo == null && bar != null)
        {
            queryStr = "SELECT * FROM Users WHERE IsDeleted = 0 ORDER BY " + bar;
        }
        else if (foo != null && bar == null)
        {
            if (foo == "'student'" || foo == "'admin'" || foo == "'teacher'")
            {
                queryStr = "SELECT * FROM Users WHERE IsDeleted = 0 and Role = " + foo + " ORDER BY Login_ID";
            }
            else if (foo == "all")
            {
                queryStr = "SELECT * FROM Users";
            }
            else if (foo == "'deleted'")
            {
                queryStr = "SELECT * FROM Users WHERE IsDeleted = 1";
            }
            else
            {
                foo = foo.Substring(1, foo.Length - 2);
                queryStr = "SELECT * FROM Users WHERE Login_ID = @Login_ID";
            }

        }
        else if (foo == null && bar == null)
        {
            queryStr = "SELECT * FROM Users WHERE IsDeleted = 0 ORDER BY Login_ID";
        }


        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                if (foo != null)
                {
                    cmd.Parameters.AddWithValue("@Login_ID", foo.ToLower());
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader != null) // If there is something to read
                    {
                        while (reader.Read())
                        {
                            Lockout eachUser = new Lockout(reader["Login_ID"].ToString(), Convert.ToBoolean(reader["isLockedoutEnabled"].ToString()), int.Parse(reader["LockoutIncrement"].ToString()), DateTime.Parse(reader["LockoutEndDate"].ToString()));
                            data.Add(eachUser);
                        }

                    }
                }
            }
        }
        return data;
    }

    public List<Lockout> searchQuery(string foo)
    {
        List<Lockout> data = new List<Lockout>();
        string queryStr = "SELECT * WHERE Login_ID LIKE '%'+ @Filter+'%' OR Name LIKE '%'+ @Filter+'%'  OR Email LIKE '%'+ @Filter+'%' OR Role LIKE '%'+ @Filter+'%' ";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Filter", foo.ToLower());

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader != null) // If there is something to read
                    {
                        while (reader.Read())
                        {
                            Lockout eachUser = new Lockout(reader["Login_ID"].ToString(), Convert.ToBoolean(reader["isLockedEnabled"].ToString()), int.Parse(reader["LockoutIncrement"].ToString()), DateTime.Parse(reader["LockoutEndDate"].ToString()));
                            data.Add(eachUser);
                        }

                    }
                }
            }
        }
        return data;
    }
}