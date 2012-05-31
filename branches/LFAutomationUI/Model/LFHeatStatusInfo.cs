using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class LFHeatStatusInfo
    {
        #region internalMembers

        private decimal msgId;
        private DateTime msgTimeStamp;
        private string heatId;
        private int treatmentCount;
        private DateTime statusTimeStamp;
        private StatusInfo heatStatus;
        private int? powerDuration;
        private int? powerConsumption;
        private double? steelWeight;
        private double? slagWeight;
        private double? stausTemperature;
        
        #endregion

        #region Properties

        public decimal MsgId
        {
            get { return this.msgId; }
            set { this.msgId = value; }
        }

        public DateTime MsgTimeStamp
        {
            get { return this.msgTimeStamp; }
            set { this.msgTimeStamp = value; }
        }

        public string HeatId
        {
            get { return this.heatId; }
            set { this.heatId = value; }
        }
        public int TreatmentCount
        {
            get { return this.treatmentCount; }
            set { this.treatmentCount = value; }
        }

        public DateTime StatusTimeStamp
        {
            get { return this.statusTimeStamp; }
            set { this.statusTimeStamp = value; }
        }

        public StatusInfo HeatStatus
        {
            get { return this.heatStatus; }
            set { this.heatStatus = value; }
        }
        public int? PowerDuration
        {
            get { return powerDuration; }
            set { powerDuration = value; }
        }

        public int? PowerConsumption
        {
            get { return powerConsumption; }
            set { powerConsumption = value; }
        }

        public double? SteelWeight
        {
            get { return steelWeight; }
            set { steelWeight = value; }
        }

        public double? SlagWeight
        {
            get { return slagWeight; }
            set { slagWeight = value; }
        }
        public double? StausTemperature
        {
            get { return stausTemperature; }
            set { stausTemperature = value; }
        }

        #endregion

        #region methods

        public LFHeatStatusInfo() 
        {
            this.HeatStatus = new StatusInfo();
        }

        public LFHeatStatusInfo(decimal msgId,DateTime msgTimeStamp)
        {
            this.HeatStatus = new StatusInfo();
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
        }

        public LFHeatStatusInfo(decimal msgId,DateTime msgTimeStamp,string heatId,int treatmentCount,DateTime statusTimeStamp,StatusInfo heatStatus,int? powerDuration,int? powerConsumption,double? steelWeight,double? slagWeight,double? statusTemperature)
        {
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
            this.heatId = heatId;
            this.treatmentCount = treatmentCount;
            this.statusTimeStamp = statusTimeStamp;
            this.heatStatus = heatStatus;
            this.powerDuration = powerDuration;
            this.powerConsumption = powerConsumption;
            this.steelWeight = steelWeight;
            this.slagWeight = slagWeight;
            this.stausTemperature = statusTemperature;
        }

        #endregion
    }
}
