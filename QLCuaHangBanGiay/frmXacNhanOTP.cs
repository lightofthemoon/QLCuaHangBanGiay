using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI;
using QLCuaHangBanGiay.DataTier;
using QLCuaHangBanGiay.DataTier.Models;
using System.CodeDom.Compiler;

namespace QLCuaHangBanGiay
{
    public partial class frmXacNhanOTP : Form
    {
        NhanVienBUS nvBUS;
        String randomCode;
        public static String to;
        public frmXacNhanOTP()
        {
            InitializeComponent();
            nvBUS = new NhanVienBUS();
            txtOTP.Enabled = false;
        }

        private void btnSendOTP_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông tin");
                return;
            }
            String from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (txtEmail.Text).ToString();
            from = "nguyentrongquy612@gmail.com";
            pass = "lhfxhqggiwpxhqat";
            messageBody = "Mã OTP của bạn là: " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Mã OTP khôi phục mật khẩu";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            NhanVien nv = nvBUS.layNV().Where(x => x.UserName == txtUserName.Text).FirstOrDefault();
            if(nv == null)
            {
                MessageBox.Show("Tên đăng nhập không tồn tại", "Thông báo");
                return;
            }
            if (!nvBUS.QuenMatKhau(txtUserName.Text, txtEmail.Text))
            {
                MessageBox.Show("Tên đăng nhậ và email không đồng nhất, vui lòng kiểm tra lại", "Thông báo");
                return;
            }
            try
            {
                smtp.Send(message);
                MessageBox.Show("Đã gửi mã OTP thành công. Vui lòng kiểm tra Email...", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOTP.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void controlExit_Click(object sender, EventArgs e)
        {
            Hide();
            frmDangNhap frmDangnhap = new frmDangNhap();
            frmDangnhap.ShowDialog();
            Dispose();
        }

        private void txtOTP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Mã OTP chỉ bao gồm số, không bao gồm các ký tự chữ. Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Username không được để trống, vui nhập nhập lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Bạn chưa nhập Email khôi phục, Xin vui lòng kiểm tra lại...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(txtOTP.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã OTP, Xin vui lòng kiểm tra lại...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (randomCode == (txtOTP.Text).ToString())
                {
                    to = txtEmail.Text;
                    Hide();
                    frmKhoiPhucMatKhau rp = new frmKhoiPhucMatKhau(txtUserName.Text, txtEmail.Text);
                    //this.Hide();
                    rp.ShowDialog();
                    rp.Dispose();
                }
                else
                {
                    MessageBox.Show("Mã OTP sai, vui lòng kiểm tra lại","Thông báo");
                }
            }
        }
    }
}
