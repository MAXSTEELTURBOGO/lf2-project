using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class MaterialInfo
    {
        #region internal Members

        private decimal materialId;
        private string materialL3Id;
        private string materialName;
        private MaterialTypeInfo matTypeInfo;
        private string materialDesc;
        private string materialShape;
        private string materialNote;
        private double? wireSpecWgt;
        private double? bulkSpecWgt;
        private double? chillFactor;
        private double? feContents;
        private double? yield;
        private IList<MaterialAnalysisInfo> analysisList;

        #endregion

        #region Properties
        public decimal MaterialId
        {
            get { return this.materialId; }
            set { this.materialId = value; }
        }
        public string MaterialL3Id
        {
            get { return this.materialL3Id; }
            set { this.materialL3Id = value; }
        }
        public string MaterialName
        {
            get { return this.materialName; }
            set { this.materialName = value; }
        }
        public MaterialTypeInfo MatTypeInfo
        {
            get { return this.matTypeInfo; }
            set { this.matTypeInfo = value; }
        }
        public string MaterialDesc
        {
            get { return this.materialDesc; }
            set { this.materialDesc = value; }
        }
        public string MaterialShape
        {
            get { return this.materialShape; }
            set { this.materialShape = value; }
        }
        public string MaterialNote
        {
            get { return this.materialNote; }
            set { this.materialNote = value; }
        }
        public double? WireSpecWgt
        {
            get { return this.wireSpecWgt; }
            set { this.wireSpecWgt = value; }
        }
        public double? BulkSpecWgt
        {
            get { return this.bulkSpecWgt; }
            set { this.bulkSpecWgt = value; }
        }
        public double? ChillFactor
        {
            get { return this.chillFactor; }
            set { this.chillFactor = value; }
        }
        public double? FeContents
        {
            get { return this.feContents; }
            set { this.feContents = value; }
        }
        public double? Yield
        {
            get { return this.yield; }
            set { this.yield = value; }
        }
        public IList<MaterialAnalysisInfo> AnalysisList
        {
            get { return this.analysisList; }
            set { this.analysisList = value; }
        }
        public IList<MaterialAnalysisInfo> ChiefAnalysisList
        {
            get { return (from i in this.analysisList where i.NetContent > 1 select i).ToList<MaterialAnalysisInfo>(); }
        }

        #endregion

        #region Methods
        public MaterialInfo()
        {
            this.matTypeInfo = new MaterialTypeInfo();
            this.analysisList = new List<MaterialAnalysisInfo>();
        }
        public MaterialInfo(decimal materialId, string materialL3Id, string materialName, MaterialTypeInfo matTypeInfo, string materialNote, string materialDesc, string shape, double? wireSpecWgt, double? bulkSpecWgt, double? chillFactor, double? feContents, double? yield)
        {
            this.matTypeInfo = new MaterialTypeInfo();
            this.materialId = materialId;
            this.materialDesc = materialDesc;
            this.materialL3Id = materialL3Id;
            this.materialName = materialName;
            this.matTypeInfo = matTypeInfo;
            this.materialNote = materialNote;
            this.materialShape = shape;
            this.wireSpecWgt = wireSpecWgt;
            this.bulkSpecWgt = bulkSpecWgt;
            this.chillFactor = chillFactor;
            this.feContents = feContents;
            this.yield = yield;
        }
        public MaterialInfo(decimal materialId, string materialL3Id, string materialName, MaterialTypeInfo matTypeInfo, string materialNote, string materialDesc, string shape, double? wireSpecWgt, double? bulkSpecWgt, double? chillFactor, double? feContents, double? yield, IList<MaterialAnalysisInfo> analysisInfo)
        {
            this.matTypeInfo = new MaterialTypeInfo();
            this.analysisList = new List<MaterialAnalysisInfo>();
            this.materialId = materialId;
            this.materialDesc = materialDesc;
            this.materialL3Id = materialL3Id;
            this.materialName = materialName;
            this.matTypeInfo = matTypeInfo;
            this.materialNote = materialNote;
            this.materialShape = shape;
            this.wireSpecWgt = wireSpecWgt;
            this.bulkSpecWgt = bulkSpecWgt;
            this.chillFactor = chillFactor;
            this.feContents = feContents;
            this.yield = yield;
            this.analysisList = analysisInfo;
        }
        #endregion
    }
}
