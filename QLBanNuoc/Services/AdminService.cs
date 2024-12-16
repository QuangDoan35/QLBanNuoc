using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanNuoc.Services
{
    public class AdminService
    {
        private DatabaseService _databaseService;
        private SqlConnection _sqlConnection;

        public AdminService ()
        {
            _databaseService = new DatabaseService();
        }

        //===================== Kiểm tra thông tin và trả về mã admin =================================
        public string kiemTraDangNhap(string taiKhoan, string matKhau)
        {
            string maAdmin = "";

            if (_sqlConnection == null)
                _sqlConnection = _databaseService.Connection();

            SqlCommand sqlCommand = new SqlCommand("KiemTraDangNhap", _sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@TaiKhoan", taiKhoan);
            sqlCommand.Parameters.AddWithValue("@MatKhau", matKhau);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                maAdmin = reader.GetString(0);
            }

            _sqlConnection.Close();

            return maAdmin;
        }

        //==================== Lấy thông tin admin =============================
        //public string getThongTinAdmin (string maAdmin)
        //{
        //    string tenAdmin = "";

        //    SqlConnection sqlConnection = _databaseService.Connection();

        //    SqlCommand sqlCommand = new SqlCommand("KiemTraDangNhap", sqlConnection);
        //    sqlCommand.CommandType = CommandType.StoredProcedure;
        //    sqlCommand.Parameters.AddWithValue("@TaiKhoan", maAdmin);

        //    SqlDataReader reader = sqlCommand.ExecuteReader();

        //    if (reader.Read())
        //    {
        //        maAdmin = reader.GetString(0);
        //    }

        //    sqlConnection.Close();

        //    return tenAdmin;
        //}
    }
}
