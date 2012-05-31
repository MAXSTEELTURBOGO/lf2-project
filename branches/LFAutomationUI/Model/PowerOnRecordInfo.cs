using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class PowerOnRecordInfo
    {
        #region internalMembers

        string heatId;
        int treatmentCount;
        int car;
        string treatmentStation;
        int stationId;
        DateTime startPowerOnTime;
        DateTime endPowerOnTime;
        DateTime powerDuration;
        double powerConsumption;

        #endregion

        #region properties

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
        public int Car
        {
            get { return car; }
            set { car = value; }
        }
        public string TreatmentStation
        {
            get { return treatmentStation; }
            set { treatmentStation = value; }
        }
        public int StationId
        {
            get { return stationId; }
            set { stationId = value; }
        }
        public DateTime StartPowerOnTime
        {
            get { return this.startPowerOnTime; }
            set { this.startPowerOnTime = value; }
        }
        public DateTime EndPowerOnTime
        {
            get { return this.endPowerOnTime; }
            set { this.endPowerOnTime = value; }
        }
        public DateTime PowerDuration
        {
            get { return powerDuration; }
            set { powerDuration = value; }
        }
        public double PowerConsumption
        {
            get { return powerConsumption; }
            set { powerConsumption = value; }
        }
        #endregion

        #region methods

        /// <summary>
        /// default constructor
        /// </summary>
        public PowerOnRecordInfo()
        {
 
        }

        public PowerOnRecordInfo(DateTime msgTimeStamp, string heatId, int treatmentCount ,int car,string treatmentStation,int stationId,DateTime startPowerOnTime ,DateTime endPowerOnTime,DateTime powerDuration,double powerConsumption)
        {
            this.heatId = heatId;
            this.treatmentCount = treatmentCount;
            this.car = car;
            this.treatmentStation = treatmentStation;
            this.stationId = stationId;
            this.startPowerOnTime = startPowerOnTime;
            this.endPowerOnTime = endPowerOnTime;
            this.powerDuration = powerDuration;
            this.powerConsumption = powerConsumption;
        }

        public PowerOnRecordInfo(DateTime msgTimeStamp, string heatId, int treatmentCount, int car, string treatmentStation, int stationId, DateTime startPowerOnTime, DateTime endPowerOnTime, double powerConsumption)
        {
            this.heatId = heatId;
            this.treatmentCount = treatmentCount;
            this.car = car;
            this.treatmentStation = treatmentStation;
            this.stationId = stationId;
            this.startPowerOnTime = startPowerOnTime;
            this.endPowerOnTime = endPowerOnTime;
            this.powerConsumption = powerConsumption;
        }

        #endregion
    }
}
