namespace BAI04
{
    partial class MovieItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            picPoster = new PictureBox();
            lblName = new Label();
            linkDetail = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)picPoster).BeginInit();
            SuspendLayout();
            // 
            // picPoster
            // 
            picPoster.Location = new Point(30, 39);
            picPoster.Name = "picPoster";
            picPoster.Size = new Size(199, 93);
            picPoster.TabIndex = 0;
            picPoster.TabStop = false;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(256, 56);
            lblName.Name = "lblName";
            lblName.Size = new Size(95, 25);
            lblName.TabIndex = 1;
            lblName.Text = "Tên phim";
            // 
            // linkDetail
            // 
            linkDetail.AutoSize = true;
            linkDetail.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkDetail.Location = new Point(256, 93);
            linkDetail.Name = "linkDetail";
            linkDetail.Size = new Size(96, 20);
            linkDetail.TabIndex = 2;
            linkDetail.TabStop = true;
            linkDetail.Text = "Xem chi tiết";
            // 
            // MovieItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(linkDetail);
            Controls.Add(lblName);
            Controls.Add(picPoster);
            Name = "MovieItem";
            Size = new Size(434, 169);
            ((System.ComponentModel.ISupportInitialize)picPoster).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picPoster;
        private Label lblName;
        private LinkLabel linkDetail;
    }
}
