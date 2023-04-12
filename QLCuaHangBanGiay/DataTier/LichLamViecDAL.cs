using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.DataTier
{
    internal class LichLamViecDAL
    {
        private QuanLyBanGiayModels quanLyBanGiayModels;
        public LichLamViecDAL()
        {
            quanLyBanGiayModels = new QuanLyBanGiayModels();
        }
        public IEnumerable<LichLamViec> GetLichLamViec()
        {
            return quanLyBanGiayModels.LichLamViecs.ToList();
        }
        public int GetSL()
        {
            return quanLyBanGiayModels.LichLamViecs.Count();
        }
        public bool ThemLichLamViec(LichLamViec lichLamViec)
        {
            try
            {
                quanLyBanGiayModels.LichLamViecs.Add(lichLamViec);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CapNhatLichLamViec(LichLamViec lichLamViec)
        {
            try
            {
                var temp = quanLyBanGiayModels.LichLamViecs.FirstOrDefault(x => x.MaNV == lichLamViec.MaNV && x.MaCaLam == lichLamViec.MaCaLam && x.NgayLamViec == lichLamViec.NgayLamViec);
                if (temp != null)
                {
                    temp.GioTanCa = lichLamViec.GioTanCa;
                    temp.TongGioLam = lichLamViec.TongGioLam;
                    quanLyBanGiayModels.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
