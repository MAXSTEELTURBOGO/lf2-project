using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class CCMHeatStatusInfo
    {
        #region Internal members

        private decimal msgId;
        private string heatId;
        private string steelGradeId;
        private string ccmId;
        private int? stationId;
        private string heatStatus;
        private DateTime? statusTimeStamp;
        private string casterId;

        #endregion

        #region Properties

        public decimal MsgId
        {
            get { return msgId; }
            set { msgId = value; }
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


        public string CCMId
        {
            get { return ccmId; }
            set { ccmId = value; }
        }

        public int? StationId
        {
            get { return stationId; }
            set { stationId = value; }
        }

        public string HeatStatus
        {
            get { return heatStatus; }
            set { heatStatus = value; }
        }

        public DateTime? StatusTimeStamp
        {
            get { return statusTimeStamp; }
            set { statusTimeStamp = value; }
        }

        public string CasterId
        {
            get { return casterId; }
            set { casterId = value; }
        }

        #endregion

        #region Methods

        public CCMHeatStatusInfo() { }

        #endregion


    }
}
