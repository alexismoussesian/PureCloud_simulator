using PureCloudPlatform.Client.V2.Api;
using PureCloudPlatform.Client.V2.Client;
using PureCloudPlatform.Client.V2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PureCloud_simulator.CallCenter
{
    public class User
    {
        RoutingApi routingApi = null;
        UsersApi usersApi = null;
        GroupsApi groupAPI = null;
        PresenceApi presenceApi = null;
        StationsApi stationApi = null;
        ListBox _lstLog;

        public User(ListBox lstLog)
        {
            _lstLog = lstLog;
            routingApi = new RoutingApi();
            usersApi = new UsersApi();
            presenceApi = new PresenceApi();
            groupAPI = new GroupsApi();
            stationApi = new StationsApi();
        }


        public string UpdateRoleUser(string id)
        {
            var usersApi = new UsersApi();
            try
            {
                usersApi.DeleteAuthorizationSubjectDivisionRole(id, "6f585ecf-e988-422a-b93a-07d5e0bf2b86", "6cde8076-59cc-4788-a34e-60e3a98e771e");
            }
            catch (Exception ex)
            {
                AddLog($"Error in UpdateRoleUser: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return "";
        }


        public string UpdateRoleUser_FromCsv(string filename)
        {
            var usersApi = new UsersApi();

            try
            {
                string[] lines = System.IO.File.ReadAllLines(filename);
                var homeDivisionId = "6f585ecf-e988-422a-b93a-07d5e0bf2b86";            // Division: HOME
                var DTR_Interne_DivisionId = "1b704451-2205-4baf-8043-45f4fbce2b0a";      // Division: DTR_INTERNE
                var DTR_Armatis_DivisionId = "1b03a6da-1142-46eb-a50e-7b34653f615a";        // Division: DTR_ARMATIS
                var DTR_Sitel_DivisionId = "a0d5cd79-15ba-4e6b-973c-80c6f6cae218";        // Division: DTR_SITEL
                var DTR_Armatis_Pro_DivisionId = "2e97fe6b-13fd-4775-9b88-89ba991d8c74";
                var DTR_Interne_Pro_DivisionId = "8758cdce-90d9-4adf-b9e5-1835e77a964d";
                var DTR_FONCTIONNEL_DivisionId = "0e201f3b-676c-4ee5-a5e1-48183aaafb63";


                var employeeRoleId = "16cf35e1-e0ed-49ac-8196-d4c5b08927c6";        // Role employee
                var conseillerInterneRoleId = "2c08d9fe-60e1-4d80-93a5-066ab57fd7bb";
                var ecouteNatRoleId = "9a612379-61c2-4a44-9df3-4c6fa61124e8";
                var equipeInterneRoleId = "f2ac768c-ced0-4bd2-afb2-320b4f32a311";
                var adminHyperviseurRoleId = "9b380929-6bc6-4f00-a2e9-cd8d35d10674";
                var ecouteInterneRoleId = "bc8aef4c-6a83-4fa0-9120-a4864ef6deda";
                var superviseurInterneRoleId = "efe7a6ef-f617-4804-9437-89f2bf05190f";
                var managerInterneRoleId = "dbaf7cdc-30a5-4966-949c-d7c281680de1";
                var equipeInterneProRoleId = "3ec2955a-ad52-4954-a834-6e09d8c0f536";
                var conseillerInterneProRoleId = "3c70216b-2462-42e6-afc3-d27e2510635e";
                var managerInterneProRoleId = "2a1d5664-b96f-4608-b263-356faa7e283d";
                var adminInterneRoleId = "6cde8076-59cc-4788-a34e-60e3a98e771e";
                var hyperviseurNatRoleId = "5fb92274-476f-4c9c-a2a3-6b182265f143";
                var adminSitelRoleId = "afb9d41c-9127-4789-a1af-a6a160104a30";
                var conseillerSitelRoleId = "ab130a8c-13a9-4e7c-9c63-52aa525be231";
                var ecouteSitelRoleId = "e7812f41-38c6-4907-b173-872517bbd77d";
                var superviseurSitelRoleId = "409f4ec8-7428-49a3-bbf9-4fb184ecad0c";
                var adminArmatisRoleId = "55d18395-190b-454f-a1f8-ee2c4fed6100";
                var adminArmatisProRoleId = "719a8f01-764d-4103-8c29-66f1453062f7";
                var conseillerArmatisRoleId = "6274d40e-dc90-4ac2-9514-c3d275aaac3d";
                var ecouteArmatisRoleId = "c91608ea-c87d-43d8-ab2e-b4a171e66544";
                int total = 0;

                foreach (string line in lines)
                {
                    // récupérer le userid
                    var userId = GetUserId(line);

                    // récupérer tous les roles du user
                    var userRoles = usersApi.GetUserRoles(userId);


                    foreach (var userRole in userRoles.Roles)
                    {
                        usersApi.DeleteAuthorizationSubjectDivisionRole(userId, homeDivisionId, userRole.Id);
                        usersApi.DeleteAuthorizationSubjectDivisionRole(userId, DTR_Interne_DivisionId, userRole.Id);
                        usersApi.DeleteAuthorizationSubjectDivisionRole(userId, DTR_Armatis_DivisionId, userRole.Id);
                        usersApi.DeleteAuthorizationSubjectDivisionRole(userId, DTR_Sitel_DivisionId, userRole.Id);
                        usersApi.DeleteAuthorizationSubjectDivisionRole(userId, DTR_Armatis_Pro_DivisionId, userRole.Id);
                        usersApi.DeleteAuthorizationSubjectDivisionRole(userId, DTR_Interne_Pro_DivisionId, userRole.Id);
                        usersApi.DeleteAuthorizationSubjectDivisionRole(userId, DTR_FONCTIONNEL_DivisionId, userRole.Id);
                    }

                    usersApi.PostAuthorizationSubjectDivisionRole(userId, DTR_Interne_DivisionId, employeeRoleId);

                    usersApi.PostAuthorizationSubjectDivisionRole(userId, DTR_Interne_DivisionId, ecouteNatRoleId);
                    usersApi.PostAuthorizationSubjectDivisionRole(userId, DTR_Armatis_DivisionId, ecouteNatRoleId);
                    usersApi.PostAuthorizationSubjectDivisionRole(userId, DTR_Sitel_DivisionId, ecouteNatRoleId);
                    usersApi.PostAuthorizationSubjectDivisionRole(userId, DTR_Interne_Pro_DivisionId, ecouteNatRoleId);
                    usersApi.PostAuthorizationSubjectDivisionRole(userId, DTR_Armatis_Pro_DivisionId, ecouteNatRoleId);
                    usersApi.PostAuthorizationSubjectDivisionRole(userId, DTR_FONCTIONNEL_DivisionId, ecouteNatRoleId);




                    AddLog($"UpdateRoleUser succeed for user {line} #{total++}");

                    if (total.Equals(4))
                    {
                        total = 0;
                        AddLog($">>>>>>>>>>> UpdateRoleUser is waiting 32 seconds");
                        Thread.Sleep(32000);
                    }

                }
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode != 429)
                {
                    AddLog($"Error in UpdateRoleUser: {ex.Message}");
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string ratelimitCount;
                    string ratelimitAllowed;
                    string ratelimitReset;
                    ex.Headers.TryGetValue("inin-ratelimit-count", out ratelimitCount);
                    ex.Headers.TryGetValue("inin-ratelimit-allowed", out ratelimitAllowed);
                    ex.Headers.TryGetValue("inin-ratelimit-reset", out ratelimitReset);
                    AddLog($"API rate limit has been reached, {nameof(ratelimitCount)}:{ratelimitCount}, {nameof(ratelimitAllowed)}:{ratelimitAllowed}, {nameof(ratelimitReset)}:{ratelimitReset}");
                    /*
                    var resetTimeSeconds = 60; // default value in case that header parsing will go wrong                
                    int.TryParse(ratelimitReset, out resetTimeSeconds);
                    if (resetTimeSeconds > 60) throw new Exception("API rate limit reset > 60"); // if resetTimeSeconds is grather than 60 it means that something is wrong
                    var resetTime = DateTime.Now.AddSeconds(resetTimeSeconds).AddMilliseconds(500); // adding a few milliseconds as a margin of error
                    while (resetTime > DateTime.Now)
                    {
                        AddLog($"Waiting, {nameof(resetTime)}:{resetTime.ToString("O")}");
                        Thread.Sleep(200);
                    }
                    AddLog($"Re-calling method {nameof(UpdateRoleUser_FromCsv)}");
                    */
                }

            }

            return "";
        }



        public string DeleteHomeDivision_FromCsv(string filename)
        {
            var usersApi = new UsersApi();

            var division = new Division(_lstLog);


            try
            {
                string[] lines = File.ReadAllLines(filename);
                var homeDivisionId = division.GetDivisionId("HOME");

                int total = 0;

                foreach (string line in lines)
                {
                    // récupérer le userid
                    var userId = GetUserId(line);

                    // récupérer tous les roles du user
                    var userRoles = usersApi.GetUserRoles(userId);


                    foreach (var userRole in userRoles.Roles)
                    {
                        usersApi.DeleteAuthorizationSubjectDivisionRole(userId, homeDivisionId, userRole.Id);
                    }


                    AddLog($"DeleteHomeDivision succeed for user {line} #{total++}");

                    if (total.Equals(4))
                    {
                        total = 0;
                        AddLog($">>>>>>>>>>> DeleteHomeDivision is waiting 32 seconds");
                        Thread.Sleep(32000);
                    }

                }
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode != 429)
                {
                    AddLog($"Error in DeleteHomeDivision: {ex.Message}");
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string ratelimitCount;
                    string ratelimitAllowed;
                    string ratelimitReset;
                    ex.Headers.TryGetValue("inin-ratelimit-count", out ratelimitCount);
                    ex.Headers.TryGetValue("inin-ratelimit-allowed", out ratelimitAllowed);
                    ex.Headers.TryGetValue("inin-ratelimit-reset", out ratelimitReset);
                    AddLog($"API rate limit has been reached, {nameof(ratelimitCount)}:{ratelimitCount}, {nameof(ratelimitAllowed)}:{ratelimitAllowed}, {nameof(ratelimitReset)}:{ratelimitReset}");
                    /*
                    var resetTimeSeconds = 60; // default value in case that header parsing will go wrong                
                    int.TryParse(ratelimitReset, out resetTimeSeconds);
                    if (resetTimeSeconds > 60) throw new Exception("API rate limit reset > 60"); // if resetTimeSeconds is grather than 60 it means that something is wrong
                    var resetTime = DateTime.Now.AddSeconds(resetTimeSeconds).AddMilliseconds(500); // adding a few milliseconds as a margin of error
                    while (resetTime > DateTime.Now)
                    {
                        AddLog($"Waiting, {nameof(resetTime)}:{resetTime.ToString("O")}");
                        Thread.Sleep(200);
                    }
                    AddLog($"Re-calling method {nameof(UpdateRoleUser_FromCsv)}");
                    */
                }

            }

            return "";
        }


        public string DeleteHomeDivision_FromCsv_withApiLimit(string filename)
        {
            var usersApi = new UsersApi();
            var division = new Division(_lstLog);

            try
            {
                string[] lines = File.ReadAllLines(filename);
                var homeDivisionId = division.GetDivisionId("Home");
                List<string> ListOfUser = new List<string>();

                foreach (var user in lines)
                {
                    ListOfUser.Add(user);
                }

                DeleteHomeDivision(ListOfUser, homeDivisionId);

            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode != 429)
                {
                    AddLog($"Error in DeleteHomeDivision: {ex.Message}");
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string ratelimitCount;
                    string ratelimitAllowed;
                    string ratelimitReset;
                    ex.Headers.TryGetValue("inin-ratelimit-count", out ratelimitCount);
                    ex.Headers.TryGetValue("inin-ratelimit-allowed", out ratelimitAllowed);
                    ex.Headers.TryGetValue("inin-ratelimit-reset", out ratelimitReset);
                    AddLog($"API rate limit has been reached, {nameof(ratelimitCount)}:{ratelimitCount}, {nameof(ratelimitAllowed)}:{ratelimitAllowed}, {nameof(ratelimitReset)}:{ratelimitReset}");
                    /*
                    var resetTimeSeconds = 60; // default value in case that header parsing will go wrong                
                    int.TryParse(ratelimitReset, out resetTimeSeconds);
                    if (resetTimeSeconds > 60) throw new Exception("API rate limit reset > 60"); // if resetTimeSeconds is grather than 60 it means that something is wrong
                    var resetTime = DateTime.Now.AddSeconds(resetTimeSeconds).AddMilliseconds(500); // adding a few milliseconds as a margin of error
                    while (resetTime > DateTime.Now)
                    {
                        AddLog($"Waiting, {nameof(resetTime)}:{resetTime.ToString("O")}");
                        Thread.Sleep(200);
                    }
                    AddLog($"Re-calling method {nameof(UpdateRoleUser_FromCsv)}");
                    */
                }

            }

            return "";
        }


        public void DeleteHomeDivision(List<string> ListOfUser, string homeDivisionId)
        {
            int total = 0;

            try
            {
                foreach (string user in ListOfUser)
                {
                    // récupérer le userid
                    var userId = GetUserId(user);

                    if (userId.Equals(""))
                    {
                        AddLog($"Error in DeleteHomeDivision: {user} does not exist");
                    }

                    // récupérer tous les roles du user
                    var userRoles = usersApi.GetUserRoles(userId);

                    foreach (var userRole in userRoles.Roles)
                    {
                        usersApi.DeleteAuthorizationSubjectDivisionRole(userId, homeDivisionId, userRole.Id);
                    }

                    AddLog($"DeleteHomeDivision succeed for user {user} #{total++}");
                }
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode != 429)
                {
                    AddLog($"Error in DeleteHomeDivision: {ex.Message}");
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string ratelimitCount;
                    string ratelimitAllowed;
                    string ratelimitReset;
                    ex.Headers.TryGetValue("inin-ratelimit-count", out ratelimitCount);
                    ex.Headers.TryGetValue("inin-ratelimit-allowed", out ratelimitAllowed);
                    ex.Headers.TryGetValue("inin-ratelimit-reset", out ratelimitReset);
                    AddLog($"API rate limit has been reached, {nameof(ratelimitCount)}:{ratelimitCount}, {nameof(ratelimitAllowed)}:{ratelimitAllowed}, {nameof(ratelimitReset)}:{ratelimitReset}");
                    
                    var resetTimeSeconds = 60; // default value in case that header parsing will go wrong                
                    AddLog($"resetTimeSeconds, {resetTimeSeconds}");
                    int.TryParse(ratelimitReset, out resetTimeSeconds);
                    if (resetTimeSeconds > 60) throw new Exception("API rate limit reset > 60"); // if resetTimeSeconds is grather than 60 it means that something is wrong

                    AddLog($"Waiting {(resetTimeSeconds + 1)} seconds");
                    Thread.Sleep((resetTimeSeconds + 1) * 1000);

                    AddLog($"Re-calling method DeleteHomeDivision");
                    ListOfUser.RemoveRange(0, total);
                    DeleteHomeDivision(ListOfUser, homeDivisionId);
                }

            }
        }



        public string AddGroupMembers_FromCsv(string filename)
        {
            var usersApi = new UsersApi();

            try
            {
                string[] lines = System.IO.File.ReadAllLines(filename);

                var Group_Admin = "eed087b8-5ee4-44f1-84a7-2784d7cb57ec";
                var Group_Vigie = "f402f4c9-4aee-4d56-863a-6336c517574c";
                var Group_Queue = "8477bb56-a48a-41bb-a078-17060084a557";

                int i = 108;
                

                foreach (string line in lines)
                {
                    List<string> ListOfMembers = new List<string>();

                    // récupérer le userid
                    var userId = GetUserId(line);
                    ListOfMembers.Add(userId);

                    //groupMembers.MemberIds.Add(userId);
                    //groupMembers.Version = 5;
                    GroupMembersUpdate groupMembers = new GroupMembersUpdate(ListOfMembers, i++);

                    var result = groupAPI.PostGroupMembers(Group_Queue, groupMembers);


                }

                AddLog($"AddGroupMembers_FromCsv succeed ");

            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode != 429)
                {
                    AddLog($"Error in UpdateRoleUser: {ex.Message}");
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string ratelimitCount;
                    string ratelimitAllowed;
                    string ratelimitReset;
                    ex.Headers.TryGetValue("inin-ratelimit-count", out ratelimitCount);
                    ex.Headers.TryGetValue("inin-ratelimit-allowed", out ratelimitAllowed);
                    ex.Headers.TryGetValue("inin-ratelimit-reset", out ratelimitReset);
                    AddLog($"API rate limit has been reached, {nameof(ratelimitCount)}:{ratelimitCount}, {nameof(ratelimitAllowed)}:{ratelimitAllowed}, {nameof(ratelimitReset)}:{ratelimitReset}");
                }
            }
            catch (Exception ex)
            {
                AddLog($"Error in GetUserId: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return "";
        }


        public string DeleteUsers_FromCsv(string filename)
        {
            var usersApi = new UsersApi();

            try
            {
                string[] lines = File.ReadAllLines(filename);


                foreach (string userName in lines)
                {
                    // récupérer le userid
                    var userId = GetUserId(userName);
                    if (userId.Equals(""))
                    {
                        AddLog($"User {userName} does not exist");
                        continue;
                    }
                    usersApi.DeleteUser(userId);
                    AddLog($"User {userName} deleted successfully");
                }

                AddLog($"DeleteUsers_FromCsv succeed ");

            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode != 429)
                {
                    AddLog($"Error in DeleteUsers_FromCsv: {ex.Message}");
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string ratelimitCount;
                    string ratelimitAllowed;
                    string ratelimitReset;
                    ex.Headers.TryGetValue("inin-ratelimit-count", out ratelimitCount);
                    ex.Headers.TryGetValue("inin-ratelimit-allowed", out ratelimitAllowed);
                    ex.Headers.TryGetValue("inin-ratelimit-reset", out ratelimitReset);
                    AddLog($"API rate limit has been reached, {nameof(ratelimitCount)}:{ratelimitCount}, {nameof(ratelimitAllowed)}:{ratelimitAllowed}, {nameof(ratelimitReset)}:{ratelimitReset}");
                }
            }
            catch (Exception ex)
            {
                AddLog($"Error in DeleteUsers_FromCsv: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return "";
        }



        public string GetUserId(string name)
        {
            string id = "";

            try
            {

                UserSearchCriteria userSearchCriteria = new UserSearchCriteria();
                userSearchCriteria.Value = name;

                List<string> listOfString = new List<string>();
                listOfString.Add("name");
                userSearchCriteria.Fields = listOfString;
                userSearchCriteria.Type = UserSearchCriteria.TypeEnum.Exact;

                List<UserSearchCriteria> listOfUserSearchCriteria = new List<UserSearchCriteria>();
                listOfUserSearchCriteria.Add(userSearchCriteria);

                UserSearchRequest userSearchRequest = new UserSearchRequest();
                userSearchRequest.Query = listOfUserSearchCriteria;

                var userEntityListing = usersApi.PostUsersSearch(userSearchRequest);

                if (userEntityListing.Total.Value.Equals(0))
                    return "";

                foreach (var user in userEntityListing.Results)
                {
                    if (user.Name.Equals(name))
                    {
                        AddLog("GetUserId: " + user.Id);
                        id = user.Id;
                    }
                }
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode != 429)
                {
                    AddLog($"Error in SetDefaultStation_fromCsv: {ex.Message}");
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string ratelimitCount;
                    string ratelimitAllowed;
                    string ratelimitReset;
                    ex.Headers.TryGetValue("inin-ratelimit-count", out ratelimitCount);
                    ex.Headers.TryGetValue("inin-ratelimit-allowed", out ratelimitAllowed);
                    ex.Headers.TryGetValue("inin-ratelimit-reset", out ratelimitReset);
                    AddLog($"API rate limit has been reached for GetUserId, {nameof(ratelimitCount)}:{ratelimitCount}, {nameof(ratelimitAllowed)}:{ratelimitAllowed}, {nameof(ratelimitReset)}:{ratelimitReset}");

                    var resetTimeSeconds = 60; // default value in case that header parsing will go wrong                
                    AddLog($"resetTimeSeconds, {resetTimeSeconds}");
                    int.TryParse(ratelimitReset, out resetTimeSeconds);
                    if (resetTimeSeconds > 60) throw new Exception("API rate limit reset > 60"); // if resetTimeSeconds is grather than 60 it means that something is wrong
                    var resetTime = DateTime.Now.AddSeconds(resetTimeSeconds).AddMilliseconds(500); // adding a few milliseconds as a margin of error
                    AddLog($"resetTime, {resetTime}");
                    while (resetTime > DateTime.Now)
                    {
                        AddLog($"Waiting, {nameof(resetTime)}:{resetTime.ToString("O")}");
                        Thread.Sleep(2000);
                    }
                    AddLog($"Re-calling method {nameof(GetUserId)}");
                    id = GetUserId(name);

                }

            }

            return id;
        }

        public string GetUserId_fromEmail(string email)
        {
            string id = "";

            try
            {
                email = email.ToLower();


                UserSearchCriteria userSearchCriteria = new UserSearchCriteria();
                userSearchCriteria.Value = email;

                List<string> listOfString = new List<string>();
                listOfString.Add("email");
                userSearchCriteria.Fields = listOfString;
                userSearchCriteria.Type = UserSearchCriteria.TypeEnum.Exact;

                List<UserSearchCriteria> listOfUserSearchCriteria = new List<UserSearchCriteria>();
                listOfUserSearchCriteria.Add(userSearchCriteria);

                UserSearchRequest userSearchRequest = new UserSearchRequest();
                userSearchRequest.Query = listOfUserSearchCriteria;

                var userEntityListing = usersApi.PostUsersSearch(userSearchRequest);

                if (userEntityListing.Total.Value.Equals(0))
                    return "";

                foreach (var user in userEntityListing.Results)
                {
                    if (user.Username.Equals(email))
                    {
                        //AddLog("GetUserId_fromEmail: " + user.Id);
                        id = user.Id;
                    }
                }
            }
            catch (Exception ex)
            {
                AddLog($"Error in GetUserId: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return id;
        }


        public void UpdateStatusAvailable(string id)
        {

            try
            {
                // Get presences
                int pageNumber = 1;
                int pageSize = 100;
                OrganizationPresenceEntityListing presences = presenceApi.GetPresencedefinitions(pageNumber, pageSize);

                // Find Available and Break org presences
                PresenceDefinition availablePresence = null;
                PresenceDefinition breakPresence = null;
                foreach(var pres in presences.Entities)
                {
                    if (pres.SystemPresence.Equals("Available") && pres.Primary.Equals(true))
                    {
                        availablePresence = new PresenceDefinition();
                        availablePresence.Id = pres.Id;
                    }
                    if (pres.SystemPresence.Equals("Break") && pres.Primary.Equals(true))
                    {
                        breakPresence = new PresenceDefinition();
                        breakPresence.Id = pres.Id;
                    }
                }

                //string sourceId = "6a3af858-942f-489d-9700-5f9bcdcdae9b"; //Available
                UserPresence body = new UserPresence();
                body.Primary = true;
                body.Source = "API";
                body.Message = "modification via API";
                body.PresenceDefinition = new PresenceDefinition();
                body.PresenceDefinition.Id = availablePresence.Id;
                body.Name = "test API";
                
                var result = presenceApi.PatchUserPresence(id, availablePresence.Id, body);
                AddLog("UpdateStatusAvailable: " + id);

            }
            catch (Exception ex)
            {
                AddLog($"Error in UpdateStatusAvailable: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void UpdateStatusAway(string id)
        {

            try
            {
                // Get presences
                int pageNumber = 1;
                int pageSize = 100;
                OrganizationPresenceEntityListing presences = presenceApi.GetPresencedefinitions(pageNumber, pageSize);

                // Find Available and Break org presences
                PresenceDefinition availablePresence = null;
                PresenceDefinition breakPresence = null;
                foreach (var pres in presences.Entities)
                {
                    if (pres.SystemPresence.Equals("Available") && pres.Primary.Equals(true))
                    {
                        availablePresence = new PresenceDefinition();
                        availablePresence.Id = pres.Id;
                    }
                    if (pres.SystemPresence.Equals("Break") && pres.Primary.Equals(true))
                    {
                        breakPresence = new PresenceDefinition();
                        breakPresence.Id = pres.Id;
                    }
                }



                //string sourceId = "5e5c5c66-ea97-4e7f-ac41-6424784829f2"; //Away
                UserPresence body = new UserPresence();
                body.Primary = true;
                body.Source = "API";
                body.Message = "modification via API";
                body.PresenceDefinition = new PresenceDefinition();
                body.PresenceDefinition.Id = breakPresence.Id;

                var result = presenceApi.PatchUserPresence(id, breakPresence.Id, body);
                AddLog("UpdateStatusAway: " + id);

               
            }
            catch (Exception ex)
            {
                AddLog($"Error in UpdateStatusAway: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /// <summary>
        /// Update the user information frome the username
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string UpdateUserId(string name)
        {
            string id = "";

            try
            {


            }
            catch (Exception ex)
            {
                AddLog($"Error in UpdateUserId: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return id;
        }


        public void ExportAllUsers()
        {
            try
            {
                int i = 1;
                string strFilePath = "C:\\temp\\export_user2.csv";


                UserSearchCriteria userSearchCriteria = new UserSearchCriteria();
                userSearchCriteria.Value = "";

                userSearchCriteria.Type = UserSearchCriteria.TypeEnum.MatchAll;

                List<UserSearchCriteria> listOfUserSearchCriteria = new List<UserSearchCriteria>();
                listOfUserSearchCriteria.Add(userSearchCriteria);


                UserSearchRequest userSearchRequest = new UserSearchRequest();
                userSearchRequest.Query = listOfUserSearchCriteria;

                List<string> listOfString = new List<string>();
                listOfString.Add("skills");
                userSearchRequest.Expand = listOfString;
                userSearchRequest.PageNumber = 0;
                userSearchRequest.PageSize = 100;
                UsersSearchResponse userEntityListing = null;
                do
                {
                    userSearchRequest.PageNumber = userSearchRequest.PageNumber + 1;

                    userEntityListing = usersApi.PostUsersSearch(userSearchRequest);

                    foreach (var user in userEntityListing.Results)
                    {
                        AddLog("User: " + user.Name);
                        File.AppendAllText(strFilePath, user.Name);

                        File.AppendAllText(strFilePath, "|Email: " + user.Email);

                        File.AppendAllText(strFilePath, "|Division: " + user.Division.Name + ";");

                        if (user.Department != null)
                        {
                            File.AppendAllText(strFilePath, "|Department: " + user.Department + ";");
                        }

                        if (user.Title != null)
                        {
                            File.AppendAllText(strFilePath, "|Title: " + user.Title + ";");
                        }


                        if (user.Groups != null)
                        {
                            File.AppendAllText(strFilePath,  "|Group:");
                            foreach (var group in user.Groups)
                            {
                                File.AppendAllText(strFilePath, group.Name + ";");

                            }
                        }

                        if (user.Skills != null)
                        {
                            File.AppendAllText(strFilePath, "|Skill:");
                            foreach (var skill in user.Skills)
                            {
                                File.AppendAllText(strFilePath, skill.Name + ";" + skill.Proficiency + ";");

                            }
                        }

                        File.AppendAllText(strFilePath, "\n");
                        i++;
                    }

                } while (userEntityListing.Results.Count == 100);

                AddLog($"Exportation finished with {i} users");

            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode != 429)
                {
                    AddLog($"Error in GetAllUsers: {ex.Message}");
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string ratelimitCount;
                    string ratelimitAllowed;
                    string ratelimitReset;
                    ex.Headers.TryGetValue("inin-ratelimit-count", out ratelimitCount);
                    ex.Headers.TryGetValue("inin-ratelimit-allowed", out ratelimitAllowed);
                    ex.Headers.TryGetValue("inin-ratelimit-reset", out ratelimitReset);
                    AddLog($"API rate limit has been reached, {nameof(ratelimitCount)}:{ratelimitCount}, {nameof(ratelimitAllowed)}:{ratelimitAllowed}, {nameof(ratelimitReset)}:{ratelimitReset}");
                }
            }
            catch (Exception ex)
            {
                AddLog($"Error in GetAllUsers: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public Dictionary<string, string> GetAllUsers()
        {
            Dictionary<string, string> ListOfUsers = new Dictionary<string, string>();
            try
            {
                int i = 1;

                UserSearchCriteria userSearchCriteria = new UserSearchCriteria();
                userSearchCriteria.Value = "";

                userSearchCriteria.Type = UserSearchCriteria.TypeEnum.MatchAll;

                List<UserSearchCriteria> listOfUserSearchCriteria = new List<UserSearchCriteria>();
                listOfUserSearchCriteria.Add(userSearchCriteria);


                UserSearchRequest userSearchRequest = new UserSearchRequest();
                userSearchRequest.Query = listOfUserSearchCriteria;

                List<string> listOfString = new List<string>();
                listOfString.Add("skills");
                userSearchRequest.Expand = listOfString;
                userSearchRequest.PageNumber = 0;
                userSearchRequest.PageSize = 100;
                UsersSearchResponse userEntityListing = null;
                do
                {
                    userSearchRequest.PageNumber = userSearchRequest.PageNumber + 1;

                    userEntityListing = usersApi.PostUsersSearch(userSearchRequest);

                    foreach (var user in userEntityListing.Results)
                    {
                        AddLog("User: " + user.Name);
                        ListOfUsers.Add(user.Id, user.Name);
                    }

                } while (userEntityListing.Results.Count == 100);

                AddLog($"GatUsers finished with {i} users");

            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode != 429)
                {
                    AddLog($"Error in GetAllUsers: {ex.Message}");
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string ratelimitCount;
                    string ratelimitAllowed;
                    string ratelimitReset;
                    ex.Headers.TryGetValue("inin-ratelimit-count", out ratelimitCount);
                    ex.Headers.TryGetValue("inin-ratelimit-allowed", out ratelimitAllowed);
                    ex.Headers.TryGetValue("inin-ratelimit-reset", out ratelimitReset);
                    AddLog($"API rate limit has been reached, {nameof(ratelimitCount)}:{ratelimitCount}, {nameof(ratelimitAllowed)}:{ratelimitAllowed}, {nameof(ratelimitReset)}:{ratelimitReset}");
                }
            }
            catch (Exception ex)
            {
                AddLog($"Error in GetAllUsers: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ListOfUsers;
        }


        /// <summary>
        /// Export all users (name + id) in csv file
        /// </summary>
        public void ExportQueueUsers()
        {
            try
            {
                string strFilePath = "C:\\temp\\export_queue3.csv";
                UserEntityListing userEntityListening = new UserEntityListing();
                UserQueueEntityListing userQueues = new UserQueueEntityListing();

                int i = 1;
                var userApi = new UsersApi();
                var pageSize = 100;
                var pageNumber = 1;

                do
                {
                    userEntityListening = userApi.GetUsers(pageSize, pageNumber++);

                    foreach (var user in userEntityListening.Entities)
                    {
                        AddLog("User: " + user.Name);
                        File.AppendAllText(strFilePath, user.Name);


                        try
                        {
                            userQueues = userApi.GetUserQueues(user.Id, pageSize, 1);
                        }
                        catch (ApiException ex)
                        {
                            if (ex.ErrorCode != 429)
                            {
                                AddLog($"Error in GetUserQueues: {ex.Message}");
                            }
                            else
                            {
                                string ratelimitCount;
                                string ratelimitAllowed;
                                string ratelimitReset;
                                ex.Headers.TryGetValue("inin-ratelimit-count", out ratelimitCount);
                                ex.Headers.TryGetValue("inin-ratelimit-allowed", out ratelimitAllowed);
                                ex.Headers.TryGetValue("inin-ratelimit-reset", out ratelimitReset);
                                AddLog($"API rate limit has been reached for GetUserQueues, {nameof(ratelimitCount)}:{ratelimitCount}, {nameof(ratelimitAllowed)}:{ratelimitAllowed}, {nameof(ratelimitReset)}:{ratelimitReset}");

                                var resetTimeSeconds = 60; // default value in case that header parsing will go wrong                
                                AddLog($"resetTimeSeconds, {resetTimeSeconds}");
                                int.TryParse(ratelimitReset, out resetTimeSeconds);
                                if (resetTimeSeconds > 60) throw new Exception("API rate limit reset > 60"); // if resetTimeSeconds is grather than 60 it means that something is wrong

                                AddLog($"Waiting {(resetTimeSeconds + 1)} seconds");
                                Thread.Sleep((resetTimeSeconds + 1) * 1000);

                                AddLog($"Re-calling method GetUserQueues");
                                userQueues = userApi.GetUserQueues(user.Id, pageSize, 1);

                            }

                        }



                        if (userQueues.Entities != null)
                        {
                            File.AppendAllText(strFilePath, "|Queues:");

                            foreach (var queues in userQueues.Entities)
                            {
                                File.AppendAllText(strFilePath, queues.Name + ";");
                            }
                        }
                        File.AppendAllText(strFilePath, "\n");
                        i++;
                    }
                    //Thread.Sleep(55000);
                } while (userEntityListening.Entities.Count == 100);

                AddLog($"Exportation finished with {i} users");


            }
            catch (Exception ex)
            {
                AddLog($"Error in GetUserId: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void ExportRoleUsers()
        {
            try
            {
                string strFilePath = "C:\\temp\\export_role4.csv";
                UserEntityListing userEntityListening = new UserEntityListing();

                int i = 1;
                var userApi = new UsersApi();

                var userAuth = new AuthorizationApi();
                AuthzSubject auth = new AuthzSubject();
                var pageSize = 100;
                var pageNumber = 1;

                do
                {
                    userEntityListening = userApi.GetUsers(pageSize, pageNumber++);

                    foreach (var user in userEntityListening.Entities)
                    {
                        AddLog("User: " + user.Name);
                        File.AppendAllText(strFilePath, user.Name);

                        try
                        {
                            auth = userAuth.GetAuthorizationSubject(user.Id);

                        }
                        catch (ApiException ex)
                        {
                            if (ex.ErrorCode != 429)
                            {
                                AddLog($"Error in GetAuthorizationSubject: {ex.Message}");
                            }
                            else
                            {
                                string ratelimitCount;
                                string ratelimitAllowed;
                                string ratelimitReset;
                                ex.Headers.TryGetValue("inin-ratelimit-count", out ratelimitCount);
                                ex.Headers.TryGetValue("inin-ratelimit-allowed", out ratelimitAllowed);
                                ex.Headers.TryGetValue("inin-ratelimit-reset", out ratelimitReset);
                                AddLog($"API rate limit has been reached for GetUserId, {nameof(ratelimitCount)}:{ratelimitCount}, {nameof(ratelimitAllowed)}:{ratelimitAllowed}, {nameof(ratelimitReset)}:{ratelimitReset}");

                                var resetTimeSeconds = 60; // default value in case that header parsing will go wrong                
                                AddLog($"resetTimeSeconds, {resetTimeSeconds}");
                                int.TryParse(ratelimitReset, out resetTimeSeconds);
                                if (resetTimeSeconds > 60) throw new Exception("API rate limit reset > 60"); // if resetTimeSeconds is grather than 60 it means that something is wrong

                                AddLog($"Waiting {(resetTimeSeconds + 1)} seconds");
                                Thread.Sleep((resetTimeSeconds + 1) * 1000);

                                AddLog($"Re-calling method GetAuthorizationSubject");
                                auth = userAuth.GetAuthorizationSubject(user.Id);

                            }

                        }




                        if (auth.Grants != null)
                        {
                            File.AppendAllText(strFilePath, "|");

                            foreach (var result in auth.Grants)
                            {
                                File.AppendAllText(strFilePath, result.Role.Name + " [" + result.Division.Name + "]; ");
                            }
                        }
                        File.AppendAllText(strFilePath, "\n");
                        i++;
                    }
                    //Thread.Sleep(55000);
                } while (userEntityListening.Entities.Count == 100);

                AddLog($"Exportation finished with {i} users");


            }
            catch (Exception ex)
            {
                AddLog($"Error in GetUserId: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public string GetStationId(string stationName)
        {
            string id = "";

            try
            {
                var result = stationApi.GetStations(25, 1, null, stationName, null, null, null, null);

                if (result.Total.Value.Equals(0))
                {
                    AddLog($"GatStationId result is null for station {stationName}");
                    return "";
                }

                foreach (var station in result.Entities)
                {
                    if (station.Name.Equals(stationName))
                    {
                        return station.Id;
                    }
                }


            }
            catch (Exception ex)
            {
                AddLog($"Error in UpdateUserId: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return id;
        }


        public string SetDefaultStation_fromCsv(string filename)
        {
            var usersApi = new UsersApi();

            try
            {
                string[] lines = File.ReadAllLines(filename);

                foreach (var line in lines)
                {
                    var ListOfObject = line.Split(',');

                    var stationName = ListOfObject[0];
                    var userEmail = ListOfObject[1];

                    var userId = GetUserId_fromEmail(userEmail);
                    var stationId = GetStationId(stationName);

                    usersApi.PutUserStationDefaultstationStationId(userId, stationId);

                    AddLog($"Default station updated for user {userEmail} on station {stationName}");
                }

                AddLog($"SetDefaultStation_fromCsv succeed ");

            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode != 429)
                {
                    AddLog($"Error in SetDefaultStation_fromCsv: {ex.Message}");
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string ratelimitCount;
                    string ratelimitAllowed;
                    string ratelimitReset;
                    ex.Headers.TryGetValue("inin-ratelimit-count", out ratelimitCount);
                    ex.Headers.TryGetValue("inin-ratelimit-allowed", out ratelimitAllowed);
                    ex.Headers.TryGetValue("inin-ratelimit-reset", out ratelimitReset);
                    AddLog($"API rate limit has been reached, {nameof(ratelimitCount)}:{ratelimitCount}, {nameof(ratelimitAllowed)}:{ratelimitAllowed}, {nameof(ratelimitReset)}:{ratelimitReset}");
                }
            }
            catch (Exception ex)
            {
                AddLog($"Error in SetDefaultStation_fromCsv: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return "";
        }


        public string SetDefaultPassword_fromCsv(string filename)
        {
            var usersApi = new UsersApi();

            ChangePasswordRequest passwordRequest = new ChangePasswordRequest();

            try
            {
                string[] lines = File.ReadAllLines(filename);

                foreach (var line in lines)
                {
                    var ListOfObject = line.Split(',');
                    var userName = ListOfObject[0];
                    var userPassword = ListOfObject[1];
                    var userId = GetUserId(userName);

                    passwordRequest.NewPassword = userPassword;

                    usersApi.PostUserPassword(userId, passwordRequest);

                    AddLog($"Password updated for user {userName} with password {userPassword}");
                }

                AddLog($"SetDefaultPassword_fromCsv succeed ");

            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode != 429)
                {
                    AddLog($"Error in SetDefaultStation_fromCsv: {ex.Message}");
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string ratelimitCount;
                    string ratelimitAllowed;
                    string ratelimitReset;
                    ex.Headers.TryGetValue("inin-ratelimit-count", out ratelimitCount);
                    ex.Headers.TryGetValue("inin-ratelimit-allowed", out ratelimitAllowed);
                    ex.Headers.TryGetValue("inin-ratelimit-reset", out ratelimitReset);
                    AddLog($"API rate limit has been reached, {nameof(ratelimitCount)}:{ratelimitCount}, {nameof(ratelimitAllowed)}:{ratelimitAllowed}, {nameof(ratelimitReset)}:{ratelimitReset}");
                }
            }
            catch (Exception ex)
            {
                AddLog($"Error in SetDefaultStation_fromCsv: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return "";
        }


        public string GetUserProfile(string userId)
        {
            var usersApi = new UsersApi();

            try
            {
                AddLog("GetUserProfile started");

                List<string> ListOfUsers = new List<string>();
                ListOfUsers.Add(userId);


                List<string> criteria = new List<string>();
                criteria.Add("routingStatus");
                criteria.Add("presence");
                criteria.Add("conversationSummary");
                criteria.Add("outOfOffice");
                criteria.Add("geolocation");
                criteria.Add("station");
                criteria.Add("authorization");

                criteria.Add("certifications");
                criteria.Add("groups");
                criteria.Add("employerinfo");
                criteria.Add("locations");
                criteria.Add("profileskills");
                criteria.Add("skills");
                criteria.Add("languagepreference");

                var users = new UsersApi();

                //var user = users.GetUserProfile(userId, criteria);

                //var user = users.GetProfilesUsers(100, 1, ListOfUsers, null, "ASC", criteria);

                var user = users.GetUser(userId, criteria);


                if (user != null)
                {

                    AddLog($"loop ");

                }

                AddLog($"GetUserProfile succeed ");

            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode != 429)
                {
                    AddLog($"Error in SetDefaultStation_fromCsv: {ex.Message}");
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string ratelimitCount;
                    string ratelimitAllowed;
                    string ratelimitReset;
                    ex.Headers.TryGetValue("inin-ratelimit-count", out ratelimitCount);
                    ex.Headers.TryGetValue("inin-ratelimit-allowed", out ratelimitAllowed);
                    ex.Headers.TryGetValue("inin-ratelimit-reset", out ratelimitReset);
                    AddLog($"API rate limit has been reached, {nameof(ratelimitCount)}:{ratelimitCount}, {nameof(ratelimitAllowed)}:{ratelimitAllowed}, {nameof(ratelimitReset)}:{ratelimitReset}");
                }
            }
            catch (Exception ex)
            {
                AddLog($"Error in SetDefaultStation_fromCsv: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return "";
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
