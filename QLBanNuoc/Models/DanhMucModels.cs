using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanNuoc.Models
{
    public class DanhMucModels
    {
        public string MaDM { get; set; }
        public string TenDM { get; set; }
        public string MoTa { get; set; }
        public string AnhDM { get; set; }

        public DanhMucModels(string maDM, string tenDM, string moTa, string anhDM) { 
            this.MaDM = maDM;
            this.TenDM = tenDM;
            this.MoTa = moTa;
            this.AnhDM = anhDM;
        }   
    }
}
