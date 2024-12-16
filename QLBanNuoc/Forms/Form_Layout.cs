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
    public partial class Form_Layout : Form
    {
        public Form_Layout()
        {
            InitializeComponent();
            // Không cho thay đổi kích thước của form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        public void Form_Layout_Load(object sender, EventArgs e)
        {
            setStyleHoverMenu();
            AnChucNang();
        }

        //======================= Ẩn hết các nút chức năng khi mới vào form =====================
        public void AnChucNang()
        {
            panel_ButtonChinhSua.Visible = false;
            panel_ButtonXoa.Visible = false;
            panel_ButtonLuu.Visible = false;
            panel_ButtonHuy.Visible = false;
        }

        //================== Hiệu ứng hover trong menu ===================================
        public void setStyleHoverMenu()
        {
            panel_TrangChuLink.MouseEnter += mouseEnter;
            panel_DanhMucLink.MouseEnter += mouseEnter;
            panel_SanPhamLink.MouseEnter += mouseEnter;
            panel_KhachHangLink.MouseEnter += mouseEnter;
            panel_HoaDonLink.MouseEnter += mouseEnter;
            panel_CTHDLink.MouseEnter += mouseEnter;
            panel_DangXuatLink.MouseEnter += mouseEnter;

            panel_TrangChuLink.MouseLeave += mouseLeave;
            panel_DanhMucLink.MouseLeave += mouseLeave;
            panel_SanPhamLink.MouseLeave += mouseLeave;
            panel_KhachHangLink.MouseLeave += mouseLeave;
            panel_HoaDonLink.MouseLeave += mouseLeave;
            panel_CTHDLink.MouseLeave += mouseLeave;
            panel_DangXuatLink.MouseLeave += mouseLeave;
        }

        public void mouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.BackColor = System.Drawing.Color.WhiteSmoke;
            }
        }

        public void mouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.BackColor = System.Drawing.Color.Transparent;
            }
        }

        private void Form_Layout_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        //==================== Chọn chức năng trên menu ===========================

        // Form trang chủ
        private void TrangChuLink_Click(object sender, EventArgs e)
        {
            TrangChu trangChu = new TrangChu();
            trangChu.Show();
            this.Hide();
        }

        //Form danh mục
        private void DanhMucLink_Click(object sender, EventArgs e)
        {
            DanhMuc danhMuc = new DanhMuc();
            danhMuc.Show();
            this.Hide();
        }

        //Form sản phẩm
        private void SanPhamLink_Click(object sender, EventArgs e)
        {
            SanPham sanPham = new SanPham();
            sanPham.Show();
            this.Hide();
        }

        // Đăng xuất và quay trở lại form đăng nhập
        private void DangXuatLink_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            dangNhap.Show();
            this.Hide();
        }

        private void txb_SearchBox_Click(object sender, EventArgs e)
        {
            TimKiem timKiem = new TimKiem();
            timKiem.Show();

            this.Hide();
        }

        // =================== Nút thêm mới ============================
        private void btn_ThemMoi_Click(object sender, EventArgs e)
        {
            // Khi bấm vào nút thêm mới thì sẽ hiển thị ra nút lưu và hủy
            panel_ButtonLuu.Visible = true;
            panel_ButtonHuy.Visible = true;
            // Enable khung nhập dữ liệu
            panel17.Enabled = true;

            // Ẩn các nút không cần thiết
            panel_ButtonChinhSua.Visible = false;
            panel_ButtonXoa.Visible = false;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {

        }
    }
}
