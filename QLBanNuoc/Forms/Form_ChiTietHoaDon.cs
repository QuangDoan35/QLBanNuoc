using QLBanNuoc.Models;
using QLBanNuoc.Services;
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
    public partial class Form_ChiTietHoaDon : Form
    {
        ChiTietHoaDonService chiTietHoaDonService = new ChiTietHoaDonService();
        List<CHiTietHoaDonModels> danhSachChiTietHoaDon = new List<CHiTietHoaDonModels>();
        int trangThai; // Trạng thái của nút lưu: 1 - thêm mới, 2 - chỉnh sửa

        public string MaCTHDTimKiem {  get; set; }

        public Form_ChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void Form_ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            hienThiDanhSachChiTietHoaDon();

            chonCTHDTimKiem();
        }

        //================================= Reset lại form hiển thị và nút bấm ============================
        public void resetFormField()
        {
            txb_MaHD.Text = string.Empty;
            txb_MaSP.Text = string.Empty;
            txb_SoLuong.Text = string.Empty;
            txb_GiaBan.Text = string.Empty;

            panel_FormFields.Enabled = false;
        }

        public void resetButton()
        {
            btn_ChinhSua.Visible = false;
            btn_Xoa.Visible = false;
            panel_btn_Luu_Huy.Visible = false;
        }

        //=========================== Hiển thị toàn bộ danh sách chi tiết hóa đơn ========================
        public void hienThiDanhSachChiTietHoaDon()
        {
            danhSachChiTietHoaDon = chiTietHoaDonService.GetDanhSachChiTietHoaDon();

            int stt = 1;
            foreach (CHiTietHoaDonModels chiTietHoaDon in danhSachChiTietHoaDon)
            {
                dgv_DSChiTietHoaDon.Rows.Add(
                    stt,
                    chiTietHoaDon.MaHD,
                    chiTietHoaDon.MaSP,
                    chiTietHoaDon.SoLuong,
                    chiTietHoaDon.GiaBan
                );
                stt++;
            }
        }

        //========================== Hiển thị chi tiết thông tin chi tiết hóa đơn được chọn =============
        private void dgv_DSChiTietHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgv_DSChiTietHoaDon.Rows.Count)
                return;

            DataGridViewRow selectedRow = dgv_DSChiTietHoaDon.Rows[e.RowIndex];

            string maHD = selectedRow.Cells[1].Value.ToString();
            string maSP = selectedRow.Cells[2].Value.ToString();
            string soLuong = selectedRow.Cells[3].Value.ToString();
            string giaBan = selectedRow.Cells[4].Value.ToString();

            txb_MaHD.Text = maHD;
            txb_MaSP.Text = maSP;
            txb_SoLuong.Text = soLuong;
            txb_GiaBan.Text = giaBan;

            resetButton();
            panel_FormFields.Enabled = false;

            btn_ChinhSua.Visible = true;
            btn_Xoa.Visible = true;
        }

        //=========================== Nút lưu ============================================================
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string maHD = txb_MaHD.Text?.Trim();
            string maSP = txb_MaSP.Text?.Trim();
            string soLuongText = txb_SoLuong.Text?.Trim();
            string giaBanText = txb_GiaBan.Text?.Trim();

            if (string.IsNullOrEmpty(maHD) || string.IsNullOrEmpty(maSP) || string.IsNullOrEmpty(soLuongText) || string.IsNullOrEmpty(giaBanText))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(soLuongText, out int soLuong) || soLuong <= 0 ||
                !decimal.TryParse(giaBanText, out decimal giaBan) || giaBan <= 0)
            {
                MessageBox.Show("Thông tin không hợp lệ. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CHiTietHoaDonModels chiTietHoaDon = new CHiTietHoaDonModels(maHD, maSP, soLuong, giaBan);

            if (trangThai == 1)
            {
                luuThemMoiChiTietHoaDon(chiTietHoaDon);
            }
            else if (trangThai == 2)
            {
                luuChinhSuaChiTietHoaDon(chiTietHoaDon);
            }
        }

        //Lưu thêm mới
        public void luuThemMoiChiTietHoaDon(CHiTietHoaDonModels chiTietHoaDon)
        {
            try
            {
                chiTietHoaDonService.ThemChiTietHoaDon(chiTietHoaDon);
                MessageBox.Show("Thêm chi tiết hóa đơn thành công", "Thông báo");

                danhSachChiTietHoaDon = chiTietHoaDonService.GetDanhSachChiTietHoaDon();
                dgv_DSChiTietHoaDon.Rows.Clear();
                hienThiDanhSachChiTietHoaDon();

                resetFormField();
                resetButton();
            }
            catch
            {
                MessageBox.Show("Mã hóa đơn hoặc mã sản phẩm không tồn tại!", "Thông báo");
            }
        }

        //Lưu chỉnh sửa
        public void luuChinhSuaChiTietHoaDon(CHiTietHoaDonModels chiTietHoaDon)
        {
            try
            {
                chiTietHoaDonService.SuaChiTietHoaDon(chiTietHoaDon);
                MessageBox.Show("Sửa chi tiết hóa đơn thành công", "Thông báo");

                danhSachChiTietHoaDon = chiTietHoaDonService.GetDanhSachChiTietHoaDon();
                dgv_DSChiTietHoaDon.Rows.Clear();
                hienThiDanhSachChiTietHoaDon();

                resetFormField();
                resetButton();
            }
            catch
            {
                MessageBox.Show("Mã hóa đơn hoặc mã sản phẩm không tồn tại!", "Thông báo");
            }
        }

        //======================================= Nút hủy ===============================================
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                resetFormField();
                resetButton();
            }
        }

        //======================================== nút thêm mới ==========================================
        private void btn_ThemMoi_Click(object sender, EventArgs e)
        {
            resetFormField();
            resetButton();

            panel_btn_Luu_Huy.Visible = true;

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

        //======================================== nút xóa ===============================================
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maHD = txb_MaHD.Text;
                string maSP = txb_MaSP.Text;

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa chi tiết hóa đơn {maHD} không?", "Xác nhận", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    chiTietHoaDonService.XoaChiTietHoaDon(maHD, maSP);
                    MessageBox.Show("Xóa chi tiết hóa đơn thành công!", "Thông báo");

                    danhSachChiTietHoaDon = chiTietHoaDonService.GetDanhSachChiTietHoaDon();
                    dgv_DSChiTietHoaDon.Rows.Clear();
                    hienThiDanhSachChiTietHoaDon();

                    resetFormField();
                    resetButton();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi xóa chi tiết hóa đơn!", "Thông báo");
            }
        }


        //==================================== Tính giá bán của chi tiết hóa đơn ==========================================================

        private void txb_SoLuong_TextChanged(object sender, EventArgs e)
        {
            SanPhamService sanPhamService = new SanPhamService();

            //Lấy giá sản phẩm từ mã sản phẩm
            decimal gia = sanPhamService.LayGiaBanTheoMaSP(txb_MaSP.Text);

            if (!string.IsNullOrEmpty(txb_SoLuong.Text))
            {
                //Trường hợp giá = -1 nghĩa là không tìm thấy sản phẩm có mã truyền vào
                if (gia <= -1)
                {
                    txb_SoLuong.Text = string.Empty;

                    //In ra thông báo
                    MessageBox.Show("Không tìm thấy sản phẩm có mã bạn nhập vào!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
                else //Trường hợp có sản phẩm 
                {
                    //Tính giá của sản phẩm nhân với số lượng và hiển thị lên ô textbox
                    try
                    {
                        decimal giaBan = gia * Int32.Parse(txb_SoLuong.Text);
                        txb_GiaBan.Text = giaBan.ToString();
                    }
                    catch
                    {
                        MessageBox.Show($"Số lượng nhập vào không hợp lệ!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                txb_GiaBan.Text = string.Empty;
            }
        }

        //========================= Chọn vào hàng được tìm kiếm ======================================
        private void chonCTHDTimKiem()
        {
            foreach (DataGridViewRow row in dgv_DSChiTietHoaDon.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == MaCTHDTimKiem)
                {
                    // Chọn dòng
                    row.Selected = true;

                    // Đặt con trỏ vào ô của dòng
                    dgv_DSChiTietHoaDon.CurrentCell = row.Cells[1];

                    // Kích hoạt sự kiện CellClick
                    int rowIndex = row.Index;
                    dgv_DSChiTietHoaDon_CellClick(this, new DataGridViewCellEventArgs(1, rowIndex));
                    break;
                }
            }
        }
    }
}
