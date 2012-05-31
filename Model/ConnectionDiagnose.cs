using System.Net;
using System.Net.NetworkInformation;

namespace LFAutomationUI.Model
{
    /// <summary>
    /// Class used to diagnose connection status
    /// </summary>
    public class ConnectionDiagnose
    {
        /// <summary>
        /// static method used to check connection
        /// </summary>
        /// <param name="ipAddress">IP Address</param>
        /// <param name="error">if return false,error refer to the reason</param>
        /// <returns></returns>
        public static bool CheckConnection(string ipAddress, out string error)
        {
            error = null;
            Ping userPing = new Ping();
            IPAddress IP;
            bool isLegalIPAddress = IPAddress.TryParse(ipAddress, out IP);
            if (isLegalIPAddress == false)
            {
                error = "Illegal IP Address!";
                return false;
            }
            else
            {
                PingReply pingReply = userPing.Send(IP, 100);

                if (pingReply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static void CheckConnection(string[] ipAddresses, out string[] error, out bool[] connectionStatus)
        {
            int countOfIPAddresses=ipAddresses.Length;
            error=new string[countOfIPAddresses];
		    connectionStatus=new bool[countOfIPAddresses];
            int i=0;
            foreach (string ipAddess in ipAddresses)
            {
                connectionStatus[i]=CheckConnection(ipAddess, out error[i++]);
            }
        }
    }
}
