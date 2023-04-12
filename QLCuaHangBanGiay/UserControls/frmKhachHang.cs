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
    public partial class frmKhachHang : UserControl
    {
        KhachHangBUS khachHangBUS;
        LoaiKHBUS loaiKHBUS;
        public frmKhachHang()
        {
            InitializeComponent();
            khachHangBUS = new KhachHangBUS();
            loaiKHBUS = new LoaiKHBUS();
        }
        private void clearKH()
        {
            txtMaKH.Text = "";
            txtLoaiKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text ="";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiemTichLuy.Text = "";
        }
        private void clearLoaiKH()
        {
            txtMaLoaiKH1.Text = "";
            txtTenLoaiKH.Text = "";
            txtTichLuy.Text = "";
        }
        private void loadKH()
        {
            dgvKH.DataSource = khachHangBUS.GetKhachHang();
        }
        private void loadLoaiKH()
        {
            dgvLoaiKH.DataSource = loaiKHBUS.GetData();
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            loadKH();
            loadLoaiKH();
        }
        string SetMaLoaiKH()
        {
            string digit = "LKH";
            string id = "";
            var count = loaiKHBUS.GetSL();
            if (count > 0)
            {
                var str = loaiKHBUS.GetLoaiKH().OrderByDescending(a => a.MaLoaiKH).Select(a => a.MaLoaiKH).Last();
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
        string SetMaKH()
        {
            string digit = "KH";
            string id = "";
            var count = khachHangBUS.GetSL();
            if (count > 0)
            {
                var str = khachHangBUS.GetKhachHang().OrderByDescending(a => a.MaKH).Select(a => a.MaKH).Last();
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
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Số điện thoại phải là chứa số và không chứa kí tự đặc biệt !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void txtTichLuy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Điểm tích luỹ phải là số và không chứa kí tự đặc biệt !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dgvLoaiKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clearLoaiKH();
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvLoaiKH.Rows[e.RowIndex];
            txtMaLoaiKH1.Text = row.Cells[0].Value.ToString();
            txtTenLoaiKH.Text = row.Cells[1].Value.ToString();
            txtTichLuy.Text = row.Cells[2].Value.ToString();
        }
        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            KhachHang temp = khachHangBUS.GetKhachHangData().Where(x => x.MaKH == dgvKH.Rows[e.RowIndex].Cells[0].Value.ToString()).FirstOrDefault();
            txtMaKH.Text = temp.MaKH;
            txtTenKH.Text = temp.TenKH;
            LoaiKH loai = loaiKHBUS.GetLoaiKH().Where(x => x.MaLoaiKH == temp.MaLoaiKH).FirstOrDefault();
            txtLoaiKH.Text = loai.TenLoaiKH;
            txtEmail.Text = temp.Email;
            txtDiaChi.Text = temp.DiaChi;
            txtSDT.Text = temp.SDT;
            txtDiemTichLuy.Text = temp.DiemTichLuy.ToString();
        }
        private void btnAddLoaiKH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenLoaiKH.Text))
            {
                MessageBox.Show("Tên khách hàng hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtTichLuy.Text))
            {
                MessageBox.Show("Điểm tích luỹ hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Int32.Parse(txtTichLuy.Text) < 0)
            {
                MessageBox.Show("Điểm tích luỹ không được nhập nhỏ hơn hoặc bằng 0, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtTichLuy.TextLength >= 9)
            {
                MessageBox.Show("Điểm tích luỹ không không được lớn hơn 9 chữ số, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LoaiKH temp = new LoaiKH();
                temp.MaLoaiKH = SetMaLoaiKH();
                temp.TenLoaiKH = txtTenLoaiKH.Text;
                temp.SoDiemTichLuyToiThieu = Convert.ToInt32(txtTichLuy.Text);
                try
                {
                    if (loaiKHBUS.ThemLoaiKH(temp))
                    {
                        MessageBox.Show("Thêm loại khách hàng " + temp.MaLoaiKH + " thành công", "Thông báo");
                        loadLoaiKH();
                        clearLoaiKH();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo!"); }
            }
        }
        private void btnDeleteLoaiKH_Click(object sender, EventArgs e)
        {
            if(txtMaLoaiKH1.Text == "")
            {
                MessageBox.Show("Vui lòng chọn loại khách hàng cần xóa", "Thông báo");
                return;
            }
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa loại khách hàng " + txtMaLoaiKH1.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (loaiKHBUS.XoaLoaiKH(txtMaLoaiKH1.Text))
                    {
                        MessageBox.Show("Xóa loại khách hàng " + txtMaLoaiKH1.Text + " thành công!", "Thông báo");
                        loadLoaiKH();
                        clearLoaiKH();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo!"); }
        }

        private void btnEditLoaiKH_Click(object sender, EventArgs e)
        {
            if(txtMaLoaiKH1.Text == "")
            {
                MessageBox.Show("Vui lòng chọn loại khách hàng cần sửa", "Thông báo");
                return;
            }
            LoaiKH temp = new LoaiKH();
            temp.MaLoaiKH = txtMaLoaiKH1.Text;
            temp.TenLoaiKH = txtTenLoaiKH.Text;
            temp.SoDiemTichLuyToiThieu = Convert.ToInt32(txtTichLuy.Text);
            try
            {
                if (loaiKHBUS.CapNhatLoaiKH(temp))
                {
                    MessageBox.Show("Cập nhật khách hàng " + txtMaLoaiKH1.Text + " thành công!", "Thông báo");
                    loadLoaiKH();
                    clearLoaiKH();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo!"); }
        }

        private void btnRefreshLoaiKH_Click(object sender, EventArgs e)
        {
            clearLoaiKH();
        }
        private string checkPoint(int? point)
        {
            var temp = loaiKHBUS.GetLoaiKH().Where(x => x.SoDiemTichLuyToiThieu <= point).Last();
            return temp.MaLoaiKH;
        }
        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        private void btnAddKH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenKH.Text))
            {
                MessageBox.Show("Tên khách hàng hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại khách hàng hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtDiemTichLuy.Text))
            {
                MessageBox.Show("Điểm tích luỹ hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Int32.Parse(txtDiemTichLuy.Text) <= 0)
            {
                MessageBox.Show("Điểm tích luỹ không được nhập nhỏ hơn hoặc bằng 0, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtDiemTichLuy.TextLength > 9)
            {
                MessageBox.Show("Điểm tích luỹ không không được lớn hơn 9 chữ số, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                KhachHang temp = new KhachHang();
                temp.MaKH = SetMaKH();
                temp.TenKH = txtTenKH.Text;
                temp.SDT = txtSDT.Text;
                temp.DiaChi = txtDiaChi.Text;
                if (IsValidEmail(txtEmail.Text))
                    temp.Email = txtEmail.Text;
                else
                {
                    MessageBox.Show("Email không tồn tại", "Thông báo");
                    return;
                }
                temp.DiemTichLuy = Convert.ToInt32(txtDiemTichLuy.Text);
                LoaiKH loai = loaiKHBUS.GetLoaiKH().Last(x => x.SoDiemTichLuyToiThieu < temp.DiemTichLuy);
                temp.MaLoaiKH = loai.MaLoaiKH;
                KhachHang kh = khachHangBUS.GetKhachHangData().Where(x => x.SDT == temp.SDT).FirstOrDefault();
                if(kh != null)
                {
                    MessageBox.Show("Khách hàng đã tồn tại", "Thông báo");
                    clearKH();
                    return;
                }
                try
                {
                    if (khachHangBUS.ThemKH(temp))
                    {
                        MessageBox.Show("Thêm khách hàng mới thành công!", "Thông báo");
                        loadKH();
                        clearKH();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo!"); }
            }
        }
        private void btnDeleteKH_Click(object sender, EventArgs e)
        {
            if(txtMaKH.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa", "Thông báo");
                return;
            }
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa khách hàng " + txtMaKH.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (khachHangBUS.XoaKH(txtMaKH.Text))
                    {
                        MessageBox.Show("Xóa khách hàng " + txtMaKH.Text + " thành công!", "Thông báo");
                        loadKH();
                        clearKH();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo!"); }
        }
        private void btnEditKH_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa", "Thông báo");
                return;
            }
            KhachHang temp = new KhachHang();
            temp.MaKH = txtMaKH.Text;
            temp.TenKH = txtTenKH.Text;
            temp.SDT = txtSDT.Text;
            temp.DiaChi = txtDiaChi.Text;
            if(IsValidEmail(txtEmail.Text))
                temp.Email = txtEmail.Text;
            else
            {
                MessageBox.Show("Email không hợp lệ", "Thông báo");
                return;
            }
            temp.DiemTichLuy = Convert.ToInt32(txtDiemTichLuy.Text);
            temp.MaLoaiKH = checkPoint(temp.DiemTichLuy);
            try
            {
                if (khachHangBUS.CapNhatKH(temp))
                {
                    MessageBox.Show("Cập nhật khách hàng " + txtMaKH.Text + " thành công!", "Thông báo");
                    loadKH();
                    clearKH();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo!"); }
        }
        private void btnRefreshKH_Click(object sender, EventArgs e)
        {
            clearKH();
        }
        private void txtTenLoaiKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Tên khách chỉ bao gồm chữ và số, không bao gồm các ký tự đặc biệt. Vui lòng kiểm tra lại...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtDiemTichLuy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Điểm tích luỹ phải là số và không chứa kí tự đặc biệt, Xin vui lòng kiểm tra lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtFindLoaiKH_TextChanged(object sender, EventArgs e)
        {
            dgvLoaiKH.DataSource = loaiKHBUS.Find(txtFindLoaiKH.Text);
        }

        private void txtFindKH_TextChanged(object sender, EventArgs e)
        {
            dgvKH.DataSource = khachHangBUS.Find(txtFindKH.Text);
        }
    }
}
