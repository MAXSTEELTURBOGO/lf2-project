using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IClasses
    {

        /// <summary>
        /// 获取所有班组信息
        /// </summary>
        /// <returns>所有班组信息</returns>
        IList<ClassesInfo> GetAllClasses();

        /// <summary>
        /// 根据班组名称获取班组信息
        /// </summary>
        /// <param name="classId">班组名</param>
        /// <returns>班组信息</returns>
        ClassesInfo GetClassInfo(string classId);


        /// <summary>
        /// 插入指定的班组信息
        /// </summary>
        /// <param name="cls">班组信息</param>
        void InsertClassInfo(ClassesInfo cls);

        /// <summary>
        /// 更新指定班组的信息
        /// </summary>
        /// <param name="cls">班组信息</param>
        void UpdateClassInfo(ClassesInfo cls);

        /// <summary>
        /// 删除指定班组的信息
        /// </summary>
        /// <param name="cls">班组信息</param>
        void DeleteClassInfo(ClassesInfo cls);
    }
}
