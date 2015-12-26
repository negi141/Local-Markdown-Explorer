namespace LocalMarkdownExplorer
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbMdList = new System.Windows.Forms.ListBox();
            this.tabEditor = new System.Windows.Forms.TabControl();
            this.tabText = new System.Windows.Forms.TabPage();
            this.tbMd = new System.Windows.Forms.TextBox();
            this.tabMd = new System.Windows.Forms.TabPage();
            this.webMd = new System.Windows.Forms.WebBrowser();
            this.tabHTML = new System.Windows.Forms.TabPage();
            this.tbHTML = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnOpenDir = new System.Windows.Forms.Button();
            this.lbCautionMessge = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.Button();
            this.tabEditor.SuspendLayout();
            this.tabText.SuspendLayout();
            this.tabMd.SuspendLayout();
            this.tabHTML.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "検索";
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbSearch.Location = new System.Drawing.Point(48, 51);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(232, 23);
            this.tbSearch.TabIndex = 31;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(77, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(126, 28);
            this.btnAdd.TabIndex = 30;
            this.btnAdd.Text = "作成";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbMdList
            // 
            this.lbMdList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMdList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbMdList.FormattingEnabled = true;
            this.lbMdList.Location = new System.Drawing.Point(12, 85);
            this.lbMdList.Name = "lbMdList";
            this.lbMdList.Size = new System.Drawing.Size(302, 524);
            this.lbMdList.TabIndex = 28;
            this.lbMdList.SelectedIndexChanged += new System.EventHandler(this.lbMdList_SelectedIndexChanged);
            // 
            // tabEditor
            // 
            this.tabEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabEditor.Controls.Add(this.tabText);
            this.tabEditor.Controls.Add(this.tabMd);
            this.tabEditor.Controls.Add(this.tabHTML);
            this.tabEditor.Location = new System.Drawing.Point(322, 85);
            this.tabEditor.Name = "tabEditor";
            this.tabEditor.SelectedIndex = 0;
            this.tabEditor.Size = new System.Drawing.Size(590, 534);
            this.tabEditor.TabIndex = 48;
            this.tabEditor.SelectedIndexChanged += new System.EventHandler(this.tabEditor_SelectedIndexChanged);
            // 
            // tabText
            // 
            this.tabText.Controls.Add(this.tbMd);
            this.tabText.Location = new System.Drawing.Point(4, 22);
            this.tabText.Name = "tabText";
            this.tabText.Padding = new System.Windows.Forms.Padding(3);
            this.tabText.Size = new System.Drawing.Size(582, 508);
            this.tabText.TabIndex = 0;
            this.tabText.Text = "　　Text Editor　　";
            this.tabText.UseVisualStyleBackColor = true;
            // 
            // tbMd
            // 
            this.tbMd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMd.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbMd.Location = new System.Drawing.Point(6, 11);
            this.tbMd.Multiline = true;
            this.tbMd.Name = "tbMd";
            this.tbMd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMd.Size = new System.Drawing.Size(757, 756);
            this.tbMd.TabIndex = 30;
            this.tbMd.TextChanged += new System.EventHandler(this.tbMd_TextChanged);
            // 
            // tabMd
            // 
            this.tabMd.Controls.Add(this.webMd);
            this.tabMd.Location = new System.Drawing.Point(4, 22);
            this.tabMd.Name = "tabMd";
            this.tabMd.Padding = new System.Windows.Forms.Padding(3);
            this.tabMd.Size = new System.Drawing.Size(582, 508);
            this.tabMd.TabIndex = 1;
            this.tabMd.Text = " MarkdownViewer ";
            this.tabMd.UseVisualStyleBackColor = true;
            // 
            // webMd
            // 
            this.webMd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webMd.Location = new System.Drawing.Point(3, 3);
            this.webMd.MinimumSize = new System.Drawing.Size(20, 20);
            this.webMd.Name = "webMd";
            this.webMd.Size = new System.Drawing.Size(576, 502);
            this.webMd.TabIndex = 0;
            // 
            // tabHTML
            // 
            this.tabHTML.Controls.Add(this.tbHTML);
            this.tabHTML.Location = new System.Drawing.Point(4, 22);
            this.tabHTML.Name = "tabHTML";
            this.tabHTML.Padding = new System.Windows.Forms.Padding(3);
            this.tabHTML.Size = new System.Drawing.Size(582, 508);
            this.tabHTML.TabIndex = 2;
            this.tabHTML.Text = "　　HTML Output　　";
            this.tabHTML.UseVisualStyleBackColor = true;
            // 
            // tbHTML
            // 
            this.tbHTML.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHTML.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbHTML.Location = new System.Drawing.Point(6, 6);
            this.tbHTML.Multiline = true;
            this.tbHTML.Name = "tbHTML";
            this.tbHTML.ReadOnly = true;
            this.tbHTML.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbHTML.Size = new System.Drawing.Size(563, 482);
            this.tbHTML.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 12);
            this.label2.TabIndex = 47;
            this.label2.Text = "ファイル名";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnDelete.Location = new System.Drawing.Point(788, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 29);
            this.btnDelete.TabIndex = 46;
            this.btnDelete.Text = "削除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tbTitle
            // 
            this.tbTitle.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbTitle.Location = new System.Drawing.Point(377, 51);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(382, 23);
            this.tbTitle.TabIndex = 45;
            this.tbTitle.TextChanged += new System.EventHandler(this.tbTitle_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(322, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(233, 29);
            this.btnSave.TabIndex = 44;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(616, 13);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(93, 28);
            this.btnOpenFile.TabIndex = 49;
            this.btnOpenFile.Text = "ファイルを開く";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnOpenDir
            // 
            this.btnOpenDir.Location = new System.Drawing.Point(218, 12);
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.Size = new System.Drawing.Size(81, 28);
            this.btnOpenDir.TabIndex = 50;
            this.btnOpenDir.Text = "フォルダを開く";
            this.btnOpenDir.UseVisualStyleBackColor = true;
            this.btnOpenDir.Click += new System.EventHandler(this.btnOpenDir_Click);
            // 
            // lbCautionMessge
            // 
            this.lbCautionMessge.AutoSize = true;
            this.lbCautionMessge.ForeColor = System.Drawing.Color.Tomato;
            this.lbCautionMessge.Location = new System.Drawing.Point(772, 58);
            this.lbCautionMessge.Name = "lbCautionMessge";
            this.lbCautionMessge.Size = new System.Drawing.Size(92, 12);
            this.lbCautionMessge.TabIndex = 51;
            this.lbCautionMessge.Text = "lbCautionMessge";
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(12, 12);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(49, 28);
            this.btnSetting.TabIndex = 52;
            this.btnSetting.Text = "設定";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 631);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.lbCautionMessge);
            this.Controls.Add(this.btnOpenDir);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.tabEditor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbMdList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "LocalMarkDownSearcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabEditor.ResumeLayout(false);
            this.tabText.ResumeLayout(false);
            this.tabText.PerformLayout();
            this.tabMd.ResumeLayout(false);
            this.tabHTML.ResumeLayout(false);
            this.tabHTML.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lbMdList;
        private System.Windows.Forms.TabControl tabEditor;
        private System.Windows.Forms.TabPage tabText;
        private System.Windows.Forms.TextBox tbMd;
        private System.Windows.Forms.TabPage tabMd;
        private System.Windows.Forms.WebBrowser webMd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnOpenDir;
        private System.Windows.Forms.Label lbCautionMessge;
        private System.Windows.Forms.TabPage tabHTML;
        private System.Windows.Forms.TextBox tbHTML;
        private System.Windows.Forms.Button btnSetting;
    }
}

