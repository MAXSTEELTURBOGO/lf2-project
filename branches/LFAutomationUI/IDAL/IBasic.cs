using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IBasic
    {
        /// <summary>
        /// 获取所有基本信息
        /// </summary>
        /// <returns>基本信息</returns>
        IList<BasicInfo> GetBasicInfos();

        /// <summary>
        /// 向表TB_BASIC_INFO插入一条基础信息
        /// </summary>
        /// <param name="basicInfo">基础信息</param>
        void InsertBasicInfo(BasicInfo basicInfo);

        /// <summary>
        /// 根据INFO_NAME更新表TB_BASIC_INFO中的数据
        /// </summary>
        /// <param name="basicInfo">基础信息</param>
        void UpdateBasicInfo(BasicInfo basicInfo);
    }
}
