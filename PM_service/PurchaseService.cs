using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_service
{
    public class PurchaseService : IPurchase
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PharmacyManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        public int AddPurchase(Purchase p)
        {
            int purchaseId = 0;
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO Purchase (CustomerName, Date, TotalPrice) " +
                                  "VALUES (@customerName, @date, @totalPrice)"+ "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("@customerName", p.CustomerName);
                cmd.Parameters.AddWithValue("@date", p.Date);
                cmd.Parameters.AddWithValue("@totalPrice", p.TotalPrice);

                cn.Open();
                purchaseId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return purchaseId;
        }

        public void DeletePurchase(int purchaseId)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "DELETE FROM Purchase WHERE PurchaseId = @purchaseId";
                cmd.Parameters.AddWithValue("@purchaseId", purchaseId);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Purchase GetPurchase(int purchaseId)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT PurchaseId, CustomerName, Date, TotalPrice FROM Purchase WHERE PurchaseId = @purchaseId";
                cmd.Parameters.AddWithValue("@purchaseId", purchaseId);

                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Purchase purchase = new Purchase();
                while (reader.Read())
                {
                    purchase.PurchaseId = reader.GetInt32(0);
                    purchase.CustomerName = reader.GetString(1);
                    purchase.Date = reader.GetDateTime(2);
                    purchase.TotalPrice = reader.GetDecimal(3);
                }
                return purchase;
            }
        }

        public DataSet GetPurchases()
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT PurchaseId, CustomerName, Date, TotalPrice FROM Purchase", cn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Purchase");
                return ds;
            }
        }

        public void UpdatePurchase(Purchase purchase)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE Purchase SET CustomerName = @customerName, Date = @date, " +
                                  "TotalPrice = @totalPrice WHERE PurchaseId = @purchaseId";
                cmd.Parameters.AddWithValue("@customerName", purchase.CustomerName);
                cmd.Parameters.AddWithValue("@date", purchase.Date);
                cmd.Parameters.AddWithValue("@totalPrice", purchase.TotalPrice);
                cmd.Parameters.AddWithValue("@purchaseId", purchase.PurchaseId);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
