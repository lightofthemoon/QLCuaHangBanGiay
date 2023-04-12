using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.DataTier
{
    internal class NhaCungCapBUS
    {
        private NhaCungCapDAL nhaCungCapDAL;
        public NhaCungCapBUS()
        {
            nhaCungCapDAL = new NhaCungCapDAL();
        }
        public IEnumerable<NhaCungCapViewModels> GetNhaCungCap()
        {
            return nhaCungCapDAL.GetNhaCungCap();
        }
        public int GetSL()
        {
            return nhaCungCapDAL.GetSL();
        }
        public bool ThemNhaCungCap(NhaCungCap ncc)
        {
            return nhaCungCapDAL.ThemNhaCungCap(ncc);
        }
        public bool CapNhatNhaCungCap(NhaCungCap ncc)
        {
            return nhaCungCapDAL.CapNhatNhaCungCap(ncc);
        }
        public bool XoaNhaCungCap(string maNCC)
        {
            return nhaCungCapDAL.XoaNhaCungCap(maNCC);
        }
        public IEnumerable<NhaCungCapViewModels> Find(string text)
        {
            return nhaCungCapDAL.Find(text);
        }
    }
}
