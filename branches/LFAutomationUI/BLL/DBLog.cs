using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;

namespace LFAutomationUI.BLL
{
    public class DBLog
    {
        private static readonly IDBLog dal = LFAutomationUI.DALFactory.DataAccess.CreateDBLog();

        /// <summary>
        /// 插入数据库日志信息
        /// </summary>
        /// <param name="dbLog">日志信息</param>
        public void InsertDBLogInfo(DBLogInfo dbLog)
        {
            dal.InsertDBLogInfo(dbLog);
        }


        /// <summary>
        /// 获取所有日志信息
        /// </summary>
        /// <returns>所有日志信息</returns>
        public IList<DBLogInfo> GetAllDBLog()
        {
            return dal.GetAllDBLog();
        }
    }
}
