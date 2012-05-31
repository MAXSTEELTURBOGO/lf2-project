using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using LFAutomationUI.DBUtility;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.DAL
{
    public class Status : IStatus
    {
        #region SQL AND PARAM

        private const string SQL_SELECT_ALL_STATUS_INFO = @"SELECT STATUS_ID,STATUS_NAME FROM TB_STATUS_INFO";

        #endregion

        /// <summary>
        /// 获取所有状态信息
        /// </summary>
        /// <returns>所有的状态信息</returns>
        public IList<StatusInfo> GetAllStatusInfo()
        {
            IList<StatusInfo> statusList = new List<StatusInfo>();
            using (OracleDataReader odr=OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQL_SELECT_ALL_STATUS_INFO,null))
            {
                while (odr.Read())
                {
                    int statusId = Convert.ToInt32(odr["STATUS_ID"]);
                    string statusName = odr["STATUS_NAME"].ToString();
                    StatusInfo status = new StatusInfo(statusId, statusName);
                    statusList.Add(status);
                }
            }
            return statusList;
        }
    }
}
