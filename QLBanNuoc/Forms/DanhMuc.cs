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
    public partial class DanhMuc : Form_Layout
    {
        DanhMucService danhMucService = new DanhMucService();
        List<DanhMucModels> danhMucs = new List<DanhMucModels>();
        private int trangThai;
        private string selectedFilePath;
        private string originalAnhDM;

        public DanhMuc()
        {
            InitializeComponent();

            danhMucs = danhMucService.GetDanhMuc();
        }

        private void DanhMuc_Load(object sender, EventArgs e)
        {
            HienThiDanhMuc();
        }

        //========================= Hiển thị danh sách danh mục =======================
        public void HienThiDanhMuc()
        {
            int stt = 1; // Khởi tạo số thứ tự
            foreach (DanhMucModels danhMuc in danhMucs)
            {
                // Thêm từng dòng vào DataGridView
                dgv_DanhMuc.Rows.Add(
                    stt, // Số thứ tự
                    danhMuc.MaDM,
                    danhMuc.TenDM,
                    danhMuc.MoTa,
                    danhMuc.AnhDM
                );
                stt++; // Tăng số thứ tự
            }
        }

        //========================== Xóa thông tin nhập trong form ===================================
        public void XoaForm()
        {
            if (
                !string.IsNullOrEmpty(txb_MaDM.Text) ||
                !string.IsNullOrEmpty(txb_TenDM.Text) ||
                !string.IsNullOrEmpty(txb_MoTa.Text)
            )
            {
                txb_MaDM.Text = string.Empty;
                txb_TenDM.Text = string.Empty;
                txb_MoTa.Text = string.Empty;
                ptb_SanPham.ImageLocation = "../../../Assets/Images/login-background.png";
            }
        }

        //=============== Hiển thị chi tiết danh mục khi click =======================================
        private void dgv_DanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_DanhMuc.Rows[e.RowIndex];

                string maDM = selectedRow.Cells[1].Value.ToString();
                string tenDM = selectedRow.Cells[2].Value.ToString();
                string mota = selectedRow.Cells[3].Value.ToString();
                string anhDM = selectedRow.Cells[4].Value.ToString();

                txb_MaDM.Text = maDM;
                txb_TenDM.Text = tenDM;
                txb_MoTa.Text = mota;
                txb_AnhDM.Text = anhDM;

                string imageLocation = @$"{selectedRow.Cells[4].Value}";
                ptb_SanPham.ImageLocation = imageLocation;

                originalAnhDM = anhDM; // Lưu đường dẫn ảnh gốc để kiểm tra trong bước chỉnh sửa coi ảnh có được chọn mới để chỉnh sửa hay là không

                panel17.Enabled = false;
                panel_ButtonChinhSua.Visible = true;
                panel_ButtonXoa.Visible = true;
                panel_ButtonLuu.Visible = false;
                panel_ButtonHuy.Visible = false;

                panel_ButtonThemMoi.Visible = true;
            }
        }

        //================== Nút thêm mới danh mục =================================
        private void btn_ThemMoi_Click(object sender, EventArgs e)
        {
            // Xóa thông tin nhập trong form 
            XoaForm();

            // Tạo mã danh mục mới tự động
            // Lấy số danh mục đã có tăng thêm 1 -> ra mã danh mục mới
            int soDanhMuc = danhMucs.Count + 1;
            string maDM = "DM00" + soDanhMuc;
            txb_MaDM.Text = maDM;

            // Đánh dấu trạng thái là đang thêm mới cho nút lưu biết
            trangThai = 1;
        }

        //===================== Nút chỉnh sửa ==========================
        private void btn_ChinhSua_Click(object sender, EventArgs e)
        {
            panel17.Enabled = true; // Mở khóa cho form nhập thông tin
            panel_ButtonLuu.Visible = true;
            panel_ButtonHuy.Visible = true;
            panel_ButtonXoa.Visible = false;
            panel_ButtonThemMoi.Visible = false;

            // Đánh dấu trạng thái là đang chỉnh sửa cho nút lưu biết
            trangThai = 2;
        }

        //===================== Nút xóa ==========================
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maDM = txb_MaDM.Text;

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa danh mục {maDM} không?", "Xác nhận", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes) {
                    danhMucService.XoaDanhMuc(maDM); // Xóa trong cơ sở dữ liệu
                    MessageBox.Show("Xóa danh mục thành công!", "Thông báo"); // in ra thông báo

                    // Xóa ảnh của sản phẩm đi
                    string oldImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, originalAnhDM);
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }

                    //Cập nhật lại danh sách hiển thị
                    danhMucs = danhMucService.GetDanhMuc();
                    dgv_DanhMuc.Rows.Clear(); //Xóa dữ liệu cũ trong bảng trước khi hiển thị lại
                    HienThiDanhMuc();

                    XoaForm();
                }
            } 
            catch
            {
                //In ra thông báo không thể xóa danh mục
                MessageBox.Show("Không thể xóa danh mục này!", "Thông báo");
            }
        }

        //===================== Nút Lưu ========================
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (trangThai == 1)
            { 
                LuuThemMoi();
            }
            else if (trangThai == 2)
            {
                LuuChinhSua();
            }
        }

        // Lưu thêm mới
        public void LuuThemMoi ()
        {
            // Chưa điền đầy đủ thông tin thì in ra thông báo lỗi
            if (string.IsNullOrEmpty(txb_TenDM.Text) || string.IsNullOrEmpty(txb_MoTa.Text) || string.IsNullOrEmpty(txb_AnhDM.Text))
            {
                MessageBox.Show("Bạn chưa nhâp đủ thông tin!", "Thông báo");
                return;
            }

            // Đã nhập đủ thông tin
            string maDM = txb_MaDM.Text;
            string tenDM = txb_TenDM.Text;
            string moTa = txb_MoTa.Text;
            string anhDM = "../../../Assets/DanhMuc/" + txb_AnhDM.Text;

            try
            {
                //Lưu thông tin vào database
                danhMucService.ThemDanhMuc(maDM, tenDM, moTa, anhDM);

                // Lưu ảnh vào thư mục của dự án
                string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
                string destFolder = Path.Combine(projectPath, "Assets", "DanhMuc");
                string destFilePath = Path.Combine(destFolder, Path.GetFileName(selectedFilePath));
                File.Copy(selectedFilePath, destFilePath, true);

                MessageBox.Show("Thêm danh mục thành công", "Thông báo");

                //Cập nhật lại danh sách khi lưu thành công
                danhMucs = danhMucService.GetDanhMuc();
                dgv_DanhMuc.Rows.Clear(); //Xóa dữ liệu cũ trong bảng trước khi hiển thị lại
                HienThiDanhMuc();

                XoaForm();
            }
            catch
            {
                MessageBox.Show("Thêm danh mục thất bại!", "Thông báo");
            }
        }

        // Lưu chỉnh sửa
        public void LuuChinhSua ()
        {
            // Chưa điền đầy đủ thông tin thì in ra thông báo lỗi
            if (string.IsNullOrEmpty(txb_TenDM.Text) || string.IsNullOrEmpty(txb_MoTa.Text) || string.IsNullOrEmpty(txb_AnhDM.Text))
            {
                MessageBox.Show("Bạn chưa nhâp đủ thông tin!", "Thông báo");
                return;
            }

            // Đã nhập đủ thông tin
            string maDM = txb_MaDM.Text;
            string tenDM = txb_TenDM.Text;
            string moTa = txb_MoTa.Text;
            string anhDM = txb_AnhDM.Text;

            try
            {
                //Kiểm tra xem coi có thay đổi ảnh hay là không
                if (!originalAnhDM.Equals(anhDM)) // Nếu đã chọn ảnh mới
                {
                    // Xóa ảnh cũ
                    string oldImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, originalAnhDM); 
                    if (File.Exists(oldImagePath)) 
                    { 
                        File.Delete(oldImagePath); 
                    }

                    anhDM = "../../../Assets/DanhMuc/" + txb_AnhDM.Text;

                    // Lưu ảnh vào thư mục của dự án
                    string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
                    string destFolder = Path.Combine(projectPath, "Assets", "DanhMuc");
                    string destFilePath = Path.Combine(destFolder, Path.GetFileName(selectedFilePath));
                    File.Copy(selectedFilePath, destFilePath, true);
                }

                //Lưu thông tin vào database
                danhMucService.SuaDanhMuc(maDM, tenDM, moTa, anhDM);

                MessageBox.Show("Sửa danh mục thành công", "Thông báo");

                //Cập nhật lại danh sách khi sửa thành công
                danhMucs = danhMucService.GetDanhMuc();
                dgv_DanhMuc.Rows.Clear(); //Xóa dữ liệu cũ trong bảng trước khi hiển thị lại
                HienThiDanhMuc();

                XoaForm();
                panel17.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Sửa danh mục thất bại!", "Thông báo");
            }
        }

        //================= Nút hủy ===============================
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            DialogResult result;

            if (trangThai == 1)
            {
                result = MessageBox.Show("Bạn có chắc chắn muốn hủy lưu thêm mới sản phẩm?", "Thông báo", MessageBoxButtons.YesNo);
            }
            else
            {
                result = MessageBox.Show("Bạn có chắc chắn muốn hủy Chỉnh sửa sản phẩm?", "Thông báo", MessageBoxButtons.YesNo);
            }

            if (result == DialogResult.Yes)
            {
                // Ẩn nút sửa, xóa, lưu, hủy
                panel_ButtonChinhSua.Visible = false;
                panel_ButtonXoa.Visible = false;
                panel_ButtonLuu.Visible = false;
                panel_ButtonHuy.Visible = false;

                // Xóa thông tin trong form và vô hiệu hóa form nhập thông tin đi
                XoaForm();
                panel17.Enabled = false;
            }

            panel_ButtonThemMoi.Visible = true;
        }

        //======================= Nút chọn ảnh =============================
        private void btn_ChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;)|*.jpg; *.jpeg; *.gif; *.bmp;";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Hiển thị tên ảnh sản phẩm
                txb_AnhDM.Text = Path.GetFileName(openFileDialog.FileName);
                //Hiển thị ảnh sản phẩm
                ptb_SanPham.Image = new Bitmap(openFileDialog.FileName);

                //Lưu đường dẫn ảnh
                selectedFilePath = openFileDialog.FileName;
            }
        }
    }
}
