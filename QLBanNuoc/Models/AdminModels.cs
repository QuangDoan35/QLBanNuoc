using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanNuoc.Models
{
    public class AdminModels
    {
        string MaAdmin {  get; set; }
        string HoTen {  get; set; }

        public AdminModels (string maAdmin, string hoTen)
        {
            this.MaAdmin = maAdmin;
            this.HoTen = hoTen;
        }
    }
}
