namespace BAI04
{
    partial class Chitietphim
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
            picPoster = new PictureBox();
            lblDirector = new Label();
            lblActors = new Label();
            lblGenre = new Label();
            lblDuration = new Label();
            label5 = new Label();
            lblName = new Label();
            btnXem = new Button();
            textBox1 = new TextBox();
            lblgia = new Label();
            btndat = new Button();
            ((System.ComponentModel.ISupportInitialize)picPoster).BeginInit();
            SuspendLayout();
            // 
            // picPoster
            // 
            picPoster.BackColor = SystemColors.ControlLight;
            picPoster.Location = new Point(31, 74);
            picPoster.Name = "picPoster";
            picPoster.Size = new Size(150, 175);
            picPoster.TabIndex = 0;
            picPoster.TabStop = false;
            // 
            // lblDirector
            // 
            lblDirector.AutoSize = true;
            lblDirector.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lblDirector.Location = new Point(31, 270);
            lblDirector.Name = "lblDirector";
            lblDirector.Size = new Size(87, 25);
            lblDirector.TabIndex = 1;
            lblDirector.Text = "Đạo diễn";
            // 
            // lblActors
            // 
            lblActors.AutoSize = true;
            lblActors.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lblActors.Location = new Point(31, 312);
            lblActors.Name = "lblActors";
            lblActors.Size = new Size(91, 25);
            lblActors.TabIndex = 2;
            lblActors.Text = "Diễn viên";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lblGenre.Location = new Point(31, 356);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(77, 25);
            lblGenre.TabIndex = 3;
            lblGenre.Text = "Thể loại";
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lblDuration.Location = new Point(31, 396);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(102, 25);
            lblDuration.TabIndex = 4;
            lblDuration.Text = "Thời lượng";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(31, 28);
            label5.Name = "label5";
            label5.Size = new Size(88, 31);
            label5.TabIndex = 5;
            label5.Text = "Poster";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(428, 28);
            lblName.Name = "lblName";
            lblName.Size = new Size(120, 31);
            lblName.TabIndex = 6;
            lblName.Text = "Tên phim";
            // 
            // btnXem
            // 
            btnXem.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXem.Location = new Point(428, 342);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(162, 37);
            btnXem.TabIndex = 7;
            btnXem.Text = "Xem chi tiết";
            btnXem.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(428, 74);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(373, 247);
            textBox1.TabIndex = 9;
            // 
            // lblgia
            // 
            lblgia.AutoSize = true;
            lblgia.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblgia.Location = new Point(827, 28);
            lblgia.Name = "lblgia";
            lblgia.Size = new Size(84, 31);
            lblgia.TabIndex = 10;
            lblgia.Text = "Giá vé";
            // 
            // btndat
            // 
            btndat.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btndat.Location = new Point(827, 74);
            btndat.Name = "btndat";
            btndat.Size = new Size(162, 37);
            btndat.TabIndex = 11;
            btndat.Text = "Đặt vé";
            btndat.UseVisualStyleBackColor = true;
            // 
            // Chitietphim
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1026, 450);
            Controls.Add(btndat);
            Controls.Add(lblgia);
            Controls.Add(textBox1);
            Controls.Add(btnXem);
            Controls.Add(lblName);
            Controls.Add(label5);
            Controls.Add(lblDuration);
            Controls.Add(lblGenre);
            Controls.Add(lblActors);
            Controls.Add(lblDirector);
            Controls.Add(picPoster);
            Name = "Chitietphim";
            Text = "Chitietphim";
            ((System.ComponentModel.ISupportInitialize)picPoster).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picPoster;
        private Label lblDirector;
        private Label lblActors;
        private Label lblGenre;
        private Label lblDuration;
        private Label label5;
        private Label lblName;
        private Button btnXem;
        private TextBox textBox1;
        private Label lblgia;
        private Button btndat;
    }
}