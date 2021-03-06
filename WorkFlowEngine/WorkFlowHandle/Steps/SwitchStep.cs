﻿/********************************************************************************
** Class Name:   SwitchStep 
** Author：      Spring Yang
** Create date： 2012-9-1
** Modify：      Spring Yang
** Modify Date： 2012-9-25
** Summary：     SwitchStep class
*********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using CommonLibrary.Help;
using WorkFlowHandle.IDAL;

namespace WorkFlowHandle.Steps
{
    using Model;
    public class SwitchStep : StepRunnerStep,ISwitchStep
    {
        public SwitchContextModel SwitchContext { get; set; }

        /// <summary>
        /// Initializes a new instance of the SwitchStep class
        /// </summary>
        /// <param name="attributes">Xml attributes from the BPEL file</param>
        public SwitchStep(XmlAttributeCollection attributes)
        {
            SwitchContext = new SwitchContextModel();
            // set name attribute - only one we care about for now
            foreach (XmlAttribute attrib in attributes)
            {
                if (attrib.LocalName == "name")
                {
                    SwitchContext.Name = attrib.Value;
                    StepId = attrib.Value;
                }
            }
        }

        /// <summary>
        /// Executes the SwitchStep.  
        /// </summary>
        /// <param name="context">Context for the workflow to run</param>
        /// <param name="stepId">Action name</param>
        /// <returns>State of the workflow after executing the steps.</returns>
        public override string Run(WorkflowContext context, string stepId)
        {
            //var currentState = WorkFlowState.Done.ToString();
            var currentState = string.Empty;
            foreach (WorkflowStep step in WorkflowSteps)
            {
                // Go through each step in order until one is found with a valid condition.
                var caseStep = step as ICaseStep;
                if (caseStep != null)
                {
                    if (!String.IsNullOrEmpty(stepId))
                    {
                        // Used to run workflow from switch step begin.
                        if (caseStep.CaseContext.Condition.CompareEqualIgnoreCase(stepId))
                        {
                            currentState = this.RunCase(caseStep, ref context, stepId);
                        }
                        // we must be restarting for some reason,  find the case where we last stopped.
                        //if (step.HasStep(stepId))
                        //{
                        //    currentState = this.RunCase(caseStep, ref context, stepId);
                        //    break;
                        //}
                    }
                    else if (caseStep.IsConditionTrue(context))
                    {
                        currentState = this.RunCase(caseStep, ref context, stepId);
                        break;
                    }
                }
            }
            return currentState;
        }

        /// <summary>
        /// Runs the provided CaseStep.  The CaseStep requires a reference to 
        /// an instance of the currently executing WorkflowExecutionEngine
        /// to run.
        /// </summary>
        /// <param name="caseStep">The CaseStep instance to run</param>
        /// <param name="context">The workflow context containing workflow state and data.</param>
        /// <param name="stepId">The stepId for the step to start exeuction.  This is only
        /// non null when a workflow has previously run and is restarteing.  The stepId
        /// is used to determine where to restart execution.</param>
        /// <returns>The WorkflowState after execution of the CaseStep.</returns>
        private string RunCase(ICaseStep caseStep, ref WorkflowContext context, string stepId)
        {
            var currentState = caseStep.Run(context, stepId);
            return currentState;
        }
    }
}
