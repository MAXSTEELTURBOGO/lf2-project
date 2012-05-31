using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class ClassesInfo
    {
        #region Inernal Members
        private string classId;
        private string classHeader;
        #endregion  

        #region Properties
        
        public string ClassId
        {
            get { return this.classId; }
            set { this.classId = value; }
        }

        public string ClassHeader
        {
            get { return this.classHeader; }
            set { this.classHeader = value; }
        }
        
        #endregion

        #region Methods
        public ClassesInfo() { }


        public ClassesInfo(string classId, string classHeader)
        {
            this.classId = classId;
            this.classHeader = classHeader;
        }

        public ClassesInfo(string classId)
        {
            this.classId = classId;
        }
        #endregion     
    }
}
