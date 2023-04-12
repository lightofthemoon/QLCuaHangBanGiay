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
    internal class HoaDonDAL
    {
        private QuanLyBanGiayModels quanLyBanGiayModels;
        public HoaDonDAL()
        {
            quanLyBanGiayModels = new QuanLyBanGiayModels();
        }
        public IEnumerable<HoaDon> GetHoaDon()
        {
            return quanLyBanGiayModels.HoaDons.ToList();
        }
        public IEnumerable<HoaDonViewModels> GetDataHD(string maHD)
        {
            var temp = quanLyBanGiayModels.HoaDons.Select(h => new HoaDonViewModels
            {
                MaHD = h.MaHD,
                MaNV = h.MaNV,
                MaKH = h.MaKH,
                NgayTao = h.NgayTao,
            }).ToList();
            return temp.Where(h => h.MaHD == maHD).ToList();
        }
        public IEnumerable<HoaDonViewModels> GetHD()
        {
            return quanLyBanGiayModels.HoaDons.Select(h => new HoaDonViewModels
            {
                MaHD = h.MaHD,
                MaNV = h.MaNV,
                MaKH = h.MaKH,
                NgayTao = h.NgayTao,
            }).ToList();
        }
        public int GetSL()
        {
            return quanLyBanGiayModels.HoaDons.Count();
        }
        public bool ThemHoaDon(HoaDon hoaDon)
        {
            try
            {
                quanLyBanGiayModels.HoaDons.Add(hoaDon);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CapNhatHoaDon(HoaDon hoaDon)
        {
            try
            {
                var temp = quanLyBanGiayModels.HoaDons.FirstOrDefault(x => x.MaHD == hoaDon.MaHD);
                if(temp != null)
                {
                    temp.MaNV = hoaDon.MaNV;
                    temp.MaKH = hoaDon.MaKH;
                    temp.NgayTao = hoaDon.NgayTao;
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
        public bool XoaHoaDon(string maHD)
        {
            try
            {
                var temp = quanLyBanGiayModels.HoaDons.FirstOrDefault(x => x.MaHD == maHD);
                if (temp != null)
                    quanLyBanGiayModels.HoaDons.Remove(temp);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<HoaDonViewModels> Find(string temp)
        {
            var hd = quanLyBanGiayModels.HoaDons.Select(x => new HoaDonViewModels()
            {
                MaHD = x.MaHD,
                MaNV = x.MaNV,
                MaKH = x.MaKH,
                NgayTao = x.NgayTao,
            }).ToList();
            return hd.Where(x => x.MaHD.Contains(temp) || x.MaNV.Contains(temp) || x.MaKH.Contains(temp)).ToList();
        }
    }
}
