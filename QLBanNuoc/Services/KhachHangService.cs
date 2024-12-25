using Microsoft.Data.SqlClient;
using QLBanNuoc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanNuoc.Services
{
    public class KhachHangService
    {
        private DatabaseService _databaseService;

        public KhachHangService ()
        {
            _databaseService = new DatabaseService ();
        }

        //==================== Lấy ra và trả về danh sách khách hàng =================================
        public List<KhachHangModels> GetDanhSachKhachHang()
        {
            List<KhachHangModels> danhSachKhachHang = new List<KhachHangModels>();

            SqlConnection sqlConnection = _databaseService.Connection();

            string sqlString = "SELECT * FROM KhachHang";

            SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                string maKH = reader.GetString(0).Trim();
                string tenKH = reader.GetString(1).Trim();
                string diaChi = reader.GetString(2).Trim();
                string sdt = reader.GetString(3).Trim();
                string email = reader.GetString(4).Trim();
                string anhKH = reader.GetString(5).Trim();

                KhachHangModels sanPham = new KhachHangModels(maKH, tenKH, diaChi, sdt, email, anhKH);

                danhSachKhachHang.Add(sanPham);
            }

            sqlConnection.Close();

            return danhSachKhachHang;
        }

        //========================= Thêm khách hàng ==========================================================
        public void ThemKhachHang (KhachHangModels khachHang)
        {
            SqlConnection sqlConnection = _databaseService.Connection();

            SqlCommand sqlCommand = new SqlCommand("ThemKH", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@maKH", khachHang.MaKH);
            sqlCommand.Parameters.AddWithValue("@hoTen", khachHang.HoTen);
            sqlCommand.Parameters.AddWithValue("@diaChi", khachHang.DiaChi);
            sqlCommand.Parameters.AddWithValue("@sdt", khachHang.SDT);
            sqlCommand.Parameters.AddWithValue("@email", khachHang.Email);
            sqlCommand.Parameters.AddWithValue("@anhKH", khachHang.AnhKH);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        //============================ Sửa khách hàng ========================================================
        public void SuaKhachHang(KhachHangModels khachHang)
        {
            SqlConnection sqlConnection = _databaseService.Connection();

            SqlCommand sqlCommand = new SqlCommand("SuaKH", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@maKH", khachHang.MaKH);
            sqlCommand.Parameters.AddWithValue("@hoTen", khachHang.HoTen);
            sqlCommand.Parameters.AddWithValue("@diaChi", khachHang.DiaChi);
            sqlCommand.Parameters.AddWithValue("@sdt", khachHang.SDT);
            sqlCommand.Parameters.AddWithValue("@email", khachHang.Email);
            sqlCommand.Parameters.AddWithValue("@anhKH", khachHang.AnhKH);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        //=============================== Xóa khách hàng =====================================================
        public void XoaKhachHang(string maKH)
        {
            SqlConnection sqlConnection = _databaseService.Connection();

            string sqlString = "Delete from KhachHang Where MaKH = @maKH";

            SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@maKH", maKH);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }


        //====================== Tìm kiếm khach hang ==============================================
        public List<KhachHangModels> TimKiem(string searchString)
        {
            // Lấy danh sách sản phẩm
            List<KhachHangModels> khachHangs = GetDanhSachKhachHang();
            List<KhachHangModels> khachHangsTimKiem = new List<KhachHangModels>();

            // Chuẩn hóa searchString để so sánh không phân biệt hoa thường
            string searchStringLower = searchString.ToLower();

            // Duyệt qua từng sản phẩm
            foreach (KhachHangModels khachHang in khachHangs)
            {
                string maSPLower = khachHang.MaKH.ToLower();
                string tenSPLower = khachHang.HoTen.ToLower();

                if (maSPLower.Equals(searchStringLower))
                {
                    khachHangsTimKiem.Add(khachHang);
                }
                else if (tenSPLower.Contains(searchStringLower))
                {
                    khachHangsTimKiem.Add(khachHang);
                }
            }

            return khachHangsTimKiem;
        }
    }
}
