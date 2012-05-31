using System.Collections.Generic;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.BLL
{
    /// <summary>
    /// A business component to manage treatment station
    /// </summary>
    public class TreatmentStation
    {
        // Get an instance of the Item DAL using the DALFactory
        // Making this static will cache the DAL instance after the initial load
        private static readonly ITreatmentStation dal = LFAutomationUI.DALFactory.DataAccess.CreateTreatmentStation();

        public IList<TreatmentStationInfo> GetTreatmentStations()
        {
            return dal.GetTreatmentStations();
        }

        public void UpdateTreatmentStationStatus(IList<TreatmentStationInfo> treatmentStations)
        {
            dal.UpdateTreatmentStationStatus(treatmentStations);
            return;
        }
        public TreatmentStationInfo GetTreatmentStationByTreatmentStationName(string treatmentStationName)
        {
            return dal.GetTreatmentStationByTreatmentStationName(treatmentStationName);
        }
    }
}
