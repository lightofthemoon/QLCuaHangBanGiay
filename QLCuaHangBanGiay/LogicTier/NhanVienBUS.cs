using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.DataTier
{
    internal class NhanVienBUS
    {
        private NhanVienDAL nhanVienDAL;
        public NhanVienBUS()
        {
            nhanVienDAL = new NhanVienDAL();
        }
        public IEnumerable<NhanVienViewModels> GetNhanViens()
        {
            return nhanVienDAL.GetNhanViens();
        }
        public IEnumerable<NhanVien> layNV()
        {
            return nhanVienDAL.layNV();
        }
        public int GetSL()
        {
            return nhanVienDAL.GetSL();
        }
        public int GetSLNV()
        {
            return nhanVienDAL.GetSLNV();
        }
        public int GetSLQL()
        {
            return nhanVienDAL.GetSLQL();
        }
        public bool ThemNhanVien(NhanVien nv)
        {
            return nhanVienDAL.ThemNhanVien(nv);
        }
        public bool CapNhatNhanVien(NhanVien nv)
        {
            return nhanVienDAL.CapNhatNhanVien(nv);
        }
        public bool XoaNhanVien(string maNV)
        {
            return nhanVienDAL.XoaNhanVien(maNV);
        }
        public IEnumerable<NhanVienViewModels> GetNhanVienTheoLoai(string chucVu)
        {
            return nhanVienDAL.GetNhanVienTheoLoai(chucVu);
        }
        public IEnumerable<NhanVienViewModels> Find(string temp)
        {
            return nhanVienDAL.Find(temp);
        }
        public bool CapNhatPass(string maNV, string newPass)
        {
            return nhanVienDAL.CapNhatPassWord(maNV, newPass);
        }
        public int GetNum(string maNV)
        {
            return nhanVienDAL.GetNum(maNV);
        }
        public bool QuenMatKhau(string userName, string email, string newPass)
        {
            return nhanVienDAL.QuenMatKhau(userName, email, newPass);
        }
        public bool QuenMatKhau(string userName, string email)
        {
            return nhanVienDAL.QuenMatKhau(userName, email);
        }
    }
}
