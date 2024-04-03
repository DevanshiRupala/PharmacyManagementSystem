using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PM_service
{
        [ServiceContract]
        public interface IPurchase
        {
            [OperationContract]
             int AddPurchase(Purchase purchase);
            [OperationContract]
            void DeletePurchase(int purchaseId);

            [OperationContract]
            void UpdatePurchase(Purchase purchase);

            [OperationContract]
            Purchase GetPurchase(int purchaseId);

            [OperationContract]
            DataSet GetPurchases();

        }

        [DataContract]
        public class Purchase
        {
            [DataMember]
            public int PurchaseId { get; set; }

            [DataMember]
            public String CustomerName { get; set; } 

            [DataMember]
            public DateTime Date { get; set; }

            [DataMember]
            public decimal TotalPrice { get; set; }
        }
}
