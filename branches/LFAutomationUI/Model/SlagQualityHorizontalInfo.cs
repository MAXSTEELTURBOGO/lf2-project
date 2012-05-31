using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class SlagQualityHorizontalInfo
    {
        #region internal Members and Properties

        private decimal msgId;
        public decimal MsgId
        {
            get { return msgId; }
            set { msgId = value; }
        }

        private DateTime msgTimeStamp;
        public DateTime MsgTimeStamp
        {
            get { return msgTimeStamp; }
            set { msgTimeStamp = value; }
        }

        private string heatId;
        public string HeatId
        {
            get { return heatId; }
            set { heatId = value; }
        }

        private int treatmentCount;
        public int TreatmentCount
        {
            get { return treatmentCount; }
            set { treatmentCount = value; }
        }

        private DateTime? sampleTime;
        public DateTime? SampleTime
        {
            get { return sampleTime; }
            set { sampleTime = value; }
        }

        private string samplePlace;
        public string SamplePlace
        {
            get { return samplePlace; }
            set { samplePlace = value; }
        }

        private int? sampleNumber;
        public int? SampleNumber
        {
            get { return sampleNumber; }
            set { sampleNumber = value; }
        }

        private string analCode;
        public string AnalCode
        {
            get { return analCode; }
            set { analCode = value; }
        }

        private double? analSIO2;
        public double? AnalSIO2
        {
            get { return analSIO2; }
            set { analSIO2 = value; }
        }

        private double? analCAO;
        public double? AnalCAO
        {
            get { return analCAO; }
            set { analCAO = value; }
        }

        private double? analMNO;
        public double? AnalMNO
        {
            get { return analMNO; }
            set { analMNO = value; }
        }

        private double? analMGO;
        public double? AnalMGO
        {
            get { return analMGO; }
            set { analMGO = value; }
        }

        private double? analP2O5;
        public double? AnalP2O5
        {
            get { return analP2O5; }
            set { analP2O5 = value; }
        }

        private double? analAL2O3;
        public double? AnalAL2O3
        {
            get { return analAL2O3; }
            set { analAL2O3 = value; }
        }

        private double? analFEOX;
        public double? AnalFEOX
        {
            get { return analFEOX; }
            set { analFEOX = value; }
        }

        private double? analFE_TOT;
        public double? AnalFE_TOT
        {
            get { return analFE_TOT; }
            set { analFE_TOT = value; }
        }

        private double? analOX;
        public double? AnalOX
        {
            get { return analOX; }
            set { analOX = value; }
        }

        private double? analCAF2;
        public double? AnalCAF2
        {
            get { return analCAF2; }
            set { analCAF2 = value; }
        }

        private double? analO2;
        public double? AnalO2
        {
            get { return analO2; }
            set { analO2 = value; }
        }

        private double? analS;
        public double? AnalS
        {
            get { return analS; }
            set { analS = value; }
        }

        private double? analNA2O;
        public double? AnalNA2O
        {
            get { return analNA2O; }
            set { analNA2O = value; }
        }

        private double? analCR2O3;
        public double? AnalCR2O3
        {
            get { return analCR2O3; }
            set { analCR2O3 = value; }
        }

        private double? analTIO2;
        public double? AnalTIO2
        {
            get { return analTIO2; }
            set { analTIO2 = value; }
        }

        private double? analK2O;
        public double? AnalK2O
        {
            get { return analK2O; }
            set { analK2O = value; }
        }

        #endregion

        #region Methods
        public SlagQualityHorizontalInfo()
        { }
        public SlagQualityHorizontalInfo(decimal msgId, DateTime msgTimeStamp,string heatId,int treatmentCount,DateTime? sampleTime,string samplePlace,
                                        int? sampleNumber,double? analSIO2,double? analCAO,double? analMNO,double? analMGO,double? analP2O5,
                                        double? analAL2O3,double? analFEOX,double? analFE_TOT,double? analOX,double? analCAF2,double? analO2,
                                        double? analS,double? analNA2O,double? analCR2O3,double? analTIO2,double? analK2O)
        {
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
            this.heatId = heatId;
            this.treatmentCount = treatmentCount;
            this.sampleTime = sampleTime;
            this.samplePlace = samplePlace;
            this.sampleNumber = sampleNumber;
            this.analSIO2 = analSIO2;
            this.analCAO = analCAO;
            this.analMNO = analMNO;
            this.analMGO = analMGO;
            this.analP2O5 = analP2O5;
            this.analAL2O3 = analAL2O3;
            this.analFEOX = analFEOX;
            this.analFE_TOT = analFE_TOT;
            this.analOX = analOX;
            this.analCAF2 = analCAF2;
            this.analO2 = analO2;
            this.analS = analS;
            this.analNA2O = analNA2O;
            this.analCR2O3 = analCR2O3;
            this.analTIO2 = analTIO2;
            this.analK2O = analK2O;
        }



        #endregion
    }
}
