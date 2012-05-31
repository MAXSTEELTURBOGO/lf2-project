using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class RouteInfo
    {
        #region internal members
        private string routeId;
        private string routeDesc;
        #endregion

        #region Properties
        public string RouteId
        {
            get { return this.routeId; }
            set { this.routeId = value; }
        }
        public string RouteDesc
        {
            get { return this.routeDesc; }
            set { this.routeDesc = value; }
        }
        #endregion

        #region Construction Methods
        public RouteInfo(string routeId, string routeDesc)
        {
            this.routeId = routeId;
            this.routeDesc = routeDesc;
        }
        #endregion

    }
}
