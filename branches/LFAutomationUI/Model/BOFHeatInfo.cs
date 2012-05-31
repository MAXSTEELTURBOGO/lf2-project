using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class BOFHeatInfo
    {
        #region Internal member

        private decimal msgId;
        private DateTime msgTimeStamp;
        private string heatId;
        private int? stationId;
        private string steelGradeId;
        private int? blowCount;
        private DateTime? startTime;
        private DateTime? endTime;
        private double? endTemperature;
        private double? tappingDuration;
        private bool? isReblowing;
        private double? steelNetWeight;
        private double? hotMetalWeight;
        private double? scrapInWeight;
        private double? oxygenConsumption;
        private double? reblowingOxygenConsumption;
        private double? tscTemperature;
        private double? tscCarbon;
        private double? tsoTemperature;
        private double? tsoOxygen;
        private double? tsoCarbon;

        #endregion

        #region Properties

        /// <summary>
        /// 流水号
        /// </summary>
        public decimal MsgId
        {
            get { return msgId; }
            set { msgId = value; }
        }
        
        /// <summary>
        /// 消息时间
        /// </summary>
        public DateTime MsgTimeStamp
        {
            get { return msgTimeStamp; }
            set { msgTimeStamp = value; }
        }

        /// <summary>
        /// 炉次号
        /// </summary>
        public string HeatId
        {
            get { return heatId; }
            set { heatId = value; }
        }

        /// <summary>
        /// BOF站号
        /// </summary>
        public int? StationId
        {
            get { return stationId; }
            set { stationId = value; }
        }
        
        /// <summary>
        /// 钢种号
        /// </summary>
        public string SteelGradeId
        {
            get { return steelGradeId; }
            set { steelGradeId = value; }
        }

        /// <summary>
        /// 吹炼次数
        /// </summary>
        public int? BlowCount
        {
            get { return blowCount; }
            set { blowCount = value; }
        }

        /// <summary>
        /// 开始处理时刻
        /// </summary>
        public DateTime? StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        
        /// <summary>
        /// 出钢结束时刻
        /// </summary>
        public DateTime? EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        
        /// <summary>
        /// 出钢后温度
        /// </summary>
        public double? EndTemperature
        {
            get { return endTemperature; }
            set { endTemperature = value; }
        }
       
        /// <summary>
        /// 出钢耗时，单位S
        /// </summary>
        public double? TappingDuration
        {
            get { return tappingDuration; }
            set { tappingDuration = value; }
        }
        
        /// <summary>
        /// 是否点吹
        /// </summary>
        public bool? IsReblowing
        {
            get { return isReblowing; }
            set { isReblowing = value; }
        }

        /// <summary>
        /// 钢水净重
        /// </summary>
        public double? SteelNetWeight
        {
            get { return steelNetWeight; }
            set { steelNetWeight = value; }
        }
        
        /// <summary>
        /// 兑入铁水量
        /// </summary>
        public double? HotMetalWeight
        {
            get { return hotMetalWeight; }
            set { hotMetalWeight = value; }
        }
        
        /// <summary>
        /// 废钢装炉量
        /// </summary>
        public double? ScrapInWeight
        {
            get { return scrapInWeight; }
            set { scrapInWeight = value; }
        }

        /// <summary>
        /// 总耗氧量
        /// </summary>
        public double? OxygenConsumption
        {
            get { return oxygenConsumption; }
            set { oxygenConsumption = value; }
        }
        
        /// <summary>
        /// 点吹耗氧量
        /// </summary>
        public double? ReblowingOxygenConsumption
        {
            get { return reblowingOxygenConsumption; }
            set { reblowingOxygenConsumption = value; }
        }

       
        /// <summary>
        /// TSC测温
        /// </summary>
        public double? TscTemperature
        {
            get { return tscTemperature; }
            set { tscTemperature = value; }
        }
       
        /// <summary>
        /// TSC测碳
        /// </summary>
        public double? TscCarbon
        {
            get { return tscCarbon; }
            set { tscCarbon = value; }
        }
        
        /// <summary>
        /// TSO测温
        /// </summary>
        public double? TsoTemperature
        {
            get { return tsoTemperature; }
            set { tsoTemperature = value; }
        }
        
        /// <summary>
        /// TSO测氧
        /// </summary>
        public double? TsoOxygen
        {
            get { return tsoOxygen; }
            set { tsoOxygen = value; }
        }
        
        /// <summary>
        /// TSO测碳
        /// </summary>
        public double? TsoCarbon
        {
            get { return tsoCarbon; }
            set { tsoCarbon = value; }
        }

        #endregion

        #region MyRegion

        public BOFHeatInfo() { }

        public BOFHeatInfo(decimal msgId, DateTime msgTimeStamp)
        {
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
        }

        public string IsBlowingToString()
        {
            if (this.isReblowing!=null&&this.isReblowing.HasValue)
            {
                return this.isReblowing.Value ? "是" : "否";
            }
            else
            {
                return null;
            }
        }

        #endregion
        
    }
}
