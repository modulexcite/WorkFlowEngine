﻿/********************************************************************************
** Class Name:   TestStateWorkFlowTest
** Author：      spring yang
** Create date： 2013-3-13
** Modify：      spring yang
** Modify Date： 2012-3-13
** Summary：     TestStateWorkFlowTest interface
*********************************************************************************/


using System.Diagnostics;
using CommonLibrary.Help;
using CommonLibrary.Model;

namespace TestCommunication.WorkflowService
{
    using Common;
    using NUnit.Framework;
    using WFService;

    public class TestStateWorkFlowTest : BaseActivity
    {
      

        [Test]
        public void TestNewWorkflow()
        {
            var appEntity = new AppInfoModel
            {
                ActivityState = "Submit",
                AppName = "TestApp",
                AppId = "001",
                WorkflowName = "TestStateWorkFlow",
                UserId = "001",
                CurrentState = "Common"
            };
            var result = WfServiceInstance.NewWorkFlow(appEntity);
            Assert.AreEqual(result, "Manage");

        }


        [Test]
        public void TestManageApproveWorkflow()
        {
            var appEntity = new AppInfoModel
            {
                ActivityState = "Submit",
                AppId = "002",
                AppName = "TestApp",
                WorkflowName = "TestStateWorkFlow",
                UserId = "002",
                CurrentState = "Common"
            };
            var result = WfServiceInstance.NewWorkFlow(appEntity);
            Assert.AreEqual(result, "Manage");

            var manageEntity = new AppInfoModel
            {
                ActivityState = "Approve",
                AppId = "002",
                AppName = "TestApp",
                WorkflowName = "TestStateWorkFlow",
                UserId = "003",
                CurrentState = "Manage"
            };
            var manageResult = WfServiceInstance.Execute(manageEntity);
            Assert.AreEqual(manageResult, "Done");
        }

        [Test]
        public void TestManageRejectWorkFlow()
        {
            var appEntity = new AppInfoModel
            {
                ActivityState = "Submit",
                AppId = "004",
                AppName = "TestApp",
                WorkflowName = "TestStateWorkFlow",
                UserId = "004",
                CurrentState = "Common"
            };
            var result = WfServiceInstance.NewWorkFlow(appEntity);
            Assert.AreEqual(result, "Manage");

            var manageEntity = new AppInfoModel
            {
                ActivityState = "Reject",
                AppId = "004",
                AppName = "TestApp",
                WorkflowName = "TestStateWorkFlow",
                UserId = "005",
                CurrentState = "Manage"
            };
            var manageResult = WfServiceInstance.Execute(manageEntity);
            Assert.AreEqual(manageResult, "Refuse");
        }


        [Test]
        public void TestSaveWorkflow()
        {
            var appEntity = new AppInfoModel
            {
                ActivityState = "Save",
                AppId = "006",
                AppName = "TestApp",
                WorkflowName = "TestStateWorkFlow",
                UserId = "006",
                CurrentState = "Common"
            };
            var result = WfServiceInstance.NewWorkFlow(appEntity);
            Assert.AreEqual(result, "Common");
        }


        [Test]
        public void TestRevokeWorkflow()
        {
            var appEntity = new AppInfoModel
            {
                ActivityState = "Submit",
                AppId = "007",
                AppName = "TestApp",
                WorkflowName = "TestStateWorkFlow",
                UserId = "007",
                CurrentState = "Common"
            };
            var result = WfServiceInstance.NewWorkFlow(appEntity);
            Assert.AreEqual(result, "Manage");

            var commonEntity = new AppInfoModel
            {
                ActivityState = "Revoke",
                AppId = "007",
                AppName = "TestApp",
                WorkflowName = "TestStateWorkFlow",
                UserId = "007",
                CurrentState = "Common"
            };
            var revokeResult = WfServiceInstance.Execute(commonEntity);
            Assert.AreEqual(revokeResult, "Common");
        }

        [Test]
        public void TestResubmitWorkflow()
        {
            var appEntity = new AppInfoModel
            {
                ActivityState = "Submit",
                AppId = "008",
                AppName = "TestApp",
                WorkflowName = "TestStateWorkFlow",
                UserId = "008",
                CurrentState = "Common"
            };
            var result = WfServiceInstance.NewWorkFlow(appEntity);
            Assert.AreEqual(result, "Manage");

            var commonEntity = new AppInfoModel
            {
                ActivityState = "Revoke",
                AppId = "008",
                AppName = "TestApp",
                WorkflowName = "TestStateWorkFlow",
                UserId = "008",
                CurrentState = "Common"
            };
            var revokeResult = WfServiceInstance.Execute(commonEntity);
            Assert.AreEqual(revokeResult, "Common");

            var resubmitEntity = new AppInfoModel
            {
                ActivityState = "Resubmit",
                AppId = "008",
                AppName = "TestApp",
                WorkflowName = "TestStateWorkFlow",
                UserId = "008",
                CurrentState = "Common"
            };
            var lastResult = WfServiceInstance.Execute(resubmitEntity);
            Assert.AreEqual(lastResult, "Manage");
        }

        [Test]
        public void TestWorkflowAppState()
        {

            var appEntity = new AppInfoModel
            {
                ActivityState = "Submit",
                AppId = "009",
                AppName = "TestApp",
                WorkflowName = "TestStateWorkFlow",
                UserId = "009",
                CurrentState = "Common"
            };

            var firstState = WfServiceInstance.GetApplicationStateByAppId(appEntity.AppId);
            Assert.AreEqual(firstState,ApplicationState.Draft);
            var result = WfServiceInstance.NewWorkFlow(appEntity);
            Assert.AreEqual(result, "Manage");
            var secondState = WfServiceInstance.GetApplicationStateByAppId(appEntity.AppId);
            Assert.AreEqual(secondState, ApplicationState.InProgress);
            var commonEntity = new AppInfoModel
            {
                ActivityState = "Approve",
                AppId = "009",
                AppName = "TestApp",
                WorkflowName = "TestStateWorkFlow",
                UserId = "009",
                CurrentState = "Manage"
            };
            var approveResult = WfServiceInstance.Execute(commonEntity);
            Assert.AreEqual(approveResult, "Done");
            var thirdState = WfServiceInstance.GetApplicationStateByAppId(appEntity.AppId);
            Assert.AreEqual(thirdState, ApplicationState.Complete);
        }
    }
}

