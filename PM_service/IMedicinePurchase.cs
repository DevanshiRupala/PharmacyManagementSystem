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
    public interface IMedicinePurchase
    {
        [OperationContract]
        void AddMedicinePurchase(MedicinePurchase m);

        [OperationContract]
        void RemoveMedicinePurchase(int id);

        [OperationContract]
        bool UpdateMedicinePurchase(int id);

        [OperationContract]
        MedicinePurchase GetMedicinePurchase(int id);

        [OperationContract]
        DataSet GetAllMedicinePurchases();

        [OperationContract]
        DataSet GetMedicinePurchasesByPurchaseId(int purchaseId);

        [OperationContract]
        void RemoveMedicinePurchasesByPurchaseId(int purchaseId);
    }

    [DataContract]
    public class MedicinePurchase
    {
        [DataMember]
        public int MedicinePurchaseId { get; set; }

        [DataMember]
        public int MedicineId { get; set; }

        [DataMember]
        public int PurchaseId { get; set; }

        [DataMember]
        public int Quantity { get; set; }
    }
}
