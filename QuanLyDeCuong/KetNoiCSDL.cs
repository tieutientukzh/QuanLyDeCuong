using Microsoft.Data.SqlClient;

namespace QuanLyDeCuong
{
    public static class KetNoiCSDL
    {
        private static string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ Path.Combine(Application.StartupPath, "Data", "Database.mdf") + ";Integrated Security=True;Connect Timeout=30";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
