using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IMaterialAnalysis
    {
        /// <summary>
        /// 取得所有物料的元素分析信息
        /// </summary>
        /// <returns>元素分析信息</returns>
        IList<MaterialAnalysisInfo> GetAllMaterialAnalysis();

        /// <summary>
        /// 通过物料代码获取该物料的含量信息
        /// </summary>
        /// <param name="materialId">物料代码</param>
        /// <returns>含量信息</returns>
        IList<MaterialAnalysisInfo> GetMaterialAnalysisByMaterialid(int materialId);

        /// <summary>
        /// 给物料元素信息表插入元素含量与收得率信息
        /// </summary>
        /// <param name="materialAnalysisInfos">物料元素信息</param>
        void InsertMaterialAnalysisInfo(IList<MaterialAnalysisInfo> materialAnalysisInfos);

        /// <summary>
        /// 通过物料代码删除物料元素信息
        /// </summary>
        /// <param name="materialId">物料代码</param>
        void DeleteMaterialAnalysisInfoByMatId(decimal materialId);
    }
}
