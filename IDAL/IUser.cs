using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IUser
    {
        /// <summary>
        /// 根据用户名和密码获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPassword">密码</param>
        /// <returns>用户信息</returns>
        UserInfo GetUserInfo(string userName,string userPassword);

        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>用户信息</returns>
        UserInfo GetUserInfo(string userName);

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns>所有用户信息</returns>
        IList<UserInfo> GetAllUsers();

        /// <summary>
        /// 插入用户信息
        /// </summary>
        /// <param name="user">要插入的用户信息</param>
        void InsertUserInfo(UserInfo user);

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user">用户信息</param>
        void UpdateUserInfo(UserInfo user);


        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="user">用户</param>
        void DeleteUserInfo(UserInfo user);

        /// <summary>
        /// 删除指定用户的角色信息
        /// </summary>
        /// <param name="user">用户</param>
        void DeleteUserRoleInfo(UserInfo user);

        /// <summary>
        /// 插入用户的角色信息
        /// </summary>
        /// <param name="user">用户</param>
        void InsertUserRoleInfo(UserInfo user);
    }
}
