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
    
    public partial class SinhVienHoatDong
    {
        public int SinhVienHoatDongId { get; set; }
        public string MaSinhVien { get; set; }
        public string NoiDung { get; set; }
        public string GhiChu { get; set; }
        public System.DateTime NgayCapNhat { get; set; }
    
        public virtual SinhVien SinhVien { get; set; }
    }
}