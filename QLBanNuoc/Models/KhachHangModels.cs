using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanNuoc.Models
{
    public class KhachHangModels
    {
        public string MaKH { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string AnhKH { get; set; }

        public KhachHangModels (string maKH, string hoTen, string diaChi, string SDT, string email, string anhKH)
        {
            this.MaKH = maKH;
            this.HoTen = hoTen;
            this.DiaChi = diaChi;
            this.SDT = SDT;
            this.Email = email;
            this.AnhKH = anhKH;
        }

    }
}
