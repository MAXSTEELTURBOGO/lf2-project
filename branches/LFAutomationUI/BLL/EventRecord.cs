using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;

namespace LFAutomationUI.BLL
{
    public class EventRecord
    {
        private static readonly IEventRecord dal = LFAutomationUI.DALFactory.DataAccess.CreateEventRecord();

        /// <summary>
        /// 取所有事件记录
        /// </summary>
        /// <returns>事件记录</returns>
        public IList<EventRecordInfo> GetEventRecords()
        {
            return dal.GetEventRecords();
        }

        /// <summary>
        /// 根据炉次号取事件记录
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>事件记录</returns>
        public IList<EventRecordInfo> GetEventRecords(string heatId)
        {
            return dal.GetEventRecords(heatId);
        }

        /// <summary>
        /// 根据炉次号和冶炼次数取事件记录
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">冶炼次数</param>
        /// <returns>事件记录</returns>
        public IList<EventRecordInfo> GetEventRecords(string heatId, int treatmentCount)
        {
            return dal.GetEventRecords(heatId, treatmentCount);
        }

        /// <summary>
        /// 根据起始时间 结束时间取出事件记录
        /// </summary>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>事件记录</returns>
        public IList<EventRecordInfo> GetEventRecords(DateTime startTime, DateTime endTime)
        {
            return dal.GetEventRecords(startTime, endTime);
        }

    }
}
