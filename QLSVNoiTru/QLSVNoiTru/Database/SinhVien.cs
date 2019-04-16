//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLSVNoiTru.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class SinhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SinhVien()
        {
            this.SinhVienChuyenPhongs = new HashSet<SinhVienChuyenPhong>();
            this.SinhVienHoatDongs = new HashSet<SinhVienHoatDong>();
            this.SinhVienKyLuats = new HashSet<SinhVienKyLuat>();
        }
    
        public string MaSinhVien { get; set; }
        public string MaLop { get; set; }
        public string SoHieuPhong { get; set; }
        public string TenSinhVien { get; set; }
        public string HinhAnh { get; set; }
        public System.DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DanToc { get; set; }
        public string HoKhau { get; set; }
        public string SDT { get; set; }
        public string GhiChu { get; set; }
        public Nullable<int> TrangThaiO { get; set; }
        public Nullable<System.DateTime> NgayNhanPhong { get; set; }
        public string KhenThuong { get; set; }
    
        public virtual Lop Lop { get; set; }
        public virtual Phong Phong { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SinhVienChuyenPhong> SinhVienChuyenPhongs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SinhVienHoatDong> SinhVienHoatDongs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SinhVienKyLuat> SinhVienKyLuats { get; set; }
    }
}