using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.DataTier
{
    internal class SanPhamDAL
    {
        private QuanLyBanGiayModels quanLyBanGiayModels;
        public SanPhamDAL()
        {
            quanLyBanGiayModels = new QuanLyBanGiayModels();
        }
        public IEnumerable<SanPhamInHoaDonViewModels> GetData()
        {
            return quanLyBanGiayModels.SanPhams.Select(x => new SanPhamInHoaDonViewModels()
            {
                MaSP = x.MaSP,
                TenSP = x.TenSP,
                MoTa = x.MoTa,
                SLTonKho = x.SLTonKho,
                DonGia = x.DonGia,
            }).ToList();
        }
        public IEnumerable<SanPham> GetSanPhamData()
        {
            return quanLyBanGiayModels.SanPhams.ToList();
        }
        public IEnumerable<SanPhamViewModels> GetSanPham()
        {
            return quanLyBanGiayModels.SanPhams.Select(x => new SanPhamViewModels()
            {
                MaSP = x.MaSP,
                MaDanhMuc = x.MaDanhMuc,
                MaNhanHieu = x.MaNhanHieu,
                TenSP = x.TenSP,
                MoTa = x.MoTa,
                SLTonKho = x.SLTonKho,
                DonGia = x.DonGia,
            }).ToList();
        }
        public int GetSL()
        {
            return quanLyBanGiayModels.SanPhams.Count();
        }
        public bool ThemSanPham(SanPham sp)
        {
            try
            {
                quanLyBanGiayModels.SanPhams.Add(sp);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CapNhatSanPham(SanPham sp)
        {
            try
            {
                var temp = quanLyBanGiayModels.SanPhams.FirstOrDefault(x => x.MaSP == sp.MaSP);
                if(temp != null)
                {
                    temp.MaSP = sp.MaSP;
                    temp.MaDanhMuc = sp.MaDanhMuc;
                    temp.MaNhanHieu = sp.MaNhanHieu;
                    temp.TenSP = sp.TenSP;
                    temp.MoTa = sp.MoTa;
                    temp.AnhSP = sp.AnhSP;
                    temp.SLTonKho = sp.SLTonKho;
                    temp.DonGia = sp.DonGia;
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
        public bool XoaSanPham(string maSP)
        {
            try
            {
                var temp = quanLyBanGiayModels.SanPhams.FirstOrDefault(x => x.MaSP == maSP);
                if (temp != null)
                    quanLyBanGiayModels.SanPhams.Remove(temp);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<SanPhamViewModels> Find(string text)
        {
            var find = quanLyBanGiayModels.SanPhams.Select(x => new SanPhamViewModels()
            {
                MaSP = x.MaSP,
                MaDanhMuc = x.MaDanhMuc,
                MaNhanHieu = x.MaNhanHieu,
                TenSP = x.TenSP,
                SLTonKho = x.SLTonKho,
                DonGia = x.DonGia,
                MoTa = x.MoTa,
            }).ToList();
            return find.Where(x => x.MaSP.Contains(text) || x.TenSP.Contains(text) || x.MaNhanHieu.Contains(text)).ToList();
        }
    }
}
