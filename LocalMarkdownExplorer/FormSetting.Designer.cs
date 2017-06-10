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
            this.groupBoxEncode = new System.Windows.Forms.GroupBox();
            this.groupBoxExtension = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbExtensionIgnore = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbExtensionText = new System.Windows.Forms.TextBox();
            this.groupBoxEncode.SuspendLayout();
            this.groupBoxExtension.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(138, 167);
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
            this.ddlEncoding.Location = new System.Drawing.Point(52, 19);
            this.ddlEncoding.Name = "ddlEncoding";
            this.ddlEncoding.Size = new System.Drawing.Size(121, 20);
            this.ddlEncoding.TabIndex = 1;
            // 
            // groupBoxEncode
            // 
            this.groupBoxEncode.Controls.Add(this.ddlEncoding);
            this.groupBoxEncode.Location = new System.Drawing.Point(12, 12);
            this.groupBoxEncode.Name = "groupBoxEncode";
            this.groupBoxEncode.Size = new System.Drawing.Size(377, 50);
            this.groupBoxEncode.TabIndex = 10;
            this.groupBoxEncode.TabStop = false;
            this.groupBoxEncode.Text = "表示・保存時の文字コード";
            // 
            // groupBoxExtension
            // 
            this.groupBoxExtension.Controls.Add(this.label2);
            this.groupBoxExtension.Controls.Add(this.tbExtensionIgnore);
            this.groupBoxExtension.Controls.Add(this.label1);
            this.groupBoxExtension.Controls.Add(this.tbExtensionText);
            this.groupBoxExtension.Location = new System.Drawing.Point(12, 82);
            this.groupBoxExtension.Name = "groupBoxExtension";
            this.groupBoxExtension.Size = new System.Drawing.Size(377, 79);
            this.groupBoxExtension.TabIndex = 11;
            this.groupBoxExtension.TabStop = false;
            this.groupBoxExtension.Text = "拡張子";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "除外する拡張子：";
            // 
            // tbExtensionIgnore
            // 
            this.tbExtensionIgnore.Location = new System.Drawing.Point(115, 48);
            this.tbExtensionIgnore.Name = "tbExtensionIgnore";
            this.tbExtensionIgnore.Size = new System.Drawing.Size(202, 19);
            this.tbExtensionIgnore.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "テキスト拡張子：";
            // 
            // tbExtensionText
            // 
            this.tbExtensionText.Location = new System.Drawing.Point(115, 23);
            this.tbExtensionText.Name = "tbExtensionText";
            this.tbExtensionText.Size = new System.Drawing.Size(202, 19);
            this.tbExtensionText.TabIndex = 7;
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 197);
            this.Controls.Add(this.groupBoxExtension);
            this.Controls.Add(this.groupBoxEncode);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSetting";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "設定";
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.groupBoxEncode.ResumeLayout(false);
            this.groupBoxExtension.ResumeLayout(false);
            this.groupBoxExtension.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox ddlEncoding;
        private System.Windows.Forms.GroupBox groupBoxEncode;
        private System.Windows.Forms.GroupBox groupBoxExtension;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbExtensionText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbExtensionIgnore;
    }
}