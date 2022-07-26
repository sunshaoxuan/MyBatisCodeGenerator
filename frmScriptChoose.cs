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

        public List<String> getCheckedScriptNames()
        {
            List<String> scriptNames = new List<String>();
            
            return scriptNames;
        }

        public void setScripts(String[] allScripts)
        {
            foreach (String script in allScripts)
            {
                chklScripts.Items.Add(script);  
            }
        }
    }
}
