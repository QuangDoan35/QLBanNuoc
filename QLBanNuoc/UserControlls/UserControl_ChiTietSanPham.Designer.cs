namespace QLBanNuoc.UserControlls
{
    partial class UserControl_ChiTietSanPham
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            picturebox_AnhSanPham = new Guna.UI2.WinForms.Guna2PictureBox();
            label_MaSanPham = new Label();
            button_XemChiTietSanPham = new Guna.UI2.WinForms.Guna2Button();
            label_TenSanPham = new Label();
            guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picturebox_AnhSanPham).BeginInit();
            SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(picturebox_AnhSanPham);
            guna2ShadowPanel1.Controls.Add(label_MaSanPham);
            guna2ShadowPanel1.Controls.Add(button_XemChiTietSanPham);
            guna2ShadowPanel1.Controls.Add(label_TenSanPham);
            guna2ShadowPanel1.Dock = DockStyle.Fill;
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(0, 0);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Padding = new Padding(10);
            guna2ShadowPanel1.Radius = 5;
            guna2ShadowPanel1.ShadowColor = Color.Gainsboro;
            guna2ShadowPanel1.Size = new Size(210, 298);
            guna2ShadowPanel1.TabIndex = 0;
            // 
            // picturebox_AnhSanPham
            // 
            picturebox_AnhSanPham.BackColor = Color.Transparent;
            picturebox_AnhSanPham.BorderRadius = 10;
            picturebox_AnhSanPham.CustomizableEdges = customizableEdges1;
            picturebox_AnhSanPham.Dock = DockStyle.Top;
            picturebox_AnhSanPham.Image = Properties.Resources.product_image;
            picturebox_AnhSanPham.ImageRotate = 0F;
            picturebox_AnhSanPham.Location = new Point(10, 10);
            picturebox_AnhSanPham.Name = "picturebox_AnhSanPham";
            picturebox_AnhSanPham.ShadowDecoration.CustomizableEdges = customizableEdges2;
            picturebox_AnhSanPham.Size = new Size(190, 144);
            picturebox_AnhSanPham.SizeMode = PictureBoxSizeMode.Zoom;
            picturebox_AnhSanPham.TabIndex = 4;
            picturebox_AnhSanPham.TabStop = false;
            // 
            // label_MaSanPham
            // 
            label_MaSanPham.AutoSize = true;
            label_MaSanPham.Font = new Font("Segoe UI", 9F);
            label_MaSanPham.ForeColor = Color.Silver;
            label_MaSanPham.Location = new Point(13, 180);
            label_MaSanPham.Name = "label_MaSanPham";
            label_MaSanPham.Size = new Size(98, 20);
            label_MaSanPham.TabIndex = 3;
            label_MaSanPham.Text = "Ma san pham";
            // 
            // button_XemChiTietSanPham
            // 
            button_XemChiTietSanPham.BorderRadius = 5;
            button_XemChiTietSanPham.Cursor = Cursors.Hand;
            button_XemChiTietSanPham.CustomizableEdges = customizableEdges3;
            button_XemChiTietSanPham.DisabledState.BorderColor = Color.DarkGray;
            button_XemChiTietSanPham.DisabledState.CustomBorderColor = Color.DarkGray;
            button_XemChiTietSanPham.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            button_XemChiTietSanPham.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            button_XemChiTietSanPham.FillColor = Color.LightSeaGreen;
            button_XemChiTietSanPham.Font = new Font("Segoe UI", 9F);
            button_XemChiTietSanPham.ForeColor = Color.White;
            button_XemChiTietSanPham.Location = new Point(13, 245);
            button_XemChiTietSanPham.Name = "button_XemChiTietSanPham";
            button_XemChiTietSanPham.ShadowDecoration.CustomizableEdges = customizableEdges4;
            button_XemChiTietSanPham.Size = new Size(184, 40);
            button_XemChiTietSanPham.TabIndex = 2;
            button_XemChiTietSanPham.Text = "Xem chi tiết";
            button_XemChiTietSanPham.Click += button_XemChiTietSanPham_Click;
            // 
            // label_TenSanPham
            // 
            label_TenSanPham.AutoSize = true;
            label_TenSanPham.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_TenSanPham.ForeColor = Color.DimGray;
            label_TenSanPham.Location = new Point(13, 157);
            label_TenSanPham.Name = "label_TenSanPham";
            label_TenSanPham.Size = new Size(119, 23);
            label_TenSanPham.TabIndex = 1;
            label_TenSanPham.Text = "Ten san pham";
            // 
            // UserControl_ChiTietSanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(guna2ShadowPanel1);
            Name = "UserControl_ChiTietSanPham";
            Size = new Size(210, 298);
            Load += UserControl_ChiTietSanPham_Load;
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picturebox_AnhSanPham).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        public Label label_TenSanPham;
        public Guna.UI2.WinForms.Guna2Button button_XemChiTietSanPham;
        public Label label_MaSanPham;
        private Guna.UI2.WinForms.Guna2PictureBox picturebox_AnhSanPham;
    }
}
