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
    internal class DanhMucDAL
    {
        private QuanLyBanGiayModels quanLyBanGiayModels;
        public DanhMucDAL()
        {
            quanLyBanGiayModels = new QuanLyBanGiayModels();
        }
        public IEnumerable<DanhMucViewModels> GetDanhMuc()
        {
            return quanLyBanGiayModels.DanhMucSanPhams.Select(x => new DanhMucViewModels()
            {
                MaDanhMuc = x.MaDanhMuc,
                TenDanhMuc = x.TenDanhMuc,
            }).ToList();
        }
        public int GetSL()
        {
            return quanLyBanGiayModels.DanhMucSanPhams.Count();
        }
        public bool ThemDanhMuc(DanhMucSanPham danhMuc)
        {
            try
            {
                quanLyBanGiayModels.DanhMucSanPhams.Add(danhMuc);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CapNhatDanhMuc(DanhMucSanPham danhMuc)
        {
            try
            {
                var temp = quanLyBanGiayModels.DanhMucSanPhams.FirstOrDefault(x => x.MaDanhMuc == danhMuc.MaDanhMuc);
                if(temp != null)
                {
                    temp.MaDanhMuc = danhMuc.MaDanhMuc;
                    temp.TenDanhMuc = danhMuc.TenDanhMuc;
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
        public bool XoaDanhMuc(string maDanhMuc)
        {
            try
            {
                var temp = quanLyBanGiayModels.DanhMucSanPhams.FirstOrDefault(x => x.MaDanhMuc == maDanhMuc);
                if (temp != null)
                    quanLyBanGiayModels.DanhMucSanPhams.Remove(temp);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<DanhMucViewModels> Find(string text)
        {
            var find = quanLyBanGiayModels.DanhMucSanPhams.Select(x => new DanhMucViewModels()
            {
                MaDanhMuc = x.MaDanhMuc,
                TenDanhMuc = x.TenDanhMuc,
            }).ToList();
            return find.Where(x => x.MaDanhMuc.Contains(text) || x.TenDanhMuc.Contains(text)).ToList();
        }
    }
}
