using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class SteelAnalysisInfo
    {
        #region internalMember
        private string steelGradeId;
        private ElementInfo elementInfo;
        private double? maxValue;
        private double? minValue;
        private double? aimValue;
        #endregion

        #region properties
        public string SteelGradeId
        {
            get { return this.steelGradeId; }
            set { this.steelGradeId = value; }
        }
        public ElementInfo ElemInfo
        {
            get { return this.elementInfo; }
            set { this.elementInfo = value; }
        }
        public double? MaxValue
        {
            get { return this.maxValue; }
            set { this.maxValue = value; }
        }
        public double? MinValue
        {
            get { return this.minValue; }
            set { this.minValue = value; }
        }
        public double? AimValue
        {
            get { return this.aimValue; }
            set { this.aimValue = value; }
        }
        #endregion

        #region Functions
        public SteelAnalysisInfo()
        {
            this.elementInfo = new ElementInfo();
        }
        public SteelAnalysisInfo(string steelGradeId, ElementInfo elementInfo, double? maxValue, double? minValue, double? aimValue)
        {
            this.elementInfo = new ElementInfo();
            this.steelGradeId = steelGradeId;
            this.elementInfo = elementInfo;
            this.maxValue = maxValue;
            this.minValue = minValue;
            this.aimValue = aimValue;
        }
        #endregion
    }
}
