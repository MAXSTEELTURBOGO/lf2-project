using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    /// <summary>
    /// 该类是化验室信息的横表结构类
    /// </summary>
    public class QualityHorizontalInfo
    {
        #region members
        private decimal msgId;
        private DateTime msgTimeStamp;
        private string heatId;
        private int treatmentCount;
        private DateTime sampleTime;
        private string samplePlace;
        private int sampleNumber;
        private string analCode;
        private string stationId;
        private double? eleC;
        private double? eleSI;
        private double? eleMN;
        private double? eleP;
        private double? eleS;
        private double? eleCU;
        private double? eleTAL;
        private double? eleSOL;
        private double? eleB;
        private double? eleNI;
        private double? eleCR;
        private double? eleMO;
        private double? eleW;
        private double? eleTI;
        private double? eleV;
        private double? eleZR;
        private double? elePB;
        private double? eleSN;
        private double? eleAS;
        private double? eleCA;
        private double? eleCO;
        private double? eleMG;
        private double? eleTE;
        private double? eleBI;
        private double? eleSB;
        private double? eleZN;
        private double? eleNB;
        private double? eleH;
        private double? eleN;
        private double? eleO;
        private double? eleAL;
        private double? eleALT;
        private double? eleSE;
        private double? eleRE;
        private double? eleALS;
        private double? eleCEQ;
        private double? elePCM;
        private double? elePSR;
        private double? eleTA;
        private double? eleALN;
        private double? eleCAS;
        private double? eleCRMO;
        private double? eleCRMOCU;
        private double? eleCRMOCUNI;
        private double? eleCUCR;
        private double? eleCUNI;
        private double? eleMNSI;
        private double? eleNBN;
        private double? eleNBJN;
        private double? eleNBVTI;
        private double? eleNICR;
        private double? eleNICRCU;
        private double? elePS;
        private double? eleTIN;
        private double? eleVNB;

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
        public int TreatmentCount
        {
            get { return treatmentCount; }
            set { treatmentCount = value; }
        }

        public DateTime SampleTime
        {
            get { return sampleTime; }
            set { sampleTime = value; }
        }
        public string SamplePlace
        {
            get { return samplePlace; }
            set { samplePlace = value; }
        }
        public int SampleNumber
        {
            get { return sampleNumber; }
            set { sampleNumber = value; }
        }
        public string AnalCode
        {
            get { return analCode; }
            set { analCode = value; }
        }
        public string StationId
        {
            get { return stationId; }
            set { stationId = value; }
        }
        public double? EleC
        {
            get { return eleC; }
            set { eleC = value; }
        }
        public double? EleSI
        {
            get { return eleSI; }
            set { eleSI = value; }
        }
        public double? EleMN
        {
            get { return eleMN; }
            set { eleMN = value; }
        }
        public double? EleP
        {
            get { return eleP; }
            set { eleP = value; }
        }
        public double? EleS
        {
            get { return eleS; }
            set { eleS = value; }
        }
        public double? EleCU
        {
            get { return eleCU; }
            set { eleCU = value; }
        }
        public double? EleTAL
        {
            get { return eleTAL; }
            set { eleTAL = value; }
        }
        public double? EleSOL
        {
            get { return eleSOL; }
            set { eleSOL = value; }
        }
        public double? EleB
        {
            get { return eleB; }
            set { eleB = value; }
        }
        public double? EleNI
        {
            get { return eleNI; }
            set { eleNI = value; }
        }
        public double? EleCR
        {
            get { return eleCR; }
            set { eleCR = value; }
        }
        public double? EleMO
        {
            get { return eleMO; }
            set { eleMO = value; }
        }
        public double? EleW
        {
            get { return eleW; }
            set { eleW = value; }
        }
        public double? EleTI
        {
            get { return eleTI; }
            set { eleTI = value; }
        }
        public double? EleV
        {
            get { return eleV; }
            set { eleV = value; }
        }
        public double? EleZR
        {
            get { return eleZR; }
            set { eleZR = value; }
        }
        public double? ElePB
        {
            get { return elePB; }
            set { elePB = value; }
        }
        public double? EleSN
        {
            get { return eleSN; }
            set { eleSN = value; }
        }
        public double? EleAS
        {
            get { return eleAS; }
            set { eleAS = value; }
        }
        public double? EleCA
        {
            get { return eleCA; }
            set { eleCA = value; }
        }
        public double? EleCO
        {
            get { return eleCO; }
            set { eleCO = value; }
        }
        public double? EleMG
        {
            get { return eleMG; }
            set { eleMG = value; }
        }
        public double? EleTE
        {
            get { return eleTE; }
            set { eleTE = value; }
        }
        public double? EleBI
        {
            get { return eleBI; }
            set { eleBI = value; }
        }
        public double? EleSB
        {
            get { return eleSB; }
            set { eleSB = value; }
        }
        public double? EleZN
        {
            get { return eleZN; }
            set { eleZN = value; }
        }
        public double? EleNB
        {
            get { return eleNB; }
            set { eleNB = value; }
        }
        public double? EleH
        {
            get { return eleH; }
            set { eleH = value; }
        }
        public double? EleN
        {
            get { return eleN; }
            set { eleN = value; }
        }
        public double? EleO
        {
            get { return eleO; }
            set { eleO = value; }
        }

        public double? EleAL
        {
            get { return eleAL; }
            set { eleAL = value; }
        }
        public double? EleALT
        {
            get { return eleALT; }
            set { eleALT = value; }
        }
        public double? EleSE
        {
            get { return eleSE; }
            set { eleSE = value; }
        }
        public double? EleRE
        {
            get { return eleRE; }
            set { eleRE = value; }
        }
        public double? EleALS
        {
            get { return eleALS; }
            set { eleALS = value; }
        }
        public double? EleCEQ
        {
            get { return eleCEQ; }
            set { eleCEQ = value; }
        }
        public double? ElePCM
        {
            get { return elePCM; }
            set { elePCM = value; }
        }
        public double? ElePSR
        {
            get { return elePSR; }
            set { elePSR = value; }
        }
        public double? EleTA
        {
            get { return eleTA; }
            set { eleTA = value; }
        }
        public double? EleALN
        {
            get { return eleALN; }
            set { eleALN = value; }
        }
        public double? EleCAS
        {
            get { return eleCAS; }
            set { eleCAS = value; }
        }
        public double? EleCRMO
        {
            get { return eleCRMO; }
            set { eleCRMO = value; }
        }
        public double? EleCRMOCU
        {
            get { return eleCRMOCU; }
            set { eleCRMOCU = value; }
        }
        public double? EleCRMOCUNI
        {
            get { return eleCRMOCUNI; }
            set { eleCRMOCUNI = value; }
        }
        public double? EleCUCR
        {
            get { return eleCUCR; }
            set { eleCUCR = value; }
        }
        public double? EleCUNI
        {
            get { return eleCUNI; }
            set { eleCUNI = value; }
        }
        public double? EleMNSI
        {
            get { return eleMNSI; }
            set { eleMNSI = value; }
        }
        public double? EleNBN
        {
            get { return eleNBN; }
            set { eleNBN = value; }
        }
        public double? EleNBJN
        {
            get { return eleNBJN; }
            set { eleNBJN = value; }
        }
        public double? EleNBVTI
        {
            get { return eleNBVTI; }
            set { eleNBVTI = value; }
        }
        public double? EleNICR
        {
            get { return eleNICR; }
            set { eleNICR = value; }
        }
        public double? EleNICRCU
        {
            get { return eleNICRCU; }
            set { eleNICRCU = value; }
        }
        public double? ElePS
        {
            get { return elePS; }
            set { elePS = value; }
        }
        public double? EleTIN
        {
            get { return eleTIN; }
            set { eleTIN = value; }
        }
        public double? EleVNB
        {
            get { return eleVNB; }
            set { eleVNB = value; }
        }
        #endregion

        #region Methods
        public QualityHorizontalInfo()
        { }

        public QualityHorizontalInfo(decimal msgId, DateTime msgTimeStamp, string heatId, int treatmentCount, DateTime sampleTime, string samplePlace,
                                int sampleNumber, string analCode, string stationId, double? eleC, double? eleSI, double? eleMN, double? eleP, double? eleS,
                                double? eleCU, double? eleTAL, double? eleSOL, double? eleB, double? eleNI, double? eleCR, double? eleMO, double? eleW,
                                double? eleTI, double? eleV, double? eleZR, double? elePB, double? eleSN, double? eleAS, double? eleCA, double? eleCO,
                                double? eleMG, double? eleTE, double? eleBI, double? eleSB, double? eleZN, double? eleNB, double? eleH, double? eleN,
                                double? eleO, double? eleAL, double? eleALT, double? eleSE, double? eleRE, double? eleALS, double? eleCEQ, double? elePCM, double? elePSR,
                                double? eleTA, double? eleALN, double? eleCAS, double? eleCRMO, double? eleCRMOCU, double? eleCRMOCUNI, double? eleCUCR,
                                double? eleCUNI, double? eleMNSI, double? eleNBN, double? eleNBJN, double? eleNBVTI, double? eleNICR, double? eleNICRCU,
                                double? elePS, double? eleTIN, double? eleVNB)
        {
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
            this.heatId = heatId;
            this.treatmentCount = treatmentCount;
            this.sampleTime = sampleTime;
            this.samplePlace = samplePlace;
            this.sampleNumber = sampleNumber;
            this.analCode = analCode;
            this.stationId = stationId;
            this.eleC = eleC;
            this.eleSI = eleSI;
            this.eleMN = eleMN;
            this.eleP = eleP;
            this.eleS = eleS;
            this.eleCU = eleCU;
            this.eleTAL = eleTAL;
            this.eleSOL = eleSOL;
            this.eleB = eleB;
            this.eleNI = eleNI;
            this.eleCR = eleCR;
            this.eleMO = eleMO;
            this.eleW = eleW;
            this.eleTI = eleTI;
            this.eleV = eleV;
            this.eleZR = eleZR;
            this.elePB = elePB;
            this.eleSN = eleSN;
            this.eleAS = eleAS;
            this.eleCA = eleCA;
            this.eleCO = eleCO;
            this.eleMG = eleMG;
            this.eleTE = eleTE;
            this.eleBI = eleBI;
            this.eleSB = eleSB;
            this.eleZN = eleZN;
            this.eleNB = eleNB;
            this.eleH = eleH;
            this.eleN = eleN;
            this.eleO = eleO;
            this.eleAL = eleAL;
            this.eleALT = eleALT;
            this.eleSE = eleSE;
            this.eleRE = eleRE;
            this.eleALS = eleALS;
            this.eleCEQ = eleCEQ;
            this.elePCM = elePCM;
            this.elePSR = elePSR;
            this.eleTA = eleTA;
            this.eleALN = eleALN;
            this.eleCAS = eleCAS;
            this.eleCRMO = eleCRMO;
            this.eleCRMOCU = eleCRMOCU;
            this.eleCRMOCUNI = eleCRMOCUNI;
            this.eleCUCR = eleCUCR;
            this.eleCUNI = eleCUNI;
            this.eleMNSI = eleMNSI;
            this.eleNBN = eleNBN;
            this.eleNBJN = eleNBJN;
            this.eleNBVTI = eleNBVTI;
            this.eleNICR = eleNICR;
            this.eleNICRCU = eleNICRCU;
            this.elePS = elePS;
            this.eleTIN = eleTIN;
            this.eleVNB = eleVNB;
        }
        #endregion
    }
}
