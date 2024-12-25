using QLBanNuoc.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanNuoc.UserControlls
{
    public partial class UserControl_KetQuaTimKiem : UserControl
    {
        public string ChuyenHuong { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }

        public Form_Layout Form_Layout { get; set; }

        public UserControl_KetQuaTimKiem(string chuyenHuong, string ma, string ten, Form_Layout form_Layout)
        {
            InitializeComponent();

            this.ChuyenHuong = chuyenHuong;
            this.Ma = ma;
            this.Ten = ten;
            this.Form_Layout = form_Layout;
        }

        private void UserControl_KetQuaTimKiem_Load(object sender, EventArgs e)
        {
            lbl_Ma.Text = Ma;
            lbl_Ten.Text = Ten;
        }

        //=============================== Chuyển hướng sang trang người dùng chọn, Nút xem chi tiết ========================
        private void btn_XemChiTiet_Click(object sender, EventArgs e)
        {
            switch (ChuyenHuong)
            {
                case "DanhMuc":
                    Form_DanhMuc form_DanhMuc = new Form_DanhMuc();
                    form_DanhMuc.maDMTimKiem = this.Ma;
                    Form_Layout.loadForm(form_DanhMuc);
                    break;
                case "SanPham":
                    Form_SanPham form_SanPham = new Form_SanPham();
                    form_SanPham.maSPTimKiem = this.Ma;
                    Form_Layout.loadForm(form_SanPham);
                    break;
                case "KhachHang":
                    Form_KhachHang form_KhachHang = new Form_KhachHang();
                    form_KhachHang.MaKHTimKiem = this.Ma;
                    Form_Layout.loadForm(form_KhachHang);
                    break;
                case "HoaDon":
                    Form_HoaDon form_HoaDon = new Form_HoaDon();
                    form_HoaDon.MaHDTimKiem = this.Ma;
                    Form_Layout.loadForm(form_HoaDon);
                    break;
                case "ChiTietHoaDon":
                    Form_ChiTietHoaDon form_ChiTietHoaDon = new Form_ChiTietHoaDon();
                    form_ChiTietHoaDon.MaCTHDTimKiem = this.Ma;
                    Form_Layout.loadForm(form_ChiTietHoaDon);
                    break;
            }
        }

    }
}
