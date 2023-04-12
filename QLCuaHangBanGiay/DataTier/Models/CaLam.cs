namespace QLCuaHangBanGiay.DataTier.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CaLam")]
    public partial class CaLam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CaLam()
        {
            LichLamViecs = new HashSet<LichLamViec>();
        }

        [Key]
        [StringLength(7)]
        public string MaCaLam { get; set; }

        [StringLength(50)]
        public string TenCaLam { get; set; }

        public int? ThoiGianCaLam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichLamViec> LichLamViecs { get; set; }
    }
}
