using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface ISource
    {
        /// <summary>
        /// 取得所有料仓信息（TB_Source_INFO）
        /// </summary>
        /// <returns>料仓信息</returns>
        IList<SourceInfo> GetSourceInfo();

        /// <summary>
        /// 通过物料来源类型和编号更新信息
        /// </summary>
        /// <param name="source">物料来源信息</param>
        void UpdataSourceInfo(SourceInfo source);

        /// <summary>
        /// 把LFDBUSER的TB_SILO_INFO的每个料仓的信息更新到LFOPCUSER中TB_OPC_ITEM_INFO
        /// </summary>
        void UpdataOPCSiloInfo();

        /// <summary>
        /// 更新各料仓合金计算的值
        /// </summary>
        void UpdateOpcSiloCalculateValue(double[] calCulateValue,int carId);
    }
}
