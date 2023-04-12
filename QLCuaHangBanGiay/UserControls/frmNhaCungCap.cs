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

namespace QLCuaHangBanGiay.UserControls
{
    public partial class frmNhaCungCap : UserControl
    {
        NhaCungCapBUS nccBUS;
        public frmNhaCungCap()
        {
            InitializeComponent();
            nccBUS = new NhaCungCapBUS();
        }
        private void LoadNCC()
        {
            dgvNCC.DataSource = nccBUS.GetNhaCungCap();
            lbNCC.Text = "Nhà cung cấp: " + nccBUS.GetSL().ToString();
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadNCC();
        }
        private void clear()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtSoTK.Text = "";
            txtTenNH.Text = "";
            txtEmail.Text = "";
        }
        string SetMaNCC()
        {
            string digit = "NCC";
            string id = "";
            var count = nccBUS.GetSL();
            if (count > 0)
            {
                var str = nccBUS.GetNhaCungCap().OrderByDescending(a => a.MaNCC).Select(a => a.MaNCC).First();
                string digits = new string(str.Where(char.IsDigit).ToArray());
                string letters = new string(str.Where(char.IsLetter).ToArray());
                int numbers;
                if (int.TryParse(digits, out numbers))
                {
                    id += letters + (++numbers).ToString("D4");
                }
                return id;
            }
            else
                return digit + "0001";
        }
        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clear();
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvNCC.Rows[e.RowIndex];
            txtMaNCC.Text = row.Cells[0].Value.ToString();
            txtTenNCC.Text = row.Cells[1].Value.ToString();
            txtDiaChi.Text = row.Cells[2].Value.ToString();
            txtSoTK.Text = row.Cells[3].Value.ToString();
            txtTenNH.Text = row.Cells[4].Value.ToString();
            txtSDT.Text = row.Cells[5].Value.ToString();
            txtEmail.Text = row.Cells[6].Value.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenNCC.Text))
            {
                MessageBox.Show("Tên nhà cung cấp hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại nhà cung cấp hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtSDT.TextLength != 10)
            {
                MessageBox.Show("Số điện thoại nhà cung cấp phải từ 10 số trở lên, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ nhà cung cấp hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtSoTK.Text))
            {
                MessageBox.Show("Số tài khoản nhà cung cấp hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Email nhà cung cấp hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtTenNH.Text))
            {
                MessageBox.Show("Tên ngân hàng nhà cung cấp hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                NhaCungCap ncc = new NhaCungCap();
                ncc.MaNCC = SetMaNCC();
                ncc.SDT = txtSDT.Text;
                ncc.TenNCC = txtTenNCC.Text;
                ncc.DiaChi = txtDiaChi.Text;
                ncc.Email = txtEmail.Text;
                ncc.SoTaiKhoan = txtSoTK.Text;
                ncc.TenNH = txtTenNH.Text;
                try
                {
                    if (nccBUS.ThemNhaCungCap(ncc))
                    {
                        MessageBox.Show("Thêm nhà cung cấp " + ncc.MaNCC + " thành công!", "Thông báo");
                        LoadNCC();
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Mã nhà cung cấp " + ncc.MaNCC + " đã tồn tại!", "Thông báo");
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
            NhaCungCap ncc = new NhaCungCap();
            ncc.MaNCC = txtMaNCC.Text;
            ncc.SDT = txtSDT.Text;
            ncc.TenNCC = txtTenNCC.Text;
            ncc.DiaChi = txtDiaChi.Text;
            ncc.Email = txtEmail.Text;
            ncc.SoTaiKhoan = txtSoTK.Text;
            ncc.TenNH = txtTenNH.Text;
            try
            {
                if (nccBUS.CapNhatNhaCungCap(ncc))
                {
                    MessageBox.Show("Cập nhật nhà cung cấp " + ncc.MaNCC + " thành công!", "Thông báo");
                    LoadNCC();
                    clear();
                }
                else
                {
                    MessageBox.Show("Mã nhà cung cấp " + ncc.MaNCC + " không tồn tại!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtMaNCC.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa", "Thông báo");
                return;
            }
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa nhà cung cấp " + txtMaNCC.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (nccBUS.XoaNhaCungCap(txtMaNCC.Text))
                    {
                        MessageBox.Show("Xóa nhà cung cấp " + txtMaNCC.Text + " thành công!", "Thông báo");
                        LoadNCC();
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Mã nhà cung cấp " + txtMaNCC.Text + " không tồn tại!", "Thông báo");
                    }
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
        }
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Số điện thoại không được chứa ký tự chữ, ký tự đặc biệt. Vui lòng kiểm tra lại...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void txtSoTK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Điểm tích luỹ phải là số và không chứa kí tự đặc biệt, Xin vui lòng kiểm tra lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void txtFindNhaCC_TextChanged(object sender, EventArgs e)
        {
            dgvNCC.DataSource = nccBUS.Find(txtFindNhaCC.Text);
        }
    }
}
