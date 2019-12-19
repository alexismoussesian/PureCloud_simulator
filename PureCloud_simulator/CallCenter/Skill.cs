using PureCloudPlatform.Client.V2.Api;
using PureCloudPlatform.Client.V2.Model;
using System;
using System.Windows.Forms;

namespace PureCloud_simulator.CallCenter
{
    public class Skill
    {
        RoutingApi routingApi = null;
        ListBox _lstLog;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lstLog"></param>
        public Skill(ListBox lstLog)
        {
            _lstLog = lstLog;
            routingApi = new RoutingApi();
        }

        /// <summary>
        /// Show all skills in the org
        /// </summary>
        public void GetSkill()
        {
            try
            {
                var pageNumber = 1;
                var pageCount = 1;

                var skillEntityListing = routingApi.GetRoutingSkills(100, pageNumber, null);

                pageCount = skillEntityListing.PageCount.Value;

                foreach (var skill in skillEntityListing.Entities)
                {

                    AddLog("Get Name: " + skill.Name + " - Id: " + skill.Id);

                }
            }
            catch (Exception ex)
            {
                AddLog($"Error in GetSkill: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Retrieve the skill id from the name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetSkillId(string name)
        {
            string id = "";

            try
            {
                var pageNumber = 1;
                var pageSize = 1;

                var skillEntityListing = routingApi.GetRoutingSkills(pageSize, pageNumber, name);

                foreach (var skill in skillEntityListing.Entities)
                {
                    if (skill.Name.Equals(name))
                    {
                        AddLog("GetSkillId: " + skill.Id);
                        id = skill.Id;
                    }
                }
            }
            catch (Exception ex)
            {
                AddLog($"Error in GetSkill: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return id;
        }

        /// <summary>
        /// Add a new skill with the name
        /// </summary>
        /// <param name="nom"></param>
        public void CreateSkill(string name)
        {
            try
            {
                RoutingSkill routingSkill = new RoutingSkill();

                routingSkill.Name = name;

                routingApi.PostRoutingSkills(routingSkill);

            }
            catch (Exception ex)
            {
                AddLog($"Error in CreateSkill on {name} : {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Add a new skill from a csv file
        /// </summary>
        public void CreateSkill()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\Dev\purecloud\createskill.csv");
                RoutingSkill routingSkill = new RoutingSkill();

                // Display the file contents by using a foreach loop.
                Console.WriteLine("Contents of WriteLines2.txt = ");
                foreach (string line in lines)
                {
                    // Use a tab to indent each line of the file.
                    Console.WriteLine("\t" + line);

                    routingSkill.Name = line;

                    routingApi.PostRoutingSkills(routingSkill);

                }
            }
            catch (Exception ex)
            {
                AddLog($"Error in CreateSkill: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Create skill from a csv file
        /// </summary>
        /// <param name="filename"></param>
        public void CreateSkillFromCsv(string filename)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(filename);
                RoutingSkill routingSkill = new RoutingSkill();

                foreach (string line in lines)
                {
                    routingSkill.Name = line;

                    try
                    {
                        routingApi.PostRoutingSkills(routingSkill);

                        AddLog("Skill is created : " + line);

                    }
                    catch (Exception ex)
                    {
                        AddLog($"Error in CreateSkill: {ex.Message}");
                        //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

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
