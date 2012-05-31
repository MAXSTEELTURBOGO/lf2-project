using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IDBLog
    {
        /// <summary>
        /// 插入数据库日志信息
        /// </summary>
        /// <param name="dbLog">日志信息</param>
        void InsertDBLogInfo(DBLogInfo dbLog);


        /// <summary>
        /// 获取所有日志信息
        /// </summary>
        /// <returns>所有日志信息</returns>
        IList<DBLogInfo> GetAllDBLog();
    }
}
