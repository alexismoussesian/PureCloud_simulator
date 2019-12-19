using PureCloudPlatform.Client.V2.Api;
using PureCloudPlatform.Client.V2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PureCloud_simulator
{
    public class Quality
    {
        ListBox _lstLog;
        QualityApi qualityApi = null;

        public Quality(ListBox lstLog)
        {
            _lstLog = lstLog;
            qualityApi = new QualityApi();

        }

        public void QueryEvaluations(string agentUserId)
        {
            try
            {
                string startTime = "2019-10-01T01:00:00";
                string endTime = "2019-10-30T01:00:00";
                int pageNumber = 1;
                int pageSize = 100;
                string strFilePath = "C:\\temp\\export_eval.csv";
                string strSeperator = ";";
                StringBuilder sbOutput = new StringBuilder();

                var result = qualityApi.GetQualityEvaluationsQuery(pageSize, pageNumber, null, null, null, null, null, agentUserId, null, null, null, null, null, null, null, true, null, null);



                foreach(var res in result.Entities)
                {
                    AddLog("QueryEvaluations: " + res.Agent);
                    File.AppendAllText(strFilePath, "Evaluation: " + res.Agent.Id + ";" + res.Conversation.Id + ";" + res.Answers.TotalScore.Value + ";" + res.Answers.TotalCriticalScore.Value + ";" + res.Answers.AnyFailedKillQuestions.Value + ";");

                    foreach(var questions in res.Answers.QuestionGroupScores)
                    {
                        File.AppendAllText(strFilePath, "QuestionGroupScores: " + questions.QuestionGroupId + ";" + questions.TotalScore + ";" + questions.TotalCriticalScore + ";");

                        foreach(var details in questions.QuestionScores)
                        {
                            File.AppendAllText(strFilePath, "details: " + details.AnswerId + ";" + details.QuestionId + ";" + details.Score + ";");

                        }

                    }

                    File.AppendAllText(strFilePath, "\n");
                }


                File.AppendAllText(strFilePath, "\n");

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
