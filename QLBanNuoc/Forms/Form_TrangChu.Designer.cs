namespace QLBanNuoc.Forms
{
    partial class Form_TrangChu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TrangChu));
            panel2 = new Panel();
            panel3 = new Panel();
            flowLayoutPanel_SPBanChay = new FlowLayoutPanel();
            label1 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(panel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1004, 625);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.WhiteSmoke;
            panel3.Controls.Add(flowLayoutPanel_SPBanChay);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(0, 303);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10);
            panel3.Size = new Size(1004, 322);
            panel3.TabIndex = 1;
            // 
            // flowLayoutPanel_SPBanChay
            // 
            flowLayoutPanel_SPBanChay.AutoScroll = true;
            flowLayoutPanel_SPBanChay.Dock = DockStyle.Fill;
            flowLayoutPanel_SPBanChay.Location = new Point(10, 38);
            flowLayoutPanel_SPBanChay.Name = "flowLayoutPanel_SPBanChay";
            flowLayoutPanel_SPBanChay.Size = new Size(984, 274);
            flowLayoutPanel_SPBanChay.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(10, 10);
            label1.Margin = new Padding(3, 0, 3, 10);
            label1.Name = "label1";
            label1.Size = new Size(271, 28);
            label1.TabIndex = 0;
            label1.Text = "TOP SẢN PHẨM BÁN CHẠY";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1004, 303);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.home_banner;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1004, 303);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            guna2HtmlLabel1.ForeColor = SystemColors.ControlDarkDark;
            guna2HtmlLabel1.Location = new Point(12, 13);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(3, 2);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = null;
            // 
            // Form_TrangChu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1004, 625);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_TrangChu";
            Text = "FormTrangChu";
            Load += Form_TrangChu_Load;
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Panel panel3;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel_SPBanChay;
        private PictureBox pictureBox1;
    }
}