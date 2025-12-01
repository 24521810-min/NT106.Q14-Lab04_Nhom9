namespace Bai01
{
    partial class Bai01
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
            textBox_link = new TextBox();
            button_get = new Button();
            richTextBox_nd = new RichTextBox();
            SuspendLayout();
            // 
            // textBox_link
            // 
            textBox_link.Font = new Font("Segoe UI", 12F);
            textBox_link.Location = new Point(37, 35);
            textBox_link.Name = "textBox_link";
            textBox_link.Size = new Size(624, 34);
            textBox_link.TabIndex = 0;
            // 
            // button_get
            // 
            button_get.Font = new Font("Segoe UI", 12F);
            button_get.Location = new Point(677, 33);
            button_get.Name = "button_get";
            button_get.Size = new Size(96, 38);
            button_get.TabIndex = 1;
            button_get.Text = "GET";
            button_get.UseVisualStyleBackColor = true;
            // 
            // richTextBox_nd
            // 
            richTextBox_nd.Font = new Font("Segoe UI", 12F);
            richTextBox_nd.Location = new Point(37, 95);
            richTextBox_nd.Name = "richTextBox_nd";
            richTextBox_nd.Size = new Size(736, 314);
            richTextBox_nd.TabIndex = 2;
            richTextBox_nd.Text = "";
            // 
            // Bai01
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FloralWhite;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox_nd);
            Controls.Add(button_get);
            Controls.Add(textBox_link);
            Name = "Bai01";
            Text = "Bài 01";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_link;
        private Button button_get;
        private RichTextBox richTextBox_nd;
    }
}
