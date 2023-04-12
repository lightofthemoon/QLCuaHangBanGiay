using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.DataTier
{
    internal class SanPhamBUS
    {
        private SanPhamDAL sanPhamDAL;
        public SanPhamBUS()
        {
            sanPhamDAL = new SanPhamDAL();
        }
        public IEnumerable<SanPhamInHoaDonViewModels> GetData()
        {
            return sanPhamDAL.GetData();
        }
        public IEnumerable<SanPham> GetSanPhamData()
        {
            return sanPhamDAL.GetSanPhamData();
        }
        public IEnumerable<SanPhamViewModels> GetSanPham()
        {
            return sanPhamDAL.GetSanPham();
        }
        public int GetSL()
        {
            return sanPhamDAL.GetSL();
        }
        public bool ThemSanPham(SanPham sp)
        {
            return sanPhamDAL.ThemSanPham(sp);
        }
        public bool CapNhatSanPham(SanPham sp)
        {
            return sanPhamDAL.CapNhatSanPham(sp);
        }
        public bool XoaSanPham(string maSP)
        {
            return sanPhamDAL.XoaSanPham(maSP);
        }
        public IEnumerable<SanPhamViewModels> Find(string text)
        {
            return sanPhamDAL.Find(text);
        }
    }
}
