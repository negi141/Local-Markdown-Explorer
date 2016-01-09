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
            this.lbMdList = new System.Windows.Forms.ListBox();
            this.tabEditor = new System.Windows.Forms.TabControl();
            this.tabText = new System.Windows.Forms.TabPage();
            this.tbMd = new System.Windows.Forms.TextBox();
            this.tabMd = new System.Windows.Forms.TabPage();
            this.webMd = new System.Windows.Forms.WebBrowser();
            this.tabHTML = new System.Windows.Forms.TabPage();
            this.tbHTML = new System.Windows.Forms.TextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.lbCautionMessge = new System.Windows.Forms.Label();
            this.groupBoxFile = new System.Windows.Forms.GroupBox();
            this.lbAssist = new System.Windows.Forms.ListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnOpenDir = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.linkBack = new System.Windows.Forms.LinkLabel();
            this.tabEditor.SuspendLayout();
            this.tabText.SuspendLayout();
            this.tabMd.SuspendLayout();
            this.tabHTML.SuspendLayout();
            this.groupBoxFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "検索";
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbSearch.Location = new System.Drawing.Point(48, 46);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(232, 23);
            this.tbSearch.TabIndex = 20;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // lbMdList
            // 
            this.lbMdList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMdList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbMdList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbMdList.FormattingEnabled = true;
            this.lbMdList.ItemHeight = 16;
            this.lbMdList.Location = new System.Drawing.Point(12, 86);
            this.lbMdList.Name = "lbMdList";
            this.lbMdList.Size = new System.Drawing.Size(287, 532);
            this.lbMdList.TabIndex = 25;
            this.lbMdList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbMdList_DrawItem);
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
            this.tabEditor.Location = new System.Drawing.Point(7, 56);
            this.tabEditor.Name = "tabEditor";
            this.tabEditor.SelectedIndex = 0;
            this.tabEditor.Size = new System.Drawing.Size(614, 555);
            this.tabEditor.TabIndex = 50;
            this.tabEditor.SelectedIndexChanged += new System.EventHandler(this.tabEditor_SelectedIndexChanged);
            // 
            // tabText
            // 
            this.tabText.Controls.Add(this.tbMd);
            this.tabText.Location = new System.Drawing.Point(4, 22);
            this.tabText.Name = "tabText";
            this.tabText.Padding = new System.Windows.Forms.Padding(3);
            this.tabText.Size = new System.Drawing.Size(606, 529);
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
            this.tbMd.Location = new System.Drawing.Point(6, 6);
            this.tbMd.Multiline = true;
            this.tbMd.Name = "tbMd";
            this.tbMd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMd.Size = new System.Drawing.Size(594, 517);
            this.tbMd.TabIndex = 30;
            this.tbMd.TextChanged += new System.EventHandler(this.tbMd_TextChanged);
            // 
            // tabMd
            // 
            this.tabMd.Controls.Add(this.webMd);
            this.tabMd.Location = new System.Drawing.Point(4, 22);
            this.tabMd.Name = "tabMd";
            this.tabMd.Padding = new System.Windows.Forms.Padding(3);
            this.tabMd.Size = new System.Drawing.Size(606, 529);
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
            this.webMd.Size = new System.Drawing.Size(600, 523);
            this.webMd.TabIndex = 0;
            // 
            // tabHTML
            // 
            this.tabHTML.Controls.Add(this.tbHTML);
            this.tabHTML.Location = new System.Drawing.Point(4, 22);
            this.tabHTML.Name = "tabHTML";
            this.tabHTML.Padding = new System.Windows.Forms.Padding(3);
            this.tabHTML.Size = new System.Drawing.Size(606, 529);
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
            // tbTitle
            // 
            this.tbTitle.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbTitle.Location = new System.Drawing.Point(11, 23);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(324, 23);
            this.tbTitle.TabIndex = 30;
            this.tbTitle.TextChanged += new System.EventHandler(this.tbTitle_TextChanged);
            // 
            // lbCautionMessge
            // 
            this.lbCautionMessge.AutoSize = true;
            this.lbCautionMessge.ForeColor = System.Drawing.Color.Tomato;
            this.lbCautionMessge.Location = new System.Drawing.Point(42, 0);
            this.lbCautionMessge.Name = "lbCautionMessge";
            this.lbCautionMessge.Size = new System.Drawing.Size(92, 12);
            this.lbCautionMessge.TabIndex = 51;
            this.lbCautionMessge.Text = "lbCautionMessge";
            // 
            // groupBoxFile
            // 
            this.groupBoxFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFile.Controls.Add(this.btnDelete);
            this.groupBoxFile.Controls.Add(this.lbCautionMessge);
            this.groupBoxFile.Controls.Add(this.btnSave);
            this.groupBoxFile.Controls.Add(this.tbTitle);
            this.groupBoxFile.Controls.Add(this.btnOpenFile);
            this.groupBoxFile.Controls.Add(this.tabEditor);
            this.groupBoxFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBoxFile.Location = new System.Drawing.Point(305, 5);
            this.groupBoxFile.Name = "groupBoxFile";
            this.groupBoxFile.Size = new System.Drawing.Size(629, 617);
            this.groupBoxFile.TabIndex = 53;
            this.groupBoxFile.TabStop = false;
            this.groupBoxFile.Text = "ファイル";
            // 
            // lbAssist
            // 
            this.lbAssist.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbAssist.FormattingEnabled = true;
            this.lbAssist.Location = new System.Drawing.Point(48, 68);
            this.lbAssist.Name = "lbAssist";
            this.lbAssist.Size = new System.Drawing.Size(285, 17);
            this.lbAssist.TabIndex = 54;
            this.lbAssist.Visible = false;
            this.lbAssist.SelectedIndexChanged += new System.EventHandler(this.lbAssist_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::LocalMarkdownExplorer.Resource1.DeleteHS;
            this.btnDelete.Location = new System.Drawing.Point(505, 21);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(56, 26);
            this.btnDelete.TabIndex = 45;
            this.btnDelete.Text = "削除";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::LocalMarkdownExplorer.Resource1.saveHS;
            this.btnSave.Location = new System.Drawing.Point(341, 21);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 26);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "保存";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Image = global::LocalMarkdownExplorer.Resource1.RightToLeftDoucmentHS;
            this.btnOpenFile.Location = new System.Drawing.Point(406, 21);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(93, 26);
            this.btnOpenFile.TabIndex = 40;
            this.btnOpenFile.Text = "ファイルを開く";
            this.btnOpenFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Image = global::LocalMarkdownExplorer.Resource1.properties_16xMD;
            this.btnSetting.Location = new System.Drawing.Point(12, 12);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(58, 26);
            this.btnSetting.TabIndex = 5;
            this.btnSetting.Text = "設定";
            this.btnSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnOpenDir
            // 
            this.btnOpenDir.Image = global::LocalMarkdownExplorer.Resource1.FolderOpen_16x16_72;
            this.btnOpenDir.Location = new System.Drawing.Point(169, 12);
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.Size = new System.Drawing.Size(98, 26);
            this.btnOpenDir.TabIndex = 15;
            this.btnOpenDir.Text = "フォルダを開く";
            this.btnOpenDir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpenDir.UseVisualStyleBackColor = true;
            this.btnOpenDir.Click += new System.EventHandler(this.btnOpenDir_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::LocalMarkdownExplorer.Resource1.NewDocumentHS;
            this.btnAdd.Location = new System.Drawing.Point(76, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 26);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "新規作成";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // linkBack
            // 
            this.linkBack.AutoSize = true;
            this.linkBack.Location = new System.Drawing.Point(15, 73);
            this.linkBack.Name = "linkBack";
            this.linkBack.Size = new System.Drawing.Size(38, 12);
            this.linkBack.TabIndex = 55;
            this.linkBack.TabStop = true;
            this.linkBack.Text = "＜戻る";
            this.linkBack.Visible = false;
            this.linkBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBack_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 631);
            this.Controls.Add(this.linkBack);
            this.Controls.Add(this.lbAssist);
            this.Controls.Add(this.groupBoxFile);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnOpenDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbMdList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "LocalMarkDownSearcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tabEditor.ResumeLayout(false);
            this.tabText.ResumeLayout(false);
            this.tabText.PerformLayout();
            this.tabMd.ResumeLayout(false);
            this.tabHTML.ResumeLayout(false);
            this.tabHTML.PerformLayout();
            this.groupBoxFile.ResumeLayout(false);
            this.groupBoxFile.PerformLayout();
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
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnOpenDir;
        private System.Windows.Forms.Label lbCautionMessge;
        private System.Windows.Forms.TabPage tabHTML;
        private System.Windows.Forms.TextBox tbHTML;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.GroupBox groupBoxFile;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox lbAssist;
        private System.Windows.Forms.LinkLabel linkBack;
    }
}

