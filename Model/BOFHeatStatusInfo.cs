using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class BOFHeatStatusInfo
    {
        #region Internal members

        private decimal msgId;
        private DateTime msgTimeStamp;
        private int stationId;
        private decimal? planId;
        private string heatId;
        private string steelGradeId;
        private string heatStatus;
        private DateTime statusTimeStamp;


        #endregion

        #region Properties

        public decimal MsgId
        {
            get { return msgId; }
            set { msgId = value; }
        }

        public DateTime MsgTimeStamp
        {
            get { return msgTimeStamp; }
            set { msgTimeStamp = value; }
        }

        public int StationId
        {
            get { return stationId; }
            set { stationId = value; }
        }

        public decimal? PlanId
        {
            get { return planId; }
            set { planId = value; }
        }

        public string HeatId
        {
            get { return heatId; }
            set { heatId = value; }
        }

        public string SteelGradeId
        {
            get { return steelGradeId; }
            set { steelGradeId = value; }
        }

        public string HeatStatus
        {
            get { return heatStatus; }
            set { heatStatus = value; }
        }

        public DateTime StatusTimeStamp
        {
            get { return statusTimeStamp; }
            set { statusTimeStamp = value; }
        }

        #endregion

        #region Methods

        public BOFHeatStatusInfo() { }

        public BOFHeatStatusInfo(decimal msgId, DateTime msgTimeStamp, int stationId, decimal? planId, string heatId, string steelGradeId, string heatStatus, DateTime statusTimeStamp)
        {
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
            this.stationId = stationId;
            this.planId = planId;
            this.heatId = heatId;
            this.steelGradeId = steelGradeId;
            this.heatStatus = heatStatus;
            this.statusTimeStamp = statusTimeStamp;
        }

        #endregion
    }
}
