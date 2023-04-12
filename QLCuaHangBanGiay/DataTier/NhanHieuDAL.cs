using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuaHangBanGiay.DataTier
{
    internal class NhanHieuDAL
    {
        private QuanLyBanGiayModels quanLyBanGiayModels;
        public NhanHieuDAL()
        {
            quanLyBanGiayModels = new QuanLyBanGiayModels();
        }
        public IEnumerable<NhanHieu> GetNhanHieuData()
        {
            return quanLyBanGiayModels.NhanHieux.ToList();
        }
        public IEnumerable<NhanHieuViewModels> GetNhanHieu()
        {
            return quanLyBanGiayModels.NhanHieux.Select(x => new NhanHieuViewModels()
            {
                MaNhanHieu = x.MaNhanHieu,
                TenNhanHieu = x.TenNhanHieu,
                XuatXu = x.XuatXu,
            }).ToList();
        }
        public int GetSL()
        {
            return quanLyBanGiayModels.NhanHieux.Count();
        }
        public bool ThemNhanHieu(NhanHieu nhanHieu)
        {
            try
            {
                quanLyBanGiayModels.NhanHieux.Add(nhanHieu);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CapNhatNhanHieu(NhanHieu nhanHieu)
        {
            try
            {
                var temp = quanLyBanGiayModels.NhanHieux.FirstOrDefault(x => x.MaNhanHieu == nhanHieu.MaNhanHieu);
                if(temp != null)
                {
                    temp.MaNhanHieu = nhanHieu.MaNhanHieu;
                    temp.TenNhanHieu = nhanHieu.TenNhanHieu;
                    temp.XuatXu = nhanHieu.XuatXu;
                    temp.AnhNH = nhanHieu.AnhNH;
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
        public bool XoaNhanHieu(string maNhanHieu)
        {
            try
            {
                var temp = quanLyBanGiayModels.NhanHieux.FirstOrDefault(x => x.MaNhanHieu == maNhanHieu);
                if (temp != null)
                    quanLyBanGiayModels.NhanHieux.Remove(temp);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<NhanHieuViewModels> Find(string text)
        {
            var find = quanLyBanGiayModels.NhanHieux.Select(x => new NhanHieuViewModels()
            {
                MaNhanHieu = x.MaNhanHieu,
                TenNhanHieu = x.TenNhanHieu,
                XuatXu = x.XuatXu,
            }).ToList();
            return find.Where(x => x.MaNhanHieu.Contains(text) || x.TenNhanHieu.Contains(text) || x.MaNhanHieu.Contains(text)).ToList();
        }
    }
}
