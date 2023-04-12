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
    public partial class frmSanPham : UserControl
    {
        private SanPhamBUS spBUS;
        private DanhMucBUS danhMucBUS;
        private NhanHieuBUS nhanHieuBUS;
        public frmSanPham()
        {
            spBUS = new SanPhamBUS();
            danhMucBUS = new DanhMucBUS();
            nhanHieuBUS = new NhanHieuBUS();
            InitializeComponent();
        }
        private void LoadSP()
        {
            dgvSanPham.DataSource = spBUS.GetSanPham();
            lbSL.Text = "Sản phẩm: " + spBUS.GetSL().ToString();
            cmbDM.DataSource = danhMucBUS.GetDanhMuc();
            cmbNH.DataSource = nhanHieuBUS.GetNhanHieu();
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            cmbDM.ValueMember = "MaDanhMuc";
            cmbDM.DisplayMember = "TenDanhMuc";
            cmbNH.ValueMember = "MaNhanHieu";
            cmbNH.DisplayMember = "TenNhanHieu";
            LoadSP();
        }
        private void clear()
        {
            txtMaSP.Text = "";
            cmbDM.SelectedIndex = 0;
            cmbNH.SelectedIndex = 0;
            txtTenSP.Clear();
            txtMoTa.Clear();
            picSP.Image = null;
            txtSL.Clear();
            txtDonGia.Clear();
            picSP.Image = null;
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

                    picSP.Image = Image.FromFile(ofd.FileName);
            }
        }
        string SetMaSP()
        {
            string digit = "SP";
            string id = "";
            var count = spBUS.GetSL();
            if (count > 0)
            {
                var str = spBUS.GetSanPham().OrderByDescending(a => a.MaSP).Select(a => a.MaSP).First();
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

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clear();
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
            txtMaSP.Text = row.Cells[0].Value.ToString();
            cmbDM.SelectedValue = row.Cells[1].Value.ToString();
            cmbNH.SelectedValue = row.Cells[2].Value.ToString();
            txtTenSP.Text = row.Cells[3].Value.ToString();
            txtMoTa.Text = row.Cells[4].Value.ToString();
            txtSL.Text = row.Cells[5].Value.ToString();
            txtDonGia.Text = row.Cells[6].Value.ToString();
            SanPham sp = spBUS.GetSanPhamData().Where(x => x.MaSP == txtMaSP.Text).FirstOrDefault();
            picSP.Image = convertByteArrayToImage((byte[])sp.AnhSP);
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenSP.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống, Xin vui lòng nhập lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(cmbDM.Text))
            {
                MessageBox.Show("Danh mục sản phẩm không được để trống, Xin vui lòng nhập lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtSL.Text))
            {
                MessageBox.Show("Số lượng phẩm không được trống, Xin vui lòng nhập lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(cmbNH.Text))
            {
                MessageBox.Show("Nhãn hiệu sản phẩm không được trống, Xin vui lòng nhập lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show("Đơn giá sản phẩm không được trống, Xin vui lòng nhập lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtMoTa.Text))
            {
                MessageBox.Show("Mô tả không được trống, Xin vui lòng nhập lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (picSP.Image == null)
            {
                MessageBox.Show("Ảnh sản phẩm không được trống, Xin vui lòng nhập lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SanPham sp = new SanPham();
                sp.MaSP = SetMaSP();
                sp.MaDanhMuc = cmbDM.SelectedValue.ToString();
                sp.MaNhanHieu = cmbNH.SelectedValue.ToString();
                sp.TenSP = txtTenSP.Text;
                sp.MoTa = txtMoTa.Text;
                sp.SLTonKho = Convert.ToInt32(txtSL.Text);
                sp.AnhSP = convertImgToByte(picSP.Image);
                sp.DonGia = Convert.ToInt32(txtDonGia.Text);
                if (spBUS.ThemSanPham(sp))
                {
                    MessageBox.Show("Thêm sản phẩm " + sp.MaSP + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSP();
                    clear();
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm " + sp.MaSP + " đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtMaSP.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm muốn xóa", "Thông báo");
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa sản phẩm " + txtMaSP.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (spBUS.XoaSanPham(txtMaSP.Text))
                    {
                        MessageBox.Show("Xóa sản phẩm " + txtMaSP.Text + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSP();
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Mã sản phẩm " + txtMaSP.Text + " không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm muốn sửa", "Thông báo");
                return;
            }
            SanPham sp = new SanPham();
            sp.MaSP = txtMaSP.Text;
            sp.MaDanhMuc = cmbDM.SelectedValue.ToString();
            sp.MaNhanHieu = cmbNH.SelectedValue.ToString();
            sp.TenSP = txtTenSP.Text;
            sp.MoTa = txtMoTa.Text;
            sp.SLTonKho = Convert.ToInt32(txtSL.Text);
            sp.AnhSP = convertImgToByte(picSP.Image);
            sp.DonGia = Convert.ToInt32(txtDonGia.Text);
            try
            {
                if (spBUS.CapNhatSanPham(sp))
                {
                    MessageBox.Show("Cập nhật mã sản phẩm " + sp.MaSP + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSP();
                    clear();
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm " + sp.MaSP + " không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtFindSP_TextChanged(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = spBUS.Find(txtFindSP.Text);
        }
    }
}
