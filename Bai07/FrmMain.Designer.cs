namespace Bai07
{
    partial class FrmMain
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAnGiGio = new System.Windows.Forms.Button();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.tabFoods = new System.Windows.Forms.TabControl();
            this.tabAll = new System.Windows.Forms.TabPage();
            this.tabMine = new System.Windows.Forms.TabPage();
            this.flpAllFoods = new System.Windows.Forms.FlowLayoutPanel();
            this.flpMyFoods = new System.Windows.Forms.FlowLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblWelcome = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslLogout = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelPaging = new System.Windows.Forms.Panel();
            this.lblPageText = new System.Windows.Forms.Label();
            this.numPage = new System.Windows.Forms.NumericUpDown();
            this.lblPageSizeText = new System.Windows.Forms.Label();
            this.numPageSize = new System.Windows.Forms.NumericUpDown();
            this.panelHeader.SuspendLayout();
            this.tabFoods.SuspendLayout();
            this.tabAll.SuspendLayout();
            this.tabMine.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelPaging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.btnThemMon);
            this.panelHeader.Controls.Add(this.btnAnGiGio);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Location = new System.Drawing.Point(12, 13);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(759, 106);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.IndianRed;
            this.lblTitle.Location = new System.Drawing.Point(3, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(239, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HÔM NAY ĂN GÌ?";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAnGiGio
            // 
            this.btnAnGiGio.BackColor = System.Drawing.SystemColors.Info;
            this.btnAnGiGio.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnGiGio.Location = new System.Drawing.Point(366, 34);
            this.btnAnGiGio.Name = "btnAnGiGio";
            this.btnAnGiGio.Size = new System.Drawing.Size(190, 58);
            this.btnAnGiGio.TabIndex = 1;
            this.btnAnGiGio.Text = "Ăn gì giờ?";
            this.btnAnGiGio.UseVisualStyleBackColor = false;
            // 
            // btnThemMon
            // 
            this.btnThemMon.BackColor = System.Drawing.SystemColors.Info;
            this.btnThemMon.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMon.Location = new System.Drawing.Point(562, 34);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(190, 58);
            this.btnThemMon.TabIndex = 2;
            this.btnThemMon.Text = "Thêm món ăn";
            this.btnThemMon.UseVisualStyleBackColor = false;
            // 
            // tabFoods
            // 
            this.tabFoods.Controls.Add(this.tabAll);
            this.tabFoods.Controls.Add(this.tabMine);
            this.tabFoods.Location = new System.Drawing.Point(22, 125);
            this.tabFoods.Name = "tabFoods";
            this.tabFoods.SelectedIndex = 0;
            this.tabFoods.Size = new System.Drawing.Size(766, 502);
            this.tabFoods.TabIndex = 1;
            // 
            // tabAll
            // 
            this.tabAll.Controls.Add(this.flpAllFoods);
            this.tabAll.Location = new System.Drawing.Point(8, 39);
            this.tabAll.Name = "tabAll";
            this.tabAll.Padding = new System.Windows.Forms.Padding(3);
            this.tabAll.Size = new System.Drawing.Size(750, 455);
            this.tabAll.TabIndex = 0;
            this.tabAll.Text = "All";
            this.tabAll.UseVisualStyleBackColor = true;
            // 
            // tabMine
            // 
            this.tabMine.Controls.Add(this.flpMyFoods);
            this.tabMine.Location = new System.Drawing.Point(8, 39);
            this.tabMine.Name = "tabMine";
            this.tabMine.Padding = new System.Windows.Forms.Padding(3);
            this.tabMine.Size = new System.Drawing.Size(750, 455);
            this.tabMine.TabIndex = 1;
            this.tabMine.Text = "Tôi đóng góp";
            this.tabMine.UseVisualStyleBackColor = true;
            // 
            // flpAllFoods
            // 
            this.flpAllFoods.AutoScroll = true;
            this.flpAllFoods.Location = new System.Drawing.Point(6, 6);
            this.flpAllFoods.Name = "flpAllFoods";
            this.flpAllFoods.Size = new System.Drawing.Size(728, 443);
            this.flpAllFoods.TabIndex = 0;
            // 
            // flpMyFoods
            // 
            this.flpMyFoods.AutoScroll = true;
            this.flpMyFoods.Location = new System.Drawing.Point(6, 6);
            this.flpMyFoods.Name = "flpMyFoods";
            this.flpMyFoods.Size = new System.Drawing.Size(735, 443);
            this.flpMyFoods.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblWelcome,
            this.tslLogout});
            this.statusStrip1.Location = new System.Drawing.Point(0, 674);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 42);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblWelcome
            // 
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(113, 32);
            this.lblWelcome.Text = "Welcome";
            // 
            // tslLogout
            // 
            this.tslLogout.IsLink = true;
            this.tslLogout.Name = "tslLogout";
            this.tslLogout.Size = new System.Drawing.Size(89, 32);
            this.tslLogout.Text = "Logout";
            // 
            // panelPaging
            // 
            this.panelPaging.Controls.Add(this.numPageSize);
            this.panelPaging.Controls.Add(this.lblPageSizeText);
            this.panelPaging.Controls.Add(this.numPage);
            this.panelPaging.Controls.Add(this.lblPageText);
            this.panelPaging.Location = new System.Drawing.Point(12, 625);
            this.panelPaging.Name = "panelPaging";
            this.panelPaging.Size = new System.Drawing.Size(776, 46);
            this.panelPaging.TabIndex = 3;
            // 
            // lblPageText
            // 
            this.lblPageText.AutoSize = true;
            this.lblPageText.Location = new System.Drawing.Point(330, 12);
            this.lblPageText.Name = "lblPageText";
            this.lblPageText.Size = new System.Drawing.Size(62, 25);
            this.lblPageText.TabIndex = 0;
            this.lblPageText.Text = "Page";
            // 
            // numPage
            // 
            this.numPage.Location = new System.Drawing.Point(398, 6);
            this.numPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPage.Name = "numPage";
            this.numPage.Size = new System.Drawing.Size(120, 31);
            this.numPage.TabIndex = 1;
            this.numPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPageSizeText
            // 
            this.lblPageSizeText.AutoSize = true;
            this.lblPageSizeText.Location = new System.Drawing.Point(524, 8);
            this.lblPageSizeText.Name = "lblPageSizeText";
            this.lblPageSizeText.Size = new System.Drawing.Size(107, 25);
            this.lblPageSizeText.TabIndex = 2;
            this.lblPageSizeText.Text = "Page size";
            // 
            // numPageSize
            // 
            this.numPageSize.Location = new System.Drawing.Point(637, 6);
            this.numPageSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPageSize.Name = "numPageSize";
            this.numPageSize.Size = new System.Drawing.Size(120, 31);
            this.numPageSize.TabIndex = 3;
            this.numPageSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 716);
            this.Controls.Add(this.panelPaging);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabFoods);
            this.Controls.Add(this.panelHeader);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hôm nay ăn gì?";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tabFoods.ResumeLayout(false);
            this.tabAll.ResumeLayout(false);
            this.tabMine.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelPaging.ResumeLayout(false);
            this.panelPaging.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Button btnAnGiGio;
        private System.Windows.Forms.TabControl tabFoods;
        private System.Windows.Forms.TabPage tabAll;
        private System.Windows.Forms.FlowLayoutPanel flpAllFoods;
        private System.Windows.Forms.TabPage tabMine;
        private System.Windows.Forms.FlowLayoutPanel flpMyFoods;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblWelcome;
        private System.Windows.Forms.ToolStripStatusLabel tslLogout;
        private System.Windows.Forms.Panel panelPaging;
        private System.Windows.Forms.Label lblPageText;
        private System.Windows.Forms.NumericUpDown numPageSize;
        private System.Windows.Forms.Label lblPageSizeText;
        private System.Windows.Forms.NumericUpDown numPage;
    }
}