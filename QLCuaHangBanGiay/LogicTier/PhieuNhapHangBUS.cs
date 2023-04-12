using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.DataTier
{
    internal class PhieuNhapHangBUS
    {
        private PhieuNhapHangDAL phieuNhapHangDAL;
        public PhieuNhapHangBUS()
        {
            phieuNhapHangDAL = new PhieuNhapHangDAL();
        }
        public IEnumerable<PhieuNhapHangViewModels> GetPhieuNhapHang()
        {
            return phieuNhapHangDAL.GetPhieuNhapHang();
        }
        public IEnumerable<PhieuNhapHang> GetData()
        {
            return phieuNhapHangDAL.GetData();
        }
        public int GetSL()
        {
            return phieuNhapHangDAL.GetSL();
        }
        public bool ThemPhieuNhapHang(PhieuNhapHang nhapHang)
        {
            return phieuNhapHangDAL.ThemPhieuNhapHang(nhapHang);
        }
        public bool CapNhatPhieuNhapHang(PhieuNhapHang nhapHang)
        {
            return phieuNhapHangDAL.CapNhatPhieuNhapHang(nhapHang);
        }
        public bool XoaPhieuNhapHang(string maPhieu)
        {
            return phieuNhapHangDAL.XoaPhieuNhapHang(maPhieu);
        }
        public IEnumerable<PhieuNhapHang> Find(string temp)
        {
            return phieuNhapHangDAL.Find(temp);
        }
    }
}
