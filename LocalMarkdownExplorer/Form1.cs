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
using Codeplex.Data;
using negi;

namespace LocalMarkdownExplorer
{
    public partial class Form1 : Form
    {
        public string appTitle = "Local-Markdown-Explorer";
        string targetPath;
        public string selectedDirName = "";
        Encoding fileEncode;
        string[] extensionText;
        string[] extensionIgnore;
        bool isFirstLoad = true;
        SelectedFile selectedFile;
        public dynamic config;

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
            string configStr = Util.IO.GetFileReadToEnd("config.json");
            // データがない場合
            if (configStr == "")
            {
                this.config = new
                {
                    paths = new object[]{},
                };
                Util.IO.SaveFile("config.json", DynamicJson.Serialize(config));

                btnAddRootDir_Click(null, null);
            }
            else
            {                
                this.lbCautionMessge.Text = "(内容を変更中)";
                this.lbCautionMessge.Visible = false;

                this.groupBoxFile.Enabled = false;

                this.isFirstLoad = false;
                // コンボボックスに追加
                this.config = DynamicJson.Parse(configStr);
                cbRootDir.Items.Clear();
                foreach (var path in config.paths)
                {
                    cbRootDir.Items.Add(path.name);
                }
                // ある場合
                if (cbRootDir.Items.Count > 0)
                {
                    if (selectedDirName == "")
                    {
                        cbRootDir.SelectedIndex = cbRootDir.Items.Count - 1;
                    }
                    else
                    {
                        cbRootDir.Text = selectedDirName;
                    }
                    btnAdd.Enabled = btnOpenDir.Enabled = tbSearch.Enabled = true;
                }
                else
                {
                    btnAdd.Enabled = btnOpenDir.Enabled = tbSearch.Enabled = false;
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.tbSearch.Focus();
        }
        #endregion

        #region ボタンクリックイベントメソッド============================================================

        private void btnAddRootDir_Click(object sender, EventArgs e)
        {
            FormAddRootDir f = new FormAddRootDir(this);
            f.ShowDialog();
            f.Dispose();
        }

        private void btnEditRootDir_Click(object sender, EventArgs e)
        {
            FormAddRootDir f = new FormAddRootDir(this);
            f.SetEditName(this.cbRootDir.Text);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tbSearch_TextChanged(null, null);
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
            cbRootDir_TextChanged(null, null);
            linkBack.Visible = false;
        }
        private void btnAssistClose_Click(object sender, EventArgs e)
        {
            AssistVisible(false);
        }

        private void btnHighLight_Click(object sender, EventArgs e)
        {
            highLight();
        }
        #endregion


        #region エディターパネル内ボタンクリックイベントメソッド============================================================
        private void btnTextAdd_Code_Click(object sender, EventArgs e)
        {
            textAdd("~~~~~~~~~~~~~~~~");
        }

        private void btnTextAdd_H1_Click(object sender, EventArgs e)
        {
            textAdd("# "); 
        }

        private void btnTextAdd_H2_Click(object sender, EventArgs e)
        {
            textAdd("## ");
        }
        private void btnTextAdd_Li1_Click(object sender, EventArgs e)
        {
            textAdd(" - ");
        }

        private void btnTextAdd_LI2_Click(object sender, EventArgs e)
        {
            textAdd("    - ");
        }
        #endregion


        #region 選択イベントメソッド============================================================

        private void cbRootDir_TextChanged(object sender, EventArgs e)
        {
            var name = this.cbRootDir.Text;
            foreach (var path in config.paths)
            {
                if (name == path.name)
                {
                    if (path.type == "Absolute")
                    {
                        setTargetPath(targetPath = path.AbsolutePath + "\\");
                    }
                    else
                    {
                        setTargetPath(Path.GetFullPath(path.RelativePath));
                    }

                    // エンコーディング
                    fileEncode = Encoding.GetEncoding(path.Encoding);
                    // 拡張子
                    extensionText = path.ExtensionText.Split(',');
                    for (int i = 0; i < extensionText.Length; i++) extensionText[i] = "." + extensionText[i];
                    extensionIgnore = path.ExtensionIgnore.Split(',');
                    for (int i = 0; i < extensionIgnore.Length; i++) extensionIgnore[i] = "." + extensionIgnore[i];

                    SetViewListBox();
                }
            }
        }
        private void lbAssist_MouseUp(object sender, MouseEventArgs e)
        {
            DictionaryEntry dictionaryEntry = (DictionaryEntry)this.lbAssist.SelectedItem;
            this.lbMdList.Text = dictionaryEntry.Key.ToString();
            if (lbAssist.Items.Count <= 1) AssistVisible(false);
        }

        private void lbMdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFile = getSelectedItem();
            if (selectedFile == null) return;

            if (selectedFile.isDirectory)
            {
                setTargetPath(selectedFile.fullPath + "\\");

                this.InitViewListBox();

                linkBack.Visible = true;
            }
            else
            {
                this.groupBoxFile.Enabled = true;
                this.rtbMd.ScrollToCaret();
                openSelectFile();
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

        private void lbAssist_DrawItem(object sender, DrawItemEventArgs e)
        {
            lbAssist.DrawMode = DrawMode.OwnerDrawFixed;
            e.DrawBackground();
            Brush brush = null;
            if ((e.State & DrawItemState.Selected) != DrawItemState.Selected)
            {
                brush = new SolidBrush(Color.Black);
            }
            else
            {
                brush = new SolidBrush(e.ForeColor);
            }
            DictionaryEntry dictionaryEntry = (DictionaryEntry)((ListBox)sender).Items[e.Index];
            SelectedFile file = (SelectedFile)dictionaryEntry.Value;
            e.Graphics.DrawString(file.fileName, e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }
        #endregion


        #region テキストイベントメソッド============================================================

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // 検索フォームで↓を押したら候補リストボックスにフォーカスする
            if (e.KeyCode == Keys.Down)
            {
                if (lbAssist.Visible)
                {
                    lbAssist.SelectedIndex = 0;
                    lbAssist.Focus();
                }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text == "")
            {
                AssistVisible(false);
                return;
            }
            this.SetAssistListBox(this.tbSearch.Text.ToLower(), true);
        }

        private void lbAssist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DictionaryEntry dictionaryEntry = (DictionaryEntry)this.lbAssist.SelectedItem;
                this.lbMdList.Text = dictionaryEntry.Key.ToString();
                if (lbAssist.Items.Count <= 1) AssistVisible(false);
            }
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            if (this.isFirstLoad == false) lbCautionMessge.Visible = true;
        }

        private void rtbMd_TextChanged(object sender, EventArgs e)
        {
            if (this.isFirstLoad == false) lbCautionMessge.Visible = true;
        }

        #endregion


        #region 汎用メソッド============================================================
        
        private void AssistVisible(bool visible)
        {
            lbAssist.Visible = btnAssistClose.Visible = visible; 
        }
        
        private void setTargetPath(string path)
        {
            this.targetPath = path;
            this.Text = appTitle + "  [" + cbRootDir.Text + "]";
        }
        private void textAdd(string addText)
        {
            int index = rtbMd.SelectionStart;
            if (rtbMd.SelectedText.Length == 0)
                rtbMd.SelectedText = addText;
            highLight();
            rtbMd.Select(index+addText.Length, 0);
            rtbMd.Focus();
        }

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
            AssistVisible(true);
            this.lbAssist.Items.Clear();
            this.lbAssist.DisplayMember = "Key";
            this.lbAssist.ValueMember = "Value";
            this.DirSearch(lbAssist, targetPath, searchWord, enableDetailSearch);
            var dispLength = 20;
            var showLength = (this.lbAssist.Items.Count <= dispLength) ? this.lbAssist.Items.Count : dispLength;
            if (showLength == 0) AssistVisible(false);
            this.lbAssist.Height = this.lbAssist.ItemHeight * (showLength+1);
        }

        private void DirSearch(ListBox listBox, string sDir, string searchWord, bool enableDetailSearch)
        {
            try
            {
                string[] searchWords = searchWord.Split(' ');
                string[] arrayDir = Directory.GetDirectories(sDir);


                if (searchWord == "")
                {
                    for (int i = 0; i < arrayDir.Length; i++)
                    {
                        string fullpath = arrayDir[i];
                        string key = fullpath.Replace(sDir, "");
                        object value = new SelectedFile(true, key, fullpath, "");
                        listBox.Items.Add(new DictionaryEntry(key, value));
                    }
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
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
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

        private void highLight()
        {
            rtbMd.Select(0, rtbMd.Text.Length);
            rtbMd.SelectionColor = Color.Black;
            rtbMd.SelectionFont = new Font("MS UI Gothic", 12, FontStyle.Regular);

            string[] lines = rtbMd.Lines;

            Dictionary<string, HWord> hWords = new Dictionary<string, HWord>();
            hWords.Add("midashi1", new HWord(@"(^#.*)", Color.FromArgb(0, 50, 150), FontStyle.Bold, 16));// #
            hWords.Add("midashi2", new HWord(@"(^##.*)", Color.FromArgb(0, 50, 150), FontStyle.Bold, 14));// ##
            hWords.Add("midashi3", new HWord(@"(^###+.*)", Color.FromArgb(0, 50, 150), FontStyle.Bold, 12));// ###
            hWords.Add("code", new HWord(@"(```|^~~~+$|^    [^\*\-]+|`[^`]+`)", Color.FromArgb(0, 120, 20), FontStyle.Regular, 11));// ``` , ~~~ , スペース , ```
            hWords.Add("list", new HWord(@"(^ *\* |^ *\- |[0-9]+\. )", Color.FromArgb(150, 50, 0), FontStyle.Regular, 11));// * , 0. , -
            hWords.Add("string", new HWord(@"(\*\*.+\*\*)", Color.FromArgb(0, 0, 0), FontStyle.Bold, 12));// **～**
            hWords.Add("link", new HWord(@"(\[.+\]\(.+\)|\[[0-9]+\])", Color.FromArgb(0, 50, 200), FontStyle.Regular, 11));// [～](～) , [1]
            hWords.Add("border1", new HWord(@"(^\===+$)", Color.FromArgb(0, 150, 150), FontStyle.Regular, 11));// ===
            hWords.Add("border2", new HWord(@"(^\---+$)", Color.FromArgb(0, 150, 150), FontStyle.Regular, 11));// ---
            hWords.Add("table", new HWord(@"(^\|.+\|$)", Color.FromArgb(0, 150, 150), FontStyle.Regular, 11));// |～～|
            hWords.Add("other", new HWord(@"(^>)", Color.FromArgb(0, 150, 150), FontStyle.Regular, 11));// > 

            for (int i = 0; i < lines.Length; i++)
            {
                int StartCursorPosition = rtbMd.SelectionStart;
                foreach (var hword in hWords)
                {
                    MatchCollection mc = new Regex(hword.Value.token).Matches(lines[i]);
                    foreach (Match m in mc)
                    {
                        int startIndex = rtbMd.GetFirstCharIndexFromLine(i) + m.Groups[1].Index;
                        int length = m.Groups[1].Length;
                        SetTextStyle(startIndex, length, hword.Value);
                        if (i > 0 && lines[i-1] != "")
                        {
                            if (hword.Key == "border1")
                            {
                                startIndex = rtbMd.GetFirstCharIndexFromLine(i - 1);
                                length = lines[i - 1].Length;
                                SetTextStyle(startIndex, length, hWords["midashi1"]);
                            }
                            if (hword.Key == "border2")
                            {
                                startIndex = rtbMd.GetFirstCharIndexFromLine(i - 1);
                                length = lines[i - 1].Length;
                                SetTextStyle(startIndex, length, hWords["midashi2"]);
                            }
                        }
                    }
                }
                rtbMd.Select(StartCursorPosition, 0);
                rtbMd.SelectionColor = Color.Black;
            }
        }

        private void SetTextStyle(int startIndex, int length, HWord Style)
        {
            rtbMd.Select(startIndex, length);
            rtbMd.SelectionColor = Style.color;
            rtbMd.SelectionFont = new Font("MS UI Gothic", Style.fontSize, Style.fontStyle);
        }

        private void displayMarkDown()
        {
            string content = "";

            Markdown m = new Markdown();
            m.ExtraMode = true;
            content = m.Transform(rtbMd.Text);

            // チェック用
            content = new Regex("\t").Replace(content,"    ");
            tbHTML.Text = content.Replace("\n","\r\n");

            string html = @"
<!DOCTYPE html>
<html>
  <head>
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
<style type=""text/css"">
    " + Resource1.default_css + @"
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
        private void btnCredit_Click(object sender, EventArgs e)
        {
            MessageBox.Show(appTitle + "　(version 1.1)\r\n\r\n　　　Takuto Negishi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
