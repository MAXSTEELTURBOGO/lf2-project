using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using LFAutomationUI.DBUtility;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.DAL
{
    public class Route:IRoute
    {
        #region SQL && PARAMETER
        private const string SQL_SELECT_ALL_ROUTE_INFO = @"SELECT ROUTE_CODE,ROUTE_DESC FROM TB_ROUTE_INFO";
        #endregion

        #region Methods
        /// <summary>
        /// 从表TB_ROUTE_INFO中获取冶炼路径信息
        /// </summary>
        /// <returns>路径信息</returns>
        public IList<RouteInfo> GetAllRouteInfo()
        {
            IList<RouteInfo> routeInfos = new List<RouteInfo>();
            using (OracleDataReader odr=OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQL_SELECT_ALL_ROUTE_INFO,null))
            {
                while (odr.Read())
                {
                    RouteInfo routeInfo = new RouteInfo("", "");
                    routeInfo.RouteId = odr.GetString(0);
                    routeInfo.RouteDesc = odr.GetString(1);
                    routeInfos.Add(routeInfo);
                }
            }
            return routeInfos;
        }
        #endregion
    }
}
