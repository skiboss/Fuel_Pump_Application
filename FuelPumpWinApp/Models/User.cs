using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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
                    cmd.Parameters.AddWithValue("Password", Password);
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
                        user.Password = reader["Password"].ToString();
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

        public static string ValidateUser(string username, string password)
        {
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
                        if (reader["Password"].ToString() == password)
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
    }
}
