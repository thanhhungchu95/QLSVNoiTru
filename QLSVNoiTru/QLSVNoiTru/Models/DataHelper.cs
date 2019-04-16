namespace QLSVNoiTru.Models
{
    public enum TrangThaiO
    {
        DangO = 1,
        ChoNhanPhongMoi = 2,
        CheckOut = 3
    }
    public class DataHelper
    {
        public static string ConvertTrangThaiO(int trangThai)
        {
            switch (trangThai)
            {
                case (int)TrangThaiO.DangO:
                    return "Đang ở";
                case (int)TrangThaiO.ChoNhanPhongMoi:
                    return "Chờ nhận phòng mới";
                case (int)TrangThaiO.CheckOut:
                    return "Check out";
                default:
                    return "";
            }
        }
    }
}