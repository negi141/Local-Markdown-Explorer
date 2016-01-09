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
        Config config;
        string targetPath;
        Encoding fileEncode;
        string[] extensionText;
        string[] extensionIgnore;
        bool isFirstLoad = true;
        SelectedFile selectedFile;

        #region 初期化メソッド============================================================

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
            config = new Config();
            if (config.PathType == "")
            {
                // 初期設定
                config.PathType = "Absolute";
                config.AbsolutePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                config.RelativePath = "..\\";
                config.FileEncode = "Shift_JIS";
                config.ExtensionText = "txt,md";
                config.ExtensionIgnore = "exe,dll";
                config.Save();

                FormSetting f = new FormSetting(this);
                f.ShowDialog(this);
                f.Dispose();
            }
            else
            {
                // パス
                if (config.PathType == "Absolute")
                {
                    targetPath = config.AbsolutePath + "\\";
                }
                else if (config.PathType == "Relative")
                {
                    targetPath = Path.GetFullPath(config.RelativePath);
                }
                // エンコーディング
                fileEncode = Encoding.GetEncoding(config.FileEncode);
                // 拡張子
                extensionText = config.ExtensionText.Split(',');
                for (int i = 0; i < extensionText.Length; i++) extensionText[i] = "." + extensionText[i];
                extensionIgnore = config.ExtensionIgnore.Split(',');
                for (int i = 0; i < extensionIgnore.Length; i++) extensionIgnore[i] = "." + extensionIgnore[i];

                this.Text = "LocalMarkdownExplorer  [" + targetPath + "]";

                this.lbCautionMessge.Text = "(内容を変更中)";
                this.lbCautionMessge.Visible = false;

                this.InitViewListBox();

                this.tabEditor.SelectedIndex = 1;

                this.groupBoxFile.Enabled = false;

                this.isFirstLoad = false;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.tbSearch.Focus();
        }
        #endregion


        #region ボタンクリックイベントメソッド============================================================

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

            this.tabEditor.SelectedIndex = 0;

            this.tbTitle.Focus();
            this.tbTitle.Select(0, 15);
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
                string oldFileName = selectedFile.fileName;
                string newFileName = this.tbTitle.Text;
                bool cancel = false;
                // ファイル名を変更する場合
                if (oldFileName != newFileName)
                {
                    // 同名ファイルが存在した場合
                    if (File.Exists(targetPath + newFileName))
                    {
                        DialogResult result = MessageBox.Show("既に" + newFileName + "が存在します。上書きしてよろしいですか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.OK)
                        {
                            File.Delete(targetPath + oldFileName);
                        }
                        else
                        {
                            cancel = true;
                        }
                    }
                    else
                    {
                        Util.IO.DeleteFile(targetPath + oldFileName);
                    }
                }

                if (!cancel)
                {
                    Util.IO.SaveFile(targetPath + newFileName, this.rtbMd.Text, fileEncode);

                    this.InitViewListBox();

                    this.lbMdList.Text = newFileName;

                    lbMdList_SelectedIndexChanged(null, null);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(selectedFile.fileName + "を削除してよろしいですか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.OK)
            {
                File.Delete(selectedFile.fullPath);

                this.InitViewListBox();
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            Util.IO.ProcessStart(selectedFile.fullPath);
        }

        private void btnOpenDir_Click(object sender, EventArgs e)
        {
            Util.IO.ProcessStart(targetPath);
        }

        private void linkBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            initLoad();
            linkBack.Visible = false;
        }
        #endregion


        #region 選択イベントメソッド============================================================


        private void lbAssist_MouseUp(object sender, MouseEventArgs e)
        {
            lbAssist.Visible = false;
            DictionaryEntry dictionaryEntry = (DictionaryEntry)this.lbAssist.SelectedItem;
            this.lbMdList.Text = dictionaryEntry.Key.ToString();
        }
        private void lbMdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFile = getSelectedItem();
            if (selectedFile == null) return;

            if (selectedFile.isDirectory)
            {
                targetPath = selectedFile.fullPath + "\\";

                this.InitViewListBox();

                linkBack.Visible = true;
            }
            else
            {
                this.groupBoxFile.Enabled = true;
                openSelectFile();
                rtbMd.Select(0, rtbMd.Text.Length);
                rtbMd.SelectionColor = Color.Black;
                highLight();
                lbCautionMessge.Visible = false;
                try
                {
                    this.displayMarkDown();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void tabEditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                displayMarkDown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            rtbMd.Focus();
        }

        private void lbMdList_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index > -1)
            {
                Brush b = null;
                if ((e.State & DrawItemState.Selected) != DrawItemState.Selected)
                {
                    b = new SolidBrush(Color.Black);
                }
                else
                {
                    b = new SolidBrush(e.ForeColor);
                }
                DictionaryEntry dictionaryEntry = (DictionaryEntry)((ListBox)sender).Items[e.Index];
                SelectedFile file = (SelectedFile)dictionaryEntry.Value;
                int imgWidth = Resource1.DoucmentHS.Width;
                if (file.isDirectory)
                {
                    e.Graphics.DrawImage(Resource1.Folder_16x16, e.Bounds.X, e.Bounds.Y);
                }
                else if (Array.IndexOf(extensionText, file.extension) != -1)
                {
                    e.Graphics.DrawImage(Resource1.DoucmentHS, e.Bounds.X, e.Bounds.Y);
                }
                else
                {
                    e.Graphics.DrawImage(Resource1.RightToLeftDoucmentHS, e.Bounds.X, e.Bounds.Y);
                }
                e.Graphics.DrawString(file.fileName, e.Font, b, e.Bounds.X + imgWidth, e.Bounds.Y);

                b.Dispose();
            }

            e.DrawFocusRectangle();
        }
        #endregion


        #region テキストイベントメソッド============================================================

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (lbAssist.Visible)
                {
                    lbAssist.SelectedIndex = 0;
                    lbAssist.Focus();
                }
            }
        }
        private void lbAssist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lbAssist.Visible = false;
                DictionaryEntry dictionaryEntry = (DictionaryEntry)this.lbAssist.SelectedItem;
                this.lbMdList.Text = dictionaryEntry.Key.ToString();
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text == "")
            {
                lbAssist.Visible = false;
                return;
            }
            this.SetAssistListBox(this.tbSearch.Text.ToLower(), true);
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            if (this.isFirstLoad == false) lbCautionMessge.Visible = true;
        }

        private void rtbMd_TextChanged(object sender, EventArgs e)
        {
            if (this.isFirstLoad == false) lbCautionMessge.Visible = true;
        }
        private void highLight()
        {
            string tokens = @"(^#* |^~*)";
            Regex rex = new Regex(tokens);

            string[] lines = new Regex("\n").Split(rtbMd.Text);

            for (int i = 0; i < lines.Length; i++)
            {
                int StartCursorPosition = rtbMd.SelectionStart;
                MatchCollection mc = rex.Matches(lines[i]);
                foreach (Match m in mc)
                {
                    int startIndex = rtbMd.GetFirstCharIndexFromLine(i) + m.Groups[1].Index;
                    int StopIndex = m.Groups[1].Length;
                    rtbMd.Select(startIndex, StopIndex);
                    rtbMd.SelectionColor = Color.Blue;

                    rtbMd.Select(StartCursorPosition, 0);
                    rtbMd.SelectionColor = Color.Black;
                }
            }
        }
        #endregion


        #region 汎用メソッド============================================================

        private void InitViewListBox()
        {
            tbSearch.Text = "";
            SetViewListBox();
        }

        private void SetViewListBox()
        {
            this.lbMdList.Items.Clear();
            this.lbMdList.DisplayMember = "Key";
            this.lbMdList.ValueMember = "Value";
            this.DirSearch(lbMdList, targetPath, "", false);
        }

        private void SetAssistListBox(string searchWord, bool enableDetailSearch)
        {
            lbAssist.Visible = true;
            this.lbAssist.Items.Clear();
            this.lbAssist.DisplayMember = "Key";
            this.lbAssist.ValueMember = "Value";
            this.DirSearch(lbAssist, targetPath, searchWord, enableDetailSearch);
            var showLength = (this.lbAssist.Items.Count <= 10) ? this.lbAssist.Items.Count : 10;
            if (showLength == 0) lbAssist.Visible = false;
            this.lbAssist.Height = this.lbAssist.ItemHeight * (showLength+1);
        }

        private void DirSearch(ListBox listBox, string sDir, string searchWord, bool enableDetailSearch)
        {
            string[] searchWords = searchWord.Split(' ');
            string[] arrayDir = Directory.GetDirectories(sDir);

            for (int i = 0; i < arrayDir.Length; i++)
            {
                string fullpath = arrayDir[i];
                string key = fullpath.Replace(sDir, "");
                object value = new SelectedFile(true, key, fullpath, "");
                listBox.Items.Add(new DictionaryEntry(key, value));
            }
            string[] array = Directory.GetFiles(sDir);
            for (int i = 0; i < array.Length; i++)
            {
                string fullpath = array[i];
                string extension = Path.GetExtension(fullpath);
                string key = fullpath.Replace(sDir, "");
                object value = new SelectedFile(false, key, fullpath, extension);

                // 無視拡張子
                if (Array.IndexOf(extensionIgnore, extension) != -1) continue;

                if (searchWord == "" || Util.String.MultiContain(fullpath.ToLower(), searchWords))
                {
                    listBox.Items.Add(new DictionaryEntry(key, value));
                }
                else
                {
                    if (enableDetailSearch)
                    {
                        long fileSize = new FileInfo(fullpath).Length;
                        // テキストファイルであれば内容を検索, 1MB以下のファイルのみ
                        if (Array.IndexOf(extensionText, extension) != -1 && fileSize <= 1000000)
                        {
                            if (Util.String.MultiContain(Util.IO.GetFileReadToEnd(fullpath, fileEncode), searchWords))
                            {
                                listBox.Items.Add(new DictionaryEntry(key, value));
                            }
                        }
                    }
                }
            }
        }

        private void openSelectFile()
        {
            selectedFile = getSelectedItem();

            if (selectedFile == null) return;

            this.tbTitle.Text = selectedFile.fileName;
            // テキストファイル
            if (Array.IndexOf(extensionText, selectedFile.extension) != -1)
            {
                tabEditor.Visible = true;

                this.rtbMd.Text = Util.IO.GetFileReadToEnd(selectedFile.fullPath, fileEncode);
            }
            else
            { // それ以外は実行する
                tabEditor.Visible = false;
            }
            lbCautionMessge.Visible = false;
        }

        private SelectedFile getSelectedItem()
        {
            if (this.lbMdList.SelectedItem == null) return null;
            DictionaryEntry dictionaryEntry = (DictionaryEntry)this.lbMdList.SelectedItem;
            SelectedFile file = (SelectedFile)dictionaryEntry.Value;
            return file;
        }

        private void displayMarkDown()
        {
            string content = "";

            Markdown m = new Markdown();
            m.ExtraMode = true;
            content = m.Transform(rtbMd.Text);

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
        border-bottom: 2px solid #cdf;
        font-size: 24px;
        margin-bottom: 12px;
        padding-bottom: 6px;
        padding-top: 8px;
    }
    h2 {
        color: #555;
        border-bottom: 1px solid #cdf;
        font-size: 20px;
        margin-bottom: 6px;
        padding-bottom: 3px;
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
        background:#f0f9ff;
        border: 1px solid #e0e9ff;
        white-space : pre;
        padding:5px;
        color:#036;
    }
    pre {
        background:#f0f9ff;
        border: 1px solid #e0e9ff;
        white-space : pre;
        padding:5px;
        border-radius:4px;
    }
    pre code {
        border: 0px solid #e0e9ff;
        padding:0px;
    }
    blockquote {
        padding: 0px 10px;
        color: #789;
        border-left: 4px solid #dde;
        font-size:80%;
    }
    table {
        border-collapse: collapse;
    }
    th {
        border: solid 1px #ccc;
        background: #f0f9ff;
        color:#666;
    }
    td {
        border:solid 1px #ddd;
    }
    th, td {
        padding:4px;
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
