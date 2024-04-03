using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PM_service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MedicineService : IMedicine
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PharmacyManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public DataSet GetMedicines()
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MedicineId, MedicineName, MedicineDescription, UnitPrice, Quantity, ExpiryDate FROM Medicine", cn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Medicine");
                return ds;
            }
        }

        public void AddMedicines(Medicine m)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO Medicine (MedicineName, MedicineDescription, UnitPrice, Quantity, ExpiryDate) " +
                                  "VALUES (@medicineName, @medicineDescription, @unitPrice, @quantity, @expiryDate)";
                cmd.Parameters.AddWithValue("@medicineName", m.MedicineName);
                cmd.Parameters.AddWithValue("@medicineDescription", m.MedicineDescription);
                cmd.Parameters.AddWithValue("@unitPrice", m.UnitPrice);
                cmd.Parameters.AddWithValue("@quantity", m.Quantity);
                cmd.Parameters.AddWithValue("@expiryDate", m.ExpiryDate);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet GetMedicineByName(string name)
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM Medicine WHERE MedicineName = @name";
                cmd.Parameters.AddWithValue("@name", name);

                cn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet, "Medicine");
            }
            return dataSet;
        }

        public void DeleteMedicine(int medicineId)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "DELETE FROM Medicine WHERE MedicineId = @medicineId";
                cmd.Parameters.AddWithValue("@medicineId", medicineId);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateMedicine(Medicine m)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE Medicine SET MedicineName = @medicineName, MedicineDescription = @medicineDescription, " +
                                  "UnitPrice = @unitPrice, Quantity = @quantity, ExpiryDate = @expiryDate WHERE MedicineId = @medicineId";
                cmd.Parameters.AddWithValue("@medicineName", m.MedicineName);
                cmd.Parameters.AddWithValue("@medicineDescription", m.MedicineDescription);
                cmd.Parameters.AddWithValue("@unitPrice", m.UnitPrice);
                cmd.Parameters.AddWithValue("@quantity", m.Quantity);
                cmd.Parameters.AddWithValue("@expiryDate", m.ExpiryDate);
                cmd.Parameters.AddWithValue("@medicineId", m.MedicineId);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Medicine GetMedicine(int medicineId)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT MedicineId,MedicineName, MedicineDescription, UnitPrice, Quantity, ExpiryDate FROM Medicine WHERE MedicineId = @medicineId";
                cmd.Parameters.AddWithValue("@medicineId", medicineId);

                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Medicine medicine = new Medicine();
                while (reader.Read())
                {
                    medicine.MedicineId = reader.GetInt32(0);
                    medicine.MedicineName = reader.GetString(1);
                    medicine.MedicineDescription = reader.GetString(2);
                    medicine.UnitPrice = reader.GetInt32(3);
                    medicine.Quantity = reader.GetInt32(4);
                    medicine.ExpiryDate = reader.GetDateTime(5);
                }
                return medicine;
            }
        }
    }
}
