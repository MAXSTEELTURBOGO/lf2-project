using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface ILogin
    {
        /// <summary>
        /// 获取所有登录信息
        /// </summary>
        /// <returns>所有登录信息</returns>
        IList<LoginInfo> GetAllLoginInfo();

        /// <summary>
        /// 根据用户获取该用户的登录信息
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>指定用户的登录信息</returns>
        IList<LoginInfo> GetLoginInfo(UserInfo user);

        /// <summary>
        /// 获取某时间段的所有登录信息
        /// </summary>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>指定时间段的登录信息</returns>
        IList<LoginInfo> GetLoginInfo(DateTime startTime, DateTime endTime);

        /// <summary>
        /// 插入登录信息
        /// </summary>
        /// <param name="user">登录信息</param>
        void InsertLoginInfo(LoginInfo login);

        /// <summary>
        /// 更新登录信息
        /// </summary>
        /// <param name="login">登录信息</param>
        void UpdateLoginInfo(LoginInfo login);
    }
}
