using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class MaterialAnalysisInfo
    {
        #region Members
        private decimal materialId;
        private ElementInfo elemInfo;
        private double netContent;
        private double yield;
        #endregion

        #region Properties
        public decimal MaterialId
        {
            get { return this.materialId; }
            set { this.materialId = value; }
        }
        public ElementInfo ElemInfo
        {
            get { return this.elemInfo; }
            set { this.elemInfo = value; }
        }
        public double NetContent
        {
            get { return this.netContent; }
            set { this.netContent = value; }
        }
        public double Yield
        {
            get { return this.yield; }
            set { this.yield = value; }
        }

        #endregion
        #region Methods
        public MaterialAnalysisInfo(decimal materialId,ElementInfo elementInfo,double netContents,double yield)
        {
            this.materialId = materialId;
            this.elemInfo = elementInfo;
            this.netContent = netContents;
            this.yield = yield;
        }
        #endregion
    }
}
