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
    public partial class TrangChu : Form_Layout
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        public void TrangChu_Load(object sender, EventArgs e)
        {
            HienThiDanhSachSPBanChay();
        }

        //===================== Hiển thị danh sách sản phẩm bán chạy ======================================
        private void HienThiDanhSachSPBanChay()
        {
            SanPhamService sanPhamService = new SanPhamService();

            List<SanPhamModels> top10SanPham = sanPhamService.GetTop10SanPham();

            int stt = 1; // Khởi tạo số thứ tự
            foreach (SanPhamModels sanPham in top10SanPham)
            {
                // Thêm từng dòng vào DataGridView
                dgv_TopSPBanChay.Rows.Add(
                    stt, // Số thứ tự
                    sanPham.MaSP,
                    sanPham.MaDM,
                    sanPham.TenSP,
                    sanPham.SoLuongTon,
                    sanPham.SoLuongDaBan,
                    sanPham.Gia,
                    sanPham.MoTa,
                    sanPham.AnhSanPham
                );
                stt++; // Tăng số thứ tự
            }
        }


        //=============== Hiển thị chi tiết sản phẩm khi click =======================================
        private void dgv_TopSPBanChay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_TopSPBanChay.Rows[e.RowIndex];

                string maSP = selectedRow.Cells[1].Value.ToString();
                string maDM = selectedRow.Cells[2].Value.ToString();
                string tenSP = selectedRow.Cells[3].Value.ToString();
                int soLuongTon = (int)selectedRow.Cells[4].Value;
                int soLuongDaBan = (int)selectedRow.Cells[5].Value;
                decimal gia = (decimal)selectedRow.Cells[6].Value;
                string moTa = selectedRow.Cells[7].Value.ToString();

                txb_MaSanPham.Text = maSP;
                txb_TenSP.Text = tenSP;
                txb_MaDM.Text = maDM;
                txb_SoLuongTon.Text = soLuongTon.ToString();
                txb_SoLuongDaBan.Text = soLuongDaBan.ToString();
                txb_Gia.Text = gia.ToString();
                txb_MoTa.Text = moTa;

                string imageLocation = @$"{selectedRow.Cells[8].Value}";
                ptb_SanPham.ImageLocation = imageLocation;
            }
        }
    }
}
