using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;
using System.Text.RegularExpressions;

namespace LFAutomationUI.BLL
{
    public class LFHeatQuality
    {
        private static readonly IHeatQuality dal = LFAutomationUI.DALFactory.DataAccess.CreateHeatQuality();

        /// <summary>
        /// 获取所有LF炉次化验信息
        /// </summary>
        /// <returns>LF炉次化验信息</returns>
        public IList<LFHeatQualityInfo> GetAllLFHeatQualityInfo()
        {
            IList<HeatQualityInfo> heatQualityList = dal.GetAllHeatQualityInfo();
            return (from i in heatQualityList
                    where Regex.IsMatch(i.SamplePlace.ToUpper(), @"LF")
                    select i).Cast<LFHeatQualityInfo>().ToList<LFHeatQualityInfo>();
        }

        /// <summary>
        /// 根据炉次号获取LF化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>LF化验信息</returns>
        public IList<LFHeatQualityInfo> GetLFHeatQualityInfo(string heatId)
        {
            IList<HeatQualityInfo> heatQualityList = dal.GetHeatQualityInfo(heatId);
            return (from i in heatQualityList
                    where Regex.IsMatch(i.SamplePlace.ToUpper(), @"LF")
                    select i).Cast<LFHeatQualityInfo>().ToList<LFHeatQualityInfo>();
        }

        /// <summary>
        /// 根据炉次号和处理次数获取LF化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">处理次数</param>
        /// <returns>LF化验信息</returns>
        public IList<LFHeatQualityInfo> GetLFHeatQualityInfo(string heatId,int treatmentCount)
        {
            IList<HeatQualityInfo> heatQualityList = dal.GetHeatQualityInfo(heatId,treatmentCount);
            return (from i in heatQualityList
                    where Regex.IsMatch(i.SamplePlace.ToUpper(), @"LF")
                    select i).Cast<LFHeatQualityInfo>().ToList<LFHeatQualityInfo>();
        }
    }
}
