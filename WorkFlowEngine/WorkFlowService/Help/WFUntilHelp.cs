﻿/********************************************************************************
** Class Name:   WFUntilHelp 
** Author：      spring yang
** Create date： 2012-9-1
** Modify：      spring yang
** Modify Date： 2012-9-25
** Summary：     WFUntilHelp class
*********************************************************************************/

using System;
using System.IO;
using System.Linq;
using CommonLibrary.Help;

namespace WorkFlowService.Help
{
    public static class WFUntilHelp
    {
        public static string UserId { get; set; }

        public static ActivityState GetActivityStateByName(string activityState)
        {
            ActivityState result;
            if (Enum.TryParse(activityState, true, out result))
                return result;
            return ActivityState.Read;
        }

        //public static WorkFlowState GetWorkFlowStateByName(string workFlowState)
        //{
        //    WorkFlowState result;
        //    if (Enum.TryParse(workFlowState, true, out result))
        //        return result;
        //    return WorkFlowState.Common;
        //}

        public static ApplicationState GetApplicationState(string applicationState)
        {
            ApplicationState result;
            if (Enum.TryParse(applicationState, true, out result))
                return result;
            return ApplicationState.Draft;
        }

        private static string RunPath
        {
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }

        public static string SqliteFilePath
        {
            get { return Path.Combine(RunPath, WFConstants.SqliteFileNameTags); }
        }
    }
}
