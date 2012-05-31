using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class CCMSlabReportInfo
    {
        #region Internal members

        private decimal msgId;
        private DateTime msgTimeStamp;
        private string heatId;
        private string steelGradeId;
        private string slabId;
        private int? slabThickness;
        private int? slabLength;
        private int? slabWidth;
        private int? sampleCut;
        private string productType;
        private int? calculatedSlabWeight;
        private int? slabWeight;
        private DateTime? cuttingTime;
        private int? cuttingPosition;
        private int? destination;
        private string slabSequence;
        private int? slabInitialWidth;
        private int? slabFinalWidth;
        private int? widthChangeOffset;
        private int? widthChangeRate;
        private string slabType;
        
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
        /// 钢种号
        /// </summary>
        public string SteelGradeId
        {
            get { return steelGradeId; }
            set { steelGradeId = value; }
        }

        /// <summary>
        /// 二级板坯序号
        /// </summary>
        public string SlabId
        {
            get { return slabId; }
            set { slabId = value; }
        }
        
        /// <summary>
        /// 板坯厚度mm
        /// </summary>
        public int? SlabThickness
        {
            get { return slabThickness; }
            set { slabThickness = value; }
        }

        /// <summary>
        /// 板坯长度mm
        /// </summary>
        public int? SlabLength
        {
            get { return slabLength; }
            set { slabLength = value; }
        }

        /// <summary>
        /// 前端宽度mm
        /// </summary>
        public int? SlabWidth
        {
            get { return slabWidth; }
            set { slabWidth = value; }
        }

        /// <summary>
        /// 取样切割
        /// </summary>
        public int? SampleCut
        {
            get { return sampleCut; }
            set { sampleCut = value; }
        }

        /// <summary>
        /// 类型
        /// </summary>
        public string ProductType
        {
            get { return productType; }
            set { productType = value; }
        }

        /// <summary>
        /// 板坯計算重量
        /// </summary>
        public int? CalculatedSlabWeight
        {
            get { return calculatedSlabWeight; }
            set { calculatedSlabWeight = value; }
        }

        /// <summary>
        /// 板坯重量
        /// </summary>
        public int? SlabWeight
        {
            get { return slabWeight; }
            set { slabWeight = value; }
        }

        /// <summary>
        /// 切割时间
        /// </summary>
        public DateTime? CuttingTime
        {
            get { return cuttingTime; }
            set { cuttingTime = value; }
        }

        /// <summary>
        /// 切割位置
        /// </summary>
        public int? CuttingPosition
        {
            get { return cuttingPosition; }
            set { cuttingPosition = value; }
        }

        /// <summary>
        /// 是否二切
        /// </summary>
        public int? Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        /// <summary>
        /// 二级板坯号
        /// </summary>
        public string SlabSequence
        {
            get { return slabSequence; }
            set { slabSequence = value; }
        }

        /// <summary>
        /// SLAB INITIAL WIDTH
        /// </summary>
        public int? SlabInitialWidth
        {
            get { return slabInitialWidth; }
            set { slabInitialWidth = value; }
        }

        /// <summary>
        /// SLAB FINAL WIDTH
        /// </summary>
        public int? SlabFinalWidth
        {
            get { return slabFinalWidth; }
            set { slabFinalWidth = value; }
        }

        /// <summary>
        /// SLAB WIDTH CHANGE OFFSET
        /// </summary>
        public int? WidthChangeOffset
        {
            get { return widthChangeOffset; }
            set { widthChangeOffset = value; }
        }

        /// <summary>
        /// SLAB WIDTH CHANGE RATE
        /// </summary>
        public int? WidthChangeRate
        {
            get { return widthChangeRate; }
            set { widthChangeRate = value; }
        }

        /// <summary>
        /// Mother Slab or Daughter Slab
        /// </summary>
        public string SlabType
        {
            get { return slabType; }
            set { slabType = value; }
        }

        #endregion

        #region Methods

        public CCMSlabReportInfo() 
        { }

        #endregion
    }
}
