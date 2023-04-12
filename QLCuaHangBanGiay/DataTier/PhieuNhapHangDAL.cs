using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.DataTier
{
    internal class PhieuNhapHangDAL
    {
        private QuanLyBanGiayModels quanLyBanGiayModels;
        public PhieuNhapHangDAL()
        {
            quanLyBanGiayModels = new QuanLyBanGiayModels();
        }
        public IEnumerable<PhieuNhapHang> GetData()
        {
            return quanLyBanGiayModels.PhieuNhapHangs.ToList();
        }
        public IEnumerable<PhieuNhapHangViewModels> GetPhieuNhapHang()
        {
            return quanLyBanGiayModels.PhieuNhapHangs.Select(x => new PhieuNhapHangViewModels()
            {
                MaPhieuNhap = x.MaPhieuNhap,
                MaNV = x.MaNV,
                SoLuongSP = x.SoLuongSP,
                TongTien = x.TongTien,
                NgayGiao = x.NgayGiao,
                NgayTao = x.NgayTao,
            }).ToList();
        }
        public int GetSL()
        {
            return quanLyBanGiayModels.PhieuNhapHangs.Count();
        }
        public bool ThemPhieuNhapHang(PhieuNhapHang nhapHang)
        {
            try
            {
                quanLyBanGiayModels.PhieuNhapHangs.Add(nhapHang);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CapNhatPhieuNhapHang(PhieuNhapHang nhapHang)
        {
            try
            {
                var temp = quanLyBanGiayModels.PhieuNhapHangs.FirstOrDefault(x => x.MaPhieuNhap == nhapHang.MaPhieuNhap);
                if(temp != null)
                {
                    temp.MaNV = nhapHang.MaNV;
                    temp.SoLuongSP = nhapHang.SoLuongSP;
                    temp.NgayGiao = nhapHang.NgayGiao;
                    temp.NgayTao = nhapHang.NgayTao;
                    temp.TongTien = nhapHang.TongTien;
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
        public bool XoaPhieuNhapHang(string maPhieu)
        {
            try
            {
                var temp = quanLyBanGiayModels.PhieuNhapHangs.FirstOrDefault(x => x.MaPhieuNhap == maPhieu);
                if (temp != null)
                    quanLyBanGiayModels.PhieuNhapHangs.Remove(temp);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<PhieuNhapHang> Find(string temp)
        {
            return quanLyBanGiayModels.PhieuNhapHangs.Where(x => x.MaPhieuNhap.Contains(temp) || x.MaNV.Contains(temp)).ToList();
        }
    }
}
