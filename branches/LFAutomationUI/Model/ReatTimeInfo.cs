using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class RealTimeInfo
    {

        #region Internal members

        private decimal msgId;
        private DateTime msgTimeStamp;
        private string heatId;
        private int treatmentCount;
        private double? arConsumption;
        private double? powerConsumption;
        private double? aEAV;
        private double? bEAV;
        private double? cEAV;
        private double? aEAC;
        private double? bEAC;
        private double? cEAC;
        private double? argonFlow1;
        private double? argonFlow2;
        private double? argonPressure1;
        private double? argonPressure2;
        private double? theoryTemp;

        #endregion

        #region Properties

        public decimal MsgId
        {
            get { return msgId; }
            set { msgId = value; }
        }

        public DateTime MsgTimeStamp
        {
            get { return msgTimeStamp; }
            set { msgTimeStamp = value; }
        }

        public string HeatId
        {
            get { return heatId; }
            set { heatId = value; }
        }

        public int TreatmentCount
        {
            get { return treatmentCount; }
            set { treatmentCount = value; }
        }

        public double? ArConsumption
        {
            get { return arConsumption; }
            set { arConsumption = value; }
        }

        public double? PowerConsumption
        {
            get { return powerConsumption; }
            set { powerConsumption = value; }
        }

        public double? AEAV
        {
            get { return aEAV; }
            set { aEAV = value; }
        }

        public double? BEAV
        {
            get { return bEAV; }
            set { bEAV = value; }
        }

        public double? CEAV
        {
            get { return cEAV; }
            set { cEAV = value; }
        }

        public double? AEAC
        {
            get { return aEAC; }
            set { aEAC = value; }
        }

        public double? BEAC
        {
            get { return bEAC; }
            set { bEAC = value; }
        }

        public double? CEAC
        {
            get { return cEAC; }
            set { cEAC = value; }
        }

        public double? ArgonFlow1
        {
            get { return argonFlow1; }
            set { argonFlow1 = value; }
        }

        public double? ArgonFlow2
        {
            get { return argonFlow2; }
            set { argonFlow2 = value; }
        }

        public double? ArgonPressure1
        {
            get { return argonPressure1; }
            set { argonPressure1 = value; }
        }


        public double? ArgonPressure2
        {
            get { return argonPressure2; }
            set { argonPressure2 = value; }
        }

        /// <summary>
        /// 理论温度值
        /// </summary>
        public double? TheoryTemp
        {
            get { return theoryTemp; }
            set { theoryTemp = value; }
        }
        #endregion

        #region Public Methods

        public RealTimeInfo() { }

        public RealTimeInfo(decimal msgId,DateTime msgTimeStamp)
        {
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
        }

        #endregion
       
    }
}
