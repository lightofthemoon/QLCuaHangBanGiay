using QLCuaHangBanGiay.DataTier;
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
    public partial class frmQLHoaDon : UserControl
    {
        HoaDonBUS hoaDonBUS;
        ChiTietHoaDonBUS chiTietHoaDonBUS;
        public frmQLHoaDon()
        {
            hoaDonBUS = new HoaDonBUS();
            chiTietHoaDonBUS = new ChiTietHoaDonBUS();
            InitializeComponent();
        }
        public void loadDGV()
        {
            dgvHD.DataSource = hoaDonBUS.GetHD();
        }
        private void frmQLHoaDon_Load(object sender, EventArgs e)
        {
            loadDGV();
            
        }
        private void clearHD()
        {
            txtMaHD.Text = "";
            txtMaKH.Text = "";
            txtMaNV.Text = "";
            txtMaHoaDon.Text = "";
            txtTenSP.Text = "";
            txtSL.Text = "";
            richMoTa.Text = "";
        }
        private void clearChiTiet()
        {
            txtMaHoaDon.Text = "";
            txtTenSP.Clear();
            txtSL.Clear();
            richMoTa.Clear();
        }
        private void dgvHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            DataGridViewRow row = dgvHD.Rows[e.RowIndex];
            txtMaHD.Text = row.Cells[0].Value.ToString();
            txtMaKH.Text = row.Cells[1].Value.ToString();
            txtMaNV.Text = row.Cells[2].Value.ToString();
            dateNgayTao.Text = row.Cells[3].Value.ToString();
        }
        private void btnDeleteChiTietHD_Click(object sender, EventArgs e)
        {
            if (hoaDonBUS.GetSL() == 0 || txtMaHoaDon.Text == "" || txtMaHD.Text == "")
            {
                MessageBox.Show("Không có hóa đơn để xóa", "Thông báo");
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa chi tiết hóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgvChiTietHD.Rows.Count != 0)
                {
                    try
                    {
                        if (chiTietHoaDonBUS.Xoa1ChiTietHoaDon(txtMaHoaDon.Text, txtTenSP.Text))
                        {
                            MessageBox.Show("Xóa chi tiết hóa đơn thành công!", "Thông báo");
                            dgvChiTietHD.DataSource = chiTietHoaDonBUS.Find(txtMaHD.Text);
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo"); }
                }
                if (dgvChiTietHD.Rows.Count == 0)
                {
                    if (MessageBox.Show("Chi tiết hóa đơn " + txtMaHoaDon.Text + " đã không còn, bạn có muốn xóa hóa đơn " + txtMaHoaDon.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            if (chiTietHoaDonBUS.XoaChiTietHoaDon(txtMaHoaDon.Text) && hoaDonBUS.XoaHoaDon(txtMaHoaDon.Text))
                            {
                                loadDGV();
                                MessageBox.Show("Xóa hóa đơn "+txtMaHoaDon.Text+" thành công!", "Thông báo");
                            }

                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo"); }
                    }
                }
            }
        }
        private void dgvChiTietHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            DataGridViewRow row = dgvChiTietHD.Rows[e.RowIndex];
            txtMaHoaDon.Text = row.Cells[0].Value.ToString();
            txtTenSP.Text = row.Cells[1].Value.ToString();
            richMoTa.Text = row.Cells[2].Value.ToString();
            txtSL.Text = row.Cells[3].Value.ToString();
        }
        private void txtFindHD_TextChanged(object sender, EventArgs e)
        {
            dgvHD.DataSource = hoaDonBUS.Find(txtFindHD.Text);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtMaHD.Text == "")
            {
                MessageBox.Show("Vui lòng chọn hóa đơn muốn xóa", "Thông báo");
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa hóa đơn " + txtMaHD.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (MessageBox.Show("Nếu xóa hóa đơn sẽ xóa chi tiết hóa đơn tương ứng, bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (chiTietHoaDonBUS.XoaChiTietHoaDon(txtMaHD.Text) && hoaDonBUS.XoaHoaDon(txtMaHD.Text))
                        {
                            loadDGV();
                            dgvChiTietHD.DataSource = null;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo"); }
                }                    
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            if(hoaDonBUS.GetSL() == 0)
            {
                MessageBox.Show("Không có hóa đơn để hiển thị", "Thông tin");
                return;
            }
            dgvChiTietHD.DataSource = chiTietHoaDonBUS.Find(txtMaHD.Text);
            dgvChiTietHD.Columns["ThanhTien"].DefaultCellStyle.Format = "N2";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Mã khách hàng không được để trống, Xin vui lòng nhập đầy đủ tên nhân viên", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Mã nhân viên không được để trống, Xin vui lòng nhập đầy đủ tên nhân viên", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Mã khách hàng không được để trống, Xin vui lòng nhập đầy đủ tên nhân viên", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnRefreshHD_Click(object sender, EventArgs e)
        {
            clearHD();
            clearChiTiet();
        }
        private void btnRefreshChiTietHD_Click(object sender, EventArgs e)
        {
            clearChiTiet();
        }
        private void txtFindChiTietHD_TextChanged(object sender, EventArgs e)
        {
            dgvChiTietHD.DataSource = chiTietHoaDonBUS.FindText(txtFindChiTietHD.Text);
        }
    }
}
