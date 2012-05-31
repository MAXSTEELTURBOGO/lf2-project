using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.BLL
{
    public class TempOxygenRecord
    {
        private static readonly ITempOxygenRecord dal = LFAutomationUI.DALFactory.DataAccess.CreateTempOxygenRecord();

        /// <summary>
        /// 取出所有的测温记录
        /// </summary>
        /// <returns>所有测温记录</returns>
        public IList<TempOxygenRecordInfo> GetTempOxygenRecord()
        {
            return dal.GetTempOxygenRecord();
        }

        /// <summary>
        /// 根据炉次号查询测温测氧记录
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>测温测氧记录</returns>
        public IList<TempOxygenRecordInfo> GetTempOxygenRecord(string heatId)
        {
            return dal.GetTempOxygenRecord(heatId);
        }

        /// <summary>
        /// 根据炉次号和冶炼次数查询测温测氧记录
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">冶炼次数</param>
        /// <returns>测温测氧记录</returns>
        public IList<TempOxygenRecordInfo> GetTempOxygenRecord(string heatId, int treatmentCount)
        {
            return dal.GetTempOxygenRecord(heatId, treatmentCount);
        }

        /// <summary>
        /// 根据起始日期和结束日期获取测温测氧记录
        /// </summary>
        /// <param name="startDate">起始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>测温测氧记录</returns>
        public IList<TempOxygenRecordInfo> GetTempOxygenRecord(DateTime startDate, DateTime endDate)
        {
            return dal.GetTempOxygenRecord(startDate, endDate);
        }
    }
}
