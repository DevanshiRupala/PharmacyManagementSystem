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
    public partial class PurchasePage : Form
    {
        private readonly List<MedicineServiceRef.Medicine> _medicines;
        public PurchasePage(List<MedicineServiceRef.Medicine> selectedmedicines)
        {
            InitializeComponent();
            _medicines = selectedmedicines;
            dataGridView1.DataSource = selectedmedicines;
            dataGridView1.Columns["MedicineId"].Visible = false;
            dataGridView1.Columns["Quantity"].Visible = false;
            label1.Text = "Enter Customer Name:";
            label2.Text = "Home";
            label3.Text = "Add Medicine";
            label4.Text = "Purchases";
            label5.Text = "Log Out";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Enter Customer Name.");
            }
            else
            {
                int totalPrice = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int unitPrice = Convert.ToInt32(row.Cells["UnitPrice"].Value);
                    int quantity = Convert.ToInt32(row.Cells["Column1"].Value);

                    int totalMedicinePrice = unitPrice * quantity;

                    totalPrice += totalMedicinePrice;
                }

                PurchaseServiceRef.Purchase p = new PurchaseServiceRef.Purchase
                {
                    CustomerName = textBox1.Text,
                    Date = DateTime.Now,
                    TotalPrice = totalPrice,
                };

                PurchaseServiceRef.IPurchase proxy = new PM_client.PurchaseServiceRef.PurchaseClient();
                int id = proxy.AddPurchase(p);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    MedicinePurchaseServiceRef.MedicinePurchase mp = new PM_client.MedicinePurchaseServiceRef.MedicinePurchase
                    {
                        MedicineId = Convert.ToInt32(row.Cells["MedicineId"].Value),
                        PurchaseId = id,
                        Quantity = Convert.ToInt32(row.Cells["Column1"].Value)
                    };
                    MedicineServiceRef.IMedicine pro = new MedicineServiceRef.MedicineClient();
                    MedicineServiceRef.Medicine med = pro.GetMedicine(Convert.ToInt32(row.Cells["MedicineId"].Value));
                    int q = med.Quantity;
                    med.Quantity = Convert.ToInt32((q- Convert.ToInt32(row.Cells["Column1"].Value)));
                    pro.UpdateMedicine(med);
                    MedicinePurchaseServiceRef.IMedicinePurchase pr = new PM_client.MedicinePurchaseServiceRef.MedicinePurchaseClient();
                    pr.AddMedicinePurchase(mp);
                }

                ShowPurchase s = new ShowPurchase();
                s.Show();
                this.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AddMedicine addMedicine = new AddMedicine();
            addMedicine.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ShowPurchase s = new ShowPurchase();
            s.Show();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
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

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            ds.Show();
            this.Close();
        }
    }
}
