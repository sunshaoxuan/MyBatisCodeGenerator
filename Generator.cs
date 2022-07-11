﻿using MyBatisCodeGenerator.Generator;
using MyBatisCodeGenerator.Utils;
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
        enum RunStatusEnum
        {
            Running, Stopped
        }

        Dictionary<String, String> settings = new Dictionary<string, string>();
        RunStatusEnum runStatus = RunStatusEnum.Stopped;
        
        public frmMain()
        {
            InitializeComponent();
        }

        bool initialized = false;

        private void btnDesignFileBrowse_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Filter = "Excel Files | *.xls;*.xlsx";
            DialogResult result = dlgOpenFile.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtDesignFile.Text = dlgOpenFile.FileName;
            }

            refreshControlStatus();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklTemplate.Items.Count; i++)
            {
                chklTemplate.SetItemChecked(i, true);
            }
            refreshControlStatus();
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklTemplate.Items.Count; i++)
            {
                chklTemplate.SetItemChecked(i, false);
            }
            refreshControlStatus();
        }

        private void btnSelectReverse_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklTemplate.Items.Count; i++)
            {
                chklTemplate.SetItemChecked(i, chklTemplate.GetItemChecked(i) ? false : true);
            }
            refreshControlStatus();
        }

        private void btnSourceCodeRoot_Click(object sender, EventArgs e)
        {
            DialogResult result = dlgFolderBrowser.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtSourceCodeRoot.Text = dlgFolderBrowser.SelectedPath;
            }
            refreshControlStatus();
        }

        private void btnScriptSavePath_Click(object sender, EventArgs e)
        {
            DialogResult result = dlgFolderBrowser.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtScriptSavePath.Text = dlgFolderBrowser.SelectedPath;
            }
            refreshControlStatus();
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

        private void refreshControlStatus()
        {
            if (chklTemplate.CheckedItems.Count == 0)
            {
                lblUsedTemplate.ForeColor = Color.Red;
            }
            else
            {
                lblUsedTemplate.ForeColor = Color.Black;
            }

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
            refreshControlStatus();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            runStatus = RunStatusEnum.Running;

            tstrsStatus.Text = "Generate Processing ...";
            disableAllOnRunning();
            dtgStepLog.Rows.Clear();

            tstrpProgress.Visible = true;
            btnStop.Enabled = true;

            Application.DoEvents();

            try
            {
                generate();
            }
            catch (Exception ex)
            {
                CommonUtils.log(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }

            stopGenerate(true);

            MessageBox.Show(tstrsStatus.Text, "Information", MessageBoxButtons.OK);
            tstrsStatus.Text = "";

            tstrpProgress.Visible = false;
        }

        List<String> preparedDefineTables = new List<string>();
        List<String> preparedDataTables = new List<string>();

        private void generate()
        {
            int stepCount = 0;
            int finishedCount = 0;
            tstrpProgress.Value = 0;

            if (runStatus.Equals(RunStatusEnum.Stopped))
            {
                return;
            }

            //Load Design File
            tstrsStatus.Text = "Loading design file ...";
            stepCount++;
            Dictionary<string, DataTable> excelTables = ExcelUtils.GetExcelTableByOleDB(txtDesignFile.Text);
            finishedCount++;

            if (runStatus.Equals(RunStatusEnum.Stopped))
            {
                return;
            }

            //Check Design File
            tstrsStatus.Text = "Checking design file ...";
            stepCount++;
            getPreparedTables(excelTables);
            stepCount += preparedDefineTables.Count * 9;
            stepCount += preparedDataTables.Count * 4;
            finishedCount++;

            if (runStatus.Equals(RunStatusEnum.Stopped))
            {
                return;
            }

            tstrpProgress.Value = 100 * finishedCount / stepCount;

            //Check Templates
            tstrsStatus.Text = "Checking templates ...";
            stepCount++;
            checkTemplates();
            finishedCount++;

            if (runStatus.Equals(RunStatusEnum.Stopped))
            {
                return;
            }

            tstrpProgress.Value = 100 * finishedCount / stepCount;

            //Execute Task List
            foreach (KeyValuePair<string, DataTable> kv in excelTables)
            {
                if (runStatus.Equals(RunStatusEnum.Stopped))
                {
                    return;
                }

                string taskName = kv.Key.Trim().Replace("$", "");
                tstrsStatus.Text = "Dealing " + taskName + " ...";
                int rowNoAdded = dtgStepLog.Rows.Add("Dealing:" + taskName);
                dtgStepLog.Rows[rowNoAdded].Cells[1].Value = "Dealing: " + taskName;
                dtgStepLog.Rows[rowNoAdded].Cells[1].Style.Font = new Font(dtgStepLog.Font, FontStyle.Bold);
                ((DataGridViewImageCell)dtgStepLog.Rows[rowNoAdded].Cells[0]).Value = imgList.Images["running.gif"];
                dtgStepLog.Refresh();

                if (preparedDefineTables.Contains(kv.Key))
                {
                    if (runStatus.Equals(RunStatusEnum.Stopped))
                    {
                        return;
                    }

                    //Entity
                    if (chklTemplate.GetItemChecked(((int)TemplateUtils.TemplateTypeEnum.Entity)))
                    {
                        doGenerate(kv.Value, rtbEntityTpl.Text, TemplateUtils.TemplateTypeEnum.Entity);
                    }

                    finishedCount++;
                    tstrpProgress.Value = 100 * finishedCount / stepCount;

                    if (runStatus.Equals(RunStatusEnum.Stopped))
                    {
                        return;
                    }
                    //SqlProvider
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.SqlProvider))
                    {
                        doGenerate(kv.Value, rtbSqlProviderTpl.Text, TemplateUtils.TemplateTypeEnum.SqlProvider);
                    }

                    finishedCount++;
                    tstrpProgress.Value = 100 * finishedCount / stepCount;

                    if (runStatus.Equals(RunStatusEnum.Stopped))
                    {
                        return;
                    }
                    //Mapper
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.Mapper))
                    {
                        doGenerate(kv.Value, rtbMapperTpl.Text, TemplateUtils.TemplateTypeEnum.Mapper);
                    }

                    finishedCount++;
                    tstrpProgress.Value = 100 * finishedCount / stepCount;

                    //MapperExtends
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.MapperExtend))
                    {
                        doGenerate(kv.Value, rtbMapperExtendTpl.Text, TemplateUtils.TemplateTypeEnum.MapperExtend);
                    }

                    finishedCount++;
                    tstrpProgress.Value = 100 * finishedCount / stepCount;

                    //VO
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.VO))
                    {
                        doGenerate(kv.Value, rtbVOTpl.Text, TemplateUtils.TemplateTypeEnum.VO);
                    }

                    finishedCount++;
                    tstrpProgress.Value = 100 * finishedCount / stepCount;

                    //MultiLanguage
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.MultiLanguage))
                    {
                        //Entity
                        if (chklTemplate.GetItemChecked(((int)TemplateUtils.TemplateTypeEnum.Entity)))
                        {
                            doGenerate(kv.Value, rtbMultiLangEntity.Text, TemplateUtils.TemplateTypeEnum.MultiLangEntity);
                        }
                        finishedCount++;
                        tstrpProgress.Value = 100 * finishedCount / stepCount;

                        //Mapper
                        if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.Mapper))
                        {
                            doGenerate(kv.Value, rtbMultiLangMapper.Text, TemplateUtils.TemplateTypeEnum.MultiLangMapper);
                        }
                        finishedCount++;
                        tstrpProgress.Value = 100 * finishedCount / stepCount;

                        //MapperExtends
                        if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.MapperExtend))
                        {
                            doGenerate(kv.Value, rtbMultiLangMapperExtend.Text, TemplateUtils.TemplateTypeEnum.MultiLangMapperExtend);
                        }
                        finishedCount++;
                        tstrpProgress.Value = 100 * finishedCount / stepCount;

                        //SqlProvider
                        if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.SqlProvider))
                        {
                            doGenerate(kv.Value, rtbMultiLangSqlProvider.Text, TemplateUtils.TemplateTypeEnum.MultiLangSqlProvider);
                        }
                        finishedCount++;
                        tstrpProgress.Value = 100 * finishedCount / stepCount;
                    }
                }

                if (preparedDataTables.Contains(kv.Key))
                {
                    if (runStatus.Equals(RunStatusEnum.Stopped))
                    {
                        return;
                    }
                    //Create Table
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.CreateTable))
                    {
                        doGenerate(kv.Value, rtbCreateTableTpl.Text, TemplateUtils.TemplateTypeEnum.CreateTable);
                    }

                    finishedCount++;
                    tstrpProgress.Value = 100 * finishedCount / stepCount;

                    if (runStatus.Equals(RunStatusEnum.Stopped))
                    {
                        return;
                    }
                    //Insert Data
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.InsertData))
                    {
                        doGenerate(kv.Value, rtbInsertDataTpl.Text, TemplateUtils.TemplateTypeEnum.InsertData);
                    }

                    finishedCount++;
                    tstrpProgress.Value = 100 * finishedCount / stepCount;

                    //MultiLanguage
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.MultiLanguage))
                    {
                        //Create Table
                        if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.CreateTable))
                        {
                            doGenerate(kv.Value, rtbMultiLangCreateTable.Text, TemplateUtils.TemplateTypeEnum.MultiLangCreateTable);
                        }
                        finishedCount++;
                        tstrpProgress.Value = 100 * finishedCount / stepCount;

                        //Insert Data
                        if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.InsertData))
                        {
                            doGenerate(kv.Value, rtbMultiLangInsertData.Text, TemplateUtils.TemplateTypeEnum.MultiLangInsertData);
                        }
                        finishedCount++;
                        tstrpProgress.Value = 100 * finishedCount / stepCount;
                    }
                }

                dtgStepLog.Rows[rowNoAdded].Cells[1].Value = kv.Key + " dealed.";
                ((DataGridViewImageCell)dtgStepLog.Rows[rowNoAdded].Cells[0]).Value = imgList.Images["success.gif"];
                dtgStepLog.Refresh();
                Application.DoEvents();
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
                tstrsStatus.Text = "Generating is interrupted.";
            }
            else
            {
                tstrsStatus.Text = "Generating finished."; 
            }

            runStatus = RunStatusEnum.Stopped;
            btnRun.Enabled = true;
            enableAllOnStop();
        }

        private void doGenerate(DataTable table, string templateText, TemplateUtils.TemplateTypeEnum tmpType)
        {
            int newTaskRowNo = dtgStepLog.Rows.Add("Generating: [" + tmpType.ToString() + "]");

            try
            {
                ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Value = imgList.Images["running.gif"];
                dtgStepLog.Rows[newTaskRowNo].Cells[1].Value = "  Generating: [" + tmpType.ToString() + "]";
                CommonUtils.log(dtgStepLog.Rows[newTaskRowNo].Cells[1].Value.ToString().Trim());
                dtgStepLog.Refresh();
            }
            catch (Exception ex)
            {
                CommonUtils.log(ex.Message);
            }

            try
            {
                string savedFileName = translateTemplate(table, templateText, tmpType);

                if (string.IsNullOrEmpty(savedFileName))
                {
                    dtgStepLog.Rows[newTaskRowNo].Cells[1].Value = "  No [" + tmpType.ToString() + "] file Generated.";
                    ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Value = imgList.Images["warning.gif"];
                    dtgStepLog.Refresh();
                }
                else
                {
                    dtgStepLog.Rows[newTaskRowNo].Cells[1].Value = "  File [" + savedFileName + "] generated.";
                    ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Value = imgList.Images["success.gif"];
                    dtgStepLog.Refresh();
                }
            }
            catch (Exception ex)
            {
                CommonUtils.log(ex.StackTrace);

                dtgStepLog.Rows[newTaskRowNo].Cells[1].Value = "  Error on generating "+tmpType.ToString()+" file:" + ex.Message;
                ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Style.ForeColor = Color.Red;
                ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Value = imgList.Images["error.gif"];

                if (chkStopOnError.Checked)
                {
                    stopGenerate(true);
                }

                dtgStepLog.Refresh();
            }
        }

        private string translateTemplate(DataTable table, string templateText, TemplateUtils.TemplateTypeEnum templateType)
        {
            AbstractGenerator generator = GeneratorFactory.createGenerator(templateType);

            if(generator == null)
            {
                throw new Exception("No generator defined.");
            }

            try
            {
                Dictionary<String, String> defRefs = new Dictionary<string, string>();
                defRefs.Add("ENTITYNAMESPACE", txtEntityNS.Text);
                defRefs.Add("MAPPERNAMESPACE", txtMapperNS.Text);
                defRefs.Add("SQLPROVIDERNAMESPACE", txtProviderNS.Text);
                defRefs.Add("MULTILANGBASECLASS", txtMultiLangEntityClass.Text);
                defRefs.Add("VONAMESPACE", txtVONS.Text);

                generator.author = chkGenerateAuthor.Checked ? txtAuthor.Text : "";
                generator.isCreatePath = chkCreatePath.Checked;
                generator.isOverwriteExists = chkOverwrite.Checked;
                generator.baseSourcePath = txtSourceCodeRoot.Text;
                generator.baseScriptPath = txtScriptSavePath.Text;
                generator.isVO = templateType.Equals(TemplateUtils.TemplateTypeEnum.VO);
                generator.dataTable = table;
                generator.defRefs = defRefs;
                string savedFilename = generator.run(templateText);
                Application.DoEvents();
                return savedFilename;
            }catch(Exception ex)
            {
                if (ex.Message.Contains("No file"))
                {
                    return "";
                }
                else
                {
                    throw ex;
                }
            }
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
            refreshControlStatus();
        }

        private void chklTemplate_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            refreshControlStatus();
        }

        private void chklTemplate_SelectedValueChanged_1(object sender, EventArgs e)
        {
            refreshControlStatus();
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
            if (!initialized)
            {
                if (File.Exists(Application.StartupPath + @"\setting.dat"))
                {
                    Object settingObj = CommonUtils.readSerializationDataFromFile(Application.StartupPath + @"\setting.dat");
                    if (settingObj != null)
                    {
                        settings = (Dictionary<String, String>)settingObj;
                        injectSettingsToControls(this);
                    }

                    refreshControlStatus();
                }

                initialized = true;
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
                CommonUtils.setRichTextBoxTextColor(rtbMapperExtendTpl, txtTagColor.ForeColor);
                CommonUtils.setRichTextBoxTextColor(rtbMultiLangEntity, txtTagColor.ForeColor);
                CommonUtils.setRichTextBoxTextColor(rtbMultiLangSqlProvider, txtTagColor.ForeColor);
                CommonUtils.setRichTextBoxTextColor(rtbMultiLangMapper, txtTagColor.ForeColor);
                CommonUtils.setRichTextBoxTextColor(rtbMultiLangMapperExtend, txtTagColor.ForeColor);
                CommonUtils.setRichTextBoxTextColor(rtbMultiLangCreateTable, txtTagColor.ForeColor);
                CommonUtils.setRichTextBoxTextColor(rtbMultiLangInsertData, txtTagColor.ForeColor);
                CommonUtils.setRichTextBoxTextColor(rtbVOTpl, txtTagColor.ForeColor);
            }
        }

        private void txtDesignFile_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDesignFile.Text))
            {
                lblDesignFile.ForeColor = Color.Red;
            }
            else
            {
                lblDesignFile.ForeColor = Color.Black;
            }
        }

        private void txtSourceCodeRoot_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSourceCodeRoot.Text))
            {
                lblSourceRoot.ForeColor = Color.Red;
            }
            else
            {
                lblSourceRoot.ForeColor = Color.Black;
            }
        }

        private void txtScriptSavePath_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtScriptSavePath.Text))
            {
                lblScriptSavePath.ForeColor = Color.Red;
            }
            else
            {
                lblScriptSavePath.ForeColor = Color.Black;
            }
        }

        private void dtgStepLog_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dtgStepLog.FirstDisplayedScrollingRowIndex = e.RowIndex;
            }
        }

        private void btnMapperExtendTpl_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Filter = "Template File | *.Tpl";
            dlgOpenFile.FileName = "MapperExtend.Tpl";
            DialogResult result = dlgOpenFile.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtMapperExtendTpl.Text = dlgOpenFile.FileName;
            }
        }

        private void txtMapperExtendTpl_TextChanged(object sender, EventArgs e)
        {
            rtbMapperExtendTpl.Text = CommonUtils.readTextFile(txtMapperExtendTpl.Text);
            CommonUtils.setRichTextBoxTextColor(rtbMapperExtendTpl, txtTagColor.ForeColor);
        }

        private void btnMultiLang_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Filter = "Template File | *.Tpl";
            dlgOpenFile.FileName = "MultiLangEntity.Tpl";
            DialogResult result = dlgOpenFile.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtMultiLangEntity.Text = dlgOpenFile.FileName;
            }
        }

        private void txtMultiLang_TextChanged(object sender, EventArgs e)
        {
            rtbMultiLangEntity.Text = CommonUtils.readTextFile(txtMultiLangEntity.Text);
            CommonUtils.setRichTextBoxTextColor(rtbMultiLangEntity, txtTagColor.ForeColor);
        }

        private void btnMultiLangSqlProvider_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Filter = "Template File | *.Tpl";
            dlgOpenFile.FileName = "MultiLangSqlProvider.Tpl";
            DialogResult result = dlgOpenFile.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtMultiLangSqlProvider.Text = dlgOpenFile.FileName;
            }
        }

        private void txtMultiLangSqlProvider_TextChanged(object sender, EventArgs e)
        {
            rtbMultiLangSqlProvider.Text = CommonUtils.readTextFile(txtMultiLangSqlProvider.Text);
            CommonUtils.setRichTextBoxTextColor(rtbMultiLangSqlProvider, txtTagColor.ForeColor);
        }

        private void btnMultiLangMapper_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Filter = "Template File | *.Tpl";
            dlgOpenFile.FileName = "MultiLangMapper.Tpl";
            DialogResult result = dlgOpenFile.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtMultiLangMapper.Text = dlgOpenFile.FileName;
            }
        }

        private void txtMultiLangMapper_TextChanged(object sender, EventArgs e)
        {
            rtbMultiLangMapper.Text = CommonUtils.readTextFile(txtMultiLangMapper.Text);
            CommonUtils.setRichTextBoxTextColor(rtbMultiLangMapper, txtTagColor.ForeColor);
        }

        private void txtMultiLangMapperExtend_TextChanged(object sender, EventArgs e)
        {
            rtbMultiLangMapperExtend.Text = CommonUtils.readTextFile(txtMultiLangMapperExtend.Text);
            CommonUtils.setRichTextBoxTextColor(rtbMultiLangMapperExtend, txtTagColor.ForeColor);
        }

        private void btnMultiLangMapperExtend_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Filter = "Template File | *.Tpl";
            dlgOpenFile.FileName = "MultiLangMapperExtend.Tpl";
            DialogResult result = dlgOpenFile.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtMultiLangMapperExtend.Text = dlgOpenFile.FileName;
            }
        }

        private void txtMultiLangCreateTable_TextChanged(object sender, EventArgs e)
        {
            rtbMultiLangCreateTable.Text = CommonUtils.readTextFile(txtMultiLangCreateTable.Text);
            CommonUtils.setRichTextBoxTextColor(rtbMultiLangCreateTable, txtTagColor.ForeColor);
        }

        private void btnMultiLangCreateTable_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Filter = "Template File | *.Tpl";
            dlgOpenFile.FileName = "MultiLangCreateTable.Tpl";
            DialogResult result = dlgOpenFile.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtMultiLangCreateTable.Text = dlgOpenFile.FileName;
            }
        }

        private void txtMultiLangInsertData_TextChanged(object sender, EventArgs e)
        {
            rtbMultiLangInsertData.Text = CommonUtils.readTextFile(txtMultiLangInsertData.Text);
            CommonUtils.setRichTextBoxTextColor(rtbMultiLangInsertData, txtTagColor.ForeColor);
        }

        private void btnMultiLangInsertData_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Filter = "Template File | *.Tpl";
            dlgOpenFile.FileName = "MultiLangInsertData.Tpl";
            DialogResult result = dlgOpenFile.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtMultiLangInsertData.Text = dlgOpenFile.FileName;
            }
        }

        private void txtVO_TextChanged(object sender, EventArgs e)
        {
            rtbVOTpl.Text = CommonUtils.readTextFile(txtVO.Text);
            CommonUtils.setRichTextBoxTextColor(rtbVOTpl, txtTagColor.ForeColor);
        }

        private void btnVO_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Filter = "Template File | *.Tpl";
            dlgOpenFile.FileName = "VO.Tpl";
            DialogResult result = dlgOpenFile.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtVO.Text = dlgOpenFile.FileName;
            }
        }
    }
}
