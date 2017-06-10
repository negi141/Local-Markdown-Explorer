using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LocalMarkdownExplorer
{
    public partial class FormSetting : Form
    {
        Form1 form1;

        public FormSetting(Form1 parent)
        {
            form1 = parent;
            InitializeComponent();
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            //if (config.PathType == "Absolute") rbPathAbsolute.Select(); else rbPathRelative.Select();
            //tbPathAbsolute.Text = config.AbsolutePath;
            //tbPathRelative.Text = config.RelativePath;
            
            //ddlEncoding.Text = config.FileEncode;
            //tbExtensionText.Text = config.ExtensionText;
            //tbExtensionIgnore.Text = config.ExtensionIgnore;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //config.PathType = (rbPathAbsolute.Checked) ? "Absolute" : "Relative";
            //config.AbsolutePath = tbPathAbsolute.Text;
            //config.RelativePath = tbPathRelative.Text;
            
            //config.FileEncode = ddlEncoding.SelectedItem.ToString();
            //config.ExtensionText = tbExtensionText.Text;
            //config.ExtensionIgnore = tbExtensionIgnore.Text;
            //config.Save();
            form1.initLoad();
            this.Close();
        }
    }
}
