using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;

namespace LFAutomationUI.BLL
{
    public class BOFHeat
    {
        private static readonly IBOFHeat dal = LFAutomationUI.DALFactory.DataAccess.CreateBOFHeat();

        /// <summary>
        /// 通过炉次号获取BOF炉次信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>BOF炉次信息</returns>
        public BOFHeatInfo GetBOFHeatInfo(string heatId)
        {
            return dal.GetBOFHeatInfo(heatId);
        }
    }
}
