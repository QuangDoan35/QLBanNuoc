namespace QLBanNuoc.UserControlls
{
    partial class UserControl_KetQuaTimKiem
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
            panel1 = new Panel();
            lbl_Ma = new Label();
            panel2 = new Panel();
            lbl_Ten = new Label();
            btn_XemChiTiet = new Guna.UI2.WinForms.Guna2Button();
            panel_KetQuaTimKiem = new Guna.UI2.WinForms.Guna2GradientPanel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel_KetQuaTimKiem.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lbl_Ma);
            panel1.Location = new Point(3, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(125, 74);
            panel1.TabIndex = 0;
            // 
            // lbl_Ma
            // 
            lbl_Ma.AutoSize = true;
            lbl_Ma.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl_Ma.Location = new Point(3, 26);
            lbl_Ma.Name = "lbl_Ma";
            lbl_Ma.Size = new Size(35, 23);
            lbl_Ma.TabIndex = 0;
            lbl_Ma.Text = "Mã";
            // 
            // panel2
            // 
            panel2.Controls.Add(lbl_Ten);
            panel2.Location = new Point(134, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(408, 74);
            panel2.TabIndex = 1;
            // 
            // lbl_Ten
            // 
            lbl_Ten.AutoSize = true;
            lbl_Ten.Font = new Font("Segoe UI", 10F);
            lbl_Ten.Location = new Point(17, 26);
            lbl_Ten.Name = "lbl_Ten";
            lbl_Ten.Size = new Size(36, 23);
            lbl_Ten.TabIndex = 0;
            lbl_Ten.Text = "Tên";
            // 
            // btn_XemChiTiet
            // 
            btn_XemChiTiet.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_XemChiTiet.BorderRadius = 5;
            btn_XemChiTiet.CustomizableEdges = customizableEdges1;
            btn_XemChiTiet.DisabledState.BorderColor = Color.DarkGray;
            btn_XemChiTiet.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_XemChiTiet.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_XemChiTiet.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_XemChiTiet.FillColor = Color.White;
            btn_XemChiTiet.Font = new Font("Segoe UI", 9F);
            btn_XemChiTiet.ForeColor = Color.RoyalBlue;
            btn_XemChiTiet.HoverState.FillColor = Color.WhiteSmoke;
            btn_XemChiTiet.Location = new Point(579, 15);
            btn_XemChiTiet.Name = "btn_XemChiTiet";
            btn_XemChiTiet.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_XemChiTiet.Size = new Size(156, 44);
            btn_XemChiTiet.TabIndex = 2;
            btn_XemChiTiet.Text = "Xem chi tiết";
            btn_XemChiTiet.Click += btn_XemChiTiet_Click;
            // 
            // panel_KetQuaTimKiem
            // 
            panel_KetQuaTimKiem.BorderRadius = 5;
            panel_KetQuaTimKiem.Controls.Add(panel1);
            panel_KetQuaTimKiem.Controls.Add(btn_XemChiTiet);
            panel_KetQuaTimKiem.Controls.Add(panel2);
            panel_KetQuaTimKiem.CustomBorderColor = Color.Black;
            panel_KetQuaTimKiem.CustomizableEdges = customizableEdges3;
            panel_KetQuaTimKiem.Dock = DockStyle.Fill;
            panel_KetQuaTimKiem.FillColor = Color.Aquamarine;
            panel_KetQuaTimKiem.FillColor2 = Color.MediumTurquoise;
            panel_KetQuaTimKiem.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            panel_KetQuaTimKiem.Location = new Point(10, 10);
            panel_KetQuaTimKiem.Name = "panel_KetQuaTimKiem";
            panel_KetQuaTimKiem.ShadowDecoration.CustomizableEdges = customizableEdges4;
            panel_KetQuaTimKiem.Size = new Size(755, 74);
            panel_KetQuaTimKiem.TabIndex = 3;
            // 
            // UserControl_KetQuaTimKiem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(panel_KetQuaTimKiem);
            Margin = new Padding(0, 20, 20, 0);
            Name = "UserControl_KetQuaTimKiem";
            Padding = new Padding(10);
            Size = new Size(775, 94);
            Load += UserControl_KetQuaTimKiem_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel_KetQuaTimKiem.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lbl_Ma;
        private Panel panel2;
        private Label lbl_Ten;
        private Guna.UI2.WinForms.Guna2Button btn_XemChiTiet;
        private Guna.UI2.WinForms.Guna2GradientPanel panel_KetQuaTimKiem;
    }
}
