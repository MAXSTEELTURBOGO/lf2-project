using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class BOFAdditionInfo
    {
        #region Internal members

        private decimal msgId;
        private string heatId;
        private int? treatmentStation;
        private DateTime additionTime;
        private int? stationId;
        private string materialId;
        private string materialName;
        private string materialCode;
        private double? additionAmount;
        private string additionPlace;

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
        public string HeatId
        {
            get { return heatId; }
            set { heatId = value; }
        }

        /// <summary>
        /// 处理站1 bof 2 cas
        /// </summary>
        public int? TreatmentStation
        {
            get { return treatmentStation; }
            set { treatmentStation = value; }
        }

        /// <summary>
        /// 加料时间
        /// </summary>
        public DateTime AdditionTime
        {
            get { return additionTime; }
            set { additionTime = value; }
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
        /// 物料ID
        /// </summary>
        public string MaterialId
        {
            get { return materialId; }
            set { materialId = value; }
        }

        /// <summary>
        /// 物料名称
        /// </summary>
        public string MaterialName
        {
            get { return materialName; }
            set { materialName = value; }
        }

        /// <summary>
        /// 物料代码
        /// </summary>
        public string MaterialCode
        {
            get { return materialCode; }
            set { materialCode = value; }
        }

        /// <summary>
        /// 加料量
        /// </summary>
        public double? AdditionAmount
        {
            get { return additionAmount; }
            set { additionAmount = value; }
        }

        /// <summary>
        /// 加料地点
        /// </summary>
        public string AdditionPlace
        {
            get { return additionPlace; }
            set { additionPlace = value; }
        }

        #endregion

        #region Methods

        public BOFAdditionInfo()
        { }

        #endregion

    }
}
