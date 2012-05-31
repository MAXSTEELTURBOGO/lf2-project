using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using LFAutomationUI.DBUtility;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.DAL
{
    public class TempEstimateBasic : ITempEstimateBasic
    {
        private string SQL_GET_ALL_TEMP_BASIC_INFO = @"SELECT T.INFO_NAME, T.INFO_VALUE, T.INFO_DESC
                                                        FROM TB_TEMP_PREDICTION_BASIC_INFO T";
        private string SQL_UPD_TEMP_ESTIMATE_BASIC_INFO = @"UPDATE TB_TEMP_PREDICTION_BASIC_INFO T
                                                               SET T.INFO_VALUE = :INFO_VALUE
                                                             WHERE T.INFO_NAME = :INFO_NAME";
        private string PARAM_INFO_VALUE = ":INFO_VALUE";
        private string PARAM_INFO_NAME = ":INFO_NAME";

        /// <summary>
        /// 获取所有的温度预估基础信息
        /// </summary>
        /// <returns>温度预估基础信息</returns>
        public IList<TempEstimateBasicInfo> GetTempEstimateBasic()
        {
            IList<TempEstimateBasicInfo> tempEstimateBasicList = new List<TempEstimateBasicInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_GET_ALL_TEMP_BASIC_INFO, null))
            {
                while (odr.Read())
                {
                    TempEstimateBasicInfo tempEstimateInfo = new TempEstimateBasicInfo();
                    tempEstimateInfo.InfoName = odr["INFO_NAME"].ToString();
                    tempEstimateInfo.InfoValue = odr["INFO_VALUE"].ToString();
                    tempEstimateInfo.InfoDesc = odr["INFO_DESC"].ToString();
                    tempEstimateBasicList.Add(tempEstimateInfo);
                }
            }
            return tempEstimateBasicList;
        }
        /// <summary>
        /// 更新温度预估基础信息
        /// </summary>
        /// <param name="tempEstBasicInfo"></param>
        public void UpdateTempEstimateBasic(TempEstimateBasicInfo tempEstBasicInfo)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_INFO_VALUE, tempEstBasicInfo.InfoValue);
            param[1] = new OracleParameter(PARAM_INFO_NAME, tempEstBasicInfo.InfoName);
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_UPD_TEMP_ESTIMATE_BASIC_INFO, param);
        }
    }
}
