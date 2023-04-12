namespace QLCuaHangBanGiay.DataTier.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichLamViec")]
    public partial class LichLamViec
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(7)]
        public string MaNV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(7)]
        public string MaCaLam { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime NgayLamViec { get; set; }

        public TimeSpan? GioVaoLam { get; set; }

        public TimeSpan? GioTanCa { get; set; }

        public double? TongGioLam { get; set; }

        public virtual CaLam CaLam { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
