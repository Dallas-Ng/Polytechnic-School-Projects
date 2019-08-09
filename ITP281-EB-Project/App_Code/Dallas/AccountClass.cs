using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;


// DALLAS 180522Y
/// <summary>
/// Summary description for AccountClass
/// Account class uses Users table
/// Used for manipulation of accounts
/// 
/// Methods:
/// C:                      Insert(), InsertAll(),
/// R:                      Retrieve(), RetrieveAdmin()
/// U:                      Update(), UpdateAll(), RecentLoginUpdate(), 
/// D:                      Delete(),
/// Password:               PasswordUpdate(), resetPassword(),
/// ProfilePicture:         ImageUpload(), ImageRetrieve(),
/// Email:                  checkEmail(), checkEmailConfirmed(), updateEmailConfirmed(), 
/// LockoutSystem:          checkLockout(), ResetIncrement(),
/// Checking:               checkLoginID(), checkIsExist(), checkIsDeleted(), checkSignUp(), 
/// Searching:              searchQuery(), 
/// </summary>


// Most of these functions are utter garbage, because I can combine them, but I used the codes so much that im lazy to change it
// It works but its not that pretty

public class AccountClass
{
    /// <summary>
    /// Init Variables and Setting DB connString
    /// </summary>
    private string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;
    private string _Login_ID, _Password, _Name, _Email, _Role = "";
    private DateTime _Recent_Login, _Creation_Date, _DateofBirth;
    private string _isLockoutEnabled, _LockoutIncrement, _LockoutEndDate;

    /// <summary>
    /// Constructors
    /// </summary>
    public AccountClass(string Login_ID, string Password, DateTime Recent_Login, DateTime Creation_Date, string Name, string Email, DateTime DateofBirth, string Role)
    { // Used for Add.aspx
        _Login_ID = Login_ID.ToLower();
        _Password = Password;
        _Recent_Login = Recent_Login;
        _Creation_Date = Creation_Date;
        _Name = Name.ToLower();
        _Email = Email.ToLower();
        _DateofBirth = DateofBirth;
        _Role = Role.ToLower();
    }

    public AccountClass(string Login_ID, string Password, string Email, string Role)
    { // Used for Index.aspx
        _Login_ID = Login_ID.ToLower();
        _Password = Password;
        _Email = Email.ToLower();
        _Role = Role.ToLower();
    }

    public AccountClass(string Email, DateTime Creation_Date)
    {// Used for Change_Password.apsx
        _Email = Email.ToLower();
    }

    public AccountClass(string Login_ID, bool isLockoutEnabled, int LockoutIncrement, DateTime LockoutEndDate)
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

    public AccountClass() { }



    /// <summary>
    /// Get and Set Methods
    /// </summary>
    public string Login_ID
    {
        get { return _Login_ID; }
        set { _Login_ID = value.ToLower(); }
    }
    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }
    public DateTime Recent_Login
    {
        get { return _Recent_Login; }
        set { _Recent_Login = value; }
    }
    public DateTime Creation_Date
    {
        get { return _Creation_Date; }
        set { _Creation_Date = value; }
    }
    public string Name
    {
        get { return _Name; }
        set { _Name = value.ToLower(); }
    }
    public string Email
    {
        get { return _Email; }
        set { _Email = value.ToLower(); }
    }
    public DateTime DateofBirth
    {
        get { return _DateofBirth; }
        set { _DateofBirth = value; }
    }
    public string Role
    {
        get { return _Role; }
        set { _Role = value.ToLower(); }
    }
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


    /// <summary>
    /// Inserts a new user into the database
    /// </summary>
    /// <returns>
    /// 1 if successful, 0 if not
    /// </returns>
    public int Insert()
    {
        int output = 0;
        string queryStr = "INSERT INTO Users(Login_ID, Password, Email, Role)" +
                          "VALUES(@Login_ID, @Password, @Email, @Role)";
        // Opening SQL connection
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID);
                var hashedPassword = HasherClass.Hash(Password); //Hash password before into database
                cmd.Parameters.AddWithValue("@Password", hashedPassword);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Role", Role);

                output += cmd.ExecuteNonQuery();
            }
        }
        return output;
    }



    /// <summary>
    /// Inserts a new user into the database
    /// (Able to put in all the basic variables of the account)
    /// </summary>
    /// <returns>
    /// 1 if successful, 0 if not
    /// </returns>
    public int InsertAll()
    {
        int output = 0;
        string queryStr = "INSERT INTO Users(Login_ID, Password, Name, Email, DateofBirth, Role)" +
                          "VALUES(@Login_ID, @Password, @Name, @Email, @DateofBirth, @Role)";
        // Opening SQL connection
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID);
                var hashedPassword = HasherClass.Hash(Password); //Hash password before into database
                cmd.Parameters.AddWithValue("@Password", hashedPassword);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@DateofBirth", DateofBirth);
                cmd.Parameters.AddWithValue("@Role", Role);

                output += cmd.ExecuteNonQuery();
            }
        }
        return output;
    }



    /// <summary>
    /// Updates the user from the database
    /// </summary>
    /// <returns>
    /// 1 if successful, 0 if not
    /// </returns>
    public int Update()
    {
        int output = 0;
        string queryStr = "UPDATE Users SET Name = @Name, DateofBirth = @DateofBirth WHERE Login_ID = @Login_ID";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID);
                cmd.Parameters.AddWithValue("@Name", Name);
                if (DateofBirth == DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@DateofBirth", DateTime.MinValue);

                }
                else
                {
                    cmd.Parameters.AddWithValue("@DateofBirth", DateofBirth);
                }
                output += cmd.ExecuteNonQuery();
            }
        }

        return output;
    }



    /// <summary>
    /// Updates the user from the database
    /// (Able to update all basic variables of the account)
    /// </summary>
    /// <returns>
    /// 1 if successful, 0 if not
    /// </returns>
    public int UpdateAll()
    {
        int output = 0;
        string queryStr = "UPDATE Users SET Name = @Name, DateofBirth = @DateofBirth, Role = @Role WHERE Login_ID = @Login_ID";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@DateofBirth", DateofBirth);
                cmd.Parameters.AddWithValue("@Role", Role);

                output += cmd.ExecuteNonQuery();
            }
        }

        return output;
    }



    /// <summary>
    /// Retrieves all basic information from the account in the database
    /// </summary>
    /// <param name="foo">
    /// Foo = "Login_ID" of the user || Direct Input "all"
    /// Foo is the filter of the function
    /// If Foo == ALL, it retrieves every user from the database
    /// Else, it retrives the information from 1 user only.
    /// </param>
    /// <returns>
    /// userList that has all the basic variables
    /// </returns>
    public List<AccountClass> retrieve(string foo)
    {
        List<AccountClass> userList = new List<AccountClass>();

        //
        string queryStr;
        if (foo.ToLower() == "all")
        {
            queryStr = "SELECT * FROM Users WHERE IsDeleted = 0 ORDER BY Login_ID";
        }
        else if (foo.ToLower() == "deleted")
        {
            queryStr = "SELECT * FROM Users WHERE IsDeleted = 1 ORDER BY Login_Id";
        }
        else if (foo.ToLower() == "admin")
        {
            queryStr = "SELECT * FROM Users WHERE Role = 'admin' AND IsDeleted = 0";
        }
        else if (foo.ToLower() == "student")
        {
            queryStr = "SELECT * FROM Users WHERE Role = 'student' AND IsDeleted = 0";
        }
        else if (foo.ToLower() == "teacher")
        {
            queryStr = "SELECT * FROM Users WHERE Role = 'teacher' AND IsDeleted = 0";
        }
        else
        {
            queryStr = "SELECT * FROM Users WHERE Login_ID = @Login_ID";
        }

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", foo.ToLower());

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader != null) // If there is something to read
                    {
                        while (reader.Read())
                        {
                            Login_ID = reader["Login_ID"].ToString();
                            Name = reader["Name"].ToString();
                            Email = reader["Email"].ToString();
                            Role = reader["Role"].ToString();

                            DateTime Recent_Login = DateTime.Parse(reader["Recent_Login"].ToString());
                            DateTime Creation_Date = DateTime.Parse(reader["Creation_Date"].ToString());
                            DateTime DoB; // DateofBirth is a nullable DateTime variable, has to be checked if there is a value
                            if (DateTime.TryParse(reader["DateofBirth"].ToString(), out DoB))
                            {
                                // If parse is successful, DOB is set to the dateofbirth of the account retrieved
                            }
                            else
                            {
                                DoB = DateTime.MinValue;
                                // If parse not successfull, set DOB to minValue (01/01/00)
                            }

                            AccountClass eachUser = new AccountClass(Login_ID, null, Recent_Login, Creation_Date, Name, Email, DoB, Role);
                            userList.Add(eachUser);
                        }

                    }
                }
            }
        }
        return userList;
    }



    public List<AccountClass> retrieveAdmin(string foo, string bar)
    {
        List<AccountClass> userList = new List<AccountClass>();


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
                            Login_ID = reader["Login_ID"].ToString();
                            Name = reader["Name"].ToString();
                            Email = reader["Email"].ToString();
                            Role = reader["Role"].ToString();

                            DateTime Recent_Login = DateTime.Parse(reader["Recent_Login"].ToString());
                            DateTime Creation_Date = DateTime.Parse(reader["Creation_Date"].ToString());
                            DateTime DoB; // DateofBirth is a nullable DateTime variable, has to be checked if there is a value
                            if (DateTime.TryParse(reader["DateofBirth"].ToString(), out DoB))
                            {
                                // If parse is successful, DOB is set to the dateofbirth of the account retrieved
                            }
                            else
                            {
                                DoB = DateTime.MinValue;
                                // If parse not successfull, set DOB to minValue (01/01/00)
                            }

                            AccountClass eachUser = new AccountClass(Login_ID, null, Recent_Login, Creation_Date, Name, Email, DoB, Role);
                            userList.Add(eachUser);
                        }

                    }
                }
            }
        }
        return userList;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="foo"></param>
    /// <param name="bar"></param>
    /// <returns></returns>
    public List<AccountClass> retrieveLockoutInformation(string foo, string bar)
    {
        List<AccountClass> userList = new List<AccountClass>();


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
                            AccountClass eachUser = new AccountClass(reader["Login_ID"].ToString(), Convert.ToBoolean(reader["isLockoutEnabled"].ToString()), int.Parse(reader["LockoutIncrement"].ToString()), DateTime.Parse(reader["LockoutEndDate"].ToString()));
                            userList.Add(eachUser);
                        }

                    }
                }
            }
        }
        return userList;
    }

    /// <summary>
    /// Deletes the user from the database logically or physically
    /// </summary>
    /// <param name="Login_ID"></param>
    /// <param name="command">
    /// if command is Logical = does a logical delete
    /// if command is anything else = does a physical delete
    /// </param>
    /// <returns>
    /// 1 if successful, 0 is not
    /// </returns>
    public int Delete(string Login_ID, string command)
    {
        int output = 0;
        string queryStr;

        if (command == "physical")
        {
            queryStr = "DELETE FROM Users WHERE Login_ID = @Login_ID";

        }
        else
        {
            queryStr = "UPDATE Users SET isDeleted = 1 WHERE Login_ID = @Login_ID";
        }

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID.ToLower());
                output += cmd.ExecuteNonQuery();
            }
        }
        return output;
    }



    /// <summary> 
    /// Updates Recent Login with current time
    /// </summary>
    /// <returns>
    /// 1 if successful, 0 if not
    /// </returns>
    public int RecentLoginUpdate(string Login_ID)
    {
        string queryStr = "UPDATE Users SET Recent_Login = @Recent_Login WHERE Login_ID = @Login_ID";
        int output = 0;

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                DateTime newDateTime = DateTime.Now;
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID.ToLower());
                cmd.Parameters.AddWithValue("@Recent_Login", newDateTime);
                output = cmd.ExecuteNonQuery();
            }
        }
        return output;
    }



    /// <summary>
    /// Checks and update password variable of the account
    /// Uses HasherClass to verify password and hash the new password if it is correct
    /// </summary>
    /// <returns>
    /// 1 if successful, 0 if not
    /// </returns>
    public int PasswordUpdate(string Login_ID, string OldPassword, string NewPassword)
    {
        int output = 0;
        string currentPassword = "";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Login_ID = @Login_ID", conn))
            {

                cmd.Parameters.AddWithValue("@Login_ID", Login_ID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        currentPassword = reader["Password"].ToString();
                    }
                }
            }

            using (SqlCommand cmd = new SqlCommand("UPDATE Users SET Password = @Password WHERE Login_ID = @Login_ID", conn))
            {
                if (HasherClass.Verify(OldPassword, currentPassword)) // Checks old hash with current hash
                {
                    cmd.Parameters.AddWithValue("@Login_ID", Login_ID.ToLower());
                    string hashNewPassword = HasherClass.Hash(NewPassword); // Hash password before into database
                    cmd.Parameters.AddWithValue("@Password", hashNewPassword);
                    output = cmd.ExecuteNonQuery();
                }
            }
        }
        return output;
    }



    /// <summary>
    /// Directly sets the password of the user in the database
    /// Uses Login ID to enter
    /// Used for forgot password
    /// </summary>
    /// <returns>
    /// Returns new password in string
    /// </returns>
    public int resetPassword(string newPassword, string Login_ID)
    {
        int output = 0;
        string queryStr = "UPDATE Users SET Password = @Hashed_Password WHERE Login_ID = @Login_ID";


        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID.ToLower());
                var Hashed_Password = HasherClass.Hash(newPassword);
                cmd.Parameters.AddWithValue("@Hashed_Password", Hashed_Password);
                output = cmd.ExecuteNonQuery();
            }
        }
        return output;
    }



    /// <summary>
    /// Checks if Login ID is in the current Database
    /// </summary>
    /// <returns>
    /// Returns role of the account if it is valid
    /// Returns "none" if there is no account
    /// </returns>
    public string checkIsExist(string Login_ID, string Password)
    {
        string output = "none";
        string queryStr = "SELECT * FROM Users WHERE Login_ID = @Login_ID";

        // Opening SQL connection
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID.ToLower());

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (!Convert.ToBoolean(reader["isDeleted"]))
                        {
                            if (HasherClass.Verify(Password, reader["Password"].ToString()))
                            {
                                output = reader["Role"].ToString();
                                AccountClass Acc = new AccountClass();
                                Acc.RecentLoginUpdate(Login_ID); // Update Recent Login
                            }
                        }
                        else
                        {
                            output = "deleted";
                        }
                    }
                }
            }
        }
        return output;
    }



    /// <summary>
    /// Checks if Email exists inside the database
    /// </summary>
    /// <returns>
    /// Returns null if email does not exist or if isDeleted is true
    /// Returns login id if it is valid
    /// </returns>
    public string checkEmail(string nEmail)
    {
        string Login_ID = "none";
        string queryStr = "SELECT Login_ID, isDeleted FROM Users WHERE Email = @Email";

        // Opening SQL connection
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Email", nEmail.ToLower());

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (!Convert.ToBoolean(reader["isDeleted"]))
                        {
                            Login_ID = reader["Login_ID"].ToString();
                            // WRITE CODE TO APPEND NEW PASSWORD
                        }
                    }
                }
            }
        }
        return Login_ID;
    }



    public int checkSignUp()
    {
        int output = 0;

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM USERS WHERE Login_ID = @Login_ID", conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID.ToLower());
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        output = 1;
                    }

                }
            }

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM USERS WHERE Email = @Email", conn))
            {
                cmd.Parameters.AddWithValue("@Email", Email.ToLower());
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        output = 2;
                    }

                }
            }
        }

        return output;
    }



    public int ImageUpload(string ImageName, string Login_ID)
    {
        string queryStr = "UPDATE Users SET ProfilePictureUrl = @ProfilePictureUrl WHERE Login_ID = @Login_ID";
        int output = 0;

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID);
                cmd.Parameters.AddWithValue("@ProfilePictureUrl", ImageName);
                output = cmd.ExecuteNonQuery();
            }
        }
        return output;
    }



    public string ImageRetrieve(string Login_ID)
    {
        string queryStr = "SELECT ProfilePictureUrl FROM Users WHERE Login_ID = @Login_ID";
        string output = "";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            output = reader["ProfilePictureUrl"].ToString();
                        }
                    }
                }
            }
        }
        return output;
    }



    public int updateEmailConfirmed(string Email)
    {
        int output = 0;
        string queryStr = "UPDATE Users SET isEmailConfirmed = 1 WHERE Email = @Email";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Email", Email);
                output = cmd.ExecuteNonQuery();
            }
        }
        return output;
    }



    public bool checkEmailConfirmed(string Login_ID)
    {
        bool output = false;
        string queryStr = "SELECT isEmailConfirmed FROM Users WHERE Login_ID = @Login_ID";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            output = Convert.ToBoolean(reader["isEmailConfirmed"]);
                        }
                    }
                }
            }
        }
        return output;
    }



    public List<AccountClass> searchQuery(string foo)
    {
        List<AccountClass> userList = new List<AccountClass>();
        string queryStr = "SELECT Login_ID, Name, Email, Role FROM Users WHERE Login_ID LIKE '%'+ @Filter+'%' OR Name LIKE '%'+ @Filter+'%'  OR Email LIKE '%'+ @Filter+'%' OR Role LIKE '%'+ @Filter+'%' ";

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
                            Login_ID = reader["Login_ID"].ToString();
                            Name = reader["Name"].ToString();
                            Email = reader["Email"].ToString();
                            Role = reader["Role"].ToString();
                            AccountClass eachUser = new AccountClass(Login_ID, null, Recent_Login, Creation_Date, Name, Email, DateTime.MinValue, Role);
                            userList.Add(eachUser);
                        }

                    }
                }
            }
        }
        return userList;
    }


    public List<AccountClass> searchQueryLockoutInformation(string foo)
    {
        List<AccountClass> userList = new List<AccountClass>();
        string queryStr = "SELECT * FROM Users WHERE Login_ID LIKE '%'+ @Filter+'%' OR Name LIKE '%'+ @Filter+'%'  OR Email LIKE '%'+ @Filter+'%' OR Role LIKE '%'+ @Filter+'%' ";

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
                            AccountClass eachUser = new AccountClass(reader["Login_ID"].ToString(), Convert.ToBoolean(reader["isLockoutEnabled"].ToString()), int.Parse(reader["LockoutIncrement"].ToString()), DateTime.Parse(reader["LockoutEndDate"].ToString()));
                            userList.Add(eachUser);
                        }

                    }
                }
            }
        }
        return userList;
    }



    public bool checkisDeleted(string Login_ID)
    {
        bool deleted = false;
        string queryStr = "SELECT isDeleted FROM Users WHERE Login_ID = @Login_ID";

        // Opening SQL connection
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID.ToLower());

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (Convert.ToBoolean(reader["isDeleted"]))
                        {
                            deleted = true;
                        }
                    }
                }
            }
        }
        return deleted;
    }



    public static int ActivateAccount(string nLogin_ID)
    {
        int output = 0;

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE Users SET isDeleted = 0 WHERE Login_ID = @Login_ID", conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", nLogin_ID.ToLower());
                output += cmd.ExecuteNonQuery();
            }
        }
        return output;
    }
}