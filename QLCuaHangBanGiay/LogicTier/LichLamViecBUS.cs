using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.DataTier
{
    internal class LichLamViecBUS
    {
        private LichLamViecDAL lichLamViecDAL;
        public LichLamViecBUS()
        {
            lichLamViecDAL = new LichLamViecDAL();
        }
        public IEnumerable<LichLamViec> GetLichLamViec()
        {
            return lichLamViecDAL.GetLichLamViec();
        }
        public bool ThemLichLamViec(LichLamViec lichLamViec)
        {
            return lichLamViecDAL.ThemLichLamViec(lichLamViec);
        }
        public bool CapNhatLichLamViec(LichLamViec lichLamViec)
        {
            return lichLamViecDAL.CapNhatLichLamViec(lichLamViec);
        }
    }
}
