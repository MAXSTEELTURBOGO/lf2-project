using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using LFAutomationUI.IDAL;
using LFAutomationUI.DBUtility;
using LFAutomationUI.Model;

namespace LFAutomationUI.DAL
{
    public class LFHeatStatus : ILFHeatStatus
    {
        #region SQL AND PARAMS

        private const string SQL_SELECT_HEAT_STATUS = @" SELECT MSG_ID,
                                                                MSG_TIME_STAMP,
                                                                HEAT_ID,
                                                                TREATMENT_COUNT,
                                                                HEAT_STATUS,
                                                                STATUS_NAME,
                                                                STATUS_TIME_STAMP,
                                                                POWER_DURATION,
                                                                POWER_CONSUMPTION,
                                                                STEEL_WEIGHT,
                                                                SLAG_WEIGHT,
                                                                TEMPERATURE_DATA
                                                                FROM V_HEAT_STATUS_DETAIL_INFO
                                                         ORDER BY MSG_TIME_STAMP DESC";
        private const string SQL_SELECT_HEAT_STATUS_BY_HEAT_ID = @" SELECT  MSG_ID,
                                                                            MSG_TIME_STAMP,
                                                                            HEAT_ID,
                                                                            TREATMENT_COUNT,
                                                                            HEAT_STATUS,
                                                                            STATUS_NAME,
                                                                            STATUS_TIME_STAMP,
                                                                            POWER_DURATION,
                                                                            POWER_CONSUMPTION,
                                                                            STEEL_WEIGHT,
                                                                            SLAG_WEIGHT,
                                                                            TEMPERATURE_DATA
                                                                            FROM V_HEAT_STATUS_DETAIL_INFO
                                                                        WHERE HEAT_ID=:HEAT_ID
                                                                     ORDER BY MSG_ID DESC";
        private const string SQL_SELECT_HEAT_STATUS_BY_HEAT_ID_AND_TREACNT = @" SELECT  MSG_ID,
                                                                                        MSG_TIME_STAMP,
                                                                                        HEAT_ID,
                                                                                        TREATMENT_COUNT,
                                                                                        HEAT_STATUS,
                                                                                        STATUS_NAME,
                                                                                        STATUS_TIME_STAMP,
                                                                                        POWER_DURATION,
                                                                                        POWER_CONSUMPTION,
                                                                                        STEEL_WEIGHT,
                                                                                        SLAG_WEIGHT,
                                                                                        TEMPERATURE_DATA
                                                                                        FROM V_HEAT_STATUS_DETAIL_INFO
                                                                                    WHERE HEAT_ID=:HEAT_ID AND TREATMENT_COUNT=:TREATMENT_COUNT
                                                                                 ORDER BY MSG_ID";
        private const string SQL_SELECT_HEAT_STATUS_BY_DATE = @" SELECT T1.MSG_ID,
                                                                       T1.MSG_TIME_STAMP,
                                                                       T1.HEAT_ID,
                                                                       T1.TREATMENT_COUNT,
                                                                       T1.HEAT_STATUS,
                                                                       DECODE(FLOOR(T1.HEAT_STATUS / 10),
                                                                              0,
                                                                              T2.STATUS_NAME,
                                                                              DECODE(FLOOR(T1.HEAT_STATUS / 100),
                                                                                     0,
                                                                                     T2.STATUS_NAME || '(第' || MOD(T1.HEAT_STATUS, 10) || '次)',
                                                                                     T2.STATUS_NAME || '(第' || MOD(T1.HEAT_STATUS, 100) || '次)')) AS STATUS_NAME,
                                                                       T1.STATUS_TIME_STAMP,
                                                                       T1.POWER_DURATION,
                                                                       T1.POWER_CONSUMPTION
                                                                  FROM TB_LF_L3_HEAT_STATUS T1
                                                                  LEFT JOIN TB_STATUS_INFO T2
                                                                    ON DECODE(FLOOR(T1.HEAT_STATUS / 10),
                                                                              0,
                                                                              T1.HEAT_STATUS,
                                                                              DECODE(FLOOR(T1.HEAT_STATUS / 100),
                                                                                     0,
                                                                                     FLOOR(T1.HEAT_STATUS / 10),
                                                                                     FLOOR(T1.HEAT_STATUS / 100))) = T2.STATUS_ID
                                                                    WHERE T1.MSG_TIME_STAMP > :START_DATE AND T1.MSG_TIME_STAMP < :END_DATE
                                                                 ORDER BY T1.MSG_ID";
        private const string PARAM_HEAT_ID = ":HEAT_ID";
        private const string PARAM_TREATMENT_COUNT = ":TREATMENT_COUNT";
        private const string PARAM_START_DATE = ":START_DATE";
        private const string PARAM_END_DATE = ":END_DATE";

        #endregion

        /// <summary>
        /// 获取所有炉次状态信息
        /// </summary>
        /// <returns>炉次状态信息</returns>
        public IList<LFHeatStatusInfo> GetLFHeatStatus()
        {
            IList<LFHeatStatusInfo> lfHeatStatusList = new List<LFHeatStatusInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_HEAT_STATUS, null))
            {
                while (odr.Read())
                {
                    LFHeatStatusInfo lfHeatStatus = new LFHeatStatusInfo();
                    lfHeatStatus.MsgId = Convert.ToDecimal(odr["MSG_ID"]);
                    lfHeatStatus.MsgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    lfHeatStatus.HeatId = odr["HEAT_ID"].ToString();
                    lfHeatStatus.TreatmentCount = Convert.ToInt16(odr["TREATMENT_COUNT"]);
                    lfHeatStatus.HeatStatus.StatusId = Convert.ToInt16(odr["HEAT_STATUS"]);
                    lfHeatStatus.HeatStatus.StatusName = odr["STATUS_NAME"].ToString();
                    lfHeatStatus.StatusTimeStamp = Convert.ToDateTime(odr["STATUS_TIME_STAMP"]);
                    lfHeatStatus.PowerDuration = odr["POWER_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["POWER_DURATION"]));
                    lfHeatStatus.PowerConsumption = odr["POWER_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["POWER_CONSUMPTION"]));
                    lfHeatStatus.SteelWeight = odr["STEEL_WEIGHT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["STEEL_WEIGHT"]));
                    lfHeatStatus.SlagWeight = odr["SLAG_WEIGHT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["SLAG_WEIGHT"]));
                    lfHeatStatus.StausTemperature = odr["TEMPERATURE_DATA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["TEMPERATURE_DATA"]));

                    lfHeatStatusList.Add(lfHeatStatus);
                }
            }

            return lfHeatStatusList;
        }

        /// <summary>
        /// 获取指定炉次列表中所有炉次的状态信息
        /// </summary>
        /// <param name="lfHeatList">炉次列表</param>
        /// <returns>炉次状态信息</returns>
        public IList<LFHeatStatusInfo> GetLFHeatStatus(IList<LFHeatInfo> lfHeatList)
        {
            IList<LFHeatStatusInfo> lfHeatStatusList = new List<LFHeatStatusInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_HEAT_STATUS, null))
            {
                DataTable dt = new DataTable();
                dt.Load(odr);
                IEnumerable<string> enumHeatId = lfHeatList.Select<LFHeatInfo, string>(i => i.HeatId);

                var enumHeatStatusList = from i in dt.AsEnumerable()
                                         where enumHeatId.Contains<string>(i["HEAT_ID"].ToString())
                                         select
                                         new
                                         {
                                             MsgId = Convert.ToDecimal(i["MSG_ID"]),
                                             MsgTimeStamp = Convert.ToDateTime(i["MSG_TIME_STAMP"]),
                                             HeatId = i["HEAT_ID"].ToString(),
                                             TreatmentCount = Convert.ToInt16(i["TREATMENT_COUNT"]),
                                             StatusId = Convert.ToInt16(i["HEAT_STATUS"]),
                                             StatusName = i["STATUS_NAME"].ToString(),
                                             StatusTimeStamp = Convert.ToDateTime(i["STATUS_TIME_STAMP"]),
                                             PowerDuration = i["POWER_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(i["POWER_DURATION"])),
                                             PowerConsumption = i["POWER_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(i["POWER_CONSUMPTION"])),
                                             SteelWeight = i["STEEL_WEIGHT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(i["STEEL_WEIGHT"])),
                                             SlagWeight = i["SLAG_WEIGHT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(i["SLAG_WEIGHT"])),
                                             StausTemperature = i["TEMPERATURE_DATA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(i["TEMPERATURE_DATA"]))
                                         };
                foreach (var item in enumHeatStatusList)
                {
                    LFHeatStatusInfo lfHeatStatus = new LFHeatStatusInfo();

                    lfHeatStatus.MsgId = item.MsgId;
                    lfHeatStatus.MsgTimeStamp = item.MsgTimeStamp;
                    lfHeatStatus.HeatId = item.HeatId;
                    lfHeatStatus.TreatmentCount = item.TreatmentCount;
                    lfHeatStatus.HeatStatus.StatusId = item.StatusId;
                    lfHeatStatus.HeatStatus.StatusName = item.StatusName;
                    lfHeatStatus.StatusTimeStamp = item.StatusTimeStamp;
                    lfHeatStatus.PowerDuration = item.PowerDuration;
                    lfHeatStatus.PowerConsumption = item.PowerConsumption;
                    lfHeatStatus.SteelWeight = item.SteelWeight;
                    lfHeatStatus.SlagWeight = item.SlagWeight;
                    lfHeatStatus.StausTemperature = item.StausTemperature;

                    lfHeatStatusList.Add(lfHeatStatus);
                }
            }

            return lfHeatStatusList;
        }

        /// <summary>
        /// 根据炉次号获取炉次状态信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>炉次冶炼状态信息</returns>
        public IList<LFHeatStatusInfo> GetLFHeatStatus(string heatId)
        {
            OracleParameter param = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param.Value = heatId;
            IList<LFHeatStatusInfo> lfHeatStatusList = new List<LFHeatStatusInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_HEAT_STATUS_BY_HEAT_ID, param))
            {
                while (odr.Read())
                {
                    LFHeatStatusInfo lfHeatStatus = new LFHeatStatusInfo();
                    lfHeatStatus.MsgId = Convert.ToDecimal(odr["MSG_ID"]);
                    lfHeatStatus.MsgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    lfHeatStatus.HeatId = odr["HEAT_ID"].ToString();
                    lfHeatStatus.TreatmentCount = Convert.ToInt16(odr["TREATMENT_COUNT"]);
                    lfHeatStatus.HeatStatus.StatusId = Convert.ToInt16(odr["HEAT_STATUS"]);
                    lfHeatStatus.HeatStatus.StatusName = odr["STATUS_NAME"].ToString();
                    lfHeatStatus.StatusTimeStamp = Convert.ToDateTime(odr["STATUS_TIME_STAMP"]);
                    lfHeatStatus.PowerDuration = odr["POWER_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["POWER_DURATION"]));
                    lfHeatStatus.PowerConsumption = odr["POWER_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["POWER_CONSUMPTION"]));
                    lfHeatStatus.SteelWeight = odr["STEEL_WEIGHT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["STEEL_WEIGHT"]));
                    lfHeatStatus.SlagWeight = odr["SLAG_WEIGHT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["SLAG_WEIGHT"]));
                    lfHeatStatus.StausTemperature = odr["TEMPERATURE_DATA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["TEMPERATURE_DATA"]));
                    lfHeatStatusList.Add(lfHeatStatus);
                }
            }
            return lfHeatStatusList;
        }

        /// <summary>
        /// 根据炉次号和冶炼次数获取炉次状态信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">冶炼次数</param>
        /// <returns>炉次冶炼状态信息</returns>
        public IList<LFHeatStatusInfo> GetLFHeatStatus(string heatId, int treatmentCount)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = heatId;
            param[1] = new OracleParameter(PARAM_TREATMENT_COUNT, OracleType.Number);
            param[1].Value = treatmentCount;
            IList<LFHeatStatusInfo> lfHeatStatusList = new List<LFHeatStatusInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_HEAT_STATUS_BY_HEAT_ID_AND_TREACNT, param))
            {
                while (odr.Read())
                {
                    LFHeatStatusInfo lfHeatStatus = new LFHeatStatusInfo();
                    lfHeatStatus.MsgId = Convert.ToDecimal(odr["MSG_ID"]);
                    lfHeatStatus.MsgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    lfHeatStatus.HeatId = odr["HEAT_ID"].ToString();
                    lfHeatStatus.TreatmentCount = Convert.ToInt16(odr["TREATMENT_COUNT"]);
                    lfHeatStatus.HeatStatus.StatusId = Convert.ToInt16(odr["HEAT_STATUS"]);
                    lfHeatStatus.HeatStatus.StatusName = odr["STATUS_NAME"].ToString();
                    lfHeatStatus.StatusTimeStamp = Convert.ToDateTime(odr["STATUS_TIME_STAMP"]);
                    lfHeatStatus.PowerDuration = odr["POWER_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["POWER_DURATION"]));
                    lfHeatStatus.PowerConsumption = odr["POWER_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["POWER_CONSUMPTION"]));
                    lfHeatStatus.SteelWeight = odr["STEEL_WEIGHT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["STEEL_WEIGHT"]));
                    lfHeatStatus.SlagWeight = odr["SLAG_WEIGHT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["SLAG_WEIGHT"]));
                    lfHeatStatus.StausTemperature = odr["TEMPERATURE_DATA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["TEMPERATURE_DATA"]));
                    lfHeatStatusList.Add(lfHeatStatus);
                }
            }
            return lfHeatStatusList;
        }

        /// <summary>
        /// 根据开始时间和结束时间查询炉次运转状况
        /// </summary>
        /// <param name="startDate">起始时间</param>
        /// <param name="endDate">终止时间</param>
        /// <returns>炉次冶炼状态信息</returns>
        public IList<LFHeatStatusInfo> GetLFHeatStatus(DateTime startDate, DateTime endDate)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_START_DATE, OracleType.DateTime);
            param[0].Value = startDate;
            param[1] = new OracleParameter(PARAM_END_DATE, OracleType.DateTime);
            param[1].Value = endDate;
            IList<LFHeatStatusInfo> lfHeatStatusList = new List<LFHeatStatusInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_HEAT_STATUS_BY_DATE, param))
            {
                while (odr.Read())
                {
                    LFHeatStatusInfo lfHeatStatus = new LFHeatStatusInfo();
                    lfHeatStatus.MsgId = Convert.ToDecimal(odr["MSG_ID"]);
                    lfHeatStatus.MsgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    lfHeatStatus.HeatId = odr["HEAT_ID"].ToString();
                    lfHeatStatus.TreatmentCount = Convert.ToInt16(odr["TREATMENT_COUNT"]);
                    lfHeatStatus.HeatStatus.StatusId = Convert.ToInt16(odr["HEAT_STATUS"]);
                    lfHeatStatus.HeatStatus.StatusName = odr["STATUS_NAME"].ToString();
                    lfHeatStatus.StatusTimeStamp = Convert.ToDateTime(odr["STATUS_TIME_STAMP"]);
                    lfHeatStatus.PowerDuration = odr["POWER_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["POWER_DURATION"]));
                    lfHeatStatus.PowerConsumption = odr["POWER_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["POWER_CONSUMPTION"]));
                    lfHeatStatusList.Add(lfHeatStatus);
                }
            }
            return lfHeatStatusList;
        }
    }
}
