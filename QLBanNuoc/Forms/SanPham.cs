using Azure;
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
    public partial class SanPham : Form_Layout
    {
        SanPhamService sanPhamService = new SanPhamService();
        List<SanPhamModels> danhSachSanPham = new List<SanPhamModels>();
        private int trangThaiLuu; // Lưu trạng thái lưu thông tin: 1 là thêm mới, 2 là chỉnh sửa
        private string selectedFilePath;
        private string originalAnhSP;

        public SanPham()
        {
            InitializeComponent();

            //Thêm sự kiện click cho nút chỉnh sửa, xóa, lưu và hủy
            btn_ChinhSua.Click += btn_ChinhSua_Click;
            btn_Xoa.Click += btn_Xoa_Click;
            btn_Luu.Click += btn_Luu_Click;
            btn_Huy.Click += btn_Huy_Click;
        }


        private void SanPham_Load(object sender, EventArgs e)
        {
            HienThiDanhSachSanPham();
        }

        //============================ Xóa trắng form điền thông tin ===================================
        public void XoaForm()
        {
            txb_MaSanPham.Text = string.Empty;
            txb_TenSP.Text = string.Empty;
            txb_MaDM.Text = string.Empty;
            txb_SoLuongTon.Text = string.Empty;
            txb_SoLuongDaBan.Text = string.Empty;
            txb_Gia.Text = string.Empty;
            txb_MoTa.Text = string.Empty;
            txb_AnhSP.Text = string.Empty;

            ptb_SanPham.ImageLocation = "../../../Assets/Images/login-background.png";

            panel17.Enabled = false;
        }

        //=============================== Hiển thị danh sách sản phẩm ====================================
        public void HienThiDanhSachSanPham()
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

        //=============================== Hiển thị chi tiết sản phẩm khi click =======================================
        private void dgv_DSSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_DSSanPham.Rows[e.RowIndex];

                string maSP = selectedRow.Cells[1].Value.ToString();
                string maDM = selectedRow.Cells[2].Value.ToString();
                string tenSP = selectedRow.Cells[3].Value.ToString();
                int soLuongTon = (int)selectedRow.Cells[4].Value;
                int soLuongDaBan = (int)selectedRow.Cells[5].Value;
                decimal gia = (decimal)selectedRow.Cells[6].Value;
                string moTa = selectedRow.Cells[7].Value.ToString();
                string anhSP = selectedRow.Cells[8].Value.ToString();

                txb_MaSanPham.Text = maSP;
                txb_TenSP.Text = tenSP;
                txb_MaDM.Text = maDM;
                txb_SoLuongTon.Text = soLuongTon.ToString();
                txb_SoLuongDaBan.Text = soLuongDaBan.ToString();
                txb_Gia.Text = gia.ToString();
                txb_MoTa.Text = moTa;
                txb_AnhSP.Text = anhSP;

                string imageLocation = @$"{selectedRow.Cells[8].Value}";
                ptb_SanPham.ImageLocation = imageLocation;

                originalAnhSP = anhSP; // Lưu đường dẫn ảnh gốc để kiểm tra trong bước chỉnh sửa coi ảnh có được chọn mới để chỉnh sửa hay là không


                // Hiển thị nút chỉnh sửa và nút xóa, ẩn nút lưu
                panel_ButtonThemMoi.Visible = true;
                panel_ButtonChinhSua.Visible = true;
                panel_ButtonXoa.Visible = true;
                panel_ButtonLuu.Visible = false;
                panel_ButtonHuy.Visible = false;
            }
        }

        // ============================ Nút chọn ảnh ===================================
        private void btn_ChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;)|*.jpg; *.jpeg; *.gif; *.bmp;";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Hiển thị tên ảnh sản phẩm
                txb_AnhSP.Text = Path.GetFileName(openFileDialog.FileName);
                //Hiển thị ảnh sản phẩm
                ptb_SanPham.Image = new Bitmap(openFileDialog.FileName);

                //Lưu đường dẫn ảnh
                selectedFilePath = openFileDialog.FileName;
            }
        }

        //============================== Nút thêm mới ==================================
        private void btn_ThemMoi_Click(object sender, EventArgs e)
        {
            trangThaiLuu = 1; // Lưu trạng thái là đang thêm mới để cho nút Lưu biết

            //Xóa thông tin cũ trong form
            XoaForm();

            //Tự động tạo mã sản phẩm mới và gán vào ô mã sản phẩm
            string maSP = $"SP00{danhSachSanPham.Count + 1}";
            txb_MaSanPham.Text = maSP;
        }

        //============================== Nút chỉnh sửa ==================================
        public void btn_ChinhSua_Click(Object sender, EventArgs e)
        {
            trangThaiLuu = 2; // Lưu trạng thái là đang chỉnh sửa để cho nút Lưu biết

            // Mở enable form nhập thông tin để chỉnh sửa
            panel17.Enabled = true;

            //Hiển thị nút lưu và hủy, ẩn nút xóa và nút thêm mới
            panel_ButtonLuu.Visible = true;
            panel_ButtonHuy.Visible = true;
            panel_ButtonXoa.Visible = false;
            panel_ButtonThemMoi.Visible = false;

            //Lấy thông tin từ form

        }

        //============================== Nút Xóa ==================================
        public void btn_Xoa_Click(Object sender, EventArgs e)
        {
            try
            {
                string maSP = txb_MaSanPham.Text;

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm {maSP} không?", "Xác nhận", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    sanPhamService.XoaSanPham(maSP); // Xóa trong cơ sở dữ liệu
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo"); // in ra thông báo

                    // Xóa ảnh của danh mục đi
                    string oldImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, originalAnhSP);
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }

                    //Cập nhật lại danh sách hiển thị
                    danhSachSanPham = sanPhamService.GetDanhSachSanPham();
                    dgv_DSSanPham.Rows.Clear(); //Xóa dữ liệu cũ trong bảng trước khi hiển thị lại
                    HienThiDanhSachSanPham();

                    XoaForm();
                }
            }
            catch
            {
                //In ra thông báo không thể xóa danh mục
                MessageBox.Show("Không thể xóa sản phẩm này!", "Thông báo");
            }
        }

        //============================== Nút Lưu ==================================
        public void btn_Luu_Click(Object sender, EventArgs e)
        {
            // Kiểm tra và chuyển đổi dữ liệu đầu vào
            string maSanPham = txb_MaSanPham.Text?.Trim();
            string maDanhMuc = txb_MaDM.Text?.Trim();
            string tenSanPham = txb_TenSP.Text?.Trim();
            string moTa = txb_MoTa.Text?.Trim();
            string anhSP = txb_AnhSP.Text;

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

            // Xử lý lưu
            if (trangThaiLuu == 1)
            {
                sanPham.AnhSanPham = $"../../../Assets/SanPham/{txb_AnhSP.Text?.Trim()}";
                LuuThemMoi(sanPham);
            }
            else if (trangThaiLuu == 2)
            {
                // Kiểm tra xem coi có thay đổi ảnh không
                if (!txb_AnhSP.Text.Equals(originalAnhSP))
                {
                    sanPham.AnhSanPham = $"../../../Assets/SanPham/{txb_AnhSP.Text?.Trim()}";
                }
                LuuChinhSua(sanPham);
            }
        }

        // Lưu thêm mới
        public void LuuThemMoi(SanPhamModels sanPham)
        {
            // Đã nhập đủ thông tin
            try
            {
                //Lưu thông tin vào database
                sanPhamService.ThemSanPham(sanPham);

                // Lưu ảnh vào thư mục của dự án
                string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
                string destFolder = Path.Combine(projectPath, "Assets", "SanPham");
                string destFilePath = Path.Combine(destFolder, Path.GetFileName(selectedFilePath));
                File.Copy(selectedFilePath, destFilePath, true);

                MessageBox.Show("Thêm danh mục thành công", "Thông báo");

                //Cập nhật lại danh sách khi lưu thành công
                danhSachSanPham = sanPhamService.GetDanhSachSanPham();
                dgv_DSSanPham.Rows.Clear(); //Xóa dữ liệu cũ trong bảng trước khi hiển thị lại
                HienThiDanhSachSanPham();

                XoaForm();
            }
            catch //Trường hợp nhập vào mã danh mục không tồn tại
            {
                MessageBox.Show("Mã danh mục không tồn tại!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // Lưu chỉnh sửa
        public void LuuChinhSua(SanPhamModels sanPham)
        {
            // Đã nhập đủ thông tin
            try
            {
                //Lưu thông tin vào database
                sanPhamService.SuaSanPham(sanPham);

                // Lưu ảnh vào thư mục của dự án
                string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
                string destFolder = Path.Combine(projectPath, "Assets", "SanPham");
                string destFilePath = Path.Combine(destFolder, Path.GetFileName(selectedFilePath));
                File.Copy(selectedFilePath, destFilePath, true);

                MessageBox.Show("Thêm danh mục thành công", "Thông báo");

                //Cập nhật lại danh sách khi lưu thành công
                danhSachSanPham = sanPhamService.GetDanhSachSanPham();
                dgv_DSSanPham.Rows.Clear(); //Xóa dữ liệu cũ trong bảng trước khi hiển thị lại
                HienThiDanhSachSanPham();

                XoaForm();
            }
            catch //Trường hợp nhập vào mã danh mục không tồn tại
            {
                MessageBox.Show("Mã danh mục không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //============================== Nút Hủy ==================================
        public void btn_Huy_Click(Object sender, EventArgs e)
        {
            DialogResult result;

            if (trangThaiLuu == 1)
            {
                result = MessageBox.Show("Bạn có chắc chắn muốn hủy lưu thêm mới sản phẩm?", "Thông báo", MessageBoxButtons.YesNo);
            }
            else
            {
                result = MessageBox.Show("Bạn có chắc chắn muốn hủy Chỉnh sửa sản phẩm?", "Thông báo", MessageBoxButtons.YesNo);
            }

            if (result == DialogResult.Yes)
            {
                // Ẩn nút sửa, xóa, lưu, hủy, hiện nút thêm mới
                panel_ButtonChinhSua.Visible = false;
                panel_ButtonXoa.Visible = false;
                panel_ButtonLuu.Visible = false;
                panel_ButtonHuy.Visible = false;
                panel_ButtonThemMoi.Visible = true;

                // Xóa thông tin trong form và vô hiệu hóa form nhập thông tin đi
                XoaForm();
                panel17.Enabled = false;
            }
        }
    }
}
