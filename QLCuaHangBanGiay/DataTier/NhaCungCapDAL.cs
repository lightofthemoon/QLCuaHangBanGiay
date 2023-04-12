using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.DataTier
{
    internal class NhaCungCapDAL
    {
        private QuanLyBanGiayModels quanLyBanGiayModels;
        public NhaCungCapDAL()
        {
            quanLyBanGiayModels = new QuanLyBanGiayModels();
        }
        public IEnumerable<NhaCungCapViewModels> GetNhaCungCap()
        {
            return quanLyBanGiayModels.NhaCungCaps.Select(x => new NhaCungCapViewModels()
            {
                MaNCC = x.MaNCC,
                TenNCC = x.TenNCC,
                DiaChi = x.DiaChi,
                SoTaiKhoan = x.SoTaiKhoan,
                TenNH = x.TenNH,
                SDT = x.SDT,
                Email = x.Email,
            }).ToList();
        }
        public int GetSL()
        {
            return quanLyBanGiayModels.NhaCungCaps.Count();
        }
        public bool ThemNhaCungCap(NhaCungCap ncc)
        {
            try
            {
                quanLyBanGiayModels.NhaCungCaps.Add(ncc);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CapNhatNhaCungCap(NhaCungCap ncc)
        {
            try
            {
                var temp = quanLyBanGiayModels.NhaCungCaps.FirstOrDefault(x => x.MaNCC == ncc.MaNCC);
                if(temp != null)
                {
                    temp.MaNCC = ncc.MaNCC;
                    temp.SDT = ncc.SDT;
                    temp.TenNCC = ncc.TenNCC;
                    temp.DiaChi = ncc.DiaChi;
                    temp.Email = ncc.Email;
                    temp.SoTaiKhoan = ncc.SoTaiKhoan;
                    temp.TenNH = ncc.TenNH;
                    quanLyBanGiayModels.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool XoaNhaCungCap(string maNCC)
        {
            try
            {
                var temp = quanLyBanGiayModels.NhaCungCaps.FirstOrDefault(x => x.MaNCC == maNCC);
                if (temp != null)
                    quanLyBanGiayModels.NhaCungCaps.Remove(temp);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<NhaCungCapViewModels> Find(string text)
        {
            var find = quanLyBanGiayModels.NhaCungCaps.Select(x => new NhaCungCapViewModels()
            {
                MaNCC = x.MaNCC,
                TenNCC = x.TenNCC,
                DiaChi = x.DiaChi,
                SoTaiKhoan = x.SoTaiKhoan,
                TenNH = x.TenNH,
                SDT = x.SDT,
                Email = x.Email,
            }).ToList();
            return find.Where(x => x.MaNCC.Contains(text) || x.TenNCC.Contains(text) || x.TenNH.Contains(text)).ToList();
        }
    }
}
