using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class SteelGradeDetailInfo
    {
        #region internalMembers
        private string steelGradeId;
        private string steelGradeName;
        private string steelGradeGroupCode;
        private string steelGradeGroupName;
        private string steelGradeDescr;
        private IList<FormulaInfo> formulaInfos;
        private double? liquidTemp;
        private string slagModel;
        private string argonModel;
        private int? maxDuraEachHeating;
        private int? heatingCount;
        private double? feTiAftHeating;
        private double? wireWgtAftHeating;
        private int? arDuraBefFeedWire;
        private int? arDuraAftFeedWire;
        private string routeId;
        private string routeDesc;
        private TechnicsInfo technicsInfo;
        private IList<SteelAnalysisInfo> steelAnalysisList;

        #endregion

        #region properties

        /// <summary>
        /// 钢种代码
        /// </summary>
        public string SteelGradeId
        {
            get { return this.steelGradeId; }
            set { this.steelGradeId = value; }
        }

        /// <summary>
        /// 钢种名称
        /// </summary>
        public string SteelGradeName
        {
            get { return this.steelGradeName; }
            set { this.steelGradeName = value; }
        }
        
        /// <summary>
        /// 钢种组代码
        /// </summary>
        public string SteelGradeGroupCode
        {
            get { return this.steelGradeGroupCode; }
            set { this.steelGradeGroupCode = value; }
        }

        /// <summary>
        /// 钢种组名称
        /// </summary>
        public string SteelGradeGroupName
        {
            get { return this.steelGradeGroupName; }
            set { this.steelGradeGroupName = value; }
        }

        /// <summary>
        /// 钢种描述
        /// </summary>
        public string SteelGradeDescr
        {
            get { return this.steelGradeDescr; }
            set { this.steelGradeDescr = value; }
        }
        
        /// <summary>
        /// 钢种碳当量公式
        /// </summary>
        public IList<FormulaInfo> FormulaInfos
        {
            get { return this.formulaInfos; }
            set { this.formulaInfos = value; }
        }

        /// <summary>
        /// 液相线温度 
        /// </summary>
        public double? LiquidTemp
        {
            get { return this.liquidTemp; }
            set { this.liquidTemp = value; }
        }
        /// <summary>
        /// 钢种所用渣模式
        /// </summary>
        public string SlagModel
        {
            get { return this.slagModel; }
            set { this.slagModel = value; }
        }
        
        /// <summary>
        /// 吹氩模式
        /// </summary>
        public string ArgonModel
        {
            get { return this.argonModel; }
            set { this.argonModel = value; }
        }

        /// <summary>
        /// 每次加热最大时间
        /// </summary>
        public int? MaxDuraEachHeating
        {
            get { return this.maxDuraEachHeating; }
            set { this.maxDuraEachHeating = value; }
        }

        /// <summary>
        /// 最大加热次数
        /// </summary>
        public int? HeatingCount
        {
            get { return this.heatingCount; }
            set { this.heatingCount = value; }
        }

        /// <summary>
        /// 加热后CaFe线喂入数量
        /// </summary>
        public double? FeTiAftHeating
        {
            get { return this.feTiAftHeating; }
            set { this.feTiAftHeating = value; }
        }

        /// <summary>
        /// 加热后喂线重量
        /// </summary>
        public double? WireWgtAftHeating
        {
            get { return this.wireWgtAftHeating; }
            set { this.wireWgtAftHeating = value; }
        }
        /// <summary>
        /// 喂线前吹氩最小时间
        /// </summary>
        public int? ArDuraBefFeedWire
        {
            get { return this.arDuraBefFeedWire; }
            set { this.arDuraBefFeedWire = value; }
        }

        /// <summary>
        /// 喂线后吹氩最小时间
        /// </summary>
        public int? ArDuraAftFeedWire
        {
            get { return this.arDuraAftFeedWire; }
            set { this.arDuraAftFeedWire = value; }
        }

        /// <summary>
        /// 路径代码
        /// </summary>
        public string RouteId
        {
            get { return this.routeId; }
            set { this.routeId = value; }
        }

        /// <summary>
        /// 路径描述
        /// </summary>
        public string RouteDesc
        {
            get { return this.routeDesc; }
            set { this.routeDesc = value; }
        }

        /// <summary>
        /// 工艺信息
        /// </summary>
        public TechnicsInfo TechnicsInfo
        {
            get { return this.technicsInfo; }
            set { this.technicsInfo = value; }
        }

        /// <summary>
        /// 钢分析信息
        /// </summary>
        public IList<SteelAnalysisInfo> SteelAnalysisList
        {
            get { return steelAnalysisList; }
            set { steelAnalysisList = value; }
        }
        #endregion

        #region methods

        public SteelGradeDetailInfo() 
        {
            this.formulaInfos = new List<FormulaInfo>();
            this.technicsInfo = new TechnicsInfo();
            this.steelAnalysisList = new List<SteelAnalysisInfo>();
        }

        public SteelGradeDetailInfo(string steelGradeId, string steelGradeName, string steelGradeGroupCode, string steelGradeGroupName, string steelGradeDescr)
        {
            this.steelGradeDescr = steelGradeDescr;
            this.steelGradeGroupCode = steelGradeGroupCode;
            this.steelGradeGroupName = steelGradeGroupName;
            this.steelGradeId = steelGradeId;
            this.steelGradeName = steelGradeName;
        }

        /// <summary>
        /// 不带钢种公式信息 且没有钢种分析信息的构造函数
        /// </summary>
        public SteelGradeDetailInfo(string steelGradeId, string steelGradeName, string steelGradeGroupCode, string steelGradeGroupName, string steelGradeDescr, double? liquidTemp, string slagModel, string argonModel, int? maxDuraEachHeating, int? heatingCount, double? feTiAftHeating, double? wireWgtAftHeating, int? arDuraBefFeedWire, int? arDuraAftFeedWire, string routeId, string routeDesc, TechnicsInfo technicsInfo)
        {
            this.technicsInfo = new TechnicsInfo();
            this.steelGradeId = steelGradeId;
            this.steelGradeName = steelGradeName;
            this.steelGradeGroupCode = steelGradeGroupCode;
            this.steelGradeGroupName = steelGradeGroupName;
            this.steelGradeDescr = steelGradeDescr;
            this.liquidTemp = liquidTemp;
            this.slagModel = slagModel;
            this.argonModel = argonModel;
            this.maxDuraEachHeating = maxDuraEachHeating;
            this.heatingCount = heatingCount;
            this.feTiAftHeating = feTiAftHeating;
            this.wireWgtAftHeating = wireWgtAftHeating;
            this.arDuraBefFeedWire = arDuraBefFeedWire;
            this.arDuraAftFeedWire = arDuraAftFeedWire;
            this.routeId = routeId;
            this.routeDesc = routeDesc;
            this.technicsInfo = technicsInfo;
        }

        /// <summary>
        /// 不带钢种分析信息的构造函数
        /// </summary>
        public SteelGradeDetailInfo(string steelGradeId, string steelGradeName, string steelGradeGroupCode, string steelGradeGroupName, string steelGradeDescr, IList<FormulaInfo> formulaInfos, double? liquidTemp, string slagModel, string argonModel, int? maxDuraEachHeating, int? heatingCount, double? feTiAftHeating, double? wireWgtAftHeating, int? arDuraBefFeedWire, int? arDuraAftFeedWire, string routeId, string routeDesc, TechnicsInfo technicsInfo)
        {
            this.formulaInfos = new List<FormulaInfo>();
            this.technicsInfo = new TechnicsInfo();
            this.steelGradeId = steelGradeId;
            this.steelGradeName = steelGradeName;
            this.steelGradeGroupCode = steelGradeGroupCode;
            this.steelGradeGroupName = steelGradeGroupName;
            this.steelGradeDescr = steelGradeDescr;
            this.formulaInfos = formulaInfos;
            this.liquidTemp = liquidTemp;
            this.slagModel = slagModel;
            this.argonModel = argonModel;
            this.maxDuraEachHeating = maxDuraEachHeating;
            this.heatingCount = heatingCount;
            this.feTiAftHeating = feTiAftHeating;
            this.wireWgtAftHeating = wireWgtAftHeating;
            this.arDuraBefFeedWire = arDuraBefFeedWire;
            this.arDuraAftFeedWire = arDuraAftFeedWire;
            this.routeId = routeId;
            this.routeDesc = routeDesc;
            this.technicsInfo = technicsInfo;
        }
        /// <summary>
        /// 带钢种分析信息的构造函数
        /// </summary>
        public SteelGradeDetailInfo(string steelGradeId, string steelGradeName, string steelGradeGroupCode, string steelGradeGroupName, string steelGradeDescr, IList<FormulaInfo> formulaInfos, double? liquidTemp, string slagModel, string argonModel, int? maxDuraEachHeating, int? heatingCount, double? feTiAftHeating, double? wireWgtAftHeating, int? arDuraBefFeedWire, int? arDuraAftFeedWire, string routeId, string routeDesc, TechnicsInfo technicsInfo, IList<SteelAnalysisInfo> steelAnalysisList)
        {
            this.formulaInfos = new List<FormulaInfo>();
            this.technicsInfo = new TechnicsInfo();
            this.steelAnalysisList = new List<SteelAnalysisInfo>();
            this.steelGradeId = steelGradeId;
            this.steelGradeName = steelGradeName;
            this.steelGradeGroupCode = steelGradeGroupCode;
            this.steelGradeGroupName = steelGradeGroupName;
            this.steelGradeDescr = steelGradeDescr;
            this.formulaInfos = formulaInfos;
            this.liquidTemp = liquidTemp;
            this.slagModel = slagModel;
            this.argonModel = argonModel;
            this.maxDuraEachHeating = maxDuraEachHeating;
            this.heatingCount = heatingCount;
            this.feTiAftHeating = feTiAftHeating;
            this.wireWgtAftHeating = wireWgtAftHeating;
            this.arDuraBefFeedWire = arDuraBefFeedWire;
            this.arDuraAftFeedWire = arDuraAftFeedWire;
            this.routeId = routeId;
            this.routeDesc = routeDesc;
            this.technicsInfo = technicsInfo;
            this.steelAnalysisList = steelAnalysisList;
        }
        #endregion
    }
}
