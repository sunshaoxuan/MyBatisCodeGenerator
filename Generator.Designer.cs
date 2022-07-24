namespace MyBatisCodeGenerator
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tabcMain = new System.Windows.Forms.TabControl();
            this.tabGenerator = new System.Windows.Forms.TabPage();
            this.btnPublish = new System.Windows.Forms.Button();
            this.dtgStepLog = new System.Windows.Forms.DataGridView();
            this.colIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.colText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strpStatus = new System.Windows.Forms.StatusStrip();
            this.tstrpProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tstrsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnSelectReverse = new System.Windows.Forms.Button();
            this.btnSelectNone = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.chkStopOnError = new System.Windows.Forms.CheckBox();
            this.chkCreatePath = new System.Windows.Forms.CheckBox();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.chklTemplate = new System.Windows.Forms.CheckedListBox();
            this.lblUsedTemplate = new System.Windows.Forms.Label();
            this.btnScriptSavePath = new System.Windows.Forms.Button();
            this.btnSourceCodeRoot = new System.Windows.Forms.Button();
            this.btnDesignFileBrowse = new System.Windows.Forms.Button();
            this.txtScriptSavePath = new System.Windows.Forms.TextBox();
            this.txtSourceCodeRoot = new System.Windows.Forms.TextBox();
            this.txtDesignFile = new System.Windows.Forms.TextBox();
            this.lblScriptSavePath = new System.Windows.Forms.Label();
            this.lblSourceRoot = new System.Windows.Forms.Label();
            this.lblDesignFile = new System.Windows.Forms.Label();
            this.tabTemplate = new System.Windows.Forms.TabPage();
            this.tabcTemplates = new System.Windows.Forms.TabControl();
            this.tabEntities = new System.Windows.Forms.TabPage();
            this.rtbEntityTpl = new System.Windows.Forms.RichTextBox();
            this.btnEntityTpl = new System.Windows.Forms.Button();
            this.txtEntityTpl = new System.Windows.Forms.TextBox();
            this.lblEntityTpl = new System.Windows.Forms.Label();
            this.tabEntityExtends = new System.Windows.Forms.TabPage();
            this.rtbSqlProviderTpl = new System.Windows.Forms.RichTextBox();
            this.btnSqlProviderTpl = new System.Windows.Forms.Button();
            this.txtSqlProviderTpl = new System.Windows.Forms.TextBox();
            this.lblSqlProviderTpl = new System.Windows.Forms.Label();
            this.tabMappers = new System.Windows.Forms.TabPage();
            this.rtbMapperTpl = new System.Windows.Forms.RichTextBox();
            this.btnMapperTpl = new System.Windows.Forms.Button();
            this.txtMapperTpl = new System.Windows.Forms.TextBox();
            this.lblMapperTpl = new System.Windows.Forms.Label();
            this.tabMapperExtend = new System.Windows.Forms.TabPage();
            this.rtbMapperExtendTpl = new System.Windows.Forms.RichTextBox();
            this.btnMapperExtendTpl = new System.Windows.Forms.Button();
            this.txtMapperExtendTpl = new System.Windows.Forms.TextBox();
            this.lblMapperExtendTpl = new System.Windows.Forms.Label();
            this.tabCreateTableScripts = new System.Windows.Forms.TabPage();
            this.rtbCreateTableTpl = new System.Windows.Forms.RichTextBox();
            this.btnCreateTableTpl = new System.Windows.Forms.Button();
            this.txtCreateTableTpl = new System.Windows.Forms.TextBox();
            this.lblCreateTableTpl = new System.Windows.Forms.Label();
            this.tabInsertDataScripts = new System.Windows.Forms.TabPage();
            this.rtbInsertDataTpl = new System.Windows.Forms.RichTextBox();
            this.btnInsertDataTpl = new System.Windows.Forms.Button();
            this.txtInsertDataTpl = new System.Windows.Forms.TextBox();
            this.lblInsertDataTpl = new System.Windows.Forms.Label();
            this.tabMultiLangEntity = new System.Windows.Forms.TabPage();
            this.rtbMultiLangEntity = new System.Windows.Forms.RichTextBox();
            this.btnMultiLangEntity = new System.Windows.Forms.Button();
            this.txtMultiLangEntity = new System.Windows.Forms.TextBox();
            this.lblMultiLangEntity = new System.Windows.Forms.Label();
            this.tabMultiLangSqlProvider = new System.Windows.Forms.TabPage();
            this.rtbMultiLangSqlProvider = new System.Windows.Forms.RichTextBox();
            this.btnMultiLangSqlProvider = new System.Windows.Forms.Button();
            this.txtMultiLangSqlProvider = new System.Windows.Forms.TextBox();
            this.lblMultiLangSqlProvider = new System.Windows.Forms.Label();
            this.tabMultiLangMapper = new System.Windows.Forms.TabPage();
            this.rtbMultiLangMapper = new System.Windows.Forms.RichTextBox();
            this.btnMultiLangMapper = new System.Windows.Forms.Button();
            this.txtMultiLangMapper = new System.Windows.Forms.TextBox();
            this.lblMultiLangMapper = new System.Windows.Forms.Label();
            this.tabMultiLangMapperExtend = new System.Windows.Forms.TabPage();
            this.rtbMultiLangMapperExtend = new System.Windows.Forms.RichTextBox();
            this.btnMultiLangMapperExtend = new System.Windows.Forms.Button();
            this.txtMultiLangMapperExtend = new System.Windows.Forms.TextBox();
            this.lblMultiLangMapperExtend = new System.Windows.Forms.Label();
            this.tabMultiLangCreateTable = new System.Windows.Forms.TabPage();
            this.rtbMultiLangCreateTable = new System.Windows.Forms.RichTextBox();
            this.btnMultiLangCreateTable = new System.Windows.Forms.Button();
            this.txtMultiLangCreateTable = new System.Windows.Forms.TextBox();
            this.lblMultLangCreateTable = new System.Windows.Forms.Label();
            this.tabMultiLangInsertData = new System.Windows.Forms.TabPage();
            this.rtbMultiLangInsertData = new System.Windows.Forms.RichTextBox();
            this.btnMultiLangInsertData = new System.Windows.Forms.Button();
            this.txtMultiLangInsertData = new System.Windows.Forms.TextBox();
            this.lblMultiLangInsertData = new System.Windows.Forms.Label();
            this.tabVO = new System.Windows.Forms.TabPage();
            this.rtbVOTpl = new System.Windows.Forms.RichTextBox();
            this.btnVO = new System.Windows.Forms.Button();
            this.txtVO = new System.Windows.Forms.TextBox();
            this.lblVO = new System.Windows.Forms.Label();
            this.tabAggVO = new System.Windows.Forms.TabPage();
            this.rtbAggVO = new System.Windows.Forms.RichTextBox();
            this.btnAggVO = new System.Windows.Forms.Button();
            this.txtAggVO = new System.Windows.Forms.TextBox();
            this.lblAggVO = new System.Windows.Forms.Label();
            this.tabRest = new System.Windows.Forms.TabPage();
            this.rtbRestTpl = new System.Windows.Forms.RichTextBox();
            this.btnRestTpl = new System.Windows.Forms.Button();
            this.txtRestTpl = new System.Windows.Forms.TextBox();
            this.lblRestTpl = new System.Windows.Forms.Label();
            this.tabService = new System.Windows.Forms.TabPage();
            this.rtbServiceTpl = new System.Windows.Forms.RichTextBox();
            this.btnServiceTpl = new System.Windows.Forms.Button();
            this.txtServiceTpl = new System.Windows.Forms.TextBox();
            this.lblServiceTpl = new System.Windows.Forms.Label();
            this.tabServiceImpl = new System.Windows.Forms.TabPage();
            this.rtbServiceImplTpl = new System.Windows.Forms.RichTextBox();
            this.btnServiceImplTpl = new System.Windows.Forms.Button();
            this.txtServiceImplTpl = new System.Windows.Forms.TextBox();
            this.lblServiceImplTpl = new System.Windows.Forms.Label();
            this.tabSetting = new System.Windows.Forms.TabPage();
            this.grpPublish = new System.Windows.Forms.GroupBox();
            this.lblBaseExecutive = new System.Windows.Forms.Label();
            this.txtBaseExecutive = new System.Windows.Forms.TextBox();
            this.chkExecuteMultiLang = new System.Windows.Forms.CheckBox();
            this.lblDBConnStr = new System.Windows.Forms.Label();
            this.txtDBConnStr = new System.Windows.Forms.TextBox();
            this.grpGenerate = new System.Windows.Forms.GroupBox();
            this.lblInsertTablePrefix = new System.Windows.Forms.Label();
            this.txtInsertDataPrefix = new System.Windows.Forms.TextBox();
            this.lblCreateTablePrefix = new System.Windows.Forms.Label();
            this.txtCreateTablePrefix = new System.Windows.Forms.TextBox();
            this.btnChangeColor = new System.Windows.Forms.Button();
            this.txtTagColor = new System.Windows.Forms.TextBox();
            this.lblClassRoot = new System.Windows.Forms.Label();
            this.lblTagColor = new System.Windows.Forms.Label();
            this.chkGenerateAuthor = new System.Windows.Forms.CheckBox();
            this.txtClassRoot = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tabAggVORequest = new System.Windows.Forms.TabPage();
            this.rtbAggVORequestTpl = new System.Windows.Forms.RichTextBox();
            this.btnAggVORequestTpl = new System.Windows.Forms.Button();
            this.txtAggVORequestTpl = new System.Windows.Forms.TextBox();
            this.lblAggVORequestTpl = new System.Windows.Forms.Label();
            this.tabcMain.SuspendLayout();
            this.tabGenerator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgStepLog)).BeginInit();
            this.strpStatus.SuspendLayout();
            this.tabTemplate.SuspendLayout();
            this.tabcTemplates.SuspendLayout();
            this.tabEntities.SuspendLayout();
            this.tabEntityExtends.SuspendLayout();
            this.tabMappers.SuspendLayout();
            this.tabMapperExtend.SuspendLayout();
            this.tabCreateTableScripts.SuspendLayout();
            this.tabInsertDataScripts.SuspendLayout();
            this.tabMultiLangEntity.SuspendLayout();
            this.tabMultiLangSqlProvider.SuspendLayout();
            this.tabMultiLangMapper.SuspendLayout();
            this.tabMultiLangMapperExtend.SuspendLayout();
            this.tabMultiLangCreateTable.SuspendLayout();
            this.tabMultiLangInsertData.SuspendLayout();
            this.tabVO.SuspendLayout();
            this.tabAggVO.SuspendLayout();
            this.tabRest.SuspendLayout();
            this.tabService.SuspendLayout();
            this.tabServiceImpl.SuspendLayout();
            this.tabSetting.SuspendLayout();
            this.grpPublish.SuspendLayout();
            this.grpGenerate.SuspendLayout();
            this.tabAggVORequest.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabcMain
            // 
            this.tabcMain.Controls.Add(this.tabGenerator);
            this.tabcMain.Controls.Add(this.tabTemplate);
            this.tabcMain.Controls.Add(this.tabSetting);
            this.tabcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabcMain.Location = new System.Drawing.Point(0, 0);
            this.tabcMain.Name = "tabcMain";
            this.tabcMain.SelectedIndex = 0;
            this.tabcMain.Size = new System.Drawing.Size(784, 561);
            this.tabcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabcMain.TabIndex = 0;
            // 
            // tabGenerator
            // 
            this.tabGenerator.Controls.Add(this.btnPublish);
            this.tabGenerator.Controls.Add(this.dtgStepLog);
            this.tabGenerator.Controls.Add(this.strpStatus);
            this.tabGenerator.Controls.Add(this.btnStop);
            this.tabGenerator.Controls.Add(this.btnRun);
            this.tabGenerator.Controls.Add(this.btnSelectReverse);
            this.tabGenerator.Controls.Add(this.btnSelectNone);
            this.tabGenerator.Controls.Add(this.btnSelectAll);
            this.tabGenerator.Controls.Add(this.chkStopOnError);
            this.tabGenerator.Controls.Add(this.chkCreatePath);
            this.tabGenerator.Controls.Add(this.chkOverwrite);
            this.tabGenerator.Controls.Add(this.chklTemplate);
            this.tabGenerator.Controls.Add(this.lblUsedTemplate);
            this.tabGenerator.Controls.Add(this.btnScriptSavePath);
            this.tabGenerator.Controls.Add(this.btnSourceCodeRoot);
            this.tabGenerator.Controls.Add(this.btnDesignFileBrowse);
            this.tabGenerator.Controls.Add(this.txtScriptSavePath);
            this.tabGenerator.Controls.Add(this.txtSourceCodeRoot);
            this.tabGenerator.Controls.Add(this.txtDesignFile);
            this.tabGenerator.Controls.Add(this.lblScriptSavePath);
            this.tabGenerator.Controls.Add(this.lblSourceRoot);
            this.tabGenerator.Controls.Add(this.lblDesignFile);
            this.tabGenerator.Location = new System.Drawing.Point(4, 22);
            this.tabGenerator.Name = "tabGenerator";
            this.tabGenerator.Padding = new System.Windows.Forms.Padding(3);
            this.tabGenerator.Size = new System.Drawing.Size(776, 535);
            this.tabGenerator.TabIndex = 0;
            this.tabGenerator.Text = "Generator";
            this.tabGenerator.UseVisualStyleBackColor = true;
            // 
            // btnPublish
            // 
            this.btnPublish.Location = new System.Drawing.Point(683, 227);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(75, 23);
            this.btnPublish.TabIndex = 10;
            this.btnPublish.Text = "Publish (&P)";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // dtgStepLog
            // 
            this.dtgStepLog.AllowUserToAddRows = false;
            this.dtgStepLog.AllowUserToDeleteRows = false;
            this.dtgStepLog.AllowUserToResizeColumns = false;
            this.dtgStepLog.AllowUserToResizeRows = false;
            this.dtgStepLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgStepLog.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgStepLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgStepLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgStepLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIcon,
            this.colText});
            this.dtgStepLog.Location = new System.Drawing.Point(3, 258);
            this.dtgStepLog.Name = "dtgStepLog";
            this.dtgStepLog.ReadOnly = true;
            this.dtgStepLog.RowTemplate.Height = 21;
            this.dtgStepLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgStepLog.ShowCellErrors = false;
            this.dtgStepLog.ShowEditingIcon = false;
            this.dtgStepLog.ShowRowErrors = false;
            this.dtgStepLog.Size = new System.Drawing.Size(770, 249);
            this.dtgStepLog.TabIndex = 9;
            this.dtgStepLog.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgStepLog_CellValueChanged);
            // 
            // colIcon
            // 
            this.colIcon.HeaderText = "";
            this.colIcon.MinimumWidth = 16;
            this.colIcon.Name = "colIcon";
            this.colIcon.ReadOnly = true;
            this.colIcon.Width = 16;
            // 
            // colText
            // 
            this.colText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colText.HeaderText = "Message";
            this.colText.Name = "colText";
            this.colText.ReadOnly = true;
            // 
            // strpStatus
            // 
            this.strpStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstrpProgress,
            this.tstrsStatus});
            this.strpStatus.Location = new System.Drawing.Point(3, 510);
            this.strpStatus.Name = "strpStatus";
            this.strpStatus.Size = new System.Drawing.Size(770, 22);
            this.strpStatus.TabIndex = 8;
            this.strpStatus.Text = "statusStrip1";
            // 
            // tstrpProgress
            // 
            this.tstrpProgress.Name = "tstrpProgress";
            this.tstrpProgress.Size = new System.Drawing.Size(200, 16);
            this.tstrpProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.tstrpProgress.Visible = false;
            // 
            // tstrsStatus
            // 
            this.tstrsStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tstrsStatus.Name = "tstrsStatus";
            this.tstrsStatus.Size = new System.Drawing.Size(0, 17);
            this.tstrsStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(584, 227);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop (&S)";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnRun.Location = new System.Drawing.Point(503, 227);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 7;
            this.btnRun.Text = "Run (&R)";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnSelectReverse
            // 
            this.btnSelectReverse.Location = new System.Drawing.Point(445, 77);
            this.btnSelectReverse.Name = "btnSelectReverse";
            this.btnSelectReverse.Size = new System.Drawing.Size(55, 20);
            this.btnSelectReverse.TabIndex = 6;
            this.btnSelectReverse.Text = "Reverse";
            this.btnSelectReverse.UseVisualStyleBackColor = true;
            this.btnSelectReverse.Click += new System.EventHandler(this.btnSelectReverse_Click);
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Location = new System.Drawing.Point(445, 58);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(55, 20);
            this.btnSelectNone.TabIndex = 6;
            this.btnSelectNone.Text = "None";
            this.btnSelectNone.UseVisualStyleBackColor = true;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(445, 39);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(55, 20);
            this.btnSelectAll.TabIndex = 6;
            this.btnSelectAll.Text = "All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // chkStopOnError
            // 
            this.chkStopOnError.AutoSize = true;
            this.chkStopOnError.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkStopOnError.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkStopOnError.Location = new System.Drawing.Point(532, 77);
            this.chkStopOnError.Name = "chkStopOnError";
            this.chkStopOnError.Size = new System.Drawing.Size(113, 17);
            this.chkStopOnError.TabIndex = 5;
            this.chkStopOnError.Text = "Stop On Error";
            this.chkStopOnError.UseVisualStyleBackColor = true;
            // 
            // chkCreatePath
            // 
            this.chkCreatePath.AutoSize = true;
            this.chkCreatePath.Checked = true;
            this.chkCreatePath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCreatePath.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkCreatePath.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkCreatePath.Location = new System.Drawing.Point(532, 58);
            this.chkCreatePath.Name = "chkCreatePath";
            this.chkCreatePath.Size = new System.Drawing.Size(205, 17);
            this.chkCreatePath.TabIndex = 5;
            this.chkCreatePath.Text = "Create non-exist Directories";
            this.chkCreatePath.UseVisualStyleBackColor = true;
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.Checked = true;
            this.chkOverwrite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOverwrite.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOverwrite.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkOverwrite.Location = new System.Drawing.Point(532, 39);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Size = new System.Drawing.Size(159, 17);
            this.chkOverwrite.TabIndex = 5;
            this.chkOverwrite.Text = "Overwrite Exist Files";
            this.chkOverwrite.UseVisualStyleBackColor = true;
            // 
            // chklTemplate
            // 
            this.chklTemplate.CheckOnClick = true;
            this.chklTemplate.FormattingEnabled = true;
            this.chklTemplate.Items.AddRange(new object[] {
            "Entities",
            "SqlProvider",
            "Mappers",
            "MapperExtends",
            "Create Table Scripts",
            "Insert Data Scripts",
            "MultiLanguage",
            "VO",
            "AggVO",
            "Rest",
            "Service",
            "ServiceImpl",
            "AggVORequest"});
            this.chklTemplate.Location = new System.Drawing.Point(155, 39);
            this.chklTemplate.MultiColumn = true;
            this.chklTemplate.Name = "chklTemplate";
            this.chklTemplate.Size = new System.Drawing.Size(284, 130);
            this.chklTemplate.TabIndex = 4;
            this.chklTemplate.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklTemplate_ItemCheck);
            this.chklTemplate.SelectedValueChanged += new System.EventHandler(this.chklTemplate_SelectedValueChanged_1);
            // 
            // lblUsedTemplate
            // 
            this.lblUsedTemplate.AutoSize = true;
            this.lblUsedTemplate.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUsedTemplate.ForeColor = System.Drawing.Color.Red;
            this.lblUsedTemplate.Location = new System.Drawing.Point(43, 39);
            this.lblUsedTemplate.Name = "lblUsedTemplate";
            this.lblUsedTemplate.Size = new System.Drawing.Size(102, 12);
            this.lblUsedTemplate.TabIndex = 3;
            this.lblUsedTemplate.Text = "Code Templates";
            // 
            // btnScriptSavePath
            // 
            this.btnScriptSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScriptSavePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScriptSavePath.Location = new System.Drawing.Point(738, 201);
            this.btnScriptSavePath.Name = "btnScriptSavePath";
            this.btnScriptSavePath.Size = new System.Drawing.Size(20, 20);
            this.btnScriptSavePath.TabIndex = 2;
            this.btnScriptSavePath.Text = "...";
            this.btnScriptSavePath.UseVisualStyleBackColor = true;
            this.btnScriptSavePath.Click += new System.EventHandler(this.btnScriptSavePath_Click);
            // 
            // btnSourceCodeRoot
            // 
            this.btnSourceCodeRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSourceCodeRoot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSourceCodeRoot.Location = new System.Drawing.Point(738, 176);
            this.btnSourceCodeRoot.Name = "btnSourceCodeRoot";
            this.btnSourceCodeRoot.Size = new System.Drawing.Size(20, 20);
            this.btnSourceCodeRoot.TabIndex = 2;
            this.btnSourceCodeRoot.Text = "...";
            this.btnSourceCodeRoot.UseVisualStyleBackColor = true;
            this.btnSourceCodeRoot.Click += new System.EventHandler(this.btnSourceCodeRoot_Click);
            // 
            // btnDesignFileBrowse
            // 
            this.btnDesignFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesignFileBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesignFileBrowse.Location = new System.Drawing.Point(738, 13);
            this.btnDesignFileBrowse.Name = "btnDesignFileBrowse";
            this.btnDesignFileBrowse.Size = new System.Drawing.Size(20, 20);
            this.btnDesignFileBrowse.TabIndex = 2;
            this.btnDesignFileBrowse.Text = "...";
            this.btnDesignFileBrowse.UseVisualStyleBackColor = true;
            this.btnDesignFileBrowse.Click += new System.EventHandler(this.btnDesignFileBrowse_Click);
            // 
            // txtScriptSavePath
            // 
            this.txtScriptSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScriptSavePath.Location = new System.Drawing.Point(151, 202);
            this.txtScriptSavePath.Name = "txtScriptSavePath";
            this.txtScriptSavePath.Size = new System.Drawing.Size(586, 19);
            this.txtScriptSavePath.TabIndex = 1;
            this.txtScriptSavePath.TextChanged += new System.EventHandler(this.txtScriptSavePath_TextChanged);
            // 
            // txtSourceCodeRoot
            // 
            this.txtSourceCodeRoot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceCodeRoot.Location = new System.Drawing.Point(151, 177);
            this.txtSourceCodeRoot.Name = "txtSourceCodeRoot";
            this.txtSourceCodeRoot.Size = new System.Drawing.Size(586, 19);
            this.txtSourceCodeRoot.TabIndex = 1;
            this.txtSourceCodeRoot.TextChanged += new System.EventHandler(this.txtSourceCodeRoot_TextChanged);
            // 
            // txtDesignFile
            // 
            this.txtDesignFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesignFile.Location = new System.Drawing.Point(155, 14);
            this.txtDesignFile.Name = "txtDesignFile";
            this.txtDesignFile.Size = new System.Drawing.Size(582, 19);
            this.txtDesignFile.TabIndex = 1;
            this.txtDesignFile.TextChanged += new System.EventHandler(this.txtDesignFile_TextChanged);
            // 
            // lblScriptSavePath
            // 
            this.lblScriptSavePath.AutoSize = true;
            this.lblScriptSavePath.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblScriptSavePath.ForeColor = System.Drawing.Color.Red;
            this.lblScriptSavePath.Location = new System.Drawing.Point(24, 205);
            this.lblScriptSavePath.Name = "lblScriptSavePath";
            this.lblScriptSavePath.Size = new System.Drawing.Size(121, 12);
            this.lblScriptSavePath.TabIndex = 0;
            this.lblScriptSavePath.Text = "Scripts Saved Path";
            // 
            // lblSourceRoot
            // 
            this.lblSourceRoot.AutoSize = true;
            this.lblSourceRoot.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSourceRoot.ForeColor = System.Drawing.Color.Red;
            this.lblSourceRoot.Location = new System.Drawing.Point(31, 180);
            this.lblSourceRoot.Name = "lblSourceRoot";
            this.lblSourceRoot.Size = new System.Drawing.Size(114, 12);
            this.lblSourceRoot.TabIndex = 0;
            this.lblSourceRoot.Text = "Source Code Root";
            // 
            // lblDesignFile
            // 
            this.lblDesignFile.AutoSize = true;
            this.lblDesignFile.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDesignFile.ForeColor = System.Drawing.Color.Red;
            this.lblDesignFile.Location = new System.Drawing.Point(15, 17);
            this.lblDesignFile.Name = "lblDesignFile";
            this.lblDesignFile.Size = new System.Drawing.Size(130, 12);
            this.lblDesignFile.TabIndex = 0;
            this.lblDesignFile.Text = "Design File Location";
            // 
            // tabTemplate
            // 
            this.tabTemplate.Controls.Add(this.tabcTemplates);
            this.tabTemplate.Location = new System.Drawing.Point(4, 22);
            this.tabTemplate.Name = "tabTemplate";
            this.tabTemplate.Padding = new System.Windows.Forms.Padding(3);
            this.tabTemplate.Size = new System.Drawing.Size(776, 535);
            this.tabTemplate.TabIndex = 1;
            this.tabTemplate.Text = "Code Templates";
            this.tabTemplate.UseVisualStyleBackColor = true;
            // 
            // tabcTemplates
            // 
            this.tabcTemplates.Controls.Add(this.tabEntities);
            this.tabcTemplates.Controls.Add(this.tabEntityExtends);
            this.tabcTemplates.Controls.Add(this.tabMappers);
            this.tabcTemplates.Controls.Add(this.tabMapperExtend);
            this.tabcTemplates.Controls.Add(this.tabCreateTableScripts);
            this.tabcTemplates.Controls.Add(this.tabInsertDataScripts);
            this.tabcTemplates.Controls.Add(this.tabMultiLangEntity);
            this.tabcTemplates.Controls.Add(this.tabMultiLangSqlProvider);
            this.tabcTemplates.Controls.Add(this.tabMultiLangMapper);
            this.tabcTemplates.Controls.Add(this.tabMultiLangMapperExtend);
            this.tabcTemplates.Controls.Add(this.tabMultiLangCreateTable);
            this.tabcTemplates.Controls.Add(this.tabMultiLangInsertData);
            this.tabcTemplates.Controls.Add(this.tabVO);
            this.tabcTemplates.Controls.Add(this.tabAggVO);
            this.tabcTemplates.Controls.Add(this.tabRest);
            this.tabcTemplates.Controls.Add(this.tabService);
            this.tabcTemplates.Controls.Add(this.tabServiceImpl);
            this.tabcTemplates.Controls.Add(this.tabAggVORequest);
            this.tabcTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabcTemplates.Location = new System.Drawing.Point(3, 3);
            this.tabcTemplates.Name = "tabcTemplates";
            this.tabcTemplates.SelectedIndex = 0;
            this.tabcTemplates.Size = new System.Drawing.Size(770, 529);
            this.tabcTemplates.TabIndex = 0;
            // 
            // tabEntities
            // 
            this.tabEntities.Controls.Add(this.rtbEntityTpl);
            this.tabEntities.Controls.Add(this.btnEntityTpl);
            this.tabEntities.Controls.Add(this.txtEntityTpl);
            this.tabEntities.Controls.Add(this.lblEntityTpl);
            this.tabEntities.Location = new System.Drawing.Point(4, 22);
            this.tabEntities.Name = "tabEntities";
            this.tabEntities.Padding = new System.Windows.Forms.Padding(3);
            this.tabEntities.Size = new System.Drawing.Size(762, 503);
            this.tabEntities.TabIndex = 0;
            this.tabEntities.Text = "Entities";
            this.tabEntities.UseVisualStyleBackColor = true;
            // 
            // rtbEntityTpl
            // 
            this.rtbEntityTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbEntityTpl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbEntityTpl.Location = new System.Drawing.Point(0, 32);
            this.rtbEntityTpl.Name = "rtbEntityTpl";
            this.rtbEntityTpl.ReadOnly = true;
            this.rtbEntityTpl.Size = new System.Drawing.Size(762, 471);
            this.rtbEntityTpl.TabIndex = 4;
            this.rtbEntityTpl.Text = "";
            // 
            // btnEntityTpl
            // 
            this.btnEntityTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEntityTpl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntityTpl.Location = new System.Drawing.Point(732, 3);
            this.btnEntityTpl.Name = "btnEntityTpl";
            this.btnEntityTpl.Size = new System.Drawing.Size(20, 20);
            this.btnEntityTpl.TabIndex = 3;
            this.btnEntityTpl.Text = "...";
            this.btnEntityTpl.UseVisualStyleBackColor = true;
            this.btnEntityTpl.Click += new System.EventHandler(this.btnEntityTpl_Click);
            // 
            // txtEntityTpl
            // 
            this.txtEntityTpl.Location = new System.Drawing.Point(102, 4);
            this.txtEntityTpl.Name = "txtEntityTpl";
            this.txtEntityTpl.Size = new System.Drawing.Size(629, 19);
            this.txtEntityTpl.TabIndex = 1;
            this.txtEntityTpl.TextChanged += new System.EventHandler(this.txtEntityTpl_TextChanged);
            // 
            // lblEntityTpl
            // 
            this.lblEntityTpl.AutoSize = true;
            this.lblEntityTpl.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEntityTpl.Location = new System.Drawing.Point(8, 7);
            this.lblEntityTpl.Name = "lblEntityTpl";
            this.lblEntityTpl.Size = new System.Drawing.Size(88, 12);
            this.lblEntityTpl.TabIndex = 0;
            this.lblEntityTpl.Text = "Entity.tpl File";
            // 
            // tabEntityExtends
            // 
            this.tabEntityExtends.Controls.Add(this.rtbSqlProviderTpl);
            this.tabEntityExtends.Controls.Add(this.btnSqlProviderTpl);
            this.tabEntityExtends.Controls.Add(this.txtSqlProviderTpl);
            this.tabEntityExtends.Controls.Add(this.lblSqlProviderTpl);
            this.tabEntityExtends.Location = new System.Drawing.Point(4, 22);
            this.tabEntityExtends.Name = "tabEntityExtends";
            this.tabEntityExtends.Padding = new System.Windows.Forms.Padding(3);
            this.tabEntityExtends.Size = new System.Drawing.Size(762, 503);
            this.tabEntityExtends.TabIndex = 1;
            this.tabEntityExtends.Text = "SqlProviders";
            this.tabEntityExtends.UseVisualStyleBackColor = true;
            // 
            // rtbSqlProviderTpl
            // 
            this.rtbSqlProviderTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbSqlProviderTpl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSqlProviderTpl.Location = new System.Drawing.Point(0, 29);
            this.rtbSqlProviderTpl.Name = "rtbSqlProviderTpl";
            this.rtbSqlProviderTpl.ReadOnly = true;
            this.rtbSqlProviderTpl.Size = new System.Drawing.Size(762, 474);
            this.rtbSqlProviderTpl.TabIndex = 8;
            this.rtbSqlProviderTpl.Text = "";
            // 
            // btnSqlProviderTpl
            // 
            this.btnSqlProviderTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSqlProviderTpl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSqlProviderTpl.Location = new System.Drawing.Point(732, 3);
            this.btnSqlProviderTpl.Name = "btnSqlProviderTpl";
            this.btnSqlProviderTpl.Size = new System.Drawing.Size(20, 20);
            this.btnSqlProviderTpl.TabIndex = 7;
            this.btnSqlProviderTpl.Text = "...";
            this.btnSqlProviderTpl.UseVisualStyleBackColor = true;
            this.btnSqlProviderTpl.Click += new System.EventHandler(this.btnEntityExtendTpl_Click);
            // 
            // txtSqlProviderTpl
            // 
            this.txtSqlProviderTpl.Location = new System.Drawing.Point(135, 4);
            this.txtSqlProviderTpl.Name = "txtSqlProviderTpl";
            this.txtSqlProviderTpl.Size = new System.Drawing.Size(596, 19);
            this.txtSqlProviderTpl.TabIndex = 6;
            this.txtSqlProviderTpl.TextChanged += new System.EventHandler(this.txtSqlProviderTpl_TextChanged);
            // 
            // lblSqlProviderTpl
            // 
            this.lblSqlProviderTpl.AutoSize = true;
            this.lblSqlProviderTpl.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSqlProviderTpl.Location = new System.Drawing.Point(8, 7);
            this.lblSqlProviderTpl.Name = "lblSqlProviderTpl";
            this.lblSqlProviderTpl.Size = new System.Drawing.Size(121, 12);
            this.lblSqlProviderTpl.TabIndex = 5;
            this.lblSqlProviderTpl.Text = "SqlProvider.tpl File";
            // 
            // tabMappers
            // 
            this.tabMappers.Controls.Add(this.rtbMapperTpl);
            this.tabMappers.Controls.Add(this.btnMapperTpl);
            this.tabMappers.Controls.Add(this.txtMapperTpl);
            this.tabMappers.Controls.Add(this.lblMapperTpl);
            this.tabMappers.Location = new System.Drawing.Point(4, 22);
            this.tabMappers.Name = "tabMappers";
            this.tabMappers.Padding = new System.Windows.Forms.Padding(3);
            this.tabMappers.Size = new System.Drawing.Size(762, 503);
            this.tabMappers.TabIndex = 2;
            this.tabMappers.Text = "Mappers";
            this.tabMappers.UseVisualStyleBackColor = true;
            // 
            // rtbMapperTpl
            // 
            this.rtbMapperTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMapperTpl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMapperTpl.Location = new System.Drawing.Point(1, 29);
            this.rtbMapperTpl.Name = "rtbMapperTpl";
            this.rtbMapperTpl.ReadOnly = true;
            this.rtbMapperTpl.Size = new System.Drawing.Size(761, 471);
            this.rtbMapperTpl.TabIndex = 8;
            this.rtbMapperTpl.Text = "";
            // 
            // btnMapperTpl
            // 
            this.btnMapperTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapperTpl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMapperTpl.Location = new System.Drawing.Point(732, 3);
            this.btnMapperTpl.Name = "btnMapperTpl";
            this.btnMapperTpl.Size = new System.Drawing.Size(20, 20);
            this.btnMapperTpl.TabIndex = 7;
            this.btnMapperTpl.Text = "...";
            this.btnMapperTpl.UseVisualStyleBackColor = true;
            this.btnMapperTpl.Click += new System.EventHandler(this.btnMapperTpl_Click);
            // 
            // txtMapperTpl
            // 
            this.txtMapperTpl.Location = new System.Drawing.Point(109, 4);
            this.txtMapperTpl.Name = "txtMapperTpl";
            this.txtMapperTpl.Size = new System.Drawing.Size(622, 19);
            this.txtMapperTpl.TabIndex = 6;
            this.txtMapperTpl.TextChanged += new System.EventHandler(this.txtMapperTpl_TextChanged);
            // 
            // lblMapperTpl
            // 
            this.lblMapperTpl.AutoSize = true;
            this.lblMapperTpl.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMapperTpl.Location = new System.Drawing.Point(8, 7);
            this.lblMapperTpl.Name = "lblMapperTpl";
            this.lblMapperTpl.Size = new System.Drawing.Size(95, 12);
            this.lblMapperTpl.TabIndex = 5;
            this.lblMapperTpl.Text = "Mapper.tpl File";
            // 
            // tabMapperExtend
            // 
            this.tabMapperExtend.Controls.Add(this.rtbMapperExtendTpl);
            this.tabMapperExtend.Controls.Add(this.btnMapperExtendTpl);
            this.tabMapperExtend.Controls.Add(this.txtMapperExtendTpl);
            this.tabMapperExtend.Controls.Add(this.lblMapperExtendTpl);
            this.tabMapperExtend.Location = new System.Drawing.Point(4, 22);
            this.tabMapperExtend.Name = "tabMapperExtend";
            this.tabMapperExtend.Padding = new System.Windows.Forms.Padding(3);
            this.tabMapperExtend.Size = new System.Drawing.Size(762, 503);
            this.tabMapperExtend.TabIndex = 6;
            this.tabMapperExtend.Text = "MapperExtend";
            this.tabMapperExtend.UseVisualStyleBackColor = true;
            // 
            // rtbMapperExtendTpl
            // 
            this.rtbMapperExtendTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMapperExtendTpl.BackColor = System.Drawing.SystemColors.Control;
            this.rtbMapperExtendTpl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMapperExtendTpl.Location = new System.Drawing.Point(0, 30);
            this.rtbMapperExtendTpl.Name = "rtbMapperExtendTpl";
            this.rtbMapperExtendTpl.ReadOnly = true;
            this.rtbMapperExtendTpl.Size = new System.Drawing.Size(762, 471);
            this.rtbMapperExtendTpl.TabIndex = 8;
            this.rtbMapperExtendTpl.Text = "";
            // 
            // btnMapperExtendTpl
            // 
            this.btnMapperExtendTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapperExtendTpl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMapperExtendTpl.Location = new System.Drawing.Point(732, 3);
            this.btnMapperExtendTpl.Name = "btnMapperExtendTpl";
            this.btnMapperExtendTpl.Size = new System.Drawing.Size(20, 20);
            this.btnMapperExtendTpl.TabIndex = 7;
            this.btnMapperExtendTpl.Text = "...";
            this.btnMapperExtendTpl.UseVisualStyleBackColor = true;
            this.btnMapperExtendTpl.Click += new System.EventHandler(this.btnMapperExtendTpl_Click);
            // 
            // txtMapperExtendTpl
            // 
            this.txtMapperExtendTpl.Location = new System.Drawing.Point(150, 4);
            this.txtMapperExtendTpl.Name = "txtMapperExtendTpl";
            this.txtMapperExtendTpl.Size = new System.Drawing.Size(581, 19);
            this.txtMapperExtendTpl.TabIndex = 6;
            this.txtMapperExtendTpl.TextChanged += new System.EventHandler(this.txtMapperExtendTpl_TextChanged);
            // 
            // lblMapperExtendTpl
            // 
            this.lblMapperExtendTpl.AutoSize = true;
            this.lblMapperExtendTpl.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMapperExtendTpl.Location = new System.Drawing.Point(8, 7);
            this.lblMapperExtendTpl.Name = "lblMapperExtendTpl";
            this.lblMapperExtendTpl.Size = new System.Drawing.Size(136, 12);
            this.lblMapperExtendTpl.TabIndex = 5;
            this.lblMapperExtendTpl.Text = "MapperExtend.tpl File";
            // 
            // tabCreateTableScripts
            // 
            this.tabCreateTableScripts.Controls.Add(this.rtbCreateTableTpl);
            this.tabCreateTableScripts.Controls.Add(this.btnCreateTableTpl);
            this.tabCreateTableScripts.Controls.Add(this.txtCreateTableTpl);
            this.tabCreateTableScripts.Controls.Add(this.lblCreateTableTpl);
            this.tabCreateTableScripts.Location = new System.Drawing.Point(4, 22);
            this.tabCreateTableScripts.Name = "tabCreateTableScripts";
            this.tabCreateTableScripts.Padding = new System.Windows.Forms.Padding(3);
            this.tabCreateTableScripts.Size = new System.Drawing.Size(762, 503);
            this.tabCreateTableScripts.TabIndex = 4;
            this.tabCreateTableScripts.Text = "Create Table Script";
            this.tabCreateTableScripts.UseVisualStyleBackColor = true;
            // 
            // rtbCreateTableTpl
            // 
            this.rtbCreateTableTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbCreateTableTpl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbCreateTableTpl.Location = new System.Drawing.Point(1, 29);
            this.rtbCreateTableTpl.Name = "rtbCreateTableTpl";
            this.rtbCreateTableTpl.ReadOnly = true;
            this.rtbCreateTableTpl.Size = new System.Drawing.Size(761, 471);
            this.rtbCreateTableTpl.TabIndex = 8;
            this.rtbCreateTableTpl.Text = "";
            // 
            // btnCreateTableTpl
            // 
            this.btnCreateTableTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateTableTpl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTableTpl.Location = new System.Drawing.Point(732, 3);
            this.btnCreateTableTpl.Name = "btnCreateTableTpl";
            this.btnCreateTableTpl.Size = new System.Drawing.Size(20, 20);
            this.btnCreateTableTpl.TabIndex = 7;
            this.btnCreateTableTpl.Text = "...";
            this.btnCreateTableTpl.UseVisualStyleBackColor = true;
            this.btnCreateTableTpl.Click += new System.EventHandler(this.btnCreateTableTpl_Click);
            // 
            // txtCreateTableTpl
            // 
            this.txtCreateTableTpl.Location = new System.Drawing.Point(139, 4);
            this.txtCreateTableTpl.Name = "txtCreateTableTpl";
            this.txtCreateTableTpl.Size = new System.Drawing.Size(592, 19);
            this.txtCreateTableTpl.TabIndex = 6;
            this.txtCreateTableTpl.TextChanged += new System.EventHandler(this.txtCreateTableTpl_TextChanged);
            // 
            // lblCreateTableTpl
            // 
            this.lblCreateTableTpl.AutoSize = true;
            this.lblCreateTableTpl.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCreateTableTpl.Location = new System.Drawing.Point(8, 7);
            this.lblCreateTableTpl.Name = "lblCreateTableTpl";
            this.lblCreateTableTpl.Size = new System.Drawing.Size(125, 12);
            this.lblCreateTableTpl.TabIndex = 5;
            this.lblCreateTableTpl.Text = "CreateTable.tpl File";
            // 
            // tabInsertDataScripts
            // 
            this.tabInsertDataScripts.Controls.Add(this.rtbInsertDataTpl);
            this.tabInsertDataScripts.Controls.Add(this.btnInsertDataTpl);
            this.tabInsertDataScripts.Controls.Add(this.txtInsertDataTpl);
            this.tabInsertDataScripts.Controls.Add(this.lblInsertDataTpl);
            this.tabInsertDataScripts.Location = new System.Drawing.Point(4, 22);
            this.tabInsertDataScripts.Name = "tabInsertDataScripts";
            this.tabInsertDataScripts.Padding = new System.Windows.Forms.Padding(3);
            this.tabInsertDataScripts.Size = new System.Drawing.Size(762, 503);
            this.tabInsertDataScripts.TabIndex = 5;
            this.tabInsertDataScripts.Text = "Insert Data Scripts";
            this.tabInsertDataScripts.UseVisualStyleBackColor = true;
            // 
            // rtbInsertDataTpl
            // 
            this.rtbInsertDataTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbInsertDataTpl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbInsertDataTpl.Location = new System.Drawing.Point(1, 29);
            this.rtbInsertDataTpl.Name = "rtbInsertDataTpl";
            this.rtbInsertDataTpl.ReadOnly = true;
            this.rtbInsertDataTpl.Size = new System.Drawing.Size(761, 471);
            this.rtbInsertDataTpl.TabIndex = 8;
            this.rtbInsertDataTpl.Text = "";
            // 
            // btnInsertDataTpl
            // 
            this.btnInsertDataTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsertDataTpl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertDataTpl.Location = new System.Drawing.Point(732, 3);
            this.btnInsertDataTpl.Name = "btnInsertDataTpl";
            this.btnInsertDataTpl.Size = new System.Drawing.Size(20, 20);
            this.btnInsertDataTpl.TabIndex = 7;
            this.btnInsertDataTpl.Text = "...";
            this.btnInsertDataTpl.UseVisualStyleBackColor = true;
            this.btnInsertDataTpl.Click += new System.EventHandler(this.btnInsertDataTpl_Click);
            // 
            // txtInsertDataTpl
            // 
            this.txtInsertDataTpl.Location = new System.Drawing.Point(129, 4);
            this.txtInsertDataTpl.Name = "txtInsertDataTpl";
            this.txtInsertDataTpl.Size = new System.Drawing.Size(602, 19);
            this.txtInsertDataTpl.TabIndex = 6;
            this.txtInsertDataTpl.TextChanged += new System.EventHandler(this.txtInsertDataTpl_TextChanged);
            // 
            // lblInsertDataTpl
            // 
            this.lblInsertDataTpl.AutoSize = true;
            this.lblInsertDataTpl.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblInsertDataTpl.Location = new System.Drawing.Point(8, 7);
            this.lblInsertDataTpl.Name = "lblInsertDataTpl";
            this.lblInsertDataTpl.Size = new System.Drawing.Size(115, 12);
            this.lblInsertDataTpl.TabIndex = 5;
            this.lblInsertDataTpl.Text = "InsertData.tpl File";
            // 
            // tabMultiLangEntity
            // 
            this.tabMultiLangEntity.Controls.Add(this.rtbMultiLangEntity);
            this.tabMultiLangEntity.Controls.Add(this.btnMultiLangEntity);
            this.tabMultiLangEntity.Controls.Add(this.txtMultiLangEntity);
            this.tabMultiLangEntity.Controls.Add(this.lblMultiLangEntity);
            this.tabMultiLangEntity.Location = new System.Drawing.Point(4, 22);
            this.tabMultiLangEntity.Name = "tabMultiLangEntity";
            this.tabMultiLangEntity.Padding = new System.Windows.Forms.Padding(3);
            this.tabMultiLangEntity.Size = new System.Drawing.Size(762, 503);
            this.tabMultiLangEntity.TabIndex = 7;
            this.tabMultiLangEntity.Text = "MultiLangEntity";
            this.tabMultiLangEntity.UseVisualStyleBackColor = true;
            // 
            // rtbMultiLangEntity
            // 
            this.rtbMultiLangEntity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMultiLangEntity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMultiLangEntity.Location = new System.Drawing.Point(1, 29);
            this.rtbMultiLangEntity.Name = "rtbMultiLangEntity";
            this.rtbMultiLangEntity.ReadOnly = true;
            this.rtbMultiLangEntity.Size = new System.Drawing.Size(762, 471);
            this.rtbMultiLangEntity.TabIndex = 8;
            this.rtbMultiLangEntity.Text = "";
            // 
            // btnMultiLangEntity
            // 
            this.btnMultiLangEntity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMultiLangEntity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiLangEntity.Location = new System.Drawing.Point(732, 3);
            this.btnMultiLangEntity.Name = "btnMultiLangEntity";
            this.btnMultiLangEntity.Size = new System.Drawing.Size(20, 20);
            this.btnMultiLangEntity.TabIndex = 7;
            this.btnMultiLangEntity.Text = "...";
            this.btnMultiLangEntity.UseVisualStyleBackColor = true;
            this.btnMultiLangEntity.Click += new System.EventHandler(this.btnMultiLang_Click);
            // 
            // txtMultiLangEntity
            // 
            this.txtMultiLangEntity.Location = new System.Drawing.Point(160, 4);
            this.txtMultiLangEntity.Name = "txtMultiLangEntity";
            this.txtMultiLangEntity.Size = new System.Drawing.Size(571, 19);
            this.txtMultiLangEntity.TabIndex = 6;
            this.txtMultiLangEntity.TextChanged += new System.EventHandler(this.txtMultiLang_TextChanged);
            // 
            // lblMultiLangEntity
            // 
            this.lblMultiLangEntity.AutoSize = true;
            this.lblMultiLangEntity.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMultiLangEntity.Location = new System.Drawing.Point(8, 7);
            this.lblMultiLangEntity.Name = "lblMultiLangEntity";
            this.lblMultiLangEntity.Size = new System.Drawing.Size(146, 12);
            this.lblMultiLangEntity.TabIndex = 5;
            this.lblMultiLangEntity.Text = "MultiLangEntity.tpl File";
            // 
            // tabMultiLangSqlProvider
            // 
            this.tabMultiLangSqlProvider.Controls.Add(this.rtbMultiLangSqlProvider);
            this.tabMultiLangSqlProvider.Controls.Add(this.btnMultiLangSqlProvider);
            this.tabMultiLangSqlProvider.Controls.Add(this.txtMultiLangSqlProvider);
            this.tabMultiLangSqlProvider.Controls.Add(this.lblMultiLangSqlProvider);
            this.tabMultiLangSqlProvider.Location = new System.Drawing.Point(4, 22);
            this.tabMultiLangSqlProvider.Name = "tabMultiLangSqlProvider";
            this.tabMultiLangSqlProvider.Padding = new System.Windows.Forms.Padding(3);
            this.tabMultiLangSqlProvider.Size = new System.Drawing.Size(762, 503);
            this.tabMultiLangSqlProvider.TabIndex = 8;
            this.tabMultiLangSqlProvider.Text = "MultiLangSqlProvider";
            this.tabMultiLangSqlProvider.UseVisualStyleBackColor = true;
            // 
            // rtbMultiLangSqlProvider
            // 
            this.rtbMultiLangSqlProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMultiLangSqlProvider.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMultiLangSqlProvider.Location = new System.Drawing.Point(1, 29);
            this.rtbMultiLangSqlProvider.Name = "rtbMultiLangSqlProvider";
            this.rtbMultiLangSqlProvider.ReadOnly = true;
            this.rtbMultiLangSqlProvider.Size = new System.Drawing.Size(762, 471);
            this.rtbMultiLangSqlProvider.TabIndex = 12;
            this.rtbMultiLangSqlProvider.Text = "";
            // 
            // btnMultiLangSqlProvider
            // 
            this.btnMultiLangSqlProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMultiLangSqlProvider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiLangSqlProvider.Location = new System.Drawing.Point(732, 3);
            this.btnMultiLangSqlProvider.Name = "btnMultiLangSqlProvider";
            this.btnMultiLangSqlProvider.Size = new System.Drawing.Size(20, 20);
            this.btnMultiLangSqlProvider.TabIndex = 11;
            this.btnMultiLangSqlProvider.Text = "...";
            this.btnMultiLangSqlProvider.UseVisualStyleBackColor = true;
            this.btnMultiLangSqlProvider.Click += new System.EventHandler(this.btnMultiLangSqlProvider_Click);
            // 
            // txtMultiLangSqlProvider
            // 
            this.txtMultiLangSqlProvider.Location = new System.Drawing.Point(193, 4);
            this.txtMultiLangSqlProvider.Name = "txtMultiLangSqlProvider";
            this.txtMultiLangSqlProvider.Size = new System.Drawing.Size(538, 19);
            this.txtMultiLangSqlProvider.TabIndex = 10;
            this.txtMultiLangSqlProvider.TextChanged += new System.EventHandler(this.txtMultiLangSqlProvider_TextChanged);
            // 
            // lblMultiLangSqlProvider
            // 
            this.lblMultiLangSqlProvider.AutoSize = true;
            this.lblMultiLangSqlProvider.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMultiLangSqlProvider.Location = new System.Drawing.Point(8, 7);
            this.lblMultiLangSqlProvider.Name = "lblMultiLangSqlProvider";
            this.lblMultiLangSqlProvider.Size = new System.Drawing.Size(179, 12);
            this.lblMultiLangSqlProvider.TabIndex = 9;
            this.lblMultiLangSqlProvider.Text = "MultiLangSqlProvider.tpl File";
            // 
            // tabMultiLangMapper
            // 
            this.tabMultiLangMapper.Controls.Add(this.rtbMultiLangMapper);
            this.tabMultiLangMapper.Controls.Add(this.btnMultiLangMapper);
            this.tabMultiLangMapper.Controls.Add(this.txtMultiLangMapper);
            this.tabMultiLangMapper.Controls.Add(this.lblMultiLangMapper);
            this.tabMultiLangMapper.Location = new System.Drawing.Point(4, 22);
            this.tabMultiLangMapper.Name = "tabMultiLangMapper";
            this.tabMultiLangMapper.Padding = new System.Windows.Forms.Padding(3);
            this.tabMultiLangMapper.Size = new System.Drawing.Size(762, 503);
            this.tabMultiLangMapper.TabIndex = 9;
            this.tabMultiLangMapper.Text = "MultiLangMapper";
            this.tabMultiLangMapper.UseVisualStyleBackColor = true;
            // 
            // rtbMultiLangMapper
            // 
            this.rtbMultiLangMapper.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMultiLangMapper.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMultiLangMapper.Location = new System.Drawing.Point(1, 29);
            this.rtbMultiLangMapper.Name = "rtbMultiLangMapper";
            this.rtbMultiLangMapper.ReadOnly = true;
            this.rtbMultiLangMapper.Size = new System.Drawing.Size(762, 471);
            this.rtbMultiLangMapper.TabIndex = 16;
            this.rtbMultiLangMapper.Text = "";
            // 
            // btnMultiLangMapper
            // 
            this.btnMultiLangMapper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMultiLangMapper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiLangMapper.Location = new System.Drawing.Point(732, 3);
            this.btnMultiLangMapper.Name = "btnMultiLangMapper";
            this.btnMultiLangMapper.Size = new System.Drawing.Size(20, 20);
            this.btnMultiLangMapper.TabIndex = 15;
            this.btnMultiLangMapper.Text = "...";
            this.btnMultiLangMapper.UseVisualStyleBackColor = true;
            this.btnMultiLangMapper.Click += new System.EventHandler(this.btnMultiLangMapper_Click);
            // 
            // txtMultiLangMapper
            // 
            this.txtMultiLangMapper.Location = new System.Drawing.Point(167, 4);
            this.txtMultiLangMapper.Name = "txtMultiLangMapper";
            this.txtMultiLangMapper.Size = new System.Drawing.Size(564, 19);
            this.txtMultiLangMapper.TabIndex = 14;
            this.txtMultiLangMapper.TextChanged += new System.EventHandler(this.txtMultiLangMapper_TextChanged);
            // 
            // lblMultiLangMapper
            // 
            this.lblMultiLangMapper.AutoSize = true;
            this.lblMultiLangMapper.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMultiLangMapper.Location = new System.Drawing.Point(8, 7);
            this.lblMultiLangMapper.Name = "lblMultiLangMapper";
            this.lblMultiLangMapper.Size = new System.Drawing.Size(153, 12);
            this.lblMultiLangMapper.TabIndex = 13;
            this.lblMultiLangMapper.Text = "MultiLangMapper.tpl File";
            // 
            // tabMultiLangMapperExtend
            // 
            this.tabMultiLangMapperExtend.Controls.Add(this.rtbMultiLangMapperExtend);
            this.tabMultiLangMapperExtend.Controls.Add(this.btnMultiLangMapperExtend);
            this.tabMultiLangMapperExtend.Controls.Add(this.txtMultiLangMapperExtend);
            this.tabMultiLangMapperExtend.Controls.Add(this.lblMultiLangMapperExtend);
            this.tabMultiLangMapperExtend.Location = new System.Drawing.Point(4, 22);
            this.tabMultiLangMapperExtend.Name = "tabMultiLangMapperExtend";
            this.tabMultiLangMapperExtend.Padding = new System.Windows.Forms.Padding(3);
            this.tabMultiLangMapperExtend.Size = new System.Drawing.Size(762, 503);
            this.tabMultiLangMapperExtend.TabIndex = 10;
            this.tabMultiLangMapperExtend.Text = "MultiLangMapperExtend";
            this.tabMultiLangMapperExtend.UseVisualStyleBackColor = true;
            // 
            // rtbMultiLangMapperExtend
            // 
            this.rtbMultiLangMapperExtend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMultiLangMapperExtend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMultiLangMapperExtend.Location = new System.Drawing.Point(1, 29);
            this.rtbMultiLangMapperExtend.Name = "rtbMultiLangMapperExtend";
            this.rtbMultiLangMapperExtend.ReadOnly = true;
            this.rtbMultiLangMapperExtend.Size = new System.Drawing.Size(762, 471);
            this.rtbMultiLangMapperExtend.TabIndex = 20;
            this.rtbMultiLangMapperExtend.Text = "";
            // 
            // btnMultiLangMapperExtend
            // 
            this.btnMultiLangMapperExtend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMultiLangMapperExtend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiLangMapperExtend.Location = new System.Drawing.Point(732, 3);
            this.btnMultiLangMapperExtend.Name = "btnMultiLangMapperExtend";
            this.btnMultiLangMapperExtend.Size = new System.Drawing.Size(20, 20);
            this.btnMultiLangMapperExtend.TabIndex = 19;
            this.btnMultiLangMapperExtend.Text = "...";
            this.btnMultiLangMapperExtend.UseVisualStyleBackColor = true;
            this.btnMultiLangMapperExtend.Click += new System.EventHandler(this.btnMultiLangMapperExtend_Click);
            // 
            // txtMultiLangMapperExtend
            // 
            this.txtMultiLangMapperExtend.Location = new System.Drawing.Point(208, 4);
            this.txtMultiLangMapperExtend.Name = "txtMultiLangMapperExtend";
            this.txtMultiLangMapperExtend.Size = new System.Drawing.Size(523, 19);
            this.txtMultiLangMapperExtend.TabIndex = 18;
            this.txtMultiLangMapperExtend.TextChanged += new System.EventHandler(this.txtMultiLangMapperExtend_TextChanged);
            // 
            // lblMultiLangMapperExtend
            // 
            this.lblMultiLangMapperExtend.AutoSize = true;
            this.lblMultiLangMapperExtend.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMultiLangMapperExtend.Location = new System.Drawing.Point(8, 7);
            this.lblMultiLangMapperExtend.Name = "lblMultiLangMapperExtend";
            this.lblMultiLangMapperExtend.Size = new System.Drawing.Size(194, 12);
            this.lblMultiLangMapperExtend.TabIndex = 17;
            this.lblMultiLangMapperExtend.Text = "MultiLangMapperExtend.tpl File";
            // 
            // tabMultiLangCreateTable
            // 
            this.tabMultiLangCreateTable.Controls.Add(this.rtbMultiLangCreateTable);
            this.tabMultiLangCreateTable.Controls.Add(this.btnMultiLangCreateTable);
            this.tabMultiLangCreateTable.Controls.Add(this.txtMultiLangCreateTable);
            this.tabMultiLangCreateTable.Controls.Add(this.lblMultLangCreateTable);
            this.tabMultiLangCreateTable.Location = new System.Drawing.Point(4, 22);
            this.tabMultiLangCreateTable.Name = "tabMultiLangCreateTable";
            this.tabMultiLangCreateTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabMultiLangCreateTable.Size = new System.Drawing.Size(762, 503);
            this.tabMultiLangCreateTable.TabIndex = 11;
            this.tabMultiLangCreateTable.Text = "MultiLangCreateTable";
            this.tabMultiLangCreateTable.UseVisualStyleBackColor = true;
            // 
            // rtbMultiLangCreateTable
            // 
            this.rtbMultiLangCreateTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMultiLangCreateTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMultiLangCreateTable.Location = new System.Drawing.Point(1, 29);
            this.rtbMultiLangCreateTable.Name = "rtbMultiLangCreateTable";
            this.rtbMultiLangCreateTable.ReadOnly = true;
            this.rtbMultiLangCreateTable.Size = new System.Drawing.Size(762, 471);
            this.rtbMultiLangCreateTable.TabIndex = 24;
            this.rtbMultiLangCreateTable.Text = "";
            // 
            // btnMultiLangCreateTable
            // 
            this.btnMultiLangCreateTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMultiLangCreateTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiLangCreateTable.Location = new System.Drawing.Point(732, 3);
            this.btnMultiLangCreateTable.Name = "btnMultiLangCreateTable";
            this.btnMultiLangCreateTable.Size = new System.Drawing.Size(20, 20);
            this.btnMultiLangCreateTable.TabIndex = 23;
            this.btnMultiLangCreateTable.Text = "...";
            this.btnMultiLangCreateTable.UseVisualStyleBackColor = true;
            this.btnMultiLangCreateTable.Click += new System.EventHandler(this.btnMultiLangCreateTable_Click);
            // 
            // txtMultiLangCreateTable
            // 
            this.txtMultiLangCreateTable.Location = new System.Drawing.Point(197, 4);
            this.txtMultiLangCreateTable.Name = "txtMultiLangCreateTable";
            this.txtMultiLangCreateTable.Size = new System.Drawing.Size(534, 19);
            this.txtMultiLangCreateTable.TabIndex = 22;
            this.txtMultiLangCreateTable.TextChanged += new System.EventHandler(this.txtMultiLangCreateTable_TextChanged);
            // 
            // lblMultLangCreateTable
            // 
            this.lblMultLangCreateTable.AutoSize = true;
            this.lblMultLangCreateTable.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMultLangCreateTable.Location = new System.Drawing.Point(8, 7);
            this.lblMultLangCreateTable.Name = "lblMultLangCreateTable";
            this.lblMultLangCreateTable.Size = new System.Drawing.Size(183, 12);
            this.lblMultLangCreateTable.TabIndex = 21;
            this.lblMultLangCreateTable.Text = "MultiLangCreateTable.tpl File";
            // 
            // tabMultiLangInsertData
            // 
            this.tabMultiLangInsertData.Controls.Add(this.rtbMultiLangInsertData);
            this.tabMultiLangInsertData.Controls.Add(this.btnMultiLangInsertData);
            this.tabMultiLangInsertData.Controls.Add(this.txtMultiLangInsertData);
            this.tabMultiLangInsertData.Controls.Add(this.lblMultiLangInsertData);
            this.tabMultiLangInsertData.Location = new System.Drawing.Point(4, 22);
            this.tabMultiLangInsertData.Name = "tabMultiLangInsertData";
            this.tabMultiLangInsertData.Padding = new System.Windows.Forms.Padding(3);
            this.tabMultiLangInsertData.Size = new System.Drawing.Size(762, 503);
            this.tabMultiLangInsertData.TabIndex = 12;
            this.tabMultiLangInsertData.Text = "MultiLangInsertData";
            this.tabMultiLangInsertData.UseVisualStyleBackColor = true;
            // 
            // rtbMultiLangInsertData
            // 
            this.rtbMultiLangInsertData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMultiLangInsertData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMultiLangInsertData.Location = new System.Drawing.Point(1, 29);
            this.rtbMultiLangInsertData.Name = "rtbMultiLangInsertData";
            this.rtbMultiLangInsertData.ReadOnly = true;
            this.rtbMultiLangInsertData.Size = new System.Drawing.Size(762, 471);
            this.rtbMultiLangInsertData.TabIndex = 24;
            this.rtbMultiLangInsertData.Text = "";
            // 
            // btnMultiLangInsertData
            // 
            this.btnMultiLangInsertData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMultiLangInsertData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiLangInsertData.Location = new System.Drawing.Point(732, 3);
            this.btnMultiLangInsertData.Name = "btnMultiLangInsertData";
            this.btnMultiLangInsertData.Size = new System.Drawing.Size(20, 20);
            this.btnMultiLangInsertData.TabIndex = 23;
            this.btnMultiLangInsertData.Text = "...";
            this.btnMultiLangInsertData.UseVisualStyleBackColor = true;
            this.btnMultiLangInsertData.Click += new System.EventHandler(this.btnMultiLangInsertData_Click);
            // 
            // txtMultiLangInsertData
            // 
            this.txtMultiLangInsertData.Location = new System.Drawing.Point(187, 4);
            this.txtMultiLangInsertData.Name = "txtMultiLangInsertData";
            this.txtMultiLangInsertData.Size = new System.Drawing.Size(544, 19);
            this.txtMultiLangInsertData.TabIndex = 22;
            this.txtMultiLangInsertData.TextChanged += new System.EventHandler(this.txtMultiLangInsertData_TextChanged);
            // 
            // lblMultiLangInsertData
            // 
            this.lblMultiLangInsertData.AutoSize = true;
            this.lblMultiLangInsertData.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMultiLangInsertData.Location = new System.Drawing.Point(8, 7);
            this.lblMultiLangInsertData.Name = "lblMultiLangInsertData";
            this.lblMultiLangInsertData.Size = new System.Drawing.Size(173, 12);
            this.lblMultiLangInsertData.TabIndex = 21;
            this.lblMultiLangInsertData.Text = "MultiLangInsertData.tpl File";
            // 
            // tabVO
            // 
            this.tabVO.Controls.Add(this.rtbVOTpl);
            this.tabVO.Controls.Add(this.btnVO);
            this.tabVO.Controls.Add(this.txtVO);
            this.tabVO.Controls.Add(this.lblVO);
            this.tabVO.Location = new System.Drawing.Point(4, 22);
            this.tabVO.Name = "tabVO";
            this.tabVO.Padding = new System.Windows.Forms.Padding(3);
            this.tabVO.Size = new System.Drawing.Size(762, 503);
            this.tabVO.TabIndex = 13;
            this.tabVO.Text = "VO";
            this.tabVO.UseVisualStyleBackColor = true;
            // 
            // rtbVOTpl
            // 
            this.rtbVOTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbVOTpl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbVOTpl.Location = new System.Drawing.Point(1, 29);
            this.rtbVOTpl.Name = "rtbVOTpl";
            this.rtbVOTpl.ReadOnly = true;
            this.rtbVOTpl.Size = new System.Drawing.Size(762, 471);
            this.rtbVOTpl.TabIndex = 28;
            this.rtbVOTpl.Text = "";
            // 
            // btnVO
            // 
            this.btnVO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVO.Location = new System.Drawing.Point(732, 3);
            this.btnVO.Name = "btnVO";
            this.btnVO.Size = new System.Drawing.Size(20, 20);
            this.btnVO.TabIndex = 27;
            this.btnVO.Text = "...";
            this.btnVO.UseVisualStyleBackColor = true;
            this.btnVO.Click += new System.EventHandler(this.btnVO_Click);
            // 
            // txtVO
            // 
            this.txtVO.Location = new System.Drawing.Point(84, 4);
            this.txtVO.Name = "txtVO";
            this.txtVO.Size = new System.Drawing.Size(647, 19);
            this.txtVO.TabIndex = 26;
            this.txtVO.TextChanged += new System.EventHandler(this.txtVO_TextChanged);
            // 
            // lblVO
            // 
            this.lblVO.AutoSize = true;
            this.lblVO.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVO.Location = new System.Drawing.Point(8, 7);
            this.lblVO.Name = "lblVO";
            this.lblVO.Size = new System.Drawing.Size(70, 12);
            this.lblVO.TabIndex = 25;
            this.lblVO.Text = "VO.tpl File";
            // 
            // tabAggVO
            // 
            this.tabAggVO.Controls.Add(this.rtbAggVO);
            this.tabAggVO.Controls.Add(this.btnAggVO);
            this.tabAggVO.Controls.Add(this.txtAggVO);
            this.tabAggVO.Controls.Add(this.lblAggVO);
            this.tabAggVO.Location = new System.Drawing.Point(4, 22);
            this.tabAggVO.Name = "tabAggVO";
            this.tabAggVO.Padding = new System.Windows.Forms.Padding(3);
            this.tabAggVO.Size = new System.Drawing.Size(762, 503);
            this.tabAggVO.TabIndex = 14;
            this.tabAggVO.Text = "AggVO";
            this.tabAggVO.UseVisualStyleBackColor = true;
            // 
            // rtbAggVO
            // 
            this.rtbAggVO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbAggVO.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbAggVO.Location = new System.Drawing.Point(1, 29);
            this.rtbAggVO.Name = "rtbAggVO";
            this.rtbAggVO.ReadOnly = true;
            this.rtbAggVO.Size = new System.Drawing.Size(762, 471);
            this.rtbAggVO.TabIndex = 32;
            this.rtbAggVO.Text = "";
            // 
            // btnAggVO
            // 
            this.btnAggVO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAggVO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAggVO.Location = new System.Drawing.Point(732, 3);
            this.btnAggVO.Name = "btnAggVO";
            this.btnAggVO.Size = new System.Drawing.Size(20, 20);
            this.btnAggVO.TabIndex = 31;
            this.btnAggVO.Text = "...";
            this.btnAggVO.UseVisualStyleBackColor = true;
            this.btnAggVO.Click += new System.EventHandler(this.btnAggVO_Click);
            // 
            // txtAggVO
            // 
            this.txtAggVO.Location = new System.Drawing.Point(107, 4);
            this.txtAggVO.Name = "txtAggVO";
            this.txtAggVO.Size = new System.Drawing.Size(624, 19);
            this.txtAggVO.TabIndex = 30;
            this.txtAggVO.TextChanged += new System.EventHandler(this.txtAggVO_TextChanged);
            // 
            // lblAggVO
            // 
            this.lblAggVO.AutoSize = true;
            this.lblAggVO.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAggVO.Location = new System.Drawing.Point(8, 7);
            this.lblAggVO.Name = "lblAggVO";
            this.lblAggVO.Size = new System.Drawing.Size(93, 12);
            this.lblAggVO.TabIndex = 29;
            this.lblAggVO.Text = "AggVO.tpl File";
            // 
            // tabRest
            // 
            this.tabRest.Controls.Add(this.rtbRestTpl);
            this.tabRest.Controls.Add(this.btnRestTpl);
            this.tabRest.Controls.Add(this.txtRestTpl);
            this.tabRest.Controls.Add(this.lblRestTpl);
            this.tabRest.Location = new System.Drawing.Point(4, 22);
            this.tabRest.Name = "tabRest";
            this.tabRest.Padding = new System.Windows.Forms.Padding(3);
            this.tabRest.Size = new System.Drawing.Size(762, 503);
            this.tabRest.TabIndex = 15;
            this.tabRest.Text = "Rest";
            this.tabRest.UseVisualStyleBackColor = true;
            // 
            // rtbRestTpl
            // 
            this.rtbRestTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbRestTpl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbRestTpl.Location = new System.Drawing.Point(1, 29);
            this.rtbRestTpl.Name = "rtbRestTpl";
            this.rtbRestTpl.ReadOnly = true;
            this.rtbRestTpl.Size = new System.Drawing.Size(762, 471);
            this.rtbRestTpl.TabIndex = 36;
            this.rtbRestTpl.Text = "";
            // 
            // btnRestTpl
            // 
            this.btnRestTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestTpl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestTpl.Location = new System.Drawing.Point(732, 3);
            this.btnRestTpl.Name = "btnRestTpl";
            this.btnRestTpl.Size = new System.Drawing.Size(20, 20);
            this.btnRestTpl.TabIndex = 35;
            this.btnRestTpl.Text = "...";
            this.btnRestTpl.UseVisualStyleBackColor = true;
            this.btnRestTpl.Click += new System.EventHandler(this.btnRestTpl_Click);
            // 
            // txtRestTpl
            // 
            this.txtRestTpl.Location = new System.Drawing.Point(94, 4);
            this.txtRestTpl.Name = "txtRestTpl";
            this.txtRestTpl.Size = new System.Drawing.Size(637, 19);
            this.txtRestTpl.TabIndex = 34;
            this.txtRestTpl.TextChanged += new System.EventHandler(this.txtRestTpl_TextChanged);
            // 
            // lblRestTpl
            // 
            this.lblRestTpl.AutoSize = true;
            this.lblRestTpl.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRestTpl.Location = new System.Drawing.Point(8, 7);
            this.lblRestTpl.Name = "lblRestTpl";
            this.lblRestTpl.Size = new System.Drawing.Size(80, 12);
            this.lblRestTpl.TabIndex = 33;
            this.lblRestTpl.Text = "Rest.tpl File";
            // 
            // tabService
            // 
            this.tabService.Controls.Add(this.rtbServiceTpl);
            this.tabService.Controls.Add(this.btnServiceTpl);
            this.tabService.Controls.Add(this.txtServiceTpl);
            this.tabService.Controls.Add(this.lblServiceTpl);
            this.tabService.Location = new System.Drawing.Point(4, 22);
            this.tabService.Name = "tabService";
            this.tabService.Padding = new System.Windows.Forms.Padding(3);
            this.tabService.Size = new System.Drawing.Size(762, 503);
            this.tabService.TabIndex = 16;
            this.tabService.Text = "Service";
            this.tabService.UseVisualStyleBackColor = true;
            // 
            // rtbServiceTpl
            // 
            this.rtbServiceTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbServiceTpl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbServiceTpl.Location = new System.Drawing.Point(1, 29);
            this.rtbServiceTpl.Name = "rtbServiceTpl";
            this.rtbServiceTpl.ReadOnly = true;
            this.rtbServiceTpl.Size = new System.Drawing.Size(762, 471);
            this.rtbServiceTpl.TabIndex = 40;
            this.rtbServiceTpl.Text = "";
            // 
            // btnServiceTpl
            // 
            this.btnServiceTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnServiceTpl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceTpl.Location = new System.Drawing.Point(732, 3);
            this.btnServiceTpl.Name = "btnServiceTpl";
            this.btnServiceTpl.Size = new System.Drawing.Size(20, 20);
            this.btnServiceTpl.TabIndex = 39;
            this.btnServiceTpl.Text = "...";
            this.btnServiceTpl.UseVisualStyleBackColor = true;
            this.btnServiceTpl.Click += new System.EventHandler(this.btnServiceTpl_Click);
            // 
            // txtServiceTpl
            // 
            this.txtServiceTpl.Location = new System.Drawing.Point(111, 4);
            this.txtServiceTpl.Name = "txtServiceTpl";
            this.txtServiceTpl.Size = new System.Drawing.Size(620, 19);
            this.txtServiceTpl.TabIndex = 38;
            this.txtServiceTpl.TextChanged += new System.EventHandler(this.txtServiceTpl_TextChanged);
            // 
            // lblServiceTpl
            // 
            this.lblServiceTpl.AutoSize = true;
            this.lblServiceTpl.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblServiceTpl.Location = new System.Drawing.Point(8, 7);
            this.lblServiceTpl.Name = "lblServiceTpl";
            this.lblServiceTpl.Size = new System.Drawing.Size(97, 12);
            this.lblServiceTpl.TabIndex = 37;
            this.lblServiceTpl.Text = "Service.tpl File";
            // 
            // tabServiceImpl
            // 
            this.tabServiceImpl.Controls.Add(this.rtbServiceImplTpl);
            this.tabServiceImpl.Controls.Add(this.btnServiceImplTpl);
            this.tabServiceImpl.Controls.Add(this.txtServiceImplTpl);
            this.tabServiceImpl.Controls.Add(this.lblServiceImplTpl);
            this.tabServiceImpl.Location = new System.Drawing.Point(4, 22);
            this.tabServiceImpl.Name = "tabServiceImpl";
            this.tabServiceImpl.Padding = new System.Windows.Forms.Padding(3);
            this.tabServiceImpl.Size = new System.Drawing.Size(762, 503);
            this.tabServiceImpl.TabIndex = 17;
            this.tabServiceImpl.Text = "Service Implement";
            this.tabServiceImpl.UseVisualStyleBackColor = true;
            // 
            // rtbServiceImplTpl
            // 
            this.rtbServiceImplTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbServiceImplTpl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbServiceImplTpl.Location = new System.Drawing.Point(1, 29);
            this.rtbServiceImplTpl.Name = "rtbServiceImplTpl";
            this.rtbServiceImplTpl.ReadOnly = true;
            this.rtbServiceImplTpl.Size = new System.Drawing.Size(762, 471);
            this.rtbServiceImplTpl.TabIndex = 44;
            this.rtbServiceImplTpl.Text = "";
            // 
            // btnServiceImplTpl
            // 
            this.btnServiceImplTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnServiceImplTpl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceImplTpl.Location = new System.Drawing.Point(732, 3);
            this.btnServiceImplTpl.Name = "btnServiceImplTpl";
            this.btnServiceImplTpl.Size = new System.Drawing.Size(20, 20);
            this.btnServiceImplTpl.TabIndex = 43;
            this.btnServiceImplTpl.Text = "...";
            this.btnServiceImplTpl.UseVisualStyleBackColor = true;
            this.btnServiceImplTpl.Click += new System.EventHandler(this.btnServiceImplTpl_Click);
            // 
            // txtServiceImplTpl
            // 
            this.txtServiceImplTpl.Location = new System.Drawing.Point(136, 4);
            this.txtServiceImplTpl.Name = "txtServiceImplTpl";
            this.txtServiceImplTpl.Size = new System.Drawing.Size(595, 19);
            this.txtServiceImplTpl.TabIndex = 42;
            this.txtServiceImplTpl.TextChanged += new System.EventHandler(this.txtServiceImplTpl_TextChanged);
            // 
            // lblServiceImplTpl
            // 
            this.lblServiceImplTpl.AutoSize = true;
            this.lblServiceImplTpl.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblServiceImplTpl.Location = new System.Drawing.Point(8, 7);
            this.lblServiceImplTpl.Name = "lblServiceImplTpl";
            this.lblServiceImplTpl.Size = new System.Drawing.Size(122, 12);
            this.lblServiceImplTpl.TabIndex = 41;
            this.lblServiceImplTpl.Text = "ServiceImpl.tpl File";
            // 
            // tabSetting
            // 
            this.tabSetting.Controls.Add(this.grpPublish);
            this.tabSetting.Controls.Add(this.grpGenerate);
            this.tabSetting.Location = new System.Drawing.Point(4, 22);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetting.Size = new System.Drawing.Size(776, 535);
            this.tabSetting.TabIndex = 2;
            this.tabSetting.Text = "Settings";
            this.tabSetting.UseVisualStyleBackColor = true;
            // 
            // grpPublish
            // 
            this.grpPublish.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPublish.Controls.Add(this.lblBaseExecutive);
            this.grpPublish.Controls.Add(this.txtBaseExecutive);
            this.grpPublish.Controls.Add(this.chkExecuteMultiLang);
            this.grpPublish.Controls.Add(this.lblDBConnStr);
            this.grpPublish.Controls.Add(this.txtDBConnStr);
            this.grpPublish.Location = new System.Drawing.Point(8, 222);
            this.grpPublish.Name = "grpPublish";
            this.grpPublish.Size = new System.Drawing.Size(762, 305);
            this.grpPublish.TabIndex = 11;
            this.grpPublish.TabStop = false;
            this.grpPublish.Text = "Publish Options";
            // 
            // lblBaseExecutive
            // 
            this.lblBaseExecutive.AutoSize = true;
            this.lblBaseExecutive.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblBaseExecutive.Location = new System.Drawing.Point(17, 84);
            this.lblBaseExecutive.Name = "lblBaseExecutive";
            this.lblBaseExecutive.Size = new System.Drawing.Size(186, 12);
            this.lblBaseExecutive.TabIndex = 14;
            this.lblBaseExecutive.Text = "First Batch Executing Scripts";
            // 
            // txtBaseExecutive
            // 
            this.txtBaseExecutive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBaseExecutive.Location = new System.Drawing.Point(210, 81);
            this.txtBaseExecutive.Name = "txtBaseExecutive";
            this.txtBaseExecutive.Size = new System.Drawing.Size(534, 19);
            this.txtBaseExecutive.TabIndex = 13;
            // 
            // chkExecuteMultiLang
            // 
            this.chkExecuteMultiLang.AutoSize = true;
            this.chkExecuteMultiLang.Location = new System.Drawing.Point(20, 53);
            this.chkExecuteMultiLang.Name = "chkExecuteMultiLang";
            this.chkExecuteMultiLang.Size = new System.Drawing.Size(148, 16);
            this.chkExecuteMultiLang.TabIndex = 12;
            this.chkExecuteMultiLang.Text = "Publish MultiLang Script";
            this.chkExecuteMultiLang.UseVisualStyleBackColor = true;
            // 
            // lblDBConnStr
            // 
            this.lblDBConnStr.AutoSize = true;
            this.lblDBConnStr.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDBConnStr.Location = new System.Drawing.Point(18, 27);
            this.lblDBConnStr.Name = "lblDBConnStr";
            this.lblDBConnStr.Size = new System.Drawing.Size(176, 12);
            this.lblDBConnStr.TabIndex = 11;
            this.lblDBConnStr.Text = "DataBase Connection String";
            // 
            // txtDBConnStr
            // 
            this.txtDBConnStr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDBConnStr.Location = new System.Drawing.Point(211, 24);
            this.txtDBConnStr.Name = "txtDBConnStr";
            this.txtDBConnStr.Size = new System.Drawing.Size(533, 19);
            this.txtDBConnStr.TabIndex = 10;
            // 
            // grpGenerate
            // 
            this.grpGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGenerate.Controls.Add(this.lblInsertTablePrefix);
            this.grpGenerate.Controls.Add(this.txtInsertDataPrefix);
            this.grpGenerate.Controls.Add(this.lblCreateTablePrefix);
            this.grpGenerate.Controls.Add(this.txtCreateTablePrefix);
            this.grpGenerate.Controls.Add(this.btnChangeColor);
            this.grpGenerate.Controls.Add(this.txtTagColor);
            this.grpGenerate.Controls.Add(this.lblClassRoot);
            this.grpGenerate.Controls.Add(this.lblTagColor);
            this.grpGenerate.Controls.Add(this.chkGenerateAuthor);
            this.grpGenerate.Controls.Add(this.txtClassRoot);
            this.grpGenerate.Controls.Add(this.txtAuthor);
            this.grpGenerate.Controls.Add(this.lblAuthor);
            this.grpGenerate.Location = new System.Drawing.Point(8, 6);
            this.grpGenerate.Name = "grpGenerate";
            this.grpGenerate.Size = new System.Drawing.Size(762, 210);
            this.grpGenerate.TabIndex = 10;
            this.grpGenerate.TabStop = false;
            this.grpGenerate.Text = "Generate Options";
            // 
            // lblInsertTablePrefix
            // 
            this.lblInsertTablePrefix.AutoSize = true;
            this.lblInsertTablePrefix.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblInsertTablePrefix.Location = new System.Drawing.Point(17, 168);
            this.lblInsertTablePrefix.Name = "lblInsertTablePrefix";
            this.lblInsertTablePrefix.Size = new System.Drawing.Size(173, 12);
            this.lblInsertTablePrefix.TabIndex = 27;
            this.lblInsertTablePrefix.Text = "Insert Data Filename Prefix";
            // 
            // txtInsertDataPrefix
            // 
            this.txtInsertDataPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInsertDataPrefix.Location = new System.Drawing.Point(210, 165);
            this.txtInsertDataPrefix.Name = "txtInsertDataPrefix";
            this.txtInsertDataPrefix.Size = new System.Drawing.Size(534, 19);
            this.txtInsertDataPrefix.TabIndex = 26;
            // 
            // lblCreateTablePrefix
            // 
            this.lblCreateTablePrefix.AutoSize = true;
            this.lblCreateTablePrefix.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCreateTablePrefix.Location = new System.Drawing.Point(17, 133);
            this.lblCreateTablePrefix.Name = "lblCreateTablePrefix";
            this.lblCreateTablePrefix.Size = new System.Drawing.Size(183, 12);
            this.lblCreateTablePrefix.TabIndex = 25;
            this.lblCreateTablePrefix.Text = "Create Table Filename Prefix";
            // 
            // txtCreateTablePrefix
            // 
            this.txtCreateTablePrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreateTablePrefix.Location = new System.Drawing.Point(210, 130);
            this.txtCreateTablePrefix.Name = "txtCreateTablePrefix";
            this.txtCreateTablePrefix.Size = new System.Drawing.Size(534, 19);
            this.txtCreateTablePrefix.TabIndex = 24;
            // 
            // btnChangeColor
            // 
            this.btnChangeColor.Location = new System.Drawing.Point(239, 58);
            this.btnChangeColor.Name = "btnChangeColor";
            this.btnChangeColor.Size = new System.Drawing.Size(60, 23);
            this.btnChangeColor.TabIndex = 21;
            this.btnChangeColor.Text = "Change Color";
            this.btnChangeColor.UseVisualStyleBackColor = true;
            // 
            // txtTagColor
            // 
            this.txtTagColor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTagColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTagColor.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTagColor.ForeColor = System.Drawing.Color.Maroon;
            this.txtTagColor.Location = new System.Drawing.Point(87, 60);
            this.txtTagColor.Name = "txtTagColor";
            this.txtTagColor.ReadOnly = true;
            this.txtTagColor.Size = new System.Drawing.Size(109, 19);
            this.txtTagColor.TabIndex = 20;
            this.txtTagColor.Text = "$TEMPLATETAGS$";
            this.txtTagColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblClassRoot
            // 
            this.lblClassRoot.AutoSize = true;
            this.lblClassRoot.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblClassRoot.Location = new System.Drawing.Point(17, 95);
            this.lblClassRoot.Name = "lblClassRoot";
            this.lblClassRoot.Size = new System.Drawing.Size(72, 12);
            this.lblClassRoot.TabIndex = 18;
            this.lblClassRoot.Text = "Class Root";
            // 
            // lblTagColor
            // 
            this.lblTagColor.AutoSize = true;
            this.lblTagColor.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTagColor.Location = new System.Drawing.Point(17, 63);
            this.lblTagColor.Name = "lblTagColor";
            this.lblTagColor.Size = new System.Drawing.Size(64, 12);
            this.lblTagColor.TabIndex = 19;
            this.lblTagColor.Text = "Tag Color";
            // 
            // chkGenerateAuthor
            // 
            this.chkGenerateAuthor.AutoSize = true;
            this.chkGenerateAuthor.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkGenerateAuthor.Location = new System.Drawing.Point(19, 31);
            this.chkGenerateAuthor.Name = "chkGenerateAuthor";
            this.chkGenerateAuthor.Size = new System.Drawing.Size(173, 16);
            this.chkGenerateAuthor.TabIndex = 14;
            this.chkGenerateAuthor.Text = "Generate Author Remark";
            this.chkGenerateAuthor.UseVisualStyleBackColor = true;
            this.chkGenerateAuthor.CheckedChanged += new System.EventHandler(this.chkGenerateAuthor_CheckedChanged);
            // 
            // txtClassRoot
            // 
            this.txtClassRoot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClassRoot.Location = new System.Drawing.Point(95, 92);
            this.txtClassRoot.Name = "txtClassRoot";
            this.txtClassRoot.Size = new System.Drawing.Size(649, 19);
            this.txtClassRoot.TabIndex = 12;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthor.Enabled = false;
            this.txtAuthor.Location = new System.Drawing.Point(255, 29);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(489, 19);
            this.txtAuthor.TabIndex = 13;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Enabled = false;
            this.lblAuthor.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAuthor.Location = new System.Drawing.Point(204, 32);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(45, 12);
            this.lblAuthor.TabIndex = 8;
            this.lblAuthor.Text = "Author";
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.Filter = "Excel | *.xlsx";
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "error.gif");
            this.imgList.Images.SetKeyName(1, "running.gif");
            this.imgList.Images.SetKeyName(2, "stop.gif");
            this.imgList.Images.SetKeyName(3, "success.gif");
            this.imgList.Images.SetKeyName(4, "warning.gif");
            // 
            // tabAggVORequest
            // 
            this.tabAggVORequest.Controls.Add(this.rtbAggVORequestTpl);
            this.tabAggVORequest.Controls.Add(this.btnAggVORequestTpl);
            this.tabAggVORequest.Controls.Add(this.txtAggVORequestTpl);
            this.tabAggVORequest.Controls.Add(this.lblAggVORequestTpl);
            this.tabAggVORequest.Location = new System.Drawing.Point(4, 22);
            this.tabAggVORequest.Name = "tabAggVORequest";
            this.tabAggVORequest.Padding = new System.Windows.Forms.Padding(3);
            this.tabAggVORequest.Size = new System.Drawing.Size(762, 503);
            this.tabAggVORequest.TabIndex = 18;
            this.tabAggVORequest.Text = "AggVORequest";
            this.tabAggVORequest.UseVisualStyleBackColor = true;
            // 
            // rtbAggVORequestTpl
            // 
            this.rtbAggVORequestTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbAggVORequestTpl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbAggVORequestTpl.Location = new System.Drawing.Point(1, 29);
            this.rtbAggVORequestTpl.Name = "rtbAggVORequestTpl";
            this.rtbAggVORequestTpl.ReadOnly = true;
            this.rtbAggVORequestTpl.Size = new System.Drawing.Size(762, 471);
            this.rtbAggVORequestTpl.TabIndex = 48;
            this.rtbAggVORequestTpl.Text = "";
            // 
            // btnAggVORequestTpl
            // 
            this.btnAggVORequestTpl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAggVORequestTpl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAggVORequestTpl.Location = new System.Drawing.Point(732, 3);
            this.btnAggVORequestTpl.Name = "btnAggVORequestTpl";
            this.btnAggVORequestTpl.Size = new System.Drawing.Size(20, 20);
            this.btnAggVORequestTpl.TabIndex = 47;
            this.btnAggVORequestTpl.Text = "...";
            this.btnAggVORequestTpl.UseVisualStyleBackColor = true;
            this.btnAggVORequestTpl.Click += new System.EventHandler(this.btnAggVORequestTpl_Click);
            // 
            // txtAggVORequestTpl
            // 
            this.txtAggVORequestTpl.Location = new System.Drawing.Point(156, 4);
            this.txtAggVORequestTpl.Name = "txtAggVORequestTpl";
            this.txtAggVORequestTpl.Size = new System.Drawing.Size(575, 19);
            this.txtAggVORequestTpl.TabIndex = 46;
            this.txtAggVORequestTpl.TextChanged += new System.EventHandler(this.txtAggVORequestTpl_TextChanged);
            // 
            // lblAggVORequestTpl
            // 
            this.lblAggVORequestTpl.AutoSize = true;
            this.lblAggVORequestTpl.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAggVORequestTpl.Location = new System.Drawing.Point(8, 7);
            this.lblAggVORequestTpl.Name = "lblAggVORequestTpl";
            this.lblAggVORequestTpl.Size = new System.Drawing.Size(142, 12);
            this.lblAggVORequestTpl.TabIndex = 45;
            this.lblAggVORequestTpl.Text = "AggVORequest.tpl File";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mybatis Code Generator";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabcMain.ResumeLayout(false);
            this.tabGenerator.ResumeLayout(false);
            this.tabGenerator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgStepLog)).EndInit();
            this.strpStatus.ResumeLayout(false);
            this.strpStatus.PerformLayout();
            this.tabTemplate.ResumeLayout(false);
            this.tabcTemplates.ResumeLayout(false);
            this.tabEntities.ResumeLayout(false);
            this.tabEntities.PerformLayout();
            this.tabEntityExtends.ResumeLayout(false);
            this.tabEntityExtends.PerformLayout();
            this.tabMappers.ResumeLayout(false);
            this.tabMappers.PerformLayout();
            this.tabMapperExtend.ResumeLayout(false);
            this.tabMapperExtend.PerformLayout();
            this.tabCreateTableScripts.ResumeLayout(false);
            this.tabCreateTableScripts.PerformLayout();
            this.tabInsertDataScripts.ResumeLayout(false);
            this.tabInsertDataScripts.PerformLayout();
            this.tabMultiLangEntity.ResumeLayout(false);
            this.tabMultiLangEntity.PerformLayout();
            this.tabMultiLangSqlProvider.ResumeLayout(false);
            this.tabMultiLangSqlProvider.PerformLayout();
            this.tabMultiLangMapper.ResumeLayout(false);
            this.tabMultiLangMapper.PerformLayout();
            this.tabMultiLangMapperExtend.ResumeLayout(false);
            this.tabMultiLangMapperExtend.PerformLayout();
            this.tabMultiLangCreateTable.ResumeLayout(false);
            this.tabMultiLangCreateTable.PerformLayout();
            this.tabMultiLangInsertData.ResumeLayout(false);
            this.tabMultiLangInsertData.PerformLayout();
            this.tabVO.ResumeLayout(false);
            this.tabVO.PerformLayout();
            this.tabAggVO.ResumeLayout(false);
            this.tabAggVO.PerformLayout();
            this.tabRest.ResumeLayout(false);
            this.tabRest.PerformLayout();
            this.tabService.ResumeLayout(false);
            this.tabService.PerformLayout();
            this.tabServiceImpl.ResumeLayout(false);
            this.tabServiceImpl.PerformLayout();
            this.tabSetting.ResumeLayout(false);
            this.grpPublish.ResumeLayout(false);
            this.grpPublish.PerformLayout();
            this.grpGenerate.ResumeLayout(false);
            this.grpGenerate.PerformLayout();
            this.tabAggVORequest.ResumeLayout(false);
            this.tabAggVORequest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabcMain;
        private System.Windows.Forms.TabPage tabGenerator;
        private System.Windows.Forms.TabPage tabTemplate;
        private System.Windows.Forms.Label lblDesignFile;
        private System.Windows.Forms.Button btnDesignFileBrowse;
        private System.Windows.Forms.TextBox txtDesignFile;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.CheckedListBox chklTemplate;
        private System.Windows.Forms.Label lblUsedTemplate;
        private System.Windows.Forms.TabControl tabcTemplates;
        private System.Windows.Forms.TabPage tabEntities;
        private System.Windows.Forms.TabPage tabEntityExtends;
        private System.Windows.Forms.TabPage tabMappers;
        private System.Windows.Forms.Button btnSourceCodeRoot;
        private System.Windows.Forms.TextBox txtSourceCodeRoot;
        private System.Windows.Forms.Label lblSourceRoot;
        private System.Windows.Forms.CheckBox chkOverwrite;
        private System.Windows.Forms.CheckBox chkCreatePath;
        private System.Windows.Forms.Button btnSelectReverse;
        private System.Windows.Forms.Button btnSelectNone;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.CheckBox chkStopOnError;
        private System.Windows.Forms.TabPage tabCreateTableScripts;
        private System.Windows.Forms.TabPage tabInsertDataScripts;
        private System.Windows.Forms.Button btnScriptSavePath;
        private System.Windows.Forms.TextBox txtScriptSavePath;
        private System.Windows.Forms.Label lblScriptSavePath;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
        private System.Windows.Forms.StatusStrip strpStatus;
        private System.Windows.Forms.ToolStripProgressBar tstrpProgress;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.DataGridView dtgStepLog;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnEntityTpl;
        private System.Windows.Forms.TextBox txtEntityTpl;
        private System.Windows.Forms.Label lblEntityTpl;
        private System.Windows.Forms.RichTextBox rtbEntityTpl;
        private System.Windows.Forms.RichTextBox rtbSqlProviderTpl;
        private System.Windows.Forms.Button btnSqlProviderTpl;
        private System.Windows.Forms.TextBox txtSqlProviderTpl;
        private System.Windows.Forms.Label lblSqlProviderTpl;
        private System.Windows.Forms.RichTextBox rtbMapperTpl;
        private System.Windows.Forms.Button btnMapperTpl;
        private System.Windows.Forms.TextBox txtMapperTpl;
        private System.Windows.Forms.Label lblMapperTpl;
        private System.Windows.Forms.RichTextBox rtbCreateTableTpl;
        private System.Windows.Forms.Button btnCreateTableTpl;
        private System.Windows.Forms.TextBox txtCreateTableTpl;
        private System.Windows.Forms.Label lblCreateTableTpl;
        private System.Windows.Forms.RichTextBox rtbInsertDataTpl;
        private System.Windows.Forms.Button btnInsertDataTpl;
        private System.Windows.Forms.TextBox txtInsertDataTpl;
        private System.Windows.Forms.Label lblInsertDataTpl;
        private System.Windows.Forms.TabPage tabSetting;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.DataGridViewImageColumn colIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colText;
        private System.Windows.Forms.ToolStripStatusLabel tstrsStatus;
        private System.Windows.Forms.TabPage tabMapperExtend;
        private System.Windows.Forms.RichTextBox rtbMapperExtendTpl;
        private System.Windows.Forms.Button btnMapperExtendTpl;
        private System.Windows.Forms.TextBox txtMapperExtendTpl;
        private System.Windows.Forms.Label lblMapperExtendTpl;
        private System.Windows.Forms.TabPage tabMultiLangEntity;
        private System.Windows.Forms.RichTextBox rtbMultiLangEntity;
        private System.Windows.Forms.Button btnMultiLangEntity;
        private System.Windows.Forms.TextBox txtMultiLangEntity;
        private System.Windows.Forms.Label lblMultiLangEntity;
        private System.Windows.Forms.TabPage tabMultiLangSqlProvider;
        private System.Windows.Forms.RichTextBox rtbMultiLangSqlProvider;
        private System.Windows.Forms.Button btnMultiLangSqlProvider;
        private System.Windows.Forms.TextBox txtMultiLangSqlProvider;
        private System.Windows.Forms.Label lblMultiLangSqlProvider;
        private System.Windows.Forms.TabPage tabMultiLangMapper;
        private System.Windows.Forms.RichTextBox rtbMultiLangMapper;
        private System.Windows.Forms.Button btnMultiLangMapper;
        private System.Windows.Forms.TextBox txtMultiLangMapper;
        private System.Windows.Forms.Label lblMultiLangMapper;
        private System.Windows.Forms.TabPage tabMultiLangMapperExtend;
        private System.Windows.Forms.RichTextBox rtbMultiLangMapperExtend;
        private System.Windows.Forms.Button btnMultiLangMapperExtend;
        private System.Windows.Forms.TextBox txtMultiLangMapperExtend;
        private System.Windows.Forms.Label lblMultiLangMapperExtend;
        private System.Windows.Forms.TabPage tabMultiLangCreateTable;
        private System.Windows.Forms.TabPage tabMultiLangInsertData;
        private System.Windows.Forms.RichTextBox rtbMultiLangCreateTable;
        private System.Windows.Forms.Button btnMultiLangCreateTable;
        private System.Windows.Forms.TextBox txtMultiLangCreateTable;
        private System.Windows.Forms.Label lblMultLangCreateTable;
        private System.Windows.Forms.RichTextBox rtbMultiLangInsertData;
        private System.Windows.Forms.Button btnMultiLangInsertData;
        private System.Windows.Forms.TextBox txtMultiLangInsertData;
        private System.Windows.Forms.Label lblMultiLangInsertData;
        private System.Windows.Forms.TabPage tabVO;
        private System.Windows.Forms.RichTextBox rtbVOTpl;
        private System.Windows.Forms.Button btnVO;
        private System.Windows.Forms.TextBox txtVO;
        private System.Windows.Forms.Label lblVO;
        private System.Windows.Forms.TabPage tabAggVO;
        private System.Windows.Forms.RichTextBox rtbAggVO;
        private System.Windows.Forms.Button btnAggVO;
        private System.Windows.Forms.TextBox txtAggVO;
        private System.Windows.Forms.Label lblAggVO;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.GroupBox grpPublish;
        private System.Windows.Forms.Label lblDBConnStr;
        private System.Windows.Forms.TextBox txtDBConnStr;
        private System.Windows.Forms.GroupBox grpGenerate;
        private System.Windows.Forms.Button btnChangeColor;
        private System.Windows.Forms.TextBox txtTagColor;
        private System.Windows.Forms.Label lblClassRoot;
        private System.Windows.Forms.Label lblTagColor;
        private System.Windows.Forms.CheckBox chkGenerateAuthor;
        private System.Windows.Forms.TextBox txtClassRoot;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.CheckBox chkExecuteMultiLang;
        private System.Windows.Forms.Label lblBaseExecutive;
        private System.Windows.Forms.TextBox txtBaseExecutive;
        private System.Windows.Forms.Label lblInsertTablePrefix;
        private System.Windows.Forms.TextBox txtInsertDataPrefix;
        private System.Windows.Forms.Label lblCreateTablePrefix;
        private System.Windows.Forms.TextBox txtCreateTablePrefix;
        private System.Windows.Forms.TabPage tabRest;
        private System.Windows.Forms.TabPage tabService;
        private System.Windows.Forms.TabPage tabServiceImpl;
        private System.Windows.Forms.RichTextBox rtbRestTpl;
        private System.Windows.Forms.Button btnRestTpl;
        private System.Windows.Forms.TextBox txtRestTpl;
        private System.Windows.Forms.Label lblRestTpl;
        private System.Windows.Forms.RichTextBox rtbServiceTpl;
        private System.Windows.Forms.Button btnServiceTpl;
        private System.Windows.Forms.TextBox txtServiceTpl;
        private System.Windows.Forms.Label lblServiceTpl;
        private System.Windows.Forms.RichTextBox rtbServiceImplTpl;
        private System.Windows.Forms.Button btnServiceImplTpl;
        private System.Windows.Forms.TextBox txtServiceImplTpl;
        private System.Windows.Forms.Label lblServiceImplTpl;
        private System.Windows.Forms.TabPage tabAggVORequest;
        private System.Windows.Forms.RichTextBox rtbAggVORequestTpl;
        private System.Windows.Forms.Button btnAggVORequestTpl;
        private System.Windows.Forms.TextBox txtAggVORequestTpl;
        private System.Windows.Forms.Label lblAggVORequestTpl;
    }
}

