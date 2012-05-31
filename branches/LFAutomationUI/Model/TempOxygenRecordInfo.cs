using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class TempOxygenRecordInfo
    {
        #region internalMembers

        decimal msgId;
        DateTime? msgTimeStamp;
        string heatId;
        int treatmentCount;
        private int car;
        private string treatmentStation;
        private int? stationId;
        double? temperatureData;
        double? oxygenData;
        int? powerDuration;
        int? powerConsumption;
        string type;

        #endregion

        #region properties
        /// <summary>
        /// 消息号
        /// </summary>
        public decimal MsgId
        {
            get { return this.msgId; }
            set { this.msgId = value; }
        }
        /// <summary>
        /// 消息时间
        /// </summary>
        public DateTime? MsgTimeStamp
        {
            get { return this.msgTimeStamp; }
            set { this.msgTimeStamp = value; }
        }
        /// <summary>
        /// 炉次号
        /// </summary>
        public string HeatId
        {
            get { return this.heatId; }
            set { this.heatId = value; }
        }
        /// <summary>
        /// 冶炼次数
        /// </summary>
        public int TreatmentCount
        {
            get { return this.treatmentCount; }
            set { this.treatmentCount = value; }
        }
        /// <summary>
        /// 小车号
        /// </summary>
        public int Car
        {
            get { return car; }
            set { car = value; }
        }
        /// <summary>
        /// 处理站名称
        /// </summary>
        public string TreatmentStation
        {
            get { return treatmentStation; }
            set { treatmentStation = value; }
        }
        /// <summary>
        /// 处理站号
        /// </summary>
        public int? StationId
        {
            get { return stationId; }
            set { stationId = value; }
        }
        /// <summary>
        /// 测温值
        /// </summary>
        public double? TemperatureData
        {
            get { return this.temperatureData; }
            set { this.temperatureData = value; }
        }
        /// <summary>
        /// 测含氧量值
        /// </summary>
        public double? OxygenData
        {
            get { return this.oxygenData; }
            set { this.oxygenData = value; }
        }
        /// <summary>
        /// 测温时通电时间
        /// </summary>
        public int? PowerDuration
        {
            get { return this.powerDuration; }
            set { this.powerDuration = value; }
        }
        /// <summary>
        /// 测温时电耗
        /// </summary>
        public int? PowerConsumption
        {
            get { return this.powerConsumption; }
            set { this.powerConsumption = value; }
        }
        /// <summary>
        /// 测取类型
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        #endregion

        #region methods

        public TempOxygenRecordInfo() { }

        public TempOxygenRecordInfo(decimal msgId, DateTime? msgTimeStamp, string heatId, int treatmentCount, int car, string treatmentStation, int? stationId, double? temperatureData, double? oxygenData, int? powerDuration, int? powerConsumption)
        {
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
            this.heatId = heatId;
            this.treatmentCount = treatmentCount;
            this.car = car;
            this.treatmentStation = treatmentStation;
            this.stationId = stationId;
            this.temperatureData = temperatureData;
            this.oxygenData = oxygenData;
            this.powerDuration = powerDuration;
            this.powerConsumption = powerConsumption;
        }
        public TempOxygenRecordInfo(decimal msgId, DateTime? msgTimeStamp, string heatId, int treatmentCount, int car, string treatmentStation, int? stationId, double? temperatureData, double? oxygenData, int? powerDuration, int? powerConsumption,string type)
        {
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
            this.heatId = heatId;
            this.treatmentCount = treatmentCount;
            this.car = car;
            this.treatmentStation = treatmentStation;
            this.stationId = stationId;
            this.temperatureData = temperatureData;
            this.oxygenData = oxygenData;
            this.powerDuration = powerDuration;
            this.powerConsumption = powerConsumption;
            this.type = type;
        }
        #endregion
    }
}
