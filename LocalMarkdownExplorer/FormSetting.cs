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
        Config config;

        public FormSetting(Form1 parent)
        {
            form1 = parent;
            InitializeComponent();
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            config = new Config();
            if (config.PathType == "Absolute") rbPathAbsolute.Select(); else rbPathRelative.Select();
            tbPathAbsolute.Text = config.AbsolutePath;
            tbPathRelative.Text = config.RelativePath;
            ddlEncoding.Text = config.FileEncode;
            tbExtensionText.Text = config.ExtensionText;
            tbExtensionIgnore.Text = config.ExtensionIgnore;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string err = saveValidate();
            if(err != "") {
                MessageBox.Show(err);
                return;
            }
            config.PathType = (rbPathAbsolute.Checked) ? "Absolute" : "Relative";
            config.AbsolutePath = tbPathAbsolute.Text;
            config.RelativePath = tbPathRelative.Text;
            config.FileEncode = ddlEncoding.SelectedItem.ToString();
            config.ExtensionText = tbExtensionText.Text;
            config.ExtensionIgnore = tbExtensionIgnore.Text;
            config.Save();
            form1.initLoad();
            this.Close();
        }

        private string saveValidate()
        {
            string errMessage = "";
            if (rbPathAbsolute.Checked)
            {
                if (tbPathAbsolute.Text == "" || !Directory.Exists(tbPathAbsolute.Text))
                {
                    errMessage = "絶対パスを正しく入力してください。";
                }
            }
            else
            {
                if (tbPathRelative.Text == "" || !Directory.Exists(Path.GetFullPath(tbPathRelative.Text)))
                {
                    errMessage = "相対パスを正しく入力してください。";
                }
            }
            return errMessage;
        }

        private void btnDirBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = tbPathAbsolute.Text;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbPathAbsolute.Text = folderBrowserDialog1.SelectedPath;
            }

            folderBrowserDialog1.Dispose();
        }

        private void btnRelativeParentPath_Click(object sender, EventArgs e)
        {
            tbPathRelative.Text = "..\\";
        }
    }
}
