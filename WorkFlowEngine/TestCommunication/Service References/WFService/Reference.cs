﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.17929
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestCommunication.WFService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AppInfoModel", Namespace="http://schemas.datacontract.org/2004/07/CommonLibrary.Model")]
    [System.SerializableAttribute()]
    public partial class AppInfoModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ActivityStateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AppIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CurrentStateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WorkflowNameField;
        
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
        public string ActivityState {
            get {
                return this.ActivityStateField;
            }
            set {
                if ((object.ReferenceEquals(this.ActivityStateField, value) != true)) {
                    this.ActivityStateField = value;
                    this.RaisePropertyChanged("ActivityState");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AppId {
            get {
                return this.AppIdField;
            }
            set {
                if ((object.ReferenceEquals(this.AppIdField, value) != true)) {
                    this.AppIdField = value;
                    this.RaisePropertyChanged("AppId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CurrentState {
            get {
                return this.CurrentStateField;
            }
            set {
                if ((object.ReferenceEquals(this.CurrentStateField, value) != true)) {
                    this.CurrentStateField = value;
                    this.RaisePropertyChanged("CurrentState");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((object.ReferenceEquals(this.UserIdField, value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WorkflowName {
            get {
                return this.WorkflowNameField;
            }
            set {
                if ((object.ReferenceEquals(this.WorkflowNameField, value) != true)) {
                    this.WorkflowNameField = value;
                    this.RaisePropertyChanged("WorkflowName");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="WorkFlowActivityModel", Namespace="http://schemas.datacontract.org/2004/07/CommonLibrary.Model")]
    [System.SerializableAttribute()]
    public partial class WorkFlowActivityModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AppIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AppNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApplicationStateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> CreateDateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CreateUserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CurrentWorkflowStateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ForeWorkflowStateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsDeleteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> LastUpdateDateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OperatorActivityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OperatorUserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OperatorUserListField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WorkflowNameField;
        
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
        public string AppId {
            get {
                return this.AppIdField;
            }
            set {
                if ((object.ReferenceEquals(this.AppIdField, value) != true)) {
                    this.AppIdField = value;
                    this.RaisePropertyChanged("AppId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AppName {
            get {
                return this.AppNameField;
            }
            set {
                if ((object.ReferenceEquals(this.AppNameField, value) != true)) {
                    this.AppNameField = value;
                    this.RaisePropertyChanged("AppName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ApplicationState {
            get {
                return this.ApplicationStateField;
            }
            set {
                if ((object.ReferenceEquals(this.ApplicationStateField, value) != true)) {
                    this.ApplicationStateField = value;
                    this.RaisePropertyChanged("ApplicationState");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> CreateDateTime {
            get {
                return this.CreateDateTimeField;
            }
            set {
                if ((this.CreateDateTimeField.Equals(value) != true)) {
                    this.CreateDateTimeField = value;
                    this.RaisePropertyChanged("CreateDateTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CreateUserId {
            get {
                return this.CreateUserIdField;
            }
            set {
                if ((object.ReferenceEquals(this.CreateUserIdField, value) != true)) {
                    this.CreateUserIdField = value;
                    this.RaisePropertyChanged("CreateUserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CurrentWorkflowState {
            get {
                return this.CurrentWorkflowStateField;
            }
            set {
                if ((object.ReferenceEquals(this.CurrentWorkflowStateField, value) != true)) {
                    this.CurrentWorkflowStateField = value;
                    this.RaisePropertyChanged("CurrentWorkflowState");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ForeWorkflowState {
            get {
                return this.ForeWorkflowStateField;
            }
            set {
                if ((object.ReferenceEquals(this.ForeWorkflowStateField, value) != true)) {
                    this.ForeWorkflowStateField = value;
                    this.RaisePropertyChanged("ForeWorkflowState");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ID {
            get {
                return this.IDField;
            }
            set {
                if ((object.ReferenceEquals(this.IDField, value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsDelete {
            get {
                return this.IsDeleteField;
            }
            set {
                if ((this.IsDeleteField.Equals(value) != true)) {
                    this.IsDeleteField = value;
                    this.RaisePropertyChanged("IsDelete");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> LastUpdateDateTime {
            get {
                return this.LastUpdateDateTimeField;
            }
            set {
                if ((this.LastUpdateDateTimeField.Equals(value) != true)) {
                    this.LastUpdateDateTimeField = value;
                    this.RaisePropertyChanged("LastUpdateDateTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OperatorActivity {
            get {
                return this.OperatorActivityField;
            }
            set {
                if ((object.ReferenceEquals(this.OperatorActivityField, value) != true)) {
                    this.OperatorActivityField = value;
                    this.RaisePropertyChanged("OperatorActivity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OperatorUserId {
            get {
                return this.OperatorUserIdField;
            }
            set {
                if ((object.ReferenceEquals(this.OperatorUserIdField, value) != true)) {
                    this.OperatorUserIdField = value;
                    this.RaisePropertyChanged("OperatorUserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OperatorUserList {
            get {
                return this.OperatorUserListField;
            }
            set {
                if ((object.ReferenceEquals(this.OperatorUserListField, value) != true)) {
                    this.OperatorUserListField = value;
                    this.RaisePropertyChanged("OperatorUserList");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WorkflowName {
            get {
                return this.WorkflowNameField;
            }
            set {
                if ((object.ReferenceEquals(this.WorkflowNameField, value) != true)) {
                    this.WorkflowNameField = value;
                    this.RaisePropertyChanged("WorkflowName");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WFService.WorkFlowService")]
    public interface WorkFlowService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/WorkFlowService/Execute", ReplyAction="http://tempuri.org/WorkFlowService/ExecuteResponse")]
        string Execute(TestCommunication.WFService.AppInfoModel entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/WorkFlowService/NewWorkFlow", ReplyAction="http://tempuri.org/WorkFlowService/NewWorkFlowResponse")]
        string NewWorkFlow(TestCommunication.WFService.AppInfoModel entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/WorkFlowService/QueryInProgressActivityListByOperatorUserId", ReplyAction="http://tempuri.org/WorkFlowService/QueryInProgressActivityListByOperatorUserIdRes" +
            "ponse")]
        TestCommunication.WFService.WorkFlowActivityModel[] QueryInProgressActivityListByOperatorUserId(string operatorUserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/WorkFlowService/GetCurrentActivityStateByAppIdAndUserID", ReplyAction="http://tempuri.org/WorkFlowService/GetCurrentActivityStateByAppIdAndUserIDRespons" +
            "e")]
        string[] GetCurrentActivityStateByAppIdAndUserID(string appId, string userId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WorkFlowServiceChannel : TestCommunication.WFService.WorkFlowService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WorkFlowServiceClient : System.ServiceModel.ClientBase<TestCommunication.WFService.WorkFlowService>, TestCommunication.WFService.WorkFlowService {
        
        public WorkFlowServiceClient() {
        }
        
        public WorkFlowServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WorkFlowServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WorkFlowServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WorkFlowServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Execute(TestCommunication.WFService.AppInfoModel entity) {
            return base.Channel.Execute(entity);
        }
        
        public string NewWorkFlow(TestCommunication.WFService.AppInfoModel entity) {
            return base.Channel.NewWorkFlow(entity);
        }
        
        public TestCommunication.WFService.WorkFlowActivityModel[] QueryInProgressActivityListByOperatorUserId(string operatorUserId) {
            return base.Channel.QueryInProgressActivityListByOperatorUserId(operatorUserId);
        }
        
        public string[] GetCurrentActivityStateByAppIdAndUserID(string appId, string userId) {
            return base.Channel.GetCurrentActivityStateByAppIdAndUserID(appId, userId);
        }
    }
}
