using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;
using LFAutomationUI.DBUtility;

namespace LFAutomationUI.DAL
{
    public class EventRecord : IEventRecord
    {
        #region SQL AND PARAM

        private string SQL_SELECT_EVENT_RECORD = @"SELECT MSG_TIME_STAMP,HEAT_ID,TREATMENT_COUNT,EVENT_TYPE,INFO
                                                            FROM V_EVENT_RECORD ORDER BY MSG_TIME_STAMP DESC";
        private string SQL_SELECT_EVENT_RECORD_BY_HEAT_ID = @"SELECT MSG_TIME_STAMP, HEAT_ID, TREATMENT_COUNT, EVENT_TYPE, INFO
                                                                  FROM V_EVENT_RECORD V
                                                                 WHERE V.HEAT_ID = :HEAT_ID
                                                                 ORDER BY MSG_TIME_STAMP DESC";
        private string SQL_SELECT_EVENT_RECORD_BY_HEAT_ID_TREAT_CNT = @"SELECT MSG_TIME_STAMP, HEAT_ID, TREATMENT_COUNT, EVENT_TYPE, INFO
                                                                          FROM V_EVENT_RECORD V
                                                                         WHERE V.HEAT_ID = :HEAT_ID AND V.TREATMENT_COUNT=:TREATMENT_COUNT
                                                                         ORDER BY MSG_TIME_STAMP";
        private string SQL_SELECT_EVENT_RECORD_BY_DATE = @"SELECT MSG_TIME_STAMP, HEAT_ID, TREATMENT_COUNT, EVENT_TYPE, INFO
                                                              FROM V_EVENT_RECORD V
                                                             WHERE V.MSG_TIME_STAMP > :START_DATE
                                                               AND V.MSG_TIME_STAMP < :END_DATE
                                                             ORDER BY MSG_TIME_STAMP DESC";
        private string PARAM_HEAT_ID = @":HEAT_ID";
        private string PARAM_TREATMENT_COUNT = ":TREATMENT_COUNT";
        private string PARAM_START_DATE = @":START_DATE";
        private string PARAM_END_DATE = @":END_DATE";

        #endregion

        #region Methods

        /// <summary>
        /// 取所有的事件记录
        /// </summary>
        /// <returns>事件记录</returns>
        public IList<EventRecordInfo> GetEventRecords()
        {
            IList<EventRecordInfo> recentEventRecordInfo = new List<EventRecordInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_EVENT_RECORD, null))
            {
                while (odr.Read())
                {
                    DateTime msgTimeStamp = Convert.ToDateTime(odr[0]);
                    string heatId = odr.GetString(1);
                    int treatmentCount = Convert.ToInt16(odr[2]);
                    string eventType = odr.GetString(3);
                    string info = odr.GetString(4);
                    EventRecordInfo eventRecordInfo = new EventRecordInfo(msgTimeStamp, heatId, treatmentCount,eventType, info);
                    recentEventRecordInfo.Add(eventRecordInfo);
                }
            }
            return recentEventRecordInfo;
        }

        /// <summary>
        /// 根据炉次号取事件记录
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>事件记录</returns>
        public IList<EventRecordInfo> GetEventRecords(string heatId)
        {
            OracleParameter param = new OracleParameter(PARAM_HEAT_ID,OracleType.VarChar);
            param.Value = heatId;
            IList<EventRecordInfo> recentEventRecordInfo = new List<EventRecordInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_EVENT_RECORD_BY_HEAT_ID, param))
            {
                while (odr.Read())
                {
                    DateTime msgTimeStamp = Convert.ToDateTime(odr[0]);
                    int treatmentCount = Convert.ToInt16(odr[2]);
                    string eventType = odr.GetString(3);
                    string info = odr.GetString(4);
                    EventRecordInfo eventRecordInfo = new EventRecordInfo(msgTimeStamp, heatId, treatmentCount, eventType, info);
                    recentEventRecordInfo.Add(eventRecordInfo);
                }
            }
            return recentEventRecordInfo;
        }

        /// <summary>
        /// 根据炉次号和冶炼次数取事件记录
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">冶炼次数</param>
        /// <returns>事件记录</returns>
        public IList<EventRecordInfo> GetEventRecords(string heatId, int treatmentCount)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = heatId;
            param[1] = new OracleParameter(PARAM_TREATMENT_COUNT, OracleType.Number);
            param[1].Value = treatmentCount;
            IList<EventRecordInfo> recentEventRecordInfo = new List<EventRecordInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_EVENT_RECORD_BY_HEAT_ID_TREAT_CNT, param))
            {
                while (odr.Read())
                {
                    DateTime msgTimeStamp = Convert.ToDateTime(odr[0]);
                    string eventType = odr.GetString(3);
                    string info = odr.GetString(4);
                    EventRecordInfo eventRecordInfo = new EventRecordInfo(msgTimeStamp, heatId, treatmentCount, eventType, info);
                    recentEventRecordInfo.Add(eventRecordInfo);
                }
            }
            return recentEventRecordInfo;
        }

        /// <summary>
        /// 根据起始时间 结束时间取出事件记录
        /// </summary>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>事件记录</returns>
        public IList<EventRecordInfo> GetEventRecords(DateTime startTime, DateTime endTime)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_START_DATE, OracleType.DateTime);
            param[0].Value = startTime;
            param[1] = new OracleParameter(PARAM_END_DATE, OracleType.DateTime);
            param[1].Value = endTime;
            IList<EventRecordInfo> recentEventRecordInfo = new List<EventRecordInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_EVENT_RECORD_BY_DATE, param))
            {
                while (odr.Read())
                {
                    DateTime msgTimeStamp = Convert.ToDateTime(odr[0]);
                    string heatId = odr.GetString(1);
                    int treatmentCount = Convert.ToInt16(odr[2]);
                    string eventType = odr.GetString(3);
                    string info = odr.GetString(4);
                    EventRecordInfo eventRecordInfo = new EventRecordInfo(msgTimeStamp, heatId, treatmentCount, eventType, info);
                    recentEventRecordInfo.Add(eventRecordInfo);
                }
            }
            return recentEventRecordInfo;
        }

        #endregion
    }
}
