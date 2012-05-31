using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class SourceInfo
    {
        #region members
        private string sourceType;
        private int sourceId;
        private int materialId;
        private string materialName;
        #endregion

        #region Properties

        public string SourceEnType
        {
            get { return this.sourceType; }
            set { this.sourceType = value; }
        }


        public string SourceType
        {
            get
            {
                return this.sourceType == "SILO" ? "料仓" : "喂丝机";
            }
            set
            {
                this.sourceType = (value == "料仓" ? "SILO" : "FEED MACHINE");
            }
        }
        public int SourceId
        {
            get { return this.sourceId; }
            set { this.sourceId = value; }
        }
        public int MaterialId
        {
            get { return this.materialId; }
            set { this.materialId = value; }
        }
        public string MaterialName
        {
            get { return this.materialName; }
            set { this.materialName = value; }
        }
        #endregion

        #region Methods

        public SourceInfo() { }

        public SourceInfo(string sourceType, int sourceId, int materialId, string materialName)
        {
            this.sourceType = sourceType;
            this.sourceId = sourceId;
            this.materialId = materialId;
            this.materialName = materialName;
        }

        #endregion
    }
}
