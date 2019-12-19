using PureCloudPlatform.Client.V2.Api;
using PureCloudPlatform.Client.V2.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PureCloud_simulator.CallCenter
{
    public class Division
    {
        ListBox _lstLog;
        AuthorizationApi authorizationApi = null;

        public Division(ListBox lstLog)
        {
            _lstLog = lstLog;
            authorizationApi = new AuthorizationApi();
        }

        public string GetDivisionId(string name)
        {
            string id = "";

            try
            {
                var pageNumber = 1;
                var pageSize = 25;

                var divisionEntityListing = authorizationApi.GetAuthorizationDivisions(pageSize, pageNumber,null,null,null,null,null,null, name);
                //var divisionEntityListing = authorizationApi.GetAuthorizationDivisions(pageSize, pageNumber);

                foreach (var div in divisionEntityListing.Entities)
                {
                    if (div.Name.Equals(name))
                    {
                        AddLog("GetDivisionId: " + div.Id);
                        id = div.Id;
                    }
                }
            }
            catch (Exception ex)
            {
                AddLog($"Error in GetDivisionId: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return id;
        }

        public string GetDivisionName(string id)
        {
            string name = "";

            try
            {
                var pageNumber = 1;
                var pageSize = 100;

                var divisionEntityListing = authorizationApi.GetAuthorizationDivisions(pageSize, pageNumber, null, null, null, null, null, null, null);

                foreach (var div in divisionEntityListing.Entities)
                {
                    if (div.Id.Equals(id))
                    {
                        AddLog("GetDivisionName: " + div.Name);
                        name = div.Name;
                    }
                }
            }
            catch (Exception ex)
            {
                AddLog($"Error in GetDivisionName: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return id;
        }

        public Dictionary<string, string> GetDivisions()
        {
            Dictionary<string, string> listOfDivisions = new Dictionary<string, string>();

            try
            {
                var pageNumber = 1;
                var pageSize = 100;

                var divisionEntityListing = authorizationApi.GetAuthorizationDivisions(pageSize, pageNumber, null, null, null, null, null, null, null);

                foreach (var div in divisionEntityListing.Entities)
                {
                    listOfDivisions.Add(div.Id, div.Name);
                }
            }
            catch (Exception ex)
            {
                AddLog($"Error in GetDivisionName: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listOfDivisions;
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
