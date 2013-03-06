﻿/********************************************************************************
** Class Name:   WorkFlowEngine 
** Author：      spring yang
** Create date： 2012-9-1
** Modify：      spring yang
** Modify Date： 2012-9-25
** Summary：     WorkFlowEngine class
*********************************************************************************/

using System.Collections.Generic;

namespace WorkFlowService.BLL
{
    using WorkFlowHandle.Model;
    using System;
    using System.Linq;
    using CommonLibrary.Help;
    using WorkFlowHandle.Steps;
    using DAL;
    using Help;
    using WorkFlowHandle.BLL;
    using Model;

    public class WorkFlowEngine
    {

        public static WorkFlowEngine Current
        {
            get { return new WorkFlowEngine(); }
        }

        //private IStateBase GetCurrentWorkFlowStateByWorkFlowState(WorkFlowState workFlowState)
        //{
        //    foreach (var iStateBase in StateMapping.Instance.StateBasesList)
        //    {
        //        if (iStateBase.GetCurrentState() == workFlowState) return iStateBase;
        //    }
        //    return new CommonState();
        //}

        public string Execute(string workflowName, string currentState, string activityState)
        {
            return WorkflowHandle.Instance.Run(workflowName, currentState, activityState);
        }

        public void InitWorkflowState(string workflowName)
        {
            var workflowContext = WorkflowHandle.Instance.GetWorkflowContextByWorkflowName(workflowName);
            var invokeStepList = GetInvokeStepFromContext(workflowContext);
            foreach (var workflowStep in invokeStepList)
            {
                AddWorkflowStateInfoByCondition(workflowName, workflowStep);
                if (workflowStep == null) continue;
                var partnerLinkEntity =
                    workflowContext.PartnerLinkList.First(
                        entity => entity.Name.CompareEqualIgnoreCase(workflowStep.InvokeContext.PartnerLink));
                if (partnerLinkEntity != null)
                    AddStateRoleByCondition(workflowName, workflowStep.InvokeContext.Name, partnerLinkEntity);
            }
        }

        private IEnumerable<InvokeStep> GetInvokeStepFromContext(WorkflowContext workflowContext)
        {
            return workflowContext.WorkflowStepList.OfType<StepRunnerStep>().Select(stepRunnerStep => (from invokeStep in stepRunnerStep.WorkflowSteps.OfType<InvokeStep>() select invokeStep)).FirstOrDefault();
        }

        public void AddStateRoleByCondition(string workflowName, string stateNodeName, PartnerLinkModel partnerLink)
        {
            var workflowStateEntity = GetWorkflowStateInfoByCondition(workflowName, stateNodeName);
            var roleInfoEntity = UserOperationBLL.Current.QueryRoleInfoByWorkflowStateId(workflowStateEntity.ID);
            if (roleInfoEntity == null)
            {
                roleInfoEntity = UserOperationBLL.Current.QueryRoleInfoByRoleName(partnerLink.MyRole);
                if (roleInfoEntity == null)
                {
                    roleInfoEntity = new RoleInfoModel
                                         {
                                             CreateDateTime = DateTime.Now,
                                             LastUpdateDateTime = DateTime.Now,
                                             RoleDisplayName = partnerLink.MyRole,
                                             RoleName = partnerLink.MyRole
                                         };
                    DataOperationBLL.Current.Insert(roleInfoEntity);

                }
                else
                {
                    roleInfoEntity.RoleName = partnerLink.MyRole;
                    roleInfoEntity.LastUpdateDateTime = DateTime.Now;
                    DataOperationBLL.Current.Modify(roleInfoEntity);
                }
                UserOperationBLL.Current.AddWorkflowStateInRole(workflowStateEntity.ID, roleInfoEntity.ID);
            }
            else
            {
                roleInfoEntity.RoleName = partnerLink.MyRole;
                roleInfoEntity.LastUpdateDateTime = DateTime.Now;
                DataOperationBLL.Current.Modify(roleInfoEntity);
            }
        }

        private void AddWorkflowStateInfoByCondition(string workflowName, WorkflowStep workflowStep)
        {
            var workflowStateEntity = GetWorkflowStateInfoByCondition(workflowName, workflowStep.StepId);
            if (workflowStateEntity == null)
            {
                workflowStateEntity = new WorkflowStateInfoModel
                                          {
                                              ID = Guid.NewGuid().ToString(),
                                              CreateDateTime = DateTime.Now,
                                              LastUpdateDateTime = DateTime.Now,                                             StateNodeName = workflowStep.StepId,
 
                                              StateNodeDisplayName = workflowStep.StepId,
                                              WorkflowName = workflowName,                                             WorkflowDisplayName = workflowName
 
                                          };
            }
            else
            {
                workflowStateEntity.WorkflowDisplayName = workflowName;
                workflowStateEntity.StateNodeDisplayName = workflowStep.StepId;
                //Todo: modify workflowStateInfo 
            }
          DataOperationBLL.Current.Modify(workflowStateEntity);
        }

        public WorkflowStateInfoModel GetWorkflowStateInfoByCondition(string workflowName, string stateNodeName)
        {
            return UserOperationBLL.Current.QueryWorkflowStateInfoByCondition(workflowName, stateNodeName);
        }

        public ActivityState GetActivityStateByConditontring workflowName, string workFlowState)
        {
            var entityList = UserOperationBLL.Current.QueryOperationActionByWorkCondition(workflowName,FlowState);
            return entityList.Aggregate(ActivityState.Read, (current, entity) => current | WFUntilHelp.GetActivityStateByName(entity.ActionName));
       
        }
    }
}
