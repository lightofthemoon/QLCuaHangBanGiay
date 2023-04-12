using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.DataTier
{
    internal class ChiTietPhieuNhapHangBUS
    {
        private ChiTietPhieuNhapHangDAL ctphieuNhapHangDAL;
        public ChiTietPhieuNhapHangBUS()
        {
            ctphieuNhapHangDAL = new ChiTietPhieuNhapHangDAL();
        }
        public IEnumerable<ChiTietPhieuNhapHangViewModels> GetChiTietPhieuNhapHang()
        {
            return ctphieuNhapHangDAL.GetChiTietPhieuNhapHang();
        }
        public IEnumerable<ChiTietPhieuNhapHang> GetData()
        {
            return ctphieuNhapHangDAL.GetData();
        }
        public int GetSL()
        {
            return ctphieuNhapHangDAL.GetSL();
        }
        public bool ThemChiTietPhieuNhapHang(ChiTietPhieuNhapHang ctnhapHang)
        {
            return ctphieuNhapHangDAL.ThemChiTietPhieuNhapHang(ctnhapHang);
        }
        public bool CapNhatChiTietPhieuNhapHang(ChiTietPhieuNhapHang ctnhapHang)
        {
            return ctphieuNhapHangDAL.CapNhatChiTietPhieuNhapHang(ctnhapHang);
        }
        public bool XoaChiTietPhieuNhapHang(string maPhieu, string maNCC, string maSP)
        {
            return ctphieuNhapHangDAL.XoaChiTietPhieuNhapHang(maPhieu, maNCC, maSP);
        }
        public bool XoaChiTietFull(string maPhieu)
        {
            return ctphieuNhapHangDAL.XoaChiTietFull(maPhieu);
        }
        public IEnumerable<ChiTietPhieuNhapHang> Find(string temp)
        {
            return ctphieuNhapHangDAL.Find(temp);
        }
    }
}
