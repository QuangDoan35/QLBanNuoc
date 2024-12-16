namespace QLBanNuoc.Forms
{
    partial class TimKiem
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
            lbl_QuayLai = new Label();
            SuspendLayout();
            // 
            // lbl_QuayLai
            // 
            lbl_QuayLai.AutoSize = true;
            lbl_QuayLai.Font = new Font("Segoe UI", 12F);
            lbl_QuayLai.Location = new Point(12, 9);
            lbl_QuayLai.Name = "lbl_QuayLai";
            lbl_QuayLai.Size = new Size(83, 28);
            lbl_QuayLai.TabIndex = 0;
            lbl_QuayLai.Text = "Quay lại";
            lbl_QuayLai.Click += QuayLai_Click;
            // 
            // TimKiem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1267, 745);
            ControlBox = false;
            Controls.Add(lbl_QuayLai);
            Name = "TimKiem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tìm Kiếm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_QuayLai;
    }
}