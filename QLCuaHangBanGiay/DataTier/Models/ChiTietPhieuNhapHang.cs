namespace QLCuaHangBanGiay.DataTier.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietPhieuNhapHang")]
    public partial class ChiTietPhieuNhapHang
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(7)]
        public string MaPhieuNhap { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(7)]
        public string MaNCC { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(7)]
        public string MaSP { get; set; }

        public int? SL { get; set; }

        public int? Gia { get; set; }

        [StringLength(5)]
        public string Size { get; set; }

        [StringLength(50)]
        public string MoTa { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual PhieuNhapHang PhieuNhapHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
