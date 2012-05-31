using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IStep
    {
        /// <summary>
        /// 从TB_STEPS_INFO表获取所有的步骤信息
        /// </summary>
        /// <returns>步骤信息</returns>
        IList<StepInfo> GetAllStepInfo();

        /// <summary>
        /// 插入新的步骤信息
        /// </summary>
        /// <param name="stepInfo">步骤信息</param>
        void InsertNewStepInfo(StepInfo stepInfo);

        /// <summary>
        /// 更新已有的步骤信息
        /// </summary>
        /// <param name="stepInfo">步骤信息</param>
        void UpdateStepInfoByStepId(StepInfo stepInfo);
    }
}
