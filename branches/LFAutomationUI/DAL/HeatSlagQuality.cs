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
    public class HeatSlagQuality : IHeatSlagQuality
    {
        private const string SQL_GET_SLAG_QUALITY_BY_HEAT_ID = @"SELECT MSG_ID,
                                                                       MSG_TIME_STAMP,
                                                                       HEAT_ID,
                                                                       TREATMENT_COUNT,
                                                                       SAMPLE_TIME,
                                                                       SAMPLE_ADDR,
                                                                       SAMPLE_NUMBER,
                                                                       STATION_ID,
                                                                       T2.ELEMENT_SHORT_NAME,
                                                                       T2.ELEMENT_FULL_NAME,
                                                                       T2.ELEMENT_TYPE,
                                                                       T2.VIEW_SEQUENCE,
                                                                       VALUE
                                                                  FROM V_SLAG_QUALITY T1
                                                                  LEFT JOIN TB_ELEMENT_INFO T2
                                                                    ON T1.COMPOUND_NAME = T2.ELEMENT_SHORT_NAME
                                                                WHERE T1.HEAT_ID=:HEAT_ID";
        private const string PARAM_HEAT_ID = ":HEAT_ID";
        /// <summary>
        /// 获取所有渣料化验信息
        /// </summary>
        /// <returns>渣料化验信息</returns>
        public IList<HeatSlagQualityInfo> GetAllHeatSlagQualityInfo()
        {
            IList<HeatSlagQualityInfo> heatSlagQualityList = new List<HeatSlagQualityInfo>();

            return heatSlagQualityList;
        }

        /// <summary>
        /// 根据炉次号和处理次数获取渣料化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>渣料化验信息</returns>
        public IList<HeatSlagQualityInfo> GetHeatSlagQualityInfo(string heatId)
        {
            IList<HeatSlagQualityInfo> heatSlagQualityList = new List<HeatSlagQualityInfo>();
            OracleParameter param = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param.Value = heatId;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_GET_SLAG_QUALITY_BY_HEAT_ID, param))
            {
                DataTable dt = new DataTable();
                dt.Load(odr);
                var enumSlagQualityInfo = (from i in dt.AsEnumerable()
                                           select new
                                           {
                                               MsgId = Convert.ToDecimal(i["MSG_ID"]),
                                               MsgTimeStamp = Convert.ToDateTime(i["MSG_TIME_STAMP"]),
                                               HeatId = i["HEAT_ID"].ToString(),
                                               TreatmentCount = Convert.ToInt32(i["TREATMENT_COUNT"]),
                                               SampleTime = Convert.ToDateTime(i["SAMPLE_TIME"]),
                                               SampleAddr = i["SAMPLE_ADDR"] == DBNull.Value ? null : i["SAMPLE_ADDR"].ToString(),
                                               SampleNumber = i["SAMPLE_NUMBER"] == DBNull.Value ? null : new Nullable<Int32>(Convert.ToInt32(i["SAMPLE_NUMBER"])),
                                               StationId = i["STATION_ID"] == DBNull.Value ? null : i["STATION_ID"].ToString()
                                           }).Distinct();
                foreach (var heatSlagQualityItem in enumSlagQualityInfo)
                {
                    HeatSlagQualityInfo heatSlagQualityInfo = new HeatSlagQualityInfo(heatSlagQualityItem.MsgId, heatSlagQualityItem.MsgTimeStamp, heatSlagQualityItem.HeatId, heatSlagQualityItem.TreatmentCount, heatSlagQualityItem.SampleAddr, heatSlagQualityItem.SampleNumber, heatSlagQualityItem.StationId, heatSlagQualityItem.SampleTime);
                    var enumSlagQulityList = from i in dt.AsEnumerable()
                                             where Convert.ToDecimal(i["MSG_ID"]) == heatSlagQualityItem.MsgId
                                             select new
                                             {
                                                 ElementShortName = i["ELEMENT_SHORT_NAME"].ToString(),
                                                 ElementFullName = i["ELEMENT_FULL_NAME"].ToString(),
                                                 ElementType = i["ELEMENT_TYPE"].ToString(),
                                                 ViewSequence = Convert.ToDecimal(i["VIEW_SEQUENCE"]),
                                                 QualityValue = i["VALUE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(i["VALUE"]))
                                             };
                    IList<QualityInfo> slagQualityList = new List<QualityInfo>();
                    foreach (var heatSlagQualityListItem in enumSlagQulityList)
                    {
                        ElementInfo elem = new ElementInfo();
                        elem.ElementShortName = heatSlagQualityListItem.ElementShortName;
                        elem.ElementFullName = heatSlagQualityListItem.ElementFullName;
                        elem.ElementType = heatSlagQualityListItem.ElementType;
                        elem.ViewSequence = heatSlagQualityListItem.ViewSequence;
                        QualityInfo slagQuality = new QualityInfo(elem, heatSlagQualityListItem.QualityValue);
                        slagQualityList.Add(slagQuality);
                    }
                    heatSlagQualityInfo.SlagQualityList = slagQualityList;
                    heatSlagQualityList.Add(heatSlagQualityInfo);
                }
            }
            return heatSlagQualityList;
        }


        /// <summary>
        /// 根据炉次号和处理次数获取渣料化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">处理次数</param>
        /// <returns>渣料化验信息</returns>
        public IList<HeatSlagQualityInfo> GetHeatSlagQualityInfo(string heatId, int treatmentCount)
        {
            IList<HeatSlagQualityInfo> heatSlagQualityList = new List<HeatSlagQualityInfo>();

            return heatSlagQualityList;
        }

    }
}
