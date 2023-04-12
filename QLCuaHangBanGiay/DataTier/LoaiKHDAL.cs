using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.DataTier
{
    internal class LoaiKHDAL
    {
        private QuanLyBanGiayModels quanLyBanGiayModels;
        public LoaiKHDAL()
        {
            quanLyBanGiayModels = new QuanLyBanGiayModels();
        }
        public IEnumerable<LoaiKH> GetLoaiKH()
        {
            return quanLyBanGiayModels.LoaiKHs.ToList();
        }
        public IEnumerable<LoaiKhachHangViewModels> GetData()
        {
            return quanLyBanGiayModels.LoaiKHs.Select(x => new LoaiKhachHangViewModels()
            {
                MaLoaiKH = x.MaLoaiKH,
                TenLoaiKH = x.TenLoaiKH,
                SoDiemTichLuyToiThieu = x.SoDiemTichLuyToiThieu,
            }).ToList();
        }
        public int GetSL()
        {
            return quanLyBanGiayModels.LoaiKHs.Count();
        }
        public bool ThemLoaiKH(LoaiKH loaiKH)
        {
            try
            {
                quanLyBanGiayModels.LoaiKHs.Add(loaiKH);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CapNhatLoaiKH(LoaiKH loaiKH)
        {
            try
            {
                var temp = quanLyBanGiayModels.LoaiKHs.FirstOrDefault(x => x.MaLoaiKH == loaiKH.MaLoaiKH);
                if(temp != null)
                {
                    temp.TenLoaiKH = loaiKH.TenLoaiKH;
                    temp.SoDiemTichLuyToiThieu = loaiKH.SoDiemTichLuyToiThieu;
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
        public bool XoaLoaiKH(string maLoaiKH)
        {
            try
            {
                var temp = quanLyBanGiayModels.LoaiKHs.FirstOrDefault(x => x.MaLoaiKH == maLoaiKH);
                if (temp != null)
                    quanLyBanGiayModels.LoaiKHs.Remove(temp);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<LoaiKH> Find(string text)
        {
            return quanLyBanGiayModels.LoaiKHs.Where(x => x.MaLoaiKH.Contains(text) || x.TenLoaiKH.Contains(text)).ToList();
        }
    }
}
