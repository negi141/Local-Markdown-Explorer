namespace LocalMarkdownExplorer
{
    partial class FormSetting
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
            this.btnSave = new System.Windows.Forms.Button();
            this.ddlEncoding = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnDirBrowse = new System.Windows.Forms.Button();
            this.tbPathAbsolute = new System.Windows.Forms.TextBox();
            this.rbPathAbsolute = new System.Windows.Forms.RadioButton();
            this.rbPathRelative = new System.Windows.Forms.RadioButton();
            this.groupBoxPath = new System.Windows.Forms.GroupBox();
            this.tbPathRelative = new System.Windows.Forms.TextBox();
            this.btnRelativeParentPath = new System.Windows.Forms.Button();
            this.groupBoxEncode = new System.Windows.Forms.GroupBox();
            this.groupBoxPath.SuspendLayout();
            this.groupBoxEncode.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(138, 219);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ddlEncoding
            // 
            this.ddlEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlEncoding.FormattingEnabled = true;
            this.ddlEncoding.Items.AddRange(new object[] {
            "Shift_JIS",
            "UTF-8"});
            this.ddlEncoding.Location = new System.Drawing.Point(52, 28);
            this.ddlEncoding.Name = "ddlEncoding";
            this.ddlEncoding.Size = new System.Drawing.Size(121, 20);
            this.ddlEncoding.TabIndex = 1;
            // 
            // btnDirBrowse
            // 
            this.btnDirBrowse.Location = new System.Drawing.Point(315, 40);
            this.btnDirBrowse.Name = "btnDirBrowse";
            this.btnDirBrowse.Size = new System.Drawing.Size(47, 23);
            this.btnDirBrowse.TabIndex = 5;
            this.btnDirBrowse.Text = "参照...";
            this.btnDirBrowse.UseVisualStyleBackColor = true;
            this.btnDirBrowse.Click += new System.EventHandler(this.btnDirBrowse_Click);
            // 
            // tbPathAbsolute
            // 
            this.tbPathAbsolute.Location = new System.Drawing.Point(52, 44);
            this.tbPathAbsolute.Name = "tbPathAbsolute";
            this.tbPathAbsolute.Size = new System.Drawing.Size(257, 19);
            this.tbPathAbsolute.TabIndex = 6;
            // 
            // rbPathAbsolute
            // 
            this.rbPathAbsolute.AutoSize = true;
            this.rbPathAbsolute.Location = new System.Drawing.Point(23, 22);
            this.rbPathAbsolute.Name = "rbPathAbsolute";
            this.rbPathAbsolute.Size = new System.Drawing.Size(100, 16);
            this.rbPathAbsolute.TabIndex = 7;
            this.rbPathAbsolute.TabStop = true;
            this.rbPathAbsolute.Text = "絶対パスで指定";
            this.rbPathAbsolute.UseVisualStyleBackColor = true;
            // 
            // rbPathRelative
            // 
            this.rbPathRelative.AutoSize = true;
            this.rbPathRelative.Location = new System.Drawing.Point(23, 69);
            this.rbPathRelative.Name = "rbPathRelative";
            this.rbPathRelative.Size = new System.Drawing.Size(100, 16);
            this.rbPathRelative.TabIndex = 8;
            this.rbPathRelative.TabStop = true;
            this.rbPathRelative.Text = "相対パスで指定";
            this.rbPathRelative.UseVisualStyleBackColor = true;
            // 
            // groupBoxPath
            // 
            this.groupBoxPath.Controls.Add(this.tbPathRelative);
            this.groupBoxPath.Controls.Add(this.btnRelativeParentPath);
            this.groupBoxPath.Controls.Add(this.btnDirBrowse);
            this.groupBoxPath.Controls.Add(this.rbPathRelative);
            this.groupBoxPath.Controls.Add(this.tbPathAbsolute);
            this.groupBoxPath.Controls.Add(this.rbPathAbsolute);
            this.groupBoxPath.Location = new System.Drawing.Point(12, 12);
            this.groupBoxPath.Name = "groupBoxPath";
            this.groupBoxPath.Size = new System.Drawing.Size(377, 119);
            this.groupBoxPath.TabIndex = 9;
            this.groupBoxPath.TabStop = false;
            this.groupBoxPath.Text = "表示するフォルダ";
            // 
            // tbPathRelative
            // 
            this.tbPathRelative.Location = new System.Drawing.Point(52, 91);
            this.tbPathRelative.Name = "tbPathRelative";
            this.tbPathRelative.Size = new System.Drawing.Size(160, 19);
            this.tbPathRelative.TabIndex = 11;
            // 
            // btnRelativeParentPath
            // 
            this.btnRelativeParentPath.Location = new System.Drawing.Point(218, 87);
            this.btnRelativeParentPath.Name = "btnRelativeParentPath";
            this.btnRelativeParentPath.Size = new System.Drawing.Size(75, 23);
            this.btnRelativeParentPath.TabIndex = 0;
            this.btnRelativeParentPath.Text = "上フォルダ";
            this.btnRelativeParentPath.UseVisualStyleBackColor = true;
            this.btnRelativeParentPath.Click += new System.EventHandler(this.btnRelativeParentPath_Click);
            // 
            // groupBoxEncode
            // 
            this.groupBoxEncode.Controls.Add(this.ddlEncoding);
            this.groupBoxEncode.Location = new System.Drawing.Point(12, 149);
            this.groupBoxEncode.Name = "groupBoxEncode";
            this.groupBoxEncode.Size = new System.Drawing.Size(377, 64);
            this.groupBoxEncode.TabIndex = 10;
            this.groupBoxEncode.TabStop = false;
            this.groupBoxEncode.Text = "表示・保存時の文字コード";
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 249);
            this.Controls.Add(this.groupBoxEncode);
            this.Controls.Add(this.groupBoxPath);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSetting";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "設定";
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.groupBoxPath.ResumeLayout(false);
            this.groupBoxPath.PerformLayout();
            this.groupBoxEncode.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox ddlEncoding;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnDirBrowse;
        private System.Windows.Forms.TextBox tbPathAbsolute;
        private System.Windows.Forms.RadioButton rbPathAbsolute;
        private System.Windows.Forms.RadioButton rbPathRelative;
        private System.Windows.Forms.GroupBox groupBoxPath;
        private System.Windows.Forms.TextBox tbPathRelative;
        private System.Windows.Forms.Button btnRelativeParentPath;
        private System.Windows.Forms.GroupBox groupBoxEncode;
    }
}