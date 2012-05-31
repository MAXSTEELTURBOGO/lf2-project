using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class HeatEquipmentInfo
    {
        #region Internal members

        private string heatId;
        private int treatmentCount;
        private int? aElectrodeAge;
        private int? bElectrodeAge;
        private int? cElectrodeAge;
        private int? aPoleCircleUseCount;
        private int? bPoleCircleUseCount;
        private int? cPoleCircleUseCount;
        private string roofId;
        private int? roofAge;
        
        #endregion 
        
        #region Properties
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
        public int? AElectrodeAge
        {
            get { return aElectrodeAge; }
            set { aElectrodeAge = value; }
        }
        public int? BElectrodeAge
        {
            get { return bElectrodeAge; }
            set { bElectrodeAge = value; }
        }
        public int? CElectrodeAge
        {
            get { return cElectrodeAge; }
            set { cElectrodeAge = value; }
        }
        public int? APoleCircleUseCount
        {
            get { return aPoleCircleUseCount; }
            set { aPoleCircleUseCount = value; }
        }
        public int? BPoleCircleUseCount
        {
            get { return bPoleCircleUseCount; }
            set { bPoleCircleUseCount = value; }
        }
        public int? CPoleCircleUseCount
        {
            get { return cPoleCircleUseCount; }
            set { cPoleCircleUseCount = value; }
        }
        public string RoofId
        {
            get { return this.roofId; }
            set { this.roofId = value; }
        }
        public int? RoofAge
        {
            get { return roofAge; }
            set { roofAge = value; }
        }
        #endregion

        #region Methods

        public HeatEquipmentInfo() { }

        public HeatEquipmentInfo(int aElectrodeAge, int bElectrodeAge, int cElectrodeAge, int aPoleCircleUseCount, int bPoleCircleUseCount, int cPoleCircleUseCount, int roofAge)
        {
            this.aElectrodeAge = aElectrodeAge;
            this.bElectrodeAge = bElectrodeAge;
            this.cElectrodeAge = cElectrodeAge;
            this.aPoleCircleUseCount = aPoleCircleUseCount;
            this.bPoleCircleUseCount = bPoleCircleUseCount;
            this.cPoleCircleUseCount = cPoleCircleUseCount;
            this.roofAge = roofAge;
        }

        public HeatEquipmentInfo(string heatId,int treatmentCount,int aElectrodeAge, int bElectrodeAge, int cElectrodeAge, int aPoleCircleUseCount, int bPoleCircleUseCount, int cPoleCircleUseCount, int roofAge)
        {
            this.heatId = heatId;
            this.treatmentCount = treatmentCount;
            this.aElectrodeAge = aElectrodeAge;
            this.bElectrodeAge = bElectrodeAge;
            this.cElectrodeAge = cElectrodeAge;
            this.aPoleCircleUseCount = aPoleCircleUseCount;
            this.bPoleCircleUseCount = bPoleCircleUseCount;
            this.cPoleCircleUseCount = cPoleCircleUseCount;
            this.roofAge = roofAge;
        }

        #endregion
    }
}
