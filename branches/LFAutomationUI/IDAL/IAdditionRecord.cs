using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IAdditionRecord
    {
        /// <summary>
        /// 取出所有的加料报告
        /// </summary>
        /// <returns>加料记录</returns>
        IList<AdditionRecordInfo> GetAdditionMaterialRecords();

        /// <summary>
        /// 根据炉次号取得加料报告
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>加料记录</returns>
        IList<AdditionRecordInfo> GetAdditionMaterialRecords(string heatId);

        /// <summary>
        /// 根据炉次号,冶炼次数 取得加料报告
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">冶炼次数</param>
        /// <returns>加料记录</returns>
        IList<AdditionRecordInfo> GetAdditionMaterialRecords(string heatId, int treatmentCount);

        /// <summary>
        /// 根据日期查询加料信息
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>加料信息</returns>
        IList<AdditionRecordInfo> GetAdditionMaterialRecords(DateTime startDate, DateTime endDate);

        /// <summary>
        /// 添加加料信息
        /// </summary>
        /// <param name="additionRecord">加料记录</param>
        void InsertAdditionRecord(AdditionRecordInfo additionRecord);
    }
}
