using GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QLCuaHangBanGiay.DataTier;
using QLCuaHangBanGiay.DataTier.Models;
using static Guna.UI2.Native.WinApi;
using System.Runtime.Remoting.Contexts;

namespace QLCuaHangBanGiay.UserControls
{
    public partial class frmNhanVien : UserControl
    {
        private NhanVienBUS nhanVienBUS; 

        public frmNhanVien()
        {
            InitializeComponent();
            nhanVienBUS = new NhanVienBUS();
        }
        private void LoadNhanVien()
        {
            dgvNhanVien.DataSource = nhanVienBUS.GetNhanViens();
            lbNV.Text = "Nhân viên: " + nhanVienBUS.GetSL().ToString();
            cmbLoaiNV.Text = null;
        }
        private void frmEmloyees_Load(object sender, EventArgs e)
        {
            LoadNhanVien(); 
        }
        private void clear()
        {
            txtMaNV.Text = "";
            txtTenNV.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            txtChucVu.Clear();
            txtLuongCB.Clear();
            txtNamSinh.Clear();
            cmbLoaiNV.Text = null;
            picAnhNV.Image = null;
        }
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
        private void txtTenNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Tên nhân viên không được chứa số và ký tự đặc biệt!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập đúng số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNamSinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập đúng năm sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        string SetMaNV(string chucVu)
        {
            string digit = "NV";
            string digit2 = "QL";
            string id = "";
            int count;
            if (chucVu == "Quản Lý")
            {
                count = nhanVienBUS.GetSLQL();
                if (count > 0)
                {
                    var str = nhanVienBUS.GetNhanViens().Where(x => x.MaNV.Contains("QL")).OrderByDescending(a => a.MaNV.Contains("QL")).Select(a => a.MaNV).Last();
                    string digits = new string(str.Where(char.IsDigit).ToArray());
                    string letters = new string(str.Where(char.IsLetter).ToArray());
                    int numbers;
                    if (int.TryParse(digits, out numbers))
                    {
                        id += letters + (++numbers).ToString("D3");
                    }
                    return id;
                }
                else return digit2 + "001";
            }
            else
            {
                count = nhanVienBUS.GetSLNV();
                if (count > 0)
                {
                    var str = nhanVienBUS.GetNhanViens().Where(x => x.MaNV.Contains("NV")).OrderByDescending(a => a.MaNV.Contains("NV")).Select(a => a.MaNV).Last();
                    string digits = new string(str.Where(char.IsDigit).ToArray());
                    string letters = new string(str.Where(char.IsLetter).ToArray());
                    int numbers;
                    if (int.TryParse(digits, out numbers))
                    {
                        id += letters + (++numbers).ToString("D3");
                    }
                    return id;
                }
                else return digit + "001";
            }
        }
       
        private void picAnhNV_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.png)| *.png| jpg files (*.jpg)| *.jpg| All files(*.*)| *.*", Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)

                    picAnhNV.Image = Image.FromFile(ofd.FileName);
            }
        }
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clear();
            if (e.RowIndex < 0)
                return;
            DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
            txtMaNV.Text = row.Cells[1].Value.ToString();
            txtTenNV.Text = row.Cells[2].Value.ToString();
            cmbLoaiNV.Text = row.Cells[3].Value.ToString();
            txtTaiKhoan.Text = row.Cells[4].Value.ToString();
            txtNamSinh.Text = row.Cells[5].Value.ToString();
            txtDiaChi.Text = row.Cells[6].Value.ToString();
            txtEmail.Text = row.Cells[7].Value.ToString();
            txtSDT.Text = row.Cells[8].Value.ToString();
            txtChucVu.Text = row.Cells[9].Value.ToString();
            txtLuongCB.Text = row.Cells[10].Value.ToString();
            NhanVien nv = nhanVienBUS.layNV().Where(x => x.MaNV == txtMaNV.Text).FirstOrDefault();
            picAnhNV.Image = convertByteArrayToImage((byte[])nv.AnhNV);
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = nhanVienBUS.Find(txtFindNV.Text);
        }
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string temp = "";
            if (cmbSort.Text == "Quản Lý")
                temp = "QL";
            else temp = "NV";
            dgvNhanVien.DataSource = nhanVienBUS.GetNhanVienTheoLoai(temp);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenNV.Text))
            {
                MessageBox.Show("Tên nhân viên không được để trống, Xin vui lòng nhập đầy đủ tên nhân viên", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(cmbLoaiNV.Text))
            {
                MessageBox.Show("Loại nhân viên không được để trống, Xin vui lòng chọn loại nhân viên", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                MessageBox.Show("Tài khoản đăng nhập không được để trống, Xin vui lòng nhập lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtTaiKhoan.TextLength < 5)
            {
                MessageBox.Show("Tài khoản đăng nhập phải từ 5 ký tự trở lên, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu nhân viên hiện đang trống, Xin vui lòng thử lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtMatKhau.TextLength < 8)
            {
                MessageBox.Show("Mật khẩu nhân viên phải từ 8 ký tự trở lên, Xin vui lòng thử lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Email hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtSDT.TextLength < 10)
            {
                MessageBox.Show("Số điện thoại phải từ 10 số trở lên, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtChucVu.Text))
            {
                MessageBox.Show("Chức vụ hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK);
            }
            else if (string.IsNullOrEmpty(txtLuongCB.Text))
            {
                MessageBox.Show("Lương cơ bản hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK);
            }
            else if (string.IsNullOrEmpty(txtNamSinh.Text))
            {
                MessageBox.Show("Năm sinh hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK);
            }
            else if (picAnhNV.Image == null)
            {
                MessageBox.Show("Ảnh nhân viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                NhanVien nv = new NhanVien();
                nv.TenNV = txtTenNV.Text;
                nv.LoaiNhanVien = cmbLoaiNV.Text;
                nv.UserName = txtTaiKhoan.Text;
                nv.PassWord = txtMatKhau.Text;
                nv.NamSinh = Convert.ToInt32(txtNamSinh.Text);
                nv.Email = txtEmail.Text;
                nv.SDT = txtSDT.Text;
                nv.DiaChi = txtDiaChi.Text;
                nv.Email = txtEmail.Text;
                nv.ChucVu = txtChucVu.Text;
                nv.LuongCB = Convert.ToInt32(txtLuongCB.Text);
                nv.Email = txtEmail.Text;
                nv.AnhNV = convertImgToByte(picAnhNV.Image);
                nv.MaNV = SetMaNV(nv.ChucVu);               
                try
                {
                    if (nhanVienBUS.ThemNhanVien(nv))
                    {
                        MessageBox.Show("Thêm nhân viên " + nv.MaNV + " thành công!", "Thông báo");
                        LoadNhanVien();
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Mã nhân viên " + nv.MaNV + " đã tồn tại!", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo");
                }

            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Mời bạn nhập mã nhân viên hoặc chọn nhân viên cần xóa", "Thông báo");
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa nhân viên " + txtMaNV.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (nhanVienBUS.XoaNhanVien(txtMaNV.Text))
                    {
                        MessageBox.Show("Xóa nhân viên " + txtMaNV.Text + " thành công!", "Thông báo");
                        LoadNhanVien();
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Mã nhân viên " + txtMaNV.Text + " không tồn tại!", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "" || txtTenNV.Text == "" || cmbLoaiNV.Text == ""
                     || txtTaiKhoan.Text == "" || txtNamSinh.Text == "" || txtEmail.Text == ""
                        || txtSDT.Text == "" || txtDiaChi.Text == "" || txtChucVu.Text == "" || txtLuongCB.Text == ""
                            || picAnhNV.Image == null)
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin của nhân viên", "Thông báo");
                return;
            }
            NhanVien nv = nhanVienBUS.layNV().FirstOrDefault(x => x.MaNV == txtMaNV.Text);
            nv.TenNV = txtTenNV.Text;
            nv.LoaiNhanVien = cmbLoaiNV.Text;
            nv.UserName = txtTaiKhoan.Text;
            if(txtMatKhau.Text != null && txtMatKhau.Text != "")
                nv.PassWord = txtMatKhau.Text;
            nv.NamSinh = Convert.ToInt32(txtNamSinh.Text);
            nv.SDT = txtSDT.Text;
            nv.DiaChi = txtDiaChi.Text;
            nv.Email = txtEmail.Text;
            nv.ChucVu = txtChucVu.Text;
            nv.LuongCB = Convert.ToInt32(txtLuongCB.Text);
            nv.AnhNV = convertImgToByte(picAnhNV.Image);
            try
            {
                if (nhanVienBUS.CapNhatNhanVien(nv))
                {
                    MessageBox.Show("Cập nhật nhân viên " + nv.MaNV + " thành công!", "Thông báo");
                    LoadNhanVien();
                }
                else
                {
                    MessageBox.Show("Mã nhân viên " + nv.MaNV + " không tồn tại!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clear();
            LoadNhanVien();
        }

    }
}
