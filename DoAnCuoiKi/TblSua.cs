//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnCuoiKi
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblSua
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblSua()
        {
            this.TblChiTietHDBanSuas = new HashSet<TblChiTietHDBanSua>();
        }
    
        public string MaSua { get; set; }
        public string TenSua { get; set; }
        public string MaLoaiSua { get; set; }
        public int SoLuong { get; set; }
        public double DonGiaNhap { get; set; }
        public double DonGiaBan { get; set; }
        public string Anh { get; set; }
        public string GhiChu { get; set; }
        public System.DateTime HanSuDung { get; set; }
        public string MaPhanLoai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblChiTietHDBanSua> TblChiTietHDBanSuas { get; set; }
        public virtual TblLoaiSua TblLoaiSua { get; set; }
        public virtual TblPhanLoai TblPhanLoai { get; set; }
    }
}
