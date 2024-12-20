namespace QLBanNuoc.Forms
{
    partial class Form_DangNhap
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
            panel1 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel9 = new Panel();
            lbl_ErrorLogin = new Label();
            btn_Thoat = new Button();
            btn_dangNhap = new Button();
            panel7 = new Panel();
            label2 = new Label();
            panel8 = new Panel();
            lbl_hienThiMatKhau = new Label();
            txb_MatKhau = new TextBox();
            panel5 = new Panel();
            label1 = new Label();
            panel6 = new Panel();
            txb_TaiKhoan = new TextBox();
            panel2 = new Panel();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel9.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(242, 37);
            panel1.Name = "panel1";
            panel1.Size = new Size(530, 547);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 154);
            panel3.Name = "panel3";
            panel3.Size = new Size(530, 393);
            panel3.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(panel9);
            panel4.Controls.Add(panel7);
            panel4.Controls.Add(panel5);
            panel4.Location = new Point(24, 19);
            panel4.Name = "panel4";
            panel4.Size = new Size(483, 371);
            panel4.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.Controls.Add(lbl_ErrorLogin);
            panel9.Controls.Add(btn_Thoat);
            panel9.Controls.Add(btn_dangNhap);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 184);
            panel9.Name = "panel9";
            panel9.Size = new Size(483, 187);
            panel9.TabIndex = 2;
            // 
            // lbl_ErrorLogin
            // 
            lbl_ErrorLogin.AutoSize = true;
            lbl_ErrorLogin.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_ErrorLogin.ForeColor = Color.Red;
            lbl_ErrorLogin.Location = new Point(0, 0);
            lbl_ErrorLogin.Name = "lbl_ErrorLogin";
            lbl_ErrorLogin.Size = new Size(0, 20);
            lbl_ErrorLogin.TabIndex = 3;
            // 
            // btn_Thoat
            // 
            btn_Thoat.BackColor = Color.LightSteelBlue;
            btn_Thoat.Cursor = Cursors.Hand;
            btn_Thoat.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btn_Thoat.ForeColor = SystemColors.WindowFrame;
            btn_Thoat.Location = new Point(0, 112);
            btn_Thoat.Name = "btn_Thoat";
            btn_Thoat.Size = new Size(483, 60);
            btn_Thoat.TabIndex = 2;
            btn_Thoat.Text = "Thoát";
            btn_Thoat.UseVisualStyleBackColor = false;
            btn_Thoat.Click += btn_Thoat_Click;
            // 
            // btn_dangNhap
            // 
            btn_dangNhap.BackColor = Color.FromArgb(67, 97, 238);
            btn_dangNhap.Cursor = Cursors.Hand;
            btn_dangNhap.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btn_dangNhap.ForeColor = SystemColors.ButtonHighlight;
            btn_dangNhap.Location = new Point(0, 34);
            btn_dangNhap.Name = "btn_dangNhap";
            btn_dangNhap.Size = new Size(483, 60);
            btn_dangNhap.TabIndex = 0;
            btn_dangNhap.Text = "Đăng nhập";
            btn_dangNhap.UseVisualStyleBackColor = false;
            btn_dangNhap.Click += btn_dangNhap_Click;
            // 
            // panel7
            // 
            panel7.Controls.Add(label2);
            panel7.Controls.Add(panel8);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 92);
            panel7.Name = "panel7";
            panel7.Size = new Size(483, 92);
            panel7.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = SystemColors.HotTrack;
            label2.Location = new Point(4, 5);
            label2.Name = "label2";
            label2.Size = new Size(102, 28);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu";
            // 
            // panel8
            // 
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(lbl_hienThiMatKhau);
            panel8.Controls.Add(txb_MatKhau);
            panel8.Location = new Point(0, 23);
            panel8.Name = "panel8";
            panel8.Size = new Size(483, 47);
            panel8.TabIndex = 0;
            // 
            // lbl_hienThiMatKhau
            // 
            lbl_hienThiMatKhau.AutoSize = true;
            lbl_hienThiMatKhau.Cursor = Cursors.Hand;
            lbl_hienThiMatKhau.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_hienThiMatKhau.ForeColor = SystemColors.AppWorkspace;
            lbl_hienThiMatKhau.Location = new Point(438, 12);
            lbl_hienThiMatKhau.Name = "lbl_hienThiMatKhau";
            lbl_hienThiMatKhau.Size = new Size(41, 20);
            lbl_hienThiMatKhau.TabIndex = 1;
            lbl_hienThiMatKhau.Text = "Hiện";
            lbl_hienThiMatKhau.Click += hienThiMatKhau_Click;
            // 
            // txb_MatKhau
            // 
            txb_MatKhau.BorderStyle = BorderStyle.None;
            txb_MatKhau.Location = new Point(15, 12);
            txb_MatKhau.Name = "txb_MatKhau";
            txb_MatKhau.Size = new Size(336, 20);
            txb_MatKhau.TabIndex = 0;
            txb_MatKhau.UseSystemPasswordChar = true;
            txb_MatKhau.TextChanged += ClearErrorLoginMess;
            // 
            // panel5
            // 
            panel5.Controls.Add(label1);
            panel5.Controls.Add(panel6);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(483, 92);
            panel5.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(3, 5);
            label1.Name = "label1";
            label1.Size = new Size(103, 28);
            label1.TabIndex = 1;
            label1.Text = "Tài khoản";
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(txb_TaiKhoan);
            panel6.Location = new Point(0, 23);
            panel6.Name = "panel6";
            panel6.Size = new Size(483, 47);
            panel6.TabIndex = 0;
            // 
            // txb_TaiKhoan
            // 
            txb_TaiKhoan.BorderStyle = BorderStyle.None;
            txb_TaiKhoan.Location = new Point(15, 12);
            txb_TaiKhoan.Name = "txb_TaiKhoan";
            txb_TaiKhoan.Size = new Size(336, 20);
            txb_TaiKhoan.TabIndex = 0;
            txb_TaiKhoan.TextChanged += ClearErrorLoginMess;
            // 
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Controls.Add(pictureBox2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(530, 154);
            panel2.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ActiveCaption;
            label3.Location = new Point(89, 87);
            label3.Name = "label3";
            label3.Size = new Size(352, 32);
            label3.TabIndex = 1;
            label3.Text = "Đăng nhập quản trị bán nước";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.logo;
            pictureBox2.Location = new Point(165, 34);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(200, 37);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(72, 149, 239);
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.login_background;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1015, 620);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // DangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DodgerBlue;
            ClientSize = new Size(1015, 620);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox2;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Label label1;
        private TextBox txb_TaiKhoan;
        private Panel panel7;
        private Label label2;
        private Panel panel8;
        private TextBox txb_MatKhau;
        private Label lbl_hienThiMatKhau;
        private Panel panel9;
        private Button btn_dangNhap;
        private Label label3;
        private Button btn_Thoat;
        private Label lbl_ErrorLogin;
    }
}