using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IElement
    {
        /// <summary>
        /// 获取所有元素的信息
        /// </summary>
        /// <returns></returns>
        IList<ElementInfo> GetElementList();


        /// <summary>
        /// 取得元素信息
        /// </summary>
        /// <returns>元素信息（包括：元素代码、元素简称、元素全称）</returns>
        IList<ElementInfo> GetElementInfo();
        /// <summary>
        /// 取得化合物信息
        /// </summary>
        /// <returns>化合物信息</returns>
        IList<ElementInfo> GetCompoundInfo();
        /// <summary>
        /// 删除指定元素信息
        /// </summary>
        /// <param name="elementId">元素号</param>
        void DeleteElementInfoByElementId(int elementId);
        /// <summary>
        /// 插入元素信息
        /// </summary>
        ///<param name="elem">元素信息</param>
        void InsertElementInfo(ElementInfo elem);

        /// <summary>
        /// 由元素号得到该元素号的元素信息
        /// </summary>
        /// <param name="elementId">元素号</param>
        /// <returns>元素信息</returns>
        ElementInfo GetElementInfoByElementId(int elementId);
    }
}
