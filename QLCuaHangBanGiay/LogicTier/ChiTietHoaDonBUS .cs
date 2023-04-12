using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.DataTier
{
    internal class ChiTietHoaDonBUS
    {
        private ChiTietHoaDonDAL chiTietHDDAL;
        public ChiTietHoaDonBUS()
        {
            chiTietHDDAL = new ChiTietHoaDonDAL();
        }
        public IEnumerable<ChiTietHoaDon> GetData()
        {
            return chiTietHDDAL.GetData();
        }
        public IEnumerable<ChiTietHoaDonViewModels> GetChiTietHoaDon()
        {
            return chiTietHDDAL.GetChiTietHoaDon();
        }
        public IEnumerable<ChiTietHoaDonViewModels> Find(string maHD)
        {
            return chiTietHDDAL.Find(maHD);
        }
        public bool ThemChiTietHoaDon(ChiTietHoaDon chiTietHD)
        {
            return chiTietHDDAL.ThemChiTietHoaDon(chiTietHD);
        }
        public bool Xoa1ChiTietHoaDon(string maHD, string maSP)
        {
            return chiTietHDDAL.Xoa1ChiTietHoaDon(maHD, maSP);
        }
        public bool XoaChiTietHoaDon(string maHD)
        {
            return chiTietHDDAL.XoaChiTietHoaDon(maHD);
        }
        public IEnumerable<ChiTietHoaDonViewModels> FindText(string text)
        {
            return chiTietHDDAL.FindText(text);
        }
    }
}
