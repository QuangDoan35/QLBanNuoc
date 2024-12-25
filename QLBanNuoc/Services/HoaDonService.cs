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

    public class HoaDonService
    {
        private DatabaseService _databaseService;

        public HoaDonService ()
        {
            _databaseService = new DatabaseService();
        }

        //==================== Lấy ra và trả về danh sách hóa đơn =================================
        public List<HoaDonModels> GetDanhSachHoaDon()
        {
            List<HoaDonModels> danhSachHoaDon = new List<HoaDonModels>();

            SqlConnection sqlConnection = _databaseService.Connection();

            string sqlString = "SELECT * FROM HoaDon";

            SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                string maHD = reader.GetString(0).Trim();
                string maKH = reader.GetString(1).Trim();
                DateTime ngayLap = reader.GetDateTime(2);
                decimal tongTien = reader.GetDecimal(3);

                HoaDonModels hoaDon = new HoaDonModels(maHD, maKH, ngayLap, tongTien);

                danhSachHoaDon.Add(hoaDon);
            }

            sqlConnection.Close();

            return danhSachHoaDon;
        }

        //========================= Thêm hóa đơn ==========================================================
        public void ThemHoaDon(HoaDonModels hoaDon)
        {
            SqlConnection sqlConnection = _databaseService.Connection();

            SqlCommand sqlCommand = new SqlCommand("ThemHD", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@maHD", hoaDon.MaHD);
            sqlCommand.Parameters.AddWithValue("@maKH", hoaDon.MaKH);
            sqlCommand.Parameters.AddWithValue("@ngayLap", hoaDon.NgayLap);
            sqlCommand.Parameters.AddWithValue("@tongTien", hoaDon.TongTien);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        //============================ Sửa hóa đơn ========================================================
        public void SuaHoaDon(HoaDonModels hoaDon)
        {
            SqlConnection sqlConnection = _databaseService.Connection();

            SqlCommand sqlCommand = new SqlCommand("SuaHD", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@maHD", hoaDon.MaHD);
            sqlCommand.Parameters.AddWithValue("@maKH", hoaDon.MaKH);
            sqlCommand.Parameters.AddWithValue("@ngayLap", hoaDon.NgayLap);
            sqlCommand.Parameters.AddWithValue("@tongTien", hoaDon.TongTien);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        //=============================== Xóa hóa đơn =====================================================
        public void XoaHoaDon(string maHD)
        {
            SqlConnection sqlConnection = _databaseService.Connection();

            string sqlString = "Delete from HoaDon Where MaHD = @maHD";

            SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@maHD", maHD);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }


        //====================== Tìm kiếm hóa đơn ==============================================
        public List<HoaDonModels> TimKiem(string searchString)
        {
            // Lấy danh sách sản phẩm
            List<HoaDonModels> hoaDons = GetDanhSachHoaDon();
            List<HoaDonModels> hoaDonsTimKiem = new List<HoaDonModels>();

            // Chuẩn hóa searchString để so sánh không phân biệt hoa thường
            string searchStringLower = searchString.ToLower();

            // Duyệt qua từng sản phẩm
            foreach (HoaDonModels hoaDon in hoaDons)
            {
                string maHDLower = hoaDon.MaHD.ToLower();
                string tenKHLower = hoaDon.MaKH.ToLower();

                if (maHDLower.Contains(searchStringLower) || tenKHLower.Contains(searchStringLower))
                {
                    hoaDonsTimKiem.Add(hoaDon);
                }
            }

            return hoaDonsTimKiem;
        }
    }
}
