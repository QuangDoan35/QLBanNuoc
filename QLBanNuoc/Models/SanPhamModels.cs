using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanNuoc.Models
{
    public class SanPhamModels
    {
        public string MaSP { get; set; }
        public string MaDM { get; set; }
        public string TenSP { get; set; }
        public int SoLuongTon { get; set; }
        public int SoLuongDaBan { get; set; }
        public decimal Gia { get; set; }
        public string MoTa { get; set; }
        public string AnhSanPham { get; set; }

        public SanPhamModels (string maSP, string maDM, string tenSP, int soLuongTon, int soLuongDaBan, decimal gia, string moTa, string anhSanPham)
        {
            this.MaSP = maSP;
            this.MaDM = maDM;
            this.TenSP = tenSP;
            this.SoLuongTon = soLuongTon;
            this.SoLuongDaBan = soLuongDaBan;
            this.Gia = gia;
            this.MoTa = moTa;
            this.AnhSanPham = anhSanPham;
        }
    }
}
