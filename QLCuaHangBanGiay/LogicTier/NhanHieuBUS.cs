using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.DataTier
{
    internal class NhanHieuBUS
    {
        private NhanHieuDAL nhanHieuDAL;
        public NhanHieuBUS()
        {
            nhanHieuDAL = new NhanHieuDAL();
        }
        public IEnumerable<NhanHieu> GetNhanHieuData()
        {
            return nhanHieuDAL.GetNhanHieuData();
        }
        public IEnumerable<NhanHieuViewModels> GetNhanHieu()
        {
            return nhanHieuDAL.GetNhanHieu();
        }
        public int GetSL()
        {
            return nhanHieuDAL.GetSL();
        }
        public bool ThemNhanHieu(NhanHieu nhanHieu)
        {
            return nhanHieuDAL.ThemNhanHieu(nhanHieu);
        }
        public bool CapNhatNhanHieu(NhanHieu nhanHieu)
        {
            return nhanHieuDAL.CapNhatNhanHieu(nhanHieu);
        }
        public bool XoaNhanHieu(string maNhanHieu)
        {
            return nhanHieuDAL.XoaNhanHieu(maNhanHieu);
        }
        public IEnumerable<NhanHieuViewModels> Find(string text)
        {
            return nhanHieuDAL.Find(text);
        }
    }
}
