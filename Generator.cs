using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MyBatisCodeGenerator
{
    public partial class frmMain : Form
    {
        enum RunStatus
        {
            Running, Pause, Stopped
        }

        Dictionary<String, String> settings = new Dictionary<string, string>();

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
            btnPause.Enabled = false;
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
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            refreshRunButtonStatus();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            disableAllOnRunning();

            tstrpProgress.Visible = true;
            btnPause.Enabled = true;
            btnStop.Enabled = true;

            try
            {
                generate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            tstrpProgress.Visible = false;
        }

        List<String> preparedDefineTables = new List<string>();
        List<String> preparedDataTables = new List<string>();

        private void generate()
        {
            int stepCount = 0;
            int finishedCount = 0;
            tstrpProgress.Value = 0;

            //Load Design File
            stepCount++;
            Dictionary<string, DataTable> excelTables = ExcelUtils.GetExcelTableByOleDB(txtDesignFile.Text);
            finishedCount++;

            //Check Design File
            stepCount++;
            getPreparedTables(excelTables);
            stepCount += preparedDefineTables.Count;
            stepCount += preparedDataTables.Count;
            finishedCount++;

            tstrpProgress.Value = 100 * finishedCount / stepCount;

            //Check Tamplates
            stepCount++;
            checkTemplates();
            finishedCount++;

            tstrpProgress.Value = 100 * finishedCount / stepCount;

            //Execute Task List
            foreach (KeyValuePair<string, DataTable> kv in excelTables)
            {
                int rowNoAdded = dtgStepLog.Rows.Add("Dealing:" + kv.Key);
                dtgStepLog.Rows[rowNoAdded].Cells[1].Value = "Dealing: " + kv.Key;
                ((DataGridViewImageCell)dtgStepLog.Rows[rowNoAdded].Cells[0]).Value = imgList.Images["running.gif"];
                dtgStepLog.Refresh();

                if (preparedDefineTables.Contains(kv.Key))
                {
                    //Entity
                    if (chklTemplate.GetItemChecked(0)) {
                        doGenerate(kv.Value, rtbEntityTpl.Text, "Entity");
                    }

                    //SqlProvider
                    if (chklTemplate.GetItemChecked(1))
                    {
                        doGenerate(kv.Value, rtbSqlProviderTpl.Text, "SqlProvider");
                    }

                    //Mapper
                    if (chklTemplate.GetItemChecked(2))
                    {
                        doGenerate(kv.Value, rtbMapperTpl.Text, "Mapper");
                    }

                    finishedCount++;
                    tstrpProgress.Value = 100 * finishedCount / stepCount;
                }

                if (preparedDataTables.Contains(kv.Key))
                {
                    //Create Table
                    if (chklTemplate.GetItemChecked(3))
                    {
                        doGenerate(kv.Value, rtbEntityTpl.Text, "Create Table");
                    }

                    //Insert Data
                    if (chklTemplate.GetItemChecked(4))
                    {
                        doGenerate(kv.Value, rtbEntityTpl.Text, "Insert Data");
                    }

                    finishedCount++;
                    tstrpProgress.Value = 100 * finishedCount / stepCount;
                }

                dtgStepLog.Rows[rowNoAdded].Cells[1].Value = kv.Key + " dealed.";
                ((DataGridViewImageCell)dtgStepLog.Rows[rowNoAdded].Cells[0]).Value = imgList.Images["success.gif"];
                dtgStepLog.Refresh();
            }
        }

        private void doGenerate(DataTable table, string templateText, string tag)
        {
            int newTaskRowNo = dtgStepLog.Rows.Add("Generating: [" + tag + "]");
            dtgStepLog.Rows[newTaskRowNo].Cells[1].Value = "Generating: [" + tag + "]";

            ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Value = imgList.Images["running.gif"];
            dtgStepLog.Refresh();
            try
            {
                string warningMessage = translateTemplate(table, templateText);

                if (string.IsNullOrEmpty(warningMessage))
                {
                    dtgStepLog.Rows[newTaskRowNo].Cells[1].Value = "[" + tag + "] Generated.";
                    ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Value = imgList.Images["success.gif"];
                    dtgStepLog.Refresh();
                }
                else
                {
                    dtgStepLog.Rows[newTaskRowNo].Cells[1].Value = "Warning:" + warningMessage;
                    ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Value = imgList.Images["warning.gif"];
                    dtgStepLog.Refresh();
                }
            }
            catch (Exception ex)
            {
                dtgStepLog.Rows[newTaskRowNo].Cells[1].Value = "Error:" + ex.Message;
                ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Value = imgList.Images["error.gif"];
                dtgStepLog.Refresh();
            }
        }

        private string translateTemplate(DataTable table, string templateText)
        {
            Thread.Sleep(3000);
            return string.Empty;
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

                        if (row[0].ToString().ToUpper().Contains("$MYBATIS META DATA START$"))
                        {
                            bDataBegin = true;
                            continue;
                        }

                        if (row[0].ToString().ToUpper().Contains("$MYBATIS META DATA END$"))
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
            btnRun.Enabled = true;
            btnPause.Enabled = false;
            tstrpProgress.Visible = false;
            enableAllOnStop();
        }

        private void chklTemplate_SelectedValueChanged(object sender, EventArgs e)
        {
            refreshRunButtonStatus();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            btnPause.Text = "Continue (&C)";
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
                Object settingObj = CommonUtils.readSerialzationDataFromFile(Application.StartupPath + @"\setting.dat");
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
            CommonUtils.setRichTextBoxTextColor(rtbInsertDataTpl);
        }

        private void txtCreateTableTpl_TextChanged(object sender, EventArgs e)
        {
            rtbCreateTableTpl.Text = CommonUtils.readTextFile(txtCreateTableTpl.Text);
            CommonUtils.setRichTextBoxTextColor(rtbCreateTableTpl);
        }

        private void txtMapperTpl_TextChanged(object sender, EventArgs e)
        {
            rtbMapperTpl.Text = CommonUtils.readTextFile(txtMapperTpl.Text);
            CommonUtils.setRichTextBoxTextColor(rtbMapperTpl);
        }

        private void txtSqlProviderTpl_TextChanged(object sender, EventArgs e)
        {
            rtbSqlProviderTpl.Text = CommonUtils.readTextFile(txtSqlProviderTpl.Text);
            CommonUtils.setRichTextBoxTextColor(rtbSqlProviderTpl);
        }

        private void txtEntityTpl_TextChanged(object sender, EventArgs e)
        {
            rtbEntityTpl.Text = CommonUtils.readTextFile(txtEntityTpl.Text);
            CommonUtils.setRichTextBoxTextColor(rtbEntityTpl);
        }
    }
}
