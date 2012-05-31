using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.BLL
{
    public class TechnicStep
    {
        private static readonly ITechnicStep dal = LFAutomationUI.DALFactory.DataAccess.CreateTechnicStep();

        /// <summary>
        /// 插入工艺步骤信息
        /// </summary>
        /// <param name="technicStepList">工艺步骤信息</param>
        public void InsertTechnicStepInfo(IList<TechnicStepInfo> technicStepList)
        {
            dal.InsertTechnicStepInfo(technicStepList);
        }
    }
}
