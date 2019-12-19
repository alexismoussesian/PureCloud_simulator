using PureCloudPlatform.Client.V2.Api;
using PureCloudPlatform.Client.V2.Client;
using PureCloudPlatform.Client.V2.Extensions;
using PureCloudPlatform.Client.V2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PureCloud_simulator.CallCenter
{
    public class Queue
    {
        RoutingApi routingApi = null;
        System.Windows.Forms.ListBox _lstLog;
        List<QueueInfo> queueList;
        List<QueueMember> currentQueueMembers = new List<QueueMember>();
        //private System.Windows.Forms.ListBox lstLog;

        public Queue(System.Windows.Forms.ListBox lstLog)
        {
            _lstLog = lstLog;
            routingApi = new RoutingApi();
        }



        public void GetQueues()
        {
            try
            {
                var pageNumber = 1;
                var pageCount = 1;

                queueList = new List<QueueInfo>();

                AddLog($"Getting Queues");
                do
                {
                    var queueEntityListing = routingApi.GetRoutingQueues(100, pageNumber++, null, null, null);
                    pageCount = queueEntityListing.PageCount.Value;
                    foreach (var queue in queueEntityListing.Entities)
                    {
                        //queueList.Add(new QueueInfo(queue.Id, queue.Name, queue.MemberCount));

                        queueList.Add(new QueueInfo(queue.Id, queue.Name, queue.MemberCount, queue.AcwSettings.TimeoutMs, queue.AcwSettings.WrapupPrompt));

                        AddLog("Get " + queue.Name + " - " + queue.AcwSettings.WrapupPrompt + " - " + queue.AcwSettings.TimeoutMs);
                    }
                } while (pageNumber <= pageCount);
            }
            catch (Exception ex)
            {
                AddLog($"Error in GetQueues: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddQueue()
        {
            try
            {

                var test = new CreateQueueRequest();
                //test.AcwSettings.WrapupPrompt = AcwSettings.WrapupPromptEnum.Mandatory;
                //test.AcwSettings.TimeoutMs = 120000;
                test.CallingPartyNumber = "+33954360976";

                //test.Division.Name = "Home";
                test.Name = "AMO - test queue";
                test.SkillEvaluationMethod = CreateQueueRequest.SkillEvaluationMethodEnum.Best;
                //test.AutoAnswerOnly = false;

                routingApi.PostRoutingQueues(test);


            }
            catch (Exception ex)
            {
                AddLog($"Error in AddQueue: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreateQueueFromCsv(string filename)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(filename);
                var queue = new CreateQueueRequest();

                foreach (string line in lines)
                {
                    //queue.AcwSettings.WrapupPrompt = AcwSettings.WrapupPromptEnum.Mandatory;
                    //queue.AcwSettings.TimeoutMs = 120000;

                    string[] champs = line.Split(';');

                    queue.Name = champs[0];

                    //queue.CallingPartyName = "";
                    queue.CallingPartyNumber = champs[1];

                    queue.Division = new WritableDivision();

                    // Find the id of the division from the division name
                    var div = new Division(_lstLog);
                    var divisionId = div.GetDivisionId(champs[2]);

                    queue.Division.Id = divisionId;

                    //queue.Bullseye = "";

                    var result = routingApi.PostRoutingQueues(queue);

                    AddLog("Queue is created : " + line);

                    // Add queue members
                    //AddQueueMembers(result.Id, champs[3]);

                }
            }
            catch (Exception ex)
            {
                AddLog($"Error in CreateQueue: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddQueueMembers(string queueId, string queueMembers)
        {
            try
            {
                User userMember = new User(_lstLog);
                var userId = userMember.GetUserId(queueMembers);

                Boolean deleteMembers = false;
                List<WritableEntity> body = new List<WritableEntity>();

                WritableEntity user = new WritableEntity();
                user.Id = userId;

                body.Add(user);

                routingApi.PostRoutingQueueUsers(queueId, body, deleteMembers);

                AddLog("Members is added in queue: " + queueMembers);

            }
            catch (Exception ex)
            {
                AddLog($"Error in AddQueueMembers: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public List<QueueMember> selectQueue(QueueInfo queue)
        {
            try
            {
                // Reset values
                if (queue.AllQueueMembers == null)
                {
                    queue.AllQueueMembers = new List<QueueMember>();
                }
                else
                {
                    queue.AllQueueMembers.Clear();
                }

                currentQueueMembers.Clear();

                var pageNumber = 1;
                var pageCount = 1;

                do
                {
                    var allQueueMemberEntityListing = routingApi.GetRoutingQueueUsers(queue.Id, 100, pageNumber++, "name");
                    pageCount = allQueueMemberEntityListing.PageCount.Value;
                    queue.AllQueueMembers.AddRange(allQueueMemberEntityListing.Entities);
                } while (pageNumber <= pageCount);

                var queueMemberEntityListing = new QueueMemberEntityListing();
                pageNumber = 1;
                pageCount = 1;

                do
                {
                    queueMemberEntityListing = routingApi.GetRoutingQueueUsers(queue.Id, 100, pageNumber++, "name", null);
                    pageCount = queueMemberEntityListing.PageCount.Value;
                    currentQueueMembers.AddRange(queueMemberEntityListing.Entities);
                } while (pageNumber <= pageCount);

            }
            catch (Exception ex)
            {
                AddLog($"Error in cmbQueues_SelectedIndexChanged: {ex}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return currentQueueMembers;

        }

        public void GetQueueDetails(QueueInfo queue)
        {
            try
            {

                var test = routingApi.GetRoutingQueue(queue.Id);

                AddLog(" reult: ");
                Dictionary<String, String> headerParams = new Dictionary<String, String>();
                headerParams.Add("Authorization", "bearer " + Configuration.Default.AccessToken);
                headerParams.Add("Content-Type", "application/json");
                //var result = Configuration.Default.ApiClient.CallApi($"https://api.mypurecloud.ie/api/v2/routing/queues", RestSharp.Method.GET, null, null, headerParams, null, null, null, "application/json");

                var api = new ApiClient();
                var result = api.CallApi($"https://api.mypurecloud.ie/api/v2/routing/queues", RestSharp.Method.GET, null, null, headerParams, null, null, null, "application/json");
                AddLog(" result: " + result.ToString());
            }
            catch (Exception ex)
            {
                AddLog("Exception " + ex.Message);
            }

        }




        public void deactivateAllMembers(QueueInfo queue, List<QueueMember> currentQueueMembers)
        {
            try
            {
                int deactivatedCount = 0;

                // Send Patch request to apply the changes. No more than 100 agents can be deactivated in a single request
                for (int i = 0; i < currentQueueMembers.Count; i = i + 100)
                {
                    var queueMembersToDeactivate = currentQueueMembers.Skip(i).Take(100).ToList();
                    var queueMemberEntityListing = routingApi.PatchRoutingQueueUsers(queue.Id, queueMembersToDeactivate);
                    deactivatedCount += queueMembersToDeactivate.Count;
                    /*foreach (var queueMember in queueMembersToDeactivate)
                    {
                        AddLog($"{queueMember.Name} has been deactivated from {queue.Name}   -   {queueMember.Id}");
                    }*/
                }

                var userApi = new UsersApi();
                string queueId = queue.Id;

                // Mark all current queue members as unjoined
                foreach (var queueMember in currentQueueMembers)
                {
                    queueMember.Joined = false;

                    string userId = queueMember.Id;
                    UserQueue userQueue = new UserQueue();
                    userQueue.Joined = false;
                    var test = userApi.PatchUserQueue(queueId, userId, userQueue);

                    AddLog($"{queueMember.Name} has been deactivated from {queue.Name}   -   {queueMember.Id}");
                }





                AddLog($"{deactivatedCount} members have been deactivated from {queue.Name}");
            }
            catch (Exception ex)
            {
                AddLog($"Error in btnDeactivate_Click: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void activateAllMembers(QueueInfo queue, List<QueueMember> currentQueueMembers)
        {
            try
            {
                int activatedCount = 0;

                // Send Patch request to apply the changes. No more than 100 agents can be activated in a single request
                for (int i = 0; i < currentQueueMembers.Count; i = i + 100)
                {
                    var queueMembersToActivate = currentQueueMembers.Skip(i).Take(100).ToList();
                    var queueMemberEntityListing = routingApi.PatchRoutingQueueUsers(queue.Id, queueMembersToActivate);
                    activatedCount += queueMembersToActivate.Count;
                    /*foreach (var queueMember in queueMembersToActivate)
                    {
                        AddLog($"{queueMember.Name} is now activated in {queue.Name}");
                    }*/
                }

                var userApi = new UsersApi();
                string queueId = queue.Id;

                // Mark all current queue members as joined
                foreach (var queueMember in currentQueueMembers)
                {
                    queueMember.Joined = true;

                    string userId = queueMember.Id;
                    UserQueue userQueue = new UserQueue();
                    userQueue.Joined = true;
                    var test = userApi.PatchUserQueue(queueId, userId, userQueue);

                    AddLog($"{queueMember.Name} has been activated from {queue.Name}   -   {queueMember.Id}");
                }

                AddLog($"{activatedCount} members have been activated in {queue.Name}");
            }
            catch (Exception ex)
            {
                AddLog($"Error in btnDeactivate_Click: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public List<QueueInfo> getListQueue()
        {
            return queueList;
        }


        public string GetUserId(QueueInfo queue, string user)
        {
            var result = "";

            try
            {

                var pageNumber = 1;
                var pageCount = 1;

                var allQueueMemberEntityListing = routingApi.GetRoutingQueueUsers(queue.Id, 100, pageNumber++, "name");
                pageCount = allQueueMemberEntityListing.PageCount.Value;
                AddLog("Members: " + allQueueMemberEntityListing.Entities);
                //queue.AllQueueMembers.AddRange(allQueueMemberEntityListing.Entities);

                foreach(var member in allQueueMemberEntityListing.Entities)
                {
                    if (member.Name.Equals(user))
                    {
                        result = member.Id; 
                    }
                }

            }
            catch (Exception ex)
            {
                AddLog($"Error in cmbQueues_SelectedIndexChanged: {ex}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }


        public string GetQueueId(string queueName)
        {
            var result = "";

            try
            {

                var pageNumber = 1;
                var pageSize = 25;
                var pageCount = 0;

                var allQueueItemEntityListing = routingApi.GetRoutingQueues(pageSize, pageNumber, null, queueName, null, null );
                pageCount = allQueueItemEntityListing.PageCount.Value;
                AddLog("Queue: " + allQueueItemEntityListing.Entities);


                foreach (var queueItem in allQueueItemEntityListing.Entities)
                {
                    if (queueItem.Name.Equals(queueName))
                    {
                        result = queueItem.Id;
                    }
                }

            }
            catch (Exception ex)
            {
                AddLog($"Error in cmbQueues_SelectedIndexChanged: {ex}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }



        public int GetEwt(string queueId)
        {
            int result = -1;

            try
            {
                var pageNumber = 1;
                var pageCount = 1;

                queueList = new List<QueueInfo>();

                //AddLog($"Getting Queues");
                var test = routingApi.GetRoutingQueueEstimatedwaittime(queueId);
                result = (int)test.Results[0].EstimatedWaitTimeSeconds;
                AddLog("GetEwt: " +result);

            }
            catch (Exception ex)
            {
                AddLog($"Error in GetQueues: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        private void AddLog(string message)
        {
            _lstLog.Items.Add($"{DateTime.Now} {message}");
            _lstLog.SelectedIndex = _lstLog.Items.Count - 1;
            _lstLog.SelectedIndex = -1;
        }
    }
}
