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
    public class RHHeatStatus : IRHHeatStatus
    {
        #region SQL&&PARAM
        private const string SQL_SELECT_CURRENT_RH_HEAT_STATUS = @"select * from v_rh_current_heat_status_info";
        private const string SQL_SELECT_RH_HEAT_STATUS_BY_HEAT_ID = @"SELECT T.MSG_ID,
                                                                           T.MSG_TIME_STAMP,
                                                                           T.MSG_INFO,
                                                                           T.AGGREGATE_NAME,
                                                                           T.STATION_ID,
                                                                           T.HEAT_ID,
                                                                           T.HEAT_TREATMENT_COUNTER,
                                                                           T.CALC_TEMP,
                                                                           T.HEAT_STATUS,
                                                                           T.STATUS_TIME_STAMP
                                                                      FROM V_RH_HEAT_STATUS_INFO T
                                                                    WHERE T.HEAT_ID = :HEAT_ID";
        private const string PARAM_HEAT_ID = ":HEAT_ID";
        #endregion

        #region IRHHeatStatus 成员
        /// <summary>
        /// 获取当前RH状态信息
        /// </summary>
        /// <returns>当前RH状态信息</returns>
        public IList<RHHeatStatusInfo> GetCurrentRHHeatStatusInfo()
        {
            IList<RHHeatStatusInfo> currentRHHeatStatusList = new List<RHHeatStatusInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_CURRENT_RH_HEAT_STATUS, null))
            {
                while (odr.Read())
                {
                    decimal msgId = Convert.ToDecimal(odr["MSG_ID"]);
                    DateTime? msgTimeStamp = odr["MSG_TIME_STAMP"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["MSG_TIME_STAMP"]));
                    int stationId = Convert.ToInt32(odr["STATION_ID"]);
                    string heatId = odr["HEAT_ID"].ToString();
                    string heatStatus = odr["HEAT_STATUS"].ToString();
                    DateTime? statusTimeStamp = odr["STATUS_TIME_STAMP"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["STATUS_TIME_STAMP"]));
                    RHHeatStatusInfo currentRHHeatStatus = new RHHeatStatusInfo(msgId, msgTimeStamp, stationId, heatId, heatStatus, statusTimeStamp);
                    currentRHHeatStatusList.Add(currentRHHeatStatus);
                }
            }
            return currentRHHeatStatusList;
        }

        /// <summary>
        /// 按照炉次号获取RH状态信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>RH状态信息</returns>
        public IList<RHHeatStatusInfo> GetRHHeatStatusInfo(string heatId)
        {
            IList<RHHeatStatusInfo> currentRHHeatStatusList = new List<RHHeatStatusInfo>();
            OracleParameter param = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param.Value = heatId;
            using (OracleDataReader odr=OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQL_SELECT_RH_HEAT_STATUS_BY_HEAT_ID,param))
            {
                while (odr.Read())
                {
                    decimal msgId = Convert.ToDecimal(odr["MSG_ID"]);
                    DateTime? msgTimeStamp = odr["MSG_TIME_STAMP"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["MSG_TIME_STAMP"]));
                    int stationId = Convert.ToInt32(odr["STATION_ID"]);
                    string heatStatus = odr["HEAT_STATUS"].ToString();
                    DateTime? statusTimeStamp = odr["STATUS_TIME_STAMP"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["STATUS_TIME_STAMP"]));
                    RHHeatStatusInfo currentRHHeatStatus = new RHHeatStatusInfo(msgId, msgTimeStamp, stationId, heatId, heatStatus, statusTimeStamp);
                    currentRHHeatStatusList.Add(currentRHHeatStatus);
                }
            }
            return currentRHHeatStatusList;
        }

        #endregion
    }
}
