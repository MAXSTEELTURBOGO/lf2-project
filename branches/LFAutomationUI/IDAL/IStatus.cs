using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IStatus
    {
        /// <summary>
        /// 获取所有状态信息
        /// </summary>
        /// <returns>所有的状态信息</returns>
        IList<StatusInfo> GetAllStatusInfo();
    }
}
