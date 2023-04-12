using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.DataTier
{
    internal class KhachHangDAL
    {
        private QuanLyBanGiayModels quanLyBanGiayModels;
        public KhachHangDAL()
        {
            quanLyBanGiayModels = new QuanLyBanGiayModels();
        }
        public IEnumerable<KhachHang> GetKhachHangData()
        {
            return quanLyBanGiayModels.KhachHangs.ToList();
        }
        public IEnumerable<KhachHangViewModels> GetKhachHang()
        {
            return quanLyBanGiayModels.KhachHangs.Select(x => new KhachHangViewModels()
            {
                MaKH = x.MaKH,
                TenKH = x.TenKH,
                LoaiKH = x.LoaiKH.TenLoaiKH,
                SDT = x.SDT,
                DiemTichLuy = x.DiemTichLuy,
            }).ToList();
        }
        public int GetSL()
        {
            return quanLyBanGiayModels.KhachHangs.Count();
        }
        public bool ThemKH(KhachHang kh)
        {
            try
            {
                quanLyBanGiayModels.KhachHangs.Add(kh);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CapNhatKH(KhachHang kh)
        {
            try
            {
                var temp = quanLyBanGiayModels.KhachHangs.FirstOrDefault(x => x.MaKH == kh.MaKH);
                if(temp != null)
                {
                    temp.MaKH = kh.MaKH;
                    temp.TenKH = kh.TenKH;
                    temp.DiaChi = kh.DiaChi;
                    temp.SDT = kh.SDT;
                    temp.Email = kh.Email;
                    temp.DiemTichLuy = kh.DiemTichLuy;
                    temp.MaLoaiKH = kh.MaLoaiKH;
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
        public bool XoaKH(string maKH)
        {
            try
            {
                var temp = quanLyBanGiayModels.KhachHangs.FirstOrDefault(x => x.MaKH == maKH);
                if (temp != null)
                    quanLyBanGiayModels.KhachHangs.Remove(temp);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<KhachHangViewModels> Find(string text)
        {
            var find = quanLyBanGiayModels.KhachHangs.Select(x => new KhachHangViewModels()
            {
                MaKH = x.MaKH,
                TenKH = x.TenKH,
                LoaiKH = x.LoaiKH.TenLoaiKH,
                SDT = x.SDT,
                DiemTichLuy = x.DiemTichLuy,
            }).ToList();
            return find.Where(x => x.LoaiKH.Contains(text) || x.TenKH.Contains(text) || x.SDT.Contains(text)).ToList();
        }
    }
}
