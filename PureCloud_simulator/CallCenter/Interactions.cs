using PureCloudPlatform.Client.V2.Api;
using PureCloudPlatform.Client.V2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using log4net;
using PureCloud_simulator.Model;

namespace PureCloud_simulator.CallCenter
{
    class Interactions
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        RoutingApi routingApi = null;
        UsersApi usersApi = null;
        ConversationsApi conversationsApi = null;
        ConversationQuery conversationQuery = null;
        AnalyticsApi api = null;
        ListBox _lstLog;

        public Interactions(ListBox lstLog)
        {
            _lstLog = lstLog;

            conversationsApi = new ConversationsApi();
            conversationQuery = new ConversationQuery();
            api = new AnalyticsApi();
        }


        public string GetConversationDetails(string interactionId)
        {
            var resultat = "";

            try
            {
                

                var conversation = conversationsApi.GetConversation(interactionId);

                foreach (var result in conversation.Participants)
                {
                    AddLog("conv: " + result.Attributes.Count);
                    foreach(var attr in result.Attributes)
                    {
                        AddLog("attr: " + attr.Key + "=" + attr.Value);
                    }
                    resultat = result.Attributes.ToString();
                }

                
            }
            catch (Exception ex)
            {
                AddLog($"Error in GetUserId: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultat;
        }


        public void RetrieveInteractions()
        {
            try
            {
                string strFilePath = "C:\\temp\\retrieve_interactions7.csv";

                DateTime fromForAggregates = new DateTime(2019, 10, 16, 01, 00, 00);
                DateTime toForAggregates = fromForAggregates.AddDays(7);

                var interval = new Interval(fromForAggregates, toForAggregates);

                var result = GetConversationData(interval);

                var listConversation = new List<ConversationData>();

                foreach(var res in result)
                {
                    var conversation = new ConversationData();
                    conversation.ConversationId = res.ConversationId;
                    conversation.ConversationStart = (DateTime)res.ConversationStart;
                    if (res.ConversationEnd != null) conversation.ConversationEnd = (DateTime)res.ConversationEnd;

                    foreach (var div in res.DivisionIds)
                    {
                        conversation.DivisionIds = conversation.DivisionIds += div.ToString();
                    }


                    foreach (var participants in res.Participants)
                    {
                        foreach (var session in participants.Sessions)
                        {
                            conversation.Media = session.MediaType.Value.ToString();

                            if (session.Ani != null) conversation.Ani = session.Ani;
                            if (session.Dnis != null) conversation.Dnis = session.Dnis;

                            if (session.Metrics != null)
                            {
                                foreach (var metric in session.Metrics)
                                {

                                    conversation = UpdateConversationMetric(conversation, metric);

                                }
                            }

                        }
                        if (participants.Purpose.Equals("acd"))
                        {
                            conversation.Queue.Add(participants.ParticipantName);
                        }
                    }
                    listConversation.Add(conversation);
                }



                foreach (var listconv in listConversation)
                {
                    File.AppendAllText(strFilePath, listconv.ConversationId + ";" + listconv.ConversationStart + ";" + listconv.ConversationEnd + ";" + listconv.Ani + ";" + listconv.Media + ";" +
                        listconv.Dnis + ";" + listconv.nConnected + ";" + listconv.tNotResponding + ";" + listconv.Rona + ";" + listconv.tIvr + ";" + listconv.DivisionIds + "\n");
                }







            }
            catch (Exception ex)
            {
                AddLog($"Error in RetrieveInteractions: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public ConversationData UpdateConversationMetric(ConversationData conversation, AnalyticsSessionMetric metric)
        {
            //ConversationData conv = null;
            try
            {
                switch (metric.Name)
                {
                    case "nConnected":
                        conversation.nConnected = (long)metric.Value;
                        break;
                    case "nBlindTransferred":
                        conversation.nBlindTransferred = (long)metric.Value;
                        break;
                    case "nConsult":
                        conversation.nConsult = (long)metric.Value;
                        break;
                    case "nConsultTransferred":
                        conversation.nConsultTransferred = (long)metric.Value;
                        break;
                    case "nError":
                        conversation.nError = (long)metric.Value;
                        break;
                    case "nFlow":
                        conversation.nFlow = (long)metric.Value;
                        break;
                    case "nFlowOutcome":
                        conversation.nFlowOutcome = (long)metric.Value;
                        break;
                    case "nFlowOutcomeFailed":
                        conversation.nFlowOutcomeFailed = (long)metric.Value;
                        break;
                    case "nOffered":
                        conversation.nOffered = (long)metric.Value;
                        break;
                    case "nOutbound":
                        conversation.nOutbound = (long)metric.Value;
                        break;
                    case "nOutboundAbandoned":
                        conversation.nOutboundAbandoned = (long)metric.Value;
                        break;
                    case "nOutboundAttempted":
                        conversation.nOutboundAttempted = (long)metric.Value;
                        break;
                    case "nOutboundConnected":
                        conversation.nOutboundConnected = (long)metric.Value;
                        break;
                    case "nOverSla":
                        conversation.nOverSla = (long)metric.Value;
                        break;
                    case "nStateTransitionError":
                        conversation.nStateTransitionError = (long)metric.Value;
                        break;
                    case "nTransferred":
                        conversation.nTransferred = (long)metric.Value;
                        break;
                    case "oSurveyQuestionGroupScore":
                        conversation.oSurveyQuestionGroupScore = (long)metric.Value;
                        break;
                    case "oSurveyQuestionScore":
                        conversation.oSurveyQuestionScore = (long)metric.Value;
                        break;
                    case "oSurveyTotalScore":
                        conversation.oSurveyTotalScore = (long)metric.Value;
                        break;
                    case "oTotalCriticalScore":
                        conversation.oTotalCriticalScore = (long)metric.Value;
                        break;
                    case "oTotalScore":
                        conversation.oTotalScore = (long)metric.Value;
                        break;
                    case "tAbandon":
                        conversation.tAbandon = (long)metric.Value;
                        break;
                    case "tAcd":
                        conversation.tAcd = (long)metric.Value;
                        break;
                    case "tAcw":
                        conversation.tAcw = (long)metric.Value;
                        break;
                    case "tAgentResponseTime":
                        conversation.tAgentResponseTime = (long)metric.Value;
                        break;
                    case "tAgentRoutingStatus":
                        conversation.tAgentRoutingStatus = (long)metric.Value;
                        break;
                    case "tAlert":
                        conversation.tAlert = (long)metric.Value;
                        break;
                    case "tAnswered":
                        conversation.tAnswered = (long)metric.Value;
                        break;
                    case "tContacting":
                        conversation.tContacting = (long)metric.Value;
                        break;
                    case "tDialing":
                        conversation.tDialing = (long)metric.Value;
                        break;
                    case "tFlow":
                        conversation.tFlow = (long)metric.Value;
                        break;
                    case "tFlowDisconnect":
                        conversation.tFlowDisconnect = (long)metric.Value;
                        break;
                    case "tFlowExit":
                        conversation.tFlowExit = (long)metric.Value;
                        break;
                    case "tFlowOut":
                        conversation.tFlowOut = (long)metric.Value;
                        break;
                    case "tFlowOutcome":
                        conversation.tFlowOutcome = (long)metric.Value;
                        break;
                    case "tHandle":
                        conversation.tHandle = (long)metric.Value;
                        break;
                    case "tHeld":
                        conversation.tHeld = (long)metric.Value;
                        break;
                    case "tHeldComplete":
                        conversation.tHeldComplete = (long)metric.Value;
                        break;
                    case "tOrganizationPresence":
                        conversation.tOrganizationPresence = (long)metric.Value;
                        break;
                    case "tIvr":
                        conversation.tIvr = conversation.tIvr += (long)metric.Value;
                        break;
                    case "tTalk":
                        conversation.tTalk = (long)metric.Value;
                        break;
                    case "tSystemPresence":
                        conversation.tSystemPresence = (long)metric.Value;
                        break;
                    case "tTalkComplete":
                        conversation.tTalkComplete = (long)metric.Value;
                        break;
                    case "tUserResponseTime":
                        conversation.tUserResponseTime = (long)metric.Value;
                        break;
                    case "tWait":
                        conversation.tWait = conversation.tWait += (long)metric.Value;
                        break;
                    case "tNotResponding":
                        conversation.tNotResponding = (long)metric.Value;
                        conversation.Rona = 1;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                AddLog($"Error in RetrieveInteractions: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conversation;
        }




        public List<AnalyticsConversation> GetConversationData(Interval interval)
        {
            Log.Debug($"GetConversationData(), {nameof(interval)}:{interval}");
            var result = new List<AnalyticsConversation>();
            try
            {
                var pageSize = 100;
                var pageNumber = 1;
                var api = new AnalyticsApi();
                var body = new ConversationQuery
                {
                    Interval = interval.ToString(),
                    Paging = new PagingSpec(pageSize, pageNumber)
                };
                Log.Info($"Getting conversations for interval: {body.Interval}");
                var pageResult = api.PostAnalyticsConversationsDetailsQuery(body);
                while (pageResult?.Conversations != null)
                {
                    result.AddRange(pageResult.Conversations);
                    body.Paging.PageNumber++;
                    pageResult = api.PostAnalyticsConversationsDetailsQuery(body);
                }
                Log.Info($"Conversations for interval retrived: {result.Count}");
            }
            catch (Exception ex)
            {
                Log.Error("GetConversationData()", ex);
            }
            return result;
        }



        public void ExportAllInteractions()
        {
            try
            {
                string strFilePath = "C:\\temp\\export_interactions8.csv";
                string strSeperator = ";";
                StringBuilder sbOutput = new StringBuilder();

                int pageSize = 100;
                int pageNumber = 1;

                //conversationQuery.Interval = "2019-08-29T05:00:00/2019-08-29T05:59:59";
                conversationQuery.Interval = "2019-09-30T01:00:00/2019-10-05T11:59:59";
                conversationQuery.Paging = new PagingSpec(pageSize, pageNumber);
                
                var pageResult = api.PostAnalyticsConversationsDetailsQuery(conversationQuery);



                foreach (var conv in pageResult.Conversations)
                {
                    // parse du resultat
                    AddLog("conv: " + conv);
                    File.AppendAllText(strFilePath, conv.ConversationId + ";" + conv.ConversationStart + ";" + conv.ConversationEnd );

                    //var result = GetConversationDetails(conv.ConversationId);
                    //File.AppendAllText(strFilePath, ";attributes:"+ result);

                    foreach (var participants in conv.Participants)
                    {
                        File.AppendAllText(strFilePath, ";ParticipantName:" + participants.ParticipantName);

                        switch (participants.Purpose.Value)
                        {
                            case AnalyticsParticipant.PurposeEnum.Acd:
                                File.AppendAllText(strFilePath, ";Acd:");
                                foreach (var session in participants.Sessions)
                                {
                                    
                                    foreach (var metric in session.Metrics)
                                    {
                                        File.AppendAllText(strFilePath, "|Metric:" + metric.Name + "$" + metric.Value);
                                    }

                                }
                                break;
                            case AnalyticsParticipant.PurposeEnum.Agent:
                                File.AppendAllText(strFilePath, ";Agent:");
                                foreach (var session in participants.Sessions)
                                {
                                    foreach (var metric in session.Metrics)
                                    {
                                        File.AppendAllText(strFilePath, "|Metric:" + metric.Name + "$" + metric.Value);
                                    }

                                }
                                break;
                            case AnalyticsParticipant.PurposeEnum.Ivr:
                                File.AppendAllText(strFilePath, ";Ivr:");
                                foreach (var session in participants.Sessions)
                                {
                                    File.AppendAllText(strFilePath, "ANI:" + session.Ani + "+DNIS:" + session.Dnis);
                                }

                                foreach (var session in participants.Sessions)
                                {
                                    foreach (var metric in session.Metrics)
                                    {
                                        File.AppendAllText(strFilePath, "|Metric:" + metric.Name + "$" + metric.Value);
                                    }

                                }
                                break;
                            case AnalyticsParticipant.PurposeEnum.Customer:
                                File.AppendAllText(strFilePath, ";Customer:");
                                foreach (var session in participants.Sessions)
                                {
                                    //File.AppendAllText(strFilePath, "ExitReason:");

                                    foreach (var metric in session.Metrics)
                                    {
                                        File.AppendAllText(strFilePath, "|Metric:" + metric.Name + "$" + metric.Value);
                                    }
                                    
                                }
                                break;
                            case AnalyticsParticipant.PurposeEnum.External:
                                File.AppendAllText(strFilePath, ";External:");
                                break;
                            case AnalyticsParticipant.PurposeEnum.Dialer:
                                File.AppendAllText(strFilePath, ";Dialer:");
                                break;
                            case AnalyticsParticipant.PurposeEnum.Inbound:
                                File.AppendAllText(strFilePath, ";Inbound:");
                                break;
                            case AnalyticsParticipant.PurposeEnum.Manual:
                                File.AppendAllText(strFilePath, ";Manual:");
                                break;
                            case AnalyticsParticipant.PurposeEnum.User:
                                File.AppendAllText(strFilePath, ";User:");
                                break;
                            case AnalyticsParticipant.PurposeEnum.Workflow:
                                File.AppendAllText(strFilePath, ";Workflow:");
                                break;
                            default:
                                break;
                        }
                    }

                    File.AppendAllText(strFilePath, "\n");

                }



            }
            catch (Exception ex)
            {
                AddLog($"Error in GetUserId: {ex.Message}");
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
