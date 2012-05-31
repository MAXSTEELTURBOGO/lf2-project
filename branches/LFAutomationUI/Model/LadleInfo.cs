using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class LadleInfo
    {
        #region Internal member

        private decimal msgId;
        private DateTime msgTimeStamp;
        private string heatId;
        private string ladleId;
        private string ladleMaterial;
        private double? ladleEmptyWeight;
        private string ladleState;    //钢包状态 
        private string ladleStatus;   //钢包状况 冷包/热包
        private int? ladleAge;

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

        public string HeatId
        {
            get { return heatId; }
            set { heatId = value; }
        }

        public string LadleId
        {
            get { return ladleId; }
            set { ladleId = value; }
        }

        public string LadleMaterial
        {
            get { return ladleMaterial; }
            set { ladleMaterial = value; }
        }

        public double? LadlEmptyWeight
        {
            get { return ladleEmptyWeight; }
            set { ladleEmptyWeight = value; }
        }


        public string LadleState
        {
            get { return ladleState; }
            set { ladleState = value; }
        }



        public string LadleStatus
        {
            get { return ladleStatus; }
            set { ladleStatus = value; }
        }

        public int? LadleAge
        {
            get { return this.ladleAge; }
            set { ladleAge = value; }
        }

        #endregion

        #region Methods

        public LadleInfo() { }

        public LadleInfo(string ladleId, string ladleMaterial, double? ladleEmptyWeight, string ladleState, string ladleStatus, int? ladleAge)
        {
            this.ladleId = ladleId;
            this.ladleMaterial = ladleMaterial;
            this.ladleEmptyWeight = ladleEmptyWeight;
            this.ladleState = ladleState;
            this.ladleStatus = ladleStatus;
            this.ladleAge = ladleAge;
        }

        public LadleInfo(decimal msgId,DateTime msgTimeStamp,string heatId,string ladleId,string ladleMaterial,double? ladleEmptyWeight,string ladleState,string ladleStatus,int? ladleAge)
        {
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
            this.heatId = heatId;
            this.ladleId = ladleId;
            this.ladleMaterial = ladleMaterial;
            this.ladleEmptyWeight = ladleEmptyWeight;
            this.ladleState = ladleState;
            this.ladleStatus = ladleStatus;
            this.ladleAge = ladleAge;
        }

        #endregion


    }
}
