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
    public partial class Form_KhachHang : Form
    {
        KhachHangService khachHangService = new KhachHangService();
        List<KhachHangModels> danhSachKhachHang = new List<KhachHangModels>();
        int trangThai; // Trạng thái của nút lưu: 1 - thêm mới, 2 - chỉnh sửa
        string currentAnhKH;

        public Form_KhachHang()
        {
            InitializeComponent();
        }

        private void Form_KhachHang_Load(object sender, EventArgs e)
        {
            hienThiDanhSachKhachHang();
        }


        //================================= Reset lại form hiển thị và nút bấm ============================
        public void resetFormField()
        {
            txb_MaKH.Text = string.Empty;
            txb_TenKH.Text = string.Empty;
            txb_DiaChi.Text = string.Empty;
            txb_SDT.Text = string.Empty;
            txb_Email.Text = string.Empty;
            ptb_AnhKH.ImageLocation = "../../../Assets/Images/user-default-avatar.jpg";

            panel_FormFields.Enabled = false;
        }

        public void resetButton()
        {
            btn_ChinhSua.Visible = false;
            btn_Xoa.Visible = false;
            btn_ChonAnh.Visible = false;
            panel_btn_Luu_Huy.Visible = false;
        }

        //=========================== Hiển thị toàn bộ danh sách khách hàng =================================
        public void hienThiDanhSachKhachHang()
        {
            danhSachKhachHang = khachHangService.GetDanhSachKhachHang();

            int stt = 1;
            foreach (KhachHangModels khachHang in danhSachKhachHang)
            {
                dgv_DSKhachHang.Rows.Add(
                    stt,
                    khachHang.MaKH,
                    khachHang.HoTen,
                    khachHang.DiaChi,
                    khachHang.SDT,
                    khachHang.Email,
                    khachHang.AnhKH
                );
                stt++;
            }
        }

        //========================== Hiển thị chi tiết thông tin khách hàng được chọn =======================
        private void dgv_DSKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgv_DSKhachHang.Rows.Count)
                return;

            DataGridViewRow selectedRow = dgv_DSKhachHang.Rows[e.RowIndex];

            string maKH = selectedRow.Cells[1].Value.ToString();
            string tenKH = selectedRow.Cells[2].Value.ToString();
            string diaChi = selectedRow.Cells[3].Value.ToString();
            string sdt = selectedRow.Cells[4].Value.ToString();
            string email = selectedRow.Cells[5].Value.ToString();
            string anhKH = selectedRow.Cells[6].Value.ToString();

            txb_MaKH.Text = maKH;
            txb_TenKH.Text = tenKH;
            txb_DiaChi.Text = diaChi;
            txb_SDT.Text = sdt;
            txb_Email.Text = email;
            ptb_AnhKH.ImageLocation = anhKH;

            currentAnhKH = anhKH;

            resetButton();
            panel_FormFields.Enabled = false;

            btn_ChinhSua.Visible = true;
            btn_Xoa.Visible = true;
        }

        //=========================== Nút lưu ==================================================
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string maKH = txb_MaKH.Text?.Trim();
            string tenKH = txb_TenKH.Text?.Trim();
            string diaChi = txb_DiaChi.Text?.Trim();
            string sdt = txb_SDT.Text?.Trim();
            string email = txb_Email.Text?.Trim();
            string anhKH = Path.GetFileName(ptb_AnhKH.ImageLocation);

            if (string.IsNullOrEmpty(maKH) || string.IsNullOrEmpty(tenKH) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(anhKH))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra hợp lệ của số điện thoại
            if (!Regex.IsMatch(sdt, @"^(0[3|5|7|8|9])[0-9]{8}$"))
            {
                MessageBox.Show("Số điện thoại điển vào không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra tính hợp lệ của email nhập vào
            if (!Regex.IsMatch(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
            {
                MessageBox.Show("Email điền vào không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            anhKH = "../../../Assets/KhachHang/" + anhKH;

            KhachHangModels khachHang = new KhachHangModels(maKH, tenKH, diaChi, sdt, email, anhKH);

            if (trangThai == 1)
            {
                luuThemMoiKhachHang(khachHang);
            }
            else if (trangThai == 2)
            {
                luuChinhSuaKhachHang(khachHang);
            }
        }

        //Lưu thêm mới khách hàng
        public void luuThemMoiKhachHang(KhachHangModels khachHang)
        {
            try
            {
                khachHangService.ThemKhachHang(khachHang);

                string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
                string destFolder = Path.Combine(projectPath, "Assets", "KhachHang");
                string destFilePath = Path.Combine(destFolder, Path.GetFileName(ptb_AnhKH.ImageLocation));
                File.Copy(ptb_AnhKH.ImageLocation, destFilePath, true);

                MessageBox.Show("Thêm khách hàng thành công", "Thông báo");

                danhSachKhachHang = khachHangService.GetDanhSachKhachHang();
                dgv_DSKhachHang.Rows.Clear();
                hienThiDanhSachKhachHang();

                resetFormField();
                resetButton();
            }
            catch
            {
                MessageBox.Show("Lỗi khi thêm khách hàng!", "Thông báo");
            }
        }

        //Lưu chỉnh sửa khách hàng
        public void luuChinhSuaKhachHang(KhachHangModels khachHang)
        {
            try
            {
                if (ptb_AnhKH.ImageLocation != currentAnhKH)
                {
                    string oldImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, currentAnhKH);
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }

                    string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
                    string destFolder = Path.Combine(projectPath, "Assets", "KhachHang");
                    string destFilePath = Path.Combine(destFolder, Path.GetFileName(ptb_AnhKH.ImageLocation));
                    File.Copy(ptb_AnhKH.ImageLocation, destFilePath, true);
                }

                khachHangService.SuaKhachHang(khachHang);

                MessageBox.Show("Sửa khách hàng thành công", "Thông báo");

                danhSachKhachHang = khachHangService.GetDanhSachKhachHang();
                dgv_DSKhachHang.Rows.Clear();
                hienThiDanhSachKhachHang();

                resetFormField();
                resetButton();
            }
            catch
            {
                MessageBox.Show("Lỗi khi sửa khách hàng!", "Thông báo");
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
            btn_ChonAnh.Visible = true;

            int soKhachHang = danhSachKhachHang.Count + 1;
            string maKH = "KH00" + soKhachHang;
            txb_MaKH.Text = maKH;

            trangThai = 1;

            panel_FormFields.Enabled = true;
        }


        //======================================== nút chỉnh sửa =========================================
        private void btn_ChinhSua_Click(object sender, EventArgs e)
        {
            panel_btn_Luu_Huy.Visible = true;
            btn_ChonAnh.Visible = true;

            trangThai = 2;

            panel_FormFields.Enabled = true;
        }


        //======================================== nút xóa =========================================
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maKH = txb_MaKH.Text;

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng {maKH} không?", "Xác nhận", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    khachHangService.XoaKhachHang(maKH);

                    string oldImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ptb_AnhKH.ImageLocation);
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }

                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo");

                    danhSachKhachHang = khachHangService.GetDanhSachKhachHang();
                    dgv_DSKhachHang.Rows.Clear();
                    hienThiDanhSachKhachHang();

                    resetFormField();
                    resetButton();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi xóa khách hàng!", "Thông báo");
            }
        }


        //============================== Nút chọn ảnh ===================================
        private void btn_ChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ptb_AnhKH.ImageLocation = ofd.FileName;
            }
        }
    }
}
