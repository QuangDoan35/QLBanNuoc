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
    public partial class TimKiem : Form
    {
        public TimKiem()
        {
            InitializeComponent();
        }

        //============ Thoát tìm kiếm ==============================
        private void QuayLai_Click(object sender, EventArgs e)
        {
            TrangChu trangChu = new TrangChu();
            trangChu.Show();

            this.Close();
        }
    }
}
