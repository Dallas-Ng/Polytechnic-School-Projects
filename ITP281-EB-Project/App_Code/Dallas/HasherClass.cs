using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web;
using System.Linq;

/// <summary>
/// Hasher Class is to Hash STRINGS only
/// It is One way encryption, Use verify() to check
/// </summary>
public class HasherClass
{
    private const int SaltSize = 16;
    private const int HashSize = 20;



    public static string Hash(string password)
    {
        return Hashes(password, 10000);
    }



    public static string Hashes(string password, int iterations)
    {
        // Create salt
        byte[] salt;
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

        // Create hash
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
        var hash = pbkdf2.GetBytes(HashSize);

        // Combine salt and hash
        var hashBytes = new byte[SaltSize + HashSize];
        Array.Copy(salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

        // Convert to base64
        var base64Hash = Convert.ToBase64String(hashBytes);

        // Format hash with extra information
        return string.Format("$MYHASH$V1${0}${1}", iterations, base64Hash);
    }



    public static bool IsHashSupported(string hashString)
    {
        return hashString.Contains("$MYHASH$V1$");
    }



    public static bool Verify(string password, string hashedPassword)
    {
        // Check hash
        if (!IsHashSupported(hashedPassword))
        {
            throw new NotSupportedException("The hashtype is not supported");
        }

        // Extract iteration and Base64 string
        var splittedHashString = hashedPassword.Replace("$MYHASH$V1$", "").Split('$');
        var iterations = int.Parse(splittedHashString[0]);
        var base64Hash = splittedHashString[1];

        // Get hash bytes
        var hashBytes = Convert.FromBase64String(base64Hash);

        // Get salt
        var salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        // Create hash with given salt
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
        byte[] hash = pbkdf2.GetBytes(HashSize);

        // Get result
        for (var i = 0; i < HashSize; i++)
        {
            if (hashBytes[i + SaltSize] != hash[i])
            {
                return false;
            }
        }
        return true;
    }


    public static string GenerateToken()
    {
        int Length = 20;
        const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        System.Text.StringBuilder res = new System.Text.StringBuilder();
        Random rnd = new Random();

        while (0 < Length--)
        {
            res.Append(valid[rnd.Next(valid.Length)]);
        }

        return res.ToString();
    }


    public static string resetPassword(string nEmail)
    {
        string token = "none";
        string queryStr = "INSERT INTO Tokens(Token, Email) Values(@Token, @Email)";

        // Opening SQL connection
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                token = GenerateToken();
                cmd.Parameters.AddWithValue("@Token", token);
                cmd.Parameters.AddWithValue("@Email", nEmail.ToLower());
                cmd.ExecuteNonQuery();
            }
        }


        try
        {
            string companyEmail = "certcesseducation@gmail.com";
            string link = String.Format("https://Certcess.azurewebsites.net/Web/A/Change_Password.aspx?token={0}", token);

            string Body = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Static/_Account/Html/ForgotPassword.html"));

            AccountClass Acc = new AccountClass();
            Body = Body.Replace("#USERNAME#", Acc.checkEmail(nEmail));
            Body = Body.Replace("#LINK#", link);



            MailMessage message = new MailMessage();
            message.From = new MailAddress(companyEmail);
            message.To.Add(nEmail);
            message.Subject = "Reset Password Link";
            message.IsBodyHtml = true;
            message.Body = Body;

            SmtpClient cilent = new SmtpClient("smtp.gmail.com", 587);
            cilent.EnableSsl = true;
            cilent.Credentials = new System.Net.NetworkCredential(companyEmail, "Eb180522Y");
            cilent.Send(message);

        }
        catch (Exception ex)
        {
            string error = ex.StackTrace;
        }

        return token;
    }



    /// <summary>
    /// Gets Token Data
    /// </summary>
    /// <returns>
    /// Returns token data
    /// </returns>
    public static List<AccountClass> retrieveToken(string nToken)
    {
        string queryStr = "SELECT * FROM Tokens WHERE Token = @Token";
        List<AccountClass> output = new List<AccountClass>();

        // Opening SQL connection
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Token", nToken);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (!Convert.ToBoolean(reader["isUsed"]))
                        {
                            string nEmail = reader["Email"].ToString();
                            DateTime nCreation_Date = DateTime.Parse(reader["Creation_Date"].ToString());
                            AccountClass newObj = new AccountClass(nEmail, nCreation_Date);
                            output.Add(newObj);
                        }
                    }
                }
            }
        }
        return output;
    }


    public static int isTokenValid(string nToken)
    {
        int output = 0;

        List<AccountClass> Data = retrieveToken(nToken);

        if (!Data.Any())
        {
            return 1;
        }

        return output;
    }


    public static string InsertToken(string nEmail)
    {
        string token = "none";
        string queryStr = "INSERT INTO Tokens(Token, Email) Values(@Token, @Email)";


        // Opening SQL connection
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                token = GenerateToken();
                cmd.Parameters.AddWithValue("@Token", token);
                cmd.Parameters.AddWithValue("@Email", nEmail.ToLower());
                cmd.ExecuteNonQuery();
            }
        }
        return token;
    }
}


