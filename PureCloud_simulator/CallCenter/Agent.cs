using PureCloudPlatform.Client.V2.Extensions.Notifications;
using PureCloudPlatform.Client.V2.Api;
using PureCloudPlatform.Client.V2.Client;
using PureCloudPlatform.Client.V2.Extensions;
using PureCloudPlatform.Client.V2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PureCloud_simulator.CallCenter
{
    public class Agent
    {
        string _agentId;
        private ListBox _lstLog;
        NotificationHandler handler;
        RoutingApi routingApi = null;
        Thread demoThread = null;
        CheckBox[] _chkbox = new CheckBox[7];
        PresenceApi presenceApi = null;

        public Agent(ListBox lstLog, string agentId)
        {
            _lstLog = lstLog;
            _agentId = agentId;
            presenceApi = new PresenceApi();
            Agent_subscription();

        }

        public Agent(CheckBox[] chkbox, ListBox lstLog, string agentId)
        {
            _lstLog = lstLog;
            _agentId = agentId;
            _chkbox = chkbox;
            presenceApi = new PresenceApi();
            Agent_subscription();

        }

        public void Agent_subscription()
        {
            try
            {
                handler = new NotificationHandler();

                // Multiple
                handler.AddSubscription($"v2.users.{_agentId}.presence", typeof(PresenceEventUserPresence));
                handler.AddSubscription($"v2.users.{_agentId}.conversations", typeof(ConversationBasic));
                handler.NotificationReceived += (data) =>
                {

                    //this.demoThread.Start();

                    if (data.GetType() == typeof(NotificationData<PresenceEventUserPresence>))
                    {
                        var presence = (NotificationData<PresenceEventUserPresence>)data;
                        AddLog($"New presence: {presence.EventBody.PresenceDefinition.SystemPresence}");
                        RefreshForm(presence.EventBody.PresenceDefinition.SystemPresence);
                    }
                    else if (data.GetType() == typeof(NotificationData<ConversationBasic>))
                    {
                        var conversation = (NotificationData<ConversationBasic>)data;
                        AddLog($"Conversation: {conversation.EventBody.Id} - {conversation.EventBody.Name}");
                    }
                };

                AddLog("Websocket connected, awaiting messages...");

            }
            catch (Exception ex)
            {
                AddLog($"Websocket exception " + ex.Message);
            }
        }



        public void Agent_unsubscription()
        {
            handler.RemoveSubscription($"v2.users.{_agentId}.conversations");

            AddLog("Conversations subscription removed, awaiting messages...");
        }

        public void RefreshForm(string status)
        {
            for (int i = 0; i < 7; i++) _chkbox[i].Checked = false;

            switch (status)
            {
                case "AVAILABLE":
                    _chkbox[0].Checked = true;
                    break;
                case "BUSY":
                    _chkbox[1].Checked = true;
                    break;
                case "AWAY":
                    _chkbox[2].Checked = true;
                    break;
                case "BREAK":
                    _chkbox[3].Checked = true;
                    break;
                case "MEAL":
                    _chkbox[4].Checked = true;
                    break;
                case "MEETING":
                    _chkbox[5].Checked = true;
                    break;
                case "TRAINING":
                    _chkbox[6].Checked = true;
                    break;
            }
        }


        public void UpdateStatus(string status)
        {

            try
            {
                // Get presences
                int pageNumber = 1;
                int pageSize = 100;
                OrganizationPresenceEntityListing presences = presenceApi.GetPresencedefinitions(pageNumber, pageSize);


                UserPresence body = new UserPresence();
                body.Primary = true;
                body.Source = "PURECLOUD";
                body.Message = "modification via API";
                body.PresenceDefinition = new PresenceDefinition();
                body.Name = "test API";

                // Find status presences in the org
                foreach (var pres in presences.Entities)
                {
                    if (pres.SystemPresence.Equals(status) && pres.Primary.Equals(true))
                    {
                        body.PresenceDefinition.Id = pres.Id;
                    }
                }


                var result = presenceApi.PatchUserPresence(_agentId, body.PresenceDefinition.Id, body);
                AddLog("UpdateStatus: " + status + " for agent " + _agentId);

            }
            catch (Exception ex)
            {
                AddLog($"Error in UpdateStatusAvailable: {ex.Message}");
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
