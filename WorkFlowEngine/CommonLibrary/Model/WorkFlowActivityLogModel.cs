﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CommonLibrary.Model
{
    public class WorkFlowActivityLogModel
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string OldID { get; set; }
        [DataMember]
        public string AppId { get; set; }
        [DataMember]
        public string WorkFlowState { get; set; }
        [DataMember]
        public string OperatorActivity { get; set; }
        [DataMember]
        public string CurrentWorkFlowState { get; set; }
        [DataMember]
        public string OperatorUserId { get; set; }
        [DataMember]
        public DateTime? CreateDateTime { get; set; }
        [DataMember]
        public DateTime? LastUpdateDateTime { get; set; }
        [DataMember]
        public string CreateUserId { get; set; }
        [DataMember]
        public string OperatorUserList { get; set; }
        [DataMember]
        public string ApplicationState { get; set; }
        [DataMember]
        public string AppName { get; set; }
        [DataMember]
        public bool IsDelete { get; set; }
    }
}
