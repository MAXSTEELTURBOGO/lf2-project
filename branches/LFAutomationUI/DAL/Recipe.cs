using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;
using LFAutomationUI.DBUtility;

namespace LFAutomationUI.DAL
{
    public class Recipe : IRecipe
    {
        #region SQL && PARAMETERS

        private string SQL_GET_ALL_MATERIAL_RECIPE = @"SELECT  RECIPE_ID,
                                                               RECIPE_NAME,
                                                               RECIPE_TYPE,
                                                               RECIPE_DESC,
                                                               MATERIAL_ID,
                                                               MATERIAL_NAME,
                                                               YIELD,
                                                               ELEMENT_ID,
                                                               CHIEF_ELEMENT_NAME,
                                                               CHIEF_ELEMENT_CONTENT
                                                          FROM V_RECIPE_CHIEF_ELEMENT_INFO T";
        private string SQL_INSERT_RECIPE_INFO = @"INSERT INTO TB_RECIPE_INFO
                                                      (RECIPE_ID, RECIPE_TYPE, RECIPE_NAME, RECIPE_DESC)
                                                    VALUES
                                                      (:RECIPE_ID, :RECIPE_TYPE, :RECIPE_NAME, :RECIPE_DESC)";
        private string SQL_INSERT_MATERIAL_RECIPE_INFO = @"INSERT INTO TB_MATERIAL_RECIPE
                                                              (RECIPE_ID, MATERIAL_ID)
                                                            VALUES
                                                              (:RECIPE_ID, :MATERIAL_ID)";
        private string SQL_DELETE_MATERIAL_RECIPE = "DELETE FROM TB_RECIPE_INFO T WHERE T.RECIPE_ID = :RECIPE_ID";

        private string PARAM_RECIPE_ID = ":RECIPE_ID";
        private string PARAM_RECIPE_NAME = ":RECIPE_NAME";
        private string PARAM_RECIPE_TYPE = ":RECIPE_TYPE";
        private string PARAM_RECIPE_DESC = ":RECIPE_DESC";
        private string PARAM_MATERIAL_ID = ":MATERIAL_ID";
        #endregion


        /// <summary>
        /// 获取所有物料配方信息
        /// </summary>
        /// <returns>物料配方信息</returns>
        public IList<RecipeInfo> GetMaterialRecipe()
        {
            IList<RecipeInfo> materialRecipeList = new List<RecipeInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_GET_ALL_MATERIAL_RECIPE, null))
            {
                DataTable dt = new DataTable();
                dt.Load(odr);
                if (dt.Rows.Count > 0)
                {
                    var enumRepiceBasicInfo = (from i in dt.AsEnumerable()
                                               select new
                                               {
                                                   RepiceId = Convert.ToDecimal(i["RECIPE_ID"]),
                                                   RepiceName = i["RECIPE_NAME"].ToString(),
                                                   RecipeType = i["RECIPE_TYPE"].ToString(),
                                                   RecipeDesc = i["RECIPE_DESC"] == DBNull.Value ? null : i["RECIPE_DESC"].ToString()
                                               }).Distinct();
                    foreach (var item in enumRepiceBasicInfo)
                    {
                        RecipeInfo recipeInfo = new RecipeInfo();
                        recipeInfo.RecipeId = item.RepiceId;
                        recipeInfo.RecipeName = item.RepiceName;
                        recipeInfo.RecipeType = item.RecipeType;
                        recipeInfo.RecipeDesc = item.RecipeDesc;
                        materialRecipeList.Add(recipeInfo);
                    }
                    var enumRecipeMatInfo = (from i in dt.AsEnumerable()
                                             where i["MATERIAL_ID"]!=DBNull.Value
                                             select new
                                             {
                                                 RecipeId = Convert.ToDecimal(i["RECIPE_ID"]),
                                                 MaterialId = Convert.ToDecimal(i["MATERIAL_ID"]),
                                                 MaterialName = i["MATERIAL_NAME"].ToString(),
                                                 Yield = Convert.ToDouble(i["YIELD"]),
                                                 ElementId = i["ELEMENT_ID"] == DBNull.Value ? null : new Nullable<Int32>(Convert.ToInt32(i["ELEMENT_ID"])),
                                                 ElementShortName = i["CHIEF_ELEMENT_NAME"] == DBNull.Value ? null : i["CHIEF_ELEMENT_NAME"].ToString(),
                                                 ChiefElementContent = i["CHIEF_ELEMENT_CONTENT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(i["CHIEF_ELEMENT_CONTENT"]))
                                             });
                    foreach (RecipeInfo i in materialRecipeList)
                    {

                        IList<RecipeMaterialInfo> recipeMaterialInfos = new List<RecipeMaterialInfo>();
                        foreach (var j in enumRecipeMatInfo)
                        {
                            if (i.RecipeId == j.RecipeId)
                            {
                                RecipeMaterialInfo recipeMaterialInfo = new RecipeMaterialInfo();
                                recipeMaterialInfo.RecipeId = j.RecipeId;
                                recipeMaterialInfo.MaterialInfo.MaterialId = j.MaterialId;
                                recipeMaterialInfo.MaterialInfo.MaterialName = j.MaterialName;
                                recipeMaterialInfo.MaterialInfo.Yield = j.Yield;
                                recipeMaterialInfo.ChiefElementInfo.ElementId = j.ElementId;
                                recipeMaterialInfo.ChiefElementInfo.ElementShortName = j.ElementShortName;
                                recipeMaterialInfo.ChiefElementContent = j.ChiefElementContent;
                                recipeMaterialInfos.Add(recipeMaterialInfo);
                            }
                        }
                        i.RecipeMaterialInfo = recipeMaterialInfos;
                    }
                }
            }
            return materialRecipeList;
        }

        /// <summary>
        /// 插入新的配方信息
        /// </summary>
        public void InsertNewRecipeInfo(RecipeInfo recipeInfo)
        {
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter(PARAM_RECIPE_ID, OracleType.Number);
            param[0].Value = recipeInfo.RecipeId;
            param[1] = new OracleParameter(PARAM_RECIPE_NAME, OracleType.VarChar);
            param[1].Value = recipeInfo.RecipeName;
            param[2] = new OracleParameter(PARAM_RECIPE_TYPE, OracleType.VarChar);
            param[2].Value = recipeInfo.RecipeType;
            param[3] = new OracleParameter(PARAM_RECIPE_DESC, OracleType.VarChar);
            param[3].Value = recipeInfo.RecipeDesc == null ? DBNull.Value : (object)recipeInfo.RecipeDesc;
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_INSERT_RECIPE_INFO, param);
            foreach (RecipeMaterialInfo item in recipeInfo.RecipeMaterialInfo)
            {
                OracleParameter[] paramMatRecipe = new OracleParameter[2];
                paramMatRecipe[0] = new OracleParameter(PARAM_RECIPE_ID, OracleType.Number);
                paramMatRecipe[0].Value = item.RecipeId;
                paramMatRecipe[1] = new OracleParameter(PARAM_MATERIAL_ID, OracleType.Number);
                paramMatRecipe[1].Value = item.MaterialInfo.MaterialId;
                OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_INSERT_MATERIAL_RECIPE_INFO, paramMatRecipe);
            }
        }

        /// <summary>
        /// 删除配方信息
        /// </summary>
        /// <param name="recipeId">配方Id</param>
        public void DeleteRecipeInfo(decimal recipeId)
        {
            OracleParameter param = new OracleParameter(PARAM_RECIPE_ID, OracleType.Number);
            param.Value = recipeId;
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_DELETE_MATERIAL_RECIPE, param);
        }
    }
}
