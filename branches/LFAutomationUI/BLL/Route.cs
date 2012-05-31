using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;
using LFAutomationUI.DALFactory;

namespace LFAutomationUI.BLL
{
    public class Route
    {
        private static readonly IRoute dal = LFAutomationUI.DALFactory.DataAccess.CreateRoute();
        /// <summary>
        /// 从表TB_ROUTE_INFO中获取冶炼路径信息
        /// </summary>
        /// <returns>路径信息</returns>
        public IList<RouteInfo> GetAllRouteInfo()
        {
            return dal.GetAllRouteInfo();
        }
    }
}
