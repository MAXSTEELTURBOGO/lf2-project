using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;

namespace LFAutomationUI.BLL
{
    public class User
    {
        private static readonly IUser dal=LFAutomationUI.DALFactory.DataAccess.CreateUser();

        /// <summary>
        /// 根据用户名和密码获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPassword">密码</param>
        /// <returns>用户信息</returns>
        public UserInfo GetUserInfo(string userName, string userPassword)
        {
            return dal.GetUserInfo(userName, userPassword);
        }

        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>用户信息</returns>
        public UserInfo GetUserInfo(string userName)
        {
            return dal.GetUserInfo(userName);
        }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns>所有用户信息</returns>
        public IList<UserInfo> GetAllUsers()
        {
            return dal.GetAllUsers();
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="newPassword">新密码</param>
        public void ModifyPassword(UserInfo user,string newPassword)
        {
            user.UserPassword = newPassword;
            dal.UpdateUserInfo(user);
        }

        /// <summary>
        /// 插入用户信息
        /// </summary>
        /// <param name="user">要插入的用户信息</param>
        public void InsertUserInfo(UserInfo user)
        {
            dal.InsertUserInfo(user);
            UserInfo tempUser = dal.GetUserInfo(user.UserName);
            user.UserId = tempUser.UserId;
            dal.InsertUserRoleInfo(user);
        }

        /// <summary>
        /// 更新指定用户的信息
        /// </summary>
        /// <param name="user">用户信息</param>
        public void UpdateUserInfo(UserInfo user)
        {
            dal.UpdateUserInfo(user);
            dal.DeleteUserRoleInfo(user);
            if (user.Roles.Count > 0)
            {
                dal.InsertUserRoleInfo(user);
            }
        }

        /// <summary>
        /// 删除指定用户的信息
        /// </summary>
        /// <param name="user">用户信息</param>
        public void DeleteUserInfo(UserInfo user)
        {
            dal.DeleteUserInfo(user);
        }
    }
}
