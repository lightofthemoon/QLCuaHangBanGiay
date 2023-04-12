namespace QLCuaHangBanGiay.DataTier.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiKH")]
    public partial class LoaiKH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiKH()
        {
            KhachHangs = new HashSet<KhachHang>();
        }

        [Key]
        [StringLength(7)]
        public string MaLoaiKH { get; set; }

        [StringLength(50)]
        public string TenLoaiKH { get; set; }

        public int? SoDiemTichLuyToiThieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
    }
}
