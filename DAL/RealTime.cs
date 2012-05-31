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
    public class RealTime:IRealTime
    {
        #region SQL and PARAM

        private const string SQl_SELECT_REAL_TIME_BY_HEAT_ID = @"SELECT MSG_ID,
                                                                       MSG_TIME_STAMP,
                                                                       HEAT_ID,
                                                                       TREATMENT_COUNT,
                                                                       AR_CONSUMPTION,
                                                                       POWER_CONSUMPTION,
                                                                       A_ELECTRODE_ARC_VOLTAGE,
                                                                       B_ELECTROCE_ARC_VOLTAGE,
                                                                       C_ELECTRODE_ARC_VOLTAGE,
                                                                       A_ELECTRODE_CURRENT,
                                                                       B_ELECTRODE_CURRENT,
                                                                       C_ELECTRODE_CURRENT,
                                                                       ARGON_FLOW1,
                                                                       ARGON_FLOW2,
                                                                       ARGON_PRESSURE1,
                                                                       ARGON_PRESSURE2,
                                                                       THEORY_TEMP_DATA
                                                                  FROM TB_REALTIME_INFO
                                                                 WHERE HEAT_ID = :HEAT_ID";
        private const string SQl_SELECT_REAL_TIME_BY_HEAT_ID_AND_TREATMENT_COUNT = @"SELECT MSG_ID,
                                                                                           MSG_TIME_STAMP,
                                                                                           HEAT_ID,
                                                                                           TREATMENT_COUNT,
                                                                                           AR_CONSUMPTION,
                                                                                           POWER_CONSUMPTION,
                                                                                           A_ELECTRODE_ARC_VOLTAGE,
                                                                                           B_ELECTRODE_ARC_VOLTAGE,
                                                                                           C_ELECTRODE_ARC_VOLTAGE,
                                                                                           A_ELECTRODE_CURRENT,
                                                                                           B_ELECTRODE_CURRENT,
                                                                                           C_ELECTRODE_CURRENT,
                                                                                           ARGON_FLOW1,
                                                                                           ARGON_FLOW2,
                                                                                           ARGON_PRESSURE1,
                                                                                           ARGON_PRESSURE2,
                                                                                           THEORY_TEMP_DATA
                                                                                      FROM TB_REALTIME_INFO
                                                                                     WHERE HEAT_ID = :HEAT_ID
                                                                                       AND TREATMENT_COUNT = :TREATMENT_COUNT";

        
        private const string PARAM_HEAT_ID =":HEAT_ID";
        private const string PARAM_TREATMENT_COUNT = ":TREATMENT_COUNT";

        #endregion

        /// <summary>
        /// 通过炉次号获取实时信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>实时信息</returns>
        public IList<RealTimeInfo> GetRealTimeInfo(string heatId)
        {
            IList<RealTimeInfo> realTimeList = new List<RealTimeInfo>();
            OracleParameter param = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param.Value = heatId;


            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQl_SELECT_REAL_TIME_BY_HEAT_ID_AND_TREATMENT_COUNT, param))
            {
                while (odr.Read())
                {
                    RealTimeInfo realTime = new RealTimeInfo();
                    realTime.MsgId = Convert.ToDecimal(odr["MSG_ID"]);
                    realTime.MsgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    realTime.HeatId = odr["HEAT_ID"].ToString();
                    realTime.TreatmentCount = Convert.ToInt16(odr["TREATMENT_COUNT"]);
                    realTime.ArConsumption = odr["AR_CONSUMPTION"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["AR_CONSUMPTION"]));
                    realTime.PowerConsumption = odr["POWER_CONSUMPTION"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["POWER_CONSUMPTION"]));
                    realTime.AEAV = odr["A_ELECTRODE_ARC_VOLTAGE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["B_ELECTRODE_ARC_VOLTAGE"]));
                    realTime.BEAV = odr["B_ELECTRODE_ARC_VOLTAGE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["C_ELECTRODE_ARC_VOLTAGE"]));
                    realTime.CEAV = odr["C_ELECTRODE_ARC_VOLTAGE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["A_ELECTRODE_ARC_VOLTAGE"]));
                    realTime.AEAC = odr["A_ELECTRODE_CURRENT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["A_ELECTRODE_CURRENT"]));
                    realTime.BEAC = odr["B_ELECTRODE_CURRENT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["B_ELECTRODE_CURRENT"]));
                    realTime.CEAC = odr["C_ELECTRODE_CURRENT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["C_ELECTRODE_CURRENT"]));

                    realTime.ArgonFlow1 = odr["ARGON_FLOW1"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ARGON_FLOW1"]));
                    realTime.ArgonFlow2 = odr["ARGON_FLOW2"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ARGON_FLOW2"]));
                    realTime.ArgonPressure1 = odr["ARGON_PRESSURE1"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ARGON_PRESSURE1"]));
                    realTime.ArgonPressure2 = odr["ARGON_PRESSURE2"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ARGON_PRESSURE2"]));
                    realTime.TheoryTemp = odr["THEORY_TEMP_DATA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["THEORY_TEMP_DATA"]));
                    realTimeList.Add(realTime);
                }
            }
            return realTimeList;
        }

        /// <summary>
        /// 通过炉次号和冶炼次数获取实时信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">处理次数</param>
        /// <returns>实时信息</returns>
        public IList<RealTimeInfo> GetRealTimeInfo(string heatId, int treatmentCount)
        {
            IList<RealTimeInfo> realTimeList = new List<RealTimeInfo>();
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_HEAT_ID,OracleType.VarChar);
            param[0].Value = heatId;
            param[1] = new OracleParameter(PARAM_TREATMENT_COUNT, OracleType.Number);
            param[1].Value = treatmentCount;

            using (OracleDataReader odr= OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQl_SELECT_REAL_TIME_BY_HEAT_ID_AND_TREATMENT_COUNT,param))
            {
                while (odr.Read())
                {
                    RealTimeInfo realTime = new RealTimeInfo();
                    realTime.MsgId = Convert.ToDecimal(odr["MSG_ID"]);
                    realTime.MsgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    realTime.HeatId = odr["HEAT_ID"].ToString();
                    realTime.TreatmentCount = Convert.ToInt16(odr["TREATMENT_COUNT"]);
                    realTime.ArConsumption = odr["AR_CONSUMPTION"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["AR_CONSUMPTION"]));
                    realTime.PowerConsumption = odr["POWER_CONSUMPTION"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["POWER_CONSUMPTION"]));
                    
                    realTime.AEAV = odr["A_ELECTRODE_ARC_VOLTAGE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["A_ELECTRODE_ARC_VOLTAGE"]));
                    realTime.BEAV = odr["B_ELECTRODE_ARC_VOLTAGE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["B_ELECTRODE_ARC_VOLTAGE"]));
                    realTime.CEAV = odr["C_ELECTRODE_ARC_VOLTAGE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["C_ELECTRODE_ARC_VOLTAGE"]));
                    
                    realTime.AEAC = odr["A_ELECTRODE_CURRENT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["A_ELECTRODE_CURRENT"]));
                    realTime.BEAC = odr["B_ELECTRODE_CURRENT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["B_ELECTRODE_CURRENT"]));
                    realTime.CEAC = odr["C_ELECTRODE_CURRENT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["C_ELECTRODE_CURRENT"]));

                    realTime.ArgonFlow1 = odr["ARGON_FLOW1"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ARGON_FLOW1"]));
                    realTime.ArgonFlow2 = odr["ARGON_FLOW2"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ARGON_FLOW2"]));
                    realTime.ArgonPressure1 = odr["ARGON_PRESSURE1"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ARGON_PRESSURE1"]));
                    realTime.ArgonPressure2 = odr["ARGON_PRESSURE2"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ARGON_PRESSURE2"]));
                    realTime.TheoryTemp = odr["THEORY_TEMP_DATA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["THEORY_TEMP_DATA"]));
                    realTimeList.Add(realTime);
                }
            }
            return realTimeList;
        }
    }
}
