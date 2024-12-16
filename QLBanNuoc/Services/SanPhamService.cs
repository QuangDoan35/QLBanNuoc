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

            string sqlString = "SELECT TOP 10 * FROM SanPham ORDER BY SoLuongDaBan DESC";

            SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                string maSP = reader.GetString(0);
                string maDM = reader.GetString(1);
                string tenSP = reader.GetString(2);
                int soLuongTon = reader.GetInt32(3);
                int soLuongDaBan = reader.GetInt32(4);
                decimal gia = reader.GetDecimal(5);
                string moTa = reader.GetString(6);
                string anhSanPham = reader.GetString(7);

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
                string maSP = reader.GetString(0);
                string maDM = reader.GetString(1);
                string tenSP = reader.GetString(2);
                int soLuongTon = reader.GetInt32(3);
                int soLuongDaBan = reader.GetInt32(4);
                decimal gia = reader.GetDecimal(5);
                string moTa = reader.GetString(6);
                string anhSanPham = reader.GetString(7);

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
    }
}
