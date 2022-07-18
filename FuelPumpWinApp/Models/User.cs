using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Security.Cryptography;
using System.IO;

namespace FuelPumpWinApp.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

        public string Fullname { get; set; }

        public string Add()
        {
            try
            {
                using (var conn = new SqlConnection(Sales.conString))
                {
                    conn.Open();
                    string script = @"INSERT INTO [dbo].[Users]
                                    ([Username], [Firstname], [Lastname], [Position], [PhoneNumber], [Email], [Password], [Status])
                                    VALUES (@Username, @Firstname, @Lastname, @Position, @PhoneNumber, @Email, @Password, @Status)";

                    SqlCommand cmd = new SqlCommand(script, conn);

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("Username", Username);
                    cmd.Parameters.AddWithValue("Firstname", Firstname);
                    cmd.Parameters.AddWithValue("Lastname", Lastname);
                    cmd.Parameters.AddWithValue("Position", Position);
                    cmd.Parameters.AddWithValue("PhoneNumber", PhoneNumber);
                    cmd.Parameters.AddWithValue("Email", Email);
                    cmd.Parameters.AddWithValue("Password", Security.encrypt(Password));
                    cmd.Parameters.AddWithValue("Status", Status);

                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Successful";
        }

        public static User GetDetails(string username)
        {
            User user = new User();
            try
            {
                using (var conn = new SqlConnection(Sales.conString))
                {
                    conn.Open();
                    string script = @"SELECT * FROM [dbo].[Users]
                                    Where Username = @Username";

                    SqlCommand cmd = new SqlCommand(script, conn);

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("Username", username);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user.Username = reader["username"].ToString();
                        user.Firstname = reader["Firstname"].ToString();
                        user.Lastname = reader["Lastname"].ToString();
                        user.Position = reader["Position"].ToString();
                        user.Email = reader["Email"].ToString();
                        user.Password = Security.Decrypt(reader["Password"].ToString());
                        user.PhoneNumber = reader["PhoneNumber"].ToString();
                        user.Status = reader["Status"].ToString();
                    }
                }

            }
            catch (Exception)
            {
            }
            return user;
        }

        public static List<User> GetUsers()
        {
            List<User> userList = new List<User>();
            try
            {
                using (var conn = new SqlConnection(Sales.conString))
                {
                    conn.Open();
                    string script = @"SELECT *, Firstname + ' ' + Lastname As Fullname FROM Users";
                    SqlCommand cmd = new SqlCommand(script, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User();
                        user.Username = reader["Username"].ToString();
                        user.Firstname = reader["Firstname"].ToString();
                        user.Lastname = reader["Lastname"].ToString();
                        user.Position = reader["Position"].ToString();
                        user.Fullname = reader["Fullname"].ToString();
                        user.PhoneNumber = reader["PhoneNumber"].ToString();
                        user.Password = Security.Decrypt(reader["Password"].ToString());
                        user.Email = reader["Email"].ToString();
                        user.Status = reader["Status"].ToString();


                        userList.Add(user);
                    }
                }
            }

            catch(Exception)
            {
            }

            return userList;
        }

        public static string ValidateUser(string username, string password)
        {
            try
            {
                using (var conn = new SqlConnection(Sales.conString))
                {
                    conn.Open();
                    string script = @"SELECT * FROM [dbo].[Users]
                                    Where Username = @Username AND [Status] = 'ACTIVE'";

                    SqlCommand cmd = new SqlCommand(script, conn);

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("Username", username);
                    

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (Security.Decrypt(reader["Password"].ToString()) == password)
                        {
                            return "Successful";
                        }
                        return "Invalid Password!";
                    }
                }

            }
            catch (Exception)
            {

            }
            return "No User Found";
        }

        public static string BlockUser (string username)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(Sales.conString))
                {
                    string script = "Update Users Set [Status] = 'Blocked' Where Username = @Username";
                    DynamicParameters p = new DynamicParameters();
                    p.Add("Username", username);

                    conn.Execute(script, p);
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            return "Successful";
        }

        public string Update()
        {
            try
            {
                using (var conn = new SqlConnection(Sales.conString))
                {
                    conn.Open();
                    string script = @"UPDATE [dbo].[Users] SET [Firstname]=@Firstname, [Lastname]=@Lastname, [Status]=@Status,
                                    [PhoneNumber]=@PhoneNumber, [Email]=@Email, [Position]=@Position WHERE [Username]=@Username";

                    SqlCommand cmd = new SqlCommand(script, conn);

                    cmd.Parameters.AddWithValue("Username", Username);
                    cmd.Parameters.AddWithValue("Firstname", Firstname);
                    cmd.Parameters.AddWithValue("Lastname", Lastname);
                    cmd.Parameters.AddWithValue("Position", Position);
                    cmd.Parameters.AddWithValue("Status", Status);
                    cmd.Parameters.AddWithValue("PhoneNumber", PhoneNumber);
                    cmd.Parameters.AddWithValue("Email", Email);

                    cmd.ExecuteNonQuery();
                }

            }

            catch(Exception ex)
            {
                return ex.Message;
            }
            return "Successful";
        }

        public static List<User> List(string status = "")
        {
            List<User> list = new List<User>();
            try
            {
                using (IDbConnection conn = new SqlConnection(Sales.conString))
                {
                    string script = "Select * From Users Where [Status] like '%' + @status + '%'";
                    DynamicParameters p = new DynamicParameters();
                    p.Add("Status", status);

                    list = conn.Query<User>(script, p).ToList();
                }
            }

            catch(Exception)
            {
            }

            return list;
        }

        public static string UnblockUser(string username)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(Sales.conString))
                {
                    string script = "Update Users Set [Status] = 'Active' Where Username = @Username";
                    DynamicParameters p = new DynamicParameters();

                    p.Add("Username", username);
                    conn.Execute(script, p);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Successful";
        }


        public class Security
        {
            public static string encrypt(string encryptString)
            {
                string EncryptionKey = "strongWord";
                byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        encryptString = Convert.ToBase64String(ms.ToArray());
                    }
                }
                return encryptString;
            }

            public static string Decrypt(string cipherText)
            {
                string EncryptionKey = "strongWord";
                cipherText = cipherText.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return cipherText;
            }
        }
    }
}

