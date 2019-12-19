using PureCloudPlatform.Client.V2.Api;
using PureCloudPlatform.Client.V2.Client;
using PureCloudPlatform.Client.V2.Extensions;
using PureCloudPlatform.Client.V2.Extensions.Notifications;
using PureCloudPlatform.Client.V2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PureCloud_simulator.Telephony
{
    public class Edges
    {
        System.Windows.Forms.ListBox _lstLog;
        TelephonyProvidersEdgeApi telephony = null;
        NotificationHandler handler;
        string _edgeId = null;
        public Dictionary<string, string> ListOfEdgeServers { get; } = new Dictionary<string, string>();

        public Edges(System.Windows.Forms.ListBox lstLog)
        {
            _lstLog = lstLog;
            telephony = new TelephonyProvidersEdgeApi();
        }


        public void GetListOfEdge()
        {
            try
            {
                ListOfEdgeServers.Clear();

                var currentPage = 1;
                var pageSize = 100;

                var result = telephony.GetTelephonyProvidersEdges(pageSize, currentPage);

                AddLog("Total Edges: " + result.PageCount.Value.ToString());
                while (result != null && result.Entities.Any())
                {
                    foreach (var item in result.Entities)
                    {
                        AddLog("Edge Id: " + item.Id + "   - Status: " + item.OnlineStatus + " - StatusCode:" + item.StatusCode + "  - Name: " + item.Name);
                        ListOfEdgeServers.Add(item.Id, item.Name);
                        EdgeStatus(item.Id);
                    }
                    result = telephony.GetTelephonyProvidersEdges(pageSize, ++currentPage);
                }

            }
            catch (Exception ex)
            {
                AddLog($"Error in GetQueues: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public void EdgeStatus(string edgeId)
        {
            try
            {

                var result = telephony.GetTelephonyProvidersEdgeMetrics(edgeId);

                AddLog("    -Edge:       " + result.Edge.Id + " - Name: " + result.Edge.Name);

                foreach (var disk in result.Disks)
                {
                    AddLog("    -Disks TotalBytes: " + disk.TotalBytes + " - AvailableBytes: " + disk.AvailableBytes);
                }
                foreach (var memory in result.Memory)
                {
                    AddLog("    -Memory TotalBytes: " + memory.TotalBytes + " - AvailableBytes: " + memory.AvailableBytes + " - Type: " + memory.Type);
                }
                foreach (var network in result.Networks)
                {
                    AddLog("    -Network ReceivedBytesPerSec: " + network.ReceivedBytesPerSec + " - SentBytesPerSec: " + network.SentBytesPerSec + " - UtilizationPct: " + network.UtilizationPct);
                }
                foreach (var processor in result.Processors)
                {
                    AddLog("    -Processor ActiveTimePct: " + processor.ActiveTimePct + " - IdleTimePct: " + processor.IdleTimePct + " - PrivilegedTimePct: " + processor.PrivilegedTimePct + " - UserTimePct: " + processor.UserTimePct);
                }

                /*AddLog("    -Disks:      " + result.Disks);
                AddLog("    -Memory:     " + result.Memory);
                AddLog("    -Networks:   " + result.Networks);
                AddLog("    -Processors: " + result.Processors);
                AddLog("    -Subsystems: " + result.Subsystems);
                AddLog("    -UpTimeMsec: " + result.UpTimeMsec);*/


            }
            catch (Exception ex)
            {
                AddLog($"Error in GetQueues: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void AddLog(string message)
        {
            _lstLog.Items.Add($"{DateTime.Now} {message}");
            _lstLog.SelectedIndex = _lstLog.Items.Count - 1;
            _lstLog.SelectedIndex = -1;
        }
    }
}
