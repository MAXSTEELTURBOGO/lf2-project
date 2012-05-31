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
    public class CCMSlabReport : ICCMSlabReport
    {

        #region SQL AND PARAMS

        private const string SQL_SELECT_CCM_SLAB_REPORT_BY_HEAT_ID = @"SELECT MSG_ID,
                                                                               MSG_TIME_STAMP,
                                                                               SLAB_ID,
                                                                               HEAT_ID,
                                                                               SLAB_THICKNESS,
                                                                               SLAB_LENGTH,
                                                                               SLAB_WIDTH,
                                                                               STEEL_GRADE_ID,
                                                                               SAMPLE_CUT,
                                                                               DECODE(PRODUCT_TYPE,
                                                                                      1,
                                                                                      'SLAB HEAD',
                                                                                      2,
                                                                                      'SLAB TAIL',
                                                                                      3,
                                                                                      'SLABCROP',
                                                                                      4,
                                                                                      'SLAB',
                                                                                      NULL) AS PRODUCT_TYPE,
                                                                               CALCULATED_SLAB_WEIGHT,
                                                                               SLAB_WEIGHT,
                                                                               TO_DATE(CUTTING_TIME,'YYYYMMDDHH24MISS') AS CUTTING_TIME,
                                                                               CUTTING_POSITION,
                                                                               DESTINATION,
                                                                               SLAB_SEQENCE,
                                                                               INITIAL_WIDTH,
                                                                               FINAL_WITH,
                                                                               WIDTH_CHANGE_OFFSET,
                                                                               WIDTH_CHANGE_RATE,
                                                                               SLAB_TYPE,
                                                                               OPERATION
                                                                          FROM TB_CCM_SLAB_REPORT
                                                                         WHERE HEAT_ID = :HEAT_ID";
        private const string PARAM_HEAT_ID = ":HEAT_ID";
        #endregion

        /// <summary>
        /// 通过炉次号获取CCM板坯报告
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>板坯报告</returns>
        public IList<CCMSlabReportInfo> GetCCMSlabReport(string heatId)
        {
            IList<CCMSlabReportInfo> ccmSlabReportList = new List<CCMSlabReportInfo>();
            OracleParameter param = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param.Value = heatId;

            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_CCM_SLAB_REPORT_BY_HEAT_ID, param))
            {
                while (odr.Read())
                {
                    CCMSlabReportInfo ccmSlabReport = new CCMSlabReportInfo();
                    ccmSlabReport.MsgId = Convert.ToDecimal(odr["MSG_ID"]);
                    ccmSlabReport.MsgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    ccmSlabReport.SlabId = odr["SLAB_ID"].ToString();
                    ccmSlabReport.HeatId = odr["HEAT_ID"].ToString();
                    ccmSlabReport.SteelGradeId = odr["STEEL_GRADE_ID"].ToString();
                    ccmSlabReport.SlabThickness = odr["SLAB_THICKNESS"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["SLAB_THICKNESS"]));
                    ccmSlabReport.SlabLength = odr["SLAB_LENGTH"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["SLAB_LENGTH"]));
                    ccmSlabReport.SlabWidth = odr["SLAB_WIDTH"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["SLAB_WIDTH"]));
                    ccmSlabReport.SampleCut = odr["SAMPLE_CUT"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["SAMPLE_CUT"]));
                    ccmSlabReport.ProductType = odr["PRODUCT_TYPE"].ToString();
                    ccmSlabReport.CalculatedSlabWeight = odr["CALCULATED_SLAB_WEIGHT"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["CALCULATED_SLAB_WEIGHT"]));
                    ccmSlabReport.SlabWeight = odr["SLAB_WEIGHT"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["SLAB_WEIGHT"]));
                    ccmSlabReport.CuttingTime = odr["CUTTING_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["CUTTING_TIME"]));
                    ccmSlabReport.CuttingPosition = odr["CUTTING_POSITION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["CUTTING_POSITION"]));
                    ccmSlabReport.Destination = odr["DESTINATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["DESTINATION"]));
                    ccmSlabReport.SlabSequence = odr["SLAB_SEQENCE"].ToString();
                    ccmSlabReport.SlabInitialWidth = odr["INITIAL_WIDTH"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["INITIAL_WIDTH"]));
                    ccmSlabReport.SlabFinalWidth = odr["FINAL_WITH"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["FINAL_WITH"]));
                    ccmSlabReport.WidthChangeOffset = odr["WIDTH_CHANGE_OFFSET"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["WIDTH_CHANGE_OFFSET"]));
                    ccmSlabReport.WidthChangeRate = odr["WIDTH_CHANGE_RATE"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["WIDTH_CHANGE_RATE"]));
                    ccmSlabReport.SlabType = odr["SLAB_TYPE"].ToString();
                    ccmSlabReportList.Add(ccmSlabReport);
                }
            }
            return ccmSlabReportList;
        }
    }
}
