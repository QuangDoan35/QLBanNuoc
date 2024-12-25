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
    public partial class Form_SanPham : Form
    {
        SanPhamService sanPhamService = new SanPhamService();
        List<SanPhamModels> danhSachSanPham = new List<SanPhamModels>();
        int trangThai; //trạng thái của nút lưu: 1 - thêm mới, 2 - chỉnh sửa
        string currentAnhSP;

        public string maSPTimKiem { get; set; }

        public Form_SanPham()
        {
            InitializeComponent();

        }

        private void Form_SanPham_Load(object sender, EventArgs e)
        {
            hienThiDanhSachSanPham();

            chonSanPhamTimKiem();
        }

        //========================= Xóa trắng thông tin trong form và vô hiệu hóa form =====================
        public void resetFormField()
        {
            //Xóa trắng thông tin trong form
            txb_MaSP.Text = string.Empty;
            txb_TenSP.Text = string.Empty;
            txb_MaSP.Text = string.Empty;
            txb_SoLuongTon.Text = string.Empty;
            txb_SoLuongDaBan.Text = string.Empty;
            txb_Gia.Text = string.Empty;
            txb_MoTa.Text = string.Empty;
            ptb_AnhSP.ImageLocation = "../../../Assets/Images/product-image.png";

            panel_FormFields.Enabled = false;
        }

        public void resetButton()
        {
            //Ẩn các nút sửa, xóa, lưu và hủy
            btn_ChinhSua.Visible = false;
            btn_Xoa.Visible = false;
            btn_ChonAnh.Visible = false;
            panel_btn_Luu_Huy.Visible = false;
        }


        //=============================== Hiển thị danh sách sản phẩm ====================================
        public void hienThiDanhSachSanPham()
        {
            danhSachSanPham = sanPhamService.GetDanhSachSanPham();

            int stt = 1; // Khởi tạo số thứ tự
            foreach (SanPhamModels sanPham in danhSachSanPham)
            {
                // Thêm từng dòng vào DataGridView
                dgv_DSSanPham.Rows.Add(
                    stt, // Số thứ tự
                    sanPham.MaSP,
                    sanPham.MaDM,
                    sanPham.TenSP,
                    sanPham.SoLuongTon,
                    sanPham.SoLuongDaBan,
                    sanPham.Gia,
                    sanPham.MoTa,
                    sanPham.AnhSanPham
                );
                stt++; // Tăng số thứ tự
            }
        }


        //============================== Hiển thị chi tiết sản phẩm ============================================
        private void dgv_DSSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu chỉ số dòng không hợp lệ
            if (e.RowIndex < 0 || e.RowIndex >= dgv_DSSanPham.Rows.Count)
                return;

            DataGridViewRow selectedRow = dgv_DSSanPham.Rows[e.RowIndex];

            string maSP = selectedRow.Cells[1].Value.ToString();
            string maDM = selectedRow.Cells[2].Value.ToString();
            string tenSP = selectedRow.Cells[3].Value.ToString();
            int soLuongTon = (int)selectedRow.Cells[4].Value;
            int soLuongDaBan = (int)selectedRow.Cells[5].Value;
            decimal gia = (decimal)selectedRow.Cells[6].Value;
            string moTa = selectedRow.Cells[7].Value.ToString();
            string anhSP = selectedRow.Cells[8].Value.ToString();

            txb_MaSP.Text = maSP;
            txb_MaDM.Text = maDM;
            txb_TenSP.Text = tenSP;
            txb_SoLuongTon.Text = soLuongTon.ToString();
            txb_SoLuongDaBan.Text = soLuongDaBan.ToString();
            txb_Gia.Text = gia.ToString();
            txb_MoTa.Text = moTa;
            ptb_AnhSP.ImageLocation = anhSP;

            currentAnhSP = anhSP;

            resetButton();
            panel_FormFields.Enabled = false;

            //Hiển thị nút chỉnh sửa và xóa
            btn_ChinhSua.Visible = true;
            btn_Xoa.Visible = true;
        }


        //============================= Nút lưu =========================================================
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            // Kiểm tra và chuyển đổi dữ liệu đầu vào
            string maSanPham = txb_MaSP.Text?.Trim();
            string maDanhMuc = txb_MaDM.Text?.Trim();
            string tenSanPham = txb_TenSP.Text?.Trim();
            string moTa = txb_MoTa.Text?.Trim();
            string anhSP = Path.GetFileName(ptb_AnhSP.ImageLocation);

            if (string.IsNullOrEmpty(maSanPham) || string.IsNullOrEmpty(maDanhMuc) || string.IsNullOrEmpty(tenSanPham))
            {
                // Thông báo lỗi nếu dữ liệu bắt buộc bị bỏ trống
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txb_SoLuongTon.Text, out int soLuongTon) || soLuongTon < 0)
            {
                MessageBox.Show("Số lượng tồn phải là một số nguyên không âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txb_SoLuongDaBan.Text, out int soLuongDaBan) || soLuongDaBan < 0)
            {
                MessageBox.Show("Số lượng đã bán phải là một số nguyên không âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txb_Gia.Text, out decimal gia) || gia < 0)
            {
                MessageBox.Show("Giá sản phẩm phải là một số thực không âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            anhSP = "../../../Assets/SanPham/" + anhSP;

            // Tạo đối tượng sản phẩm
            SanPhamModels sanPham = new SanPhamModels(
                maSanPham,
                maDanhMuc,
                tenSanPham,
                soLuongTon,
                soLuongDaBan,
                gia,
                moTa,
                anhSP
            );

            if (trangThai == 1)
            {
                luuThemMoi(sanPham);
            }
            else if (trangThai == 2)
            {
                luuChinhSua(sanPham);
            }
        }

        //Lưu thêm mới danh mục
        public void luuThemMoi(SanPhamModels sanPham)
        {
            try
            {
                //Lưu thông tin vào database
                sanPhamService.ThemSanPham(sanPham);

                // Lưu ảnh vào thư mục của dự án
                string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
                string destFolder = Path.Combine(projectPath, "Assets", "SanPham");
                string destFilePath = Path.Combine(destFolder, Path.GetFileName(ptb_AnhSP.ImageLocation));
                File.Copy(ptb_AnhSP.ImageLocation, destFilePath, true);

                MessageBox.Show("Thêm sản phẩm thành công", "Thông báo");

                //Cập nhật lại danh sách hiển thị
                danhSachSanPham = sanPhamService.GetDanhSachSanPham();
                dgv_DSSanPham.Rows.Clear(); //Xóa dữ liệu cũ trong bảng trước khi hiển thị lại
                hienThiDanhSachSanPham();

                // Xóa thông tin trong form và ẩn nút không cần thiết
                resetFormField();
                resetButton();
            }
            catch
            {
                MessageBox.Show("Mã danh mục không tồn tại!", "Thông báo");
            }
        }

        // Lưu chính sửa sản phẩm
        public void luuChinhSua(SanPhamModels sanPham)
        {
            try
            {
                // Kiểm tra nếu ảnh mới được chọn
                if (ptb_AnhSP.ImageLocation != currentAnhSP)
                {
                    // Nếu ảnh mới khác ảnh cũ
                    // Xóa ảnh cũ đi
                    string oldImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, currentAnhSP);
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath); // Xóa file cũ
                    }

                    // Lưu ảnh mới vào thư mục của dự án
                    string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
                    string destFolder = Path.Combine(projectPath, "Assets", "SanPham");
                    string destFilePath = Path.Combine(destFolder, Path.GetFileName(ptb_AnhSP.ImageLocation));
                    File.Copy(ptb_AnhSP.ImageLocation, destFilePath, true);
                }

                // Lưu thông tin danh mục vào cơ sở dữ liệu
                sanPhamService.SuaSanPham(sanPham);

                MessageBox.Show("Sửa sản phẩm thành công", "Thông báo");

                //Cập nhật lại danh sách hiển thị
                danhSachSanPham = sanPhamService.GetDanhSachSanPham();
                dgv_DSSanPham.Rows.Clear(); //Xóa dữ liệu cũ trong bảng trước khi hiển thị lại
                hienThiDanhSachSanPham();

                // Xóa thông tin trong form và ẩn nút không cần thiết
                resetFormField();
                resetButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mã danh mục không tồn tại!", "Thông báo");
            }
        }




        //============================== Nút hủy ============================================================
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            //Xác nhận hủy
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy không", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                resetFormField();
                resetButton();
            }
        }

        //============================== Nút Thêm mới =====================================================
        private void btn_ThemMoi_Click(object sender, EventArgs e)
        {
            resetFormField();
            resetButton();

            //Hiển thị nút thêm ảnh, Lưu và hủy
            panel_btn_Luu_Huy.Visible = true;
            btn_ChonAnh.Visible = true;

            // Tự động Tạo mã
            // Tạo mã danh mục mới tự động
            // Lấy số danh mục đã có tăng thêm 1 -> ra mã danh mục mới
            int soSanPham = danhSachSanPham.Count + 1;
            string maSP = "SP00" + soSanPham;
            txb_MaSP.Text = maSP;

            // Đánh dấu trạng thái là đang thêm mới cho nút lưu biết
            trangThai = 1;

            panel_FormFields.Enabled = true;
        }


        //============================== Nút Chỉnh sửa =====================================================
        private void btn_ChinhSua_Click(object sender, EventArgs e)
        {
            //Hiển thị nút chọn ảnh, Lưu và hủy
            panel_btn_Luu_Huy.Visible = true;
            btn_ChonAnh.Visible = true;

            // Đánh dấu trạng thái là đang chỉnh sửa cho nút lưu biết
            trangThai = 2;

            panel_FormFields.Enabled = true;
        }


        //============================== Nút Xóa =====================================================
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maSP = txb_MaSP.Text;

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm {maSP} không?", "Xác nhận", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    sanPhamService.XoaSanPham(maSP); // Xóa trong cơ sở dữ liệu
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo"); // in ra thông báo

                    // Xóa ảnh của sản phẩm đi
                    string oldImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ptb_AnhSP.ImageLocation);
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }

                    //Cập nhật lại danh sách hiển thị
                    danhSachSanPham = sanPhamService.GetDanhSachSanPham();
                    dgv_DSSanPham.Rows.Clear(); //Xóa dữ liệu cũ trong bảng trước khi hiển thị lại
                    hienThiDanhSachSanPham();

                    resetFormField();
                    resetButton();
                }
            }
            catch
            {
                //In ra thông báo không thể xóa danh mục
                MessageBox.Show("Không thể xóa sản phẩm này!", "Thông báo");
            }
        }


        //=============================== Nút chọn ảnh =================================================
        private void btn_ChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ptb_AnhSP.ImageLocation = ofd.FileName;
            }
        }

        //========================= Chọn vào hàng được tìm kiếm ======================================
        private void chonSanPhamTimKiem()
        {
            foreach (DataGridViewRow row in dgv_DSSanPham.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == maSPTimKiem)
                {
                    // Chọn dòng
                    row.Selected = true;

                    // Đặt con trỏ vào ô của dòng
                    dgv_DSSanPham.CurrentCell = row.Cells[1];

                    // Kích hoạt sự kiện CellClick
                    int rowIndex = row.Index;
                    dgv_DSSanPham_CellClick(this, new DataGridViewCellEventArgs(1, rowIndex));
                    break;
                }
            }
        }
    }
}
