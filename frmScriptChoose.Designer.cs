namespace MyBatisCodeGenerator
{
    partial class frmScriptChoose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScriptChoose));
            this.chklScripts = new System.Windows.Forms.CheckedListBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.llbSelectAll = new System.Windows.Forms.LinkLabel();
            this.llbSelectNone = new System.Windows.Forms.LinkLabel();
            this.llbSelectReverse = new System.Windows.Forms.LinkLabel();
            this.llbSelectCreateTable = new System.Windows.Forms.LinkLabel();
            this.llbAllInsert = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // chklScripts
            // 
            this.chklScripts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chklScripts.CheckOnClick = true;
            this.chklScripts.FormattingEnabled = true;
            this.chklScripts.Location = new System.Drawing.Point(12, 40);
            this.chklScripts.Name = "chklScripts";
            this.chklScripts.Size = new System.Drawing.Size(776, 368);
            this.chklScripts.TabIndex = 5;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(51, 13);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(737, 19);
            this.txtFilter.TabIndex = 6;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(13, 16);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(32, 12);
            this.lblFilter.TabIndex = 7;
            this.lblFilter.Text = "Filter";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(667, 417);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel (&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnExecute.Location = new System.Drawing.Point(546, 417);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(115, 23);
            this.btnExecute.TabIndex = 11;
            this.btnExecute.Text = "Execute (&E)";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // llbSelectAll
            // 
            this.llbSelectAll.AutoSize = true;
            this.llbSelectAll.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbSelectAll.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.llbSelectAll.Location = new System.Drawing.Point(12, 419);
            this.llbSelectAll.Name = "llbSelectAll";
            this.llbSelectAll.Size = new System.Drawing.Size(28, 17);
            this.llbSelectAll.TabIndex = 13;
            this.llbSelectAll.TabStop = true;
            this.llbSelectAll.Text = "ALL";
            this.llbSelectAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbSelectAll_LinkClicked);
            // 
            // llbSelectNone
            // 
            this.llbSelectNone.AutoSize = true;
            this.llbSelectNone.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbSelectNone.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.llbSelectNone.Location = new System.Drawing.Point(53, 419);
            this.llbSelectNone.Name = "llbSelectNone";
            this.llbSelectNone.Size = new System.Drawing.Size(38, 17);
            this.llbSelectNone.TabIndex = 13;
            this.llbSelectNone.TabStop = true;
            this.llbSelectNone.Text = "None";
            this.llbSelectNone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbSelectNone_LinkClicked);
            // 
            // llbSelectReverse
            // 
            this.llbSelectReverse.AutoSize = true;
            this.llbSelectReverse.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbSelectReverse.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.llbSelectReverse.Location = new System.Drawing.Point(100, 419);
            this.llbSelectReverse.Name = "llbSelectReverse";
            this.llbSelectReverse.Size = new System.Drawing.Size(53, 17);
            this.llbSelectReverse.TabIndex = 13;
            this.llbSelectReverse.TabStop = true;
            this.llbSelectReverse.Text = "Reverse";
            this.llbSelectReverse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbSelectReverse_LinkClicked);
            // 
            // llbSelectCreateTable
            // 
            this.llbSelectCreateTable.AutoSize = true;
            this.llbSelectCreateTable.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbSelectCreateTable.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.llbSelectCreateTable.Location = new System.Drawing.Point(163, 419);
            this.llbSelectCreateTable.Name = "llbSelectCreateTable";
            this.llbSelectCreateTable.Size = new System.Drawing.Size(63, 17);
            this.llbSelectCreateTable.TabIndex = 13;
            this.llbSelectCreateTable.TabStop = true;
            this.llbSelectCreateTable.Text = "All Create";
            this.llbSelectCreateTable.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbSelectCreateTable_LinkClicked);
            // 
            // llbAllInsert
            // 
            this.llbAllInsert.AutoSize = true;
            this.llbAllInsert.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbAllInsert.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.llbAllInsert.Location = new System.Drawing.Point(236, 419);
            this.llbAllInsert.Name = "llbAllInsert";
            this.llbAllInsert.Size = new System.Drawing.Size(58, 17);
            this.llbAllInsert.TabIndex = 13;
            this.llbAllInsert.TabStop = true;
            this.llbAllInsert.Text = "All Insert";
            this.llbAllInsert.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbAllInsert_LinkClicked);
            // 
            // frmScriptChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.llbAllInsert);
            this.Controls.Add(this.llbSelectCreateTable);
            this.Controls.Add(this.llbSelectReverse);
            this.Controls.Add(this.llbSelectNone);
            this.Controls.Add(this.llbSelectAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.chklScripts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmScriptChoose";
            this.Text = "Choose Script File to Publish";
            this.Load += new System.EventHandler(this.frmScriptChoose_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chklScripts;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.LinkLabel llbSelectAll;
        private System.Windows.Forms.LinkLabel llbSelectNone;
        private System.Windows.Forms.LinkLabel llbSelectReverse;
        private System.Windows.Forms.LinkLabel llbSelectCreateTable;
        private System.Windows.Forms.LinkLabel llbAllInsert;
    }
}