using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class HeatSlagQualityInfo
    {
        #region Internal members

        protected decimal msgId;
        protected DateTime msgTimeStamp;
        protected string heatId;
        protected int treatmentCount;
        protected string steelGradeId;
        protected string sampleAddress;
        protected int? sampleNumber;
        protected string stationId;
        protected DateTime sampleTime;
        protected string operatorName;
        protected string assessorName;
        protected string className;

        protected IList<QualityInfo> slagQualityList;

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

        public string SteelGradeId
        {
            get { return steelGradeId; }
            set { steelGradeId = value; }
        }

        public string SampleAddress
        {
            get { return sampleAddress; }
            set { sampleAddress = value; }
        }

        public int? SampleNumber
        {
            get { return sampleNumber; }
            set { sampleNumber = value; }
        }

        public string StationId
        {
            get { return stationId; }
            set { stationId = value; }
        }

        public DateTime SampleTime
        {
            get { return sampleTime; }
            set { sampleTime = value; }
        }

        public string OperatorName
        {
            get { return operatorName; }
            set { operatorName = value; }
        }

        public string AssessorName
        {
            get { return assessorName; }
            set { assessorName = value; }
        }

        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }

        public IList<QualityInfo> SlagQualityList
        {
            get { return slagQualityList; }
            set { slagQualityList = value; }
        }

        #endregion

        #region Methods

        public HeatSlagQualityInfo() { }

        public HeatSlagQualityInfo(decimal msgId, DateTime msgTimeStamp)
        {
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
        }

        public HeatSlagQualityInfo(decimal msgId, DateTime msgTimeStamp, string heatId, int treatmentCount, string sampleAddress, int? sampleNumber, string stationId, DateTime sampleTime)
        {
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
            this.heatId = heatId;
            this.treatmentCount = treatmentCount;
            this.sampleAddress = sampleAddress;
            this.sampleNumber = sampleNumber;
            this.stationId = stationId;
            this.sampleTime = sampleTime;
        }

        public HeatSlagQualityInfo(decimal msgId, DateTime msgTimeStamp, string heatId, int treatmentCount, string sampleAddress, int? sampleNumber, string stationId, DateTime sampleTime,  IList<QualityInfo> slagQualityList)
        {
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
            this.heatId = heatId;
            this.treatmentCount = treatmentCount;
            this.sampleAddress = sampleAddress;
            this.sampleNumber = sampleNumber;
            this.stationId = stationId;
            this.sampleTime = sampleTime;
            this.slagQualityList = slagQualityList;
        }
        #endregion
    }
}
