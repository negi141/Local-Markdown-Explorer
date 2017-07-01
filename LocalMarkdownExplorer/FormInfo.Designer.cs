namespace LocalMarkdownExplorer
{
    partial class FormInfo
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
            this.lbAppTitle = new System.Windows.Forms.Label();
            this.lbAppVersion = new System.Windows.Forms.Label();
            this.lbCredit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbAppTitle
            // 
            this.lbAppTitle.AutoSize = true;
            this.lbAppTitle.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbAppTitle.Location = new System.Drawing.Point(49, 13);
            this.lbAppTitle.Name = "lbAppTitle";
            this.lbAppTitle.Size = new System.Drawing.Size(55, 19);
            this.lbAppTitle.TabIndex = 0;
            this.lbAppTitle.Text = "label1";
            // 
            // lbAppVersion
            // 
            this.lbAppVersion.AutoSize = true;
            this.lbAppVersion.Location = new System.Drawing.Point(51, 32);
            this.lbAppVersion.Name = "lbAppVersion";
            this.lbAppVersion.Size = new System.Drawing.Size(35, 12);
            this.lbAppVersion.TabIndex = 1;
            this.lbAppVersion.Text = "label2";
            // 
            // lbCredit
            // 
            this.lbCredit.AutoSize = true;
            this.lbCredit.Location = new System.Drawing.Point(51, 61);
            this.lbCredit.Name = "lbCredit";
            this.lbCredit.Size = new System.Drawing.Size(35, 12);
            this.lbCredit.TabIndex = 2;
            this.lbCredit.Text = "label3";
            // 
            // FormInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 94);
            this.Controls.Add(this.lbCredit);
            this.Controls.Add(this.lbAppVersion);
            this.Controls.Add(this.lbAppTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormInfo";
            this.Text = "Info";
            this.Load += new System.EventHandler(this.FormInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbAppTitle;
        private System.Windows.Forms.Label lbAppVersion;
        private System.Windows.Forms.Label lbCredit;
    }
}