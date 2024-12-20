using QLBanNuoc.Models;
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
    public partial class UserControl_ChiTietSanPham : UserControl
    {

        public SanPhamModels sanPham { get; set; }

        public UserControl_ChiTietSanPham()
        {
            InitializeComponent();
        }

        public UserControl_ChiTietSanPham(SanPhamModels sanPham)
        {
            this.sanPham = sanPham;
        }

        private void UserControl_ChiTietSanPham_Load(object sender, EventArgs e)
        {
            picturebox_AnhSanPham.ImageLocation = sanPham.AnhSanPham;
            label_TenSanPham.Text = sanPham.TenSP;
            label_MaSanPham.Text = sanPham.MaSP;
        }

        //============================== Hiển thị đầy đủ thông tin của sản phẩm bằng hộp thoại ==============================
        private void button_XemChiTietSanPham_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Mã Sản phẩm: {sanPham.MaSP} " +
                $"\nMã danh mục: {sanPham.MaDM} " +
                $"\nTên sản phẩm: {sanPham.TenSP}" +
                $"\nSố Lượng tồn: {sanPham.SoLuongTon}" +
                $"\nSố Lượng đã bán: {sanPham.SoLuongDaBan}" +
                $"\nGiá bán: {sanPham.Gia}" + 
                $"\nMô tả sản phẩm: {sanPham.MoTa}",
                "Chi tiết sản phẩm", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information
                );
        }
    }
}
