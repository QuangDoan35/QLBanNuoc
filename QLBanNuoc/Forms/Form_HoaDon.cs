using QLBanNuoc.Models;
using QLBanNuoc.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanNuoc.Forms
{
    public partial class Form_HoaDon : Form
    {
        HoaDonService hoaDonService = new HoaDonService();
        List<HoaDonModels> danhSachHoaDon = new List<HoaDonModels>();
        int trangThai; // Trạng thái của nút lưu: 1 - thêm mới, 2 - chỉnh sửa

        public string MaHDTimKiem {  get; set; }

        public Form_HoaDon()
        {
            InitializeComponent();
        }

        private void Form_HoaDon_Load(object sender, EventArgs e)
        {
            hienThiDanhSachHoaDon();

            chonHoaDonTimKiem();
        }

        //================================= Reset lại form hiển thị và nút bấm ============================
        public void resetFormField()
        {
            txb_MaHD.Text = string.Empty;
            txb_MaKH.Text = string.Empty;
            txb_TongTien.Text = string.Empty;
            DateTimePicker_NgayLap.Text = string.Empty;

            panel_FormFields.Enabled = false;
        }

        public void resetButton()
        {
            btn_ChinhSua.Visible = false;
            btn_Xoa.Visible = false;
            panel_btn_Luu_Huy.Visible = false;
        }

        //=========================== Hiển thị toàn bộ danh sách hóa đơn =================================
        public void hienThiDanhSachHoaDon()
        {
            danhSachHoaDon = hoaDonService.GetDanhSachHoaDon();

            int stt = 1;
            foreach (HoaDonModels hoaDon in danhSachHoaDon)
            {
                dgv_DSHoaDon.Rows.Add(
                    stt,
                    hoaDon.MaHD,
                    hoaDon.MaKH,
                    hoaDon.NgayLap,
                    hoaDon.TongTien
                );
                stt++;
            }
        }

        //========================== Hiển thị chi tiết thông tin hóa đơn được chọn =======================
        private void dgv_DSHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgv_DSHoaDon.Rows.Count)
                return;

            DataGridViewRow selectedRow = dgv_DSHoaDon.Rows[e.RowIndex];

            string maHD = selectedRow.Cells[1].Value.ToString();
            string maKH = selectedRow.Cells[2].Value.ToString();
            string ngayLap = selectedRow.Cells[3].Value.ToString();
            string tongTien = selectedRow.Cells[4].Value.ToString();

            txb_MaHD.Text = maHD;
            txb_MaKH.Text = maKH;
            txb_TongTien.Text = tongTien;
            DateTimePicker_NgayLap.Text = ngayLap;

            resetButton();
            panel_FormFields.Enabled = false;

            btn_ChinhSua.Visible = true;
            btn_Xoa.Visible = true;
        }

        //=========================== Nút lưu ==================================================
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string maHD = txb_MaHD.Text?.Trim();
            string maKH = txb_MaKH.Text?.Trim();
            string tongTienText = txb_TongTien.Text?.Trim();

            if (string.IsNullOrEmpty(maHD) || string.IsNullOrEmpty(maKH) || string.IsNullOrEmpty(tongTienText))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng số cho Tổng tiền
            if (!decimal.TryParse(tongTienText, out decimal tongTien) || tongTien < 0)
            {
                MessageBox.Show("Tổng tiền không hợp lệ. Vui lòng nhập một số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HoaDonModels hoaDon = new HoaDonModels(maHD, maKH, DateTimePicker_NgayLap.Value, tongTien);

            if (trangThai == 1)
            {
                luuThemMoiHoaDon(hoaDon);
            }
            else if (trangThai == 2)
            {
                luuChinhSuaHoaDon(hoaDon);
            }
        }

        //Lưu thêm mới
        public void luuThemMoiHoaDon(HoaDonModels hoaDon)
        {
            try
            {
                hoaDonService.ThemHoaDon(hoaDon);
                MessageBox.Show("Thêm hóa đơn thành công", "Thông báo");

                danhSachHoaDon = hoaDonService.GetDanhSachHoaDon();
                dgv_DSHoaDon.Rows.Clear();
                hienThiDanhSachHoaDon();

                resetFormField();
                resetButton();
            }
            catch
            {
                MessageBox.Show("Mã khách hàng không tồn tại!", "Thông báo");
            }
        }

        //Lưu chỉnh sửa
        public void luuChinhSuaHoaDon(HoaDonModels hoaDon)
        {
            try
            {
                hoaDonService.SuaHoaDon(hoaDon);
                MessageBox.Show("Sửa hóa đơn thành công", "Thông báo");

                danhSachHoaDon = hoaDonService.GetDanhSachHoaDon();
                dgv_DSHoaDon.Rows.Clear();
                hienThiDanhSachHoaDon();

                resetFormField();
                resetButton();
            }
            catch
            {
                MessageBox.Show("Mã khách hàng không tồn tại!", "Thông báo");
            }
        }


        //======================================= Nút hủy ========================================
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                resetFormField();
                resetButton();
            }
        }

        //======================================== nút thêm mới =========================================
        private void btn_ThemMoi_Click(object sender, EventArgs e)
        {
            resetFormField();
            resetButton();

            panel_btn_Luu_Huy.Visible = true;

            int soHoaDon = danhSachHoaDon.Count + 1;
            string maHD = "HD00" + soHoaDon;
            txb_MaHD.Text = maHD;

            trangThai = 1;

            panel_FormFields.Enabled = true;
        }

        //======================================== nút chỉnh sửa =========================================
        private void btn_ChinhSua_Click(object sender, EventArgs e)
        {
            panel_btn_Luu_Huy.Visible = true;

            trangThai = 2;

            panel_FormFields.Enabled = true;
        }

        //======================================== nút xóa =========================================
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maHD = txb_MaHD.Text;

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn {maHD} không?", "Xác nhận", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    hoaDonService.XoaHoaDon(maHD);
                    MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo");

                    danhSachHoaDon = hoaDonService.GetDanhSachHoaDon();
                    dgv_DSHoaDon.Rows.Clear();
                    hienThiDanhSachHoaDon();

                    resetFormField();
                    resetButton();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi xóa hóa đơn!", "Thông báo");
            }
        }


        //========================= Chọn vào hàng được tìm kiếm ======================================
        private void chonHoaDonTimKiem()
        {
            foreach (DataGridViewRow row in dgv_DSHoaDon.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == MaHDTimKiem)
                {
                    // Chọn dòng
                    row.Selected = true;

                    // Đặt con trỏ vào ô của dòng
                    dgv_DSHoaDon.CurrentCell = row.Cells[1];

                    // Kích hoạt sự kiện CellClick
                    int rowIndex = row.Index;
                    dgv_DSHoaDon_CellClick(this, new DataGridViewCellEventArgs(1, rowIndex));
                    break;
                }
            }
        }
    }
}
