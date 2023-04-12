using GUI;
using QLCuaHangBanGiay.DataTier;
using QLCuaHangBanGiay.DataTier.Models;
using QLCuaHangBanGiay.ViewModels;
using ServiceStack.Script;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCuaHangBanGiay.UserControls
{
    public partial class frmMatKhau : UserControl
    {
        NhanVienBUS nhanVienBUS;
        private Image img;
        private string maNV;

        public Action<object, FormClosingEventArgs> FormClosing { get; private set; }

        public byte[] convertImgToByte(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public Image convertByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        public frmMatKhau(string id)
        {
            nhanVienBUS = new NhanVienBUS();
            var temp = nhanVienBUS.layNV().Where(x => x.MaNV == id).ToList();
            foreach (NhanVien nv in temp)
            {
                maNV = nv.MaNV;
                img = convertByteArrayToImage((byte[])nv.AnhNV);
            }
            InitializeComponent();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            picNV.Image = img;
        }

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOldPassword.Text))
            {
                MessageBox.Show("Mật khẩu cũ hiện đang trống, Xin vui lòng kiểm tra lại...", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtOldPassword.Text))
            {
                MessageBox.Show("Mật khẩu cũ hiện đang trống, Xin vui lòng kiểm tra lại...", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                MessageBox.Show("Mật khẩu mới hiện đang trống, Xin vui lòng kiểm tra lại...", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtNewPassword.TextLength < 8)
            {
                MessageBox.Show("Mật khẩu mới phải từ 8 kí tự trở lên, Xin vui lòng kiểm tra lại...", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtConfirmPass.Text))
            {
                MessageBox.Show("Mật khẩu xác nhận hiện đang trống, Xin vui lòng kiểm tra lại...", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtNewPassword.TextLength < 8)
            {
                MessageBox.Show("Xác nhận mật khẩu mới phải từ 8 kí tự trở lên, Xin vui lòng kiểm tra lại...", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (txtNewPassword.Text == txtConfirmPass.Text)
                {
                    try
                    {
                        if (nhanVienBUS.CapNhatPass(maNV, txtConfirmPass.Text))
                        {
                            MessageBox.Show("Đổi mật khẩu thành công, vui lòng đăng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(openLoginForm));
                            t.SetApartmentState(ApartmentState.STA);
                            this.FormClosing -= frmMain_FormClosing;
                            ((Form)this.TopLevelControl).Close();
                            t.Start();
                        }
                        else
                        {
                            MessageBox.Show("Bạn đã nhập sai mật khẩu", "Thông báo");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thông báo");
                    }

                }
                else
                {
                    if (txtNewPassword.Text != txtConfirmPass.Text)
                    {
                        MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không trùng khớp. Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            } 

        }

        private void openLoginForm()
        {
            Application.Run(new frmDangNhap());
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Vui lòng đăng nhập lại", "Thông báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}
