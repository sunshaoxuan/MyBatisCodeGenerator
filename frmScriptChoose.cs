using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBatisCodeGenerator
{
    public partial class frmScriptChoose : Form
    {
        public List<string> ScriptList { get; set; } = new List<string>();

        public frmScriptChoose()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public List<string> getCheckedScriptNames()
        {
            List<string> checkItems = new List<string>();
            for (int i=0;i< chklScripts.CheckedItems.Count; i++)
            {
                checkItems.Add(chklScripts.CheckedItems[i].ToString());
            }
            return checkItems;
        }

        public void setScripts(string[] allScripts)
        {
            foreach (string script in allScripts)
            {
                chklScripts.Items.Add(script);
                ScriptList.Add(script);
            }
        }

        private void frmScriptChoose_Load(object sender, EventArgs e)
        {
            
        }

        private void llbSelectAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < chklScripts.Items.Count; i++)
            {
                chklScripts.SetItemChecked(i, true);
            }
        }

        private void llbSelectNone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < chklScripts.Items.Count; i++)
            {
                chklScripts.SetItemChecked(i, false);
            }
        }

        private void llbSelectReverse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < chklScripts.Items.Count; i++)
            {
                chklScripts.SetItemChecked(i, !chklScripts.GetItemChecked(i));
            }
        }

        private void llbSelectCreateTable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < chklScripts.Items.Count; i++)
            {
                if (chklScripts.Items[i].ToString().Substring(chklScripts.Items[i].ToString().LastIndexOf("\\") + 1).StartsWith("Create"))
                {
                    chklScripts.SetItemChecked(i, true);
                }
                else
                {
                    chklScripts.SetItemChecked(i, false);
                }
            }
        }

        private void llbAllInsert_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < chklScripts.Items.Count; i++)
            {
                if (chklScripts.Items[i].ToString().Substring(chklScripts.Items[i].ToString().LastIndexOf("\\") + 1).StartsWith("Insert"))
                {
                    chklScripts.SetItemChecked(i, true);
                }
                else
                {
                    chklScripts.SetItemChecked(i, false);
                }
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            List<string> filtered = ScriptList.AsEnumerable().Where(x => x.ToUpper().Contains(txtFilter.Text.ToUpper())).ToList();
            chklScripts.Items.Clear();
            chklScripts.Items.AddRange(filtered.ToArray());
        }
    }
}