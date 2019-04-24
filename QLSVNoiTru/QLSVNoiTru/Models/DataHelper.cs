namespace QLSVNoiTru.Models
{
    public enum TrangThaiO
    {
        DangO = 1,
        ChoNhanPhongMoi = 2,
        CheckOut = 3
    }
    public enum MucDichLoaiPhong
    {
        ChiDanhCHoNam = 1,
        ChiDanhCHoNu = 2,
        PhongHoc = 3,
        CaNamNu = 4,
        KhonXacDinh = -1
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
        public static string ConvertMucDichLoaiPhong(int mucdich)
        {
            switch (mucdich)
            {
                case (int)MucDichLoaiPhong.ChiDanhCHoNam:
                    return "Chỉ dành cho nam";
                case (int)MucDichLoaiPhong.ChiDanhCHoNu:
                    return "Chỉ dành cho nữ";
                case (int)MucDichLoaiPhong.PhongHoc:
                    return "Phòng học/ thí nghiệm...";
                case (int)MucDichLoaiPhong.CaNamNu:
                    return "Cả nam,nữ";
                case (int)MucDichLoaiPhong.KhonXacDinh:
                    return "Không xác định";
                default:
                    return "";
            }
        }
    }
}