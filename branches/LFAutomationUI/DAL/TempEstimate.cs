using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;
using LFAutomationUI.DBUtility;

namespace LFAutomationUI.DAL
{
    public class TempEstimate : ITempEstimate
    {
        private string SQL_GET_TEMP_ESTIMATE_INFO_BY_HEAT_ID = @"SELECT  T1.HEAT_ID,
                                                                       T1.TREATMENT_COUNT,
                                                                       T1.STEEL_GRADE_ID,
                                                                       T2.LADLE_ID,
                                                                       T2.LADLE_AGE,
                                                                       T4.END_TIME AS BOF_DEPART_TEMP_TIME,
                                                                       T4.END_TEMPERATURE AS BOF_DEPART_TEMP,
                                                                       T5.LIQUID_TEMP
                                                                  FROM TB_L3_LF_PLAN T1
                                                                  LEFT JOIN TB_L3_LADLE_MSG T2
                                                                    ON T1.HEAT_ID = T2.HEAT_ID
                                                                  LEFT JOIN TB_BOF_HEAT_INFO T4
                                                                    ON T1.HEAT_ID = T4.HEAT_ID
                                                                   AND T1.TREATMENT_COUNT = 1
                                                                  LEFT JOIN TB_STEEL_INFO T5
                                                                    ON T1.STEEL_GRADE_ID = T5.STEEL_GRADE_ID
                                                                WHERE T1.HEAT_ID=:HEAT_ID AND T1.TREATMENT_COUNT=:TREATMENT_COUNT";
        private string PARAM_HEAT_ID = ":HEAT_ID";
        private string PARAM_TREATMENT_COUNT = ":TREATMENT_COUNT";

        /// <summary>
        /// 获取温度预估基础信息
        /// </summary>
        /// <returns>温度预估计算基础信息</returns>
        public TempEstimateInfo GetTempEstimate(string heatId, int treatmentCount)
        {
            TempEstimateInfo tempEstimateInfo = new TempEstimateInfo();
            OracleParameter[] param = new OracleParameter[2]; 
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = heatId;
            param[1] = new OracleParameter(PARAM_TREATMENT_COUNT, OracleType.Number);
            param[1].Value = treatmentCount;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_GET_TEMP_ESTIMATE_INFO_BY_HEAT_ID, param))
            {
                while (odr.Read())
                {
                    tempEstimateInfo.HeatId = heatId;
                    tempEstimateInfo.TreatmentCount = treatmentCount;
                    try
                    {
                        tempEstimateInfo.LadleInfo.LadleId = odr["LADLE_ID"].ToString();
                        tempEstimateInfo.LadleInfo.LadleAge =odr["LADLE_AGE"]==DBNull.Value?null:new Nullable<int>( Convert.ToInt32(odr["LADLE_AGE"]));
                    }
                    catch
                    {
                    }
                    tempEstimateInfo.LiquidTemp = odr["LIQUID_TEMP"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["LIQUID_TEMP"]));
                    tempEstimateInfo.BofDepartTempTime = odr["BOF_DEPART_TEMP_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["BOF_DEPART_TEMP_TIME"]));
                    tempEstimateInfo.BofDepartTemp = odr["BOF_DEPART_TEMP"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["BOF_DEPART_TEMP"]));
                }
            }

            TempOxygenRecord tempDAL = new TempOxygenRecord();
            tempEstimateInfo.TemperatureList = tempDAL.GetTempOxygenRecord(heatId, treatmentCount);

            TempEstimateCoeffic tempEstCoefficDAL = new TempEstimateCoeffic();
            tempEstimateInfo.CoefficientList = tempEstCoefficDAL.GetTempEstimateCoeffic();

            TempEstimateBasic tempEstBasicDAL = new TempEstimateBasic();
            tempEstimateInfo.TempEstBasicList = tempEstBasicDAL.GetTempEstimateBasic();

            Material materialDAL = new Material();
            tempEstimateInfo.MaterialList = materialDAL.GetAllMaterialInfos();

            TransformerParam transParamDAL = new TransformerParam();
            tempEstimateInfo.TransformerParamList = transParamDAL.GetAllTransFormerParamInfo();

            return tempEstimateInfo;
        }
    }
}
