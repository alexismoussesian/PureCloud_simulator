using PureCloudPlatform.Client.V2.Api;
using PureCloudPlatform.Client.V2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PureCloud_simulator.CallCenter
{
    public class WrapupCodes_Qualif
    {
        RoutingApi routingApi = null;
        ListBox _lstLog;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lstLog"></param>
        public WrapupCodes_Qualif(ListBox lstLog)
        {
            _lstLog = lstLog;
            routingApi = new RoutingApi();
        }




        /// <summary>
        /// Add a new skill with the name
        /// </summary>
        /// <param name="nom"></param>
        public void CreateWrapupCode(string name)
        {
            try
            {
                WrapupCode routingWC = new WrapupCode();

                //routingWC.Name = name;
                routingWC.Name = name;

                routingApi.PostRoutingWrapupcodes(routingWC);

            }
            catch (Exception ex)
            {
                AddLog($"Error in CreateSkill on {name} : {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void CreateWrapupCodesFromCsv(string filename)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(filename);
                WrapupCode routingWC = new WrapupCode();

                foreach (string line in lines)
                {
                    routingWC.Name = line;
                    routingApi.PostRoutingWrapupcodes(routingWC);

                    AddLog("WrapupCode is created : " + line);
                }
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
