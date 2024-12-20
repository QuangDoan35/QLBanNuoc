using QLBanNuoc.Models;
using QLBanNuoc.Services;
using QLBanNuoc.UserControlls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QLBanNuoc.Forms
{
    public partial class Form_TrangChu : Form
    {
        public Form_TrangChu()
        {
            InitializeComponent();
        }

        private void Form_TrangChu_Load(object sender, EventArgs e)
        {
            hienThiDanhSachBanChay();
        }

        //======================== Hiển thị danh sách top 10 sản phẩm bán chạy =======================================
        public void hienThiDanhSachBanChay()
        {
            //Lấy ra danh sách sản phẩm để hiển thị
            SanPhamService sanPhamService = new SanPhamService();
            List<SanPhamModels> top10SanPham = sanPhamService.GetTop10SanPham();

            foreach (SanPhamModels sanPham in top10SanPham)
            {
                //Tạo ra ô sản phẩm mới
                UserControl_ChiTietSanPham userControl_ChiTietSanPham = new UserControl_ChiTietSanPham();
                userControl_ChiTietSanPham.sanPham = sanPham;

                // Thêm vào trong ô panel
                flowLayoutPanel_SPBanChay.Controls.Add(userControl_ChiTietSanPham);
            }
        }
        //===============================================================================================================

        //======================== Hiển thị biểu đồ tròn thống kê tổng số lượng bán ra của từng danh mục =======================================
        public void thongKeSoLuongBanCuaMoiDanhMuc()
        {

        }
        //===============================================================================================================
    }
}
