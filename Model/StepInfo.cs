using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class StepInfo
    {
        #region members
        private int? stepId;
        private string stepName;
        #endregion

        #region Properties
        public int? StepId
        {
            get { return this.stepId; }
            set { this.stepId = value; }
        }
        public string StepName
        {
            get { return this.stepName; }
            set { this.stepName = value; }
        }
        #endregion

        #region Methods
        public StepInfo()
        { }
        public StepInfo(int? stepId, string stepName)
        {
            this.stepId = stepId;
            this.stepName = stepName;
        }
        #endregion

    }
}
