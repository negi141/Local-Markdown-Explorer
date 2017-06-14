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
        bool isNew = true;
        string updateName = "";

        public FormAddRootDir(Form1 parent)
        {
            form1 = parent;
            InitializeComponent();
        }

        public void SetEditName(string name)
        {
            isNew = false;
            updateName = name;
            btnSave.Text = "更新";
        }

        private void FormAddRootDir_Load(object sender, EventArgs e)
        {
            if (isNew)
            {
                // 新規
                rbPathAbsolute.Checked = true;
                ddlEncoding.Text = "Shift_JIS";
                tbExtensionText.Text = "txt,md";
                tbExtensionIgnore.Text = "exe,dll";
            }
            else
            {
                // 変更時
                foreach (var path in form1.config.paths)
                {
                    if (updateName == path.name)
                    {
                        tbName.Text = path.name;
                        rbPathAbsolute.Checked = (path.type == "Absolute");
                        rbPathRelative.Checked = (path.type == "Relative");
                        tbAbsolutePath.Text = path.AbsolutePath;
                        tbRelativePath.Text = path.RelativePath;
                        ddlEncoding.Text = path.Encoding;
                        tbExtensionText.Text = path.ExtensionText;
                        tbExtensionIgnore.Text = path.ExtensionIgnore;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                // 設定のパス配列
                object[] tmpPaths = form1.config.paths;
                object[] newPaths;
                if (isNew)
                {
                    // 現在のpath+1の配列生成
                    newPaths = new object[tmpPaths.Length + 1];
                    // foreachで新しい配列に追加する
                    var i = 0;
                    foreach (var path in form1.config.paths)
                    {
                        newPaths[i] = new
                        {
                            name = path.name,
                            type = path.type,
                            AbsolutePath = path.AbsolutePath,
                            RelativePath = path.RelativePath,
                            Encoding = path.Encoding,
                            ExtensionText = path.ExtensionText,
                            ExtensionIgnore = path.ExtensionIgnore,
                        };
                        i++;
                    }
                    // 新規分を追加する
                    newPaths[i] = new
                    {
                        name = tbName.Text,
                        type = (rbPathAbsolute.Checked) ? "Absolute" : "Relative",
                        AbsolutePath = tbAbsolutePath.Text,
                        RelativePath = tbRelativePath.Text,
                        Encoding = ddlEncoding.Text,
                        ExtensionText = tbExtensionText.Text,
                        ExtensionIgnore = tbExtensionIgnore.Text,
                    };
                }
                else
                {
                    // 現在のpathの配列生成
                    newPaths = new object[tmpPaths.Length];
                    // foreachで新しい配列に追加する
                    var i = 0;
                    foreach (var path in form1.config.paths)
                    {
                        if (path.name == updateName)
                        {
                            newPaths[i] = new
                            {
                                name = tbName.Text,
                                type = (rbPathAbsolute.Checked) ? "Absolute" : "Relative",
                                AbsolutePath = tbAbsolutePath.Text,
                                RelativePath = tbRelativePath.Text,
                                Encoding = ddlEncoding.Text,
                                ExtensionText = tbExtensionText.Text,
                                ExtensionIgnore = tbExtensionIgnore.Text,
                            };
                        }
                        else
                        {
                            newPaths[i] = new
                            {
                                name = path.name,
                                type = path.type,
                                AbsolutePath = path.AbsolutePath,
                                RelativePath = path.RelativePath,
                                Encoding = path.Encoding,
                                ExtensionText = path.ExtensionText,
                                ExtensionIgnore = path.ExtensionIgnore,
                            };
                        }
                        i++;
                    }
                }
                form1.config = new
                {
                    paths = newPaths,
                };
                Util.IO.SaveFile("config.json", DynamicJson.Serialize(form1.config));

                form1.selectedDirName = tbName.Text;
                form1.initLoad();
                this.Close();
            }
        }

        private bool validate()
        {
            if (!Util.Validate.TextBox(tbName, "表示名")) return false;
            if (rbPathAbsolute.Checked)
            {
                if (!Util.Validate.TextBox(tbAbsolutePath, "絶対パス")) return false;
                if (!Util.Validate.DirectoryExists(tbAbsolutePath.Text, "絶対パス")) return false;
            }
            else
            {
                if (!Util.Validate.TextBox(tbRelativePath, "相対パス")) return false;
                if (!Util.Validate.DirectoryExists(Path.GetFullPath(tbRelativePath.Text), "相対パス")) return false;
            }
            return true;
        }

        private void btnDirBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = tbAbsolutePath.Text;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbAbsolutePath.Text = folderBrowserDialog1.SelectedPath;
            }

            folderBrowserDialog1.Dispose();
        }

        private void btnRelativeParentPath_Click(object sender, EventArgs e)
        {
            tbRelativePath.Text = "..\\";
        }
    }
}
