using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Codeplex.Data;
using negi;

namespace LocalMarkdownExplorer
{
    public partial class FormAddRootDir : Form
    {
        Form1 form1;

        public FormAddRootDir(Form1 parent)
        {
            form1 = parent;
            InitializeComponent();
        }

        private void FormAddRootDir_Load(object sender, EventArgs e)
        {
            rbPathAbsolute.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                // 設定のパス配列
                object[] tmpPaths = form1.config.paths;
                // 現在のpath+1の配列生成
                object[] newPaths = new object[tmpPaths.Length + 1];
                // foreachで新しい配列に追加する
                var i = 0;
                foreach (var path in form1.config.paths)
                {
                    newPaths[i] = new
                    {
                        name = path.name,
                        type = path.type,
                        AbsolutePath = path.AbsolutePath,
                        RelativePath = path.RelativePath
                    };
                    i++;
                }
                // 新規分を追加する
                newPaths[i] = new
                {
                    name = tbName.Text,
                    type = (rbPathAbsolute.Checked) ? "Absolute" : "Relative",
                    AbsolutePath = tbPathAbsolute.Text,
                    RelativePath = tbPathRelative.Text
                };
                form1.config = new
                {
                    paths = newPaths,
                    FileEncode = form1.config.FileEncode,
                    ExtensionText = form1.config.ExtensionText,
                    ExtensionIgnore = form1.config.ExtensionIgnore
                };
                Util.IO.SaveFile("config.json", DynamicJson.Serialize(form1.config));

                form1.initLoad();
                this.Close();
            }
        }

        private bool validate()
        {
            if (!Util.Validate.TextBox(tbName, "表示名")) return false;
            if (rbPathAbsolute.Checked)
            {
                if (!Util.Validate.TextBox(tbPathAbsolute, "絶対パス")) return false;
                if (!Util.Validate.DirectoryExists(tbPathAbsolute.Text, "絶対パス")) return false;
            }
            else
            {
                if (!Util.Validate.TextBox(tbPathRelative, "相対パス")) return false;
                if (!Util.Validate.DirectoryExists(Path.GetFullPath(tbPathRelative.Text), "相対パス")) return false;
            }
            return true;
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
