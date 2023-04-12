using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.DataTier
{
    internal class HoaDonBUS
    {
        private HoaDonDAL hoaDonDAL;
        public HoaDonBUS()
        {
            hoaDonDAL = new HoaDonDAL();
        }
        public IEnumerable<HoaDon> GetHoaDon()
        {
            return hoaDonDAL.GetHoaDon();
        }
        public IEnumerable<HoaDonViewModels> GetDataHD(string maHD)
        {
            return hoaDonDAL.GetDataHD(maHD);
        }
        public IEnumerable<HoaDonViewModels> GetHD()
        {
            return hoaDonDAL.GetHD();
        }
        public int GetSL()
        {
            return hoaDonDAL.GetSL();
        }
        public bool ThemHoaDon(HoaDon hoaDon)
        {
            return hoaDonDAL.ThemHoaDon(hoaDon);
        }
        public bool CapNhatHoaDon(HoaDon hoaDon)
        {
            return hoaDonDAL.CapNhatHoaDon(hoaDon);
        }
        public bool XoaHoaDon(string maHD)
        {
            return hoaDonDAL.XoaHoaDon(maHD);
        }
        public IEnumerable<HoaDonViewModels> Find(string temp)
        {
            return hoaDonDAL.Find(temp);
        }
    }
}
