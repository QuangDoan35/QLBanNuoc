using Microsoft.Data.SqlClient;
using QLBanNuoc.Models;
using QLBanNuoc.Services;
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
    public partial class Form_DangNhap : Form
    {
        public Form_DangNhap()
        {
            InitializeComponent();
            // Không cho thay đổi kích thước của form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        //=================== Hiển thị password ==========================================
        private void hienThiMatKhau_Click(object sender, EventArgs e)
        {
            if (txb_MatKhau.UseSystemPasswordChar)
            {
                txb_MatKhau.UseSystemPasswordChar = false;
                lbl_hienThiMatKhau.Text = "Ẩn";
            }
            else
            {
                txb_MatKhau.UseSystemPasswordChar = true;
                lbl_hienThiMatKhau.Text = "Hiện";
            }
        }

        // ================ Nút đăng nhập ==============================================
        private void btn_dangNhap_Click(object sender, EventArgs e)
        {
            string TaiKhoan = txb_TaiKhoan.Text;
            string MatKhau = txb_MatKhau.Text;
            AdminService adminService = new AdminService();

            if (string.IsNullOrEmpty(TaiKhoan) && string.IsNullOrEmpty(MatKhau))
            {
                lbl_ErrorLogin.Text = "Tài khoản và mật khẩu không được để trống!";
            }
            else if (string.IsNullOrEmpty(TaiKhoan))
            {
                lbl_ErrorLogin.Text = "Tài khoản không được để trống!";
            }
            else if (string.IsNullOrEmpty(MatKhau))
            {
                lbl_ErrorLogin.Text = "Mật khẩu không được để trống!";
            }
            else
            {
                AdminModels adminModels = adminService.kiemTraDangNhap(TaiKhoan, MatKhau);

                if (adminModels == null)
                {
                    lbl_ErrorLogin.Text = "Tài khoản hoặc mật khẩu không chính xác!";
                }
                else
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo");

                    Form_Layout mainForm = new Form_Layout();
                    mainForm.maAdmin = adminModels.HoTen;
                    mainForm.Show();

                    this.Close();
                }
            }
        }

        //==================== Thoát =====================================
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //================== Xóa nội dung thông báo lỗi đăng nhập ================================
        public void ClearErrorLoginMess(object sender, EventArgs e)
        {
            lbl_ErrorLogin.Text = string.Empty;
        }

    }
}
