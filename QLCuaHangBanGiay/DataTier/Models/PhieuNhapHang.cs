namespace QLCuaHangBanGiay.DataTier.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuNhapHang")]
    public partial class PhieuNhapHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuNhapHang()
        {
            ChiTietPhieuNhapHangs = new HashSet<ChiTietPhieuNhapHang>();
        }

        [Key]
        [StringLength(7)]
        public string MaPhieuNhap { get; set; }

        [StringLength(7)]
        public string MaNV { get; set; }

        public int? SoLuongSP { get; set; }

        public int? TongTien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayGiao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuNhapHang> ChiTietPhieuNhapHangs { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
