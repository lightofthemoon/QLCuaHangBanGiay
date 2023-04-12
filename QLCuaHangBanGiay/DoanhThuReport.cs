using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay
{
    internal class DoanhThuReport
    {
        public string MaHD { get; set; }
        public string MaSP { get; set; }
        public DateTime Ngay { get; set; }

        public string MoTa { get; set; }

        public int? SL { get; set; }

        public int? DonGia { get; set; }

        public int? ThanhTien { get; set; }
    }
}
