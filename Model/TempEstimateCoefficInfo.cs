using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class TempEstimateCoefficInfo
    {
        private string coefficientName;
        public string CoefficientName
        {
            get { return coefficientName; }
            set { coefficientName = value; }
        }

        private double coefficientDefaultVal;
        public double CoefficientDefaultVal
        {
            get { return coefficientDefaultVal; }
            set { coefficientDefaultVal = value; }
        }

        private double coefficientModifyVal;
        public double CoefficientModifyVal
        {
            get { return coefficientModifyVal; }
            set { coefficientModifyVal = value; }
        }

        private string coefficientDesc;
        public string CoefficientDesc
        {
            get { return coefficientDesc; }
            set { coefficientDesc = value; }
        }

        #region Methods
        public TempEstimateCoefficInfo()
        { }

        public TempEstimateCoefficInfo(string coefficName, double coefficDefaultVal, double coefficModifyVal,string coefficientDesc)
        {
            this.coefficientName = coefficName;
            this.coefficientDefaultVal = coefficDefaultVal;
            this.coefficientModifyVal = coefficModifyVal;
            this.coefficientDesc = coefficientDesc;
        }
        #endregion

    }
}
