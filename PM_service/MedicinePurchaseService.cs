using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_service
{
    public class MedicinePurchaseService : IMedicinePurchase
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PharmacyManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public void AddMedicinePurchase(MedicinePurchase m)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO MedicinePurchase (MedicineId, PurchaseId, Quantity) " +
                                  "VALUES (@medicineId, @purchaseId, @quantity)";
                cmd.Parameters.AddWithValue("@medicineId", m.MedicineId);
                cmd.Parameters.AddWithValue("@purchaseId", m.PurchaseId);
                cmd.Parameters.AddWithValue("@quantity", m.Quantity);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveMedicinePurchase(int id)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "DELETE FROM MedicinePurchase WHERE MedicinePurchaseId = @medicinePurchaseId";
                cmd.Parameters.AddWithValue("@medicinePurchaseId", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public bool UpdateMedicinePurchase(int id)
        {
            return false;
        }

        public MedicinePurchase GetMedicinePurchase(int id)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT MedicinePurchaseId, MedicineId, PurchaseId, Quantity FROM MedicinePurchase WHERE MedicinePurchaseId = @medicinePurchaseId";
                cmd.Parameters.AddWithValue("@medicinePurchaseId", id);

                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                MedicinePurchase medicinePurchase = new MedicinePurchase();
                while (reader.Read())
                {
                    medicinePurchase.MedicinePurchaseId = reader.GetInt32(0);
                    medicinePurchase.MedicineId = reader.GetInt32(1);
                    medicinePurchase.PurchaseId = reader.GetInt32(2);
                    medicinePurchase.Quantity = reader.GetInt32(3);
                }
                return medicinePurchase;
            }
        }

        public DataSet GetMedicinePurchasesByPurchaseId(int purchaseId)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT MedicinePurchaseId, PurchaseId, MedicineId, Quantity FROM MedicinePurchase WHERE PurchaseId = @purchaseId";
                cmd.Parameters.AddWithValue("@purchaseId", purchaseId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "MedicinePurchase");

                return ds;
            }
        }

        public void RemoveMedicinePurchasesByPurchaseId(int purchaseId)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "DELETE FROM MedicinePurchase WHERE PurchaseId = @purchaseId";
                cmd.Parameters.AddWithValue("@purchaseId", purchaseId);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet GetAllMedicinePurchases()
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MedicinePurchaseId, PurchaseId, MedicineId, Quantity FROM MedicinePurchase", cn);
                DataSet ds = new DataSet();
                da.Fill(ds, "MedicinePurchase");
                return ds;
            }
        }
    }
}

