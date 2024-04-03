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
    public partial class ShowPurchase : Form
    {
        public ShowPurchase()
        {
            InitializeComponent();
        }

        private void ShowPurchase_Load(object sender, EventArgs e)
        {
            label1.Text = "Dashboard";
            PurchaseServiceRef.IPurchase p = new PurchaseServiceRef.PurchaseClient();
            DataSet ds = p.GetPurchases();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["PurchaseId"].Visible = false;
            label2.Text = "Home";
            label3.Text = "Add Medicine";
            label4.Text = "Purchases";
            label5.Text = "Log Out";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["ViewMore"].Index)
            {
                int purchaseId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["PurchaseId"].Value);
                ShowMedicines sm = new ShowMedicines(purchaseId);
                sm.Show();
                this.Close();
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                int purchaseId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["PurchaseId"].Value);
                MedicinePurchaseServiceRef.IMedicinePurchase mp = new MedicinePurchaseServiceRef.MedicinePurchaseClient();
                mp.RemoveMedicinePurchasesByPurchaseId(purchaseId);
                PurchaseServiceRef.IPurchase p = new PurchaseServiceRef.PurchaseClient();
                p.DeletePurchase(purchaseId);
                MessageBox.Show("Purchase Deleted");
                PurchaseServiceRef.IPurchase p1 = new PurchaseServiceRef.PurchaseClient();
                DataSet ds = p1.GetPurchases();
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["PurchaseId"].Visible = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            AddMedicine add = new AddMedicine();
            add.Show();
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
            Form1 form1 = new Form1();
            form1.Show();
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
