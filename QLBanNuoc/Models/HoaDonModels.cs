using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanNuoc.Models
{
    public class HoaDonModels
    {
        public string MaHD {  get; set; }
        public string MaKH { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }

        public HoaDonModels(string maHD, string maKH, DateTime ngayLap, decimal tongTien) { 
            this.MaHD = maHD;
            this.MaKH = maKH;
            this.NgayLap = ngayLap;
            this.TongTien = tongTien;
        }
    }
}
