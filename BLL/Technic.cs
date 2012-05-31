using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;
using LFAutomationUI.DALFactory;

namespace LFAutomationUI.BLL
{
    public class Technic
    {
        private static readonly ITechnics dal = LFAutomationUI.DALFactory.DataAccess.CreateTechnics();
        /// <summary>
        /// 获取所有的冶炼工艺基本信息  包括 工艺号 和 工艺名
        /// </summary>
        /// <returns>工艺基本信息</returns>
        public IList<TechnicsInfo> GetAllTechnicInfo()
        {
            return dal.GetAllTechnicInfo();
        }

        /// <summary>
        /// 通过工艺名称选择工艺号
        /// </summary>
        /// <param name="technicsName">工艺名称</param>
        /// <returns>工艺号</returns>
        public int? GetTechnicsId(string technicsName)
        {
            return dal.GetTechnicsId(technicsName);
        }

        /// <summary>
        /// 删除工艺信息
        /// </summary>
        public void DeleteTechnicInfo(int technicsId)
        {
            dal.DeleteTechnicInfo(technicsId);
        }

        /// <summary>
        /// 插入一条新的工艺信息
        /// </summary>
        /// <param name="technicName"></param>
        public void InsertTechnicInfo(string technicName)
        {
            dal.InsertTechnicInfo(technicName);
        }
    }
}
