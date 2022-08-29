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
            this.DialogResult =DialogResult.Cancel;
        }

        public List<string> getCheckedScriptNames()
        {
            List<string> scriptNames = new List<string>();
            
            return scriptNames;
        }

        public void setScripts(string[] allScripts)
        {
            foreach (string script in allScripts)
            {
                chklScripts.Items.Add(script);  
            }
        }

        private void frmScriptChoose_Load(object sender, EventArgs e)
        {

        }
    }
}
