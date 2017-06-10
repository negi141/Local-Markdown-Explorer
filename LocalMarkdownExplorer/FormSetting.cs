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
            ddlEncoding.Text = form1.config.FileEncode;
            tbExtensionText.Text = form1.config.ExtensionText;
            tbExtensionIgnore.Text = form1.config.ExtensionIgnore;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 設定のパス配列
            object[] tmpPaths = form1.config.paths;
            // 現在のpathの配列生成
            object[] newPaths = new object[tmpPaths.Length];
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

            form1.config = new
            {
                paths = newPaths,
                FileEncode = ddlEncoding.SelectedItem.ToString(),
                ExtensionText = tbExtensionText.Text,
                ExtensionIgnore = tbExtensionIgnore.Text
            };
            Util.IO.SaveFile("config.json", DynamicJson.Serialize(form1.config));
            form1.initLoad();
            this.Close();
        }
    }
}
