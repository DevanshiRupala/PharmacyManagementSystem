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
    public partial class AddMedicine : Form
    {
        public AddMedicine()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) ||
            String.IsNullOrEmpty(textBox2.Text) ||
            String.IsNullOrEmpty(textBox3.Text) ||
            String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            string medicineName = textBox1.Text;
            int quantity = int.Parse(textBox2.Text); 
            string medicineDescription = textBox3.Text;
            decimal unitPrice = decimal.Parse(textBox4.Text);
            DateTime expiryDate = dateTimePicker1.Value;

            MedicineServiceRef.Medicine medicine = new MedicineServiceRef.Medicine
            {
                MedicineName = medicineName,
                Quantity = quantity,
                MedicineDescription = medicineDescription,
                UnitPrice = (int)unitPrice,
                ExpiryDate = expiryDate
            };
            MedicineServiceRef.IMedicine proxy = new PM_client.MedicineServiceRef.MedicineClient();
            proxy.AddMedicines(medicine);

            MessageBox.Show("Medicine added successfully.");
            Home h = new Home();
            h.Show();
            this.Close();
        }

        private void AddMedicine_Load(object sender, EventArgs e)
        {
            label1.Text = "Medicine Name";
            label2.Text = "Quantity";
            label3.Text = "Medicine Description";
            label4.Text = "Unit Price";
            label5.Text = "Expiry Date";
            label6.Text = "Dashboard";
            label7.Text = "Add Medicine";
            label8.Text = "Purchases";
            label9.Text = "Home";
            label10.Text = "Log Out";
        }

        private void label7_Click(object sender, EventArgs e)
        {
            AddMedicine am = new AddMedicine();
            am.Show();
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ShowPurchase sp = new ShowPurchase();
            sp.Show();
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
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

        private void label6_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.ForeColor = Color.White;
        }
    }
}
