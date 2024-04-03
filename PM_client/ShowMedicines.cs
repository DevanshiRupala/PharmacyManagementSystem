using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM_client
{
    public partial class ShowMedicines : Form
    {
        public ShowMedicines(int pid)
        {
            InitializeComponent();
            label1.Text = "Dashboard";
            label2.Text = "Home";
            label3.Text = "Add Medicine";
            label4.Text = "Purchases";
            label5.Text = "Log Out";
            MedicinePurchaseServiceRef.IMedicinePurchase ms = new MedicinePurchaseServiceRef.MedicinePurchaseClient();
            DataSet ds = ms.GetMedicinePurchasesByPurchaseId(pid);
            DataTable dataTable = ds.Tables["MedicinePurchase"];
            List<MedicineServiceRef.Medicine> medicines = new List<MedicineServiceRef.Medicine>();
            MedicineServiceRef.IMedicine m = new MedicineServiceRef.MedicineClient();
            foreach (DataRow row in dataTable.Rows)
            {
                int medicineId = Convert.ToInt32(row["MedicineId"]);
                MedicineServiceRef.Medicine medicine = m.GetMedicine(medicineId);
                
                if (medicine != null)
                {
                    medicines.Add(medicine);
                }
            }
            dataGridView1.DataSource = medicines;
            dataGridView1.Columns["MedicineId"].Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            AddMedicine addMedicine = new AddMedicine();
            addMedicine.Show();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ShowPurchase showPurchase = new ShowPurchase();
            showPurchase.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
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

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
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

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }
    }
}
