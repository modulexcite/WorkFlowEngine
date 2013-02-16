﻿/********************************************************************************
** Class Name:   SwitchStep 
** Author：      spring yang
** Create date： 2012-9-1
** Modify：      spring yang
** Modify Date： 2012-9-25
** Summary：     SwitchStep class
*********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using CommonLibrary.Help;

namespace WorkFlowHandle.Steps
{
    public class Switcusing Model;
    public class SwitchStep : StepRunnerStep
    {
        public SwitchContextModel SwitchContext { get; set; }
ry>
        /// Initializes a new instance of the SwitchStep class
        /// </summary>
        /// <param name="attributes">Xml attributes from the BPEL file</param>
        public SwitchStep(XmlAttributeCollection attributes)
        {
            // set name attribute - only one we care about for now
            foreach (XmlAttribute attrib in attributes)
            {
                if (attrib.LocalName == "name")
                {
                    StepId = attrib.Value;
       SwitchContext.Name  }
            }
        }

        /// <summary>
        /// Executes the SwitchStep.  
        /// </summary>
        /// <param name="context">Context for the workflow to run</param>
        /// <param name="stepId">Step at which to start execution.  Execution starts at first step
        /// if this is null or an empty string.</param>
        /// <returns>State of the workflow after executing the steps.</returns>
        public override WorkFlowState Run(string context, string stepIdstring Run(WorkflowContext context, string stepId)
        {
            var currentState = WorkFlowState.Done.ToString()flowSteps)
            {
                // Go through each step in order until one is found with a valid condition.
                CaseStep caseStep = step as CaseStep;
                if (caseStep != null)
                {
                    if (!String.IsNullOrEmpty(stepId))
                    {
                        // Used to run workflow from switch step begin.
                        if (stepId == StepId)
                        {
                            currentState = this.RunCase(caseStep, ref context, stepId);
                        }
                        // we must be restarting for some reason,  find the case where we last stopped.
                        if (step.HasStep(stepId))
                        {
                            currentState = this.RunCase(caseStep, ref context, stepId);
                            break;
                        }
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
        /// Runs the provided CaseStep.  The.ToString() CaseStep requires a reference to 
        /// an instance of the currently executing WorkflowExecutionEngine
        /// to run.
        /// </summary>
        /// <param name="caseStep">The CaseStep instance to run</param>
        /// <param name="context">The workflow context containing workflow state and data.</param>
        /// <param name="stepId">The stepId for the step to start exeuction.  This is only
        /// non null when a workflow has previously run and is restarteing.  The stepId
        /// is used to determine where to restart execution.</param>
        /// <returns>The WorkflowState after execution of the CaseStep.</returns>
        private WorkFlowState RunCase(CaseStep caseStep, ref string context, string stepId)
        {

      string RunCase(CaseStep caseStep, ref WorkflowContext context, string stepId)
        {

            var}
