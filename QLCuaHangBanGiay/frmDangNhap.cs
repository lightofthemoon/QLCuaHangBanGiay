using QLCuaHangBanGiay;
using QLCuaHangBanGiay.DataTier;
using QLCuaHangBanGiay.DataTier.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDangNhap : Form
    {
        private NhanVienBUS nhanVienBUS;
        public frmDangNhap()
        {
            InitializeComponent();
            nhanVienBUS = new NhanVienBUS();
        }
      
        private void txtPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Username không được để trống, vui nhập nhập lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtPassWord.Text))
            {
                MessageBox.Show("Password không được để trống, vui nhập nhập lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                NhanVien temp = nhanVienBUS.layNV().FirstOrDefault(x => x.UserName == txtUserName.Text);
                if (temp != null)
                {
                    if (txtPassWord.Text == temp.PassWord)
                    {
                        frmManHinhChinh main = new frmManHinhChinh(txtUserName.Text);
                        Hide();
                        main.ShowDialog();
                        this.Dispose();
                    }
                    else MessageBox.Show("Mật khẩu bạn nhập không đúng vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập không tồn tại, vui lòng kiểm tra lại", "Thông báo");
                }
                
            }
        }

        private void lblForgotPass_Click(object sender, EventArgs e)
        {
            //Hide();
            //frmKhoiPhucMatKhau rec = new frmKhoiPhucMatKhau();
            //rec.ShowDialog();
            //Dispose();

            Hide();
            frmXacNhanOTP frm = new frmXacNhanOTP();
            frm.ShowDialog();
            Dispose();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
