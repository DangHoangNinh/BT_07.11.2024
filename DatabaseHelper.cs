using System;
using System.Data;
using System.Data.SqlClient;

namespace SimThe
{
    public class DatabaseHelper
    {
        private readonly string connectionString = "Data Source=Nign_Doung\\SQLEXPRESS;Initial Catalog=SimThe;Integrated Security=True";
        private SqlConnection conn;

        // Constructor khởi tạo kết nối sử dụng chuỗi kết nối cố định
        public DatabaseHelper()
        {
            conn = new SqlConnection(connectionString);
        }

        // Phương thức mở kết nối
        public bool OpenConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                return true;
            }
            catch
            {
                return false;  // Trả về false nếu không mở được kết nối
            }
        }

        // Phương thức đóng kết nối
        public void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        // Phương thức lấy dữ liệu từ cơ sở dữ liệu dưới dạng DataTable
        public DataTable GetData(string query)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch
            {
                return null;  // Trả về null nếu có lỗi
            }
        }

        // Phương thức lấy dữ liệu từ cơ sở dữ liệu dưới dạng DataSet
        public DataSet LayDuLieu(string query)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(ds);
                return ds;
            }
            catch
            {
                return null;  // Trả về null nếu có lỗi
            }
        }

        // Phương thức thực thi câu truy vấn (INSERT, UPDATE, DELETE) và trả về kết quả thành công
        public bool ThucThi(string query)
        {
            try
            {
                OpenConnection();  // Đảm bảo mở kết nối
                SqlCommand cmd = new SqlCommand(query, conn);
                int result = cmd.ExecuteNonQuery();
                return result > 0;  // Trả về true nếu có ít nhất một dòng bị ảnh hưởng
            }
            catch
            {
                return false;  // Trả về false nếu có lỗi
            }
            finally
            {
                CloseConnection();  // Đảm bảo đóng kết nối
            }
        }
    }
}
