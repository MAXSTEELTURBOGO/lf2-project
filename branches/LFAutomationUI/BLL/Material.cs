using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.BLL
{
    public class Material
    {
        private static readonly IMaterial dal = LFAutomationUI.DALFactory.DataAccess.CreateMaterial();
        /// <summary>
        /// 取得所有的物料信息
        /// </summary>
        /// <returns>物料信息</returns>
        public IList<MaterialInfo> GetAllMaterialInfos()
        {
            return dal.GetAllMaterialInfos();
        }
        /// <summary>
        /// 根据物料代码取得物料信息
        /// </summary>
        /// <param name="materialId">物料代码</param>
        /// <returns>物料信息</returns>
        public MaterialInfo GetMaterialInfoByMaterialId(decimal materialId)
        {
            return dal.GetMaterialInfoByMaterialId(materialId);
        }
        /// <summary>
        /// 插入新的物料信息
        /// </summary>
        /// <param name="materialInfo">物料信息内容</param>
        public void InsertMaterialInfo(MaterialInfo materialInfo)
        {
            dal.InsertMaterialInfo(materialInfo);
        }
        /// <summary>
        /// 根据物料代码删除物料信息
        /// </summary>
        /// <param name="materialId">物料代码</param>
        public void DeleteMaterialInfo(decimal materialId)
        {
            dal.DeleteMaterialInfo(materialId);
        }
        /// <summary>
        /// 根据物料ID更新物料信息
        /// </summary>
        /// <param name="materialInfo">物料信息内容</param>
        public void UpdateMaterialInfo(MaterialInfo materialInfo)
        {
            dal.UpdateMaterialInfo(materialInfo);
        }

        /// <summary>
        /// 根据物料ID更新物料温降信息
        /// </summary>
        /// <param name="materialId">物料ID</param>
        /// <param name="chillFactor">温降值</param>
        public void UpdateMaterialInfo(int materialId, double chillFactor)
        {
            dal.UpdateMaterialInfo(materialId, chillFactor);
        }
    }
}
