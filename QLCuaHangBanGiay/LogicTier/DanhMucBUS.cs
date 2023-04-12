using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.DataTier
{
    internal class DanhMucBUS
    {
        private DanhMucDAL danhMucDAL;
        public DanhMucBUS()
        {
            danhMucDAL = new DanhMucDAL();
        }
        public IEnumerable<DanhMucViewModels> GetDanhMuc()
        {
            return danhMucDAL.GetDanhMuc();
        }
        public int GetSL()
        {
            return danhMucDAL.GetSL();
        }
        public bool ThemDanhMuc(DanhMucSanPham danhMuc)
        {
            return danhMucDAL.ThemDanhMuc(danhMuc);
        }
        public bool CapNhatDanhMuc(DanhMucSanPham danhMuc)
        {
            return danhMucDAL.CapNhatDanhMuc(danhMuc);
        }
        public bool XoaDanhMuc(string maDanhMuc)
        {
            return danhMucDAL.XoaDanhMuc(maDanhMuc);
        }
        public IEnumerable<DanhMucViewModels> Find(string text)
        {
            return danhMucDAL.Find(text);
        }
    }
}
