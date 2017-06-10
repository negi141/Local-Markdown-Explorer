namespace LocalMarkdownExplorer
{
    partial class FormAddRootDir
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
            this.groupBoxPath = new System.Windows.Forms.GroupBox();
            this.tbPathRelative = new System.Windows.Forms.TextBox();
            this.btnRelativeParentPath = new System.Windows.Forms.Button();
            this.btnDirBrowse = new System.Windows.Forms.Button();
            this.rbPathRelative = new System.Windows.Forms.RadioButton();
            this.tbPathAbsolute = new System.Windows.Forms.TextBox();
            this.rbPathAbsolute = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPath
            // 
            this.groupBoxPath.Controls.Add(this.tbPathRelative);
            this.groupBoxPath.Controls.Add(this.btnRelativeParentPath);
            this.groupBoxPath.Controls.Add(this.btnDirBrowse);
            this.groupBoxPath.Controls.Add(this.rbPathRelative);
            this.groupBoxPath.Controls.Add(this.tbPathAbsolute);
            this.groupBoxPath.Controls.Add(this.rbPathAbsolute);
            this.groupBoxPath.Location = new System.Drawing.Point(12, 47);
            this.groupBoxPath.Name = "groupBoxPath";
            this.groupBoxPath.Size = new System.Drawing.Size(377, 119);
            this.groupBoxPath.TabIndex = 10;
            this.groupBoxPath.TabStop = false;
            this.groupBoxPath.Text = "追加するフォルダ";
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
            this.btnRelativeParentPath.Location = new System.Drawing.Point(218, 89);
            this.btnRelativeParentPath.Name = "btnRelativeParentPath";
            this.btnRelativeParentPath.Size = new System.Drawing.Size(75, 23);
            this.btnRelativeParentPath.TabIndex = 0;
            this.btnRelativeParentPath.Text = "上フォルダ";
            this.btnRelativeParentPath.UseVisualStyleBackColor = true;
            this.btnRelativeParentPath.Click += new System.EventHandler(this.btnRelativeParentPath_Click);
            // 
            // btnDirBrowse
            // 
            this.btnDirBrowse.Location = new System.Drawing.Point(315, 42);
            this.btnDirBrowse.Name = "btnDirBrowse";
            this.btnDirBrowse.Size = new System.Drawing.Size(47, 23);
            this.btnDirBrowse.TabIndex = 5;
            this.btnDirBrowse.Text = "参照...";
            this.btnDirBrowse.UseVisualStyleBackColor = true;
            this.btnDirBrowse.Click += new System.EventHandler(this.btnDirBrowse_Click);
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
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(137, 172);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "追加";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(69, 13);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(160, 19);
            this.tbName.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "表示名";
            // 
            // FormAddRootDir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 201);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBoxPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAddRootDir";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ルートフォルダ追加";
            this.Load += new System.EventHandler(this.FormAddRootDir_Load);
            this.groupBoxPath.ResumeLayout(false);
            this.groupBoxPath.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPath;
        private System.Windows.Forms.TextBox tbPathRelative;
        private System.Windows.Forms.Button btnRelativeParentPath;
        private System.Windows.Forms.Button btnDirBrowse;
        private System.Windows.Forms.RadioButton rbPathRelative;
        private System.Windows.Forms.TextBox tbPathAbsolute;
        private System.Windows.Forms.RadioButton rbPathAbsolute;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
    }
}