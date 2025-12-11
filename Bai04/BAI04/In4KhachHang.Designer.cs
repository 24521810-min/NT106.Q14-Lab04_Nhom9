namespace BAI04
{
    partial class In4KhachHang
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
            lblnhap = new Label();
            lblTenkhach = new Label();
            lblsdt = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            btnxacnhan = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // lblnhap
            // 
            lblnhap.AutoSize = true;
            lblnhap.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblnhap.Location = new Point(65, 38);
            lblnhap.Name = "lblnhap";
            lblnhap.Size = new Size(280, 28);
            lblnhap.TabIndex = 0;
            lblnhap.Text = "Nhập thông tin khách hàng";
            // 
            // lblTenkhach
            // 
            lblTenkhach.AutoSize = true;
            lblTenkhach.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblTenkhach.Location = new Point(34, 98);
            lblTenkhach.Name = "lblTenkhach";
            lblTenkhach.Size = new Size(131, 23);
            lblTenkhach.TabIndex = 1;
            lblTenkhach.Text = "Tên khách hàng";
            // 
            // lblsdt
            // 
            lblsdt.AutoSize = true;
            lblsdt.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblsdt.Location = new Point(34, 163);
            lblsdt.Name = "lblsdt";
            lblsdt.Size = new Size(40, 23);
            lblsdt.TabIndex = 2;
            lblsdt.Text = "SĐT";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(185, 94);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(214, 27);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(185, 162);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(214, 27);
            textBox2.TabIndex = 4;
            // 
            // btnxacnhan
            // 
            btnxacnhan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnxacnhan.Location = new Point(159, 258);
            btnxacnhan.Name = "btnxacnhan";
            btnxacnhan.Size = new Size(94, 29);
            btnxacnhan.TabIndex = 5;
            btnxacnhan.Text = "Xác nhận";
            btnxacnhan.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(34, 215);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 6;
            button1.Text = "Chọn ghế";
            button1.UseVisualStyleBackColor = true;
            // 
            // In4KhachHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 359);
            Controls.Add(button1);
            Controls.Add(btnxacnhan);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(lblsdt);
            Controls.Add(lblTenkhach);
            Controls.Add(lblnhap);
            Name = "In4KhachHang";
            Text = "In4KhachHang";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblnhap;
        private Label lblTenkhach;
        private Label lblsdt;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button btnxacnhan;
        private Button button1;
    }
}