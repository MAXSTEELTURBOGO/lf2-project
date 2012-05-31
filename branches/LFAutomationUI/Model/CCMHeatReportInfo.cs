using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class CCMHeatReportInfo
    {
        #region Internal members
        private decimal msgId;
        private DateTime msgTimeStamp;
        private string heatId;
        private string steelGradeId;
        private string castNo;
        private int? sequenceInCast;
        private double? pouredWeight;
        private double? castWeight;
        private double? ladleTempStart;
        private double? tundishMinWeight;
        private double? moldLevelMax;
        private double? moldLevelMin;
        private double? slabTotalLength;
        private double? castStartLength;
        private double? castEndLength;
        private double? castTotalLength;
        private int? fluidTemperature;
        private int? moldFriction;
        private double? arFlowShroud;
        private double? arFlowStopper;
        private double? arFlowSealing;
        private double? arFlowUpnozzle;
        private string alarmPosition;
        private DateTime? alarmTime;
        private double? skullWeight;
        private double? ladleArrivalWeight;
        private double? ladleDepartWeight;
        private double? moldSetLevel;
        #endregion

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
        ///炉次号 
        /// </summary>
        public string HeatId
        {
            get { return heatId; }
            set { heatId = value; }
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
        /// 浇次号
        /// </summary>
        public string CastNo
        {
            get { return castNo; }
            set { castNo = value; }
        }

        /// <summary>
        /// 浇内炉序号
        /// </summary>
        public int? SequenceInCast
        {
            get { return sequenceInCast; }
            set { sequenceInCast = value; }
        }
        /// <summary>
        /// 净重[钢包钢水毛重-钢包自重] 
        /// </summary>
        public double? PouredWeight
        {
            get { return pouredWeight; }
            set { pouredWeight = value; }
        }
        /// <summary>
        /// 浇注重量[实际倒出来的钢水重量] 
        /// </summary>
        public double? CastWeight
        {
            get { return castWeight; }
            set { castWeight = value; }
        }
        /// <summary>
        /// 钢包到站温度
        /// </summary>
        public double? LadleTempStart
        {
            get { return ladleTempStart; }
            set { ladleTempStart = value; }
        }
        /// <summary>
        /// 中包最小重量
        /// </summary>
        public double? TundishMinWeight
        {
            get { return tundishMinWeight; }
            set { tundishMinWeight = value; }
        }
        /// <summary>
        /// 结晶器最大值
        /// </summary>
        public double? MoldLevelMax
        {
            get { return moldLevelMax; }
            set { moldLevelMax = value; }
        }
        /// <summary>
        /// 结晶器最小值
        /// </summary>
        public double? MoldLevelMin
        {
            get { return moldLevelMin; }
            set { moldLevelMin = value; }
        }
        /// <summary>
        /// 板坯总长度
        /// </summary>
        public double? SlabTotalLength
        {
            get { return slabTotalLength; }
            set { slabTotalLength = value; }
        }
        /// <summary>
        /// 本炉开始长度
        /// </summary>
        public double? CastStartLength
        {
            get { return castStartLength; }
            set { castStartLength = value; }
        }
        /// <summary>
        /// 本炉结束长度
        /// </summary>
        public double? CastEndLength
        {
            get { return castEndLength; }
            set { castEndLength = value; }
        }
        /// <summary>
        /// 本炉浇次长度
        /// </summary>
        public double? CastTotalLength
        {
            get { return castTotalLength; }
            set { castTotalLength = value; }
        }
        /// <summary>
        /// 液相线温度
        /// </summary>
        public int? FluidTemperature
        {
            get { return fluidTemperature; }
            set { fluidTemperature = value; }
        }
        
        /// <summary>
        ///  结晶器摩擦力 KN/M2
        /// </summary>
        public int? MoldFriction
        {
            get { return moldFriction; }
            set { moldFriction = value; }
        }

        /// <summary>
        /// 长水口氩气流量  
        /// </summary>
        public double? ArFlowShroud
        {
            get { return arFlowShroud; }
            set { arFlowShroud = value; }
        }
        /// <summary>
        /// 塞棒氩气流量
        /// </summary>
        public double? ArFlowStopper
        {
            get { return arFlowStopper; }
            set { arFlowStopper = value; }
        }
        /// <summary>
        /// 板间氩气流量
        /// </summary>
        public double? ArFlowSealing
        {
            get { return arFlowSealing; }
            set { arFlowSealing = value; }
        }
        /// <summary>
        /// 上水口氩气流量
        /// </summary>
        public double? ArFlowUpnozzle
        {
            get { return arFlowUpnozzle; }
            set { arFlowUpnozzle = value; }
        }
        /// <summary>
        ///  结晶器 报警位置
        /// </summary>
        public string AlarmPosition
        {
            get { return alarmPosition; }
            set { alarmPosition = value; }
        }
        /// <summary>
        ///  结晶器报警时间
        /// </summary>
        public DateTime? AlarmTime
        {
            get { return alarmTime; }
            set { alarmTime = value; }
        }
        /// <summary>
        /// 包坨重量（停机记录）
        /// </summary>
        public double? SkullWeight
        {
            get { return skullWeight; }
            set { skullWeight = value; }
        }
        /// <summary>
        /// 到达重量
        /// </summary>
        public double? LadleArrivalWeight
        {
            get { return ladleArrivalWeight; }
            set { ladleArrivalWeight = value; }
        }
        /// <summary>
        /// 离开重量
        /// </summary>
        public double? LadleDepartWeight
        {
            get { return ladleDepartWeight; }
            set { ladleDepartWeight = value; }
        }
        /// <summary>
        /// 二级设定结晶器值
        /// </summary>
        public double? MoldSetLevel
        {
            get { return moldSetLevel; }
            set { moldSetLevel = value; }
        }


        #region Methods
        public CCMHeatReportInfo()
        { }


        #endregion

    }
}
