using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.BLL
{
    public class BOFHeatQuality
    {
        private static readonly IHeatQuality dal = LFAutomationUI.DALFactory.DataAccess.CreateHeatQuality();

        /// <summary>
        /// 获取所有BOF炉次化验信息
        /// </summary>
        /// <returns>BOF炉次化验信息</returns>
        public IList<BOFHeatQualityInfo> GetAllBOFHeatQualityInfo()
        {
            IList<HeatQualityInfo> heatQualityList = dal.GetAllHeatQualityInfo();
            return (from i in heatQualityList
                    where Regex.IsMatch(i.SamplePlace.ToUpper(), @"BOF")
                    select i).Cast<BOFHeatQualityInfo>().ToList<BOFHeatQualityInfo>();
        }


        /// <summary>
        /// 根据炉次获取BOF炉次化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>BOF炉次化验信息</returns>
        public IList<BOFHeatQualityInfo> GetBOFHeatQualityInfo(string heatId)
        {
            IList<HeatQualityInfo> heatQualityList = dal.GetHeatQualityInfo(heatId);
            return (from i in heatQualityList
                    where Regex.IsMatch(i.SamplePlace.ToUpper(), @"BOF")
                    select i).Cast<BOFHeatQualityInfo>().ToList<BOFHeatQualityInfo>();
        }

        /// <summary>
        /// 根据炉次获取BOF炉次化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">处理次数</param>
        /// <returns>BOF炉次化验信息</returns>
        public IList<BOFHeatQualityInfo> GetBOFHeatQualityInfo(string heatId, int treatmentCount)
        {
            IList<HeatQualityInfo> heatQualityList = dal.GetHeatQualityInfo(heatId, treatmentCount);
            return (from i in heatQualityList
                    where Regex.IsMatch(i.SamplePlace.ToUpper(), @"BOF")
                    select i).Cast<BOFHeatQualityInfo>().ToList<BOFHeatQualityInfo>();
        }
    }
}
