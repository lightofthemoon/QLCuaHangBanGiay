using QLCuaHangBanGiay.DataTier;
using QLCuaHangBanGiay.DataTier.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCuaHangBanGiay.UserControls
{
    public partial class frmDMNhanHieu : UserControl
    {
        NhanHieuBUS nhanHieuBUS;
        DanhMucBUS danhMucBUS;
        public frmDMNhanHieu()
        {
            InitializeComponent();
            nhanHieuBUS = new NhanHieuBUS();
            danhMucBUS = new DanhMucBUS();
            lblDM.Text = "Danh mục: " + danhMucBUS.GetSL();
            lblNH.Text = "Nhãn hiệu: " + nhanHieuBUS.GetSL();
        }
        private void LoadNhanHieu()
        {
            dgvNH.DataSource = nhanHieuBUS.GetNhanHieu();
            dgvDanhMuc.DataSource = danhMucBUS.GetDanhMuc();
        }
        private void clear()
        {
            txtMaNH.Text = "";
            txtTenNH.Clear();
            txtXuatXu.Clear();
          
            txtMaDanhMuc.Text = "";
            txtTenDanhMuc.Clear();
            picNH.Image = null;
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
        private void picSP_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.png)| *.png| jpg files (*.jpg)| *.jpg| All files(*.*)| *.*", Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                    picNH.Image = Image.FromFile(ofd.FileName);
            }
        }
        private void txtMaDanhMuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Danh mục phải theo quy chuẩn DM**!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void txtMaNH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Nhãn hiệu phải theo quy chuẩn NH**!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        string SetMaDM()
        {
            string digit = "DM";
            string id = "";
            var count = danhMucBUS.GetSL();
            if (count > 0)
            {
                var str = danhMucBUS.GetDanhMuc().OrderByDescending(a => a.MaDanhMuc).Select(a => a.MaDanhMuc).First();
                string digits = new string(str.Where(char.IsDigit).ToArray());
                string letters = new string(str.Where(char.IsLetter).ToArray());
                int numbers;
                if (int.TryParse(digits, out numbers))
                {
                    id += letters + (++numbers).ToString("D3");
                }
                return id;
            }
            else
                return digit + "001";
        }
        string SetMaNH()
        {
            string digit = "NH";
            string id = "";
            var count = nhanHieuBUS.GetSL();
            if (count > 0)
            {
                var str = nhanHieuBUS.GetNhanHieu().OrderByDescending(a => a.MaNhanHieu).Select(a => a.MaNhanHieu).First();
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
        private void dgvNH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clear();
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvNH.Rows[e.RowIndex];
            txtMaNH.Text = row.Cells[0].Value.ToString();
            txtTenNH.Text = row.Cells[1].Value.ToString();
            txtXuatXu.Text = row.Cells[2].Value.ToString();
            NhanHieu nh = nhanHieuBUS.GetNhanHieuData().Where(x => x.MaNhanHieu== txtMaNH.Text).FirstOrDefault();
            picNH.Image = convertByteArrayToImage((byte[])nh.AnhNH);
        }
        private void frmDMNhanHieu_Load(object sender, EventArgs e)
        {
            LoadNhanHieu();
        } 
        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            DataGridViewRow row = dgvDanhMuc.Rows[e.RowIndex];
            txtMaDanhMuc.Text = row.Cells[0].Value.ToString();
            txtTenDanhMuc.Text = row.Cells[1].Value.ToString();
        }
        private void btnAddDm_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtTenDanhMuc.Text))
            {
                MessageBox.Show("Mã danh mục hiện đang trống, Xin vui lòng thử lại", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                DanhMucSanPham temp = new DanhMucSanPham();
                temp.MaDanhMuc = SetMaDM();
                temp.TenDanhMuc = txtTenDanhMuc.Text;
                try
                {
                    if (danhMucBUS.ThemDanhMuc(temp))
                    {
                        MessageBox.Show("Thêm danh mục " + temp.MaDanhMuc + " thành công!", "Thông báo");
                        LoadNhanHieu();
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Danh mục " + temp.MaDanhMuc + " đã tồn tại!", "Thông báo");
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo"); }
            }
        }

        private void btnDeleteDM_Click(object sender, EventArgs e)
        {
            if(txtMaDanhMuc.Text == "")
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa", "Thông báo");
                return;
            }
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa danh mục " + txtMaDanhMuc.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (danhMucBUS.XoaDanhMuc(txtMaDanhMuc.Text))
                    {
                        MessageBox.Show("Xóa danh mục " + txtMaDanhMuc.Text + " thành công!", "Thông báo");
                        LoadNhanHieu();
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Danh mục không tồn tại!", "Notification");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo"); }
        }
        private void btnEditDM_Click(object sender, EventArgs e)
        {
            DanhMucSanPham temp = new DanhMucSanPham();
            temp.MaDanhMuc = txtMaDanhMuc.Text;
            temp.TenDanhMuc = txtTenDanhMuc.Text;
            try
            {
                if (danhMucBUS.CapNhatDanhMuc(temp))
                {
                    MessageBox.Show("Cập nhật danh mục " + temp.MaDanhMuc + " thành công!", "Notification");
                    LoadNhanHieu();
                    clear();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn danh mục cần cập nhật!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtXuatXu.Text))
            {
                MessageBox.Show("Xuất xứ hiện đang trống, Xin vui lòng thử lại", "Thông báo", MessageBoxButtons.OK);
            }
            else if (string.IsNullOrEmpty(txtTenNH.Text))
            {
                MessageBox.Show("Tên nhãn hiệu hiện đang trống, Xin vui lòng thử lại", "Thông báo", MessageBoxButtons.OK);
            }
            else if (picNH.Image == null)
            {
                MessageBox.Show("Ảnh sản phẩm hiện đang trống, Xin vui lòng thử lại", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                NhanHieu temp = new NhanHieu();
                temp.MaNhanHieu = SetMaNH();
                temp.TenNhanHieu = txtTenNH.Text;
                temp.XuatXu = txtXuatXu.Text;
                temp.AnhNH = convertImgToByte(picNH.Image);
                try
                {
                    if (nhanHieuBUS.ThemNhanHieu(temp))
                    {
                        MessageBox.Show("Thêm nhãn hiệu " + temp.MaNhanHieu + " thành công!", "Notification");
                        LoadNhanHieu();
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Nhãn hiệu " + temp.MaNhanHieu + " đã tồn tại", "Notification");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo!");
                }
            }   
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtMaNH.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhãn hiệu cần xóa", "Thông báo");
                return;
            }
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa nhãn hiệu " + txtTenNH.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (nhanHieuBUS.XoaNhanHieu(txtTenNH.Text))
                    {
                        MessageBox.Show("Xóa nhãn hiệu" + txtTenNH.Text + " thành công!", "Thông báo");
                        LoadNhanHieu();
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Nhãn hiệu " + txtMaNH.Text + " không tồn tại!", "Notification");
                        return;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo"); }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtMaNH.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhãn hiệu cần sửa", "Thông báo");
                return;
            }
            NhanHieu temp = new NhanHieu();
            temp.MaNhanHieu = txtMaNH.Text;
            temp.TenNhanHieu = txtTenNH.Text;
            temp.XuatXu = txtXuatXu.Text;
            temp.AnhNH = convertImgToByte(picNH.Image);
            try
            {
                if (nhanHieuBUS.CapNhatNhanHieu(temp))
                {
                    MessageBox.Show("Cập nhật nhãn hiệu " + txtMaNH.Text + " thành công!", "Notification");
                    LoadNhanHieu();
                    clear();
                }
                else
                {
                    MessageBox.Show("Nhãn hiệu " + txtMaNH.Text + " không tồn tại!", "Notification");
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
        private void btnRefreshDM_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void txtFindDanhMuc_TextChanged(object sender, EventArgs e)
        {
            dgvDanhMuc.DataSource = danhMucBUS.Find(txtFindDanhMuc.Text);
        }
        private void txtFindNhanHieu_TextChanged(object sender, EventArgs e)
        {
            dgvNH.DataSource = nhanHieuBUS.Find(txtFindNhanHieu.Text);
        }
    }
}
