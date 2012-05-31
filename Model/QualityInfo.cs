using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class QualityInfo
    {
        #region Internal members

        private ElementInfo element;
        private double? qualityValue;
        #endregion

        #region Properties

        public ElementInfo Element
        {
            get { return this.element; }
            set { this.element = value; }
        }

        public double? QualityValue
        {
            get { return qualityValue; }
            set { qualityValue = value; }
        }

        #endregion

        public QualityInfo(){ }

        public QualityInfo(ElementInfo element,double? qualityValue)
        {
            this.element = element;
            this.qualityValue = qualityValue;
        }

    }
}
