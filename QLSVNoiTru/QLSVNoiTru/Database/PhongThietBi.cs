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
    
    public partial class PhongThietBi
    {
        public int PhongThietBiId { get; set; }
        public string SoHieuPhong { get; set; }
        public string MaThietBi { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    
        public virtual Phong Phong { get; set; }
        public virtual ThietBi ThietBi { get; set; }
    }
}