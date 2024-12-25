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
    public class DanhMucService
    {
        private DatabaseService _databaseService;

        public DanhMucService ()
        {
            _databaseService = new DatabaseService ();
        }

        //================== Lấy danh sách danh mục ==========================
        public List<DanhMucModels> GetDanhMuc ()
        {
            List<DanhMucModels> danhMucs = new List<DanhMucModels>();

            DatabaseService database = new DatabaseService();

            SqlConnection sqlConnection = database.Connection();

            string sqlString = "SELECT * FROM DanhMuc";

            SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                string maDM = reader.GetString(0);
                string tenDM = reader.GetString(1);
                string moTa = reader.GetString(2);
                string anhDM = reader.GetString(3);

                DanhMucModels danhMuc = new DanhMucModels(maDM, tenDM, moTa, anhDM);

                danhMucs.Add(danhMuc);
            }

            sqlConnection.Close();

            return danhMucs;
        }

        //==================== Thêm mới danh mục ==================================
        public void ThemDanhMuc (string maDM, string tenDM, string moTa, string anhDM)
        {
            SqlConnection sqlConnection = _databaseService.Connection();

            SqlCommand sqlCommand = new SqlCommand("ThemDM", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@maDM", maDM);
            sqlCommand.Parameters.AddWithValue("@tenDM", tenDM);
            sqlCommand.Parameters.AddWithValue("@moTa", moTa);
            sqlCommand.Parameters.AddWithValue("@anhDM", anhDM);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        //==================== Sửa mới danh mục ==================================
        public void SuaDanhMuc(string maDM, string tenDM, string moTa, string anhDM)
        {
            SqlConnection sqlConnection = _databaseService.Connection();

            SqlCommand sqlCommand = new SqlCommand("SuaDM", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@maDM", maDM);
            sqlCommand.Parameters.AddWithValue("@tenDM", tenDM);
            sqlCommand.Parameters.AddWithValue("@moTa", moTa);
            sqlCommand.Parameters.AddWithValue("@anhDM", anhDM);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        //==================== Xóa danh mục ==================================
        public void XoaDanhMuc (string maDM)
        {
            SqlConnection sqlConnection = _databaseService.Connection();
            string sqlString = "Delete from DanhMuc where MaDM = @maDM";

            SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@maDM", maDM);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        //====================== Tìm kiếm danh mục ==============================================
        public List<DanhMucModels> TimKiem(string searchString)
        {
            List<DanhMucModels> danhMucs = new List<DanhMucModels>();

            using (SqlConnection sqlConnection = _databaseService.Connection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM DanhMuc WHERE MaDM = @maDM OR TenDM LIKE @tenDM", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@maDM", searchString);
                    sqlCommand.Parameters.AddWithValue("@tenDM", "%" + searchString + "%");

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maDM = reader.GetString(0);
                            string tenDM = reader.GetString(1);
                            string moTa = reader.GetString(2);
                            string anhDM = reader.GetString(3);

                            DanhMucModels danhMuc = new DanhMucModels(maDM, tenDM, moTa, anhDM);
                            danhMucs.Add(danhMuc);
                        }
                    }
                }
            }

            return danhMucs;
        }
    }
}
