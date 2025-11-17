using System.Data.SqlClient;

namespace QuanLyDeCuong
{
    public static class KetNoiCSDL
    {
        private static string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Workspace\VS_LTTQ\QuanLyDeCuong\QuanLyDeCuong\Database.mdf;Integrated Security=True;Connect Timeout=30";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
