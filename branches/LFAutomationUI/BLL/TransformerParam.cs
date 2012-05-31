using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;
using LFAutomationUI.DALFactory;

namespace LFAutomationUI.BLL
{
    public class TransformerParam
    {
        private static readonly ITransformerParam dal = LFAutomationUI.DALFactory.DataAccess.CreateTransformerParam();

        /// <summary>
        /// 从数据库获取所有的变压器参数信息
        /// </summary>
        /// <returns>变压器参数信息列表</returns>
        public IList<TransformerParamInfo> GetAllTransFormerParamInfo()
        {
            return dal.GetAllTransFormerParamInfo();
        }

        /// <summary>
        /// 删除指定变压器档位及其设定点的信息
        /// </summary>
        /// <param name="tapPosition">变压器档位</param>
        /// <param name="tapPoint">变压器单位设定点</param>
        public void DelTransParamInfoByTapPositionAndTapPoint(int tapPosition, int tapPoint)
        {
            dal.DelTransParamInfoByTapPositionAndTapPoint(tapPosition, tapPoint);
        }

        /// <summary>
        /// 插入一条变压器参数信息
        /// </summary>
        /// <param name="transformerInfo">新增的变压器参数信息</param>
        public void InsTransParamInfo(TransformerParamInfo transformerInfo)
        {
            dal.InsTransParamInfo(transformerInfo);
        }

        /// <summary>
        /// 根据变压器档位、设定点更新温升信息
        /// </summary>
        /// <param name="tapPosition">档位</param>
        /// <param name="tapPositionPoint">档位设定点</param>
        /// <param name="chillFactor">升温系数</param>
        public void UpdateTransParam(int tapPosition, int tapPositionPoint, double chillFactor)
        {
            dal.UpdateTransParam(tapPosition, tapPositionPoint, chillFactor);
        }
    }
}
