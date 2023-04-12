using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLCuaHangBanGiay.DataTier.Models
{
    public partial class QuanLyBanGiayModels : DbContext
    {
        public QuanLyBanGiayModels()
            : base("name=QuanLyBanGiayModels33")
        {
        }

        public virtual DbSet<CaLam> CaLams { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<ChiTietPhieuNhapHang> ChiTietPhieuNhapHangs { get; set; }
        public virtual DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LichLamViec> LichLamViecs { get; set; }
        public virtual DbSet<LoaiKH> LoaiKHs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanHieu> NhanHieux { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuNhapHang> PhieuNhapHangs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaLam>()
                .Property(e => e.MaCaLam)
                .IsUnicode(false);

            modelBuilder.Entity<CaLam>()
                .HasMany(e => e.LichLamViecs)
                .WithRequired(e => e.CaLam)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietPhieuNhapHang>()
                .Property(e => e.MaPhieuNhap)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietPhieuNhapHang>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietPhieuNhapHang>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietPhieuNhapHang>()
                .Property(e => e.Size)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucSanPham>()
                .Property(e => e.MaDanhMuc)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaLoaiKH)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<LichLamViec>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<LichLamViec>()
                .Property(e => e.MaCaLam)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiKH>()
                .Property(e => e.MaLoaiKH)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.SoTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.TenNH)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .HasMany(e => e.ChiTietPhieuNhapHangs)
                .WithRequired(e => e.NhaCungCap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanHieu>()
                .Property(e => e.MaNhanHieu)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.LoaiNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.LichLamViecs)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuNhapHang>()
                .Property(e => e.MaPhieuNhap)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapHang>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapHang>()
                .HasMany(e => e.ChiTietPhieuNhapHangs)
                .WithRequired(e => e.PhieuNhapHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaDanhMuc)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaNhanHieu)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietPhieuNhapHangs)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);
        }
    }
}
