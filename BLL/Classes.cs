using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.BLL
{
    public class Classes
    {
        private static readonly IClasses dal = LFAutomationUI.DALFactory.DataAccess.CreateClasses();

        /// <summary>
        /// 获取所有班组信息
        /// </summary>
        /// <returns>所有班组信息</returns>
        public IList<ClassesInfo> GetAllClasses()
        {
            return dal.GetAllClasses();
        }

        /// <summary>
        /// 根据班组名称获取班组信息
        /// </summary>
        /// <param name="classId">班组名</param>
        /// <returns>班组信息</returns>
        public ClassesInfo GetClassInfo(string classId)
        {
            return dal.GetClassInfo(classId);
        }

        /// <summary>
        /// 插入指定的班组信息
        /// </summary>
        /// <param name="cls">班组信息</param>
        public void InsertClassInfo(ClassesInfo cls)
        {
            dal.InsertClassInfo(cls);
        }

        /// <summary>
        /// 更新指定班组的信息
        /// </summary>
        /// <param name="cls">班组信息</param>
        public void UpdateClassInfo(ClassesInfo cls)
        {
            dal.UpdateClassInfo(cls);
        }

        /// <summary>
        /// 删除指定班组的信息
        /// </summary>
        /// <param name="cls">班组信息</param>
        public void DeleteClassInfo(ClassesInfo cls)
        {
            dal.DeleteClassInfo(cls);
        }
    }
}
