namespace Bai03
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.webView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnDownHtml = new System.Windows.Forms.Button();
            this.btnDownResources = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.webView2)).BeginInit();
            this.SuspendLayout();
            // 
            // webView2
            // 
            this.webView2.AllowExternalDrop = true;
            this.webView2.CreationProperties = null;
            this.webView2.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView2.Location = new System.Drawing.Point(12, 129);
            this.webView2.Name = "webView2";
            this.webView2.Size = new System.Drawing.Size(813, 355);
            this.webView2.TabIndex = 0;
            this.webView2.ZoomFactor = 1D;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(147, 16);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(526, 31);
            this.txtUrl.TabIndex = 1;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(12, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(129, 38);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Load";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click_1);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(679, 12);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(146, 41);
            this.btnReload.TabIndex = 3;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            // 
            // btnDownHtml
            // 
            this.btnDownHtml.Location = new System.Drawing.Point(367, 59);
            this.btnDownHtml.Name = "btnDownHtml";
            this.btnDownHtml.Size = new System.Drawing.Size(206, 54);
            this.btnDownHtml.TabIndex = 4;
            this.btnDownHtml.Text = "Down Files";
            this.btnDownHtml.UseVisualStyleBackColor = true;
            // 
            // btnDownResources
            // 
            this.btnDownResources.Location = new System.Drawing.Point(579, 59);
            this.btnDownResources.Name = "btnDownResources";
            this.btnDownResources.Size = new System.Drawing.Size(246, 54);
            this.btnDownResources.TabIndex = 5;
            this.btnDownResources.Text = "Down Resources";
            this.btnDownResources.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(837, 496);
            this.Controls.Add(this.btnDownResources);
            this.Controls.Add(this.btnDownHtml);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.webView2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.webView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView2;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnDownHtml;
        private System.Windows.Forms.Button btnDownResources;
    }
}