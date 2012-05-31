using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface ITransformerParam
    {
        /// <summary>
        /// 从数据库获取所有的变压器参数信息
        /// </summary>
        /// <returns>变压器参数信息列表</returns>
        IList<TransformerParamInfo> GetAllTransFormerParamInfo();

        /// <summary>
        /// 删除指定变压器档位及其设定点的信息
        /// </summary>
        /// <param name="tapPosition">变压器档位</param>
        /// <param name="tapPoint">变压器单位设定点</param>
        void DelTransParamInfoByTapPositionAndTapPoint(int tapPosition, int tapPoint);

        /// <summary>
        /// 插入一条变压器参数信息
        /// </summary>
        /// <param name="transformerInfo">新增的变压器参数信息</param>
        void InsTransParamInfo(TransformerParamInfo transformerInfo);

        /// <summary>
        /// 根据变压器档位、设定点更新温升信息
        /// </summary>
        /// <param name="tapPosition">档位</param>
        /// <param name="tapPositionPoint">档位设定点</param>
        /// <param name="chillFactor">升温系数</param>
        void UpdateTransParam(int tapPosition, int tapPositionPoint, double chillFactor);
    }
}
