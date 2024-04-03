using PM_service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM_host
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ServiceHost sh = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            Uri httpUri = new Uri("http://localhost:8733/MedicineService");
            sh = new ServiceHost(typeof(MedicineService), httpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            ServiceMetadataBehavior mBehave = new ServiceMetadataBehavior();
            sh.Description.Behaviors.Add(mBehave);
            sh.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
            sh.AddServiceEndpoint(typeof(IMedicine), binding, httpUri);
            sh.Open();

            Uri tcpuri = new Uri("net.tcp://localhost:8734/MedicinePurchaseService");
            ServiceHost sh1 = new ServiceHost(typeof(MedicinePurchaseService), tcpuri);
            NetTcpBinding binding2 = new NetTcpBinding();
            ServiceMetadataBehavior mBehave1 = new ServiceMetadataBehavior();
            sh1.Description.Behaviors.Add(mBehave1);
            sh1.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
            sh1.AddServiceEndpoint(typeof(IMedicinePurchase), binding2,tcpuri);
            sh1.Open();

            Uri tcpuri1 = new Uri("net.tcp://localhost:8735/PurchaseService");
            ServiceHost sh2 = new ServiceHost(typeof(PurchaseService), tcpuri1);
            NetTcpBinding binding3 = new NetTcpBinding();
            ServiceMetadataBehavior mBehave2 = new ServiceMetadataBehavior();
            sh2.Description.Behaviors.Add(mBehave2);
            sh2.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
            sh2.AddServiceEndpoint(typeof(IPurchase), binding3, tcpuri1);
            sh2.Open();

            label1.Text = "Service running";
        }
    }
}
