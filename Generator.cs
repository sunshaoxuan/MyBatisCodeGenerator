﻿using MyBatisCodeGenerator.Generator;
using MyBatisCodeGenerator.Transformer;
using MyBatisCodeGenerator.Utils;
using MySql.Data.MySqlClient;
using MySqlConnector;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MySqlConnection = MySqlConnector.MySqlConnection;

namespace MyBatisCodeGenerator
{
    public partial class frmMain : Form
    {
        enum RunStatusEnum
        {
            Running, Stopped
        }

        Dictionary<string, DataTable> excelReadData = null;
        bool isReading = false;
        RunStatusEnum runStatus = RunStatusEnum.Stopped;
        string currentSettingFileName = String.Empty;
        bool SettingLoaded = false;
        bool SettingSaved = true;


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
                SettingSaved = false;
            }

            RefreshControlStatus();

            tsbRefreshDesign_Click(sender, e);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklTemplate.Items.Count; i++)
            {
                chklTemplate.SetItemChecked(i, true);
            }

            SettingSaved = false;
            RefreshControlStatus();
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklTemplate.Items.Count; i++)
            {
                chklTemplate.SetItemChecked(i, false);
            }

            SettingSaved = false;
            RefreshControlStatus();
        }

        private void btnSelectReverse_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklTemplate.Items.Count; i++)
            {
                chklTemplate.SetItemChecked(i, chklTemplate.GetItemChecked(i) ? false : true);
            }

            SettingSaved = false;
            RefreshControlStatus();
        }

        private void btnSourceCodeRoot_Click(object sender, EventArgs e)
        {
            DialogResult result = dlgFolderBrowser.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtSourceCodeRoot.Text = dlgFolderBrowser.SelectedPath;
                SettingSaved = false;
            }

            RefreshControlStatus();
        }

        private void btnScriptSavePath_Click(object sender, EventArgs e)
        {
            DialogResult result = dlgFolderBrowser.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                txtScriptSavePath.Text = dlgFolderBrowser.SelectedPath;
                SettingSaved = false;
            }
            RefreshControlStatus();
        }

        private void LoadTemplate(string fileName, TextBox fileNameCtrl)
        {
            dlgOpenFile.Filter = "Template File | *.Tpl";
            dlgOpenFile.InitialDirectory = String.IsNullOrEmpty(dlgOpenFile.FileName) ? Application.StartupPath : Directory.GetParent(dlgOpenFile.FileName).ToString();
            dlgOpenFile.FileName = fileName;
            DialogResult result = dlgOpenFile.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                fileNameCtrl.Text = dlgOpenFile.FileName;
                SettingSaved = false;
                RefreshControlStatus();
            }
        }

        private void btnEntityTpl_Click(object sender, EventArgs e)
        {
            LoadTemplate("Entity.Tpl", txtEntityTpl);
        }

        private void btnEntityExtendTpl_Click(object sender, EventArgs e)
        {
            LoadTemplate("SqlProvider.Tpl", txtSqlProviderTpl);
        }

        private void btnMapperTpl_Click(object sender, EventArgs e)
        {
            LoadTemplate("Mapper.Tpl", txtMapperTpl);
        }

        private void btnCreateTableTpl_Click(object sender, EventArgs e)
        {
            LoadTemplate("CreateTable.Tpl", txtCreateTableTpl);
        }

        private void btnInsertDataTpl_Click(object sender, EventArgs e)
        {
            LoadTemplate("InsertData.Tpl", txtInsertDataTpl);
        }

        private void RefreshControlStatus()
        {
            if (String.IsNullOrEmpty(currentSettingFileName))
            {
                this.Text = "Mybatis Code Generator";
            }
            else
            {
                this.Text = "Mybatis Code Generator" + " [" + currentSettingFileName + "]";
            }

            if (chklTemplate.CheckedItems.Count == 0)
            {
                lblUsedTemplate.ForeColor = Color.Red;
            }
            else
            {
                lblUsedTemplate.ForeColor = Color.Black;
            }

            if (SettingSaved)
            {
                tsbSave.Enabled = false;
            }
            else
            {
                tsbSave.Enabled = true;
            }

            if (!SettingLoaded && !tsbRun.Enabled)
            {
                tsbRefreshDesign.Enabled = false;
                tsbRefreshTemplate.Enabled = false;
                tsbPublish.Enabled = false;
            }
            else
            {
                tsbRefreshDesign.Enabled = true;
                tsbRefreshTemplate.Enabled = true;
                tsbPublish.Enabled = true;
            }

            tsbStop.Enabled = false;

            if (string.IsNullOrEmpty(txtDesignFile.Text))
            {
                tsbRun.Enabled = false;
                return;
            }

            if (chklTemplate.CheckedItems.Count == 0)
            {
                tsbRun.Enabled = false;
                return;
            }

            if (string.IsNullOrEmpty(txtSourceCodeRoot.Text) && string.IsNullOrEmpty(txtScriptSavePath.Text))
            {
                tsbRun.Enabled = false;
                return;
            }

            tsbRun.Enabled = true;
        }

        private void DisableAllOnRunning()
        {
            tsbRun.Enabled = false;
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

            tsbRefreshTemplate.Enabled = false;
        }

        private void EnableAllOnStop()
        {
            tsbRun.Enabled = true;
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
            chkCreatePath.Enabled = true;
            chkStopOnError.Enabled = true;

            tsbRefreshTemplate.Enabled = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            RefreshControlStatus();
        }


        List<string> preparedDefineTables = new List<string>();
        List<string> preparedDataTables = new List<string>();

        internal SortedList<int, AbstractTransformer> GetDefinedTransformer()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();

            SortedList<int, AbstractTransformer> defaultTransformers = new SortedList<int, AbstractTransformer>();
            foreach (Type type in types)
            {
                if (type.BaseType.Equals(typeof(AbstractTransformer)))
                {
                    AbstractTransformer transformer = (AbstractTransformer)System.Activator.CreateInstance(type);
                    if (defaultTransformers.ContainsKey(transformer.GetOrder()))
                    {
                        throw new Exception("Transformer order [" + transformer.GetOrder() + "] has been exists.");
                    }
                    else
                    {
                        defaultTransformers.Add(transformer.GetOrder(), transformer);
                    }
                }
            }
            return defaultTransformers;
        }

        private void Generate()
        {
            tstrpProgress.Value = 0;

            if (runStatus.Equals(RunStatusEnum.Stopped))
            {
                return;
            }

            //Load Design File
            tstrsStatus.Text = "Loading design file ...";
            Dictionary<string, DataTable> excelTables = null;
            int sleepTime = 0;
            while (excelTables == null && sleepTime < 5)
            {
                excelTables = getExcelData();

                if (excelTables == null)
                {
                    Thread.Sleep(3000);
                    sleepTime++;
                }
            }

            if (excelTables == null && sleepTime >= 5)
            {
                throw new Exception("Reading faild.");
            }

            //int stepCount = GetStepCount(excelTables);

            if (runStatus.Equals(RunStatusEnum.Stopped))
            {
                return;
            }

            //Check Design File
            tstrsStatus.Text = "Checking design file ...";
            getPreparedTables(excelTables);


            if (runStatus.Equals(RunStatusEnum.Stopped))
            {
                return;
            }



            //Check Templates
            tstrsStatus.Text = "Checking templates ...";
            checkTemplates();


            if (runStatus.Equals(RunStatusEnum.Stopped))
            {
                return;
            }



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
                        DoGenerate(excelTables, kv.Value, rtbEntityTpl.Text, TemplateUtils.TemplateTypeEnum.Entity);
                    }

                    if (runStatus.Equals(RunStatusEnum.Stopped))
                    {
                        return;
                    }
                    //SqlProvider
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.SqlProvider))
                    {
                        DoGenerate(excelTables, kv.Value, rtbSqlProviderTpl.Text, TemplateUtils.TemplateTypeEnum.SqlProvider);
                    }

                    if (runStatus.Equals(RunStatusEnum.Stopped))
                    {
                        return;
                    }
                    //Mapper
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.Mapper))
                    {
                        DoGenerate(excelTables, kv.Value, rtbMapperTpl.Text, TemplateUtils.TemplateTypeEnum.Mapper);
                    }

                    if (runStatus.Equals(RunStatusEnum.Stopped))
                    {
                        return;
                    }

                    //MapperExtends
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.MapperExtend))
                    {
                        DoGenerate(excelTables, kv.Value, rtbMapperExtendTpl.Text, TemplateUtils.TemplateTypeEnum.MapperExtend);
                    }

                    if (runStatus.Equals(RunStatusEnum.Stopped))
                    {
                        return;
                    }

                    //VO
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.VO))
                    {
                        DoGenerate(excelTables, kv.Value, rtbVOTpl.Text, TemplateUtils.TemplateTypeEnum.VO);
                    }

                    if (runStatus.Equals(RunStatusEnum.Stopped))
                    {
                        return;
                    }

                    //AggVO
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.AggVO))
                    {
                        DoGenerate(excelTables, kv.Value, rtbAggVO.Text, TemplateUtils.TemplateTypeEnum.AggVO);
                    }

                    if (runStatus.Equals(RunStatusEnum.Stopped))
                    {
                        return;
                    }

                    //Rest
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.Rest))
                    {
                        DoGenerate(excelTables, kv.Value, rtbRestTpl.Text, TemplateUtils.TemplateTypeEnum.Rest);
                    }

                    if (runStatus.Equals(RunStatusEnum.Stopped))
                    {
                        return;
                    }

                    //Service
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.Service))
                    {
                        DoGenerate(excelTables, kv.Value, rtbServiceTpl.Text, TemplateUtils.TemplateTypeEnum.Service);
                    }

                    if (runStatus.Equals(RunStatusEnum.Stopped))
                    {
                        return;
                    }

                    //ServiceImpl
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.ServiceImpl))
                    {
                        DoGenerate(excelTables, kv.Value, rtbServiceImplTpl.Text, TemplateUtils.TemplateTypeEnum.ServiceImpl);
                    }

                    if (runStatus.Equals(RunStatusEnum.Stopped))
                    {
                        return;
                    }

                    //Handler
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.Handler))
                    {
                        DoGenerate(excelTables, kv.Value, rtbHandlerTpl.Text, TemplateUtils.TemplateTypeEnum.Handler);
                    }

                    if (runStatus.Equals(RunStatusEnum.Stopped))
                    {
                        return;
                    }

                    //DTO
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.DTO))
                    {
                        DoGenerate(excelTables, kv.Value, rtbDTOTpl.Text, TemplateUtils.TemplateTypeEnum.DTO);
                    }

                    if (runStatus.Equals(RunStatusEnum.Stopped))
                    {
                        return;
                    }

                    //AggDTO
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.AggDTO))
                    {
                        DoGenerate(excelTables, kv.Value, rtbAggVORequestTpl.Text, TemplateUtils.TemplateTypeEnum.AggDTO);
                    }

                    if (runStatus.Equals(RunStatusEnum.Stopped))
                    {
                        return;
                    }

                    //MultiLanguage
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.MultiLanguage))
                    {
                        if (runStatus.Equals(RunStatusEnum.Stopped))
                        {
                            return;
                        }

                        //Entity
                        if (chklTemplate.GetItemChecked(((int)TemplateUtils.TemplateTypeEnum.Entity)))
                        {
                            DoGenerate(excelTables, kv.Value, rtbMultiLangEntity.Text, TemplateUtils.TemplateTypeEnum.MultiLangEntity);
                        }

                        if (runStatus.Equals(RunStatusEnum.Stopped))
                        {
                            return;
                        }

                        //Mapper
                        if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.Mapper))
                        {
                            DoGenerate(excelTables, kv.Value, rtbMultiLangMapper.Text, TemplateUtils.TemplateTypeEnum.MultiLangMapper);
                        }

                        if (runStatus.Equals(RunStatusEnum.Stopped))
                        {
                            return;
                        }

                        //MapperExtends
                        if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.MapperExtend))
                        {
                            DoGenerate(excelTables, kv.Value, rtbMultiLangMapperExtend.Text, TemplateUtils.TemplateTypeEnum.MultiLangMapperExtend);
                        }

                        if (runStatus.Equals(RunStatusEnum.Stopped))
                        {
                            return;
                        }

                        //SqlProvider
                        if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.SqlProvider))
                        {
                            DoGenerate(excelTables, kv.Value, rtbMultiLangSqlProvider.Text, TemplateUtils.TemplateTypeEnum.MultiLangSqlProvider);
                        }
                    }
                }

                if (runStatus.Equals(RunStatusEnum.Stopped))
                {
                    return;
                }

                //Create Table
                if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.CreateTable))
                {
                    DoGenerate(excelTables, kv.Value, rtbCreateTableTpl.Text, TemplateUtils.TemplateTypeEnum.CreateTable);
                }

                if (runStatus.Equals(RunStatusEnum.Stopped))
                {
                    return;
                }
                //MultiLanguage
                if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.MultiLanguage))
                {
                    //Create Table
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.CreateTable))
                    {
                        DoGenerate(excelTables, kv.Value, rtbMultiLangCreateTable.Text, TemplateUtils.TemplateTypeEnum.MultiLangCreateTable);
                    }
                }

                if (preparedDataTables.Contains(kv.Key))
                {
                    if (runStatus.Equals(RunStatusEnum.Stopped))
                    {
                        return;
                    }
                    //Insert Data
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.InsertData))
                    {
                        DoGenerate(excelTables, kv.Value, rtbInsertDataTpl.Text, TemplateUtils.TemplateTypeEnum.InsertData);
                    }

                    if (runStatus.Equals(RunStatusEnum.Stopped))
                    {
                        return;
                    }
                    //MultiLanguage
                    if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.MultiLanguage))
                    {
                        //Insert Data
                        if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.InsertData))
                        {
                            DoGenerate(excelTables, kv.Value, rtbMultiLangInsertData.Text, TemplateUtils.TemplateTypeEnum.MultiLangInsertData);
                        }
                    }
                }

                dtgStepLog.Rows[rowNoAdded].Cells[1].Value = kv.Key + " dealed.";
                ((DataGridViewImageCell)dtgStepLog.Rows[rowNoAdded].Cells[0]).Value = imgList.Images["success.gif"];
                dtgStepLog.Refresh();
                Application.DoEvents();
            }
        }

        private Dictionary<string, DataTable> getExcelData()
        {
            if (excelReadData == null && isReading == false)
            {
                isReading = true;
                Thread t = new Thread(ReadExcel);
                t.Start();
            }

            return excelReadData;
        }

        private void ReadExcel()
        {
            if (!string.IsNullOrEmpty(txtDesignFile.Text))
            {
                excelReadData = ExcelUtils.GetExcelTableByOleDB(txtDesignFile.Text);
                isReading = false;
            }
        }

        private int GetStepCount(Dictionary<string, DataTable> excelTables)
        {
            int StepCount = 0;

            StepCount += 3;

            //Execute Task List
            foreach (KeyValuePair<string, DataTable> kv in excelTables)
            {
                StepCount += 6;
                //MultiLanguage
                if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.MultiLanguage))
                {
                    StepCount += 4;
                }

                StepCount++;
                //MultiLanguage
                if (chklTemplate.GetItemChecked((int)TemplateUtils.TemplateTypeEnum.MultiLanguage))
                {

                    //Create Table
                    StepCount++;
                }

                if (preparedDataTables.Contains(kv.Key))
                {
                    StepCount += 2;
                }
            }

            return StepCount;
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
            tsbRun.Enabled = true;
            EnableAllOnStop();
        }

        private void DoGenerate(Dictionary<string, DataTable> excelData, DataTable table, string templateText, TemplateUtils.TemplateTypeEnum tmpType)
        {
            int newTaskRowNo = dtgStepLog.Rows.Add("Generating: [" + tmpType.ToString() + "]");

            try
            {
                ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Value = imgList.Images["running.gif"];
                dtgStepLog.Rows[newTaskRowNo].Cells[1].Value = "  Generating: [" + tmpType.ToString() + "]";
                CommonUtils.Log(dtgStepLog.Rows[newTaskRowNo].Cells[1].Value.ToString().Trim());
                dtgStepLog.Refresh();
            }
            catch (Exception ex)
            {
                CommonUtils.Log(ex.Message);
            }

            try
            {
                string savedFileName = TranslateTemplate(excelData, table, templateText, tmpType);

                if (string.IsNullOrEmpty(savedFileName))
                {
                    dtgStepLog.Rows[newTaskRowNo].Cells[1].Value = "  No [" + tmpType.ToString() + "] file Generated.";
                    CommonUtils.Log((string)dtgStepLog.Rows[newTaskRowNo].Cells[1].Value);
                    ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Value = imgList.Images["warning.gif"];
                    dtgStepLog.Refresh();
                }
                else
                {
                    dtgStepLog.Rows[newTaskRowNo].Cells[1].Value = "  File [" + savedFileName + "] generated.";
                    CommonUtils.Log((string)dtgStepLog.Rows[newTaskRowNo].Cells[1].Value);
                    ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Value = imgList.Images["success.gif"];
                    dtgStepLog.Refresh();
                }
            }
            catch (Exception ex)
            {
                CommonUtils.Log(ex.StackTrace);

                dtgStepLog.Rows[newTaskRowNo].Cells[1].Value = "  Error on generating " + tmpType.ToString() + " file:" + ex.Message;
                CommonUtils.Log((string)dtgStepLog.Rows[newTaskRowNo].Cells[1].Value);
                ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Style.ForeColor = Color.Red;
                ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Value = imgList.Images["error.gif"];

                if (chkStopOnError.Checked)
                {
                    stopGenerate(true);
                }

                dtgStepLog.Refresh();
            }
        }

        /// <summary>
        /// 多语资源
        /// </summary>
        public Dictionary<string, Dictionary<string, string[]>> MultiLangRefInfo { get; set; }

        private string TranslateTemplate(Dictionary<string, DataTable> excelData, DataTable table, string templateText, TemplateUtils.TemplateTypeEnum templateType)
        {
            AbstractGenerator generator = GeneratorFactory.CreateGenerator(templateType);
            generator.CreateTablePrefix = txtCreateTablePrefix.Text;
            generator.InsertDataPrefix = txtInsertDataPrefix.Text;

            if (generator == null)
            {
                throw new Exception("No generator defined.");
            }

            try
            {
                Dictionary<string, string> defRefs = new Dictionary<string, string>();
                defRefs.Add("CLASSROOT", txtClassRoot.Text);
                defRefs.Add("DATABASENAME", TemplateUtils.getNewConntection(txtDBConnStr.Text).Database);

                generator.Author = chkGenerateAuthor.Checked ? txtAuthor.Text : "";
                generator.IsCreatePath = chkCreatePath.Checked;
                generator.IsOverwriteExists = chkOverwrite.Checked;
                generator.BaseSourcePath = txtSourceCodeRoot.Text;
                generator.BaseScriptPath = txtScriptSavePath.Text;
                generator.IsVO = templateType.Equals(TemplateUtils.TemplateTypeEnum.VO);
                generator.ExcelData = excelData;
                generator.DesignData = table;
                generator.DefRefs = defRefs;
                generator.DefaultTransformers = GetDefinedTransformer();
                string savedFilename = generator.Run(templateText);
                Application.DoEvents();

                if (generator.MultiLangRefInfo != null && generator.MultiLangRefInfo.Count > 0)
                {
                    if (MultiLangRefInfo == null)
                    {
                        MultiLangRefInfo = new Dictionary<string, Dictionary<string, string[]>>();
                    }
                    TemplateUtils.RegisterMultiLangRefInfo(MultiLangRefInfo, generator.MultiLangRefInfo);
                }
                return savedFilename;
            }
            catch (Exception ex)
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
                foreach (KeyValuePair<string, DataTable> kv in excelTables)
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

        private void chklTemplate_SelectedValueChanged(object sender, EventArgs e)
        {
            SettingSaved = false;
            RefreshControlStatus();
        }

        private void chklTemplate_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            SettingSaved = false;
            RefreshControlStatus();
        }

        private void chkGenerateAuthor_CheckedChanged(object sender, EventArgs e)
        {
            lblAuthor.Enabled = chkGenerateAuthor.Checked;
            txtAuthor.Enabled = chkGenerateAuthor.Checked;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = !SettingSaved ? MessageBox.Show("Save settings to file?", "Exit", MessageBoxButtons.YesNoCancel) : DialogResult.No;
            if (result == DialogResult.Yes)
            {
                settings.Clear();
                FetchSettingsFromControls(this);

                if (String.IsNullOrEmpty(currentSettingFileName))
                {
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.Filter = "Setting Files | *.dat";
                    saveFile.FileName = "setting.dat";
                    saveFile.InitialDirectory = Application.StartupPath;
                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        CommonUtils.WriteSerializationDataToFile(saveFile.FileName, settings);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    CommonUtils.WriteSerializationDataToFile(currentSettingFileName, settings);
                }
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        Dictionary<string, string> settings = new Dictionary<string, string>();

        private void FetchSettingsFromControls(Control control)
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

                FetchSettingsFromControls(ctl);
            }
        }

        private void InjectSettingsToControls(Control control, Dictionary<string, string> settings)
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
                            if (new List<string>(settings[ctl.Name].Split(',')).Contains((string)((CheckedListBox)ctl).Items[i]))
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

                InjectSettingsToControls(ctl, settings);
            }
        }

        private void txtInsertDataTpl_TextChanged(object sender, EventArgs e)
        {
            rtbInsertDataTpl.Text = CommonUtils.ReadTextFile(txtInsertDataTpl.Text);
            CommonUtils.SetRichTextBoxTextColor(rtbInsertDataTpl, txtTagColor.ForeColor);

            if (!string.IsNullOrEmpty(txtInsertDataTpl.Text))
            {
                registerRefreshItem(txtInsertDataTpl, rtbInsertDataTpl);
            }
        }

        private void registerRefreshItem(TextBox txtObj, RichTextBox rtbObj)
        {
            if (!freshDic.ContainsKey(txtObj))
            {
                freshDic.Add(txtObj, rtbObj);
            }
        }

        private void txtCreateTableTpl_TextChanged(object sender, EventArgs e)
        {
            rtbCreateTableTpl.Text = CommonUtils.ReadTextFile(txtCreateTableTpl.Text);
            CommonUtils.SetRichTextBoxTextColor(rtbCreateTableTpl, txtTagColor.ForeColor);

            if (!string.IsNullOrEmpty(txtCreateTableTpl.Text))
            {
                registerRefreshItem(txtCreateTableTpl, rtbCreateTableTpl);
            }
        }

        private void txtMapperTpl_TextChanged(object sender, EventArgs e)
        {
            rtbMapperTpl.Text = CommonUtils.ReadTextFile(txtMapperTpl.Text);
            CommonUtils.SetRichTextBoxTextColor(rtbMapperTpl, txtTagColor.ForeColor);

            if (!string.IsNullOrEmpty(txtMapperTpl.Text))
            {
                registerRefreshItem(txtMapperTpl, rtbMapperTpl);
            }
        }

        private void txtSqlProviderTpl_TextChanged(object sender, EventArgs e)
        {
            rtbSqlProviderTpl.Text = CommonUtils.ReadTextFile(txtSqlProviderTpl.Text);
            CommonUtils.SetRichTextBoxTextColor(rtbSqlProviderTpl, txtTagColor.ForeColor);

            if (!string.IsNullOrEmpty(txtSqlProviderTpl.Text))
            {
                registerRefreshItem(txtSqlProviderTpl, rtbSqlProviderTpl);
            }
        }

        private void txtEntityTpl_TextChanged(object sender, EventArgs e)
        {
            rtbEntityTpl.Text = CommonUtils.ReadTextFile(txtEntityTpl.Text);
            CommonUtils.SetRichTextBoxTextColor(rtbEntityTpl, txtTagColor.ForeColor);

            if (!string.IsNullOrEmpty(txtEntityTpl.Text))
            {
                registerRefreshItem(txtEntityTpl, rtbEntityTpl);
            }
        }

        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Color colorChoosed = dlg.Color;
                txtTagColor.ForeColor = colorChoosed;
                CommonUtils.SetRichTextBoxTextColor(rtbInsertDataTpl, txtTagColor.ForeColor);
                CommonUtils.SetRichTextBoxTextColor(rtbCreateTableTpl, txtTagColor.ForeColor);
                CommonUtils.SetRichTextBoxTextColor(rtbMapperTpl, txtTagColor.ForeColor);
                CommonUtils.SetRichTextBoxTextColor(rtbSqlProviderTpl, txtTagColor.ForeColor);
                CommonUtils.SetRichTextBoxTextColor(rtbEntityTpl, txtTagColor.ForeColor);
                CommonUtils.SetRichTextBoxTextColor(rtbMapperExtendTpl, txtTagColor.ForeColor);
                CommonUtils.SetRichTextBoxTextColor(rtbMultiLangEntity, txtTagColor.ForeColor);
                CommonUtils.SetRichTextBoxTextColor(rtbMultiLangSqlProvider, txtTagColor.ForeColor);
                CommonUtils.SetRichTextBoxTextColor(rtbMultiLangMapper, txtTagColor.ForeColor);
                CommonUtils.SetRichTextBoxTextColor(rtbMultiLangMapperExtend, txtTagColor.ForeColor);
                CommonUtils.SetRichTextBoxTextColor(rtbMultiLangCreateTable, txtTagColor.ForeColor);
                CommonUtils.SetRichTextBoxTextColor(rtbMultiLangInsertData, txtTagColor.ForeColor);
                CommonUtils.SetRichTextBoxTextColor(rtbVOTpl, txtTagColor.ForeColor);
                CommonUtils.SetRichTextBoxTextColor(rtbAggVO, txtTagColor.ForeColor);
                CommonUtils.SetRichTextBoxTextColor(rtbRestTpl, txtTagColor.ForeColor);
                CommonUtils.SetRichTextBoxTextColor(rtbServiceTpl, txtTagColor.ForeColor);
                CommonUtils.SetRichTextBoxTextColor(rtbServiceImplTpl, txtTagColor.ForeColor);
                CommonUtils.SetRichTextBoxTextColor(rtbAggVORequestTpl, txtTagColor.ForeColor);
                CommonUtils.SetRichTextBoxTextColor(rtbDTOTpl, txtTagColor.ForeColor);

                SettingSaved = false;
                RefreshControlStatus();
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
            LoadTemplate("MapperExtend.Tpl", txtMapperExtendTpl);
        }

        private void txtMapperExtendTpl_TextChanged(object sender, EventArgs e)
        {
            rtbMapperExtendTpl.Text = CommonUtils.ReadTextFile(txtMapperExtendTpl.Text);
            CommonUtils.SetRichTextBoxTextColor(rtbMapperExtendTpl, txtTagColor.ForeColor);

            if (!string.IsNullOrEmpty(txtMapperExtendTpl.Text))
            {
                registerRefreshItem(txtMapperExtendTpl, rtbMapperExtendTpl);
            }
        }

        private void btnMultiLang_Click(object sender, EventArgs e)
        {
            LoadTemplate("MultiLangEntity.Tpl", txtMultiLangEntity);
        }

        private void txtMultiLang_TextChanged(object sender, EventArgs e)
        {
            rtbMultiLangEntity.Text = CommonUtils.ReadTextFile(txtMultiLangEntity.Text);
            CommonUtils.SetRichTextBoxTextColor(rtbMultiLangEntity, txtTagColor.ForeColor);

            if (!string.IsNullOrEmpty(txtMultiLangEntity.Text))
            {
                registerRefreshItem(txtMultiLangEntity, rtbMultiLangEntity);
            }
        }

        private void btnMultiLangSqlProvider_Click(object sender, EventArgs e)
        {
            LoadTemplate("MultiLangSqlProvider.Tpl", txtMultiLangSqlProvider);
        }

        private void txtMultiLangSqlProvider_TextChanged(object sender, EventArgs e)
        {
            rtbMultiLangSqlProvider.Text = CommonUtils.ReadTextFile(txtMultiLangSqlProvider.Text);
            CommonUtils.SetRichTextBoxTextColor(rtbMultiLangSqlProvider, txtTagColor.ForeColor);

            if (!string.IsNullOrEmpty(txtMultiLangSqlProvider.Text))
            {
                registerRefreshItem(txtMultiLangSqlProvider, rtbMultiLangSqlProvider);
            }
        }

        private void btnMultiLangMapper_Click(object sender, EventArgs e)
        {
            LoadTemplate("MultiLangMapper.Tpl", txtMultiLangMapper);
        }

        private void txtMultiLangMapper_TextChanged(object sender, EventArgs e)
        {
            rtbMultiLangMapper.Text = CommonUtils.ReadTextFile(txtMultiLangMapper.Text);
            CommonUtils.SetRichTextBoxTextColor(rtbMultiLangMapper, txtTagColor.ForeColor);

            if (!string.IsNullOrEmpty(txtMultiLangMapper.Text))
            {
                registerRefreshItem(txtMultiLangMapper, rtbMultiLangMapper);
            }
        }

        private void txtMultiLangMapperExtend_TextChanged(object sender, EventArgs e)
        {
            rtbMultiLangMapperExtend.Text = CommonUtils.ReadTextFile(txtMultiLangMapperExtend.Text);
            CommonUtils.SetRichTextBoxTextColor(rtbMultiLangMapperExtend, txtTagColor.ForeColor);

            if (!string.IsNullOrEmpty(txtMultiLangMapperExtend.Text))
            {
                registerRefreshItem(txtMultiLangMapperExtend, rtbMultiLangMapperExtend);
            }
        }

        private void btnMultiLangMapperExtend_Click(object sender, EventArgs e)
        {
            LoadTemplate("MultiLangMapperExtend.Tpl", txtMultiLangMapperExtend);
        }

        private void txtMultiLangCreateTable_TextChanged(object sender, EventArgs e)
        {
            rtbMultiLangCreateTable.Text = CommonUtils.ReadTextFile(txtMultiLangCreateTable.Text);
            CommonUtils.SetRichTextBoxTextColor(rtbMultiLangCreateTable, txtTagColor.ForeColor);

            if (!string.IsNullOrEmpty(txtMultiLangCreateTable.Text))
            {
                registerRefreshItem(txtMultiLangCreateTable, rtbMultiLangCreateTable);
            }
        }

        private void btnMultiLangCreateTable_Click(object sender, EventArgs e)
        {
            LoadTemplate("MultiLangCreateTable.Tpl", txtMultiLangCreateTable);
        }

        private void txtMultiLangInsertData_TextChanged(object sender, EventArgs e)
        {
            rtbMultiLangInsertData.Text = CommonUtils.ReadTextFile(txtMultiLangInsertData.Text);
            CommonUtils.SetRichTextBoxTextColor(rtbMultiLangInsertData, txtTagColor.ForeColor);

            if (!string.IsNullOrEmpty(txtMultiLangInsertData.Text))
            {
                registerRefreshItem(txtMultiLangInsertData, rtbMultiLangInsertData);
            }
        }

        private void btnMultiLangInsertData_Click(object sender, EventArgs e)
        {
            LoadTemplate("MultiLangInsertData.Tpl", txtMultiLangInsertData);
        }

        private void txtVO_TextChanged(object sender, EventArgs e)
        {
            rtbVOTpl.Text = CommonUtils.ReadTextFile(txtVO.Text);
            CommonUtils.SetRichTextBoxTextColor(rtbVOTpl, txtTagColor.ForeColor);

            if (!string.IsNullOrEmpty(txtVO.Text))
            {
                registerRefreshItem(txtVO, rtbVOTpl);
            }
        }

        private void btnVO_Click(object sender, EventArgs e)
        {
            LoadTemplate("VO.Tpl", txtVO);
        }

        private void btnAggVO_Click(object sender, EventArgs e)
        {
            LoadTemplate("AggVO.Tpl", txtAggVO);
        }

        private void txtAggVO_TextChanged(object sender, EventArgs e)
        {
            rtbAggVO.Text = CommonUtils.ReadTextFile(txtAggVO.Text);
            CommonUtils.SetRichTextBoxTextColor(rtbAggVO, txtTagColor.ForeColor);

            if (!string.IsNullOrEmpty(txtAggVO.Text))
            {
                registerRefreshItem(txtAggVO, rtbAggVO);
            }
        }

        private List<string> executedScripts = new List<string>();


        private Dictionary<string, StringBuilder> ReadSpecificCreateTableScript(string prefix, string tableNameStr, List<string> scopeList)
        {
            char[] splitter = new char[] { ',', ' ' };
            Dictionary<string, StringBuilder> rtn = new Dictionary<string, StringBuilder>();
            string[] tableNames = tableNameStr.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            foreach (string tablename in tableNames)
            {
                string fileName = $"{prefix}{tablename}{".sql"}";
                if (scopeList.Contains("fileName"))
                {
                    Dictionary<string, StringBuilder> scripts = ReadScript(fileName, scopeList);
                    foreach (string key in scripts.Keys)
                    {
                        rtn.Add(key, scripts[key]);
                    }
                }
            }
            return rtn;
        }

        private void RunScripts(Dictionary<string, StringBuilder> scriptSB, MySqlConnection conn, string scriptFilename)
        {
            int newTaskRowNo = dtgStepLog.Rows.Add("Publishing: [" + scriptFilename + "]");
            ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Value = imgList.Images["running.gif"];
            dtgStepLog.Rows[newTaskRowNo].Cells[1].Value = $"  Publishing: [{scriptFilename}]";
            CommonUtils.Log(dtgStepLog.Rows[newTaskRowNo].Cells[1].Value.ToString().Trim());
            dtgStepLog.Refresh();

            bool error = false;
            foreach (KeyValuePair<string, StringBuilder> script in scriptSB)
            {
                int newRowNo = dtgStepLog.Rows.Add("Publishing: [" + script.Key + "]");
                try
                {
                    ((DataGridViewImageCell)dtgStepLog.Rows[newRowNo].Cells[0]).Value = imgList.Images["running.gif"];
                    dtgStepLog.Rows[newRowNo].Cells[1].Value = $"  Publishing: [{script.Key}]";
                    CommonUtils.Log(dtgStepLog.Rows[newRowNo].Cells[1].Value.ToString().Trim());
                    dtgStepLog.Refresh();


                    MySqlConnector.MySqlCommand cmd = new MySqlConnector.MySqlCommand(script.Value.ToString(), conn);
                    cmd.ExecuteNonQuery();

                    dtgStepLog.Rows[newRowNo].Cells[1].Value = $"  {script.Key} published.";
                    ((DataGridViewImageCell)dtgStepLog.Rows[newRowNo].Cells[0]).Value = imgList.Images["success.gif"];
                    dtgStepLog.Refresh();
                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    dtgStepLog.Rows[newTaskRowNo].Cells[1].Value = $"{script.Key} publishing faild: {ex.Message}";
                    ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Value = imgList.Images["error.gif"];
                    dtgStepLog.Refresh();
                    Application.DoEvents();

                    CommonUtils.Log($"{ex.Message}\r\n{script.Value}");
                    error = true;
                    continue;
                }
            }

            if (!error)
            {
                dtgStepLog.Rows[newTaskRowNo].Cells[1].Value = $"{scriptFilename} published.";
                ((DataGridViewImageCell)dtgStepLog.Rows[newTaskRowNo].Cells[0]).Value = imgList.Images["success.gif"];
                dtgStepLog.Refresh();
                Application.DoEvents();
            }
        }

        private Dictionary<string, StringBuilder> ReadMultiLangInsertDataScripts(List<string> scope)
        {
            return ReadScript("InsertData*_res.sql", scope);
        }

        private Dictionary<string, StringBuilder> ReadScript(string filter, List<string> scope)
        {
            string[] filenames = Directory.GetFiles(txtScriptSavePath.Text, filter);
            Dictionary<string, StringBuilder> scripts = new Dictionary<string, StringBuilder>();
            foreach (string filename in filenames)
            {
                if (scope.Contains(filename))
                {
                    if (!executedScripts.Contains(filename))
                    {
                        StringBuilder script = new StringBuilder();
                        script.Append(CommonUtils.ReadTextFile(filename));
                        scripts.Add(filename, script);
                        executedScripts.Add(filename);
                    }
                }
            }
            return scripts;
        }

        private Dictionary<string, StringBuilder> ReadInsertDataScripts(List<string> scope)
        {
            return ReadScript("InsertData*.sql", scope);
        }

        private Dictionary<string, StringBuilder> ReadCreateTableScripts(List<string> scope)
        {
            return ReadScript("CreateTable*.sql", scope);
        }

        private void btnRestTpl_Click(object sender, EventArgs e)
        {
            LoadTemplate("Rest.Tpl", txtRestTpl);
        }

        private void btnServiceTpl_Click(object sender, EventArgs e)
        {
            LoadTemplate("Service.Tpl", txtServiceTpl);
        }

        private void btnServiceImplTpl_Click(object sender, EventArgs e)
        {
            LoadTemplate("ServiceImpl.Tpl", txtServiceImplTpl);
        }

        private void txtServiceImplTpl_TextChanged(object sender, EventArgs e)
        {
            rtbServiceImplTpl.Text = CommonUtils.ReadTextFile(txtServiceImplTpl.Text);
            CommonUtils.SetRichTextBoxTextColor(rtbServiceImplTpl, txtTagColor.ForeColor);

            if (!string.IsNullOrEmpty(txtServiceImplTpl.Text))
            {
                registerRefreshItem(txtServiceImplTpl, rtbServiceImplTpl);
            }
        }

        private void txtServiceTpl_TextChanged(object sender, EventArgs e)
        {
            rtbServiceTpl.Text = CommonUtils.ReadTextFile(txtServiceTpl.Text);
            CommonUtils.SetRichTextBoxTextColor(rtbServiceTpl, txtTagColor.ForeColor);

            if (!string.IsNullOrEmpty(txtServiceTpl.Text))
            {
                registerRefreshItem(txtServiceTpl, rtbServiceTpl);
            }
        }

        private void txtRestTpl_TextChanged(object sender, EventArgs e)
        {
            rtbRestTpl.Text = CommonUtils.ReadTextFile(txtRestTpl.Text);
            CommonUtils.SetRichTextBoxTextColor(rtbRestTpl, txtTagColor.ForeColor);

            if (!string.IsNullOrEmpty(txtRestTpl.Text))
            {
                registerRefreshItem(txtRestTpl, rtbRestTpl);
            }
        }

        private void btnAggVORequestTpl_Click(object sender, EventArgs e)
        {
            LoadTemplate("AggDTO.Tpl", txtAggVORequestTpl);
        }

        private void txtAggVORequestTpl_TextChanged(object sender, EventArgs e)
        {
            rtbAggVORequestTpl.Text = CommonUtils.ReadTextFile(txtAggVORequestTpl.Text);
            CommonUtils.SetRichTextBoxTextColor(rtbAggVORequestTpl, txtTagColor.ForeColor);

            if (!string.IsNullOrEmpty(txtAggVORequestTpl.Text))
            {
                registerRefreshItem(txtAggVORequestTpl, rtbAggVORequestTpl);
            }
        }

        private void btnDTOTpl_Click(object sender, EventArgs e)
        {
            LoadTemplate("DTO.Tpl", txtDTOTpl);
        }

        private void txtDTOTpl_TextChanged(object sender, EventArgs e)
        {
            rtbDTOTpl.Text = CommonUtils.ReadTextFile(txtDTOTpl.Text);
            CommonUtils.SetRichTextBoxTextColor(rtbDTOTpl, txtTagColor.ForeColor);

            if (!string.IsNullOrEmpty(txtDTOTpl.Text))
            {
                registerRefreshItem(txtDTOTpl, rtbDTOTpl);
            }
        }

        Dictionary<TextBox, RichTextBox> freshDic = new Dictionary<TextBox, RichTextBox>();
        private void btnRefreshTemplate_Click(object sender, EventArgs e)
        {

        }

        private void tsbRun_MouseHover(object sender, EventArgs e)
        {
            if (excelReadData != null)
            {
                if (runStatus != RunStatusEnum.Running)
                {
                    if (tsbRun.Enabled == false)
                    {
                        tsbRun.Enabled = true;
                    }
                }
            }
        }

        private void txtHandlerTpl_TextChanged(object sender, EventArgs e)
        {
            rtbHandlerTpl.Text = CommonUtils.ReadTextFile(txtHandlerTpl.Text);
            CommonUtils.SetRichTextBoxTextColor(rtbHandlerTpl, txtTagColor.ForeColor);

            if (!string.IsNullOrEmpty(txtHandlerTpl.Text))
            {
                registerRefreshItem(txtHandlerTpl, rtbHandlerTpl);
            }
        }

        private void btnHandlerTpl_Click(object sender, EventArgs e)
        {
            LoadTemplate("Handler.Tpl", txtHandlerTpl);
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsbRun_Click(object sender, EventArgs e)
        {
            runStatus = RunStatusEnum.Running;

            tstrsStatus.Text = "Generate Processing ...";
            DisableAllOnRunning();
            dtgStepLog.Rows.Clear();

            tstrpProgress.Visible = true;
            tsbStop.Enabled = true;

            Application.DoEvents();

            try
            {
                TemplateUtils.connectionString = txtDBConnStr.Text;
                Generate();
                GenerateExtraMultiLangRes();
            }
            catch (Exception ex)
            {
                CommonUtils.Log(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }

            stopGenerate(true);

            MessageBox.Show(tstrsStatus.Text, "Information", MessageBoxButtons.OK);
            tstrsStatus.Text = "";

            tstrpProgress.Visible = false;
        }

        private void GenerateExtraMultiLangRes()
        {
            if (MultiLangRefInfo != null && MultiLangRefInfo.Count > 0)
            {
                StringBuilder textStr = new StringBuilder();
                foreach (KeyValuePair<string, Dictionary<string, string[]>> info in MultiLangRefInfo)
                {
                    foreach (KeyValuePair<string, string[]> item in info.Value)
                    {
                        textStr.Append(info.Key + ",");
                        textStr.Append(item.Key + ",");
                        textStr.Append(item.Value[0] + ",");
                        textStr.Append(item.Value[1] + ",");
                        textStr.Append(item.Value[2] + "\r\n");
                    }
                }
                CommonUtils.WriteTextFile("extra_meta_multilang_res.csv", txtScriptSavePath.Text, textStr.ToString(), true, true, true, false);
            }
        }

        private void tsbRefreshTemplate_Click(object sender, EventArgs e)
        {
            if (freshDic.Count > 0)
            {
                foreach (KeyValuePair<TextBox, RichTextBox> keyValuePair in freshDic)
                {
                    keyValuePair.Value.Text = CommonUtils.ReadTextFile(keyValuePair.Key.Text);
                    CommonUtils.SetRichTextBoxTextColor(keyValuePair.Value, txtTagColor.ForeColor);
                }
            }
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "Setting File | *.dat";
            openFileDialog.FileName = @"\setting.dat";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog.FileName))
                {
                    currentSettingFileName = openFileDialog.FileName;
                    Object settingObj = CommonUtils.ReadSerializationDataFromFile(openFileDialog.FileName);
                    if (settingObj != null)
                    {
                        Dictionary<string, string> settings = (Dictionary<string, string>)settingObj;
                        InjectSettingsToControls(this, settings);
                    }

                    RefreshControlStatus();
                }

                SettingLoaded = true;
                SettingSaved = true;

                tsbSave.Enabled = false;
                RefreshControlStatus();

                excelReadData = null;
                getExcelData();
            }
        }

        private void tsbStop_Click(object sender, EventArgs e)
        {
            stopGenerate(false);
        }

        private void tsbPublish_Click(object sender, EventArgs e)
        {
            frmScriptChoose frmScript = new frmScriptChoose();
            string[] filenames = Directory.GetFiles(txtScriptSavePath.Text);
            List<string> fileList = new List<string>();
            fileList.AddRange(filenames);
            Predicate<string> findPredicate = new Predicate<string>(IsSQLFile);
            frmScript.setScripts(fileList.FindAll(findPredicate).ToArray());
            frmScript.StartPosition = FormStartPosition.CenterParent;

            if (frmScript.ShowDialog(this) == DialogResult.OK)
            {
                List<string> checkedScripts = frmScript.getCheckedScriptNames();

                runStatus = RunStatusEnum.Running;

                tstrsStatus.Text = "Publishing ...";
                DisableAllOnRunning();
                dtgStepLog.Rows.Clear();
                tsbRun.Enabled = false;
                tsbStop.Enabled = true;

                Application.DoEvents();

                try
                {
                    string connetStr = txtDBConnStr.Text;

                    if (string.IsNullOrEmpty(connetStr))
                    {
                        MessageBox.Show("No database connection info defined.");
                    }
                    else
                    {
                        dtgStepLog.Rows.Clear();

                        MySqlConnection conn = new MySqlConnection(connetStr);
                        try
                        {
                            conn.Open();

                            Dictionary<string, StringBuilder> scriptSB = null;

                            scriptSB = ReadSpecificCreateTableScript(txtCreateTablePrefix.Text, txtBaseExecutive.Text, checkedScripts);
                            RunScripts(scriptSB, conn, "Pre-execute scripts");

                            scriptSB = ReadSpecificCreateTableScript(txtInsertDataPrefix.Text, txtBaseExecutive.Text, checkedScripts);
                            RunScripts(scriptSB, conn, "Pre-insert data scripts");

                            scriptSB = ReadCreateTableScripts(checkedScripts);
                            RunScripts(scriptSB, conn, "Create table scripts");

                            scriptSB = ReadInsertDataScripts(checkedScripts);
                            RunScripts(scriptSB, conn, "Metadata Insert Scripts");

                            if (chkExecuteMultiLang.Checked)
                            {
                                scriptSB = ReadMultiLangInsertDataScripts(checkedScripts);
                                RunScripts(scriptSB, conn, "Multi Language Data Insert Scripts");
                            }
                        }
                        finally
                        {
                            conn.Close();
                        }

                    }
                }
                catch (Exception ex)
                {
                    CommonUtils.Log(ex.StackTrace);
                    MessageBox.Show(ex.Message);
                }

                EnableAllOnStop();
                tsbRun.Enabled = true;
                tsbStop.Enabled = false;
                tstrsStatus.Text = "";
                tstrpProgress.Visible = false;
                runStatus = RunStatusEnum.Stopped;
            }
        }

        private bool IsSQLFile(string fileName)
        {
            return fileName.EndsWith(".sql");
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            settings.Clear();
            FetchSettingsFromControls(this);

            if (String.IsNullOrEmpty(currentSettingFileName))
            {
                tsbSaveAs_Click(sender, e);
                return;
            }
            else
            {
                CommonUtils.WriteSerializationDataToFile(currentSettingFileName, settings);
                SettingSaved = true;
                tsbSave.Enabled = false;

                RefreshControlStatus();
            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    //F5 = Run
                    tsbRun_Click(this, EventArgs.Empty);
                    break;
                case Keys.F4:
                    //F4 = Stop
                    tsbStop_Click(this, EventArgs.Empty);
                    break;
            }

            if (e.KeyCode == Keys.O && e.Modifiers == Keys.Control)
            {
                //Ctrl+O = Open
                tsbOpen_Click(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                //Ctrl+S = Save
                tsbSave_Click(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.S && ((int)e.Modifiers) == ((int)Keys.Control + (int)Keys.Shift))
            {
                //Ctrl+Shift+S = Save As
                tsbSaveAs_Click(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                //Ctrl+P = Publish to database
                tsbPublish_Click(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                //Ctrl+R = Refresh Design File
                tsbRefreshDesign_Click(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.R && ((int)e.Modifiers) == ((int)Keys.Control + (int)Keys.Shift))
            {
                //Ctrl+Shift+R = Refresh Template
                tsbRefreshTemplate_Click(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Q && e.Modifiers == Keys.Control)
            {
                //Ctrl+Q = Quit
                tsbExit_Click(this, EventArgs.Empty);
            }
        }

        private void tsbSaveAs_Click(object sender, EventArgs e)
        {
            settings.Clear();
            FetchSettingsFromControls(this);

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Setting Files | *.dat";
            saveFile.FileName = "setting.dat";
            saveFile.InitialDirectory = Application.StartupPath;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                CommonUtils.WriteSerializationDataToFile(saveFile.FileName, settings);
            }

            currentSettingFileName = saveFile.FileName;
            SettingSaved = true;
            tsbSave.Enabled = false;

            RefreshControlStatus();
        }

        private void tsbRefreshDesign_Click(object sender, EventArgs e)
        {
            if (!isReading)
            {
                excelReadData = null;
                isReading = false;
                getExcelData();
            }
        }
    }
}