using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.ViewModels
{
    internal class PhieuNhapHangViewModels
    {
        public string MaPhieuNhap { get; set; }
        public string MaNV { get; set; }
        public int? SoLuongSP { get; set; }
        public int? TongTien { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayGiao { get; set; }
    }
}
