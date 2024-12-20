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
    public class AdminService
    {
        private DatabaseService _databaseService;
        private SqlConnection _sqlConnection;

        public AdminService ()
        {
            _databaseService = new DatabaseService();
        }

        //===================== Kiểm tra thông tin và trả về mã admin =================================
        public AdminModels kiemTraDangNhap(string taiKhoan, string matKhau)
        {
            AdminModels adminModels = null;

            if (_sqlConnection == null)
                _sqlConnection = _databaseService.Connection();

            SqlCommand sqlCommand = new SqlCommand("KiemTraDangNhap", _sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@TaiKhoan", taiKhoan);
            sqlCommand.Parameters.AddWithValue("@MatKhau", matKhau);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                string maAdmin = reader.GetString(0);
                string tenAdmin = reader.GetString(1);

                adminModels = new AdminModels(maAdmin, tenAdmin);
            }

            _sqlConnection.Close();

            return adminModels;
        }
    }
}
