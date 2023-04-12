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
    internal class ChiTietHoaDonDAL
    {
        private QuanLyBanGiayModels quanLyBanGiayModels;
        public ChiTietHoaDonDAL()
        {
            quanLyBanGiayModels = new QuanLyBanGiayModels();
        }
        public IEnumerable<ChiTietHoaDon> GetData()
        {
            return quanLyBanGiayModels.ChiTietHoaDons.ToList();
        }
        public IEnumerable<ChiTietHoaDonViewModels> GetChiTietHoaDon()
        {
            return quanLyBanGiayModels.ChiTietHoaDons.Select(x => new ChiTietHoaDonViewModels
            {
                MaHD = x.MaHD,
                MaSP = x.MaSP,
                MoTa = x.MoTa,
                SoLuong = x.SL,
                DonGia = x.DonGia,
                ThanhTien = x.ThanhTien,
            }).ToList();
        }
        public IEnumerable<ChiTietHoaDonViewModels> Find(string maHD)
        {
            var temp = quanLyBanGiayModels.ChiTietHoaDons.Select(x => new ChiTietHoaDonViewModels
            {
                MaHD = x.MaHD,
                MaSP = x.MaSP,
                MoTa = x.MoTa,
                SoLuong = x.SL,
                DonGia = x.DonGia,
                ThanhTien = x.ThanhTien,
            }).ToList();
            return temp.Where(x => x.MaHD == maHD).ToList();
        }
        public int GetSL()
        {
            return quanLyBanGiayModels.ChiTietHoaDons.Count();
        }
        public bool ThemChiTietHoaDon(ChiTietHoaDon ChiTiethoaDon)
        {
            try
            {
                quanLyBanGiayModels.ChiTietHoaDons.Add(ChiTiethoaDon);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public bool CapNhatChiTietHoaDon(ChiTietHoaDon ct)
        //{
        //    try
        //    {
        //        var temp = quanLyBanGiayModels.ChiTietHoaDons.Where(x => x.MaHD == ct.MaHD && x.MaSP == ct.MaSP).ToList();
        //        if(temp != null)
        //        {
        //            temp.MaHD = ct.MaHD;
        //            temp.MaSP = ct.MaSP;
        //            temp.MoTa = ct.MoTa;
        //            temp.SL = ct.SL;
        //            quanLyBanGiayModels.SaveChanges();
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public bool Xoa1ChiTietHoaDon(string maHD, string maSP)
        {
            try
            {
                var temp = quanLyBanGiayModels.ChiTietHoaDons.Where(x => x.MaHD == maHD && x.MaSP == maSP).ToList();
                if (temp != null)
                    foreach(ChiTietHoaDon ct in temp)
                        quanLyBanGiayModels.ChiTietHoaDons.Remove(ct);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool XoaChiTietHoaDon(string maHD)
        {
            try
            {
                var temp = quanLyBanGiayModels.ChiTietHoaDons.Where(x => x.MaHD == maHD).ToList();
                if (temp != null)
                    foreach (ChiTietHoaDon ct in temp)
                        quanLyBanGiayModels.ChiTietHoaDons.Remove(ct);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<ChiTietHoaDonViewModels> FindText(string text)
        {
            var temp = quanLyBanGiayModels.ChiTietHoaDons.Select(x => new ChiTietHoaDonViewModels
            {
                MaHD = x.MaHD,
                MaSP = x.MaSP,
                MoTa = x.MoTa,
                SoLuong = x.SL,
                DonGia = x.DonGia,
                ThanhTien = x.ThanhTien,
            }).ToList();
            return temp.Where(x => x.MaHD.Contains(text) || x.MaSP.Contains(text)).ToList();
        }
    }
}
