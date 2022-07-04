using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MyBatisCodeGenerator
{
    public partial class frmMain : Form
    {
        enum RunStatus
        {
            Running, Stopped
        }

        Dictionary<String, String> settings = new Dictionary<string, string>();
        RunStatus runStatus = RunStatus.Stopped;

        public frmMain()
        {
            InitializeComponent();
        }


        private void btnDesignFileBrowse_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Filter = "Excel Files | *.xls;*.xlsx";
            DialogResult result = dlgOpenFile.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtDesignFile.Text = dlgOpenFile.FileName;
            }

            refreshRunButtonStatus();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklTemplate.Items.Count; i++)
            {
                chklTemplate.SetItemChecked(i, true);
            }
            refreshRunButtonStatus();
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklTemplate.Items.Count; i++)
            {
                chklTemplate.SetItemChecked(i, false);
            }
            refreshRunButtonStatus();
        }

        private void btnSelectReverse_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklTemplate.Items.Count; i++)
            {
                chklTemplate.SetItemChecked(i, chklTemplate.GetItemChecked(i) ? false : true);
            }
            refreshRunButtonStatus();
        }

        private void btnSourceCodeRoot_Click(object sender, EventArgs e)
        {
            DialogResult result = dlgFolderBrowser.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtSourceCodeRoot.Text = dlgFolderBrowser.SelectedPath;
            }
            refreshRunButtonStatus();
        }

        private void btnScriptSavePath_Click(object sender, EventArgs e)
        {
            DialogResult result = dlgFolderBrowser.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtScriptSavePath.Text = dlgFolderBrowser.SelectedPath;
            }
            refreshRunButtonStatus();
        }

        private void btnEntityTpl_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Filter = "Template File | *.Tpl";
            dlgOpenFile.FileName = "Entity.Tpl";
            DialogResult result = dlgOpenFile.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtEntityTpl.Text = dlgOpenFile.FileName;
            }
        }

        private void btnEntityExtendTpl_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Filter = "Template File | *.Tpl";
            dlgOpenFile.FileName = "SqlProvider.Tpl";
            DialogResult result = dlgOpenFile.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtSqlProviderTpl.Text = dlgOpenFile.FileName;
            }
        }

        private void btnMapperTpl_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Filter = "Template File | *.Tpl";
            dlgOpenFile.FileName = "Mapper.Tpl";
            DialogResult result = dlgOpenFile.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtMapperTpl.Text = dlgOpenFile.FileName;
            }
        }

        private void btnCreateTableTpl_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Filter = "Template File | *.Tpl";
            dlgOpenFile.FileName = "CreateTable.Tpl";
            DialogResult result = dlgOpenFile.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtCreateTableTpl.Text = dlgOpenFile.FileName;
            }
        }

        private void btnInsertDataTpl_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Filter = "Template File | *.Tpl";
            dlgOpenFile.FileName = "InsertData.Tpl";
            DialogResult result = dlgOpenFile.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtInsertDataTpl.Text = dlgOpenFile.FileName;
            }
        }

        private void refreshRunButtonStatus()
        {
            btnStop.Enabled = false;

            if (String.IsNullOrEmpty(txtDesignFile.Text))
            {
                btnRun.Enabled = false;
                return;
            }

            if (chklTemplate.CheckedItems.Count == 0)
            {
                btnRun.Enabled = false;
                return;
            }

            if (String.IsNullOrEmpty(txtSourceCodeRoot.Text) && String.IsNullOrEmpty(txtScriptSavePath.Text))
            {
                btnRun.Enabled = false;
                return;
            }

            btnRun.Enabled = true;
        }

        private void disableAllOnRunning()
        {
            btnRun.Enabled = false;
            tabTemplate.Enabled = false;
            tabSetting.Enabled = false;

            lblDesignFile.Enabled = false;
            txtDesignFile.Enabled = false;
            btnDesignFileBrowse.Enabled = false;

            lblUsedTemplate.Enabled = false;
            chklTemplate.Enabled = false;
            btnSelectAll.Enabled = false;
            btnSelectNone.Enabled = false;
            btnSelectReverse.Enabled = false;

            lblSourceRoot.Enabled = false;
            txtSourceCodeRoot.Enabled = false;
            btnSourceCodeRoot.Enabled = false;

            lblScriptSavePath.Enabled = false;
            txtScriptSavePath.Enabled = false;
            btnScriptSavePath.Enabled = false;

            chkOverwrite.Enabled = false;
            chkCreatePath.Enabled = false;
            chkStopOnError.Enabled = false;
        }

        private void enableAllOnStop()
        {
            btnRun.Enabled = true;
            tabTemplate.Enabled = true;
            tabSetting.Enabled = true;

            lblDesignFile.Enabled = true;
            txtDesignFile.Enabled = true;
            btnDesignFileBrowse.Enabled = true;

            lblUsedTemplate.Enabled = true;
            chklTemplate.Enabled = true;
            btnSelectAll.Enabled = true;
            btnSelectNone.Enabled = true;
            btnSelectReverse.Enabled = true;

            lblSourceRoot.Enabled = true;
            txtSourceCodeRoot.Enabled = true;
            btnSourceCodeRoot.Enabled = true;

            lblScriptSavePath.Enabled = true;
            txtScriptSavePath.Enabled = true;
            btnScriptSavePath.Enabled = true;

            chkOverwrite.Enabled = true;
            chkCreatePath.Enabled=true;
            chkStopOnError.Enabled=true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            refreshRunButtonStatus();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            runStatus = RunStatus.Running;

            disableAllOnRunning();

            tstrpProgress.Visible = true;
            btnStop.Enabled = true;

            Application.DoEvents();

            try
            {
                generate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            stopGenerate(true);
        }

        List<String> preparedDefineTables = new List<string>();
        List<String> preparedDataTables = new List<string>();

        private void generate()
        {
            int stepCount = 0;
            int finishedCount = 0;
            tstrpProgress.Value = 0;

            if (runStatus.Equals(RunStatus.Stopped))
            {
                return;
            }

            //Load Design File
            stepCount++;
            Dictionary<string, DataTable> excelTables = ExcelUtils.GetExcelTableByOleDB(txtDesignFile.Text);
            finishedCount++;

            if (runStatus.Equals(RunStatus.Stopped))
            {
                return;
            }

            //Check Design File
            stepCount++;
            getPreparedTables(excelTables);
            stepCount += preparedDefineTables.Count * 3;
            stepCount += preparedDataTables.Count * 2;
            finishedCount++;

            if (runStatus.Equals(RunStatus.Stopped))
            {
                return;
            }

            tstrpProgress.Value = 100 * finishedCount / stepCount;

            //Check Tamplates
            stepCount++;
            checkTemplates();
            finishedCount++;

            if (runStatus.Equals(RunStatus.Stopped))
            {
                return;
            }

            tstrpProgress.Value = 100 * finishedCount / stepCount;

            //Execute Task List
            foreach (KeyValuePair<string, DataTable> kv in excelTables)
            {
                if (runStatus.Equals(RunStatus.Stopped))
                {
                    return;
                }

                int rowNoAdded = dtgStepLog.Rows.Add("Dealing:" + kv.Key);
                dtgStepLog.Rows[rowNoAdded].Cells[1].Value = "Dealing: " + kv.Key;
                ((DataGridViewImageCell)dtgStepLog.Rows[rowNoAdded].Cells[0]).Value = imgList.Images["running.gif"];
                dtgStepLog.Refresh();

                if (preparedDefineTables.Contains(kv.Key))
                {
                    if (runStatus.Equals(RunStatus.Stopped))
                    {
                        return;
                    }

                    //Entity
                    if (chklTemplate.GetItemChecked(0)) {
                        doGenerate(kv.Value, rtbEntityTpl.Text, TemplateType.Entity);
                    }

                    finishedCount++;
                    tstrpProgress.Value = 100 * finishedCount / stepCount;

                    if (runStatus.Equals(RunStatus.Stopped))
                    {
                        return;
                    }
                    //SqlProvider
                    if (chklTemplate.GetItemChecked(1))
                    {
                        doGenerate(kv.Value, rtbSqlProviderTpl.Text, TemplateType.SqlProvider);
                    }

                    finishedCount++;
                    tstrpProgress.Value = 100 * finishedCount / stepCount;

                    if (runStatus.Equals(RunStatus.Stopped))
                    {
                        return;
                    }
                    //Mapper
                    if (chklTemplate.GetItemChecked(2))
                    {
                        doGenerate(kv.Value, rtbMapperTpl.Text, TemplateType.Mapper);
                    }

                    finishedCount++;
                    tstrpProgress.Value = 100 * finishedCount / stepCount;
                }

                if (preparedDataTables.Contains(kv.Key))
                {
                    if (runStatus.Equals(RunStatus.Stopped))
                    {
                        return;
                    }
                    //Create Table
                    if (chklTemplate.GetItemChecked(3))
                    {
                        doGenerate(kv.Value, rtbCreateTableTpl.Text, TemplateType.CreateTable);
                    }

                    finishedCount++;
                    tstrpProgress.Value = 100 * finishedCount / stepCount;

                    if (runStatus.Equals(RunStatus.Stopped))
                    {
                        return;
                    }
                    //Insert Data
                    if (chklTemplate.GetItemChecked(4))
                    {
                        doGenerate(kv.Value, rtbInsertDataTpl.Text, TemplateType.InsertData);
                    }

                    finishedCount++;
                    tstrpProgress.Value = 100 * finishedCount / stepCount;
                }

                dtgStepLog.Rows[rowNoAdded].Cells[1].Value = kv.Key + " dealed.";
                ((DataGridViewImageCell)dtgStepLog.Rows[rowNoAdded].Cells[0]).Value = imgList.Images["success.gif"];
                dtgStepLog.Refresh();
            }
        }

        private void stopGenerate(bool isAuto)
        {
            if (!isAuto)
            {
                int rowNoAdded = dtgStepLog.Rows.Add("User interrupted.");
                dtgStepLog.Rows[rowNoAdded].Cells[1].Value = "User interrupted.";
                ((DataGridViewImageCell)dtgStepLog.Rows[rowNoAdded].Cells[0]).Value = imgList.Images["stop.gif"];
                dtgStepLog.Refresh();
            }

            runStatus = RunStatus.Stopped;
            btnRun.Enabled = true;
            tstrpProgress.Visible = false;
            enableAllOnStop();
        }

        private void doGenerate(DataTable table, string templateText, TemplateType tmpType)
        {
            int newTaskRowNo = dtgStepLog.Rows.Add("Generating: [" + tmpType.ToString() + "]");
            dtgStepLog.Rows[newTaskRowNo].Cells[1].Value = "Generating: [" + tmpType.ToString() + "]";

            ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Value = imgList.Images["running.gif"];
            dtgStepLog.Refresh();
            try
            {
                string savedFileName = translateTemplate(table, templateText, tmpType);

                if (string.IsNullOrEmpty(savedFileName))
                {
                    dtgStepLog.Rows[newTaskRowNo].Cells[1].Value = "No file Generated?";
                    ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Value = imgList.Images["warning.gif"];
                    dtgStepLog.Refresh();
                }
                else
                {
                    dtgStepLog.Rows[newTaskRowNo].Cells[1].Value = "File [" + savedFileName + "] generated." ;
                    ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Value = imgList.Images["success.gif"];
                    dtgStepLog.Refresh();
                }
            }
            catch (Exception ex)
            {
                CommonUtils.log(ex.StackTrace);

                if (chkStopOnError.Checked)
                {
                    dtgStepLog.Rows[newTaskRowNo].Cells[1].Value = "Error:" + ex.Message;
                    ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Value = imgList.Images["error.gif"];
                    stopGenerate(true);
                }
                else
                {
                    dtgStepLog.Rows[newTaskRowNo].Cells[1].Value = "warning:" + ex.Message;
                    ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Value = imgList.Images["warning.gif"];
                }

                dtgStepLog.Refresh();
            }
        }

        private string translateTemplate(DataTable table, string templateText, TemplateType templateType)
        {
            string contentText = string.Empty;
            Application.DoEvents();
            contentText = TemplateUtils.templateApply(table, templateText,
                //Author
                chkGenerateAuthor.Checked ? txtAuthor.Text : "");
            string savedPath;
            string ext;

            if (templateType.Equals(TemplateType.Entity) || templateType.Equals(TemplateType.SqlProvider) || templateType.Equals(TemplateType.Mapper))
            {
                ext = txtDefaultExt.Text;
                savedPath = TemplateUtils.getSavedPath(table, txtSourceCodeRoot.Text, templateType);
            }
            else
            {
                ext = txtDefaultSQLExt.Text;
                savedPath = TemplateUtils.getSavedPath(table, txtScriptSavePath.Text, templateType);
            }


            string savedFilename = TemplateUtils.getSavedFileName(table, templateType, ext);
            CommonUtils.writeTextFile(savedFilename, savedPath, contentText, chkCreatePath.Checked, chkOverwrite.Checked, false, true);
            Application.DoEvents();
            return savedFilename;
        }

        private void checkTemplates()
        {
            if (preparedDefineTables.Count > 0)
            {
                if (string.IsNullOrEmpty(txtEntityTpl.Text)
                    && string.IsNullOrEmpty(txtSqlProviderTpl.Text)
                    && string.IsNullOrEmpty(txtMapperTpl.Text))
                {
                    throw new Exception("Code templates cannot be empty.");
                }
            }

            if (preparedDataTables.Count > 0)
            {
                if (string.IsNullOrEmpty(txtCreateTableTpl.Text)
                    && string.IsNullOrEmpty(txtInsertDataTpl.Text))
                {
                    throw new Exception("Script templates cannot be empty.");
                }
            }
        }

        private void getPreparedTables(Dictionary<string, DataTable> excelTables)
        {
            if (excelTables != null)
            {
                foreach (KeyValuePair<String, DataTable> kv in excelTables)
                {
                    bool bMetaBegin = false;
                    bool bMetaEnd = false;
                    bool bDataBegin = false;
                    bool bDataEnd = false;
                    foreach (DataRow row in kv.Value.Rows)
                    {
                        if (row[0].ToString().ToUpper().Contains("$MYBATIS META DESIGN START$"))
                        {
                            bMetaBegin = true;
                        }

                        if (row[0].ToString().ToUpper().Contains("$MYBATIS META DESIGN END$"))
                        {
                            bMetaEnd = true;
                            continue;
                        }

                        if (row[0].ToString().ToUpper().Contains("$MYBATIS DATA START$"))
                        {
                            bDataBegin = true;
                            continue;
                        }

                        if (row[0].ToString().ToUpper().Contains("$MYBATIS DATA END$"))
                        {
                            bDataEnd = true;
                            continue;
                        }
                    }

                    if (bMetaBegin && bMetaEnd)
                    {
                        preparedDefineTables.Add(kv.Key);
                    }

                    if (bDataBegin && bDataEnd)
                    {
                        preparedDataTables.Add(kv.Key);
                    }
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stopGenerate(false);
        }

        private void chklTemplate_SelectedValueChanged(object sender, EventArgs e)
        {
            refreshRunButtonStatus();
        }

        private void chklTemplate_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            refreshRunButtonStatus();
        }

        private void chklTemplate_SelectedValueChanged_1(object sender, EventArgs e)
        {
            refreshRunButtonStatus();
        }

        private void chkGenerateAuthor_CheckedChanged(object sender, EventArgs e)
        {
            lblAuthor.Enabled = chkGenerateAuthor.Checked;
            txtAuthor.Enabled = chkGenerateAuthor.Checked;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            fetchSettingsFromControls(this);
            CommonUtils.writeSerializationDataToFile(Application.StartupPath + @"\setting.dat", settings);
        }

        private void fetchSettingsFromControls(Control control)
        {
            foreach (Control ctl in control.Controls)
            {
                if (ctl is TextBox)
                {
                    if (settings.ContainsKey(ctl.Name))
                    {
                        settings[ctl.Name] = ctl.Text;
                    }
                    else
                    {
                        settings.Add(ctl.Name, ctl.Text);
                    }
                }
                else if (ctl is CheckBox)
                {
                    if (settings.ContainsKey(ctl.Name))
                    {
                        settings[ctl.Name] = ((CheckBox)ctl).Checked.ToString();
                    }
                    else
                    {
                        settings.Add(ctl.Name, ((CheckBox)ctl).Checked.ToString());
                    }
                }
                else if (ctl is CheckedListBox)
                {
                    string checkedItems = string.Empty;
                    for (int i = 0; i <= ((CheckedListBox)ctl).Items.Count - 1; i++)
                    {
                        if (((CheckedListBox)ctl).GetItemChecked(i))
                        {
                            if (string.IsNullOrEmpty(checkedItems))
                            {
                                checkedItems = (string)((CheckedListBox)ctl).Items[i];
                            }
                            else
                            {
                                checkedItems += "," + ((CheckedListBox)ctl).Items[i];
                            }
                        }
                    }

                    if (settings.ContainsKey(ctl.Name))
                    {
                        settings[ctl.Name] = checkedItems;
                    }
                    else
                    {
                        settings.Add(ctl.Name, checkedItems);
                    }
                }

                fetchSettingsFromControls(ctl);
            }
        }

        private void injectSettingsToControls(Control control)
        {
            foreach (Control ctl in control.Controls)
            {
                if (ctl is TextBox)
                {
                    if (settings.ContainsKey(ctl.Name))
                    {
                        ctl.Text = settings[ctl.Name];
                    }
                }
                else if (ctl is CheckBox)
                {
                    if (settings.ContainsKey(ctl.Name))
                    {
                        ((CheckBox)ctl).Checked = Boolean.Parse(settings[ctl.Name]);
                    }
                }
                else if (ctl is CheckedListBox)
                {
                    if (settings.ContainsKey(ctl.Name))
                    {
                        for (int i = 0; i <= ((CheckedListBox)ctl).Items.Count - 1; i++)
                        {
                            if (settings[ctl.Name].Contains((string)((CheckedListBox)ctl).Items[i]))
                            {
                                ((CheckedListBox)ctl).SetItemChecked(i, true);
                            }
                            else
                            {
                                ((CheckedListBox)ctl).SetItemChecked(i, false);
                            }
                        }
                    }
                }

                injectSettingsToControls(ctl);
            }
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + @"\setting.dat"))
            {
                Object settingObj = CommonUtils.readSerializationDataFromFile(Application.StartupPath + @"\setting.dat");
                if (settingObj != null)
                {
                    settings = (Dictionary<String, String>)settingObj;
                    injectSettingsToControls(this);
                }

                refreshRunButtonStatus();
            }
        }

        private void txtInsertDataTpl_TextChanged(object sender, EventArgs e)
        {
            rtbInsertDataTpl.Text = CommonUtils.readTextFile(txtInsertDataTpl.Text);
            CommonUtils.setRichTextBoxTextColor(rtbInsertDataTpl, txtTagColor.ForeColor);
        }

        private void txtCreateTableTpl_TextChanged(object sender, EventArgs e)
        {
            rtbCreateTableTpl.Text = CommonUtils.readTextFile(txtCreateTableTpl.Text);
            CommonUtils.setRichTextBoxTextColor(rtbCreateTableTpl, txtTagColor.ForeColor);
        }

        private void txtMapperTpl_TextChanged(object sender, EventArgs e)
        {
            rtbMapperTpl.Text = CommonUtils.readTextFile(txtMapperTpl.Text);
            CommonUtils.setRichTextBoxTextColor(rtbMapperTpl, txtTagColor.ForeColor);
        }

        private void txtSqlProviderTpl_TextChanged(object sender, EventArgs e)
        {
            rtbSqlProviderTpl.Text = CommonUtils.readTextFile(txtSqlProviderTpl.Text);
            CommonUtils.setRichTextBoxTextColor(rtbSqlProviderTpl, txtTagColor.ForeColor);
        }

        private void txtEntityTpl_TextChanged(object sender, EventArgs e)
        {
            rtbEntityTpl.Text = CommonUtils.readTextFile(txtEntityTpl.Text);
            CommonUtils.setRichTextBoxTextColor(rtbEntityTpl, txtTagColor.ForeColor);
        }

        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg= new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Color colorChoosed = dlg.Color;
                txtTagColor.ForeColor = colorChoosed;
                CommonUtils.setRichTextBoxTextColor(rtbInsertDataTpl, txtTagColor.ForeColor);
                CommonUtils.setRichTextBoxTextColor(rtbCreateTableTpl, txtTagColor.ForeColor);
                CommonUtils.setRichTextBoxTextColor(rtbMapperTpl, txtTagColor.ForeColor);
                CommonUtils.setRichTextBoxTextColor(rtbSqlProviderTpl, txtTagColor.ForeColor);
                CommonUtils.setRichTextBoxTextColor(rtbEntityTpl, txtTagColor.ForeColor);
            }
        }
    }
}
