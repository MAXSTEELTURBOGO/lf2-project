using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.BLL
{
    public class Element
    {
        private static readonly IElement dal = LFAutomationUI.DALFactory.DataAccess.CreateElementInfo();


        /// <summary>
        /// 获取所有元素的信息
        /// </summary>
        /// <returns></returns>
        public  IList<ElementInfo> GetElementList()
        {
            return dal.GetElementList();
        }
        
        
        /// <summary>
        /// 取得所有的元素信息和化合物信息
        /// </summary>
        /// <returns>元素信息和化合物信息</returns>
        public IList<ElementInfo> getElementAndCompoundInfo()
        {
            IList<ElementInfo> elementInfoList;
            elementInfoList = dal.GetElementInfo();
            foreach (ElementInfo item in dal.GetCompoundInfo())
            {
                elementInfoList.Add(item);
            }
            return elementInfoList;
        }
        
        /// <summary>
        /// 取得元素信息
        /// </summary>
        /// <returns>元素信息（包括：元素代码、元素简称、元素全称）</returns>
        public IList<ElementInfo> GetElementInfo()
        {
            return dal.GetElementInfo();
        }
        /// <summary>
        /// 取得化合物信息
        /// </summary>
        /// <returns>化合物信息</returns>
        public IList<ElementInfo> GetCompoundInfo()
        {
            return dal.GetCompoundInfo();
        }
        /// <summary>
        /// 删除指定元素信息
        /// </summary>
        /// <param name="elementId">元素号</param>
        public void DeleteElementInfoByElementId(int elementId)
        {
            dal.DeleteElementInfoByElementId(elementId);
        }
                /// <summary>
        /// 插入元素信息
        /// </summary>
        /// <param name="eleme">元素信息</param>
        public void InsertElementInfo(ElementInfo elem)
        {
            dal.InsertElementInfo(elem);
        }
        /// <summary>
        /// 由元素号得到该元素号的元素信息
        /// </summary>
        /// <param name="elementId">元素号</param>
        /// <returns>元素信息</returns>
        public ElementInfo GetElementInfoByElementId(int elementId)
        {
            return dal.GetElementInfoByElementId(elementId);
        }

    }
}
