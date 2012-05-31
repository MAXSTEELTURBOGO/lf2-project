using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class EventRecordInfo
    {
        #region InternalMembers
        
        DateTime msgTimeStamp;
        string heatId;
        int treatmentCount;
        string eventType;
        string info;

        #endregion

        #region Properties

        public DateTime MsgTimeStamp
        {
            get { return this.msgTimeStamp; }
            set { this.msgTimeStamp = value; }
        }
        public string HeatId
        {
            get { return this.heatId; }
            set { this.heatId = value; }
        }
        public int TreatmentCount
        {
            get { return this.treatmentCount; }
            set { this.treatmentCount = value; }
        }
        public string EventType
        {
            get { return this.eventType; }
            set { this.eventType = value; }
        }
        public string Info
        {
            get { return this.info; }
            set { this.info = value; }
        }

        #endregion

        #region Methods

        public EventRecordInfo( DateTime msgTimeStamp, string heatId, int treatmentCount, string eventType,string info)
        {
            this.msgTimeStamp = msgTimeStamp;
            this.heatId = heatId;
            this.treatmentCount = treatmentCount;
            this.eventType = eventType;
            this.info = info;
        }

        #endregion
    }
}
