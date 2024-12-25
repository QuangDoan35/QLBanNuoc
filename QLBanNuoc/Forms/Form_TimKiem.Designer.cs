namespace QLBanNuoc.Forms
{
    partial class Form_TimKiem
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel_12 = new Panel();
            panel12 = new Panel();
            panel3 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            label1 = new Label();
            panel_LichSuTimKiem = new FlowLayoutPanel();
            radioButton_CTHD = new RadioButton();
            radioButton_DanhMuc = new RadioButton();
            radioButton_SanPham = new RadioButton();
            radioButton_HoaDon = new RadioButton();
            radioButton_khachHang = new RadioButton();
            panel_KetQuaTimKiem = new FlowLayoutPanel();
            panel1 = new Panel();
            panel2 = new Panel();
            btn_TimKiem = new Guna.UI2.WinForms.Guna2Button();
            txb_TimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            panel_12.SuspendLayout();
            panel12.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel_12
            // 
            panel_12.Controls.Add(panel12);
            panel_12.Dock = DockStyle.Fill;
            panel_12.Location = new Point(0, 0);
            panel_12.Name = "panel_12";
            panel_12.Padding = new Padding(1);
            panel_12.Size = new Size(1009, 612);
            panel_12.TabIndex = 1;
            // 
            // panel12
            // 
            panel12.Controls.Add(panel3);
            panel12.Controls.Add(panel_KetQuaTimKiem);
            panel12.Controls.Add(panel1);
            panel12.Dock = DockStyle.Fill;
            panel12.Location = new Point(1, 1);
            panel12.Name = "panel12";
            panel12.Size = new Size(1007, 610);
            panel12.TabIndex = 0;
            panel12.Click += panel_KetQuaTimKiem_Click;
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(panel_LichSuTimKiem);
            panel3.Controls.Add(radioButton_CTHD);
            panel3.Controls.Add(radioButton_DanhMuc);
            panel3.Controls.Add(radioButton_SanPham);
            panel3.Controls.Add(radioButton_HoaDon);
            panel3.Controls.Add(radioButton_khachHang);
            panel3.Dock = DockStyle.Top;
            panel3.FillColor = Color.White;
            panel3.Location = new Point(0, 123);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10);
            panel3.ShadowColor = Color.Silver;
            panel3.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped;
            panel3.Size = new Size(1007, 252);
            panel3.TabIndex = 6;
            panel3.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(35, 81);
            label1.Name = "label1";
            label1.Size = new Size(155, 25);
            label1.TabIndex = 7;
            label1.Text = "Lịch sử tìm kiếm";
            // 
            // panel_LichSuTimKiem
            // 
            panel_LichSuTimKiem.AutoScroll = true;
            panel_LichSuTimKiem.Location = new Point(35, 127);
            panel_LichSuTimKiem.Margin = new Padding(0);
            panel_LichSuTimKiem.Name = "panel_LichSuTimKiem";
            panel_LichSuTimKiem.Padding = new Padding(0, 10, 0, 10);
            panel_LichSuTimKiem.Size = new Size(786, 106);
            panel_LichSuTimKiem.TabIndex = 6;
            // 
            // radioButton_CTHD
            // 
            radioButton_CTHD.AutoSize = true;
            radioButton_CTHD.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            radioButton_CTHD.ForeColor = Color.DarkGray;
            radioButton_CTHD.Location = new Point(506, 13);
            radioButton_CTHD.Name = "radioButton_CTHD";
            radioButton_CTHD.Size = new Size(161, 27);
            radioButton_CTHD.TabIndex = 5;
            radioButton_CTHD.TabStop = true;
            radioButton_CTHD.Text = "Chi tiết hóa đơn";
            radioButton_CTHD.UseVisualStyleBackColor = true;
            // 
            // radioButton_DanhMuc
            // 
            radioButton_DanhMuc.AutoSize = true;
            radioButton_DanhMuc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            radioButton_DanhMuc.ForeColor = Color.DarkGray;
            radioButton_DanhMuc.Location = new Point(35, 13);
            radioButton_DanhMuc.Name = "radioButton_DanhMuc";
            radioButton_DanhMuc.Size = new Size(112, 27);
            radioButton_DanhMuc.TabIndex = 1;
            radioButton_DanhMuc.TabStop = true;
            radioButton_DanhMuc.Text = "Danh mục";
            radioButton_DanhMuc.UseVisualStyleBackColor = true;
            // 
            // radioButton_SanPham
            // 
            radioButton_SanPham.AutoSize = true;
            radioButton_SanPham.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            radioButton_SanPham.ForeColor = Color.DarkGray;
            radioButton_SanPham.Location = new Point(153, 13);
            radioButton_SanPham.Name = "radioButton_SanPham";
            radioButton_SanPham.Size = new Size(111, 27);
            radioButton_SanPham.TabIndex = 2;
            radioButton_SanPham.TabStop = true;
            radioButton_SanPham.Text = "Sản phẩm";
            radioButton_SanPham.UseVisualStyleBackColor = true;
            // 
            // radioButton_HoaDon
            // 
            radioButton_HoaDon.AutoSize = true;
            radioButton_HoaDon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            radioButton_HoaDon.ForeColor = Color.DarkGray;
            radioButton_HoaDon.Location = new Point(400, 13);
            radioButton_HoaDon.Name = "radioButton_HoaDon";
            radioButton_HoaDon.Size = new Size(100, 27);
            radioButton_HoaDon.TabIndex = 4;
            radioButton_HoaDon.TabStop = true;
            radioButton_HoaDon.Text = "Hóa đơn";
            radioButton_HoaDon.UseVisualStyleBackColor = true;
            // 
            // radioButton_khachHang
            // 
            radioButton_khachHang.AutoSize = true;
            radioButton_khachHang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            radioButton_khachHang.ForeColor = Color.DarkGray;
            radioButton_khachHang.Location = new Point(270, 13);
            radioButton_khachHang.Name = "radioButton_khachHang";
            radioButton_khachHang.Size = new Size(124, 27);
            radioButton_khachHang.TabIndex = 3;
            radioButton_khachHang.TabStop = true;
            radioButton_khachHang.Text = "Khách hàng";
            radioButton_khachHang.UseVisualStyleBackColor = true;
            // 
            // panel_KetQuaTimKiem
            // 
            panel_KetQuaTimKiem.AutoScroll = true;
            panel_KetQuaTimKiem.Dock = DockStyle.Fill;
            panel_KetQuaTimKiem.Location = new Point(0, 123);
            panel_KetQuaTimKiem.Name = "panel_KetQuaTimKiem";
            panel_KetQuaTimKiem.Size = new Size(1007, 487);
            panel_KetQuaTimKiem.TabIndex = 1;
            panel_KetQuaTimKiem.Click += panel_KetQuaTimKiem_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1007, 123);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btn_TimKiem);
            panel2.Controls.Add(txb_TimKiem);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(20);
            panel2.Size = new Size(1007, 123);
            panel2.TabIndex = 0;
            // 
            // btn_TimKiem
            // 
            btn_TimKiem.BackColor = Color.Transparent;
            btn_TimKiem.BorderRadius = 5;
            btn_TimKiem.CustomizableEdges = customizableEdges1;
            btn_TimKiem.DisabledState.BorderColor = Color.DarkGray;
            btn_TimKiem.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_TimKiem.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_TimKiem.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_TimKiem.FillColor = Color.FromArgb(6, 214, 160);
            btn_TimKiem.Font = new Font("Segoe UI", 9F);
            btn_TimKiem.ForeColor = Color.FromArgb(7, 59, 76);
            btn_TimKiem.Location = new Point(815, 37);
            btn_TimKiem.Name = "btn_TimKiem";
            btn_TimKiem.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_TimKiem.Size = new Size(156, 48);
            btn_TimKiem.TabIndex = 3;
            btn_TimKiem.Text = "Tìm kiếm";
            btn_TimKiem.Click += btn_TimKiem_Click;
            // 
            // txb_TimKiem
            // 
            txb_TimKiem.BackColor = Color.Transparent;
            txb_TimKiem.BorderColor = Color.Gainsboro;
            txb_TimKiem.BorderRadius = 5;
            txb_TimKiem.CustomizableEdges = customizableEdges3;
            txb_TimKiem.DefaultText = "";
            txb_TimKiem.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txb_TimKiem.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txb_TimKiem.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txb_TimKiem.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txb_TimKiem.FocusedState.BorderColor = Color.LightGray;
            txb_TimKiem.Font = new Font("Segoe UI", 9F);
            txb_TimKiem.ForeColor = Color.FromArgb(6, 214, 160);
            txb_TimKiem.HoverState.BorderColor = Color.LightGray;
            txb_TimKiem.Location = new Point(35, 37);
            txb_TimKiem.Margin = new Padding(3, 4, 3, 4);
            txb_TimKiem.Name = "txb_TimKiem";
            txb_TimKiem.PasswordChar = '\0';
            txb_TimKiem.PlaceholderText = "Tìm kiếm gì đó...";
            txb_TimKiem.SelectedText = "";
            txb_TimKiem.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txb_TimKiem.Size = new Size(764, 48);
            txb_TimKiem.TabIndex = 0;
            txb_TimKiem.Click += txb_TimKiem_Click;
            // 
            // Form_TimKiem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1009, 612);
            Controls.Add(panel_12);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_TimKiem";
            Text = "Form_TimKiem";
            Load += Form_TimKiem_Load;
            panel_12.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel_12;
        private Panel panel12;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2TextBox txb_TimKiem;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btn_TimKiem;
        private Guna.UI2.WinForms.Guna2ShadowPanel panel3;
        private RadioButton radioButton_CTHD;
        private RadioButton radioButton_SanPham;
        private RadioButton radioButton_HoaDon;
        private RadioButton radioButton_khachHang;
        private FlowLayoutPanel panel_KetQuaTimKiem;
        private RadioButton radioButton_DanhMuc;
        private FlowLayoutPanel panel_LichSuTimKiem;
        private Label label1;
    }
}