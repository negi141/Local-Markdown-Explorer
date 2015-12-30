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
            Util.IniFile inifile = new Util.IniFile("config.ini");

            if (inifile.Data("PathType") == "Absolute") rbPathAbsolute.Select(); else rbPathRelative.Select();
            tbPathAbsolute.Text = inifile.Data("AbsolutePath");
            tbPathRelative.Text = inifile.Data("RelativePath");
            ddlEncoding.Text = inifile.Data("FileEncode");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string err = saveValidate(tbPathAbsolute.Text);
            if(err != "") {
                MessageBox.Show(err);
                return;
            }
            Util.IniFile inifile = new Util.IniFile("config.ini");
            inifile.data["PathType"] = (rbPathAbsolute.Checked) ? "Absolute" : "Relative";
            inifile.data["AbsolutePath"] = tbPathAbsolute.Text;
            inifile.data["RelativePath"] = tbPathRelative.Text;
            inifile.data["FileEncode"] = ddlEncoding.SelectedItem.ToString();
            inifile.Save();
            form1.initLoad();
            this.Close();
        }

        private string saveValidate(string targetPath)
        {
            string errMessage = "";
            if (targetPath == "")
            {
                errMessage = "フォルダパスを入力してください。";
            }
            else
            {
                if (!Directory.Exists(targetPath)) errMessage = "フォルダパスを正しく入力してください。";
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
