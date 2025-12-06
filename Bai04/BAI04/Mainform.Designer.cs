namespace BAI04
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblphim = new Label();
            flowMovies = new FlowLayoutPanel();
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // lblphim
            // 
            lblphim.AutoSize = true;
            lblphim.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblphim.Location = new Point(28, 20);
            lblphim.Name = "lblphim";
            lblphim.Size = new Size(176, 28);
            lblphim.TabIndex = 0;
            lblphim.Text = "Phim đang chiếu";
            // 
            // flowMovies
            // 
            flowMovies.AutoScroll = true;
            flowMovies.Location = new Point(364, -3);
            flowMovies.Name = "flowMovies";
            flowMovies.Size = new Size(623, 479);
            flowMovies.TabIndex = 1;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(28, 434);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(330, 29);
            progressBar1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 475);
            Controls.Add(progressBar1);
            Controls.Add(flowMovies);
            Controls.Add(lblphim);
            Name = "Form1";
            Text = "Mainform";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblphim;
        private FlowLayoutPanel flowMovies;
        private ProgressBar progressBar1;
    }
}
