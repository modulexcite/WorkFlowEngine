﻿/********************************************************************************
** Class Name:   WorkFlowService 
** Author：      spring yang
** Create date： 2012-9-1
** Modify：      spring yang
** Modify Date： 2012-9-25
** Summary：     WorkFlowService class
*********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CommonLibrary.Help;
using CommonLibrary.Model;
using WorkFlowService.BLL;
using WorkFlowService.IDAL;
using WorkFlowService.Help;

namespace WorkFlowWCFService
{

    [ServiceContract]
    public class WorkFlowService : IWorkFlowActivity
    {
        private IWorkFlowActivity WorkFlowEngineInstance
        {
            get { return new WorkFlowManage(); }
        }

        [OperationContract]
        public WorkFlowState Execute(AppInfoModelstring    {
            return WorkFlowEngineInstance.Execute(entity);
        }

        [OperationContract]
        public WorkFlowState NewWorkFlow(AppInfoModel estring NewWorkFlow          return WorkFlowEngineInstance.Execute(entity);
        }

        perationContract]
        public List<WorkFlowActivityModel> QueryInProgressActivityListByOperatorUserId(string operatorUserId)
        {
            return WorkFlowEngineInstance.QueryInProgressActivityListByOperatorUserId(operatorUserId);
        }

        [OperationContract]
        public ActivityState GetCurrentActivityStateByAppIdAndUserID(string appId, string userId)
        {
            return WorkFlowEngineInstance.GetCurrentActivityStateByAppIdAndUserID(appId, userId);
        }
    }
}
