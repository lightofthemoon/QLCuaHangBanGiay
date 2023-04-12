using QLCuaHangBanGiay.DataTier;
using QLCuaHangBanGiay.DataTier.Models;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QLCuaHangBanGiay.UserControls
{
    public partial class frmChiTietPhieuNhap : Form
    {
        ChiTietPhieuNhapHang ct;
        NhaCungCapBUS cungcapBUS;
        SanPhamBUS spBUS;
        public frmChiTietPhieuNhap(ChiTietPhieuNhapHang chiTiet)
        {
            InitializeComponent();
            ct = chiTiet;
            cungcapBUS = new NhaCungCapBUS();
            spBUS = new SanPhamBUS();
        }
        private void frmChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            cmbMaNCC.DataSource = cungcapBUS.GetNhaCungCap();
            cmbMaNCC.ValueMember = "MaNCC";
            cmbMaNCC.DisplayMember = "MaNCC";
            cmbMaSP.DataSource = spBUS.GetData();
            cmbMaSP.ValueMember = "MaSP";
            cmbMaSP.DisplayMember = "MaSP";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbMaNCC.Text))
            {
                MessageBox.Show("Mã nhà cung cấp không được để trống, Xin vui lòng kiểm tra lại...", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(cmbMaSP.Text))
            {
                MessageBox.Show("Mã sản phẩm không được để trống, Xin vui lòng kiểm tra lại...", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Số lượng sản phẩm hiện đang trống, Xin vui lòng kiểm tra lại...", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtSize.Text))
            {
                MessageBox.Show("Size sản phẩm hiện đang trống, Xin vui lòng kiểm tra lại...", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ct.MaNCC = cmbMaNCC.Text;
                ct.MaSP = cmbMaSP.Text;
                ct.SL = int.Parse(txtSoLuong.Text);
                ct.Gia = int.Parse(txtGia.Text);
                ct.Size = txtSize.Text;
                ct.MoTa = txtMoTa.Text;
                this.Close();
            }
        }
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Số lượng chỉ được được phép chứa số, không chứa ký tự chữ và ký tự đặc biệt. Xin vui lòng kiểm tra lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Giá sản phẩm chỉ được phép chứa số, không chứa các ký tự chữ và ký tự đặc biệt. Xin vui lòng kiểm tra lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void controlExit_Click(object sender, EventArgs e)
        {
            if (cmbMaNCC.Text == "" || cmbMaSP.Text == "" || txtSoLuong.Text == "" || txtSize.Text == "")
            {
                MessageBox.Show("Hủy nhập chi thiết phiếu thành công, phiếu sẽ được xóa", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(cmbMaNCC.Text))
            {
                MessageBox.Show("Mã nhà cung cấp không được để trống, Xin vui lòng kiểm tra lại...", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(cmbMaSP.Text))
            {
                MessageBox.Show("Mã sản phẩm không được để trống, Xin vui lòng kiểm tra lại...", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Số lượng sản phẩm hiện đang trống, Xin vui lòng kiểm tra lại...", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtSize.Text))
            {
                MessageBox.Show("Size sản phẩm hiện đang trống, Xin vui lòng kiểm tra lại...", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
