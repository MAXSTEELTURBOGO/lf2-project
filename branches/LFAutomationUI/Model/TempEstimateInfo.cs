using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class TempEstimateInfo
    {
        /// <summary>
        /// 炉次号
        /// </summary>
        private string heatId;
        public string HeatId
        {
            get { return heatId; }
            set { heatId = value; }
        }

        /// <summary>
        /// 处理次数
        /// </summary>
        private int treatmentCount;
        public int TreatmentCount
        {
            get { return treatmentCount; }
            set { treatmentCount = value; }
        }

        /// <summary>
        /// 该炉次钢水净重
        /// </summary>
        private double? steelNetWeight;
        public double? SteelNetWeight
        {
            get
            {
                if (steelNetWeight == null)
                {
                    return 0;
                }
                else
                {
                    return steelNetWeight;
                }
            }
            set { steelNetWeight = value; }
        }

        /// <summary>
        /// 钢种液相线温度
        /// </summary>
        private double? liquidTemp;
        public double? LiquidTemp
        {
            get
            {
                if (liquidTemp == null)
                {
                    return 0;
                }
                else
                {
                    return liquidTemp;
                }
            }
            set { liquidTemp = value; }
        }

        /// <summary>
        /// BOF离站温度测取时间
        /// </summary>
        private DateTime? bofDepartTempTime;
        public DateTime? BofDepartTempTime
        {
            get { return bofDepartTempTime; }
            set { bofDepartTempTime = value; }
        }

        /// <summary>
        /// BOF离站温度
        /// </summary>
        private double? bofDepartTemp;
        public double? BofDepartTemp
        {
            get
            {
                if (bofDepartTemp == 0)
                {
                    return 0;
                }
                else
                {
                    return bofDepartTemp;
                }
            }
            set { bofDepartTemp = value; }
        }

        public DateTime? LastTemperatureTime
        {
            get
            {
                if (temperatureList.Count == 0)
                {
                    if (bofDepartTemp == null)
                    {
                        return null;
                    }
                    else
                    {
                        return bofDepartTempTime;
                    }
                }
                else
                {
                    return (from i in temperatureList
                            orderby i.MsgTimeStamp descending
                            select i.MsgTimeStamp).First();
                }
            }
        }

        public double? LastTemperature
        {
            get
            {
                if (temperatureList.Count == 0)
                {
                    if (bofDepartTemp == null)
                    {
                        return 0;
                    }
                    else
                    {
                        return bofDepartTemp;
                    }
                }
                else
                {
                    return (from i in temperatureList
                            orderby i.MsgTimeStamp descending
                            select i.TemperatureData).First();
                }
            }
        }

        /// <summary>
        /// 该炉次钢包信息
        /// </summary>
        private LadleInfo ladleInfo;
        public LadleInfo LadleInfo
        {
            get { return ladleInfo; }
            set { ladleInfo = value; }
        }

        /// <summary>
        /// 该炉次测温记录
        /// </summary>
        private IList<TempOxygenRecordInfo> temperatureList;
        public IList<TempOxygenRecordInfo> TemperatureList
        {
            get { return temperatureList; }
            set { temperatureList = value; }
        }

        /// <summary>
        /// 温度预估系数信息
        /// </summary>
        private IList<TempEstimateCoefficInfo> coefficientList;
        public IList<TempEstimateCoefficInfo> CoefficientList
        {
            get { return coefficientList; }
            set { coefficientList = value; }
        }

        /// <summary>
        /// 所有物料列表信息（主要用chillFactor）
        /// </summary>
        private IList<MaterialInfo> materialList;
        public IList<MaterialInfo> MaterialList
        {
            get { return materialList; }
            set { materialList = value; }
        }

        /// <summary>
        /// 温度预估基础信息
        /// </summary>
        private IList<TempEstimateBasicInfo> tempEstBasicList;
        public IList<TempEstimateBasicInfo> TempEstBasicList
        {
            get { return tempEstBasicList; }
            set { tempEstBasicList = value; }
        }

        /// <summary>
        /// 变压器参数信息
        /// </summary>
        private IList<TransformerParamInfo> transformerParamList;
        public IList<TransformerParamInfo> TransformerParamList
        {
            get { return transformerParamList; }
            set { transformerParamList = value; }
        }

        #region Methods
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public TempEstimateInfo()
        {
            this.ladleInfo = new LadleInfo();
            this.temperatureList = new List<TempOxygenRecordInfo>();
            this.coefficientList = new List<TempEstimateCoefficInfo>();
            this.tempEstBasicList = new List<TempEstimateBasicInfo>();
            this.materialList = new List<MaterialInfo>();
            this.transformerParamList = new List<TransformerParamInfo>();
        }
        #endregion


    }
}
