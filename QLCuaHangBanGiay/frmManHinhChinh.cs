using GUI;
using QLCuaHangBanGiay.DataTier;
using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCuaHangBanGiay
{
    public partial class frmManHinhChinh : frmDangNhap
    {
        private Boolean showPanelDash = false;
        private Boolean showPanelNghiepVu = false;
        private Boolean showPanelThongKe = false;
        private NhanVienBUS nhanVienBUS;
        private string chucVu;
        private string name;
        private string maNV;
        private string userName;
        public frmManHinhChinh(string id) // id is UserName
        {
            InitializeComponent();
            customHide();
            userName = id;
            nhanVienBUS = new NhanVienBUS();
            var temp = nhanVienBUS.layNV().Where(x => x.UserName == id).ToList();
            foreach (NhanVien nv in temp)
            {
                maNV = nv.MaNV;
                name = nv.TenNV;
                chucVu = nv.ChucVu;
            }
            if (chucVu != "Quản Lý")
            {
                panelQuanLy.Visible = false;
                btnPhieuNhapHang.Visible = false;
            }
            frmHome fn = new frmHome(maNV);
            addUserControl(fn);
        }
        private void customHide()
        {
            panelQuanLySubMenu.Visible = false;
            panelNghiepVuSubMenu.Visible = false;
            panelBaoCaoSubMenu.Visible = false;
        }
        private void hidePanel()
        {
            if (panelQuanLySubMenu.Visible == true)
                panelQuanLySubMenu.Visible = false;
            if (panelNghiepVuSubMenu.Visible == true)
                panelNghiepVuSubMenu.Visible = false;
            if (panelBaoCaoSubMenu.Visible == true)
                panelBaoCaoSubMenu.Visible = false;
        }
        private void showPanel(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hidePanel();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            lbName.Text = "NV. " + name;
            lbChucVu.Text = chucVu;
        }
        public void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //frmhay2 yeah = new frmhay2();
            //addUserControl(yeah);
        }
        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            showPanel(panelQuanLySubMenu);
            showPanelDash = !showPanelDash;
        }
        private void btnNghiepVu_Click(object sender, EventArgs e)
        {
            showPanel(panelNghiepVuSubMenu);
            showPanelNghiepVu = !showPanelNghiepVu;
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            showPanel(panelBaoCaoSubMenu);
            showPanelThongKe = !showPanelThongKe;
        }
        private void btnSDoanhThu_Click(object sender, EventArgs e)
        {
            //frmTaiKhoan y = new frmTaiKhoan();
        }

        private void btnBangDieuKhien_Click(object sender, EventArgs e)
        {
            frmHome fn = new frmHome(maNV);
            addUserControl(fn);
        }

        private void btnSNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien y = new frmNhanVien();
            addUserControl(y);
        }
        private void btnSNhaCungCap_Click(object sender, EventArgs e)
        {
            frmNhaCungCap ok = new frmNhaCungCap();
            addUserControl(ok);
        }
        private void openLoginForm()
        {
            Application.Run(new frmDangNhap());
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(openLoginForm));
            t.SetApartmentState(ApartmentState.STA);
            this.FormClosing -= frmMain_FormClosing;
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                t.Start();
            }
        }
        private void btnSSanPham_Click(object sender, EventArgs e)
        {
            frmSanPham sp = new frmSanPham();
            addUserControl(sp);
        }
        private void btnNhanHieu_Click(object sender, EventArgs e)
        {
            frmDMNhanHieu nhanHieuchoQuy = new frmDMNhanHieu();
            addUserControl(nhanHieuchoQuy);
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmMatKhau tk = new frmMatKhau(maNV);
            addUserControl(tk);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            frmLapHoaDon hoadon = new frmLapHoaDon(maNV);
            addUserControl(hoadon);
        }
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang kh = new frmKhachHang();
            addUserControl(kh);
        }

        private void btnSQLHoaDon_Click(object sender, EventArgs e)
        {
            frmQLHoaDon qly = new frmQLHoaDon();
            addUserControl(qly);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmNhapHang nhapHang = new frmNhapHang(maNV);
            addUserControl(nhapHang);
        }

        private void btnSoNgayLamViec_Click(object sender, EventArgs e)
        {
            frmThongKeSoNgayLam songaylam = new frmThongKeSoNgayLam();
            addUserControl(songaylam);
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThu doanhthu = new frmThongKeDoanhThu();
            addUserControl(doanhthu);
        }
    }
}
