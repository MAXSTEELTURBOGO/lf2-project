using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class EquipmentInfo
    {
        #region Internal member
        
        private string equipmentName;
        private int equipmentAge;
        private string equipmentDescription;
        
        #endregion
        
        #region Properties

        public string EquipmentName
        {
            get { return equipmentName; }
            set { equipmentName = value; }
        }

        public int EquipmentAge
        {
            get { return equipmentAge; }
            set { equipmentAge = value; }
        }


        public string EquipmentDescription
        {
            get { return equipmentDescription; }
            set { equipmentDescription = value; }
        }


        #endregion

        #region Methods
        
        public EquipmentInfo() { }

        public EquipmentInfo(string equipmentName,int equipmentAge,string equipmentDescription)
        {
            this.equipmentName = equipmentName;
            this.equipmentAge = equipmentAge;
            this.equipmentDescription = equipmentDescription;
        }

        #endregion

        
        
    }
}
