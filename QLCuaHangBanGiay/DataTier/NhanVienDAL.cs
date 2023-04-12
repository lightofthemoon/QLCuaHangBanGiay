using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCuaHangBanGiay.DataTier
{
    internal class NhanVienDAL
    {
        private QuanLyBanGiayModels quanLyBanGiayModels;
        public NhanVienDAL()
        {
            quanLyBanGiayModels = new QuanLyBanGiayModels();
        }
        public IEnumerable<NhanVien> layNV()
        {
            return quanLyBanGiayModels.NhanViens.ToList();
        }
        public IEnumerable<NhanVienViewModels> GetNhanViens()
        {
            return quanLyBanGiayModels.NhanViens.Select(x => new NhanVienViewModels()
            {
                MaNV = x.MaNV,
                TenNV = x.TenNV,
                LoaiNhanVien = x.LoaiNhanVien,
                UserName = x.UserName,
                NamSinh = x.NamSinh,
                DiaChi = x.DiaChi,
                Email = x.Email,
                SDT = x.SDT,
                ChucVu = x.ChucVu,
                LuongCB = x.LuongCB,
            }).ToList();
        }
        public int GetSL()
        {
            return quanLyBanGiayModels.NhanViens.Count();
        }
        public int GetSLNV()
        {
            return quanLyBanGiayModels.NhanViens.Where(x => x.ChucVu != "Quản Lý").Count();
        }
        public int GetSLQL()
        {
            return quanLyBanGiayModels.NhanViens.Where(x => x.ChucVu == "Quản Lý").Count();
        }
        public bool ThemNhanVien(NhanVien nv)
        {
            try
            {
                var temp = GetNhanViens().Where(x => x.UserName == nv.UserName).ToList();
                if (temp.Count == 0)
                {
                    quanLyBanGiayModels.NhanViens.Add(nv);
                    quanLyBanGiayModels.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CapNhatNhanVien(NhanVien nv)
        {
            try
            {
                var temp = quanLyBanGiayModels.NhanViens.FirstOrDefault(x => x.MaNV == nv.MaNV);
                if(temp != null)
                {
                    temp.TenNV = nv.TenNV;
                    temp.LoaiNhanVien = nv.LoaiNhanVien;
                    temp.UserName = nv.UserName;
                    temp.PassWord = nv.PassWord;
                    temp.NamSinh = nv.NamSinh;
                    temp.DiaChi = nv.DiaChi;
                    temp.Email = nv.Email;
                    temp.SDT = nv.SDT;
                    temp.ChucVu = nv.ChucVu;
                    temp.LuongCB = nv.LuongCB;
                    temp.AnhNV = nv.AnhNV;
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
        public bool XoaNhanVien(string maNV)
        {
            try
            {
                var temp = quanLyBanGiayModels.NhanViens.FirstOrDefault(x => x.MaNV == maNV);
                if (temp != null)
                    quanLyBanGiayModels.NhanViens.Remove(temp);
                quanLyBanGiayModels.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<NhanVienViewModels> GetNhanVienTheoLoai(string chucVu)
        {
            var type = quanLyBanGiayModels.NhanViens.Select(x => new NhanVienViewModels()
            {
                MaNV = x.MaNV,
                TenNV = x.TenNV,
                LoaiNhanVien = x.LoaiNhanVien,
                UserName = x.UserName,
                NamSinh = x.NamSinh,
                DiaChi = x.DiaChi,
                Email = x.Email,
                SDT = x.SDT,
                ChucVu = x.ChucVu,
                LuongCB = x.LuongCB,
            }).ToList();
            return type.Where(x => x.MaNV.Contains(chucVu)).ToList();
        }
        public IEnumerable<NhanVienViewModels> Find(string temp)
        {
            var find = quanLyBanGiayModels.NhanViens.Select(x => new NhanVienViewModels()
            {
                MaNV = x.MaNV,
                TenNV = x.TenNV,
                LoaiNhanVien = x.LoaiNhanVien,
                UserName = x.UserName,
                NamSinh = x.NamSinh,
                DiaChi = x.DiaChi,
                Email = x.Email,
                SDT = x.SDT,
                ChucVu = x.ChucVu,
                LuongCB = x.LuongCB,
            }).ToList();
            return find.Where(x => x.MaNV.Contains(temp) || x.TenNV.Contains(temp) || x.UserName.Contains(temp)).ToList();
        }
        public bool CapNhatPassWord(string maNV, string newPass)
        {
            try
            {
                var temp = quanLyBanGiayModels.NhanViens.FirstOrDefault(x => x.MaNV == maNV);
                if (temp != null)
                {
                    temp.PassWord = newPass;
                    quanLyBanGiayModels.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetNum(string maNV)
        {
            int tong = 0;
            var temp = quanLyBanGiayModels.HoaDons.Where(x => x.MaNV == maNV).ToList();
            foreach(HoaDon hd in temp)
            {
                var temp1 = quanLyBanGiayModels.ChiTietHoaDons.Where(x => x.MaHD == hd.MaHD).ToList();
                foreach(ChiTietHoaDon ct in temp1)
                {
                    tong = tong + (int)ct.SL;
                }
            }
            return tong;
        }
        public bool QuenMatKhau(string userName, string email, string newPass)
        {
            try
            {
                var temp = quanLyBanGiayModels.NhanViens.FirstOrDefault(x => x.UserName == userName && x.Email == email);
                if (temp != null)
                {
                    temp.PassWord = newPass;
                    quanLyBanGiayModels.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool QuenMatKhau(string userName, string email)
        {
            try
            {
                var temp = quanLyBanGiayModels.NhanViens.FirstOrDefault(x => x.UserName == userName && x.Email == email);
                if (temp != null)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
