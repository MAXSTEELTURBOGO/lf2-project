using System.Collections.Generic;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    /// <summary>
    /// Interface to treatmentinfo
    /// </summary>
    public interface ITreatmentStation
    {
        /// <summary>
        /// Method definition to search all treatment station infromation
        /// </summary>
        /// <returns>Interface to Model Collection Generic of the results</returns>
        IList<TreatmentStationInfo> GetTreatmentStations();
        /// <summary>
        /// Method definition to search treatment station by specified treatment station name
        /// </summary>
        /// <param name="treatmentStationName">specified treatment station name</param>
        /// <returns>treatment station information with specified treatment station name</returns>
        TreatmentStationInfo GetTreatmentStationByTreatmentStationName(string treatmentStationName);
        /// <summary>
        /// Method definition to update specified treatment stations
        /// </summary>
        /// <param name="treatmentStations">specified treatment stations</param>
        void UpdateTreatmentStationStatus(IList<TreatmentStationInfo> treatmentStations);
    }
}
