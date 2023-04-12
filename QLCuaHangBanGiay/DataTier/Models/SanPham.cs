namespace QLCuaHangBanGiay.DataTier.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            ChiTietPhieuNhapHangs = new HashSet<ChiTietPhieuNhapHang>();
        }

        [Key]
        [StringLength(7)]
        public string MaSP { get; set; }

        [StringLength(7)]
        public string MaDanhMuc { get; set; }

        [StringLength(7)]
        public string MaNhanHieu { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        [StringLength(50)]
        public string MoTa { get; set; }

        [Column(TypeName = "image")]
        public byte[] AnhSP { get; set; }

        public int? SLTonKho { get; set; }

        public int? DonGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuNhapHang> ChiTietPhieuNhapHangs { get; set; }

        public virtual DanhMucSanPham DanhMucSanPham { get; set; }

        public virtual NhanHieu NhanHieu { get; set; }
    }
}
