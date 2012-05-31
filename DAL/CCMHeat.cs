using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using LFAutomationUI.Model;
using LFAutomationUI.DBUtility;
using LFAutomationUI.IDAL;

namespace LFAutomationUI.DAL
{
    public class CCMHeat : ICCMHeat
    {
        #region Internal Members
        private const string SQL_SELECT_CCM_HEAT_INFO = @"SELECT MSG_ID,
                                                               MSG_TIME_STAMP,
                                                               STEEL_GRADE_NAME,
                                                               STEEL_GRADE_ID,
                                                               LADLE_WEIGHT,
                                                               TUNDISH_WEIGHT,
                                                               CASTING_SPEED,
                                                               TOTAL_LENGTH,
                                                               CAST_TOTAL_TIME,
                                                               CAST_REMAIN_TIME,
                                                               HEAT_ID,
                                                               TUNDISH_TEMPERATURE,
                                                               CCM_ID,
                                                               HEAT_STATUS,
                                                               STATUS_TIME_STAMP,
                                                               START_AR_TIME,
                                                               END_AR_TIME,
                                                               AR_CONSUMED,
                                                               CAST_NUMBER,
                                                               SEQUENCE_IN_CAST,
                                                               STEEL_WEIGHT_LADLE,
                                                               STEEL_WEIGHT_TUNDISH,
                                                               LAST_TEMPERATURE_DATE,
                                                               STEEL_LIQUID_TEMPERATURE,
                                                               SLAB_WIDTH
                                                            FROM V_CCM_HEAT_INFO";

        private const string SQL_SELECT_CCM_TEMP_INFO = @"SELECT *
                                                              FROM (SELECT MSG_ID, MSG_TIME_STAMP, TUNDISH_TEMPERATURE
                                                                      FROM TB_CCM_TEMPERATURE_INFO T1
                                                                     ORDER BY T1.MSG_ID DESC)
                                                             WHERE ROWNUM < 9";
        #endregion

        /// <summary>
        /// 获取CCM的炉次信息
        /// </summary>
        /// <returns>CCM炉次信息</returns>
        public CCMHeatInfo GetCCMHeatInfo()
        {
            CCMHeatInfo ccmHeatInfo = null;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_CCM_HEAT_INFO, null))
            {
                if (odr.Read())
                {
                    ccmHeatInfo = new CCMHeatInfo();
                    ccmHeatInfo.MsgId = Convert.ToDecimal(odr["MSG_ID"]);
                    ccmHeatInfo.MsgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    ccmHeatInfo.SteelGradeName = odr["STEEL_GRADE_NAME"] == DBNull.Value ? null : odr["STEEL_GRADE_NAME"].ToString();
                    ccmHeatInfo.SteelGradeId = odr["STEEL_GRADE_ID"] == DBNull.Value ? null : odr["STEEL_GRADE_ID"].ToString();
                    ccmHeatInfo.LadleWeight = odr["LADLE_WEIGHT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["LADLE_WEIGHT"]));
                    ccmHeatInfo.TundishWeight = odr["TUNDISH_WEIGHT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["TUNDISH_WEIGHT"]));
                    ccmHeatInfo.CastingSpeed = odr["CASTING_SPEED"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["CASTING_SPEED"]));
                    ccmHeatInfo.TotalLength = odr["TOTAL_LENGTH"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["TOTAL_LENGTH"]));
                    ccmHeatInfo.CastTotalTime = odr["CAST_TOTAL_TIME"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["CAST_TOTAL_TIME"]));
                    ccmHeatInfo.CastRemainTime = odr["CAST_REMAIN_TIME"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["CAST_REMAIN_TIME"]));
                    ccmHeatInfo.HeatId = odr["HEAT_ID"] == DBNull.Value ? null : odr["HEAT_ID"].ToString();
                    ccmHeatInfo.TundishTemperature = odr["TUNDISH_TEMPERATURE"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["TUNDISH_TEMPERATURE"]));
                    ccmHeatInfo.CCMId = odr["CCM_ID"] == DBNull.Value ? null : odr["CCM_ID"].ToString();
                    ccmHeatInfo.HeatStatus = odr["HEAT_STATUS"] == DBNull.Value ? null : odr["HEAT_STATUS"].ToString();
                    ccmHeatInfo.StatusTimeStamp = odr["STATUS_TIME_STAMP"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["STATUS_TIME_STAMP"]));
                    ccmHeatInfo.StartArTime = odr["START_AR_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["START_AR_TIME"]));
                    ccmHeatInfo.EndArTime = odr["END_AR_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["END_AR_TIME"]));
                    ccmHeatInfo.ArConsumped = odr["AR_CONSUMED"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["AR_CONSUMED"]));
                    ccmHeatInfo.CastNumber = odr["CAST_NUMBER"] == DBNull.Value ? null : odr["CAST_NUMBER"].ToString();
                    ccmHeatInfo.SequenceInCast = odr["SEQUENCE_IN_CAST"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["SEQUENCE_IN_CAST"]));
                    ccmHeatInfo.SteelWeightLadle = odr["STEEL_WEIGHT_LADLE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["STEEL_WEIGHT_LADLE"]));
                    ccmHeatInfo.SteelWeightTundish = odr["STEEL_WEIGHT_TUNDISH"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["STEEL_WEIGHT_TUNDISH"]));
                    ccmHeatInfo.LastTemperatureDate = odr["LAST_TEMPERATURE_DATE"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["LAST_TEMPERATURE_DATE"]));
                    ccmHeatInfo.SlabWidth = odr["SLAB_WIDTH"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["SLAB_WIDTH"]));
                }
            }
            return ccmHeatInfo;
        }

        /// <summary>
        /// 获取CCM最近的中包测温信息
        /// </summary>
        /// <returns>中包测温信息</returns>
        public IList<CCMHeatInfo> GetCCMTempInfo()
        {
            IList<CCMHeatInfo> ccmHeatInfoList = new List<CCMHeatInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_CCM_TEMP_INFO, null))
            {
                while (odr.Read())
                {
                    CCMHeatInfo ccmHeatInfo = new CCMHeatInfo();
                    ccmHeatInfo.MsgId = Convert.ToDecimal(odr["MSG_ID"]);
                    ccmHeatInfo.MsgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    ccmHeatInfo.TundishTemperature = odr["TUNDISH_TEMPERATURE"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["TUNDISH_TEMPERATURE"]));
                    ccmHeatInfoList.Add(ccmHeatInfo);
                }
            }
            return ccmHeatInfoList;
        }
    }
}
