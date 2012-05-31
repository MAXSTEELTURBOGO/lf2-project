using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CSharp;
using LFAutomationUI.Model;
using System.Collections.Generic;
using System.Linq;

namespace LFAutomationUI.BLL
{
    public class FormulaCalculator
    {
        public FormulaCalculator() { }

        /// <summary>
        /// 计算公式值
        /// </summary>
        /// <param name="formulaString">公式字符串</param>
        /// <param name="errorMessage">出错信息</param>
        /// <param name="result">计算结果</param>
        /// <returns>指示是否计算成功</returns>
        //public bool CalculateFormulaValue(string formulaString, out string errorMessage, out double result)
        //{
        //    errorMessage = null;
        //    result = 0;
        //    try
        //    {
        //        CSharpCodeProvider csharpCodeProvider = new CSharpCodeProvider();
        //        ICodeCompiler compiler = csharpCodeProvider.CreateCompiler();
        //        CompilerParameters cp = new CompilerParameters();
        //        cp.ReferencedAssemblies.Add("system.dll");
        //        cp.CompilerOptions = "/t:library";
        //        cp.GenerateInMemory = true;
        //        string myCode = this.ConstructCEquityClassString(formulaString);
        //        CompilerResults cr = compiler.CompileAssemblyFromSource(cp, myCode);
        //        Assembly assembly = cr.CompiledAssembly;
        //        object tmp = assembly.CreateInstance("LFAutomationUI.BLL.DynamicFormula");
        //        Type type = tmp.GetType();
        //        MethodInfo mi = type.GetMethod("GetFormulaValue");
        //        result = Convert.ToDouble(mi.Invoke(tmp, null));

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        errorMessage = ex.Message;
        //        return false;
        //    }

        //}

        /// <summary>
        /// 构造动态类
        /// </summary>
        /// <param name="formulaString">公式字符串</param>
        /// <returns></returns>
        public string ConstructCEquityClassString(string formulaString)
        {
            StringBuilder myCode = new StringBuilder();
            myCode.Append("using System;");
            myCode.Append("namespace LFAutomationUI.BLL");
            myCode.Append("{");
            myCode.Append("   public class DynamicFormula");
            myCode.Append("   {");
            myCode.Append("       public double GetFormulaValue()");
            myCode.Append("       {");
            myCode.Append("             return " + formulaString + ";");
            myCode.Append("       }");
            myCode.Append("   }");
            myCode.Append("}");
            return myCode.ToString();
        }

        /// <summary>
        /// 将原公式中的元素名称使用该元素的化验值代替
        /// </summary>
        /// <param name="qualityList">化验信息</param>
        /// <param name="originalFormula">原公式</param>
        /// <returns>替换后的数字公式</returns>
        public string FormulaParse(IList<QualityInfo> qualityList, string originalFormula)
        {
            string parseFormula = originalFormula;
            parseFormula=Regex.Replace(parseFormula, "（", "(");
            parseFormula=Regex.Replace(parseFormula, "）", ")");
            parseFormula=Regex.Replace(parseFormula, "＋", "+");
            parseFormula=Regex.Replace(parseFormula, "－", "-");
            parseFormula=Regex.Replace(parseFormula, "＊", "*");
            parseFormula=Regex.Replace(parseFormula, "／", "/");

            MatchCollection matchList = Regex.Matches(originalFormula, @"[a-zA-Z]+", RegexOptions.IgnoreCase);

            

            for (int i = 0; i < matchList.Count; i++)
            {
                try
                {
                    QualityInfo quality = qualityList.Single<QualityInfo>(j => j.Element.ElementShortName == matchList[i].Value.ToUpper());
                    string pattern = @"\b" + matchList[i].Value.ToUpper() + @"\b";
                    parseFormula = Regex.Replace(parseFormula.ToString(), pattern, quality.QualityValue.HasValue? quality.QualityValue.ToString():"0",RegexOptions.IgnoreCase);
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return parseFormula;
        }
    }
}
