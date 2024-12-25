using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using QLBanNuoc.Models;
using QLBanNuoc.Forms;

namespace QLBanNuoc.Services
{
    public class SanPhamService
    {
        private DatabaseService _databaseService;

        public SanPhamService ()
        {
            _databaseService = new DatabaseService();
        }

        //==================== Lấy ra và trả về top 10 sản phẩm bán chạy =================================
        public List<SanPhamModels> GetTop10SanPham ()
        {
            List<SanPhamModels> top10SanPham = new List<SanPhamModels>();

            SqlConnection sqlConnection = _databaseService.Connection();

            string sqlString = "SELECT TOP 14 * FROM SanPham ORDER BY SoLuongDaBan DESC";

            SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                string maSP = reader.GetString(0).Trim();
                string maDM = reader.GetString(1).Trim();
                string tenSP = reader.GetString(2).Trim();
                int soLuongTon = reader.GetInt32(3);
                int soLuongDaBan = reader.GetInt32(4);
                decimal gia = reader.GetDecimal(5);
                string moTa = reader.GetString(6).Trim();
                string anhSanPham = reader.GetString(7).Trim();

                SanPhamModels sanPham = new SanPhamModels(maSP, maDM, tenSP, soLuongTon, soLuongDaBan, gia, moTa, anhSanPham);

                top10SanPham.Add(sanPham);
            }

            sqlConnection.Close();

            return top10SanPham;
        }

        //==================== Lấy ra và trả về danh sách sản phẩm =================================
        public List<SanPhamModels> GetDanhSachSanPham ()
        {
            List<SanPhamModels> danhSachSanPham = new List<SanPhamModels>();

            SqlConnection sqlConnection = _databaseService.Connection();

            string sqlString = "SELECT * FROM SanPham";

            SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                string maSP = reader.GetString(0).Trim();
                string maDM = reader.GetString(1).Trim();
                string tenSP = reader.GetString(2).Trim();
                int soLuongTon = reader.GetInt32(3);
                int soLuongDaBan = reader.GetInt32(4);
                decimal gia = reader.GetDecimal(5);
                string moTa = reader.GetString(6).Trim();
                string anhSanPham = reader.GetString(7).Trim();

                SanPhamModels sanPham = new SanPhamModels(maSP, maDM, tenSP, soLuongTon, soLuongDaBan, gia, moTa, anhSanPham);

                danhSachSanPham.Add(sanPham);
            }

            sqlConnection.Close();

            return danhSachSanPham;
        }

        //========================== Thêm sản phẩm ===================================
        public void ThemSanPham (SanPhamModels sanPham)
        {
            SqlConnection sqlConnection = _databaseService.Connection();

            SqlCommand sqlCommand = new SqlCommand("ThemSP", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@maSP", sanPham.MaSP);
            sqlCommand.Parameters.AddWithValue("@maDM", sanPham.MaDM);
            sqlCommand.Parameters.AddWithValue("@tenSP", sanPham.TenSP);
            sqlCommand.Parameters.AddWithValue("@soLuongTon", sanPham.SoLuongTon);
            sqlCommand.Parameters.AddWithValue("@soLuongDaBan", sanPham.SoLuongDaBan);
            sqlCommand.Parameters.AddWithValue("@gia", sanPham.Gia);
            sqlCommand.Parameters.AddWithValue("@moTa", sanPham.MoTa);
            sqlCommand.Parameters.AddWithValue("@anhSP", sanPham.AnhSanPham);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        //========================== Sửa sản phẩm ===================================
        public void SuaSanPham(SanPhamModels sanPham)
        {
            SqlConnection sqlConnection = _databaseService.Connection();

            SqlCommand sqlCommand = new SqlCommand("SuaSP", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@maSP", sanPham.MaSP);
            sqlCommand.Parameters.AddWithValue("@maDM", sanPham.MaDM);
            sqlCommand.Parameters.AddWithValue("@tenSP", sanPham.TenSP);
            sqlCommand.Parameters.AddWithValue("@soLuongTon", sanPham.SoLuongTon);
            sqlCommand.Parameters.AddWithValue("@soLuongDaBan", sanPham.SoLuongDaBan);
            sqlCommand.Parameters.AddWithValue("@gia", sanPham.Gia);
            sqlCommand.Parameters.AddWithValue("@moTa", sanPham.MoTa);
            sqlCommand.Parameters.AddWithValue("@anhSP", sanPham.AnhSanPham);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        //===========================Xóa sản phẩm ==============================
        public void XoaSanPham (string maSP)
        {
            SqlConnection sqlConnection = _databaseService.Connection();

            string sqlString = "Delete from SanPham Where MaSP = @maSP";

            SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@maSP", maSP);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        //================================= Lấy ra giá bán của sản phẩm có mã được truyền vào ====================
        public decimal LayGiaBanTheoMaSP(string maSP)
        {
            decimal gia = -1;

            // Mở kết nối đến cơ sở dữ liệu
            SqlConnection sqlConnection = _databaseService.Connection();

            // Câu truy vấn SQL để lấy giá sản phẩm theo mã sản phẩm
            string sqlString = "Select Gia from SanPham Where MaSP = @maSP";

            SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@maSP", maSP);

            // Thực thi truy vấn và lấy giá trị trả về
            object result = sqlCommand.ExecuteScalar();

            // Nếu kết quả không phải null, gán giá trị vào biến gia
            if (result != null && decimal.TryParse(result.ToString(), out gia))
            {
                return gia;
            }

            sqlConnection.Close();

            // Nếu không tìm thấy giá trị hợp lệ, trả về 0
            return gia;
        }


        //====================== Tìm kiếm san pham ==============================================
        public List<SanPhamModels> TimKiem(string searchString)
        {
            // Lấy danh sách sản phẩm
            List<SanPhamModels> sanPhams = GetDanhSachSanPham();
            List<SanPhamModels> sanPhamsTimKiem = new List<SanPhamModels>();

            // Chuẩn hóa searchString để so sánh không phân biệt hoa thường
            string searchStringLower = searchString.ToLower();

            // Duyệt qua từng sản phẩm
            foreach (SanPhamModels sanPham in sanPhams)
            {
                string maSPLower = sanPham.MaSP.ToLower();
                string tenSPLower = sanPham.TenSP.ToLower();
                string moTaSPLower = sanPham.MoTa.ToLower();

                if (maSPLower.Equals(searchStringLower))
                {
                    sanPhamsTimKiem.Add(sanPham);
                }
                else if (tenSPLower.Contains(searchStringLower))
                {
                    sanPhamsTimKiem.Add(sanPham);
                }
                else if (moTaSPLower.Contains(searchStringLower))
                {
                    sanPhamsTimKiem.Add(sanPham);
                }
            }

            return sanPhamsTimKiem;
        }
    }
}
