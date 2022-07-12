using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FuelPumpWinApp.Models
{
    public class Sales
    {
        public static readonly string conString = "Data Source=localhost;Initial Catalog=FuelPump;Persist Security Info=True;User ID=sa;Password=admin2019";
        public string SalesId { get; set; }
        public DateTime Date { get; set; }
        public string SalesPerson { get; set; }
        public decimal Litres { get; set; }
        public decimal Amount { get; set; }
        public string Pump { get; set; }
        public string Shift { get; set; }

        public string Add()
        {
            try
            {
                using (var conn = new SqlConnection(conString))
                {
                    conn.Open();
                    string script = @"INSERT INTO [dbo].[Sales]
                                    ([SalesId],[Date],[SalesPerson],[Litres],[Amount],[Shift],[Pump])
                                    VALUES(@SalesId, @Date, @SalesPerson, @Litres, @Amount, @Shift, @Pump)";
                    SqlCommand cmd = new SqlCommand(script, conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("SalesId", SalesId);
                    cmd.Parameters.AddWithValue("Date", Date);
                    cmd.Parameters.AddWithValue("SalesPerson", SalesPerson);
                    cmd.Parameters.AddWithValue("Litres", Litres);
                    cmd.Parameters.AddWithValue("Amount", Amount);
                    cmd.Parameters.AddWithValue("Shift", Shift);
                    cmd.Parameters.AddWithValue("Pump", Pump);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
            return "Successful";
        }

        public static List<Sales> GetSales()
        {
            List<Sales> list = new List<Sales>();
            try
            {
                using (var conn = new SqlConnection(conString))
                {
                    conn.Open();
                    string script = @"SELECT * FROM [dbo].[Sales]";

                    SqlCommand cmd = new SqlCommand(script, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Sales sale = new Sales();
                        sale.SalesId = reader["SalesId"].ToString();
                        sale.Date = Convert.ToDateTime(reader["Date"].ToString());
                        sale.SalesPerson = reader["SalesPerson"].ToString();
                        sale.Amount = Convert.ToDecimal(reader["Amount"].ToString());
                        sale.Litres = Convert.ToDecimal(reader["Litres"].ToString());
                        sale.Pump = reader["Pump"].ToString();
                        sale.Shift = reader["Shift"].ToString();
                        list.Add(sale);
                    }
                }
            }
            catch (Exception)
            {

            }
            return  list;
        }
    }
}
 