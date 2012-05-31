using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;
using LFAutomationUI.DALFactory;

namespace LFAutomationUI.BLL
{
    public class Source
    {
        private static readonly ISource dal = LFAutomationUI.DALFactory.DataAccess.CreateSource();
        
        /// <summary>
        /// 取得所有料仓信息（TB_SILO_INFO）
        /// </summary>
        /// <returns>料仓信息</returns>
        public IList<SourceInfo> GetSourceInfo()
        {
            return dal.GetSourceInfo();
        }

        /// <summary>
        /// 通过物料来源类型和编号更新信息
        /// </summary>
        /// <param name="source">物料来源信息</param>
        public void UpdataSourceInfo(SourceInfo source)
        {
            dal.UpdataSourceInfo(source);
        }

        /// <summary>
        /// 把LFDBUSER的TB_SILO_INFO的每个料仓的信息更新到LFOPCUSER中TB_OPC_ITEM_INFO
        /// </summary>
        public void UpdataOPCSiloInfo()
        {
            dal.UpdataOPCSiloInfo();
        }

                /// <summary>
        /// 更新各料仓合金计算的值
        /// </summary>
        public void UpdateOpcSiloCalculateValue(double[] calCulateValue, int carId)
        {
            dal.UpdateOpcSiloCalculateValue(calCulateValue, carId);
        }
    }
}
