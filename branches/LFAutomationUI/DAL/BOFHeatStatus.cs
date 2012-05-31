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
    public class BOFHeatStatus : IBOFHeatStatus
    {
        #region SQL AND PARAMS

        private const string SQL_SELECT_BOF_CURRENT_HETA_STATUS = @"SELECT MSG_ID,
                                                                           MSG_TIME_STAMP,
                                                                           STATION_ID,       
                                                                           PLAN_ID,
                                                                           HEAT_ID,
                                                                           STEEL_GRADE_ID,
                                                                           HEAT_STATUS,
                                                                           STATUS_TIME_STAMP
                                                                      FROM V_BOF_CURRENT_HEAT_STATUS_INFO";

        private const string SQL_SELECT_BOF_HEAT_STATUS_BY_HEAT_ID = @"SELECT MSG_ID,
                                                                           MSG_TIME_STAMP,
                                                                           STATION_ID,
                                                                           PLAN_ID,
                                                                           HEAT_ID,
                                                                           STEEL_GRADE_ID,
                                                                           HEAT_STATUS,
                                                                           STATUS_TIME_STAMP
                                                                      FROM V_BOF_HEAT_STATUS_INFO V1
                                                                     WHERE V1.HEAT_ID = :HEAT_ID
                                                                     ORDER BY V1.MSG_ID";

        private const string PARAM_HEAT_ID = ":HEAT_ID";

        #endregion

        /// <summary>
        /// 获取当前BOF各站的冶炼状态信息
        /// </summary>
        /// <returns>BOF各站的冶炼状态信息</returns>
        public IList<BOFHeatStatusInfo> GetBOFCurrentHeatStatus()
        {
            IList<BOFHeatStatusInfo> currentBOFHeatStatus = new List<BOFHeatStatusInfo>();

            using (OracleDataReader odr= OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQL_SELECT_BOF_CURRENT_HETA_STATUS,null)) 
            {
                while (odr.Read())
                {
                    decimal msgId = Convert.ToDecimal(odr["MSG_ID"]);
                    DateTime msgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    int stationId = Convert.ToInt16(odr["STATION_ID"]);
                    decimal? planId = odr["PLAN_ID"] == DBNull.Value ? null : new Nullable<decimal>(Convert.ToDecimal(odr["PLAN_ID"]));
                    string heatId = odr["HEAT_ID"].ToString();
                    string steelGradeId = odr["STEEL_GRADE_ID"].ToString();
                    string heatStatus = odr["HEAT_STATUS"].ToString();
                    DateTime statusTimeStamp = Convert.ToDateTime(odr["STATUS_TIME_STAMP"]);

                    BOFHeatStatusInfo bofHeatStatus = new BOFHeatStatusInfo(msgId, msgTimeStamp, stationId, planId, heatId, steelGradeId, heatStatus, statusTimeStamp);
                    currentBOFHeatStatus.Add(bofHeatStatus);
                }
            }
            return currentBOFHeatStatus;
        }

        /// <summary>
        /// 根据炉次号获取炉次状态信息列表
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>BOF炉次状态列表</returns>
        public IList<BOFHeatStatusInfo> GetBOFHeatStatusList(string heatId)
        {
            IList<BOFHeatStatusInfo> bofHeatStatusList = new List<BOFHeatStatusInfo>();
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = heatId;
            using (OracleDataReader odr= OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQL_SELECT_BOF_HEAT_STATUS_BY_HEAT_ID,param))
            {
                while(odr.Read())
                {
                    decimal msgId = Convert.ToDecimal(odr["MSG_ID"]);
                    DateTime msgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    int stationId = Convert.ToInt16(odr["STATION_ID"]);
                    decimal? planId = odr["PLAN_ID"] == DBNull.Value ? null : new Nullable<decimal>(Convert.ToDecimal(odr["PLAN_ID"]));
                    string steelGradeId = odr["STEEL_GRADE_ID"].ToString();
                    string heatStatus = odr["HEAT_STATUS"].ToString();
                    DateTime statusTimeStamp = Convert.ToDateTime(odr["STATUS_TIME_STAMP"]);

                    BOFHeatStatusInfo bofHeatStatus = new BOFHeatStatusInfo(msgId, msgTimeStamp, stationId, planId, heatId, steelGradeId, heatStatus, statusTimeStamp);
                    bofHeatStatusList.Add(bofHeatStatus);
                }
            }
            return bofHeatStatusList;
        }
    }
}
