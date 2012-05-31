using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class TempEstimateBasicInfo
    {
        private string infoName;
        public string InfoName
        {
            get { return infoName; }
            set { infoName = value; }
        }

        private string infoValue;
        public string InfoValue
        {
            get { return infoValue; }
            set { infoValue = value; }
        }

        private string infoDesc;
        public string InfoDesc
        {
            get { return infoDesc; }
            set { infoDesc = value; }
        }
    }
}
