using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class RHHeatStatusInfo
    {
        #region internal Members and Properties

        private decimal msgId;

        public decimal MsgId
        {
            get { return msgId; }
            set { msgId = value; }
        }
        private DateTime? msgTimeStamp;

        public DateTime? MsgTimeStamp
        {
            get { return msgTimeStamp; }
            set { msgTimeStamp = value; }
        }
        private int stationId;

        public int StationId
        {
            get { return stationId; }
            set { stationId = value; }
        }
        private string heatId;

        public string HeatId
        {
            get { return heatId; }
            set { heatId = value; }
        }
        private string heatStatus;

        public string HeatStatus
        {
            get { return heatStatus; }
            set { heatStatus = value; }
        }
        private DateTime? statusTimeStamp;

        public DateTime? StatusTimeStamp
        {
            get { return statusTimeStamp; }
            set { statusTimeStamp = value; }
        }

        #endregion

        #region Methods
        public RHHeatStatusInfo(decimal msgId, DateTime? msgTimeStamp, int stationId, string heatId, string heatStatus, DateTime? statusTimeStamp)
        {
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
            this.stationId = stationId;
            this.heatId = heatId;
            this.heatStatus = heatStatus;
            this.statusTimeStamp = statusTimeStamp;
        }
        #endregion
    }
}
