using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.DataTier
{
    internal class ChiTietPhieuNhapHangDAL
    {
        private QuanLyBanGiayModels quanLyBanGiayModels;
        public ChiTietPhieuNhapHangDAL()
        {
            quanLyBanGiayModels = new QuanLyBanGiayModels();
        }
        public IEnumerable<ChiTietPhieuNhapHangViewModels> GetChiTietPhieuNhapHang()
        {
            return quanLyBanGiayModels.ChiTietPhieuNhapHangs.Select(x => new ChiTietPhieuNhapHangViewModels()
            {
                MaPhieuNhap = x.MaPhieuNhap,
                MaNCC = x.MaNCC,
                MaSP = x.MaSP,
                SL = x.SL,
                Gia = x.Gia,
                Size = x.Size,
                MoTa = x.MoTa,
            }).ToList();
        }
        public IEnumerable<ChiTietPhieuNhapHang> GetData()
        {
            return quanLyBanGiayModels.ChiTietPhieuNhapHangs.ToList();
        }
        public int GetSL()
        {
            return quanLyBanGiayModels.ChiTietPhieuNhapHangs.Count();
        }
        public bool ThemChiTietPhieuNhapHang(ChiTietPhieuNhapHang nhapHang)
        {
            try
            {
                quanLyBanGiayModels.ChiTietPhieuNhapHangs.Add(nhapHang);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CapNhatChiTietPhieuNhapHang(ChiTietPhieuNhapHang nhapHang)
        {
            try
            {
                var temp = quanLyBanGiayModels.ChiTietPhieuNhapHangs.FirstOrDefault(x => x.MaPhieuNhap == nhapHang.MaPhieuNhap && x.MaNCC == nhapHang.MaNCC && x.MaSP == nhapHang.MaSP);
                if(temp != null)
                {
                    temp.MaNCC = nhapHang.MaNCC;
                    temp.MaSP = nhapHang.MaSP;
                    temp.SL = nhapHang.SL;
                    temp.Gia = nhapHang.Gia;
                    temp.Size = nhapHang.Size;
                    temp.MoTa = nhapHang.MoTa;
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
        public bool XoaChiTietPhieuNhapHang(string maPhieu, string maNCC, string maSP)
        {
            try
            {
                var temp = quanLyBanGiayModels.ChiTietPhieuNhapHangs.FirstOrDefault(x => x.MaPhieuNhap == maPhieu && x.MaNCC == maNCC && x.MaSP == maSP);
                if (temp != null)
                    quanLyBanGiayModels.ChiTietPhieuNhapHangs.Remove(temp);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool XoaChiTietFull(string maPhieu)
        {
            try
            {
                var temp = quanLyBanGiayModels.ChiTietPhieuNhapHangs.FirstOrDefault(x => x.MaPhieuNhap == maPhieu);
                if (temp != null)
                    quanLyBanGiayModels.ChiTietPhieuNhapHangs.Remove(temp);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<ChiTietPhieuNhapHang> Find(string temp)
        {
            return quanLyBanGiayModels.ChiTietPhieuNhapHangs.Where(x => x.MaPhieuNhap.Contains(temp) || x.MaNCC.Contains(temp) || x.MaSP.Contains(temp)).ToList();
        }
    }
}
