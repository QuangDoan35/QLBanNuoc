﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanNuoc.Models
{
    public class CHiTietHoaDonModels
    {
        public string MaHD {  get; set; }
        public string MaSP { get; set; }
        public int SoLuong { get; set; }
        public int DaBan { get; set; }

        public CHiTietHoaDonModels (string maHD, string maSP, int soLuong, int daBan)
        {
            this.MaHD = maHD;
            this.MaSP = maSP;
            this.SoLuong = soLuong;
            this.DaBan = daBan;
        }
    }
}