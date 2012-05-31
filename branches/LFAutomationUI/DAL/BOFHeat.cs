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
    public class BOFHeat : IBOFHeat
    {

        #region SQL AND PARAMS

        private const string SQL_SELECT_BOF_HEAT_INFO_BY_HEAT_ID = @"SELECT MSG_ID,
                                                                           MSG_TIME_STAMP,
                                                                           HEAT_ID,
                                                                           STATION_NO,
                                                                           STEEL_GRADE_ID,
                                                                           START_TIME,
                                                                           END_TIME,
                                                                           END_TEMPERATURE,
                                                                           TAPPING_DURATION,
                                                                           REBLOWING,
                                                                           STEEL_NET_WEIGHT,
                                                                           HOT_METAL_WGT,
                                                                           SCRP_IN_WGT,
                                                                           OXYGEN_CONSUMPTION,
                                                                           REBLOWING_DURATION,
                                                                           TSC_TEMPERATURE,
                                                                           TSC_CARBON,
                                                                           TSO_TEMPERATURE,
                                                                           TSO_OXYGEN,
                                                                           TSO_CARBON,
                                                                           BLOW_CNT
                                                                      FROM TB_BOF_HEAT_INFO T1
                                                                     WHERE HEAT_ID = :HEAT_ID
                                                                       AND NOT EXISTS (SELECT *
                                                                              FROM TB_BOF_HEAT_INFO T2
                                                                             WHERE T1.HEAT_ID = T2.HEAT_ID
                                                                               AND T2.MSG_ID > T1.MSG_ID)";


        private const string PARAM_HEAT_ID = ":HEAT_ID";
        #endregion


        /// <summary>
        /// 通过炉次号获取BOF炉次信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>BOF炉次信息</returns>
        public BOFHeatInfo GetBOFHeatInfo(string heatId)
        {
            BOFHeatInfo bofHeat = null;
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = heatId;
            using (OracleDataReader odr= OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQL_SELECT_BOF_HEAT_INFO_BY_HEAT_ID,param))
            {
                if (odr.Read())
                {
                    bofHeat = new BOFHeatInfo();
                    bofHeat.MsgId = Convert.ToDecimal(odr["MSG_ID"]);
                    bofHeat.MsgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    bofHeat.HeatId = heatId;
                    bofHeat.StationId = odr["STATION_NO"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt16(odr["STATION_NO"]));
                    bofHeat.SteelGradeId = odr["STEEL_GRADE_ID"].ToString();
                    bofHeat.StartTime = odr["START_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["START_TIME"]));
                    bofHeat.EndTime = odr["END_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["END_TIME"]));
                    bofHeat.EndTemperature = odr["END_TEMPERATURE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["END_TEMPERATURE"]));
                    bofHeat.TappingDuration = odr["TAPPING_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt16(odr["TAPPING_DURATION"]));
                    bofHeat.IsReblowing = odr["REBLOWING"] == DBNull.Value ? null : new Nullable<bool>(Convert.ToInt16(odr["REBLOWING"])==1?true:false);
                    bofHeat.SteelNetWeight = odr["STEEL_NET_WEIGHT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["STEEL_NET_WEIGHT"]));
                    bofHeat.HotMetalWeight = odr["HOT_METAL_WGT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["HOT_METAL_WGT"]));
                    bofHeat.ScrapInWeight = odr["SCRP_IN_WGT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["SCRP_IN_WGT"]));
                    bofHeat.OxygenConsumption = odr["OXYGEN_CONSUMPTION"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["OXYGEN_CONSUMPTION"]));
                    bofHeat.ReblowingOxygenConsumption = odr["REBLOWING_DURATION"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["REBLOWING_DURATION"]));

                    bofHeat.TscCarbon = odr["TSC_CARBON"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["TSC_CARBON"]));
                    bofHeat.TscTemperature = odr["TSC_TEMPERATURE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["TSC_TEMPERATURE"]));
                    bofHeat.TsoCarbon = odr["TSO_CARBON"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["TSO_CARBON"]));
                    bofHeat.TsoTemperature = odr["TSO_TEMPERATURE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["TSO_TEMPERATURE"]));
                    bofHeat.TsoOxygen = odr["TSO_OXYGEN"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["TSO_OXYGEN"]));

                    bofHeat.BlowCount = odr["BLOW_CNT"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt16(odr["BLOW_CNT"]));
                }
            }

            return bofHeat;
        }
    }
}
