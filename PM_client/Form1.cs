using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PM_client.MedicineServiceRef;

namespace PM_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "Username";
            maskedTextBox1.Text = "Password";
            textBox1.ForeColor = SystemColors.GrayText;
            maskedTextBox1.ForeColor = SystemColors.GrayText;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MedicineServiceRef.IMedicine proxy = new PM_client.MedicineServiceRef.MedicineClient();
            DataSet ds = proxy.GetMedicines();
            Console.WriteLine(ds);
            label3.Text = "Pharmacy Management System";
            label1.Text = "Username";
            label2.Text = "Password";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "Admin" && maskedTextBox1.Text == "admin@123")
            {
                this.Hide();
                Home newForm = new Home();
                newForm.Show();
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = SystemColors.WindowText;
            textBox1.SelectAll();
        }

        private void maskedTextBox1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = "";
            maskedTextBox1.ForeColor = SystemColors.WindowText;
            maskedTextBox1.SelectAll();
        }

        private void maskedTextBox1_textChanged(object sender, EventArgs e)
        {
            maskedTextBox1.UseSystemPasswordChar = true;
        }
    }
}
