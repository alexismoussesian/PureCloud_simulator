using PureCloudPlatform.Client.V2.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PureCloud_simulator.Routing
{
    public class Planning
    {
        RoutingApi routingApi = null;
        ListBox _lstLog;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lstLog"></param>
        public Planning(ListBox lstLog)
        {
            _lstLog = lstLog;
            routingApi = new RoutingApi();
        }

        public void CreateSchedule()
        {
            try
            {


            }
            catch (Exception ex)
            {
                AddLog($"Error in CreateSkill: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Show messages in the log 
        /// </summary>
        /// <param name="message"></param>
        private void AddLog(string message)
        {
            _lstLog.Items.Add($"{DateTime.Now} {message}");
            _lstLog.SelectedIndex = _lstLog.Items.Count - 1;
            _lstLog.SelectedIndex = -1;
        }

    }
}
