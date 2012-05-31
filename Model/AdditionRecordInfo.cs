using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class AdditionRecordInfo
    {
        #region Interal Members

        private string heatId;
        private int treatmentCount;
        private string steelGradeId;
        private int car;
        private string className;
        private string operatorName;
        private string treatmentStation;
        private int? stationId;
        private DateTime? additionTime;
        private int? siloId;
        private decimal? additionMaterialId;
        private string materialL3Id;
        private string materialName;
        private string materialType;
        private double? additionAmount;
        private string note;

        #endregion

        #region properties

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
        /// 钢种号
        /// </summary>
        public string SteelGradeId
        {
            get { return steelGradeId; }
            set { steelGradeId = value; }
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
        /// 班组名称
        /// </summary>
        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }
        /// <summary>
        /// 操作员名称
        /// </summary>
        public string OperatorName
        {
            get { return operatorName; }
            set { operatorName = value; }
        }
        /// <summary>
        /// 处理站名称
        /// </summary>
        public string TreatmentStation
        {
            get { return treatmentStation; }
            set { treatmentStation = value; }
        }

        public string AdditionType
        {
            get
            {
                return this.siloId.HasValue ? "料仓料" : (this.note == "m" ? "喂丝" : "手投料");
            }
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
        /// 加料时间
        /// </summary>
        public DateTime? AdditionTime
        {
            get { return this.additionTime; }
            set { this.additionTime = value; }
        }
        /// <summary>
        /// 料仓号
        /// </summary>
        public int? SiloId
        {
            get { return this.siloId; }
            set { this.siloId = value; }
        }
        /// <summary>
        /// 加入物料ID
        /// </summary>
        public decimal? AdditionMaterialId
        {
            get { return this.additionMaterialId; }
            set { this.additionMaterialId = value; }
        }
        /// <summary>
        /// 加入物料的三级代码
        /// </summary>
        public string MaterialL3Id
        {
            get { return materialL3Id; }
            set { materialL3Id = value; }
        }
        /// <summary>
        /// 加入物料名称
        /// </summary>
        public string MaterialName
        {
            get { return this.materialName; }
            set { this.materialName = value; }
        }
        /// <summary>
        /// 加入物料类型
        /// </summary>
        public string MaterialType
        {
            get { return this.materialType; }
            set { this.materialType = value; }
        }
        /// <summary>
        /// 加料重量
        /// </summary>
        public double? AdditionAmount
        {
            get { return this.additionAmount; }
            set { this.additionAmount = value; }
        }
        /// <summary>
        /// 加入物料单位
        /// </summary>
        public string Note
        {
            get { return this.note; }
            set { this.note = value; }
        }
        #endregion

        #region method

        public AdditionRecordInfo() { }

        public AdditionRecordInfo(string materialName, double? additionAmount)
        {
            this.materialName = materialName;
            this.additionAmount = additionAmount;
        }

        public AdditionRecordInfo(string heatId, int treatmentCount, string steelGradeId, int car, string treatmentStation, int? stationId, DateTime? additionTime, int? siloId, decimal? additionMaterialId, string materialL3Id, string materialName, string materialType, double? additionAmount, string note)
        {
            this.heatId = heatId;
            this.treatmentCount = treatmentCount;
            this.steelGradeId = steelGradeId;
            this.car = car;
            this.treatmentStation = treatmentStation;
            this.stationId = stationId;
            this.additionTime = additionTime;
            this.siloId = siloId;
            this.additionMaterialId = additionMaterialId;
            this.materialL3Id = materialL3Id;
            this.MaterialName = materialName;
            this.materialType = materialType;
            this.additionAmount = additionAmount;
            this.note = note;
        }
        public AdditionRecordInfo(string heatId, int treatmentCount, string steelGradeId, int car, string className, string operatorName, string treatmentStation, int? stationId, DateTime? additionTime, int? siloId, decimal? additionMaterialId, string materialL3Id, string materialName, string materialType, double? additionAmount, string note)
        {
            this.heatId = heatId;
            this.treatmentCount = treatmentCount;
            this.steelGradeId = steelGradeId;
            this.car = car;
            this.className = className;
            this.operatorName = operatorName;
            this.treatmentStation = treatmentStation;
            this.stationId = stationId;
            this.additionTime = additionTime;
            this.siloId = siloId;
            this.additionMaterialId = additionMaterialId;
            this.materialL3Id = materialL3Id;
            this.MaterialName = materialName;
            this.materialType = materialType;
            this.additionAmount = additionAmount;
            this.note = note;
        }
        #endregion
    }
}
