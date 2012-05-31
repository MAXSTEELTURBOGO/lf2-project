using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.Model
{
    public class TechnicsInfo
    {
        #region members
        private int? technicId;
        private string technicName;
        private IList<TechnicStepInfo> technicStepInfo;
        #endregion

        #region Properties
        public int? TechnicId
        {
            get { return this.technicId; }
            set { this.technicId = value; }
        }
        public string TechnicName
        {
            get { return this.technicName; }
            set { this.technicName = value; }
        }
        public IList<TechnicStepInfo> TechnicStepInfo
        {
            get { return this.technicStepInfo; }
            set { this.technicStepInfo = value; }
        }
        #endregion

        #region Methods
        public TechnicsInfo()
        {
            this.technicStepInfo = new List<TechnicStepInfo>();
        }
        public TechnicsInfo(int? technicId, string technicName)
        {
            this.technicId = technicId;
            this.technicName = technicName;
        }
        public TechnicsInfo(int? technicId, string technicName, IList<TechnicStepInfo> technicStepInfo)
        {
            this.technicStepInfo = new List<TechnicStepInfo>();
            this.technicId = technicId;
            this.technicName = technicName;
            this.technicStepInfo = technicStepInfo;
        }
        #endregion
    }
}
