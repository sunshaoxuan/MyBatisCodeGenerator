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
            this.dtgStepLog = new System.Windows.Forms.DataGridView();
            this.colIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.colText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strpStatus = new System.Windows.Forms.StatusStrip();
            this.tstrpProgress = new System.Windows.Forms.ToolStripProgressBar();
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
            this.tabSetting = new System.Windows.Forms.TabPage();
            this.btnChangeColor = new System.Windows.Forms.Button();
            this.txtTagColor = new System.Windows.Forms.TextBox();
            this.lblTagColor = new System.Windows.Forms.Label();
            this.chkGenerateAuthor = new System.Windows.Forms.CheckBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.lblDefaultExt = new System.Windows.Forms.Label();
            this.txtDefaultExt = new System.Windows.Forms.TextBox();
            this.txtDefaultSQLExt = new System.Windows.Forms.TextBox();
            this.lblDefaultSQLExt = new System.Windows.Forms.Label();
            this.tabcMain.SuspendLayout();
            this.tabGenerator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgStepLog)).BeginInit();
            this.strpStatus.SuspendLayout();
            this.tabTemplate.SuspendLayout();
            this.tabcTemplates.SuspendLayout();
            this.tabEntities.SuspendLayout();
            this.tabEntityExtends.SuspendLayout();
            this.tabMappers.SuspendLayout();
            this.tabCreateTableScripts.SuspendLayout();
            this.tabInsertDataScripts.SuspendLayout();
            this.tabSetting.SuspendLayout();
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
            this.dtgStepLog.Location = new System.Drawing.Point(3, 184);
            this.dtgStepLog.Name = "dtgStepLog";
            this.dtgStepLog.ReadOnly = true;
            this.dtgStepLog.RowTemplate.Height = 21;
            this.dtgStepLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgStepLog.ShowCellErrors = false;
            this.dtgStepLog.ShowEditingIcon = false;
            this.dtgStepLog.ShowRowErrors = false;
            this.dtgStepLog.Size = new System.Drawing.Size(770, 323);
            this.dtgStepLog.TabIndex = 9;
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
            this.tstrpProgress});
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
            this.tstrpProgress.Visible = false;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(683, 155);
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
            this.btnRun.Location = new System.Drawing.Point(602, 155);
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
            "Create Table Scripts",
            "Insert Data Scripts"});
            this.chklTemplate.Location = new System.Drawing.Point(155, 39);
            this.chklTemplate.MultiColumn = true;
            this.chklTemplate.Name = "chklTemplate";
            this.chklTemplate.Size = new System.Drawing.Size(284, 60);
            this.chklTemplate.TabIndex = 4;
            this.chklTemplate.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklTemplate_ItemCheck);
            this.chklTemplate.SelectedValueChanged += new System.EventHandler(this.chklTemplate_SelectedValueChanged_1);
            // 
            // lblUsedTemplate
            // 
            this.lblUsedTemplate.AutoSize = true;
            this.lblUsedTemplate.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.btnScriptSavePath.Location = new System.Drawing.Point(738, 129);
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
            this.btnSourceCodeRoot.Location = new System.Drawing.Point(738, 104);
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
            this.txtScriptSavePath.Location = new System.Drawing.Point(151, 130);
            this.txtScriptSavePath.Name = "txtScriptSavePath";
            this.txtScriptSavePath.Size = new System.Drawing.Size(586, 19);
            this.txtScriptSavePath.TabIndex = 1;
            // 
            // txtSourceCodeRoot
            // 
            this.txtSourceCodeRoot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceCodeRoot.Location = new System.Drawing.Point(151, 105);
            this.txtSourceCodeRoot.Name = "txtSourceCodeRoot";
            this.txtSourceCodeRoot.Size = new System.Drawing.Size(586, 19);
            this.txtSourceCodeRoot.TabIndex = 1;
            // 
            // txtDesignFile
            // 
            this.txtDesignFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesignFile.Location = new System.Drawing.Point(155, 14);
            this.txtDesignFile.Name = "txtDesignFile";
            this.txtDesignFile.Size = new System.Drawing.Size(582, 19);
            this.txtDesignFile.TabIndex = 1;
            // 
            // lblScriptSavePath
            // 
            this.lblScriptSavePath.AutoSize = true;
            this.lblScriptSavePath.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblScriptSavePath.Location = new System.Drawing.Point(24, 133);
            this.lblScriptSavePath.Name = "lblScriptSavePath";
            this.lblScriptSavePath.Size = new System.Drawing.Size(121, 12);
            this.lblScriptSavePath.TabIndex = 0;
            this.lblScriptSavePath.Text = "Scripts Saved Path";
            // 
            // lblSourceRoot
            // 
            this.lblSourceRoot.AutoSize = true;
            this.lblSourceRoot.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSourceRoot.Location = new System.Drawing.Point(31, 108);
            this.lblSourceRoot.Name = "lblSourceRoot";
            this.lblSourceRoot.Size = new System.Drawing.Size(114, 12);
            this.lblSourceRoot.TabIndex = 0;
            this.lblSourceRoot.Text = "Source Code Root";
            // 
            // lblDesignFile
            // 
            this.lblDesignFile.AutoSize = true;
            this.lblDesignFile.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.tabcTemplates.Controls.Add(this.tabCreateTableScripts);
            this.tabcTemplates.Controls.Add(this.tabInsertDataScripts);
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
            // tabSetting
            // 
            this.tabSetting.Controls.Add(this.lblDefaultSQLExt);
            this.tabSetting.Controls.Add(this.lblDefaultExt);
            this.tabSetting.Controls.Add(this.btnChangeColor);
            this.tabSetting.Controls.Add(this.txtTagColor);
            this.tabSetting.Controls.Add(this.lblTagColor);
            this.tabSetting.Controls.Add(this.chkGenerateAuthor);
            this.tabSetting.Controls.Add(this.txtDefaultSQLExt);
            this.tabSetting.Controls.Add(this.txtDefaultExt);
            this.tabSetting.Controls.Add(this.txtAuthor);
            this.tabSetting.Controls.Add(this.lblAuthor);
            this.tabSetting.Location = new System.Drawing.Point(4, 22);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetting.Size = new System.Drawing.Size(776, 535);
            this.tabSetting.TabIndex = 2;
            this.tabSetting.Text = "Settings";
            this.tabSetting.UseVisualStyleBackColor = true;
            // 
            // btnChangeColor
            // 
            this.btnChangeColor.Location = new System.Drawing.Point(230, 36);
            this.btnChangeColor.Name = "btnChangeColor";
            this.btnChangeColor.Size = new System.Drawing.Size(97, 23);
            this.btnChangeColor.TabIndex = 5;
            this.btnChangeColor.Text = "Change Color";
            this.btnChangeColor.UseVisualStyleBackColor = true;
            this.btnChangeColor.Click += new System.EventHandler(this.btnChangeColor_Click);
            // 
            // txtTagColor
            // 
            this.txtTagColor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTagColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTagColor.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTagColor.ForeColor = System.Drawing.Color.Maroon;
            this.txtTagColor.Location = new System.Drawing.Point(78, 38);
            this.txtTagColor.Name = "txtTagColor";
            this.txtTagColor.ReadOnly = true;
            this.txtTagColor.Size = new System.Drawing.Size(146, 19);
            this.txtTagColor.TabIndex = 4;
            this.txtTagColor.Text = "$TEMPLATETAGS$";
            this.txtTagColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTagColor
            // 
            this.lblTagColor.AutoSize = true;
            this.lblTagColor.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTagColor.Location = new System.Drawing.Point(8, 41);
            this.lblTagColor.Name = "lblTagColor";
            this.lblTagColor.Size = new System.Drawing.Size(64, 12);
            this.lblTagColor.TabIndex = 3;
            this.lblTagColor.Text = "Tag Color";
            // 
            // chkGenerateAuthor
            // 
            this.chkGenerateAuthor.AutoSize = true;
            this.chkGenerateAuthor.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkGenerateAuthor.Location = new System.Drawing.Point(11, 12);
            this.chkGenerateAuthor.Name = "chkGenerateAuthor";
            this.chkGenerateAuthor.Size = new System.Drawing.Size(173, 16);
            this.chkGenerateAuthor.TabIndex = 2;
            this.chkGenerateAuthor.Text = "Generate Author Remark";
            this.chkGenerateAuthor.UseVisualStyleBackColor = true;
            this.chkGenerateAuthor.CheckedChanged += new System.EventHandler(this.chkGenerateAuthor_CheckedChanged);
            // 
            // txtAuthor
            // 
            this.txtAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthor.Enabled = false;
            this.txtAuthor.Location = new System.Drawing.Point(247, 10);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(521, 19);
            this.txtAuthor.TabIndex = 1;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Enabled = false;
            this.lblAuthor.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAuthor.Location = new System.Drawing.Point(196, 13);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(45, 12);
            this.lblAuthor.TabIndex = 0;
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
            // lblDefaultExt
            // 
            this.lblDefaultExt.AutoSize = true;
            this.lblDefaultExt.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDefaultExt.Location = new System.Drawing.Point(6, 68);
            this.lblDefaultExt.Name = "lblDefaultExt";
            this.lblDefaultExt.Size = new System.Drawing.Size(151, 12);
            this.lblDefaultExt.TabIndex = 6;
            this.lblDefaultExt.Text = "Default Source File Ext.";
            // 
            // txtDefaultExt
            // 
            this.txtDefaultExt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDefaultExt.Enabled = false;
            this.txtDefaultExt.Location = new System.Drawing.Point(163, 65);
            this.txtDefaultExt.Name = "txtDefaultExt";
            this.txtDefaultExt.Size = new System.Drawing.Size(605, 19);
            this.txtDefaultExt.TabIndex = 1;
            this.txtDefaultExt.Text = ".java";
            // 
            // txtDefaultSQLExt
            // 
            this.txtDefaultSQLExt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDefaultSQLExt.Enabled = false;
            this.txtDefaultSQLExt.Location = new System.Drawing.Point(163, 90);
            this.txtDefaultSQLExt.Name = "txtDefaultSQLExt";
            this.txtDefaultSQLExt.Size = new System.Drawing.Size(605, 19);
            this.txtDefaultSQLExt.TabIndex = 1;
            this.txtDefaultSQLExt.Text = ".sql";
            // 
            // lblDefaultSQLExt
            // 
            this.lblDefaultSQLExt.AutoSize = true;
            this.lblDefaultSQLExt.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDefaultSQLExt.Location = new System.Drawing.Point(23, 93);
            this.lblDefaultSQLExt.Name = "lblDefaultSQLExt";
            this.lblDefaultSQLExt.Size = new System.Drawing.Size(134, 12);
            this.lblDefaultSQLExt.TabIndex = 6;
            this.lblDefaultSQLExt.Text = "Default SQL File Ext.";
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
            this.tabCreateTableScripts.ResumeLayout(false);
            this.tabCreateTableScripts.PerformLayout();
            this.tabInsertDataScripts.ResumeLayout(false);
            this.tabInsertDataScripts.PerformLayout();
            this.tabSetting.ResumeLayout(false);
            this.tabSetting.PerformLayout();
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
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.CheckBox chkGenerateAuthor;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.DataGridViewImageColumn colIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colText;
        private System.Windows.Forms.Button btnChangeColor;
        private System.Windows.Forms.TextBox txtTagColor;
        private System.Windows.Forms.Label lblTagColor;
        private System.Windows.Forms.Label lblDefaultExt;
        private System.Windows.Forms.TextBox txtDefaultExt;
        private System.Windows.Forms.Label lblDefaultSQLExt;
        private System.Windows.Forms.TextBox txtDefaultSQLExt;
    }
}

