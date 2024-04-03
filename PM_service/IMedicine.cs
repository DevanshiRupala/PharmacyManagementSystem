using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PM_service
{
    [ServiceContract]
    public interface IMedicine
    {
        [OperationContract]
        DataSet GetMedicines();

        [OperationContract]
        void AddMedicines(Medicine m);

        [OperationContract]
        void DeleteMedicine(int medicineId);
        [OperationContract]
        void UpdateMedicine(Medicine m);

        [OperationContract]
        Medicine GetMedicine(int medicineId);

        [OperationContract]
        DataSet GetMedicineByName(string name);
    }

    [DataContract]
    public class Medicine
    {

        [DataMember]
        public int MedicineId
        {
            get;
            set;
        }
        [DataMember]
        public string MedicineName
        {
            get;
            set;
        }
        [DataMember]
        public String MedicineDescription
        {
            get;
            set;
        }
        [DataMember]
        public int UnitPrice
        {
            get;
            set;
        }
        [DataMember]
        public int Quantity
        {
            get;
            set;
        }
        [DataMember]
        public DateTime ExpiryDate 
        { get; set; }
    }
}

