using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;
using System.Web.Configuration;

namespace LFAutomationUI.DALFactory
{
    /// <summary>
    /// This class is implemented following the Abstract Factory pattern to create the DAL implementation
    /// specified from the configuration file
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly String path = System.Web.Configuration.WebConfigurationManager.AppSettings["DAL"];
        private DataAccess() { }

        public static LFAutomationUI.IDAL.ITreatmentStation CreateTreatmentStation()
        {
            string className = path + ".TreatmentStation";
            return (LFAutomationUI.IDAL.ITreatmentStation)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.IAdditionRecord CreateAdditionRecord()
        {
            string className = path + ".AdditionRecord";
            return (LFAutomationUI.IDAL.IAdditionRecord)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.IBasic CreateBasic()
        {
            string className = path + ".Basic";
            return (LFAutomationUI.IDAL.IBasic)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.ITempOxygenRecord CreateTempOxygenRecord()
        {
            string className = path + ".TempOxygenRecord";
            return (LFAutomationUI.IDAL.ITempOxygenRecord)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.IPowerOnRecord CreatePowerOnRecord()
        {
            string className = path + ".PowerOnRecord";
            return (LFAutomationUI.IDAL.IPowerOnRecord)Assembly.Load(path).CreateInstance(className);
        }
        
        public static LFAutomationUI.IDAL.IMaterial CreateMaterial()
        {
            string className = path + ".Material";
            return (LFAutomationUI.IDAL.IMaterial)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.IMaterialAnalysis CreateMaterialAnalysis()
        {
            string className = path + ".MaterialAnalysis";
            return (LFAutomationUI.IDAL.IMaterialAnalysis)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.IMaterialType CreateMaterialType()
        {
            string className = path + ".MaterialType";
            return (LFAutomationUI.IDAL.IMaterialType)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.IEventRecord CreateEventRecord()
        {
            string className = path + ".EventRecord";
            return (LFAutomationUI.IDAL.IEventRecord)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.IElement CreateElementInfo()
        {
            string className = path + ".Element";
            return (LFAutomationUI.IDAL.IElement)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.IRoute CreateRoute()
        {
            string className = path + ".Route";
            return (LFAutomationUI.IDAL.IRoute)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.ISteelGradeDetails CreateSteelGrade()
        {
            string className = path + ".SteelGradeDetails";
            return (LFAutomationUI.IDAL.ISteelGradeDetails)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.ISteelAnalysis CreateSteelAnalysis()
        {
            string className = path + ".SteelAnalysis";
            return (LFAutomationUI.IDAL.ISteelAnalysis)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.ISource CreateSource()
        {
            string className = path + ".Source";
            return (LFAutomationUI.IDAL.ISource)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.IStep CreateStep()
        {
            string className = path + ".Step";
            return (LFAutomationUI.IDAL.IStep)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.ITransformerParam CreateTransformerParam()
        {
            string className = path + ".TransformerParam";
            return (LFAutomationUI.IDAL.ITransformerParam)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.ITechnics CreateTechnics()
        {
            string className = path + ".Technic";
            return (LFAutomationUI.IDAL.ITechnics)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.ITechnicStep CreateTechnicStep()
        {
            string className = path + ".TechnicStep";
            return (LFAutomationUI.IDAL.ITechnicStep)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.IFormula CreateFormula()
        {
            string className = path + ".Formula";
            return (LFAutomationUI.IDAL.IFormula)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.IUser CreateUser()
        {
            string className = path + ".User";
            return (LFAutomationUI.IDAL.IUser)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.IRole CreateRole()
        {
            string className = path + ".Role";
            return (LFAutomationUI.IDAL.IRole)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.IPrivilege CreatePrivilege()
        {
            string className = path + ".Privilege";
            return (LFAutomationUI.IDAL.IPrivilege)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.IClasses CreateClasses()
        {
            string className = path + ".Classes";
            return (LFAutomationUI.IDAL.IClasses)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.ILogin CreateLogin()
        {
            string className = path + ".Login";
            return (LFAutomationUI.IDAL.ILogin)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.ICCMHeat CreateCCMHeat()
        {
            string className = path + ".CCMHeat";
            return (LFAutomationUI.IDAL.ICCMHeat)Assembly.Load(path).CreateInstance(className);
        }
        public static LFAutomationUI.IDAL.IDBLog CreateDBLog()
        {
            string className = path + ".DBLog";
            return (LFAutomationUI.IDAL.IDBLog)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.ILadle CreateLadle()
        {
            string className = path + ".Ladle";
            return (LFAutomationUI.IDAL.ILadle)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.IStatus CreateStatus()
        {
            string className = path + ".Status";
            return (LFAutomationUI.IDAL.IStatus)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.IHeatQuality CreateHeatQuality()
        {
            string className = path + ".HeatQuality";
            return (LFAutomationUI.IDAL.IHeatQuality)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.IQualityHorizontal CreateQualityHorizontal()
        {
            string className = path + ".QualityHorizontal";
            return (LFAutomationUI.IDAL.IQualityHorizontal)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.ISlagQualityHorizontal CreateSlagQualityHorizontal()
        {
            string className = path + ".SlagQualityHorizontal";
            return (LFAutomationUI.IDAL.ISlagQualityHorizontal)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.IHeatSlagQuality CreateHeatSlagQuality()
        {
            string className = path + ".HeatSlagQuality";
            return (LFAutomationUI.IDAL.IHeatSlagQuality)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.ILFHeatStatus CreateLFHeatStatus()
        {
            string className = path + ".LFHeatStatus";
            return (LFAutomationUI.IDAL.ILFHeatStatus)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.IEquipment CreateEquipment()
        {
            string className = path + ".Equipment";
            return (LFAutomationUI.IDAL.IEquipment)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.ILFHeat CreateLFHeat()
        {
            string className = path + ".LFHeat";
            return (LFAutomationUI.IDAL.ILFHeat)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.IBOFHeatStatus CreateBOFHeatStatus()
        {
            string className = path + ".BOFHeatStatus";
            return (LFAutomationUI.IDAL.IBOFHeatStatus)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.IRHHeatStatus CreateRHHeatStatus()
        {
            string className = path + ".RHHeatStatus";
            return (LFAutomationUI.IDAL.IRHHeatStatus)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.IBOFHeat CreateBOFHeat()
        {
            string className = path + ".BOFHeat";
            return (LFAutomationUI.IDAL.IBOFHeat)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.IBOFAddition CreateBOFAddition()
        {
            string className = path + ".BOFAddition";
            return (LFAutomationUI.IDAL.IBOFAddition)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.IRealTime CreateRealTime()
        {
            string className = path + ".RealTime";
            return (LFAutomationUI.IDAL.IRealTime)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.ICCMHeatReport CreateCCMHeatReport()
        {
            string className = path + ".CCMHeatReport";
            return (LFAutomationUI.IDAL.ICCMHeatReport)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.ICCMSlabReport CreateCCMSlabReport()
        {
            string className = path + ".CCMSlabReport";
            return (LFAutomationUI.IDAL.ICCMSlabReport)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.ICCMHeatStatus CreateCCMHeatStatus()
        {
            string className = path + ".CCMHeatStatus";
            return (LFAutomationUI.IDAL.ICCMHeatStatus)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.ITempEstimateBasic CreateTempEstimateBasic()
        {
            string className = path + ".TempEstimateBasic";
            return (LFAutomationUI.IDAL.ITempEstimateBasic)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.ITempEstimateCoeffic CreateTempEstimateCoeffic()
        {
            string className = path + ".TempEstimateCoeffic";
            return (LFAutomationUI.IDAL.ITempEstimateCoeffic)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.ITempEstimate CreateTempEstimate()
        {
            string className = path + ".TempEstimate";
            return (LFAutomationUI.IDAL.ITempEstimate)Assembly.Load(path).CreateInstance(className);
        }

        public static LFAutomationUI.IDAL.IRecipe CreateRecipe()
        {
            string className = path + ".Recipe";
            return (LFAutomationUI.IDAL.IRecipe)Assembly.Load(path).CreateInstance(className);
        }
    }
}
