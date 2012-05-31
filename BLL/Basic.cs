using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;

namespace LFAutomationUI.BLL
{
    public class Basic
    {
        private static readonly IBasic dal = LFAutomationUI.DALFactory.DataAccess.CreateBasic();

        /// <summary>
        /// 获取所有的基础信息
        /// </summary>
        /// <returns>基础信息列表</returns>
        public IList<BasicInfo> GetBasicInfos()
        {
            return dal.GetBasicInfos();
        }
        /// <summary>
        /// 向表TB_BASIC_INFO插入基础信息
        /// </summary>
        /// <param name="basicInfo">基础信息</param>
        public void InsertBasicInfo(BasicInfo basicInfo)
        {
            dal.InsertBasicInfo(basicInfo);
        }
        /// <summary>
        /// 更新基础信息
        /// </summary>
        /// <param name="basicInfo">基础信息</param>
        public void UpdateBasicInfo(BasicInfo basicInfo)
        {
            dal.UpdateBasicInfo(basicInfo);
        }
    }
}
