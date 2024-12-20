using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanNuoc.Forms
{
    public partial class Form_Layout : Form
    {
        public string maAdmin { get; set; }

        public Form_Layout()
        {
            InitializeComponent();
        }

        public Form_Layout(string maAdmin)
        {
            this.maAdmin = maAdmin;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lbl_AdminName.Text = maAdmin;

            //Mặc định hiển thị trang chủ đầu tiền khi vừa mới vào ứng dụng
            loadForm(new Form_TrangChu());
            SetButtonStyle(btn_TrangChu, Color.DodgerBlue, Color.White);
        }

        //=============================== sử lý sự kiện bấm chọn vào các mục trong menu ========================
        public void loadForm(object Form)
        {
            if (this.panel_Main.Controls.Count > 0)
            {
                this.panel_Main.Controls.RemoveAt(0);
            }

            Form form = Form as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panel_Main.Controls.Add(form);
            this.panel_Main.Tag = form;
            form.Show();
        }

        //Chuyển sang form trang chủ
        private void btn_TrangChu_Click(object sender, EventArgs e)
        {
            loadForm(new Form_TrangChu());

            resetButton();

            SetButtonStyle(btn_TrangChu, Color.DodgerBlue, Color.White);
        }

        //Chuyển sang form danh mục
        private void btn_DanhMuc_Click(object sender, EventArgs e)
        {
            loadForm(new Form_DanhMuc());

            resetButton();

            SetButtonStyle(btn_DanhMuc, Color.DodgerBlue, Color.White);
        }

        //Chuyển sang form sản phẩm
        private void btn_SanPham_Click(object sender, EventArgs e)
        {
            loadForm(new Form_SanPham());

            resetButton();

            SetButtonStyle(btn_SanPham, Color.DodgerBlue, Color.White);
        }

        //Chuyển qua form khách hàng
        private void btn_khachHang_Click(object sender, EventArgs e)
        {
            loadForm(new Form_KhachHang());

            resetButton();

            SetButtonStyle(btn_khachHang, Color.DodgerBlue, Color.White);
        }

        //Chuyển qua form hóa đơn
        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            loadForm(new Form_HoaDon());

            resetButton();

            SetButtonStyle(btn_HoaDon, Color.DodgerBlue, Color.White);
        }

        //Chuyển qua form chi tiết hóa đơn
        private void btn_ChiTietHoaDon_Click(object sender, EventArgs e)
        {
            loadForm(new Form_ChiTietHoaDon());

            resetButton();

            SetButtonStyle(btn_ChiTietHoaDon, Color.DodgerBlue, Color.White);
        }

        //Đăng xuất
        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form_DangNhap dangNhap = new Form_DangNhap();
                dangNhap.Show();

                this.Hide();
            }
        }

        //======================================================================================================

        //=========================== Đặt style cho nút khi được kích hoạt và đặt lại màu nền cho các nút bấm menu về lại ban đầu ======================================
        private void SetButtonStyle(Guna2Button btn, Color fillColor, Color foreColor)
        {
            btn.FillColor = fillColor;
            btn.ForeColor = foreColor;
        }

        public void resetButton()
        {
            btn_TrangChu.FillColor = Color.WhiteSmoke;
            btn_DanhMuc.FillColor = Color.WhiteSmoke;
            btn_SanPham.FillColor = Color.WhiteSmoke;
            btn_khachHang.FillColor = Color.WhiteSmoke;
            btn_HoaDon.FillColor = Color.WhiteSmoke;
            btn_ChiTietHoaDon.FillColor = Color.WhiteSmoke;

            btn_TrangChu.ForeColor = Color.DimGray;
            btn_DanhMuc.ForeColor = Color.DimGray;
            btn_SanPham.ForeColor = Color.DimGray;
            btn_khachHang.ForeColor = Color.DimGray;
            btn_HoaDon.ForeColor = Color.DimGray;
            btn_ChiTietHoaDon.ForeColor = Color.DimGray;
        }


        //=============================== Đóng form ============================================================
        private void FormLayout_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        
    }
}
