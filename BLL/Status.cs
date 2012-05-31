using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;

namespace LFAutomationUI.BLL
{
    public class Status
    {
        private static readonly IStatus dal = LFAutomationUI.DALFactory.DataAccess.CreateStatus();
        /// <summary>
        /// 获取所有状态信息
        /// </summary>
        /// <returns>所有的状态信息</returns>
        public IList<StatusInfo> GetAllStatusInfo()
        {
            return dal.GetAllStatusInfo();
        }
    }
}
