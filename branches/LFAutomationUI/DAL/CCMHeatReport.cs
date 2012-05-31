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
    public class CCMHeatReport : ICCMHeatReport
    {
        #region SQL AND PARAMS

        private const string SQL_SELECT_CCM_HEAT_REPORT_BY_HEAT_ID = @"SELECT MSG_ID,
                                                                               MSG_TIME_STAMP,
                                                                               HEAT_ID,
                                                                               STEEL_GRADE_ID,
                                                                               CAST_NUMBER,
                                                                               SEQUENCE_IN_CAST,
                                                                               POURED_WEIGHT,
                                                                               CAST_WEIGHT,
                                                                               LADLE_TEMP_START,
                                                                               TUNDISH_MIN_WGT,
                                                                               MD_LEVEL_MAX,
                                                                               MD_LEVEL_MIN,
                                                                               SLAB_TOT_LTH,
                                                                               CAST_S_LTH,
                                                                               CAST_E_LTH,
                                                                               CAST_T_LTH,
                                                                               FLUID_TMP,
                                                                               MD_FRICTION,
                                                                               TUN_MIN_WGT,
                                                                               AR_FLOW_SHROUD,
                                                                               AR_FLOW_STOPPER,
                                                                               AR_FLOW_SEALING,
                                                                               AR_FLOW_UPNOZZLE,
                                                                               ALARM_POSITION,
                                                                               ALARM_TIME,
                                                                               SKULL_WGT,
                                                                               LD_ARV_WGT,
                                                                               LD_DEP_WGT,
                                                                               MD_SET_LEVEL
                                                                          FROM TB_CCM_HEAT_REPORT
                                                                          WHERE HEAT_ID=:HEAT_ID";
        private const string PARAM_HEAT_ID = ":HEAT_ID";
        #endregion



        /// <summary>
        /// 通过炉次号获取CCM炉次报告
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>炉次报告</returns>
        public CCMHeatReportInfo GetCCMHeatReport(string heatId)
        {
            CCMHeatReportInfo ccmHeatReport = null;
            OracleParameter param = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param.Value = heatId;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_CCM_HEAT_REPORT_BY_HEAT_ID, param))
            {
                if (odr.Read())
                {
                    ccmHeatReport = new CCMHeatReportInfo();
                    ccmHeatReport.MsgId = Convert.ToDecimal(odr["MSG_ID"]);
                    ccmHeatReport.MsgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    ccmHeatReport.HeatId = odr["HEAT_ID"].ToString();
                    ccmHeatReport.SteelGradeId = odr["STEEL_GRADE_ID"].ToString();
                    ccmHeatReport.CastNo = odr["CAST_NUMBER"].ToString();
                    ccmHeatReport.SequenceInCast = odr["SEQUENCE_IN_CAST"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["SEQUENCE_IN_CAST"]));
                    ccmHeatReport.PouredWeight = odr["POURED_WEIGHT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["POURED_WEIGHT"]));
                    ccmHeatReport.CastWeight = odr["CAST_WEIGHT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["CAST_WEIGHT"]));
                    ccmHeatReport.LadleTempStart = odr["LADLE_TEMP_START"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["LADLE_TEMP_START"]));
                    ccmHeatReport.TundishMinWeight = odr["TUNDISH_MIN_WGT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["TUNDISH_MIN_WGT"]));
                    ccmHeatReport.MoldLevelMax = odr["MD_LEVEL_MAX"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["MD_LEVEL_MAX"]));
                    ccmHeatReport.MoldLevelMin = odr["MD_LEVEL_MIN"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["MD_LEVEL_MIN"]));
                    ccmHeatReport.SlabTotalLength = odr["SLAB_TOT_LTH"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["SLAB_TOT_LTH"]));
                    ccmHeatReport.CastStartLength = odr["CAST_S_LTH"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["CAST_S_LTH"]));
                    ccmHeatReport.CastEndLength = odr["CAST_E_LTH"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["CAST_E_LTH"]));
                    ccmHeatReport.CastTotalLength = odr["CAST_T_LTH"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["CAST_T_LTH"]));
                    ccmHeatReport.FluidTemperature = odr["FLUID_TMP"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["FLUID_TMP"]));
                    ccmHeatReport.MoldFriction = odr["MD_FRICTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["MD_FRICTION"]));
                    ccmHeatReport.ArFlowShroud = odr["AR_FLOW_SHROUD"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["AR_FLOW_SHROUD"]));
                    ccmHeatReport.ArFlowStopper = odr["AR_FLOW_STOPPER"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["AR_FLOW_STOPPER"]));
                    ccmHeatReport.ArFlowSealing = odr["AR_FLOW_SEALING"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["AR_FLOW_SEALING"]));
                    ccmHeatReport.ArFlowUpnozzle = odr["AR_FLOW_UPNOZZLE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["AR_FLOW_UPNOZZLE"]));
                    ccmHeatReport.AlarmPosition = odr["ALARM_POSITION"].ToString();
                    ccmHeatReport.AlarmTime = odr["ALARM_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["ALARM_TIME"]));
                    ccmHeatReport.SkullWeight = odr["SKULL_WGT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["SKULL_WGT"]));
                    ccmHeatReport.LadleArrivalWeight = odr["LD_ARV_WGT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["LD_ARV_WGT"]));
                    ccmHeatReport.LadleDepartWeight = odr["LD_DEP_WGT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["LD_DEP_WGT"]));
                    ccmHeatReport.MoldFriction = odr["MD_FRICTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["MD_FRICTION"]));
                    ccmHeatReport.MoldSetLevel = odr["MD_SET_LEVEL"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["MD_SET_LEVEL"]));
                }
            }
            return ccmHeatReport;
        }
    }
}
