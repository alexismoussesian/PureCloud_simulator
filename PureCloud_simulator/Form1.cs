using PureCloud_simulator.CallCenter;
using PureCloud_simulator.Telephony;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;
using log4net;

namespace PureCloud_simulator
{
    public partial class Form1 : Form
    {
        public IList<ConversationMetric> conversationMetric { get; set; }

        Connection connection;
        Queue queue;
        Skill skill;
        DataTable dt;
        QueueInfo queueInfo;
        WrapupCodes_Qualif wc;
        Agent agent;
        Quality quality;

        string[] queueId;

        public Form1()
        {
            InitializeComponent();
            AddLog("Init");

            cmbEnvironment.SelectedIndex = 0;
            //environment = $"https://api.mypurecloud.ie";

            //emeapspractices
            //txtClientId.Text = "64755efc-d86c-4783-80e9-4a06cdf0caca";
            //txtClientSecret.Text = "BH_3kTSekhJI1KvS-fFj6PLlQzWY36P9-0SVNoKD3pg";

            //purecloud-france
            txtClientId.Text = "32d2118e-7764-4fbd-8fce-98fefaf3d13a";
            txtClientSecret.Text = "_EzAP2mBGENgYcZ_pQ8iMhB4irSeyCH2OkxbDUgoBhM";

            //rctengiedcp
            //txtClientId.Text = "bef90382-cce1-4e7d-8e2f-c8759d219831";
            //txtClientSecret.Text = "VUh3TBUCc0OzuMZ-cSMOzVcaVSJVyEJMBgU6ZSfA3aE";

            //engiedcp PROD
            //txtClientId.Text = "7b850399-6c90-4673-aa63-d5fcec524067";
            //txtClientSecret.Text = "AhQblBPlm0Sw7_qc_aksdQvMcC3CuQxc6BVjuxmdlC0";

            //rctengieec Recette
            //txtClientId.Text = "738d59f8-b42d-42b2-9401-c52a4e4e3688";
            //txtClientSecret.Text = "zmnO69Si6X3n0Ngo1JEHxlOmiO0cVL_v9kA76i_vlok";

            //engiedgp PROD
            //txtClientId.Text = "16fb1849-451a-4b09-9f67-3b4219794efb";
            //txtClientSecret.Text = "R4XSoUjvuA2_r3PNf-PodH6kLPZs0f4J47-QntezO4k";

            //engieec PROD
            //txtClientId.Text = "ab0c50a4-aefc-4e7c-a227-84087d3cdd98";
            //txtClientSecret.Text = "ylhnatyL5X5noD_gBejhGwU02qWUnZnbeeseP-8tnls";

            //lyreco PROD
            //cmbEnvironment.SelectedIndex = 1;
            //txtClientId.Text = "b44cdd98-5181-49cf-9ed3-97673fbb12b0";
            //txtClientSecret.Text = "Qq9dHzaijC6DVoMaAhpJ-8lmQQkwMCAMjBGA4UWWlqk";

            //Engie DTR PROD
            //cmbEnvironment.SelectedIndex = 1;
            //txtClientId.Text = "0ef8e617-733a-46ec-adc6-3e8922836585";
            //txtClientSecret.Text = "aEwcEEUn3ubqUEfWmP3_xa597tNjOOLyU1ezFsWoCMI";
            

            queue = new Queue(lstLog);
            skill = new Skill(lstLog);
            dt = new DataTable(lstLog, comboDatatables);
            wc = new WrapupCodes_Qualif(lstLog);
            quality = new Quality(lstLog);

            TextBox.CheckForIllegalCrossThreadCalls = false;
            ListBox.CheckForIllegalCrossThreadCalls = false;
            CheckBox.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            connection = new Connection(lstLog, cmbEnvironment.SelectedItem.ToString(), txtClientId.Text, txtClientSecret.Text);
            
            var result = connection.Connect();

            AddLog("PureCloud connection activated: " + result);

            connection.GetOrg();

        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {

            var result = connection.Disconnect();
            AddLog("PureCloud connection activated: " + result);
            }
            catch(Exception ex)
            {
                AddLog($"Error in AddRows: {ex.Message} - Not connected");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnGetQueue_Click(object sender, EventArgs e)
        {

            queue.GetQueues();

            var result = queue.getListQueue();
            cmbQueues.Items.AddRange(result.ToArray());

        }

        private void AddLog(string message)
        {
            lstLog.Items.Add($"{DateTime.Now} {message}");
            lstLog.SelectedIndex = lstLog.Items.Count - 1;
            lstLog.SelectedIndex = -1;
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            var queueMembers = queue.selectQueue(queueInfo);
            queue.deactivateAllMembers(queueInfo, queueMembers);
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            var queueMembers = queue.selectQueue(queueInfo);
            queue.activateAllMembers(queueInfo, queueMembers);
        }

        private void cmbQueues_SelectedIndexChanged(object sender, EventArgs e)
        {
            queueInfo = (QueueInfo)((ComboBox)sender).SelectedItem;
        }

        private void btnClearLog_Click_1(object sender, EventArgs e)
        {
            lstLog.Items.Clear();
        }

        private void frmButton1_Click(object sender, EventArgs e)
        {
            queue.GetQueueDetails(queueInfo);

        }

        private void btnButton2_Click(object sender, EventArgs e)
        {
            connection.GetOrg();
        }

        private void btnButton3_Click(object sender, EventArgs e)
        {

            if (queueInfo != null)
            {
                var userId = queue.GetUserId(queueInfo, "Alexis Moussesian");

                var agent = new Agent(lstLog, userId);
            }
            else
            {
                MessageBox.Show("Sélectionner la queue avant de continuer");
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            var encryptionHelper = new EncryptionHelper();
            AddLog("chaine: 00016772");
            var test = encryptionHelper.EncryptString("00016772", "MRctQ1kGN3gJCgs3Qlhjfw==", "UTF_8");
            AddLog("crypté: " + test);
            //test = encryptionHelper.DecryptString("4P4x607kq4HljAq1hzYMew==", "MRctQ1kGN3gJCgs3Qlhjfw==", "");
            //AddLog("décrypté: " + test);
        }

        private void btnAddSkill_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV Files (*.csv)|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                skill.CreateSkillFromCsv(dialog.FileName);
            }

        }

        private void btnGetSkills_Click(object sender, EventArgs e)
        {

            skill.GetSkill();
        }

        private void btnGetDataTable_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV Files (*.csv)|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dt.ExportDataTable(dialog.FileName);

            }

        }



        private void btnGetRowDataTable_Click(object sender, EventArgs e)
        {
            var result = dt.GetDataTableId("AMO - Calendrier VIP");
            dt.GetRow(result);
        }

        private void btnCreateQueue_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV Files (*.csv)|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                queue.CreateQueueFromCsv(dialog.FileName);
            }


        }

        private void btnAddRowsDataTable_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV Files (*.csv)|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //var result = dt.GetDataTableId("AMO - Calendrier VIP");
                //dt.AddRows(dialog.FileName, result);
                //var result = dt.GetDataTableId("ROUTAGE_CP_OK");
                //dt.AddRows_ROUTAGE_CP_OK(dialog.FileName, result);
                var result = dt.GetDataTableId("ANNONCE_MSG");
                dt.AddRows(dialog.FileName, result);
            }
        }

        private void btnImportWrapupCode_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV Files (*.csv)|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //skill.CreateSkillFromCsv(dialog.FileName);
                wc.CreateWrapupCodesFromCsv(dialog.FileName);
            }
        }

        private void btnEwt_Click(object sender, EventArgs e)
        {
            var queueList = new QueueInfo[3];

            var queueName = new string[3] { "FA_PRO_PaP_PROENERGY", "FA_PRO_PaP_NOS_RESEAUX", "FA_PRO_PaP_RANGER" };

            queueId = new string[3];
            int i = 0;
            foreach (var queueItem in queueName)
            {
                AddLog("QueueItem: " + queueItem);
                queueId.SetValue(queue.GetQueueId(queueItem), i++);
            }


            tmrEwt.Interval = 2000;
            tmrEwt.Enabled = true;
        }

        private void tmrEwt_Tick(object sender, EventArgs e)
        {

            foreach (var queueItem in queueId)
            {
                AddLog("QueueItem: " + queueItem);
                queue.GetEwt(queueItem);
            }

        }

        private void btmEwt2_Click(object sender, EventArgs e)
        {
            tmrEwt.Enabled = false;
        }




        private void btnCreateDataTable_Click(object sender, EventArgs e)
        {
            List<string> head = new List<string>();

            head.Add("DNIS");
            head.Add("MessageAccueil");
            head.Add("MessageDissuasion");
            head.Add("Label");

            dt.CreateDataTable("AMO - test", head);
        }

        private void btnCreateAndFillDataTable_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV Files (*.csv)|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dt.CreateAndFillDataTable(dialog.FileName);

            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGetUser_Click(object sender, EventArgs e)
        {
            User userMember = new User(lstLog);
            var userId = userMember.GetUserId("Alexis Moussesian");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV Files (*.csv)|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dt.DeleteDataTable(dialog.FileName);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            User userMember = new User(lstLog);
            userMember.GetAllUsers();

            
        }

        private void btnExportInCsvFile_Click(object sender, EventArgs e)
        {
            User userMember = new User(lstLog);
            userMember.ExportQueueUsers();
        }

        private void btnExportInteractions_Click(object sender, EventArgs e)
        {
            Interactions interaction = new Interactions(lstLog);
            //interaction.ExportAllInteractions();
            interaction.RetrieveInteractions();
        }

        private void btnAway_Click(object sender, EventArgs e)
        {
            //User userMember = new User(lstLog);
            //var id = userMember.GetUserId("Genesys Engineer");
            //var id = userMember.GetUserId("Alexis Moussesian");
            //userMember.UpdateStatusAway(id);

            agent.UpdateStatus("Away");
        }

        private void btnAvailable_Click(object sender, EventArgs e)
        {
            //User userMember = new User(lstLog);
            //var id = userMember.GetUserId("Genesys Engineer");
            //var id = userMember.GetUserId("Alexis Moussesian");
            //userMember.UpdateStatusAvailable(id);

            agent.UpdateStatus("Available");
        }

        private void btnSubscription_Click(object sender, EventArgs e)
        {
            CheckBox[] chkStatus = new CheckBox[7];
            chkStatus[0] = chkAvailable;
            chkStatus[1] = chkBusy;
            chkStatus[2] = chkAway;
            chkStatus[3] = chkBreak;
            chkStatus[4] = chkMeal;
            chkStatus[5] = chkMeeting;
            chkStatus[6] = chkTraining;

            User userMember = new User(lstLog);
            //var id = userMember.GetUserId("Genesys Engineer");
            var id = userMember.GetUserId("Alexis Moussesian");
            
            if (id != null)
            {
                agent = new Agent(chkStatus, lstLog, id);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            var test = new Edges(lstLog);
            test.GetListOfEdge();

        }

        private void btnUnsubscription_Click(object sender, EventArgs e)
        {
            if (agent != null)
            {
                agent.Agent_unsubscription();
            }
        }

        private void btnImportEval_Click(object sender, EventArgs e)
        {
            User userMember = new User(lstLog);
            var id = userMember.GetUserId("Alexis Moussesian");

            quality.QueryEvaluations(id);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
           string jsonText = System.IO.File.ReadAllText("C:\\temp\\conv.txt");

            AddLog("PureCloud connection activated: " + jsonText);


            var json = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };

            AddLog("ParseMetrics json: " + json.ToString());


            var parsed = json.Deserialize<List<ConversationMetric>>(jsonText);

            foreach(var test in parsed)
            {
                AddLog($"ParseMetrics json: {test.attrName}");
            }

            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            User userMember = new User(lstLog);
            //var id = userMember.GetUserId("HYP_00_FIORIN_Henri_RZ1015");
            //userMember.UpdateRoleUser(id);

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV Files (*.csv)|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                userMember.UpdateRoleUser_FromCsv(dialog.FileName);
            }
        }

        private void btnGroupUpdate_Click(object sender, EventArgs e)
        {
            User userMember = new User(lstLog);

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV Files (*.csv)|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                userMember.AddGroupMembers_FromCsv(dialog.FileName);
            }
        }

        private void btnDeleteUsers_Click(object sender, EventArgs e)
        {
            User userMember = new User(lstLog);

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV Files (*.csv)|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                userMember.DeleteUsers_FromCsv(dialog.FileName);
            }
        }

        private void btnDefaultStation_Click(object sender, EventArgs e)
        {
            User user = new User(lstLog);

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV Files (*.csv)|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                user.SetDefaultStation_fromCsv(dialog.FileName);
            }
        }

        private void btnUserRole_Click(object sender, EventArgs e)
        {
            User userMember = new User(lstLog);
            userMember.ExportRoleUsers();
        }

        private void btnGetUserProfile_Click(object sender, EventArgs e)
        {
            User userMember = new User(lstLog);
            var id = userMember.GetUserId("Alexis Moussesian");
            userMember.GetUserProfile(id);
        }

        private void btnDeleteHomeDivision_Click(object sender, EventArgs e)
        {
            User user = new User(lstLog);

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV Files (*.csv)|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                user.DeleteHomeDivision_FromCsv_withApiLimit(dialog.FileName);
            }
        }

        private void btnLoadDatatable_Click(object sender, EventArgs e)
        {
            dt.GetDataTable();
        }
    }
}
