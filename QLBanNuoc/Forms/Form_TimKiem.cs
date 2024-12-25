using Newtonsoft.Json;
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

namespace QLBanNuoc.Forms
{
    public partial class Form_TimKiem : Form
    {
        DanhMucService danhMucService;
        SanPhamService sanPhamService;
        KhachHangService khachHangService;
        HoaDonService hoaDonService;
        ChiTietHoaDonService chiTietHoaDonService;

        public Form_Layout Form_Layout { get; set; }

        public Form_TimKiem(Form_Layout form_Layout)
        {
            InitializeComponent();

            this.Form_Layout = form_Layout;
        }

        private void Form_TimKiem_Load(object sender, EventArgs e)
        {
            radioButton_DanhMuc.Checked = true;

            danhMucService = new DanhMucService();
            sanPhamService = new SanPhamService();
            khachHangService = new KhachHangService();
            hoaDonService = new HoaDonService();
            chiTietHoaDonService = new ChiTietHoaDonService();

            hienThiDSLichSuTimKiem();
        }

        //==================================== Nút tìm kiếm ================================================
        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            timKiem();

            panel3.Visible = false;

            LuuLichSuTimKiem(txb_TimKiem.Text);

            hienThiDSLichSuTimKiem();
        }

        //================================ Phương thức tìm kiếm =================================================
        public void timKiem()
        {
            string searchString = txb_TimKiem.Text;

            //Chưa nhập nội dung tìm kiếm
            if (string.IsNullOrEmpty(searchString))
            {
                MessageBox.Show("Vui lòng điền thông tin cần tìm kiếm!", "Thông báo");
                return;
            }

            if (radioButton_DanhMuc.Checked)
            {
                timKiemDanhMuc(searchString);
            }
            else if (radioButton_SanPham.Checked)
            {
                timKiemSanPham(searchString);
            }
            else if (radioButton_khachHang.Checked)
            {
                timKiemKhachHang(searchString);
            }
            else if (radioButton_HoaDon.Checked)
            {
                timKiemHoaDon(searchString);
            }
            else if (radioButton_CTHD.Checked)
            {
                timKiemCTHD(searchString);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mục cần tìm kiếm!", "Thông báo");
                return;
            }
        }

        //Tìm kiếm danh mục
        public void timKiemDanhMuc(string searchString)
        {

            List<DanhMucModels> danhMucs = danhMucService.TimKiem(searchString);

            if (danhMucs.Count == 0)
            {
                MessageBox.Show("Không tìm thấy danh mục!", "Thông báo");
                return;
            }

            panel_KetQuaTimKiem.Controls.Clear();

            UserControl_KetQuaTimKiem ketQuaTimKiem;

            foreach (DanhMucModels danhMuc in danhMucs)
            {
                ketQuaTimKiem = new UserControl_KetQuaTimKiem("DanhMuc", danhMuc.MaDM, danhMuc.TenDM, Form_Layout);

                panel_KetQuaTimKiem.Controls.Add(ketQuaTimKiem);
            }
        }

        //Tìm kiếm sản phẩm
        public void timKiemSanPham(string searchString)
        {
            List<SanPhamModels> sanPhams = sanPhamService.TimKiem(searchString);

            if (sanPhams.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm!", "Thông báo");
                return;
            }

            panel_KetQuaTimKiem.Controls.Clear();

            UserControl_KetQuaTimKiem ketQuaTimKiem;

            foreach (SanPhamModels sanPham in sanPhams)
            {
                ketQuaTimKiem = new UserControl_KetQuaTimKiem("SanPham", sanPham.MaSP, sanPham.TenSP, Form_Layout);

                panel_KetQuaTimKiem.Controls.Add(ketQuaTimKiem);
            }
        }

        //Tìm kiếm khách hàng
        public void timKiemKhachHang(string searchString)
        {
            List<KhachHangModels> khachHangs = khachHangService.TimKiem(searchString);

            if (khachHangs.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng!", "Thông báo");
                return;
            }

            panel_KetQuaTimKiem.Controls.Clear();

            UserControl_KetQuaTimKiem ketQuaTimKiem;

            foreach (KhachHangModels khachHang in khachHangs)
            {
                ketQuaTimKiem = new UserControl_KetQuaTimKiem("KhachHang", khachHang.MaKH, khachHang.HoTen, Form_Layout);

                panel_KetQuaTimKiem.Controls.Add(ketQuaTimKiem);
            }
        }

        //Tìm kiếm hóa đơn
        public void timKiemHoaDon(string searchString)
        {
            List<HoaDonModels> hoaDons = hoaDonService.TimKiem(searchString);

            if (hoaDons.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hóa đơn!", "Thông báo");
                return;
            }

            panel_KetQuaTimKiem.Controls.Clear();

            UserControl_KetQuaTimKiem ketQuaTimKiem;

            foreach (HoaDonModels hoaDon in hoaDons)
            {
                ketQuaTimKiem = new UserControl_KetQuaTimKiem("HoaDon", hoaDon.MaHD, hoaDon.MaKH, Form_Layout);

                panel_KetQuaTimKiem.Controls.Add(ketQuaTimKiem);
            }
        }


        //Tìm kiếm chi tiết hóa đơn
        public void timKiemCTHD(string searchString)
        {
            List<CHiTietHoaDonModels> chiTietHoaDons = chiTietHoaDonService.TimKiem(searchString);

            if (chiTietHoaDons.Count == 0)
            {
                MessageBox.Show("Không tìm thấy chi tiết hóa đơn!", "Thông báo");
                return;
            }

            panel_KetQuaTimKiem.Controls.Clear();

            UserControl_KetQuaTimKiem ketQuaTimKiem;

            foreach (CHiTietHoaDonModels chiTietHoaDon in chiTietHoaDons)
            {
                ketQuaTimKiem = new UserControl_KetQuaTimKiem("HoaDon", chiTietHoaDon.MaHD, chiTietHoaDon.MaSP, Form_Layout);

                panel_KetQuaTimKiem.Controls.Add(ketQuaTimKiem);
            }
        }

        //======================= ô tìm kiếm ==========================================
        private void txb_TimKiem_Click(object sender, EventArgs e)
        {
            //Hiển thị ô lịch sử tìm kiếm
            panel3.Visible = true;
        }

        private void panel_KetQuaTimKiem_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }


        //================================ Lưu lịch sử tìm kiếm ====================================================
        //Hiển thị danh sách lịch sử tìm kiếm
        public void hienThiDSLichSuTimKiem()
        {
            // Xóa các thành phần cũ
            panel_LichSuTimKiem.Controls.Clear();

            // Lấy danh sách lịch sử từ tệp
            List<string> danhSachLichSuTimKiem = TaiDanhSach();

            // Tạo và thêm các nhãn cho từng lịch sử
            foreach (string lichSu in danhSachLichSuTimKiem)
            {
                Button button = new Button();
                button.Text = lichSu;
                button.AutoSize = true;
                button.Margin = new Padding(0, 0, 10, 10);
                button.Click += btn_LichSu_Click;

                panel_LichSuTimKiem.Controls.Add(button);
            }
        }

        // Tìm kiếm bằng lịch sử
        private void btn_LichSu_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            txb_TimKiem.Text = clickedButton.Text;
        }


        // Hàm lưu danh sách vào tệp JSON 
        static void LuuLichSuTimKiem(string lichSuTimKiem)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LichSuTimKiem.json");

            // Tải danh sách hiện tại
            List<string> danhSachLichSu = TaiDanhSach();

            // Thêm lịch sử mới nếu chưa tồn tại
            if (!danhSachLichSu.Contains(lichSuTimKiem))
            {
                danhSachLichSu.Add(lichSuTimKiem);
            }

            // Chuyển danh sách sang định dạng JSON
            string jsonData = JsonConvert.SerializeObject(danhSachLichSu, Formatting.Indented);

            // Lưu chuỗi JSON vào tệp
            File.WriteAllText(filePath, jsonData);
        }


        // Hàm đọc danh sách từ tệp JSON
        static List<string> TaiDanhSach()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LichSuTimKiem.json");

            // Kiểm tra nếu tệp không tồn tại
            if (!File.Exists(filePath))
            {
                return new List<string>();
            }

            // Đọc chuỗi JSON từ tệp
            string jsonData = File.ReadAllText(filePath);

            // Chuyển chuỗi JSON thành danh sách
            return JsonConvert.DeserializeObject<List<string>>(jsonData);
        }
    }
}
