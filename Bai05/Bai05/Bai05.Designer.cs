namespace Bai05
{
    partial class Bai05
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
            label_URL = new Label();
            label_username = new Label();
            label_pass = new Label();
            textBox_URL = new TextBox();
            textBox_username = new TextBox();
            textBox_pass = new TextBox();
            button_login = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // label_URL
            // 
            label_URL.AutoSize = true;
            label_URL.Font = new Font("Segoe UI", 12F);
            label_URL.Location = new Point(14, 20);
            label_URL.Name = "label_URL";
            label_URL.Size = new Size(47, 28);
            label_URL.TabIndex = 0;
            label_URL.Text = "URL";
            // 
            // label_username
            // 
            label_username.AutoSize = true;
            label_username.Font = new Font("Segoe UI", 12F);
            label_username.Location = new Point(14, 74);
            label_username.Name = "label_username";
            label_username.Size = new Size(99, 28);
            label_username.TabIndex = 1;
            label_username.Text = "Username";
            // 
            // label_pass
            // 
            label_pass.AutoSize = true;
            label_pass.Font = new Font("Segoe UI", 12F);
            label_pass.Location = new Point(14, 121);
            label_pass.Name = "label_pass";
            label_pass.Size = new Size(93, 28);
            label_pass.TabIndex = 2;
            label_pass.Text = "Password";
            // 
            // textBox_URL
            // 
            textBox_URL.Font = new Font("Segoe UI", 12F);
            textBox_URL.Location = new Point(115, 17);
            textBox_URL.Name = "textBox_URL";
            textBox_URL.Size = new Size(664, 34);
            textBox_URL.TabIndex = 3;
            // 
            // textBox_username
            // 
            textBox_username.Font = new Font("Segoe UI", 12F);
            textBox_username.Location = new Point(115, 71);
            textBox_username.Name = "textBox_username";
            textBox_username.Size = new Size(513, 34);
            textBox_username.TabIndex = 4;
            // 
            // textBox_pass
            // 
            textBox_pass.Font = new Font("Segoe UI", 12F);
            textBox_pass.Location = new Point(115, 118);
            textBox_pass.Name = "textBox_pass";
            textBox_pass.Size = new Size(513, 34);
            textBox_pass.TabIndex = 5;
            // 
            // button_login
            // 
            button_login.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_login.Location = new Point(653, 77);
            button_login.Name = "button_login";
            button_login.Size = new Size(126, 65);
            button_login.TabIndex = 6;
            button_login.Text = "LOGIN";
            button_login.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Segoe UI", 12F);
            richTextBox1.Location = new Point(16, 170);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(763, 255);
            richTextBox1.TabIndex = 7;
            richTextBox1.Text = "";
            // 
            // Bai05
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FloralWhite;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(button_login);
            Controls.Add(textBox_pass);
            Controls.Add(textBox_username);
            Controls.Add(textBox_URL);
            Controls.Add(label_pass);
            Controls.Add(label_username);
            Controls.Add(label_URL);
            Name = "Bai05";
            Text = "Bài 05";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_URL;
        private Label label_username;
        private Label label_pass;
        private TextBox textBox_URL;
        private TextBox textBox_username;
        private TextBox textBox_pass;
        private Button button_login;
        private RichTextBox richTextBox1;
    }
}
