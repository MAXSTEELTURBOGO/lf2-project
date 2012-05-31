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
    public class TempEstimateCoeffic : ITempEstimateCoeffic
    {
        private const string SQL_GET_TEMP_ESTIMATE_COEFFICIENT = @"SELECT T.COEFFICIENT_NAME,
                                                                       T.COEFFICIENT_VALUE,
                                                                       T.COEFFICIENT_MODIFIED_VALUE,
                                                                       T.COEFFICIENT_DESC
                                                                  FROM TB_ESTIMATE_TEMP_COEFFIC_INFO T";
        private const string SQL_UPDATE_TEMP_ESTIMATE_COEFFIC = @"UPDATE TB_ESTIMATE_TEMP_COEFFIC_INFO T
                                                                    SET T.COEFFICIENT_MODIFIED_VALUE=:COEFFIC_MODIFY_VALUE
                                                                    WHERE T.COEFFICIENT_NAME=:COEFFICIENT_NAME";
        private const string PARAM_COEFFIC_MODIFY_VALUE = ":COEFFIC_MODIFY_VALUE";
        private const string PARAM_COEFFICIENT_NAME = ":COEFFICIENT_NAME";

        /// <summary>
        /// 获取温度预估计算系数
        /// </summary>
        /// <returns>预估计算系数</returns>
        public IList<TempEstimateCoefficInfo> GetTempEstimateCoeffic()
        {
            IList<TempEstimateCoefficInfo> tempEstimateCoefficList = new List<TempEstimateCoefficInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_GET_TEMP_ESTIMATE_COEFFICIENT, null))
            {
                while (odr.Read())
                {
                    TempEstimateCoefficInfo tempEstimateCoefficInfo = new TempEstimateCoefficInfo();
                    tempEstimateCoefficInfo.CoefficientName = odr["COEFFICIENT_NAME"].ToString();
                    tempEstimateCoefficInfo.CoefficientDefaultVal = Convert.ToDouble(odr["COEFFICIENT_VALUE"]);
                    tempEstimateCoefficInfo.CoefficientModifyVal = Convert.ToDouble(odr["COEFFICIENT_MODIFIED_VALUE"]);
                    tempEstimateCoefficInfo.CoefficientDesc = odr["COEFFICIENT_DESC"].ToString();
                    tempEstimateCoefficList.Add(tempEstimateCoefficInfo);
                }
            }
            return tempEstimateCoefficList;
        }

        /// <summary>
        /// 更新温度预估系数
        /// </summary>
        /// <param name="tempEstimateCoeffic">温度预估系数信息</param>
        public void UpdateTempEstimateCoeffic(IList<TempEstimateCoefficInfo> tempEstimateCoeffic)
        {
            foreach (TempEstimateCoefficInfo item in tempEstimateCoeffic)
            {
                OracleParameter[] param = new OracleParameter[2];
                param[0] = new OracleParameter(PARAM_COEFFIC_MODIFY_VALUE, item.CoefficientModifyVal);
                param[1] = new OracleParameter(PARAM_COEFFICIENT_NAME, item.CoefficientName);
                OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_UPDATE_TEMP_ESTIMATE_COEFFIC, param);
            }
        }
    }
}
