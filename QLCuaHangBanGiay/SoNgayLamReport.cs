using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay
{
    internal class SoNgayLamReport
    {
        public string MaNV { get; set; }
        public string MaCaLam { get; set; }

        public DateTime NgayLamViec { get; set; }

        public TimeSpan? GioVaoLam { get; set; }

        public TimeSpan? GioTanCa { get; set; }

        public double? TongGioLam { get; set; }
    }
}
