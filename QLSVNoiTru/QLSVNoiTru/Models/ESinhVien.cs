using QLSVNoiTru.Database;

namespace QLSVNoiTru.Models
{
    public class ESinhVien
    {
        public string MaSinhVien { get; set; }
        public bool Chon { get; set; }
        public SinhVien SinhVien { get; set; }
    }
}