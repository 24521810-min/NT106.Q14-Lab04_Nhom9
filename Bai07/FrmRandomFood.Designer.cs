namespace Bai07
{
    partial class FrmRandomFood
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblNameTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(20, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(230, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(270, 70);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(250, 30);
            this.lblName.TabIndex = 2;
            // 
            // lblPrice
            // 
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPrice.Location = new System.Drawing.Point(270, 110);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(250, 25);
            this.lblPrice.TabIndex = 3;
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAddress.Location = new System.Drawing.Point(270, 140);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(250, 25);
            this.lblAddress.TabIndex = 4;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUser.Location = new System.Drawing.Point(270, 170);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(250, 25);
            this.lblUser.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(220, 270);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 40);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNameTitle.Location = new System.Drawing.Point(270, 40);
            this.lblNameTitle.Name = "lblNameTitle";
            this.lblNameTitle.Size = new System.Drawing.Size(250, 25);
            this.lblNameTitle.TabIndex = 1;
            this.lblNameTitle.Text = "Tên món:";
            // 
            // FrmRandomFood
            // 
            this.ClientSize = new System.Drawing.Size(550, 360);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblNameTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnOK);
            this.Name = "FrmRandomFood";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Món ăn gợi ý";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblNameTitle;
        private System.Windows.Forms.Button btnOK;
    }
}
