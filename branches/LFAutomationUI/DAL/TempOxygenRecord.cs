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
    public class TempOxygenRecord : ITempOxygenRecord
    {
        #region SQL AND PARAM
        private const string SQL_SELECT_TEMPERATURE_RECORD = @" SELECT T1.MSG_ID,
                                                                       T1.MSG_TIME_STAMP,
                                                                       T1.HEAT_ID,
                                                                       T1.TREATMENT_COUNT,
                                                                       T2.CAR,
                                                                       LF_BLL.FUN_GET_TREATMENT_STATION AS TREATMENT_STATION,
                                                                       LF_BLL.FUN_GET_STATION_ID        AS STATION_ID,
                                                                       T1.TEMPERATURE_DATA,
                                                                       T1.OXYGEN_DATA,
                                                                       T1.POWER_DURATION,
                                                                       T1.POWER_CONSUMPTION
                                                                  FROM TB_TEMP_OXYGEN_RECORD T1
                                                                  LEFT JOIN TB_LF_HEAT_INFO T2
                                                                    ON T1.HEAT_ID = T2.HEAT_ID
                                                                   AND T1.TREATMENT_COUNT = T2.TREATMENT_COUNT
                                                                ORDER BY MSG_TIME_STAMP DESC";

        private const string SQL_SELECT_TEMPOXYGEN_BY_HEAT_ID = @"SELECT T1.MSG_ID,
                                                                       T1.MSG_TIME_STAMP,
                                                                       T1.HEAT_ID,
                                                                       T1.TREATMENT_COUNT,
                                                                       T2.CAR,
                                                                       LF_BLL.FUN_GET_TREATMENT_STATION AS TREATMENT_STATION,
                                                                       LF_BLL.FUN_GET_STATION_ID        AS STATION_ID,
                                                                       T1.TEMPERATURE_DATA,
                                                                       T1.OXYGEN_DATA,
                                                                       T1.POWER_DURATION,
                                                                       T1.POWER_CONSUMPTION
                                                                  FROM TB_TEMP_OXYGEN_RECORD T1
                                                                  LEFT JOIN TB_LF_HEAT_INFO T2
                                                                    ON T1.HEAT_ID = T2.HEAT_ID
                                                                  WHERE T1.HEAT_ID=:HEAT_ID
                                                                ORDER BY MSG_TIME_STAMP ";

        private const string SQL_SELECT_TEMPOXYGEN_BY_HEAT_ID_AND_TREACNT = @"SELECT T1.MSG_ID,
                                                                                   T1.MSG_TIME_STAMP,
                                                                                   T1.HEAT_ID,
                                                                                   T1.TREATMENT_COUNT,
                                                                                   T2.CAR,
                                                                                   LF_BLL.FUN_GET_TREATMENT_STATION AS TREATMENT_STATION,
                                                                                   LF_BLL.FUN_GET_STATION_ID        AS STATION_ID,
                                                                                   T1.TEMPERATURE_DATA,
                                                                                   T1.OXYGEN_DATA,
                                                                                   T1.POWER_DURATION,
                                                                                   T1.POWER_CONSUMPTION
                                                                              FROM TB_TEMP_OXYGEN_RECORD T1
                                                                              LEFT JOIN TB_LF_HEAT_INFO T2
                                                                                ON T1.HEAT_ID = T2.HEAT_ID
                                                                               AND T1.TREATMENT_COUNT = T2.TREATMENT_COUNT
                                                                            WHERE T1.HEAT_ID=:HEAT_ID AND T1.TREATMENT_COUNT=:TREATMENT_COUNT
                                                                            ORDER BY MSG_TIME_STAMP";

        private const string SQL_SELECT_TEMPOXYGEN_BY_DATE = @"SELECT T1.MSG_ID,
                                                                       T1.MSG_TIME_STAMP,
                                                                       T1.HEAT_ID,
                                                                       T1.TREATMENT_COUNT,
                                                                       T2.CAR,
                                                                       LF_BLL.FUN_GET_TREATMENT_STATION AS TREATMENT_STATION,
                                                                       LF_BLL.FUN_GET_STATION_ID        AS STATION_ID,
                                                                       T1.TEMPERATURE_DATA,
                                                                       T1.OXYGEN_DATA,
                                                                       T1.POWER_DURATION,
                                                                       T1.POWER_CONSUMPTION
                                                                  FROM TB_TEMP_OXYGEN_RECORD T1
                                                                  LEFT JOIN TB_LF_HEAT_INFO T2
                                                                    ON T1.HEAT_ID = T2.HEAT_ID
                                                                   AND T1.TREATMENT_COUNT = T2.TREATMENT_COUNT
                                                                WHERE T1.MSG_TIME_STAMP > :START_DATE AND T1.MSG_TIME_STAMP < :END_DATE
                                                                ORDER BY MSG_TIME_STAMP DESC ";
        private const string PARAM_HEAT_ID = ":HEAT_ID";
        private const string PARAM_TREATMENT_COUNT = ":TREATMENT_COUNT";
        private const string PARAM_START_DATE = ":START_DATE";
        private const string PARAM_END_DATE = ":END_DATE";
        #endregion

        #region Methods

        /// <summary>
        /// 取出所有的测温记录
        /// </summary>
        /// <returns>所有测温记录</returns>
        public IList<TempOxygenRecordInfo> GetTempOxygenRecord()
        {
            IList<TempOxygenRecordInfo> temperatureRecordinfo = new List<TempOxygenRecordInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_TEMPERATURE_RECORD, null))
            {
                while (odr.Read())
                {
                    decimal msgId = Convert.ToDecimal(odr["MSG_ID"]);
                    DateTime? msgTimeStamp = new Nullable<DateTime>(Convert.ToDateTime(odr["MSG_TIME_STAMP"]));
                    string heatId = odr["HEAT_ID"].ToString();
                    int treatmentCount = Convert.ToInt32(odr["TREATMENT_COUNT"]);
                    int car = Convert.ToInt32(odr["CAR"]);
                    string treatmentStation = odr["TREATMENT_STATION"].ToString();
                    int? stationId = Convert.ToInt32(odr["STATION_ID"]);
                    double? temperatureData = odr["TEMPERATURE_DATA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["TEMPERATURE_DATA"]));
                    double? oxygenData = odr["OXYGEN_DATA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["OXYGEN_DATA"]));
                    int? powerDuration = odr["POWER_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["POWER_DURATION"]));
                    int? powerConsumption = odr["POWER_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["POWER_CONSUMPTION"]));
                    TempOxygenRecordInfo temperatureRecord = new TempOxygenRecordInfo(msgId, msgTimeStamp, heatId, treatmentCount, car,
                                                treatmentStation, stationId, temperatureData, oxygenData, powerDuration, powerConsumption);
                    temperatureRecordinfo.Add(temperatureRecord);
                }
            }
            return temperatureRecordinfo;
        }

        /// <summary>
        /// 根据炉次号查询测温测氧记录
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>测温测氧记录</returns>
        public IList<TempOxygenRecordInfo> GetTempOxygenRecord(string heatId)
        {
            OracleParameter param = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param.Value = heatId;
            IList<TempOxygenRecordInfo> tempOxygenRecordinfo = new List<TempOxygenRecordInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_TEMPOXYGEN_BY_HEAT_ID, param))
            {
                while (odr.Read())
                {
                    decimal msgId = Convert.ToDecimal(odr["MSG_ID"]);
                    DateTime? msgTimeStamp = new Nullable<DateTime>(Convert.ToDateTime(odr["MSG_TIME_STAMP"]));
                    int treatmentCount = Convert.ToInt32(odr["TREATMENT_COUNT"]);
                    int car = Convert.ToInt32(odr["CAR"]);
                    string treatmentStation = odr["TREATMENT_STATION"].ToString();
                    int? stationId = Convert.ToInt32(odr["STATION_ID"]);
                    double? temperatureData = odr["TEMPERATURE_DATA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["TEMPERATURE_DATA"]));
                    double? oxygenData = odr["OXYGEN_DATA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["OXYGEN_DATA"]));
                    int? powerDuration = odr["POWER_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["POWER_DURATION"]));
                    int? powerConsumption = odr["POWER_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["POWER_CONSUMPTION"]));
                    TempOxygenRecordInfo temperatureRecord = new TempOxygenRecordInfo(msgId, msgTimeStamp, heatId, treatmentCount, car,
                                                treatmentStation, stationId, temperatureData, oxygenData, powerDuration, powerConsumption);
                    tempOxygenRecordinfo.Add(temperatureRecord);
                }
            }
            return tempOxygenRecordinfo;
        }

        /// <summary>
        /// 根据炉次号和冶炼次数查询测温测氧记录
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">冶炼次数</param>
        /// <returns>测温测氧记录</returns>
        public IList<TempOxygenRecordInfo> GetTempOxygenRecord(string heatId, int treatmentCount)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = heatId;
            param[1] = new OracleParameter(PARAM_TREATMENT_COUNT, OracleType.Number);
            param[1].Value = treatmentCount;
            IList<TempOxygenRecordInfo> temperatureRecordinfo = new List<TempOxygenRecordInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_TEMPOXYGEN_BY_HEAT_ID_AND_TREACNT, param))
            {
                while (odr.Read())
                {
                    decimal msgId = Convert.ToDecimal(odr["MSG_ID"]);
                    DateTime? msgTimeStamp = new Nullable<DateTime>(Convert.ToDateTime(odr["MSG_TIME_STAMP"]));
                    int car = Convert.ToInt32(odr["CAR"]);
                    string treatmentStation = odr["TREATMENT_STATION"].ToString();
                    int? stationId = Convert.ToInt32(odr["STATION_ID"]);
                    double? temperatureData = odr["TEMPERATURE_DATA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["TEMPERATURE_DATA"]));
                    double? oxygenData = odr["OXYGEN_DATA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["OXYGEN_DATA"]));
                    int? powerDuration = odr["POWER_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["POWER_DURATION"]));
                    int? powerConsumption = odr["POWER_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["POWER_CONSUMPTION"]));
                    TempOxygenRecordInfo temperatureRecord = new TempOxygenRecordInfo(msgId, msgTimeStamp, heatId, treatmentCount, car,
                                                treatmentStation, stationId, temperatureData, oxygenData, powerDuration, powerConsumption);
                    temperatureRecordinfo.Add(temperatureRecord);
                }
            }
            return temperatureRecordinfo;
        }

        /// <summary>
        /// 根据起始日期和结束日期获取测温测氧记录
        /// </summary>
        /// <param name="startDate">起始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>测温测氧记录</returns>
        public IList<TempOxygenRecordInfo> GetTempOxygenRecord(DateTime startDate, DateTime endDate)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_START_DATE, OracleType.DateTime);
            param[0].Value = startDate;
            param[1] = new OracleParameter(PARAM_END_DATE, OracleType.DateTime);
            param[1].Value = endDate;
            IList<TempOxygenRecordInfo> temperatureRecordinfo = new List<TempOxygenRecordInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_TEMPOXYGEN_BY_DATE, param))
            {
                while (odr.Read())
                {
                    decimal msgId = Convert.ToDecimal(odr["MSG_ID"]);
                    DateTime? msgTimeStamp = new Nullable<DateTime>(Convert.ToDateTime(odr["MSG_TIME_STAMP"]));
                    string heatId = odr["HEAT_ID"].ToString();
                    int treatmentCount = Convert.ToInt32(odr["TREATMENT_COUNT"]);
                    int car = Convert.ToInt32(odr["CAR"]);
                    string treatmentStation = odr["TREATMENT_STATION"].ToString();
                    int? stationId = Convert.ToInt32(odr["STATION_ID"]);
                    double? temperatureData = odr["TEMPERATURE_DATA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["TEMPERATURE_DATA"]));
                    double? oxygenData = odr["OXYGEN_DATA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["OXYGEN_DATA"]));
                    int? powerDuration = odr["POWER_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["POWER_DURATION"]));
                    int? powerConsumption = odr["POWER_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["POWER_CONSUMPTION"]));
                    TempOxygenRecordInfo temperatureRecord = new TempOxygenRecordInfo(msgId, msgTimeStamp, heatId, treatmentCount, car,
                                                treatmentStation, stationId, temperatureData, oxygenData, powerDuration, powerConsumption);
                    temperatureRecordinfo.Add(temperatureRecord);
                }
            }
            return temperatureRecordinfo;
        }

        #endregion

    }
}
