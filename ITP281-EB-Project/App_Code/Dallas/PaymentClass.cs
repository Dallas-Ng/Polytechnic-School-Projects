using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;



/// <summary>
/// Summary description for PaymentClass
/// Payment Class uses UsersPayment table
/// Used for manipulation of Payment Info only
/// 
/// Methods:
/// C: Insert(),
/// R: Retrieve(),
/// U: Update(), 
/// D: Delete(),
/// 
/// Database Variables for table Users:
/// Basic: 
///     Card_Num, Card_Num_Four (Needed for display purposes only)
///     Card_Name, Card_Exp_Date, CCV
///     PK is Login_ID as FK from Users Table
/// </summary>
public class PaymentClass
{
    /// <summary>
    /// Init Variables and Setting DB connString
    /// </summary>
    string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;
    private string _Card_Num, _Card_Num_Four, _Card_Name, _Card_Exp_Date, _CCV, _Login_ID;



    /// <summary>
    /// Constructors
    /// </summary>
    public PaymentClass(string Card_Num, string Card_Num_Four, string Card_Name, string Card_Exp_Date, string CCV, string Login_ID)
    {
        _Card_Num = Card_Num;
        _Card_Num_Four = Card_Num_Four;
        _Card_Name = Card_Name;
        _Card_Exp_Date = Card_Exp_Date;
        _CCV = CCV;
        _Login_ID = Login_ID;

    }

    public PaymentClass() { }



    /// <summary>
    /// Get and Set Methods
    /// </summary>
    public string Card_Num
    {
        get { return _Card_Num; }
        set { _Card_Num = value; }
    }

    public string Card_Num_Four
    {
        get { return _Card_Num_Four; }
        set { _Card_Num_Four = value; }
    }

    public string Card_Name
    {
        get { return _Card_Name; }
        set { _Card_Name = value.ToLower(); }
    }

    public string Card_Exp_Date
    {
        get { return _Card_Exp_Date; }
        set { _Card_Exp_Date = value; }
    }

    public string CCV
    {
        get { return _CCV; }
        set { _CCV = value; }
    }

    public string Login_ID
    {
        get { return _Login_ID; }
        set { _Login_ID = value.ToLower(); }
    }



    /// <summary>
    /// Inserts a new payment info into the database
    /// </summary>
    /// <returns>
    /// 1 if successful, 0 if not
    /// </returns>
    public int Insert()
    {
        int result = 0;
        string queryStr = "INSERT INTO UsersPayment(Card_Num, Card_Num_Four, Card_Name, Exp_Date, CCV, Login_ID)"
                        + "values (@Card_Num, @Card_Num_Four, @Card_Name, @Exp_Date, @CCV, @Login_ID)";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                var Hash_Card_Num = HasherClass.Hash(Card_Num.Substring(0, 12));
                cmd.Parameters.AddWithValue("@Card_Num", Hash_Card_Num);
                cmd.Parameters.AddWithValue("@Card_Num_Four", Card_Num_Four);
                cmd.Parameters.AddWithValue("@Card_Name", Card_Name);
                cmd.Parameters.AddWithValue("@Exp_Date", Card_Exp_Date);
                cmd.Parameters.AddWithValue("@CCV", CCV);
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID);

                result += cmd.ExecuteNonQuery();
            }
        }
        return result;
    }

    

    /// <summary>
    /// Updates payment info for user from database
    /// </summary>
    /// <returns>
    /// 1 if successful, 0 if not
    /// </returns>
    public int Update(string Card_Num, string Card_Num_Four, string nCard_Name, string nCard_Exp_Date, string nCCV, string nLogin_ID)
    {
        int output = 0;
        string queryStr = "";
        queryStr = "UPDATE UsersPayment SET Card_Num = @Card_Num, Card_Num_Four = @Card_Num_Four, Card_Name = @Card_Name, Exp_Date = @Exp_date, CCV = @CCV WHERE Login_ID = @Login_ID";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                var Hash_Card_Num = HasherClass.Hash(Card_Num.Substring(0, 12));
                cmd.Parameters.AddWithValue("@Card_Num", Hash_Card_Num);
                cmd.Parameters.AddWithValue("@Card_Num_Four", Card_Num_Four);
                cmd.Parameters.AddWithValue("@Card_Name", nCard_Name.ToLower());
                cmd.Parameters.AddWithValue("@Exp_Date", nCard_Exp_Date);
                var Hash_CCV = HasherClass.Hash(nCCV);
                cmd.Parameters.AddWithValue("@CCV", Hash_CCV);
                cmd.Parameters.AddWithValue("@Login_ID", nLogin_ID.ToLower());

                output += cmd.ExecuteNonQuery();
            }
        }

        return output;
    }

    /// <summary>
    /// Uses login id to pull payment information from the databse
    /// </summary>
    /// <returns>
    /// 1 if successful, 0 if not
    /// </returns>
    public List<PaymentClass> getPaymentInfo(string Login_ID)
    {
        List<PaymentClass> paymentList = new List<PaymentClass>();
        string queryStr;

        if (Login_ID == "all")
        {
            queryStr = "SELECT * FROM UsersPayment Order by Login_ID";
        }
        else
        {
            queryStr = "SELECT * FROM UsersPayment WHERE Login_ID = @Login_ID";
        }

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID.ToLower());
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                        string Card_Num = dr["Card_Num"].ToString();
                        string Card_Num_Four = dr["Card_Num_Four"].ToString();
                        string Card_Name = dr["Card_Name"].ToString();
                        string Card_Exp_Date = dr["Exp_Date"].ToString();
                        string CCV = dr["CCV"].ToString();
                        string User = dr["Login_ID"].ToString();

                        PaymentClass eachPayment = new PaymentClass(Card_Num, Card_Num_Four, Card_Name, Card_Exp_Date, CCV, User);

                        paymentList.Add(eachPayment);
                    }
                }
            }
        }
        return paymentList;
    }



    /// <summary>
    /// Deletes payment information from the table
    /// Uses Login ID
    /// </summary>
    /// 
    /// Might use a logical delete if shopping cart gets integrated
    /// 
    /// <returns>
    /// 1 if successful, 0 if not
    /// </returns>
    public int Delete(string Login_ID)
    {
        int output = 0;
        string queryStr = "DELETE FROM UsersPayment WHERE Login_ID = @Login_ID";

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
}