using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;
using LFAutomationUI.DALFactory;

namespace LFAutomationUI.BLL
{
    public class MaterialAnalysis
    {
        private static readonly IMaterialAnalysis dal = LFAutomationUI.DALFactory.DataAccess.CreateMaterialAnalysis();

        /// <summary>
        /// 通过物料代码获取该物料的含量信息
        /// </summary>
        /// <param name="materialId">物料代码</param>
        /// <returns>含量信息</returns>
        public IList<MaterialAnalysisInfo> GetMaterialAnalysisByMaterialid(int materialId)
        {
            return dal.GetMaterialAnalysisByMaterialid(materialId);
        }

        /// <summary>
        /// 给物料元素信息表插入元素含量与收得率信息
        /// </summary>
        /// <param name="materialAnalysisInfos">物料元素信息</param>
        public void InsertMaterialAnalysisInfo(IList<MaterialAnalysisInfo> materialAnalysisInfos)
        {
            dal.InsertMaterialAnalysisInfo(materialAnalysisInfos);
        }

        /// <summary>
        /// 通过物料代码删除物料元素信息
        /// </summary>
        /// <param name="materialId">物料代码</param>
        public void DeleteMaterialAnalysisInfoByMatId(decimal materialId)
        {
            dal.DeleteMaterialAnalysisInfoByMatId(materialId);
        }
    }
}
