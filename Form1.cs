using System;
using System.Data;
using System.Windows.Forms;

namespace SimThe
{
    public partial class Form1 : Form
    {
        private DatabaseHelper dbHelper;

        public Form1()
        {
            InitializeComponent();

            // Khởi tạo DatabaseHelper mà không cần chuỗi kết nối
            dbHelper = new DatabaseHelper();

            // Tải dữ liệu từ cơ sở dữ liệu và hiển thị
            LoadSimData();
        }

        private void LoadSimData()
        {
            string query = "SELECT Sim.ID, Sim.SoSim, Mang.TenMang, Sim.NgayKichHoat, Sim.NgayHetHan " +
                           "FROM Sim " +
                           "JOIN Mang ON Sim.MangID = Mang.ID " +
                           "ORDER BY Sim.NgayKichHoat ASC";

            DataTable simTable = dbHelper.GetData(query);
            dataGridView1.DataSource = simTable;
        }
    }
}
