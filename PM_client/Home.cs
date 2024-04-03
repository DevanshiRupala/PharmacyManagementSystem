using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PM_client
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            textBox1.Text = "Enter your text here...";
            textBox1.ForeColor = SystemColors.GrayText;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            MedicineServiceRef.IMedicine proxy = new PM_client.MedicineServiceRef.MedicineClient();
            DataSet ds = proxy.GetMedicines();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["MedicineId"].Visible = false;
            label1.Text = "Pharmacy Management System";
            label2.Text = "Dashboard";
            label3.Text = "Home";
            label4.Text = "Add Medicine";
            label5.Text = "Purchases";
            label6.Text = "Log Out";
            textBox1.Text = "Enter Medicine Name...";
        }

        public void LoadMedicineData()
        {
            MedicineServiceRef.IMedicine proxy = new PM_client.MedicineServiceRef.MedicineClient();
            DataSet ds = proxy.GetMedicines();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Column1"].Index)
            {
                int medicineId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MedicineId"].Value);
                MedicineServiceRef.IMedicine p = new PM_client.MedicineServiceRef.MedicineClient();
                p.DeleteMedicine(medicineId);
                MessageBox.Show($"Deleted Medicine : {medicineId} successfully");
                LoadMedicineData();
            }
            if(e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Column2"].Index)
            {
                int medicineId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MedicineId"].Value);
                string medicineName = dataGridView1.Rows[e.RowIndex].Cells["MedicineName"].Value.ToString();
                int quantity = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value);
                string md = dataGridView1.Rows[e.RowIndex].Cells["MedicineDescription"].Value.ToString();
                int up = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["UnitPrice"].Value);
                DateTime d = (DateTime)dataGridView1.Rows[e.RowIndex].Cells["ExpiryDate"].Value;
                UpdateMedicineForm u = new UpdateMedicineForm(medicineId,medicineName,quantity,md,up,d);
                u.Show();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<MedicineServiceRef.Medicine> selectedMedicines = new List<MedicineServiceRef.Medicine>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Column3"] is DataGridViewCheckBoxCell checkBoxCell)
                {
                    if (checkBoxCell.Value != null && (bool)checkBoxCell.Value){
                        int medicineId = Convert.ToInt32(row.Cells["MedicineId"].Value);
                        string medicineName = Convert.ToString(row.Cells["MedicineName"].Value);
                        int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                        string medicineDescription = Convert.ToString(row.Cells["MedicineDescription"].Value);
                        int unitPrice = Convert.ToInt32(row.Cells["UnitPrice"].Value);
                        DateTime expiryDate = Convert.ToDateTime(row.Cells["ExpiryDate"].Value);

                        MedicineServiceRef.Medicine medicine = new MedicineServiceRef.Medicine
                        {
                            MedicineId = medicineId,
                            MedicineName = medicineName,
                            Quantity = quantity,
                            MedicineDescription = medicineDescription,
                            UnitPrice = unitPrice,
                            ExpiryDate = expiryDate
                        };
                        selectedMedicines.Add(medicine);
                    }
                }
            }

            if(selectedMedicines.Count > 0)
            {
                PurchasePage p = new PurchasePage(selectedMedicines);
                p.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Select Medicines.");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AddMedicine am = new AddMedicine();
            am.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ShowPurchase sp = new ShowPurchase();
            sp.Show(); this.Close();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = SystemColors.WindowText;
            textBox1.SelectAll();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White; 
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.White; 
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.White; 
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.ForeColor = Color.White; 
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black; 
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black; 
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black; 
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black; 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(textBox1.Text == "Enter Medicine Name...")
            {
                MessageBox.Show("Enter Medicine in SearchBox");
            } 
            else
            {
                MedicineServiceRef.IMedicine p = new MedicineServiceRef.MedicineClient();
                DataSet ds = p.GetMedicineByName(textBox1.Text);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }
    }
}
