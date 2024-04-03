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
    public partial class UpdateMedicineForm : Form
    {
        private readonly int mid;
        private readonly string mn;
        private readonly string m_d;
        private readonly int q;
        private readonly int u;
        private readonly DateTime date;
        public UpdateMedicineForm(int medicineId, string medicineName, int quantity, string md, int up, DateTime d )
        {
            InitializeComponent();
            mid = medicineId;
            mn = medicineName;
            q = quantity;
            u = up;
            m_d = md;
            date = d;
        }

        private void UpdateMedicineForm_Load(object sender, EventArgs e)
        {
            label1.Text = "Medicine Name";
            label2.Text = "Medicine Description";
            label3.Text = "Quantity";
            label4.Text = "Unit Price";
            label5.Text = "Expiry Date";
            textBox1.Text = mn;
            textBox2.Text = m_d;
            textBox3.Text = q.ToString();
            textBox4.Text = u.ToString();
            dateTimePicker1.Value = date;
            label6.Text = "Dashboard";
            label7.Text = "Home";
            label8.Text = "Add Medicine";
            label9.Text = "Purchases";
            label10.Text = "Log Out";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MedicineServiceRef.Medicine medicine = new MedicineServiceRef.Medicine
            {
                MedicineId = mid,
                MedicineName = textBox1.Text,
                Quantity = int.Parse(textBox3.Text),
                MedicineDescription = textBox2.Text,
                UnitPrice = int.Parse(textBox4.Text),
                ExpiryDate = dateTimePicker1.Value
            };
            MedicineServiceRef.IMedicine proxy = new PM_client.MedicineServiceRef.MedicineClient();
            proxy.UpdateMedicine(medicine);

            MessageBox.Show("Medicine updated successfully.");
            Home h = new Home();
            h.Show();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            AddMedicine am = new AddMedicine();
            am.Show();
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            ShowPurchase showPurchase = new ShowPurchase();
            showPurchase.Show();
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            label7.ForeColor = Color.White;
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.ForeColor = Color.White;
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            label9.ForeColor = Color.White;
        }

        private void label10_MouseEnter(object sender, EventArgs e)
        {
            label10.ForeColor = Color.White;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Black;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Black;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.ForeColor = Color.Black;
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            label10.ForeColor = Color.Black;
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.ForeColor = Color.White;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }
    }
}
