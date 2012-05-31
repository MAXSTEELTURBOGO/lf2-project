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
    public class PowerOnRecord : IPowerOnRecord
    {
        #region SQL AND PARAM

        private const string SQL_SELECT_ALL_POWER_ON_RECORD = @"SELECT V.HEAT_ID,
                                                                       V.TREATMENT_COUNT,
                                                                       V.CAR,
                                                                       V.TREATMENT_STATION,
                                                                       V.STATION_ID,
                                                                       V.START_POWER_TIME,
                                                                       V.END_POWER_TIME,
                                                                       V.POWER_CONSUMPTION
                                                                  FROM V_POWERON_RECORD V
                                                                ORDER BY V.START_POWER_TIME DESC";

        private const string SQL_SELECT_POWER_ON_RECORD_BY_HEAT_ID = @"SELECT  V.HEAT_ID,
                                                                               V.TREATMENT_COUNT,
                                                                               V.CAR,
                                                                               V.TREATMENT_STATION,
                                                                               V.STATION_ID,
                                                                               V.START_POWER_TIME,
                                                                               V.END_POWER_TIME,
                                                                               V.POWER_CONSUMPTION
                                                                          FROM V_POWERON_RECORD V
                                                                        WHERE V.HEAT_ID=:HEAT_ID
                                                                        ORDER BY V.START_POWER_TIME";

        private const string SQL_SELECT_POWER_ON_RECORD_BY_HEAT_ID_AND_TREACNT = @"SELECT  V.HEAT_ID,
                                                                                           V.TREATMENT_COUNT,
                                                                                           V.CAR,
                                                                                           V.TREATMENT_STATION,
                                                                                           V.STATION_ID,
                                                                                           V.START_POWER_TIME,
                                                                                           V.END_POWER_TIME,
                                                                                           V.POWER_CONSUMPTION
                                                                                      FROM V_POWERON_RECORD V
                                                                                    WHERE V.HEAT_ID=:HEAT_ID AND V.TREATMENT_COUNT=:TREATMENT_COUNT
                                                                                    ORDER BY V.START_POWER_TIME";

        private const string SQL_SELECT_POWER_ON_RECORD_BY_DATE = @"SELECT V.HEAT_ID,
                                                                           V.TREATMENT_COUNT,
                                                                           V.CAR,
                                                                           V.TREATMENT_STATION,
                                                                           V.STATION_ID,
                                                                           V.START_POWER_TIME,
                                                                           V.END_POWER_TIME,
                                                                           V.POWER_CONSUMPTION
                                                                      FROM V_POWERON_RECORD V
                                                                    WHERE V.START_POWER_TIME > :START_DATE AND V.START_POWER_TIME < :END_DATE
                                                                    ORDER BY V.START_POWER_TIME DESC";
        private const string PARAM_HEAT_ID = ":HEAT_ID";
        private const string PARAM_TREATMENT_COUNT = ":TREATMENT_COUNT";
        private const string PARAM_START_DATE = ":START_DATE";
        private const string PARAM_END_DATE = ":END_DATE";

        #endregion

        #region methods

        /// <summary>
        /// 取出通电记录中所有的记录
        /// </summary>
        /// <returns></returns>
        public IList<PowerOnRecordInfo> GetPowerOnRecord()
        {
            IList<PowerOnRecordInfo> powerOnRecordInfo = new List<PowerOnRecordInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_ALL_POWER_ON_RECORD, null))
            {
                while (odr.Read())
                {
                    PowerOnRecordInfo powerOnRecord = new PowerOnRecordInfo();
                    powerOnRecord.HeatId = odr["HEAT_ID"].ToString();
                    powerOnRecord.TreatmentCount = Convert.ToInt16(odr["TREATMENT_COUNT"]);
                    powerOnRecord.Car = Convert.ToInt16(odr["CAR"]);
                    powerOnRecord.TreatmentStation = odr["TREATMENT_STATION"].ToString();
                    powerOnRecord.StationId = Convert.ToInt32(odr["STATION_ID"]);
                    powerOnRecord.StartPowerOnTime = Convert.ToDateTime(odr["START_POWER_TIME"]);
                    powerOnRecord.EndPowerOnTime = Convert.ToDateTime(odr["END_POWER_TIME"]);
                    powerOnRecord.PowerConsumption = Convert.ToDouble(odr["POWER_CONSUMPTION"]);
                    powerOnRecordInfo.Add(powerOnRecord);
                }
            }
            return powerOnRecordInfo;
        }

        /// <summary>
        /// 根据炉次号获取通电记录
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>通电记录</returns>
        public IList<PowerOnRecordInfo> GetPowerOnRecord(string heatId)
        {
            OracleParameter param = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param.Value = heatId;
            IList<PowerOnRecordInfo> powerOnRecordInfo = new List<PowerOnRecordInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_POWER_ON_RECORD_BY_HEAT_ID, param))
            {
                while (odr.Read())
                {
                    PowerOnRecordInfo powerOnRecord = new PowerOnRecordInfo();
                    powerOnRecord.HeatId = heatId;
                    powerOnRecord.TreatmentCount = Convert.ToInt16(odr["TREATMENT_COUNT"]);
                    powerOnRecord.Car = Convert.ToInt16(odr["CAR"]);
                    powerOnRecord.TreatmentStation = odr["TREATMENT_STATION"].ToString();
                    powerOnRecord.StationId = Convert.ToInt32(odr["STATION_ID"]);
                    powerOnRecord.StartPowerOnTime = Convert.ToDateTime(odr["START_POWER_TIME"]);
                    powerOnRecord.EndPowerOnTime = Convert.ToDateTime(odr["END_POWER_TIME"]);
                    powerOnRecord.PowerConsumption = Convert.ToDouble(odr["POWER_CONSUMPTION"]);
                    powerOnRecordInfo.Add(powerOnRecord);
                }
            }
            return powerOnRecordInfo;
        }

        /// <summary>
        /// 根据炉次号和冶炼次数获取通电信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">冶炼次数</param>
        /// <returns>通电记录</returns>
        public IList<PowerOnRecordInfo> GetPowerOnRecord(string heatId, int treatmentCount)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = heatId;
            param[1] = new OracleParameter(PARAM_TREATMENT_COUNT, OracleType.Number);
            param[1].Value = treatmentCount;
            IList<PowerOnRecordInfo> powerOnRecordInfo = new List<PowerOnRecordInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_POWER_ON_RECORD_BY_HEAT_ID_AND_TREACNT, param))
            {
                while (odr.Read())
                {
                    PowerOnRecordInfo powerOnRecord = new PowerOnRecordInfo();
                    powerOnRecord.HeatId = heatId;
                    powerOnRecord.TreatmentCount = treatmentCount;
                    powerOnRecord.Car = Convert.ToInt16(odr["CAR"]);
                    powerOnRecord.TreatmentStation = odr["TREATMENT_STATION"].ToString();
                    powerOnRecord.StationId = Convert.ToInt32(odr["STATION_ID"]);
                    powerOnRecord.StartPowerOnTime = Convert.ToDateTime(odr["START_POWER_TIME"]);
                    powerOnRecord.EndPowerOnTime = Convert.ToDateTime(odr["END_POWER_TIME"]);
                    powerOnRecord.PowerConsumption = Convert.ToDouble(odr["POWER_CONSUMPTION"]);
                    powerOnRecordInfo.Add(powerOnRecord);
                }
            }
            return powerOnRecordInfo;
        }

        /// <summary>
        /// 根据日期选取通电记录
        /// </summary>
        /// <param name="startDate">起始日期</param>
        /// <param name="endDate">终止日期</param>
        /// <returns>通电记录</returns>
        public IList<PowerOnRecordInfo> GetPowerOnRecord(DateTime startDate, DateTime endDate)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_START_DATE, OracleType.DateTime);
            param[0].Value = startDate;
            param[1] = new OracleParameter(PARAM_END_DATE, OracleType.DateTime);
            param[1].Value = endDate;
            IList<PowerOnRecordInfo> powerOnRecordInfo = new List<PowerOnRecordInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_POWER_ON_RECORD_BY_DATE, param))
            {
                while (odr.Read())
                {
                    PowerOnRecordInfo powerOnRecord = new PowerOnRecordInfo();
                    powerOnRecord.HeatId = odr["HEAT_ID"].ToString();
                    powerOnRecord.TreatmentCount = Convert.ToInt16(odr["TREATMENT_COUNT"]);
                    powerOnRecord.Car = Convert.ToInt16(odr["CAR"]);
                    powerOnRecord.TreatmentStation = odr["TREATMENT_STATION"].ToString();
                    powerOnRecord.StationId = Convert.ToInt32(odr["STATION_ID"]);
                    powerOnRecord.StartPowerOnTime = Convert.ToDateTime(odr["START_POWER_TIME"]);
                    powerOnRecord.EndPowerOnTime = Convert.ToDateTime(odr["END_POWER_TIME"]);
                    powerOnRecord.PowerConsumption = Convert.ToDouble(odr["POWER_CONSUMPTION"]);
                    powerOnRecordInfo.Add(powerOnRecord);
                }
            }
            return powerOnRecordInfo;
        }

        #endregion
    }
}
