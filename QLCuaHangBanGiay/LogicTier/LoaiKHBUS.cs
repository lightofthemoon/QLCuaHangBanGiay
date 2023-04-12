using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.DataTier
{
    internal class LoaiKHBUS
    {
        private LoaiKHDAL loaiKHDAL;
        public LoaiKHBUS()
        {
            loaiKHDAL = new LoaiKHDAL();
        }
        public IEnumerable<LoaiKH> GetLoaiKH()
        {
            return loaiKHDAL.GetLoaiKH();
        }
        public IEnumerable<LoaiKhachHangViewModels> GetData()
        {
            return loaiKHDAL.GetData();
        }
        public int GetSL()
        {
            return loaiKHDAL.GetSL();
        }
        public bool ThemLoaiKH(LoaiKH loaiKH)
        {
            return loaiKHDAL.ThemLoaiKH(loaiKH);
        }
        public bool CapNhatLoaiKH(LoaiKH loaiKH)
        {
            return loaiKHDAL.CapNhatLoaiKH(loaiKH);
        }
        public bool XoaLoaiKH(string maLoaiKH)
        {
            return loaiKHDAL.XoaLoaiKH(maLoaiKH);
        }
        public IEnumerable<LoaiKH> Find(string text)
        {
            return loaiKHDAL.Find(text);
        }
        //public string CheckPoint(int point)
        //{
        //    return loaiKHDAL.CheckPoint(point);
        //}
    }
}
