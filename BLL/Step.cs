using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;
using LFAutomationUI.DALFactory;

namespace LFAutomationUI.BLL
{
    public class Step
    {
        private static readonly IStep dal = LFAutomationUI.DALFactory.DataAccess.CreateStep();

        /// <summary>
        /// 从TB_STEPS_INFO表获取所有的步骤信息
        /// </summary>
        /// <returns>步骤信息</returns>
        public IList<StepInfo> GetAllStepInfo()
        {
            return dal.GetAllStepInfo();
        }

        /// <summary>
        /// 插入新的步骤信息
        /// </summary>
        /// <param name="stepInfo">步骤信息</param>
        public void InsertNewStepInfo(StepInfo stepInfo)
        {
            dal.InsertNewStepInfo(stepInfo);
        }

        /// <summary>
        /// 更新已有的步骤信息
        /// </summary>
        /// <param name="stepInfo">步骤信息</param>
        public void UpdateStepInfoByStepId(StepInfo stepInfo)
        {
            dal.UpdateStepInfoByStepId(stepInfo);
        }
    }
}
