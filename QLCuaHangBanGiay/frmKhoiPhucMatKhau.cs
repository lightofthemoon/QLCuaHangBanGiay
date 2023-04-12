using GUI;
using QLCuaHangBanGiay.DataTier;
using QLCuaHangBanGiay.DataTier.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCuaHangBanGiay
{
    public partial class frmKhoiPhucMatKhau : Form
    {
        NhanVienBUS nvBUS;
        string UserName;
        string UserMail;
        public frmKhoiPhucMatKhau(string user, string email)
        {
            InitializeComponent();
            UserName = user;
            UserMail = email;
            nvBUS = new NhanVienBUS();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {           
            if (string.IsNullOrEmpty(txtMatKhauMoi.Text))
            {
                MessageBox.Show("Password không được để trống, vui nhập nhập lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauMoi.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtXacNhanMK.Text))
            {
                MessageBox.Show("Password confirm không được để trống, vui nhập nhập lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtXacNhanMK.Focus();
                return;
            }
            else if (txtMatKhauMoi.Text.Length < 7)
            {
                MessageBox.Show("Password phải lớn hơn 8 ký tự trở lên, vui lòng thử lại...", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauMoi.Focus();
                return;
            }
            else if (txtXacNhanMK.Text.Length < 7)
            {
                MessageBox.Show("Password phải lớn hơn 8 ký tự trở lên, vui lòng thử lại...", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtXacNhanMK.Focus();
                return;
            }
            else
            {
                if (txtMatKhauMoi.Text != txtXacNhanMK.Text)
                {
                    MessageBox.Show("Mật khẩu khôi phục mới không trùng khớp, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (nvBUS.QuenMatKhau(UserName, UserMail, txtMatKhauMoi.Text))
                {
                    MessageBox.Show("Đổi mật khẩu thành công, xin mời đăng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frmDangNhap frm = new frmDangNhap();
                    frm.ShowDialog();

                }
                else
                {
                   MessageBox.Show("Tài khoản không tồn tại/ Email không hợp lê!, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }         
        }

        private void controlExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap frm = new frmDangNhap();
            frm.ShowDialog();
            this.Dispose();
        }
    }
}
