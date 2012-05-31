using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IMaterial
    {
        /// <summary>
        /// 取得所有的物料信息
        /// </summary>
        /// <returns>物料信息</returns>
        IList<MaterialInfo> GetAllMaterialInfos();
        /// <summary>
        /// 根据物料代码取得物料信息
        /// </summary>
        /// <param name="materialId">物料代码</param>
        /// <returns>物料信息</returns>
        MaterialInfo GetMaterialInfoByMaterialId(decimal materialId);
        /// <summary>
        /// 插入新的物料信息
        /// </summary>
        /// <param name="materialInfo">物料信息内容</param>
        void InsertMaterialInfo(MaterialInfo materialInfo);
        /// <summary>
        /// 根据物料代码删除物料信息
        /// </summary>
        /// <param name="materialId">物料代码</param>
        void DeleteMaterialInfo(decimal materialId);
        /// <summary>
        /// 根据物料ID更新物料信息
        /// </summary>
        /// <param name="materialInfo">物料信息内容</param>
        void UpdateMaterialInfo(MaterialInfo materialInfo);

        /// <summary>
        /// 根据物料ID更新物料温降信息
        /// </summary>
        /// <param name="materialId">物料ID</param>
        /// <param name="chillFactor">温降值</param>
        void UpdateMaterialInfo(int materialId, double chillFactor);
    }
}
