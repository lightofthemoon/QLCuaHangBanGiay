namespace QLCuaHangBanGiay.DataTier.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(7)]
        public string MaHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(7)]
        public string MaSP { get; set; }

        [StringLength(50)]
        public string MoTa { get; set; }

        public int? SL { get; set; }

        public int? DonGia { get; set; }

        public int? ThanhTien { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
