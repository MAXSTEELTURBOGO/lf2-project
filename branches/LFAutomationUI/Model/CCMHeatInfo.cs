using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class CCMHeatInfo
    {
        #region Internal members

        private decimal msgId;               //	N	消息号
        private DateTime msgTimeStamp;       //	N	消息时间
        private string steelGradeName;       //	Y	钢种名称
        private string steelGradeId;         //	Y	钢种代码
        private double? ladleWeight;          //	Y	钢包重量
        private double? tundishWeight;        //	Y	中包重量
        private double? castingSpeed;         //	Y	浇注速度
        private double? totalLenth;           //	Y	总长度
        private int? castTotalTime;          //	Y	浇注总时间
        private int? castRemainTime;         //	Y	浇注剩余时间
        private string heatId;               //	Y	炉次号
        private int? tundishTemperature;     //	Y	中包温度
        private string ccmId;                //	Y	铸机号
        private string heatStatus;           //	Y	"炉次状态 1 =钢包到达时刻；2  =钢包浇铸开始时刻；3  =钢包浇铸结束时刻；4  =中包浇铸开始时刻；5  =中包浇铸结束时刻；6  =钢包离开时刻。7 最后一支板坯切割时间
        private DateTime? statusTimeStamp;   //	Y	HEAT_STATUS_TIME
        private DateTime? startArTime;       //	Y	开始吹氩时间
        private DateTime? endArTime;         //	Y	结束吹氩时间
        private int? arConsumped;            //	Y	氩气消耗
        private string castNumber;           //	Y	浇次号
        private int? sequenceInCast;         //	Y	浇内炉序号
        private double? steelWeightLadle;     //	Y	STEEL l weight IN LADEL 大包内钢水重量
        private double? steelWeightTundish;   //	Y	Steel weight in tundish 中包内钢水重量
        private DateTime? lastTemperatureDate;   //	Y	last time test temperature date 最后测温时刻
        private int? steelLiquidTemperature; //	Y	last time test temperature 最后一次测温温度
        private double? slabWidth;            //	Y	slab width板坯宽度

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
        public string SteelGradeName
        {
            get { return steelGradeName; }
            set { steelGradeName = value; }
        }
        public string SteelGradeId
        {
            get { return steelGradeId; }
            set { steelGradeId = value; }
        }
        public double? LadleWeight
        {
            get { return ladleWeight; }
            set { ladleWeight = value; }
        }
        public double? TundishWeight
        {
            get { return tundishWeight; }
            set { tundishWeight = value; }
        }
        public double? CastingSpeed
        {
            get { return castingSpeed; }
            set { castingSpeed = value; }
        }
        public double? TotalLength
        {
            get { return totalLenth; }
            set { totalLenth = value; }
        }        
        public int? CastTotalTime
        {
            get { return castTotalTime; }
            set { castTotalTime = value; }
        }       
        public int? CastRemainTime
        {
            get { return castRemainTime; }
            set { castRemainTime = value; }
        }        
        public string HeatId
        {
            get { return heatId; }
            set { heatId = value; }
        }
        public int? TundishTemperature
        {
            get { return tundishTemperature; }
            set { tundishTemperature = value; }
        }        
        public string CCMId
        {
            get { return ccmId; }
            set { ccmId = value; }
        }       
        public string HeatStatus
        {
            get { return heatStatus; }
            set { heatStatus = value; }
        }        
        public DateTime? StatusTimeStamp
        {
            get { return statusTimeStamp; }
            set { statusTimeStamp = value; }
        }        
        public DateTime? StartArTime
        {
            get { return startArTime; }
            set { startArTime = value; }
        }        
        public DateTime? EndArTime
        {
            get { return endArTime; }
            set { endArTime = value; }
        }        
        public int? ArConsumped
        {
            get { return arConsumped; }
            set { arConsumped = value; }
        }        
        public string CastNumber
        {
            get { return castNumber; }
            set { castNumber = value; }
        }        
        public int? SequenceInCast
        {
            get { return sequenceInCast; }
            set { sequenceInCast = value; }
        }        
        public double? SteelWeightLadle
        {
            get { return steelWeightLadle; }
            set { steelWeightLadle = value; }
        }        
        public double? SteelWeightTundish
        {
            get { return steelWeightTundish; }
            set { steelWeightTundish = value; }
        }        
        public DateTime? LastTemperatureDate
        {
            get { return lastTemperatureDate; }
            set { lastTemperatureDate = value; }
        }        
        public int? SteelLiquidTemperature
        {
            get { return steelLiquidTemperature; }
            set { steelLiquidTemperature = value; }
        }       
        public double? SlabWidth
        {
            get { return slabWidth; }
            set { slabWidth = value; }
        }
        #endregion

        public CCMHeatInfo() { }

        public CCMHeatInfo(decimal msgId,DateTime msgTimeStamp)
        {
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
        }

        public CCMHeatInfo(decimal msgId, DateTime msgTimeStamp, int? tundishTemperature)
        {
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
            this.tundishTemperature = tundishTemperature;
        }
    }
}
 