using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class StatusInfo
    {
        #region Internal members
        private int statusId;
        private string statusName;
        #endregion

        public int StatusId
        {
            get { return this.statusId; }
            set { this.statusId = value; }
        }

        public string StatusName
        {
            get { return this.statusName; }
            set { this.statusName = value; }
        }

        public StatusInfo() { }

        public StatusInfo(int statusId, string statusName)
        {
            this.statusId = statusId;
            this.statusName = statusName;
        }
    }
}
