using Microsoft.Data.SqlClient;
using QLBanNuoc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace QLBanNuoc.Services
{
    public class ChiTietHoaDonService
    {
        private DatabaseService _databaseService;

        public ChiTietHoaDonService()
        {
            _databaseService = new DatabaseService();
        }

        //==================== Lấy ra và trả về danh sách hóa đơn =================================
        public List<CHiTietHoaDonModels> GetDanhSachChiTietHoaDon()
        {
            List<CHiTietHoaDonModels> danhSachChiTietHoaDon = new List<CHiTietHoaDonModels>();

            SqlConnection sqlConnection = _databaseService.Connection();

            string sqlString = "SELECT * FROM CTHD";

            SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                string maHD = reader.GetString(0).Trim();
                string maSP = reader.GetString(1).Trim();
                int soLuong = reader.GetInt32(2);
                decimal giaBan = reader.GetDecimal(3);

                CHiTietHoaDonModels chiTietHoaDon = new CHiTietHoaDonModels(maHD, maSP, soLuong, giaBan);

                danhSachChiTietHoaDon.Add(chiTietHoaDon);
            }

            sqlConnection.Close();

            return danhSachChiTietHoaDon;
        }

        //========================= Thêm chi tiết hóa đơn ==========================================================
        public void ThemChiTietHoaDon(CHiTietHoaDonModels chiTietHoaDon)
        {
            SqlConnection sqlConnection = _databaseService.Connection();

            SqlCommand sqlCommand = new SqlCommand("ThemCTHD", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@maHD", chiTietHoaDon.MaHD);
            sqlCommand.Parameters.AddWithValue("@maSP", chiTietHoaDon.MaSP);
            sqlCommand.Parameters.AddWithValue("@soLuong", chiTietHoaDon.SoLuong);
            sqlCommand.Parameters.AddWithValue("@giaBan", chiTietHoaDon.GiaBan);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        //============================ Sửa chi tiết hóa đơn ========================================================
        public void SuaChiTietHoaDon(CHiTietHoaDonModels chiTietHoaDon)
        {
            SqlConnection sqlConnection = _databaseService.Connection();

            SqlCommand sqlCommand = new SqlCommand("SuaCTHD", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@maHD", chiTietHoaDon.MaHD);
            sqlCommand.Parameters.AddWithValue("@maSP", chiTietHoaDon.MaSP);
            sqlCommand.Parameters.AddWithValue("@soLuong", chiTietHoaDon.SoLuong);
            sqlCommand.Parameters.AddWithValue("@giaBan", chiTietHoaDon.GiaBan);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        //=============================== Xóa chi tiết hóa đơn =====================================================
        public void XoaChiTietHoaDon(string maHD, string maSP)
        {
            SqlConnection sqlConnection = _databaseService.Connection();

            string sqlString = "Delete from CTHD Where MaHD = @maHD and MaSP = @maSP";

            SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@maHD", maHD);
            sqlCommand.Parameters.AddWithValue("@maSP", maSP);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        //====================== Tìm kiếm chi tiết hóa đơn ==============================================
        public List<CHiTietHoaDonModels> TimKiem(string searchString)
        {
            // Lấy danh sách sản phẩm
            List<CHiTietHoaDonModels> chiTietHoaDons = GetDanhSachChiTietHoaDon();
            List<CHiTietHoaDonModels> chiTietHoaDonsTimKiem = new List<CHiTietHoaDonModels>();

            // Chuẩn hóa searchString để so sánh không phân biệt hoa thường
            string searchStringLower = searchString.ToLower();

            // Duyệt qua từng sản phẩm
            foreach (CHiTietHoaDonModels chiTietHoaDon in chiTietHoaDons)
            {
                string maHDLower = chiTietHoaDon.MaHD.ToLower();
                string maSPLower = chiTietHoaDon.MaSP.ToLower();

                if (maHDLower.Contains(searchStringLower) || maSPLower.Contains(searchStringLower))
                {
                    chiTietHoaDonsTimKiem.Add(chiTietHoaDon);
                }
            }

            return chiTietHoaDonsTimKiem;
        }
    }
}
