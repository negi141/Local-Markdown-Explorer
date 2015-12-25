using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
using MarkdownDeep;

namespace LocalMarkdownExplorer
{
    public partial class Form1 : Form
    {
        string targetPath;
        Encoding fileEncode;
        string[] textExtension = { ".txt", ".md" };
        bool isFirstLoad = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initLoad();
        }

        public void initLoad()
        {
            Util.IniFile inifile = new Util.IniFile("config.ini");
            if (inifile.Data("TargetPath") == "")
            {
                inifile.data["TargetPath"] = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                inifile.data["FileEncode"] = "Shift_JIS";
                inifile.Save();

                FormSetting f = new FormSetting(this);
                f.ShowDialog(this);
                f.Dispose();
            }
            else
            {
                targetPath = inifile.Data("TargetPath") + "\\";
                fileEncode = Encoding.GetEncoding(inifile.Data("FileEncode"));

                string[] path = targetPath.Split('\\');
                this.Text = "LocalMarkdownExplorer  [" + path[path.Length - 2] + "]";


                this.lbCautionMessge.Text = "内容を変更中";
                this.lbCautionMessge.Visible = false;

                this.InitViewListBox();

                this.tabEditor.SelectedIndex = 1;

                this.ActiveControl = this.tbSearch;

                this.isFirstLoad = false;
            }
        }


        #region クリックイベントメソッド============================================================

        private void btnSetting_Click(object sender, EventArgs e)
        {
            FormSetting f = new FormSetting(this);
            f.ShowDialog();
            f.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string tempTitle = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".md";
            Util.IO.SaveFile(targetPath + tempTitle, "", fileEncode);

            this.InitViewListBox();

            this.lbMdList.Text = tempTitle;

            openSelectFile();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Regex ex = new Regex("\\/:\"><");

            if (ex.IsMatch(this.tbTitle.Text))
            {
                MessageBox.Show("使用できない文字列があります");
            }
            else
            {
                DictionaryEntry dictionaryEntry = (DictionaryEntry)this.lbMdList.SelectedItem;

                Util.IO.DeleteFile(dictionaryEntry.Value.ToString());

                string saveFileName = this.tbTitle.Text;
                Util.IO.SaveFile(targetPath + saveFileName, this.tbMd.Text, fileEncode);

                this.InitViewListBox();

                this.lbMdList.Text = saveFileName;

                openSelectFile();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DictionaryEntry dictionaryEntry = (DictionaryEntry)this.lbMdList.SelectedItem;

            DialogResult result = MessageBox.Show(dictionaryEntry.Key + "を削除してよろしいですか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.OK)
            {
                File.Delete(dictionaryEntry.Value.ToString());

                this.InitViewListBox();
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            DictionaryEntry dictionaryEntry = (DictionaryEntry)this.lbMdList.SelectedItem;

            Util.IO.ProcessStart(dictionaryEntry.Value.ToString());
        }

        private void btnOpenDir_Click(object sender, EventArgs e)
        {
            Util.IO.ProcessStart(targetPath);
        }
        #endregion


        #region その他イベントメソッド============================================================

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            this.SetViewListBox(this.tbSearch.Text.ToLower(), true);
        }

        private void lbMdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            openSelectFile();

            this.displayMarkDown();
        }

        private void tabEditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayMarkDown();
        }
        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            if (this.isFirstLoad == false) lbCautionMessge.Visible = true;
        }

        private void tbMd_TextChanged(object sender, EventArgs e)
        {
            if (this.isFirstLoad == false) lbCautionMessge.Visible = true;
        }

        #endregion


        #region 汎用メソッド============================================================

        private void InitViewListBox()
        {
            tbSearch.Text = "";
            SetViewListBox("", false);
        }

        private void SetViewListBox(string searchWord, bool enableDetailSearch)
        {
            this.lbMdList.Items.Clear();
            this.lbMdList.DisplayMember = "Key";
            this.lbMdList.ValueMember = "Value";
            this.DirSearch(targetPath, searchWord, enableDetailSearch);

            if (this.lbMdList.Items.Count != 0)
            {
                this.lbMdList.SelectedIndex = 0;
            }
        }

        private void DirSearch(string sDir, string searchWord, bool enableDetailSearch)
        {
            string[] searchWords = searchWord.Split(' ');
            string[] array = Directory.GetFiles(sDir);
            for (int i = 0; i < array.Length; i++)
            {
                string fullpath = array[i];
                string extension = Path.GetExtension(fullpath);
                if (extension != ".exe")
                {
                    string key = fullpath.Replace(sDir, "");
                    string value = fullpath;

                    if (searchWord == "" || Util.String.MultiContain(fullpath.ToLower(), searchWords))
                    {
                        this.lbMdList.Items.Add(new DictionaryEntry(key, value));
                    }
                    else
                    {
                        if (enableDetailSearch)
                        {
                            // テキストファイルであれば内容を検索
                            if (Array.IndexOf(textExtension, extension) != -1)
                            {
                                if (Util.String.MultiContain(Util.IO.GetFileReadToEnd(fullpath, fileEncode), searchWords))
                                {
                                    this.lbMdList.Items.Add(new DictionaryEntry(key, value));
                                }
                            }
                        }
                    }
                }
            }
        }

        private void openSelectFile()
        {
            DictionaryEntry dictionaryEntry = (DictionaryEntry)this.lbMdList.SelectedItem;

            string filename = dictionaryEntry.Key.ToString();
            string extension = Path.GetExtension(dictionaryEntry.Value.ToString());

            this.tbTitle.Text = filename;
            // テキストファイル
            if (Array.IndexOf(textExtension, extension) != -1)
            {
                tabEditor.Visible = true;

                this.tbMd.Text = Util.IO.GetFileReadToEnd(dictionaryEntry.Value.ToString(), fileEncode);
            }
            else
            { // それ以外は実行する
                tabEditor.Visible = false;
            }
            lbCautionMessge.Visible = false;
        }

        private void displayMarkDown()
        {
            string content = "";

            Markdown m = new Markdown();
            m.ExtraMode = true;
            content = m.Transform(tbMd.Text);

            // チェック用
            tbHTML.Text = content;

            string html = @"
<!DOCTYPE html>
<html>
  <head>
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
<style type=""text/css"">
    body {
        font-family: helvetica, arial, 'lucida grande', 'hiragino kaku gothic pro',meiryo,'ms pgothic',sans-serif;
        line-height:26px;
    }
    h1 {
        color: #555;
        border-bottom: 2px solid #EEE;
        font-size: 24px;
        margin-bottom: 12px;
        padding-bottom: 6px;
        padding-top: 8px;
    }
    h2 {
        color: #555;
        border-bottom: 1px solid #EEE;
        font-size: 20px;
        margin-bottom: 12px;
        padding-bottom: 6px;
        padding-top: 8px;
    }
    h3, h4, h5, h6 {
        color: #555;
        font-size: 16px;
        margin-bottom: 12px;
        padding-bottom: 6px;
        padding-top: 8px;
    }
    code {
        background:#f3f3ff;
        border: 1px solid #e3e3ff;
        white-space : pre;
        padding:5px;
    }
    pre {
        background:#f3f3ff;
        border: 1px solid #e3e3ff;
        white-space : pre;
        padding:5px;
        border-radius:4px;
    }
    pre code {
        border: 0px solid #e3e3ff;
        padding:0px;
    }
    blockquote {
        padding: 0px 15px;
        color: #777;
        border-left: 4px solid #DDD;
        font-size:80%;
    }
</style>
  </head>
  <body>
    " + content + @"
  </body>
</html>
";
            webMd.DocumentText = html;
        }
        #endregion


        #region オーバーライド============================================================
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.A | Keys.Control:
                    if (this.ActiveControl is TextBox)
                    {
                        TextBox txt = (TextBox)this.ActiveControl;
                        txt.SelectionStart = 0;
                        txt.SelectionLength = txt.Text.Length;
                        return true;
                    }
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }
        #endregion


    }
}
