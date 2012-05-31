using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IRoute
    {
        /// <summary>
        /// 从表TB_ROUTE_INFO中获取冶炼路径信息
        /// </summary>
        /// <returns>路径信息</returns>
        IList<RouteInfo> GetAllRouteInfo();
    }
}
