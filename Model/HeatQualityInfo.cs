using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class HeatQualityInfo
    {
        #region Internal member

        protected decimal msgId;
        protected DateTime msgTimeStamp;
        protected string heatId;
        protected int treatmentCount;
        protected DateTime sampleTime;
        protected string samplePlace;
        protected int sampleNumber;
        protected string analCode;
        protected string stationId;
        protected IList<QualityInfo> qualityList;

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

        public DateTime SampleTime
        {
            get { return sampleTime; }
            set { sampleTime = value; }
        }

        public string SamplePlace
        {
            get { return samplePlace; }
            set { samplePlace = value; }
        }

        public int SampleNumber
        {
            get { return sampleNumber; }
            set { sampleNumber = value; }
        }

        public string AnalCode
        {
            get { return analCode; }
            set { analCode = value; }
        }

        public string StationId
        {
            get { return stationId; }
            set { stationId = value; }
        }


        public IList<QualityInfo> QualityList
        {
            get { return qualityList; }
            set { qualityList = value; }
        }

        #endregion

        public HeatQualityInfo() { }

        public HeatQualityInfo(decimal msgId, DateTime msgTimeStamp, string heatId, int treatmentCount)
        {
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
            this.heatId = heatId;
            this.treatmentCount = treatmentCount;
        }

        public HeatQualityInfo(decimal msgId, DateTime msgTimeStamp,string heatId,int treatmentCount,DateTime sampleTime,string samplePlace,int sampleNumber,string analCode,string stationId) 
        {
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
            this.heatId = heatId;
            this.treatmentCount = treatmentCount;
            this.sampleTime = sampleTime;
            this.sampleNumber = sampleNumber;
            this.samplePlace = samplePlace;
            this.analCode = analCode;
            this.stationId = stationId; 
        }

        public HeatQualityInfo(decimal msgId, DateTime msgTimeStamp, string heatId, int treatmentCount, DateTime sampleTime, string samplePlace, int sampleNumber, string analCode, string stationId,IList<QualityInfo> qualityList)
        {
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
            this.heatId = heatId;
            this.treatmentCount = treatmentCount;
            this.sampleTime = sampleTime;
            this.sampleNumber = sampleNumber;
            this.samplePlace = samplePlace;
            this.analCode = analCode;
            this.stationId = stationId;
            this.qualityList = qualityList;
        }

    }
}
