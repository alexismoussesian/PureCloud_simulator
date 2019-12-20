
namespace PureCloud_simulator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnButton2 = new System.Windows.Forms.Button();
            this.lblEnvironment = new System.Windows.Forms.Label();
            this.lblClientSecret = new System.Windows.Forms.Label();
            this.lblClientId = new System.Windows.Forms.Label();
            this.txtClientSecret = new System.Windows.Forms.TextBox();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.cmbEnvironment = new System.Windows.Forms.ComboBox();
            this.btnCreateQueue = new System.Windows.Forms.Button();
            this.btnButton3 = new System.Windows.Forms.Button();
            this.frmButton1 = new System.Windows.Forms.Button();
            this.btnGetQueue = new System.Windows.Forms.Button();
            this.btnActivate = new System.Windows.Forms.Button();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.cmbQueues = new System.Windows.Forms.ComboBox();
            this.lblQueues = new System.Windows.Forms.Label();
            this.btnAddRowsDataTable = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnAddSkill = new System.Windows.Forms.Button();
            this.btnGetSkills = new System.Windows.Forms.Button();
            this.btnGetDataTable = new System.Windows.Forms.Button();
            this.btnGetRowDataTable = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabQueues = new System.Windows.Forms.TabPage();
            this.btnGetUser = new System.Windows.Forms.Button();
            this.btmEwt2 = new System.Windows.Forms.Button();
            this.btnEwt = new System.Windows.Forms.Button();
            this.tabSkills = new System.Windows.Forms.TabPage();
            this.tabDataTables = new System.Windows.Forms.TabPage();
            this.comboDatatables = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCreateAndFillDataTable = new System.Windows.Forms.Button();
            this.btnCreateDataTable = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnImportWrapupCode = new System.Windows.Forms.Button();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.btnDeleteHomeDivision = new System.Windows.Forms.Button();
            this.btnGetUserProfile = new System.Windows.Forms.Button();
            this.btnUserRole = new System.Windows.Forms.Button();
            this.btnDefaultStation = new System.Windows.Forms.Button();
            this.btnDeleteUsers = new System.Windows.Forms.Button();
            this.btnGroupUpdate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnUnsubscription = new System.Windows.Forms.Button();
            this.chkTraining = new System.Windows.Forms.CheckBox();
            this.chkMeeting = new System.Windows.Forms.CheckBox();
            this.chkMeal = new System.Windows.Forms.CheckBox();
            this.chkBreak = new System.Windows.Forms.CheckBox();
            this.chkBusy = new System.Windows.Forms.CheckBox();
            this.chkAway = new System.Windows.Forms.CheckBox();
            this.chkAvailable = new System.Windows.Forms.CheckBox();
            this.btnSubscription = new System.Windows.Forms.Button();
            this.btnAway = new System.Windows.Forms.Button();
            this.btnAvailable = new System.Windows.Forms.Button();
            this.btnExportInCsvFile = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.tabPageInteractions = new System.Windows.Forms.TabPage();
            this.btnExportInteractions = new System.Windows.Forms.Button();
            this.tabQuality = new System.Windows.Forms.TabPage();
            this.btnImportEval = new System.Windows.Forms.Button();
            this.tabEdges = new System.Windows.Forms.TabPage();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.tmrEwt = new System.Windows.Forms.Timer(this.components);
            this.btnTest = new System.Windows.Forms.Button();
            this.btnLoadDatatable = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabQueues.SuspendLayout();
            this.tabSkills.SuspendLayout();
            this.tabDataTables.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabUsers.SuspendLayout();
            this.tabPageInteractions.SuspendLayout();
            this.tabQuality.SuspendLayout();
            this.tabEdges.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.btnButton2);
            this.groupBox1.Controls.Add(this.lblEnvironment);
            this.groupBox1.Controls.Add(this.lblClientSecret);
            this.groupBox1.Controls.Add(this.lblClientId);
            this.groupBox1.Controls.Add(this.txtClientSecret);
            this.groupBox1.Controls.Add(this.txtClientId);
            this.groupBox1.Controls.Add(this.cmbEnvironment);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 182);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PureCloud Settings";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(237, 134);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(100, 28);
            this.btnDisconnect.TabIndex = 20;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(129, 134);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 28);
            this.btnConnect.TabIndex = 19;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnButton2
            // 
            this.btnButton2.Location = new System.Drawing.Point(351, 133);
            this.btnButton2.Name = "btnButton2";
            this.btnButton2.Size = new System.Drawing.Size(75, 29);
            this.btnButton2.TabIndex = 15;
            this.btnButton2.Text = "GetOrg";
            this.btnButton2.UseVisualStyleBackColor = true;
            this.btnButton2.Click += new System.EventHandler(this.btnButton2_Click);
            // 
            // lblEnvironment
            // 
            this.lblEnvironment.AutoSize = true;
            this.lblEnvironment.Location = new System.Drawing.Point(31, 41);
            this.lblEnvironment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnvironment.Name = "lblEnvironment";
            this.lblEnvironment.Size = new System.Drawing.Size(91, 17);
            this.lblEnvironment.TabIndex = 18;
            this.lblEnvironment.Text = "Environment:";
            // 
            // lblClientSecret
            // 
            this.lblClientSecret.AutoSize = true;
            this.lblClientSecret.Location = new System.Drawing.Point(29, 106);
            this.lblClientSecret.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientSecret.Name = "lblClientSecret";
            this.lblClientSecret.Size = new System.Drawing.Size(92, 17);
            this.lblClientSecret.TabIndex = 17;
            this.lblClientSecret.Text = "Client Secret:";
            // 
            // lblClientId
            // 
            this.lblClientId.AutoSize = true;
            this.lblClientId.Location = new System.Drawing.Point(59, 74);
            this.lblClientId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(62, 17);
            this.lblClientId.TabIndex = 16;
            this.lblClientId.Text = "Client Id:";
            // 
            // txtClientSecret
            // 
            this.txtClientSecret.Location = new System.Drawing.Point(129, 104);
            this.txtClientSecret.Margin = new System.Windows.Forms.Padding(4);
            this.txtClientSecret.Name = "txtClientSecret";
            this.txtClientSecret.PasswordChar = '*';
            this.txtClientSecret.Size = new System.Drawing.Size(297, 22);
            this.txtClientSecret.TabIndex = 15;
            // 
            // txtClientId
            // 
            this.txtClientId.Location = new System.Drawing.Point(129, 72);
            this.txtClientId.Margin = new System.Windows.Forms.Padding(4);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.Size = new System.Drawing.Size(297, 22);
            this.txtClientId.TabIndex = 14;
            // 
            // cmbEnvironment
            // 
            this.cmbEnvironment.FormattingEnabled = true;
            this.cmbEnvironment.Items.AddRange(new object[] {
            "mypurecloud.ie",
            "mypurecloud.de",
            "mypurecloud.com",
            "mypurecloud.com.au",
            "mypurecloud.jp"});
            this.cmbEnvironment.Location = new System.Drawing.Point(129, 41);
            this.cmbEnvironment.Name = "cmbEnvironment";
            this.cmbEnvironment.Size = new System.Drawing.Size(297, 24);
            this.cmbEnvironment.TabIndex = 13;
            // 
            // btnCreateQueue
            // 
            this.btnCreateQueue.Location = new System.Drawing.Point(305, 29);
            this.btnCreateQueue.Name = "btnCreateQueue";
            this.btnCreateQueue.Size = new System.Drawing.Size(102, 23);
            this.btnCreateQueue.TabIndex = 17;
            this.btnCreateQueue.Text = "Import";
            this.btnCreateQueue.UseVisualStyleBackColor = true;
            this.btnCreateQueue.Click += new System.EventHandler(this.btnCreateQueue_Click);
            // 
            // btnButton3
            // 
            this.btnButton3.Location = new System.Drawing.Point(457, 119);
            this.btnButton3.Name = "btnButton3";
            this.btnButton3.Size = new System.Drawing.Size(86, 29);
            this.btnButton3.TabIndex = 16;
            this.btnButton3.Text = "GetAgents";
            this.btnButton3.UseVisualStyleBackColor = true;
            this.btnButton3.Click += new System.EventHandler(this.btnButton3_Click);
            // 
            // frmButton1
            // 
            this.frmButton1.Location = new System.Drawing.Point(148, 29);
            this.frmButton1.Name = "frmButton1";
            this.frmButton1.Size = new System.Drawing.Size(112, 23);
            this.frmButton1.TabIndex = 14;
            this.frmButton1.Text = "Get";
            this.frmButton1.UseVisualStyleBackColor = true;
            this.frmButton1.Click += new System.EventHandler(this.frmButton1_Click);
            // 
            // btnGetQueue
            // 
            this.btnGetQueue.Location = new System.Drawing.Point(25, 29);
            this.btnGetQueue.Name = "btnGetQueue";
            this.btnGetQueue.Size = new System.Drawing.Size(91, 23);
            this.btnGetQueue.TabIndex = 13;
            this.btnGetQueue.Text = "Get Queue";
            this.btnGetQueue.UseVisualStyleBackColor = true;
            this.btnGetQueue.Click += new System.EventHandler(this.btnGetQueue_Click);
            // 
            // btnActivate
            // 
            this.btnActivate.Location = new System.Drawing.Point(25, 119);
            this.btnActivate.Margin = new System.Windows.Forms.Padding(4);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(187, 28);
            this.btnActivate.TabIndex = 12;
            this.btnActivate.Text = "Activate All Members";
            this.btnActivate.UseVisualStyleBackColor = true;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // btnDeactivate
            // 
            this.btnDeactivate.Location = new System.Drawing.Point(240, 119);
            this.btnDeactivate.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(187, 28);
            this.btnDeactivate.TabIndex = 11;
            this.btnDeactivate.Text = "Deactivate All Members";
            this.btnDeactivate.UseVisualStyleBackColor = true;
            this.btnDeactivate.Click += new System.EventHandler(this.btnDeactivate_Click);
            // 
            // cmbQueues
            // 
            this.cmbQueues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQueues.FormattingEnabled = true;
            this.cmbQueues.Location = new System.Drawing.Point(92, 69);
            this.cmbQueues.Margin = new System.Windows.Forms.Padding(4);
            this.cmbQueues.Name = "cmbQueues";
            this.cmbQueues.Size = new System.Drawing.Size(400, 24);
            this.cmbQueues.TabIndex = 10;
            this.cmbQueues.SelectedIndexChanged += new System.EventHandler(this.cmbQueues_SelectedIndexChanged);
            // 
            // lblQueues
            // 
            this.lblQueues.AutoSize = true;
            this.lblQueues.Location = new System.Drawing.Point(22, 72);
            this.lblQueues.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQueues.Name = "lblQueues";
            this.lblQueues.Size = new System.Drawing.Size(62, 17);
            this.lblQueues.TabIndex = 0;
            this.lblQueues.Text = "Queues:";
            // 
            // btnAddRowsDataTable
            // 
            this.btnAddRowsDataTable.Location = new System.Drawing.Point(348, 27);
            this.btnAddRowsDataTable.Name = "btnAddRowsDataTable";
            this.btnAddRowsDataTable.Size = new System.Drawing.Size(104, 23);
            this.btnAddRowsDataTable.TabIndex = 18;
            this.btnAddRowsDataTable.Text = "AddRows";
            this.btnAddRowsDataTable.UseVisualStyleBackColor = true;
            this.btnAddRowsDataTable.Click += new System.EventHandler(this.btnAddRowsDataTable_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.Location = new System.Drawing.Point(13, 246);
            this.btnClearLog.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(100, 28);
            this.btnClearLog.TabIndex = 15;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click_1);
            // 
            // lstLog
            // 
            this.lstLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 16;
            this.lstLog.Location = new System.Drawing.Point(12, 298);
            this.lstLog.Margin = new System.Windows.Forms.Padding(4);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(1040, 180);
            this.lstLog.TabIndex = 16;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(12, 200);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 31);
            this.btnEncrypt.TabIndex = 17;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(106, 200);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 31);
            this.btnDecrypt.TabIndex = 18;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            // 
            // btnAddSkill
            // 
            this.btnAddSkill.Location = new System.Drawing.Point(135, 42);
            this.btnAddSkill.Name = "btnAddSkill";
            this.btnAddSkill.Size = new System.Drawing.Size(75, 23);
            this.btnAddSkill.TabIndex = 19;
            this.btnAddSkill.Text = "Add Skill";
            this.btnAddSkill.UseVisualStyleBackColor = true;
            this.btnAddSkill.Click += new System.EventHandler(this.btnAddSkill_Click);
            // 
            // btnGetSkills
            // 
            this.btnGetSkills.Location = new System.Drawing.Point(26, 42);
            this.btnGetSkills.Name = "btnGetSkills";
            this.btnGetSkills.Size = new System.Drawing.Size(91, 23);
            this.btnGetSkills.TabIndex = 20;
            this.btnGetSkills.Text = "Get Skills";
            this.btnGetSkills.UseVisualStyleBackColor = true;
            this.btnGetSkills.Click += new System.EventHandler(this.btnGetSkills_Click);
            // 
            // btnGetDataTable
            // 
            this.btnGetDataTable.Location = new System.Drawing.Point(123, 27);
            this.btnGetDataTable.Name = "btnGetDataTable";
            this.btnGetDataTable.Size = new System.Drawing.Size(98, 23);
            this.btnGetDataTable.TabIndex = 21;
            this.btnGetDataTable.Text = "Get DT";
            this.btnGetDataTable.UseVisualStyleBackColor = true;
            this.btnGetDataTable.Click += new System.EventHandler(this.btnGetDataTable_Click);
            // 
            // btnGetRowDataTable
            // 
            this.btnGetRowDataTable.Location = new System.Drawing.Point(241, 27);
            this.btnGetRowDataTable.Name = "btnGetRowDataTable";
            this.btnGetRowDataTable.Size = new System.Drawing.Size(75, 23);
            this.btnGetRowDataTable.TabIndex = 23;
            this.btnGetRowDataTable.Text = "Get Row";
            this.btnGetRowDataTable.UseVisualStyleBackColor = true;
            this.btnGetRowDataTable.Click += new System.EventHandler(this.btnGetRowDataTable_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabQueues);
            this.tabControl1.Controls.Add(this.tabSkills);
            this.tabControl1.Controls.Add(this.tabDataTables);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabUsers);
            this.tabControl1.Controls.Add(this.tabPageInteractions);
            this.tabControl1.Controls.Add(this.tabQuality);
            this.tabControl1.Controls.Add(this.tabEdges);
            this.tabControl1.Location = new System.Drawing.Point(475, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(578, 279);
            this.tabControl1.TabIndex = 24;
            // 
            // tabQueues
            // 
            this.tabQueues.Controls.Add(this.btnGetUser);
            this.tabQueues.Controls.Add(this.btmEwt2);
            this.tabQueues.Controls.Add(this.btnEwt);
            this.tabQueues.Controls.Add(this.btnButton3);
            this.tabQueues.Controls.Add(this.btnCreateQueue);
            this.tabQueues.Controls.Add(this.btnDeactivate);
            this.tabQueues.Controls.Add(this.btnActivate);
            this.tabQueues.Controls.Add(this.btnGetQueue);
            this.tabQueues.Controls.Add(this.frmButton1);
            this.tabQueues.Controls.Add(this.cmbQueues);
            this.tabQueues.Controls.Add(this.lblQueues);
            this.tabQueues.Location = new System.Drawing.Point(4, 25);
            this.tabQueues.Name = "tabQueues";
            this.tabQueues.Padding = new System.Windows.Forms.Padding(3);
            this.tabQueues.Size = new System.Drawing.Size(570, 250);
            this.tabQueues.TabIndex = 3;
            this.tabQueues.Text = "Queues";
            this.tabQueues.UseVisualStyleBackColor = true;
            // 
            // btnGetUser
            // 
            this.btnGetUser.Location = new System.Drawing.Point(240, 163);
            this.btnGetUser.Name = "btnGetUser";
            this.btnGetUser.Size = new System.Drawing.Size(87, 23);
            this.btnGetUser.TabIndex = 20;
            this.btnGetUser.Text = "Get User";
            this.btnGetUser.UseVisualStyleBackColor = true;
            this.btnGetUser.Click += new System.EventHandler(this.btnGetUser_Click);
            // 
            // btmEwt2
            // 
            this.btmEwt2.Location = new System.Drawing.Point(119, 163);
            this.btmEwt2.Name = "btmEwt2";
            this.btmEwt2.Size = new System.Drawing.Size(75, 23);
            this.btmEwt2.TabIndex = 19;
            this.btmEwt2.Text = "StopEwt";
            this.btmEwt2.UseVisualStyleBackColor = true;
            this.btmEwt2.Click += new System.EventHandler(this.btmEwt2_Click);
            // 
            // btnEwt
            // 
            this.btnEwt.Location = new System.Drawing.Point(25, 163);
            this.btnEwt.Name = "btnEwt";
            this.btnEwt.Size = new System.Drawing.Size(75, 23);
            this.btnEwt.TabIndex = 18;
            this.btnEwt.Text = "EWT";
            this.btnEwt.UseVisualStyleBackColor = true;
            this.btnEwt.Click += new System.EventHandler(this.btnEwt_Click);
            // 
            // tabSkills
            // 
            this.tabSkills.Controls.Add(this.btnGetSkills);
            this.tabSkills.Controls.Add(this.btnAddSkill);
            this.tabSkills.Location = new System.Drawing.Point(4, 25);
            this.tabSkills.Name = "tabSkills";
            this.tabSkills.Padding = new System.Windows.Forms.Padding(3);
            this.tabSkills.Size = new System.Drawing.Size(570, 250);
            this.tabSkills.TabIndex = 1;
            this.tabSkills.Text = "Skills";
            this.tabSkills.UseVisualStyleBackColor = true;
            // 
            // tabDataTables
            // 
            this.tabDataTables.Controls.Add(this.btnLoadDatatable);
            this.tabDataTables.Controls.Add(this.comboDatatables);
            this.tabDataTables.Controls.Add(this.btnImport);
            this.tabDataTables.Controls.Add(this.btnCreateAndFillDataTable);
            this.tabDataTables.Controls.Add(this.btnCreateDataTable);
            this.tabDataTables.Controls.Add(this.btnGetDataTable);
            this.tabDataTables.Controls.Add(this.btnAddRowsDataTable);
            this.tabDataTables.Controls.Add(this.btnGetRowDataTable);
            this.tabDataTables.Location = new System.Drawing.Point(4, 25);
            this.tabDataTables.Name = "tabDataTables";
            this.tabDataTables.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataTables.Size = new System.Drawing.Size(570, 250);
            this.tabDataTables.TabIndex = 2;
            this.tabDataTables.Text = "DataTables";
            this.tabDataTables.UseVisualStyleBackColor = true;
            // 
            // comboDatatables
            // 
            this.comboDatatables.FormattingEnabled = true;
            this.comboDatatables.Location = new System.Drawing.Point(23, 65);
            this.comboDatatables.Name = "comboDatatables";
            this.comboDatatables.Size = new System.Drawing.Size(198, 24);
            this.comboDatatables.TabIndex = 34;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(241, 94);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(136, 23);
            this.btnImport.TabIndex = 32;
            this.btnImport.Text = "Delete DT";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCreateAndFillDataTable
            // 
            this.btnCreateAndFillDataTable.Location = new System.Drawing.Point(241, 65);
            this.btnCreateAndFillDataTable.Name = "btnCreateAndFillDataTable";
            this.btnCreateAndFillDataTable.Size = new System.Drawing.Size(136, 23);
            this.btnCreateAndFillDataTable.TabIndex = 30;
            this.btnCreateAndFillDataTable.Text = "Create and fill DT";
            this.btnCreateAndFillDataTable.UseVisualStyleBackColor = true;
            this.btnCreateAndFillDataTable.Click += new System.EventHandler(this.btnCreateAndFillDataTable_Click);
            // 
            // btnCreateDataTable
            // 
            this.btnCreateDataTable.Location = new System.Drawing.Point(422, 65);
            this.btnCreateDataTable.Name = "btnCreateDataTable";
            this.btnCreateDataTable.Size = new System.Drawing.Size(132, 23);
            this.btnCreateDataTable.TabIndex = 29;
            this.btnCreateDataTable.Text = "Create DataTable";
            this.btnCreateDataTable.UseVisualStyleBackColor = true;
            this.btnCreateDataTable.Click += new System.EventHandler(this.btnCreateDataTable_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnImportWrapupCode);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(570, 250);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Wrapup code";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnImportWrapupCode
            // 
            this.btnImportWrapupCode.Location = new System.Drawing.Point(30, 16);
            this.btnImportWrapupCode.Name = "btnImportWrapupCode";
            this.btnImportWrapupCode.Size = new System.Drawing.Size(75, 23);
            this.btnImportWrapupCode.TabIndex = 0;
            this.btnImportWrapupCode.Text = "Import";
            this.btnImportWrapupCode.UseVisualStyleBackColor = true;
            this.btnImportWrapupCode.Click += new System.EventHandler(this.btnImportWrapupCode_Click);
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.btnDeleteHomeDivision);
            this.tabUsers.Controls.Add(this.btnGetUserProfile);
            this.tabUsers.Controls.Add(this.btnUserRole);
            this.tabUsers.Controls.Add(this.btnDefaultStation);
            this.tabUsers.Controls.Add(this.btnDeleteUsers);
            this.tabUsers.Controls.Add(this.btnGroupUpdate);
            this.tabUsers.Controls.Add(this.btnUpdate);
            this.tabUsers.Controls.Add(this.btnUnsubscription);
            this.tabUsers.Controls.Add(this.chkTraining);
            this.tabUsers.Controls.Add(this.chkMeeting);
            this.tabUsers.Controls.Add(this.chkMeal);
            this.tabUsers.Controls.Add(this.chkBreak);
            this.tabUsers.Controls.Add(this.chkBusy);
            this.tabUsers.Controls.Add(this.chkAway);
            this.tabUsers.Controls.Add(this.chkAvailable);
            this.tabUsers.Controls.Add(this.btnSubscription);
            this.tabUsers.Controls.Add(this.btnAway);
            this.tabUsers.Controls.Add(this.btnAvailable);
            this.tabUsers.Controls.Add(this.btnExportInCsvFile);
            this.tabUsers.Controls.Add(this.btnExport);
            this.tabUsers.Location = new System.Drawing.Point(4, 25);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(570, 250);
            this.tabUsers.TabIndex = 5;
            this.tabUsers.Text = "Users";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // btnDeleteHomeDivision
            // 
            this.btnDeleteHomeDivision.Location = new System.Drawing.Point(174, 216);
            this.btnDeleteHomeDivision.Name = "btnDeleteHomeDivision";
            this.btnDeleteHomeDivision.Size = new System.Drawing.Size(143, 23);
            this.btnDeleteHomeDivision.TabIndex = 19;
            this.btnDeleteHomeDivision.Text = "Del Home Div";
            this.btnDeleteHomeDivision.UseVisualStyleBackColor = true;
            this.btnDeleteHomeDivision.Click += new System.EventHandler(this.btnDeleteHomeDivision_Click);
            // 
            // btnGetUserProfile
            // 
            this.btnGetUserProfile.Location = new System.Drawing.Point(23, 221);
            this.btnGetUserProfile.Name = "btnGetUserProfile";
            this.btnGetUserProfile.Size = new System.Drawing.Size(123, 23);
            this.btnGetUserProfile.TabIndex = 18;
            this.btnGetUserProfile.Text = "GetUserProfile";
            this.btnGetUserProfile.UseVisualStyleBackColor = true;
            this.btnGetUserProfile.Click += new System.EventHandler(this.btnGetUserProfile_Click);
            // 
            // btnUserRole
            // 
            this.btnUserRole.Location = new System.Drawing.Point(23, 93);
            this.btnUserRole.Name = "btnUserRole";
            this.btnUserRole.Size = new System.Drawing.Size(145, 23);
            this.btnUserRole.TabIndex = 17;
            this.btnUserRole.Text = "Export user role";
            this.btnUserRole.UseVisualStyleBackColor = true;
            this.btnUserRole.Click += new System.EventHandler(this.btnUserRole_Click);
            // 
            // btnDefaultStation
            // 
            this.btnDefaultStation.Location = new System.Drawing.Point(174, 187);
            this.btnDefaultStation.Name = "btnDefaultStation";
            this.btnDefaultStation.Size = new System.Drawing.Size(143, 23);
            this.btnDefaultStation.TabIndex = 16;
            this.btnDefaultStation.Text = "Set default station";
            this.btnDefaultStation.UseVisualStyleBackColor = true;
            this.btnDefaultStation.Click += new System.EventHandler(this.btnDefaultStation_Click);
            // 
            // btnDeleteUsers
            // 
            this.btnDeleteUsers.Location = new System.Drawing.Point(174, 158);
            this.btnDeleteUsers.Name = "btnDeleteUsers";
            this.btnDeleteUsers.Size = new System.Drawing.Size(143, 23);
            this.btnDeleteUsers.TabIndex = 15;
            this.btnDeleteUsers.Text = "Delete users";
            this.btnDeleteUsers.UseVisualStyleBackColor = true;
            this.btnDeleteUsers.Click += new System.EventHandler(this.btnDeleteUsers_Click);
            // 
            // btnGroupUpdate
            // 
            this.btnGroupUpdate.Location = new System.Drawing.Point(174, 123);
            this.btnGroupUpdate.Name = "btnGroupUpdate";
            this.btnGroupUpdate.Size = new System.Drawing.Size(143, 23);
            this.btnGroupUpdate.TabIndex = 14;
            this.btnGroupUpdate.Text = "Update group";
            this.btnGroupUpdate.UseVisualStyleBackColor = true;
            this.btnGroupUpdate.Click += new System.EventHandler(this.btnGroupUpdate_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(174, 93);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(143, 23);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Update role";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnUnsubscription
            // 
            this.btnUnsubscription.Location = new System.Drawing.Point(174, 61);
            this.btnUnsubscription.Name = "btnUnsubscription";
            this.btnUnsubscription.Size = new System.Drawing.Size(143, 23);
            this.btnUnsubscription.TabIndex = 12;
            this.btnUnsubscription.Text = "Unsubscription";
            this.btnUnsubscription.UseVisualStyleBackColor = true;
            this.btnUnsubscription.Click += new System.EventHandler(this.btnUnsubscription_Click);
            // 
            // chkTraining
            // 
            this.chkTraining.AutoSize = true;
            this.chkTraining.ForeColor = System.Drawing.Color.Goldenrod;
            this.chkTraining.Location = new System.Drawing.Point(365, 158);
            this.chkTraining.Name = "chkTraining";
            this.chkTraining.Size = new System.Drawing.Size(82, 21);
            this.chkTraining.TabIndex = 11;
            this.chkTraining.Text = "Training";
            this.chkTraining.UseVisualStyleBackColor = true;
            // 
            // chkMeeting
            // 
            this.chkMeeting.AutoSize = true;
            this.chkMeeting.ForeColor = System.Drawing.Color.Red;
            this.chkMeeting.Location = new System.Drawing.Point(365, 137);
            this.chkMeeting.Name = "chkMeeting";
            this.chkMeeting.Size = new System.Drawing.Size(80, 21);
            this.chkMeeting.TabIndex = 10;
            this.chkMeeting.Text = "Meeting";
            this.chkMeeting.UseVisualStyleBackColor = true;
            // 
            // chkMeal
            // 
            this.chkMeal.AutoSize = true;
            this.chkMeal.ForeColor = System.Drawing.Color.Goldenrod;
            this.chkMeal.Location = new System.Drawing.Point(365, 116);
            this.chkMeal.Name = "chkMeal";
            this.chkMeal.Size = new System.Drawing.Size(60, 21);
            this.chkMeal.TabIndex = 9;
            this.chkMeal.Text = "Meal";
            this.chkMeal.UseVisualStyleBackColor = true;
            // 
            // chkBreak
            // 
            this.chkBreak.AutoSize = true;
            this.chkBreak.ForeColor = System.Drawing.Color.Goldenrod;
            this.chkBreak.Location = new System.Drawing.Point(365, 93);
            this.chkBreak.Name = "chkBreak";
            this.chkBreak.Size = new System.Drawing.Size(67, 21);
            this.chkBreak.TabIndex = 8;
            this.chkBreak.Text = "Break";
            this.chkBreak.UseVisualStyleBackColor = true;
            // 
            // chkBusy
            // 
            this.chkBusy.AutoSize = true;
            this.chkBusy.ForeColor = System.Drawing.Color.Red;
            this.chkBusy.Location = new System.Drawing.Point(365, 51);
            this.chkBusy.Name = "chkBusy";
            this.chkBusy.Size = new System.Drawing.Size(61, 21);
            this.chkBusy.TabIndex = 7;
            this.chkBusy.Text = "Busy";
            this.chkBusy.UseVisualStyleBackColor = true;
            // 
            // chkAway
            // 
            this.chkAway.AutoSize = true;
            this.chkAway.ForeColor = System.Drawing.Color.Goldenrod;
            this.chkAway.Location = new System.Drawing.Point(365, 72);
            this.chkAway.Name = "chkAway";
            this.chkAway.Size = new System.Drawing.Size(63, 21);
            this.chkAway.TabIndex = 6;
            this.chkAway.Text = "Away";
            this.chkAway.UseVisualStyleBackColor = true;
            // 
            // chkAvailable
            // 
            this.chkAvailable.AutoSize = true;
            this.chkAvailable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.chkAvailable.Location = new System.Drawing.Point(365, 31);
            this.chkAvailable.Name = "chkAvailable";
            this.chkAvailable.Size = new System.Drawing.Size(87, 21);
            this.chkAvailable.TabIndex = 5;
            this.chkAvailable.Text = "Available";
            this.chkAvailable.UseVisualStyleBackColor = true;
            // 
            // btnSubscription
            // 
            this.btnSubscription.Location = new System.Drawing.Point(174, 31);
            this.btnSubscription.Name = "btnSubscription";
            this.btnSubscription.Size = new System.Drawing.Size(143, 23);
            this.btnSubscription.TabIndex = 4;
            this.btnSubscription.Text = "Subscription";
            this.btnSubscription.UseVisualStyleBackColor = true;
            this.btnSubscription.Click += new System.EventHandler(this.btnSubscription_Click);
            // 
            // btnAway
            // 
            this.btnAway.Location = new System.Drawing.Point(23, 187);
            this.btnAway.Name = "btnAway";
            this.btnAway.Size = new System.Drawing.Size(75, 23);
            this.btnAway.TabIndex = 3;
            this.btnAway.Text = "Away";
            this.btnAway.UseVisualStyleBackColor = true;
            this.btnAway.Click += new System.EventHandler(this.btnAway_Click);
            // 
            // btnAvailable
            // 
            this.btnAvailable.Location = new System.Drawing.Point(23, 156);
            this.btnAvailable.Name = "btnAvailable";
            this.btnAvailable.Size = new System.Drawing.Size(75, 23);
            this.btnAvailable.TabIndex = 2;
            this.btnAvailable.Text = "Available";
            this.btnAvailable.UseVisualStyleBackColor = true;
            this.btnAvailable.Click += new System.EventHandler(this.btnAvailable_Click);
            // 
            // btnExportInCsvFile
            // 
            this.btnExportInCsvFile.Location = new System.Drawing.Point(23, 61);
            this.btnExportInCsvFile.Name = "btnExportInCsvFile";
            this.btnExportInCsvFile.Size = new System.Drawing.Size(145, 23);
            this.btnExportInCsvFile.TabIndex = 1;
            this.btnExportInCsvFile.Text = "Export user queue";
            this.btnExportInCsvFile.UseVisualStyleBackColor = true;
            this.btnExportInCsvFile.Click += new System.EventHandler(this.btnExportInCsvFile_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(23, 31);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(145, 23);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export user";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tabPageInteractions
            // 
            this.tabPageInteractions.Controls.Add(this.btnExportInteractions);
            this.tabPageInteractions.Location = new System.Drawing.Point(4, 25);
            this.tabPageInteractions.Name = "tabPageInteractions";
            this.tabPageInteractions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInteractions.Size = new System.Drawing.Size(570, 250);
            this.tabPageInteractions.TabIndex = 6;
            this.tabPageInteractions.Text = "Interactions";
            this.tabPageInteractions.UseVisualStyleBackColor = true;
            // 
            // btnExportInteractions
            // 
            this.btnExportInteractions.Location = new System.Drawing.Point(25, 16);
            this.btnExportInteractions.Name = "btnExportInteractions";
            this.btnExportInteractions.Size = new System.Drawing.Size(133, 23);
            this.btnExportInteractions.TabIndex = 0;
            this.btnExportInteractions.Text = "Export Interactions";
            this.btnExportInteractions.UseVisualStyleBackColor = true;
            this.btnExportInteractions.Click += new System.EventHandler(this.btnExportInteractions_Click);
            // 
            // tabQuality
            // 
            this.tabQuality.Controls.Add(this.btnImportEval);
            this.tabQuality.Location = new System.Drawing.Point(4, 25);
            this.tabQuality.Name = "tabQuality";
            this.tabQuality.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuality.Size = new System.Drawing.Size(570, 250);
            this.tabQuality.TabIndex = 8;
            this.tabQuality.Text = "Quality";
            this.tabQuality.UseVisualStyleBackColor = true;
            // 
            // btnImportEval
            // 
            this.btnImportEval.Location = new System.Drawing.Point(25, 16);
            this.btnImportEval.Name = "btnImportEval";
            this.btnImportEval.Size = new System.Drawing.Size(102, 23);
            this.btnImportEval.TabIndex = 0;
            this.btnImportEval.Text = "Import eval";
            this.btnImportEval.UseVisualStyleBackColor = true;
            this.btnImportEval.Click += new System.EventHandler(this.btnImportEval_Click);
            // 
            // tabEdges
            // 
            this.tabEdges.Controls.Add(this.btnMonitor);
            this.tabEdges.Location = new System.Drawing.Point(4, 25);
            this.tabEdges.Name = "tabEdges";
            this.tabEdges.Size = new System.Drawing.Size(570, 250);
            this.tabEdges.TabIndex = 7;
            this.tabEdges.Text = "Edges";
            this.tabEdges.UseVisualStyleBackColor = true;
            // 
            // btnMonitor
            // 
            this.btnMonitor.Location = new System.Drawing.Point(22, 34);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(75, 23);
            this.btnMonitor.TabIndex = 0;
            this.btnMonitor.Text = "Monitor";
            this.btnMonitor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMonitor.UseVisualStyleBackColor = true;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // tmrEwt
            // 
            this.tmrEwt.Interval = 2000;
            this.tmrEwt.Tick += new System.EventHandler(this.tmrEwt_Tick);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(201, 200);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 31);
            this.btnTest.TabIndex = 25;
            this.btnTest.Text = "test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnLoadDatatable
            // 
            this.btnLoadDatatable.Location = new System.Drawing.Point(23, 27);
            this.btnLoadDatatable.Name = "btnLoadDatatable";
            this.btnLoadDatatable.Size = new System.Drawing.Size(94, 23);
            this.btnLoadDatatable.TabIndex = 35;
            this.btnLoadDatatable.Text = "Load DT";
            this.btnLoadDatatable.UseVisualStyleBackColor = true;
            this.btnLoadDatatable.Click += new System.EventHandler(this.btnLoadDatatable_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 498);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "PureCloud Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabQueues.ResumeLayout(false);
            this.tabQueues.PerformLayout();
            this.tabSkills.ResumeLayout(false);
            this.tabDataTables.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            this.tabUsers.PerformLayout();
            this.tabPageInteractions.ResumeLayout(false);
            this.tabQuality.ResumeLayout(false);
            this.tabEdges.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblEnvironment;
        private System.Windows.Forms.Label lblClientSecret;
        private System.Windows.Forms.Label lblClientId;
        private System.Windows.Forms.TextBox txtClientSecret;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.ComboBox cmbEnvironment;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Button btnDeactivate;
        private System.Windows.Forms.ComboBox cmbQueues;
        private System.Windows.Forms.Label lblQueues;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Button btnGetQueue;
        private System.Windows.Forms.Button frmButton1;
        private System.Windows.Forms.Button btnButton2;
        private System.Windows.Forms.Button btnButton3;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnAddSkill;
        private System.Windows.Forms.Button btnGetSkills;
        private System.Windows.Forms.Button btnGetDataTable;
        private System.Windows.Forms.Button btnGetRowDataTable;
        private System.Windows.Forms.Button btnCreateQueue;
        private System.Windows.Forms.Button btnAddRowsDataTable;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabQueues;
        private System.Windows.Forms.TabPage tabSkills;
        private System.Windows.Forms.TabPage tabDataTables;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnImportWrapupCode;
        private System.Windows.Forms.Button btnEwt;
        private System.Windows.Forms.Timer tmrEwt;
        private System.Windows.Forms.Button btmEwt2;
        private System.Windows.Forms.Button btnCreateDataTable;
        private System.Windows.Forms.Button btnCreateAndFillDataTable;
        private System.Windows.Forms.Button btnGetUser;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExportInCsvFile;
        private System.Windows.Forms.TabPage tabPageInteractions;
        private System.Windows.Forms.Button btnExportInteractions;
        private System.Windows.Forms.Button btnAway;
        private System.Windows.Forms.Button btnAvailable;
        private System.Windows.Forms.Button btnSubscription;
        private System.Windows.Forms.CheckBox chkAway;
        private System.Windows.Forms.CheckBox chkAvailable;
        private System.Windows.Forms.TabPage tabEdges;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.CheckBox chkTraining;
        private System.Windows.Forms.CheckBox chkMeeting;
        private System.Windows.Forms.CheckBox chkMeal;
        private System.Windows.Forms.CheckBox chkBreak;
        private System.Windows.Forms.CheckBox chkBusy;
        private System.Windows.Forms.Button btnUnsubscription;
        private System.Windows.Forms.TabPage tabQuality;
        private System.Windows.Forms.Button btnImportEval;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnGroupUpdate;
        private System.Windows.Forms.Button btnDeleteUsers;
        private System.Windows.Forms.Button btnDefaultStation;
        private System.Windows.Forms.Button btnUserRole;
        private System.Windows.Forms.Button btnGetUserProfile;
        private System.Windows.Forms.Button btnDeleteHomeDivision;
        private System.Windows.Forms.ComboBox comboDatatables;
        private System.Windows.Forms.Button btnLoadDatatable;
    }
}

