using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.DataTier
{
    internal class KhachHangBUS
    {
        private KhachHangDAL khachHangDAL;
        public KhachHangBUS()
        {
            khachHangDAL = new KhachHangDAL();
        }
        public IEnumerable<KhachHang> GetKhachHangData()
        {
            return khachHangDAL.GetKhachHangData();
        }
        public IEnumerable<KhachHangViewModels> GetKhachHang()
        {
            return khachHangDAL.GetKhachHang();
        }
        public int GetSL()
        {
            return khachHangDAL.GetSL();
        }
        public bool ThemKH(KhachHang kh)
        {
            return khachHangDAL.ThemKH(kh);
        }
        public bool CapNhatKH(KhachHang kh)
        {
            return khachHangDAL.CapNhatKH(kh);
        }
        public bool XoaKH(string maKH)
        {
            return khachHangDAL.XoaKH(maKH);
        }
        public IEnumerable<KhachHangViewModels> Find(string text)
        {
            return khachHangDAL.Find(text);
        }
    }
}
