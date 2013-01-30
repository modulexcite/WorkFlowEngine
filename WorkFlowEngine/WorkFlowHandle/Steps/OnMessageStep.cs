﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namusing System.Xml;
using CommonLibrary.Help;

namespace WorkFlowHandle.Steps
{
    public class OnMessageStep:StepRunnerStep
    {
        /// <summary>
        /// Contains a ReceiveStep instance that can find the
        /// message described in the OnMessageStep
        /// </summary>
        private ReceiveStep receiveStep;

        /// <summary>
        /// Initializes a new instance of the OnMessageStep class
        /// </summary>
        /// <param name="attributes">Xml attributes from the BPEL file</param>
        public OnMessageStep(XmlAttributeCollection attributes)
        {
            // read attributes
            foreach (XmlAttribute attrib in attributes)
            {
                if (attrib.LocalName == "name")
                {
                    StepId = attrib.Value;
                    break;
                }
            }

            this.receiveStep = new ReceiveStep(attributes);
        }

        /// <summary>
        /// Runs this OnMessage step.  If message has been received, executes the defined steps,
        /// otherwise returns a waiting status.
        /// </summary>
        /// <param name="context">Context for the workflow to run</param>
        /// <param name="stepId">Step at which to start execution.  Execution starts at first step
        /// if this is null or an empty string.</param>
        /// <returns>State of the workflow after executing the steps.</returns>
        public   WorkFlowState Run(string context, string stepId)
        {
            var currentState = this.receiveStep.Run(context, stepId);
            if (currentState !=  WorkFlowState.Done)
            {
                // Have the event so run
                return base.Run(context, null);
            }

            // Check the workflow name whether in the continueworkflowList, If in the list, then don't report error status, continue running the workflow
            if (currentState ==WorkFlowState.Manager)
            {
                return base.Run(context, null);
            }
            return currentState;
        }
    }
}
