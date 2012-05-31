using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface ITechnicStep
    {
        /// <summary>
        /// 插入工艺步骤信息
        /// </summary>
        /// <param name="technicStepList">工艺步骤信息</param>
        void InsertTechnicStepInfo(IList<TechnicStepInfo> technicStepList);
    }
}
