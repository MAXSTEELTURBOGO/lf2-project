using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class BasicInfo
    {
        #region interMembers
        private string infoName;
        private string infoDescription;
        private string infoData;
        #endregion

        #region Properties
        /// <summary>
        /// 消息名称
        /// </summary>
        public string InfoName
        {
            get { return infoName; }
            set { infoName = value; }
        }
        /// <summary>
        /// 消息数据
        /// </summary>
        public string InfoData
        {
            get { return infoData; }
            set { infoData = value; }
        }
        /// <summary>
        /// 消息描述
        /// </summary>
        public string InfoDescription
        {
            get { return infoDescription; }
            set { infoDescription = value; }
        }
        #endregion

        #region Methods 构造函数
        public BasicInfo()
        { }

        public BasicInfo(string infoName, string infoData, string infoDescription)
        {
            this.infoName = infoName;
            this.infoData = infoData;
            this.infoDescription = infoDescription;
        }
        #endregion
    }
}
