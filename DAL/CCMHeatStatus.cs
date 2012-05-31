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
    public class CCMHeatStatus : ICCMHeatStatus
    {

        #region SQL AND PARAMS

        private const string SQL_SELECT_CCM_HEAT_STATUS_BY_HEAT_ID = @"SELECT MSG_ID,
                                                                               HEAT_ID,
                                                                               TREATMENT_STATION,
                                                                               STATION_ID,
                                                                               DECODE(HEAT_STATUS,
                                                                                      1,
                                                                                      '钢包到达时刻',
                                                                                      2,
                                                                                      '钢包浇铸开始时刻',
                                                                                      3,
                                                                                      '钢包浇铸结束时刻',
                                                                                      4,
                                                                                      '中包浇铸开始时刻',
                                                                                      5,
                                                                                      '中包浇铸结束时刻',
                                                                                      6,
                                                                                      '钢包离开时刻',
                                                                                      7,
                                                                                      '最后一支板坯切割',
                                                                                      NULL) AS HEAT_STATUS,
                                                                               STATUS_TIME_STAMP,
                                                                               CASTER_ID,
                                                                               STEEL_GRADE_ID
                                                                          FROM TB_CCM_STATUS
                                                                         WHERE HEAT_ID = :HEAT_ID";

        private const string PARAM_HEAT_ID = ":HEAT_ID";

        #endregion


        /// <summary>
        /// 通过炉次号获取CCM炉次状态
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>炉次状态</returns>
        public IList<CCMHeatStatusInfo> GetCCMHeatStatus(string heatId)
        {
            IList<CCMHeatStatusInfo> ccmHeatStatusList = new List<CCMHeatStatusInfo>();
            OracleParameter param = new OracleParameter(PARAM_HEAT_ID,OracleType.VarChar);
            param.Value = heatId;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_CCM_HEAT_STATUS_BY_HEAT_ID, param))
            {
                while (odr.Read())
                {
                    CCMHeatStatusInfo ccmHeatStatus = new CCMHeatStatusInfo();
                    ccmHeatStatus.MsgId = Convert.ToDecimal(odr["MSG_ID"]);
                    ccmHeatStatus.HeatId = odr["HEAT_ID"].ToString();
                    ccmHeatStatus.CCMId = odr["TREATMENT_STATION"].ToString();
                    ccmHeatStatus.StationId = odr["STATION_ID"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt16(odr["STATION_ID"]));
                    ccmHeatStatus.HeatStatus = odr["HEAT_STATUS"].ToString();
                    ccmHeatStatus.StatusTimeStamp = odr["STATUS_TIME_STAMP"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["STATUS_TIME_STAMP"]));
                    ccmHeatStatus.CasterId = odr["CASTER_ID"].ToString();
                    ccmHeatStatus.SteelGradeId = odr["STEEL_GRADE_ID"].ToString();    
                    ccmHeatStatusList.Add(ccmHeatStatus);
                }
            }

            return ccmHeatStatusList;
        }
    }
}
