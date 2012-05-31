using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;

namespace LFAutomationUI.BLL
{
    public class Login
    {
        private static readonly ILogin dal = DALFactory.DataAccess.CreateLogin();

        /// <summary>
        /// 获取所有登录信息
        /// </summary>
        /// <returns>所有登录信息</returns>
        public IList<LoginInfo> GetAllLoginInfo()
        {
            return dal.GetAllLoginInfo();
        }

        /// <summary>
        /// 根据用户获取该用户的登录信息
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>指定用户的登录信息</returns>
        public IList<LoginInfo> GetLoginInfo(UserInfo user)
        {
            return dal.GetLoginInfo(user);
        }

        /// <summary>
        /// 获取某时间段的所有登录信息
        /// </summary>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>指定时间段的登录信息</returns>
        public IList<LoginInfo> GetLoginInfo(DateTime startTime, DateTime endTime)
        {
            return dal.GetLoginInfo(startTime, endTime);
        }

        /// <summary>
        /// 插入登录信息
        /// </summary>
        /// <param name="user">登录信息</param>
        public void InsertLoginInfo(LoginInfo login)
        {
            dal.InsertLoginInfo(login);
        }

        /// <summary>
        /// 更新登录信息
        /// </summary>
        /// <param name="login">登录信息</param>
        public void UpdateLoginInfo(LoginInfo login)
        {
            dal.UpdateLoginInfo(login);
        }
    }
}
