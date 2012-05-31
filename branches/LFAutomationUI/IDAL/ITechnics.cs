using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface ITechnics
    {
        /// <summary>
        /// 获取所有的冶炼工艺基本信息  包括 工艺号 和 工艺名
        /// </summary>
        /// <returns>工艺基本信息</returns>
        IList<TechnicsInfo> GetAllTechnicInfo();

        /// <summary>
        /// 通过工艺名称选择工艺号
        /// </summary>
        /// <param name="technicsName">工艺名称</param>
        /// <returns>工艺号</returns>
        int? GetTechnicsId(string technicsName);

        /// <summary>
        /// 删除工艺信息
        /// </summary>
        void DeleteTechnicInfo(int technicsId);

        /// <summary>
        /// 插入一条新的工艺信息
        /// </summary>
        /// <param name="technicName"></param>
        void InsertTechnicInfo(string technicName);
    }
}
