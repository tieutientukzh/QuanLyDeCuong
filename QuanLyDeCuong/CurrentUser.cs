namespace QuanLyDeCuong
{
    public static class CurrentUser
    {
        public static int UserID { get; set; }
        public static string Username { get; set; }
        public static string FullName { get; set; }
        public static string Role { get; set; }

        // Cần thêm GiangVienID cho Form Giảng viên
        public static int GiangVienID { get; set; }

        public static void Clear()
        {
            UserID = 0;
            Username = null;
            FullName = null;
            Role = null;
            GiangVienID = 0;
        }
    }
}
