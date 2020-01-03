using PureCloudPlatform.Client.V2.Api;
using PureCloudPlatform.Client.V2.Model;
using System;
using System.Windows.Forms;

namespace PureCloud_simulator.Audit
{
    public class Audit
    {
        ListBox _lstLog;
        AuditApi auditApi;
        AuditQueryRequest auditQueryRequest;

        public Audit(ListBox lstLog)
        {
            _lstLog = lstLog;
            auditApi = new AuditApi();
            auditQueryRequest = new AuditQueryRequest();

        }

        public string StartAudit(string userId)
        {
            auditQueryRequest.ServiceName = AuditQueryRequest.ServiceNameEnum.Contactcenter;
            auditQueryRequest.Interval = "2019-12-01T01:00:00/2019-12-08T01:00:00";

            AuditQueryFilter auditQueryFilter = new AuditQueryFilter();
            auditQueryFilter.Value = userId;
            auditQueryFilter.Property = AuditQueryFilter.PropertyEnum.Userid;

            auditQueryRequest.Filters = new System.Collections.Generic.List<AuditQueryFilter>();

            auditQueryRequest.Filters.Add(auditQueryFilter);

            AuditQueryExecutionStatusResponse transactionId = auditApi.PostAuditsQuery(auditQueryRequest);

            AddLog($"TransationId = {transactionId.Id} with status {transactionId.State}");

            return transactionId.Id;
        }

        public void GetAudit(string transactionId)
        {
            try
            { 
                var result = auditApi.GetAuditsQueryTransactionIdResults(transactionId);

                foreach (var item in result.Entities)
                {
                    AddLog($"Result = {result.Id} {item.Action}");
                }
            }
            catch (Exception ex)
            {
                AddLog($"Error in GetUserId: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EndAudit()
        {
            auditQueryRequest = null;
            auditApi = null;
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
