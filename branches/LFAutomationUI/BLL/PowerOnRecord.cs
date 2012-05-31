using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.BLL
{
    public class PowerOnRecord
    {
        private static readonly IPowerOnRecord dal = LFAutomationUI.DALFactory.DataAccess.CreatePowerOnRecord();

        /// <summary>
        /// 取出通电记录中所有的记录
        /// </summary>
        /// <returns>通电记录</returns>
        public IList<PowerOnRecordInfo> GetPowerOnRecord()
        {
            return dal.GetPowerOnRecord();
        }

        /// <summary>
        /// 根据炉次号获取通电记录
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>通电记录</returns>
        public IList<PowerOnRecordInfo> GetPowerOnRecord(string heatId)
        {
            return dal.GetPowerOnRecord(heatId);
        }

        /// <summary>
        /// 根据炉次号和冶炼次数获取通电信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">冶炼次数</param>
        /// <returns>通电记录</returns>
        public IList<PowerOnRecordInfo> GetPowerOnRecord(string heatId, int treatmentCount)
        {
            return dal.GetPowerOnRecord(heatId, treatmentCount);
        }

        /// <summary>
        /// 根据日期选取通电记录
        /// </summary>
        /// <param name="startDate">起始日期</param>
        /// <param name="endDate">终止日期</param>
        /// <returns>通电记录</returns>
        public IList<PowerOnRecordInfo> GetPowerOnRecord(DateTime startDate, DateTime endDate)
        {
            return dal.GetPowerOnRecord(startDate, endDate);
        }
    }
}
