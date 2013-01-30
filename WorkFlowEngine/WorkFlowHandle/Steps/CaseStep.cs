﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WorkFlowHandle.Steps
{
    public class CaseStep:StepRunnerStep
    {
        /// <summary>
        /// A flag indicating whether this case step is the default
        /// case for a switch statement.
        /// </summary>
        private bool defaultCase;

        /// <summary>
        /// A string containing the condition text
        /// </summary>
        private string condition;

        /// <summary>
        /// Initializes a new instance of the CaseStep class
        /// </summary>
        /// <param name="attributes">XmlAttributeCollection containing the attributes 
        /// for the BPEL CaseStep statement.</param>
        /// <param name="defaultCase">A flag indicating whether this case step
        /// is the default step</param>
        public CaseStep(XmlAttributeCollection attributes, bool defaultCase)
            : base()
        {
            this.defaultCase = defaultCase;

            // read attributes
            foreach (XmlAttribute attrib in attributes)
            {
                if (attrib.LocalName == "name")
                {
                   // StepId = attrib.Value;
                }
                else if (attrib.LocalName == "condition")
                {
                    this.condition = attrib.Value;
                }
            }
        }

        /// <summary>
        /// evaluate the condition and return true/false
        /// e.g. getVariableData('isLastUamReplica') = 'True'
        /// </summary>
        /// <param name="context">The context for a workflow containing the
        /// workflow parameters which are likely used in determining
        /// whether the case condition is met.</param>
        /// <returns>True if condition is met, false otherwise</returns>
        public bool IsConditionTrue(string context)
        {
            // The condition statements is used to determine when a step
            // should be run.  If this is the default step, the step should
            // always be run, regardless of the state of the condition statement.
            if (this.defaultCase)
            {
                return true;
            }

            return true;
            //return CompareXPath.IsConditionTrue(this.condition, context);
        }
    }
}