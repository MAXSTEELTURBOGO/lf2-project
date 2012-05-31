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
    public class BOFAddition : IBOFAddition
    {
        #region SQL AND PARAMS

        private const string SQL_SELECT_BOF_ADDITION_RECORD_BY_HEAT_ID = @"SELECT MSG_ID,
                                                                                   HEAT_ID,
                                                                                   TREATMENT_STATION,
                                                                                   ADDITION_TIME,
                                                                                   STATION_ID,
                                                                                   ADDITION_MATERIAL_ID,
                                                                                   T2.CN_NAME AS ADDITION_MATERIAL_NAME,
                                                                                   ADDITION_MATERIAL_CODE,
                                                                                   ADDITION_AMOUNT,
                                                                                   ADDITION_PLACE
                                                                              FROM TB_BOF_ADDITION_INFO T1
                                                                                    LEFT JOIN TB_LIBRARY_EN_CN_INFO T2
                                                                                    ON T1.ADDITION_MATERIAL_NAME = T2.EN_NAME
                                                                                WHERE HEAT_ID = :HEAT_ID
                                                                                   ORDER BY MSG_ID";
        private const string SQL_SELECT_BOF_ADDITION_STATISTIC_BY_HEAT_ID = @"SELECT HEAT_ID,
                                                                                       ADDITION_MATERIAL_CODE,
                                                                                       T2.CN_NAME AS ADDITION_MATERIAL_NAME,
                                                                                       SUM_AMOUNT
                                                                                  FROM (SELECT HEAT_ID,
                                                                                               ADDITION_MATERIAL_CODE,
                                                                                               ADDITION_MATERIAL_NAME,
                                                                                               SUM(ADDITION_AMOUNT) AS SUM_AMOUNT
                                                                                          FROM TB_BOF_ADDITION_INFO
                                                                                         GROUP BY HEAT_ID, ADDITION_MATERIAL_CODE, ADDITION_MATERIAL_NAME
                                                                                        HAVING HEAT_ID = :HEAT_ID) T1
                                                                                  LEFT JOIN TB_LIBRARY_EN_CN_INFO T2
                                                                                    ON T1.ADDITION_MATERIAL_NAME = T2.EN_NAME";

        private const string PARAM_HEAT_ID = ":HEAT_ID";

        #endregion


        /// <summary>
        /// 根据炉次号获取BOF加料记录信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>BOF加料记录</returns>
        public IList<BOFAdditionInfo> GetBOFAdditionRecord(string heatId)
        {
            IList<BOFAdditionInfo> bofAdditionList = new List<BOFAdditionInfo>();

            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = heatId;

            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_BOF_ADDITION_RECORD_BY_HEAT_ID, param))
            {
                while (odr.Read())
                {
                    BOFAdditionInfo bofAddition = new BOFAdditionInfo();
                    bofAddition.MsgId = Convert.ToDecimal(odr["MSG_ID"]);
                    bofAddition.HeatId = heatId;
                    bofAddition.TreatmentStation = odr["TREATMENT_STATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt16(odr["TREATMENT_STATION"]));
                    bofAddition.AdditionTime = Convert.ToDateTime(odr["ADDITION_TIME"]);
                    bofAddition.StationId = odr["STATION_ID"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt16(odr["STATION_ID"]));
                    bofAddition.MaterialId = odr["ADDITION_MATERIAL_ID"].ToString();
                    bofAddition.MaterialName = odr["ADDITION_MATERIAL_NAME"].ToString();
                    bofAddition.MaterialCode = odr["ADDITION_MATERIAL_CODE"].ToString();
                    bofAddition.AdditionAmount = odr["ADDITION_AMOUNT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ADDITION_AMOUNT"]));
                    bofAddition.AdditionPlace = odr["ADDITION_PLACE"].ToString();
                    bofAdditionList.Add(bofAddition);
                }
            }
            return bofAdditionList;
        }


        /// <summary>
        /// 根据炉次号获取BOF加料统计信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns></returns>
        public IList<BOFAdditionInfo> GetBOFAdditionStatistic(string heatId)
        {
            IList<BOFAdditionInfo> bofAdditionList = new List<BOFAdditionInfo>();

            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = heatId;

            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_BOF_ADDITION_STATISTIC_BY_HEAT_ID, param))
            {
                while (odr.Read())
                {
                    BOFAdditionInfo bofAddition = new BOFAdditionInfo();
                    bofAddition.HeatId = heatId;
                    bofAddition.MaterialCode = odr["ADDITION_MATERIAL_CODE"].ToString();
                    bofAddition.MaterialName = odr["ADDITION_MATERIAL_NAME"].ToString();
                    bofAddition.AdditionAmount = odr["SUM_AMOUNT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["SUM_AMOUNT"]));
                    bofAdditionList.Add(bofAddition);
                }
            }
            return bofAdditionList;
        }
    }
}
