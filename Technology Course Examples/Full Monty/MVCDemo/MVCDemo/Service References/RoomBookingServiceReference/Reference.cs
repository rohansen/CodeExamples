﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCDemo.RoomBookingServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Booking", Namespace="http://schemas.datacontract.org/2004/07/RoomBooking.Models")]
    [System.SerializableAttribute()]
    public partial class Booking : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime EndTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MVCDemo.RoomBookingServiceReference.Room RoomField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RoomIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime StartTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MVCDemo.RoomBookingServiceReference.User UserField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
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
        public System.DateTime EndTime {
            get {
                return this.EndTimeField;
            }
            set {
                if ((this.EndTimeField.Equals(value) != true)) {
                    this.EndTimeField = value;
                    this.RaisePropertyChanged("EndTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public MVCDemo.RoomBookingServiceReference.Room Room {
            get {
                return this.RoomField;
            }
            set {
                if ((object.ReferenceEquals(this.RoomField, value) != true)) {
                    this.RoomField = value;
                    this.RaisePropertyChanged("Room");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RoomId {
            get {
                return this.RoomIdField;
            }
            set {
                if ((this.RoomIdField.Equals(value) != true)) {
                    this.RoomIdField = value;
                    this.RaisePropertyChanged("RoomId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime StartTime {
            get {
                return this.StartTimeField;
            }
            set {
                if ((this.StartTimeField.Equals(value) != true)) {
                    this.StartTimeField = value;
                    this.RaisePropertyChanged("StartTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public MVCDemo.RoomBookingServiceReference.User User {
            get {
                return this.UserField;
            }
            set {
                if ((object.ReferenceEquals(this.UserField, value) != true)) {
                    this.UserField = value;
                    this.RaisePropertyChanged("User");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Room", Namespace="http://schemas.datacontract.org/2004/07/RoomBooking.Models")]
    [System.SerializableAttribute()]
    public partial class Room : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MVCDemo.RoomBookingServiceReference.Booking[] BookingsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SizeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
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
        public MVCDemo.RoomBookingServiceReference.Booking[] Bookings {
            get {
                return this.BookingsField;
            }
            set {
                if ((object.ReferenceEquals(this.BookingsField, value) != true)) {
                    this.BookingsField = value;
                    this.RaisePropertyChanged("Bookings");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Size {
            get {
                return this.SizeField;
            }
            set {
                if ((this.SizeField.Equals(value) != true)) {
                    this.SizeField = value;
                    this.RaisePropertyChanged("Size");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/RoomBooking.Models")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MVCDemo.RoomBookingServiceReference.Booking[] BookingsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        public MVCDemo.RoomBookingServiceReference.Booking[] Bookings {
            get {
                return this.BookingsField;
            }
            set {
                if ((object.ReferenceEquals(this.BookingsField, value) != true)) {
                    this.BookingsField = value;
                    this.RaisePropertyChanged("Bookings");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RoomBookingServiceReference.IRoomBookingService")]
    public interface IRoomBookingService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomBookingService/Create", ReplyAction="http://tempuri.org/IRoomBookingService/CreateResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ArgumentException), Action="http://tempuri.org/IRoomBookingService/CreateArgumentExceptionFault", Name="ArgumentException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        void Create(MVCDemo.RoomBookingServiceReference.Booking booking);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomBookingService/Create", ReplyAction="http://tempuri.org/IRoomBookingService/CreateResponse")]
        System.Threading.Tasks.Task CreateAsync(MVCDemo.RoomBookingServiceReference.Booking booking);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomBookingService/Update", ReplyAction="http://tempuri.org/IRoomBookingService/UpdateResponse")]
        void Update(MVCDemo.RoomBookingServiceReference.Booking booking);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomBookingService/Update", ReplyAction="http://tempuri.org/IRoomBookingService/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(MVCDemo.RoomBookingServiceReference.Booking booking);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomBookingService/Delete", ReplyAction="http://tempuri.org/IRoomBookingService/DeleteResponse")]
        void Delete(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomBookingService/Delete", ReplyAction="http://tempuri.org/IRoomBookingService/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomBookingService/GetAll", ReplyAction="http://tempuri.org/IRoomBookingService/GetAllResponse")]
        MVCDemo.RoomBookingServiceReference.Booking[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomBookingService/GetAll", ReplyAction="http://tempuri.org/IRoomBookingService/GetAllResponse")]
        System.Threading.Tasks.Task<MVCDemo.RoomBookingServiceReference.Booking[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomBookingService/Get", ReplyAction="http://tempuri.org/IRoomBookingService/GetResponse")]
        MVCDemo.RoomBookingServiceReference.Booking Get(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomBookingService/Get", ReplyAction="http://tempuri.org/IRoomBookingService/GetResponse")]
        System.Threading.Tasks.Task<MVCDemo.RoomBookingServiceReference.Booking> GetAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRoomBookingServiceChannel : MVCDemo.RoomBookingServiceReference.IRoomBookingService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RoomBookingServiceClient : System.ServiceModel.ClientBase<MVCDemo.RoomBookingServiceReference.IRoomBookingService>, MVCDemo.RoomBookingServiceReference.IRoomBookingService {
        
        public RoomBookingServiceClient() {
        }
        
        public RoomBookingServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RoomBookingServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoomBookingServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoomBookingServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Create(MVCDemo.RoomBookingServiceReference.Booking booking) {
            base.Channel.Create(booking);
        }
        
        public System.Threading.Tasks.Task CreateAsync(MVCDemo.RoomBookingServiceReference.Booking booking) {
            return base.Channel.CreateAsync(booking);
        }
        
        public void Update(MVCDemo.RoomBookingServiceReference.Booking booking) {
            base.Channel.Update(booking);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(MVCDemo.RoomBookingServiceReference.Booking booking) {
            return base.Channel.UpdateAsync(booking);
        }
        
        public void Delete(int id) {
            base.Channel.Delete(id);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(int id) {
            return base.Channel.DeleteAsync(id);
        }
        
        public MVCDemo.RoomBookingServiceReference.Booking[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<MVCDemo.RoomBookingServiceReference.Booking[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public MVCDemo.RoomBookingServiceReference.Booking Get(int id) {
            return base.Channel.Get(id);
        }
        
        public System.Threading.Tasks.Task<MVCDemo.RoomBookingServiceReference.Booking> GetAsync(int id) {
            return base.Channel.GetAsync(id);
        }
    }
}