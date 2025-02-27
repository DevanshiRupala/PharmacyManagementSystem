﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PM_client.PurchaseServiceRef {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Purchase", Namespace="http://schemas.datacontract.org/2004/07/PM_service")]
    [System.SerializableAttribute()]
    public partial class Purchase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CustomerNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PurchaseIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal TotalPriceField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerName {
            get {
                return this.CustomerNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CustomerNameField, value) != true)) {
                    this.CustomerNameField = value;
                    this.RaisePropertyChanged("CustomerName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PurchaseId {
            get {
                return this.PurchaseIdField;
            }
            set {
                if ((this.PurchaseIdField.Equals(value) != true)) {
                    this.PurchaseIdField = value;
                    this.RaisePropertyChanged("PurchaseId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal TotalPrice {
            get {
                return this.TotalPriceField;
            }
            set {
                if ((this.TotalPriceField.Equals(value) != true)) {
                    this.TotalPriceField = value;
                    this.RaisePropertyChanged("TotalPrice");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PurchaseServiceRef.IPurchase")]
    public interface IPurchase {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPurchase/AddPurchase", ReplyAction="http://tempuri.org/IPurchase/AddPurchaseResponse")]
        int AddPurchase(PM_client.PurchaseServiceRef.Purchase purchase);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPurchase/AddPurchase", ReplyAction="http://tempuri.org/IPurchase/AddPurchaseResponse")]
        System.Threading.Tasks.Task<int> AddPurchaseAsync(PM_client.PurchaseServiceRef.Purchase purchase);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPurchase/DeletePurchase", ReplyAction="http://tempuri.org/IPurchase/DeletePurchaseResponse")]
        void DeletePurchase(int purchaseId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPurchase/DeletePurchase", ReplyAction="http://tempuri.org/IPurchase/DeletePurchaseResponse")]
        System.Threading.Tasks.Task DeletePurchaseAsync(int purchaseId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPurchase/UpdatePurchase", ReplyAction="http://tempuri.org/IPurchase/UpdatePurchaseResponse")]
        void UpdatePurchase(PM_client.PurchaseServiceRef.Purchase purchase);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPurchase/UpdatePurchase", ReplyAction="http://tempuri.org/IPurchase/UpdatePurchaseResponse")]
        System.Threading.Tasks.Task UpdatePurchaseAsync(PM_client.PurchaseServiceRef.Purchase purchase);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPurchase/GetPurchase", ReplyAction="http://tempuri.org/IPurchase/GetPurchaseResponse")]
        PM_client.PurchaseServiceRef.Purchase GetPurchase(int purchaseId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPurchase/GetPurchase", ReplyAction="http://tempuri.org/IPurchase/GetPurchaseResponse")]
        System.Threading.Tasks.Task<PM_client.PurchaseServiceRef.Purchase> GetPurchaseAsync(int purchaseId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPurchase/GetPurchases", ReplyAction="http://tempuri.org/IPurchase/GetPurchasesResponse")]
        System.Data.DataSet GetPurchases();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPurchase/GetPurchases", ReplyAction="http://tempuri.org/IPurchase/GetPurchasesResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetPurchasesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPurchaseChannel : PM_client.PurchaseServiceRef.IPurchase, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PurchaseClient : System.ServiceModel.ClientBase<PM_client.PurchaseServiceRef.IPurchase>, PM_client.PurchaseServiceRef.IPurchase {
        
        public PurchaseClient() {
        }
        
        public PurchaseClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PurchaseClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PurchaseClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PurchaseClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int AddPurchase(PM_client.PurchaseServiceRef.Purchase purchase) {
            return base.Channel.AddPurchase(purchase);
        }
        
        public System.Threading.Tasks.Task<int> AddPurchaseAsync(PM_client.PurchaseServiceRef.Purchase purchase) {
            return base.Channel.AddPurchaseAsync(purchase);
        }
        
        public void DeletePurchase(int purchaseId) {
            base.Channel.DeletePurchase(purchaseId);
        }
        
        public System.Threading.Tasks.Task DeletePurchaseAsync(int purchaseId) {
            return base.Channel.DeletePurchaseAsync(purchaseId);
        }
        
        public void UpdatePurchase(PM_client.PurchaseServiceRef.Purchase purchase) {
            base.Channel.UpdatePurchase(purchase);
        }
        
        public System.Threading.Tasks.Task UpdatePurchaseAsync(PM_client.PurchaseServiceRef.Purchase purchase) {
            return base.Channel.UpdatePurchaseAsync(purchase);
        }
        
        public PM_client.PurchaseServiceRef.Purchase GetPurchase(int purchaseId) {
            return base.Channel.GetPurchase(purchaseId);
        }
        
        public System.Threading.Tasks.Task<PM_client.PurchaseServiceRef.Purchase> GetPurchaseAsync(int purchaseId) {
            return base.Channel.GetPurchaseAsync(purchaseId);
        }
        
        public System.Data.DataSet GetPurchases() {
            return base.Channel.GetPurchases();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetPurchasesAsync() {
            return base.Channel.GetPurchasesAsync();
        }
    }
}
