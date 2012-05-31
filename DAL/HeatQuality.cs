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
    public class HeatQuality : IHeatQuality
    {

        #region internal members

        private string SQL_GET_HEAT_QUALITY_BY_HEAT_ID = @"SELECT MSG_ID,
                                                                   MSG_TIME_STAMP,
                                                                   HEAT_ID,
                                                                   TREATMENT_COUNT,
                                                                   SAMPLE_TIME,
                                                                   SAMPLE_PLACE,
                                                                   SAMPLE_NUMBER,
                                                                   ANAL_CODE,
                                                                   STATION_ID,
                                                                   T2.ELEMENT_SHORT_NAME,
                                                                   T2.ELEMENT_FULL_NAME,
                                                                   T2.ELEMENT_TYPE,
                                                                   VALUE
                                                              FROM V_QUALITY T1
                                                              LEFT JOIN TB_ELEMENT_INFO T2
                                                                ON T1.ELEMENT_NAME = T2.ELEMENT_SHORT_NAME
                                                             WHERE T1.HEAT_ID = :HEAT_ID";

        private string PARAM_HEAT_ID = ":HEAT_ID";
        private string PARAM_TREATMENT_COUNT = ":TREATMENT_COUNT";

        #endregion


        /// <summary>
        /// 获取所有化验信息
        /// </summary>
        /// <returns>所有化验信息</returns>
        public IList<HeatQualityInfo> GetAllHeatQualityInfo()
        {
            IList<HeatQualityInfo> heatQualityList = new List<HeatQualityInfo>();

            return heatQualityList;
        }

        /// <summary>
        /// 根据炉次号和处理次数获取化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>化验信息</returns>
        public IList<HeatQualityInfo> GetHeatQualityInfo(string heatId)
        {
            IList<HeatQualityInfo> heatQualityList = new List<HeatQualityInfo>();
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = heatId;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_GET_HEAT_QUALITY_BY_HEAT_ID, param))
            {
                DataTable dt = new DataTable();
                dt.Load(odr);
                if (dt.Rows.Count > 0)
                {
                    var enumHeatQualityInfo = (from i in dt.AsEnumerable()
                                               select new
                                               {
                                                   MsgId = Convert.ToDecimal(i["MSG_ID"]),
                                                   MsgTimeStamp = Convert.ToDateTime(i["MSG_TIME_STAMP"]),
                                                   HeatId = i["HEAT_ID"].ToString(),
                                                   TreatmentCount = Convert.ToInt16(i["TREATMENT_COUNT"]),
                                                   SampleTime = Convert.ToDateTime(i["SAMPLE_TIME"]),
                                                   SamplePlace = i["SAMPLE_PLACE"].ToString(),
                                                   SampleNumber = Convert.ToInt16(i["SAMPLE_NUMBER"]),
                                                   AnalCode = i["ANAL_CODE"] == DBNull.Value ? null : i["ANAL_CODE"].ToString(),
                                                   StationId = i["STATION_ID"] == DBNull.Value ? null : i["STATION_ID"].ToString()
                                               }).Distinct();
                    foreach (var heatQualityItem in enumHeatQualityInfo)
                    {
                        HeatQualityInfo heatQualityInfo = new HeatQualityInfo(heatQualityItem.MsgId, heatQualityItem.MsgTimeStamp, heatQualityItem.HeatId, heatQualityItem.TreatmentCount, heatQualityItem.SampleTime, heatQualityItem.SamplePlace, heatQualityItem.SampleNumber, heatQualityItem.AnalCode, heatQualityItem.StationId);
                        var enumQulityList = from i in dt.AsEnumerable()
                                             where Convert.ToDecimal(i["MSG_ID"]) == heatQualityItem.MsgId
                                             select new
                                             {
                                                 ElementShortName = i["ELEMENT_SHORT_NAME"].ToString() ,
                                                 ElementFullName = i["ELEMENT_FULL_NAME"].ToString(),
                                                 ElementType = i["ELEMENT_TYPE"].ToString(),
                                                 QualityValue = i["VALUE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(i["VALUE"]))
                                             };
                        IList<QualityInfo> qualityList = new List<QualityInfo>();
                        foreach (var heatQualityListItem in enumQulityList)
                        {
                            ElementInfo elem = new ElementInfo();
                            elem.ElementShortName = heatQualityListItem.ElementShortName;
                            elem.ElementFullName = heatQualityListItem.ElementFullName;
                            elem.ElementType = heatQualityListItem.ElementType;
                            QualityInfo quality = new QualityInfo(elem, heatQualityListItem.QualityValue);
                            qualityList.Add(quality);
                        }
                        heatQualityInfo.QualityList = qualityList;
                        heatQualityList.Add(heatQualityInfo);
                    }
                }
            }
            return heatQualityList;
        }


        /// <summary>
        /// 根据炉次号和处理次数获取化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">处理次数</param>
        /// <returns>化验信息</returns>
        public IList<HeatQualityInfo> GetHeatQualityInfo(string heatId, int treatmentCount)
        {
            IList<HeatQualityInfo> heatQualityList = new List<HeatQualityInfo>();

            return heatQualityList;
        }
    }
}
