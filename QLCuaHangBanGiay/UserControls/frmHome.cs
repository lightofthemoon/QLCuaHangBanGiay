using GUI;
using QLCuaHangBanGiay.DataTier;
using QLCuaHangBanGiay.DataTier.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCuaHangBanGiay.UserControls
{
    public partial class frmHome : UserControl
    {
        private NhanVienBUS nhanVienBUS;
        LichLamViecBUS lichLamViecBUS;
        HoaDonBUS hoaDonBUS;
        ChiTietHoaDonBUS chiTietHoaDonBUS;
        SanPhamBUS spBUS;
        private string name;
        private string maNV;
        private string chucVu;
        public frmHome(string id)
        {
            nhanVienBUS = new NhanVienBUS();
            lichLamViecBUS= new LichLamViecBUS();
            chiTietHoaDonBUS = new ChiTietHoaDonBUS();
            spBUS = new SanPhamBUS();
            hoaDonBUS = new HoaDonBUS();
            
            var temp = nhanVienBUS.layNV().Where(x => x.MaNV == id).ToList();
            foreach (NhanVien nv in temp)
            {
                name = nv.TenNV;
                maNV = nv.MaNV;
                chucVu = nv.ChucVu;
            }
            InitializeComponent();
        }
        public int GetNum()
        {
            int tong = 0;
            var temp = hoaDonBUS.GetHoaDon().Where(x => x.MaNV == maNV).ToList();
            foreach(HoaDon hd in temp)
            {
                var temp1 = chiTietHoaDonBUS.GetData().Where(x => x.MaHD == hd.MaHD).ToList();
                foreach (ChiTietHoaDon ct in temp1)
                {
                    SanPham sp = spBUS.GetSanPhamData().FirstOrDefault(x => x.MaSP == ct.MaSP);
                    tong += (int)ct.SL * (int)sp.DonGia;
                }
            }
            return tong;
        }
        private int GetDoanhThu()
        {
            int tong = 0;
            var temp = chiTietHoaDonBUS.GetData().ToList();
            foreach(ChiTietHoaDon ct in temp)
            {
                SanPham sp = spBUS.GetSanPhamData().FirstOrDefault(x => x.MaSP == ct.MaSP);
                tong += (int)ct.SL * (int)sp.DonGia;
            }
            return tong;
        }
        private void frmHome_Load(object sender, EventArgs e)
        {
            lbHello.Text = "Hello " + name + ", Chúc bạn ngày mới tốt lành!";
            lbMaNV.Text = maNV;
            lblTen.Text = name;
            if (chucVu == "Quản Lý")
                panelChamCong.Visible = false;
            if(chucVu != "Quản Lý")
            {
                lbDoanhThu.Visible = false;
                lblDoanhThu.Visible = false;
            }
            int doanhso = GetNum();
            int doanhthu = GetDoanhThu();
            NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = ".";
            lbDoanhSo.Text = doanhso.ToString("N0") + " VNĐ";
            lbDoanhThu.Text = doanhthu.ToString("N0") + " VNĐ";
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LichLamViec temp = new LichLamViec();
            temp.MaNV = maNV;
            temp.NgayLamViec = DateTime.Now;
            temp.GioVaoLam = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            txtGioVaoLam.Text = "Giờ vào:" + temp.GioVaoLam;
            if (temp.GioVaoLam < TimeSpan.Parse(DateTime.Now.ToString("12:00:00")))
                temp.MaCaLam = "S01";
            else temp.MaCaLam = "C01";
            try
            {
                if (lichLamViecBUS.ThemLichLamViec(temp))
                    MessageBox.Show("Bạn đã chấm công thành công!", "Thông báo");
                else
                    MessageBox.Show("Bạn đã chấm công rồi", "Thông báo");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo!");
            }
        }
        private void picRaVe_Click(object sender, EventArgs e)
        {
            LichLamViec temp = new LichLamViec();
            temp.MaNV = maNV;
            temp.NgayLamViec = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            temp.GioTanCa = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            if (temp.GioTanCa < TimeSpan.Parse(DateTime.Now.ToString("12:00:00")))
                temp.MaCaLam = "S01";
            else temp.MaCaLam = "C01";
            LichLamViec lich = lichLamViecBUS.GetLichLamViec().FirstOrDefault(x => x.MaNV == temp.MaNV && x.MaCaLam == temp.MaCaLam && x.NgayLamViec == temp.NgayLamViec);
            if(lich == null)
            {
                MessageBox.Show("Bạn chưa chấm công vào làm", "Thông báo");
                return;
            }
            TimeSpan TimeIn = (TimeSpan)lich.GioVaoLam;
            TimeSpan TimeOut = (TimeSpan)temp.GioTanCa;
            TimeSpan minus = TimeOut.Subtract(TimeIn);
            temp.TongGioLam = Math.Round(minus.TotalHours, 2);
            txtTanCa.Text = "Giờ về: " + temp.GioTanCa;
            try
            {
                if (lichLamViecBUS.CapNhatLichLamViec(temp))
                {
                    MessageBox.Show("Bạn đã chấm công ra về thành công", "Thông báo");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
    }
}
