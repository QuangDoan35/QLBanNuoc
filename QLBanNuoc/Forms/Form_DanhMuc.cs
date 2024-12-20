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
    public partial class Form_DanhMuc : Form
    {
        DanhMucService danhMucService = new DanhMucService();
        List<DanhMucModels> danhMucs = new List<DanhMucModels>();
        int trangThai; //trạng thái của nút lưu: 1 - thêm mới, 2 - chỉnh sửa
        string currentAnhDM;

        public Form_DanhMuc()
        {
            InitializeComponent();
        }

        private void Form_DanhMuc_Load(object sender, EventArgs e)
        {
            danhMucs = danhMucService.GetDanhMuc();

            hienThiDanhMuc();
        }

        //========================= Hiển thị danh sách danh mục =============================================
        public void hienThiDanhMuc()
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


        //========================= Xóa trắng thông tin trong form và vô hiệu hóa form =====================
        public void resetFormField()
        {
            //Xóa trắng thông tin trong form
            txb_MaDM.Text = string.Empty;
            txb_TenDM.Text = string.Empty;
            txb_MoTa.Text = string.Empty;
            ptb_AnhDM.ImageLocation = "../../../Assets/Images/product-image.png";

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


        //============================== Hiển thị thông tin chi tiết lên form ===============================
        private void dgv_DanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu chỉ số dòng không hợp lệ
            if (e.RowIndex < 0 || e.RowIndex >= dgv_DanhMuc.Rows.Count)
                return;

            DataGridViewRow selectedRow = dgv_DanhMuc.Rows[e.RowIndex];

            string maDM = selectedRow.Cells[1].Value.ToString();
            string tenDM = selectedRow.Cells[2].Value.ToString();
            string mota = selectedRow.Cells[3].Value.ToString();
            string anhDM = selectedRow.Cells[4].Value.ToString();

            txb_MaDM.Text = maDM;
            txb_TenDM.Text = tenDM;
            txb_MoTa.Text = mota;

            string imageLocation = @$"{selectedRow.Cells[4].Value}";
            ptb_AnhDM.ImageLocation = imageLocation;

            currentAnhDM = anhDM;

            resetButton();
            panel_FormFields.Enabled = false;

            //Hiển thị nút chỉnh sửa và xóa
            btn_ChinhSua.Visible = true;
            btn_Xoa.Visible = true;
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


        //============================= Nút lưu =========================================================
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            //Lấy thông tin ở form và truyền vào hàm lưu tương ứng
            string maDM = txb_MaDM.Text;
            string tenDM = txb_TenDM.Text;
            string moTa = txb_MoTa.Text;
            string anhDM = Path.GetFileName(ptb_AnhDM.ImageLocation);

            // Chưa điền đầy đủ thông tin thì in ra thông báo lỗi
            if (string.IsNullOrEmpty(maDM) || string.IsNullOrEmpty(tenDM) || string.IsNullOrEmpty(moTa) || string.IsNullOrEmpty(anhDM))
            {
                MessageBox.Show("Bạn chưa nhâp đủ thông tin!", "Thông báo");
                return;
            }
            else
            {
                anhDM = "../../../Assets/DanhMuc/" + anhDM;

                DanhMucModels danhMuc = new DanhMucModels(maDM, tenDM, moTa, anhDM);

                if (trangThai == 1)
                {
                    luuThemMoi(danhMuc);
                }
                else if (trangThai == 2)
                {
                    luuChinhSua(danhMuc);
                }
            }
        }

        //Lưu thêm mới danh mục
        public void luuThemMoi(DanhMucModels danhMuc)
        {
            string maDM = danhMuc.MaDM;
            string tenDM = danhMuc.TenDM;
            string moTa = danhMuc.MoTa;
            string anhDM = danhMuc.AnhDM;

            try
            {
                //Lưu thông tin vào database
                danhMucService.ThemDanhMuc(maDM, tenDM, moTa, anhDM);

                // Lưu ảnh vào thư mục của dự án
                string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
                string destFolder = Path.Combine(projectPath, "Assets", "DanhMuc");
                string destFilePath = Path.Combine(destFolder, Path.GetFileName(ptb_AnhDM.ImageLocation));
                File.Copy(ptb_AnhDM.ImageLocation, destFilePath, true);

                MessageBox.Show("Thêm danh mục thành công", "Thông báo");

                //Cập nhật lại danh sách khi lưu thành công
                danhMucs = danhMucService.GetDanhMuc();
                dgv_DanhMuc.Rows.Clear(); //Xóa dữ liệu cũ trong bảng trước khi hiển thị lại
                hienThiDanhMuc();

                // Xóa thông tin trong form và ẩn nút không cần thiết
                resetFormField();
                resetButton();
            }
            catch
            {
                MessageBox.Show("Thêm danh mục thất bại!", "Thông báo");
            }
        }

        // Lưu chính sửa danh mục
        public void luuChinhSua(DanhMucModels danhMuc)
        {
            string maDM = danhMuc.MaDM;
            string tenDM = danhMuc.TenDM;
            string moTa = danhMuc.MoTa;
            string anhDM = danhMuc.AnhDM;

            try
            {
                // Kiểm tra nếu ảnh mới được chọn
                if (ptb_AnhDM.ImageLocation != currentAnhDM)
                {
                    // Nếu ảnh mới khác ảnh cũ
                    // Xóa ảnh cũ đi
                    string oldImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, currentAnhDM);
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath); // Xóa file cũ
                    }

                    // Lưu ảnh mới vào thư mục của dự án
                    string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
                    string destFolder = Path.Combine(projectPath, "Assets", "DanhMuc");
                    string destFilePath = Path.Combine(destFolder, Path.GetFileName(ptb_AnhDM.ImageLocation));
                    File.Copy(ptb_AnhDM.ImageLocation, destFilePath, true);
                }

                // Lưu thông tin danh mục vào cơ sở dữ liệu
                danhMucService.SuaDanhMuc(maDM, tenDM, moTa, anhDM);

                MessageBox.Show("Sửa danh mục thành công", "Thông báo");

                // Cập nhật lại danh sách khi sửa thành công
                danhMucs = danhMucService.GetDanhMuc();
                dgv_DanhMuc.Rows.Clear(); // Xóa dữ liệu cũ trong bảng
                hienThiDanhMuc();

                // Xóa thông tin trong form và ẩn nút không cần thiết
                resetFormField();
                resetButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sửa danh mục thất bại! Lỗi: {ex.Message}", "Thông báo");
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
            int soDanhMuc = danhMucs.Count + 1;
            string maDM = "DM00" + soDanhMuc;
            txb_MaDM.Text = maDM;

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
                string maDM = txb_MaDM.Text;

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa danh mục {maDM} không?", "Xác nhận", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    danhMucService.XoaDanhMuc(maDM); // Xóa trong cơ sở dữ liệu
                    MessageBox.Show("Xóa danh mục thành công!", "Thông báo"); // in ra thông báo

                    // Xóa ảnh của sản phẩm đi
                    string oldImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ptb_AnhDM.ImageLocation);
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }

                    //Cập nhật lại danh sách hiển thị
                    danhMucs = danhMucService.GetDanhMuc();
                    dgv_DanhMuc.Rows.Clear(); //Xóa dữ liệu cũ trong bảng trước khi hiển thị lại
                    hienThiDanhMuc();

                    resetFormField();
                    resetButton();
                }
            }
            catch
            {
                //In ra thông báo không thể xóa danh mục
                MessageBox.Show("Không thể xóa danh mục này!", "Thông báo");
            }
        }


        //=============================== Nút chọn ảnh =================================================
        private void btn_ChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ptb_AnhDM.ImageLocation = ofd.FileName;
            }
        }
    }
}
