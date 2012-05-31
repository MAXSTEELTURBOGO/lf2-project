using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class ElementInfo
    {
        #region Internal Members

        private int? elementId;
        private string elementShortName;
        private string elementFullName;
        private string elementType;
        private decimal viewSequence;
        private double fixedRatio;

        #endregion

        #region Properties

        public int? ElementId
        {
            get { return this.elementId; }
            set { this.elementId = value; }
        }
        public string ElementShortName
        {
            get { return this.elementShortName; }
            set { this.elementShortName = value; }
        }
        public string ElementFullName
        {
            get { return this.elementFullName; }
            set { this.elementFullName = value; }
        }
        public string ElementType
        {
            get { return this.elementType; }
            set { this.elementType = value; }
        }

        public decimal ViewSequence
        {
            get { return this.viewSequence; }
            set { this.viewSequence = value; }
        }

        public double FixedRatio
        {
            get { return this.fixedRatio; }
            set { this.fixedRatio = value; }
        }

        #endregion

        #region Methods
        public ElementInfo()
        { }

        public ElementInfo(int? elementId, string elementShortName, string elementFullName,string elementType)
        {
            this.elementId = elementId;
            this.elementShortName = elementShortName;
            this.elementFullName = elementFullName;
            this.elementType = elementType;
        }

        public ElementInfo(int? elementId, string elementShortName, string elementFullName, string elementType,decimal viewSequence,double fixedRatio)
        {
            this.elementId = elementId;
            this.elementShortName = elementShortName;
            this.elementFullName = elementFullName;
            this.elementType = elementType;
            this.fixedRatio = fixedRatio;
            this.viewSequence = viewSequence;
        }

        #endregion
    }
}
