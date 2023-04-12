using QLCuaHangBanGiay.DataTier;
using QLCuaHangBanGiay.DataTier.Models;
using System;
using System.CodeDom.Compiler;
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
    public partial class frmNhapHang : UserControl
    {
        PhieuNhapHangBUS phieuNhapHangBUS;
        ChiTietPhieuNhapHangBUS chiTietPhieuNhapHangBUS;
        SanPhamBUS spBUS;
        string maNV = "";
        public frmNhapHang(string NV)
        {
            InitializeComponent();
            maNV = NV;
            phieuNhapHangBUS = new PhieuNhapHangBUS();
            chiTietPhieuNhapHangBUS = new ChiTietPhieuNhapHangBUS();
            spBUS = new SanPhamBUS();
        }
        private void loadDGV()
        {
            dgvPhieuNhap.DataSource = phieuNhapHangBUS.GetPhieuNhapHang();
            lblSoPhieuNhapHang.Text = "Số phiếu nhập hàng: " + phieuNhapHangBUS.GetSL();
        }
        private void clearCT()
        {
            txtMaNCC.Text = "";
            txtMaSP.Text = "";
            txtSoLuong.Text = "";
            txtGia.Text = "";
            txtSize.Text = "";
            txtTongTien.Text = "";
            txtMoTa.Text = "";
        }
        private void clear()
        {
            txtMaPhieuNhap.Text = "";
            txtMaNV.Text = "";
            txtSLSP.Text = "";
            dtaNgayGiao.Text = "";
            txtNgayTao.Text = "";
            clearCT();
        }
        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            loadDGV();
           
        }
        private void txtMaPhieuNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập đúng mã phiếu nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void txtSLSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập đúng số lượng là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        string SetMaNhapHang()
        {
            string digit = "PNH";
            string id = "";
            var count = phieuNhapHangBUS.GetSL();
            if (count > 0)
            {
                var str = phieuNhapHangBUS.GetPhieuNhapHang().OrderByDescending(a => a.MaPhieuNhap).Select(a => a.MaPhieuNhap).First();
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
        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0) return;
            DataGridViewRow row = dgvPhieuNhap.Rows[e.RowIndex];
            txtMaPhieuNhap.Text = row.Cells[1].Value.ToString();
            txtMaNV.Text = row.Cells[2].Value.ToString();
            txtSLSP.Text = row.Cells[3].Value.ToString();
            if (row.Cells[4].Value == null)
                txtTongTien.Text = "";
            else txtTongTien.Text = row.Cells[4].Value.ToString();
            txtNgayTao.Text = row.Cells[5].Value.ToString();
            if(row.Cells[6].Value.ToString() == null)
                dtaNgayGiao.Text = "";
            else dtaNgayGiao.Text = row.Cells[6].Value.ToString();
            if(e.ColumnIndex == 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa phiếu nhập hàng " + txtMaPhieuNhap.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(MessageBox.Show("Nếu xóa phiếu nhập hàng sẽ xóa chi tiết phiếu nhập hàng tương ứng, bạn có muốn xóa không?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            if(chiTietPhieuNhapHangBUS.XoaChiTietFull(txtMaPhieuNhap.Text) && phieuNhapHangBUS.XoaPhieuNhapHang(txtMaPhieuNhap.Text))
                            {
                                MessageBox.Show("Xóa phiếu nhập hàng " + txtMaPhieuNhap.Text + " thành công!", "Thông báo");
                                loadDGV();
                                clear();
                            }
                            else
                            {
                                MessageBox.Show("Phiếu nhập hàng " + txtMaPhieuNhap.Text + " không tồn tại!");
                            }
                        }
                        catch(Exception ex) { MessageBox.Show(ex.Message, "Thông báo"); }
                    }
                }

            }
        }    
        private void dgvChiTietPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvChiTietPhieuNhap.Rows[e.RowIndex];
            txtMaNCC.Text = row.Cells[2].Value.ToString();
            txtMaSP.Text = row.Cells[3].Value.ToString();
            txtSoLuong.Text = row.Cells[4].Value.ToString();
            txtGia.Text = row.Cells[5].Value.ToString();
            txtSize.Text = row.Cells[6].Value.ToString();
            txtMoTa.Text = row.Cells[7].Value.ToString();
            if(e.ColumnIndex == 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa chi tiết phiếu nhập hàng " + txtMaPhieuNhap.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if(chiTietPhieuNhapHangBUS.XoaChiTietPhieuNhapHang(txtMaPhieuNhap.Text, txtMaNCC.Text, txtMaSP.Text))
                        {
                            MessageBox.Show("Xóa chi tiết phiếu nhập hàng thành công", "Thông báo");
                            dgvChiTietPhieuNhap.DataSource = chiTietPhieuNhapHangBUS.GetData().Where(x => x.MaPhieuNhap == txtMaPhieuNhap.Text).ToList();
                            clearCT();
                        }
                        else
                        {
                            MessageBox.Show("Chi tiết phiếu nhập hàng không tồn tại");
                        }
                        if(dgvChiTietPhieuNhap.Rows.Count == 0)
                        {
                            if (MessageBox.Show("Chi tiết phiếu nhập hàng " + txtMaPhieuNhap.Text + " đã được xóa hết bạn có muốn xóa phiếu nhập hàng "+txtMaPhieuNhap.Text+" không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                phieuNhapHangBUS.XoaPhieuNhapHang(txtMaPhieuNhap.Text);
                                loadDGV();
                                clear();
                            }
                        }
                    }
                    catch(Exception ex) { MessageBox.Show(ex.Message, "Thông báo"); }
                }

            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSLSP.Text))
            {
                MessageBox.Show("Số lượng sản phẩm không được phép để trống, Xin vui lòng kiểm tra lại...", "Thông báo!", MessageBoxButtons.OK);
            }
            else if (int.Parse(txtSLSP.Text) <= 0)
            {
                MessageBox.Show("Số lượng sản phẩm không được nhỏ hơn hoặc bằng 0, Xin vui lòng kiểm tra lại...", "Thông báo!", MessageBoxButtons.OK);
            }
            else if (string.IsNullOrEmpty(dtaNgayGiao.Text))
            {
                MessageBox.Show("Ngày giao sản phẩm không được phép để trống, Xin vui lòng kiểm tra lại...", "Thông báo!", MessageBoxButtons.OK);
            }
            else if (DateTime.Parse(dtaNgayGiao.Text) <= DateTime.Now)
            {
                MessageBox.Show("Ngày giao không được phép nhỏ hơn hoặc bằng ngày hiện tại, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK);
            }
            else
            {
                int tongtien = 0;
                PhieuNhapHang temp = new PhieuNhapHang();
                temp.MaPhieuNhap = SetMaNhapHang();
                temp.MaNV = maNV;
                temp.SoLuongSP = int.Parse(txtSLSP.Text);
                temp.NgayTao = DateTime.Now;
                temp.NgayGiao = DateTime.Parse(dtaNgayGiao.Text);
                try
                {
                    if (phieuNhapHangBUS.ThemPhieuNhapHang(temp))
                    {
                        MessageBox.Show("Thêm phiếu nhập hàng " + temp.MaPhieuNhap + " thành công!", "Thông báo");
                    }
                    else
                        MessageBox.Show("Phiếu nhập hàng " + temp.MaPhieuNhap + " đã tồn tại!", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo");
                }
                //loadDGV();
                MessageBox.Show("Xin mời nhập chi tiết phiếu nhập hàng", "Thông báo");
                for (int i = 0; i < temp.SoLuongSP; i++)
                {
                    MessageBox.Show("Mời nhập chi tiết phiếu nhập hàng thứ " + (i + 1),"Thông báo");
                    ChiTietPhieuNhapHang ct = new ChiTietPhieuNhapHang();
                    ct.MaPhieuNhap = temp.MaPhieuNhap;
                    frmChiTietPhieuNhap frm = new frmChiTietPhieuNhap(ct);
                    frm.ShowDialog();
                    if (ct.MaNCC == null || ct.SL == null || ct.MaSP == null || ct.Gia == null || ct.Size == null)
                    {
                        phieuNhapHangBUS.XoaPhieuNhapHang(ct.MaPhieuNhap);
                        loadDGV();
                        clear();
                        return;
                    }
                    tongtien = tongtien + (int)(ct.Gia * ct.SL);
                    try
                    {
                        if (chiTietPhieuNhapHangBUS.ThemChiTietPhieuNhapHang(ct))
                        {
                            MessageBox.Show("Thêm chi tiết phiếu nhập hàng thành công", "Thông báo");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thông báo");
                    }
                    temp.TongTien = tongtien;
                    SanPham sp = spBUS.GetSanPhamData().FirstOrDefault(x => x.MaSP == ct.MaSP);
                    sp.SLTonKho += ct.SL;
                    try
                    {
                        if (spBUS.CapNhatSanPham(sp))
                        {
                            MessageBox.Show("Cập nhật số lượng tồn kho thành công", "Thông báo");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thông báo");
                    }
                    clearCT();
                }
                phieuNhapHangBUS.CapNhatPhieuNhapHang(temp);
                loadDGV();
                clear();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtMaPhieuNhap.Text == "")
            {
                MessageBox.Show("XIn mời chọn phiếu nhập hàng cần xóa", "Thông báo");
                return;
            }
            try
            {
                if (phieuNhapHangBUS.XoaPhieuNhapHang(txtMaPhieuNhap.Text))
                {
                    MessageBox.Show("Xóa phiếu nhập hàng " + txtMaPhieuNhap.Text + " thành công!", "Thông báo");
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
        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            dgvChiTietPhieuNhap.DataSource = chiTietPhieuNhapHangBUS.GetData().Where(x => x.MaPhieuNhap == txtMaPhieuNhap.Text).ToList();
        }
        private void txtFindPhieuNhap_TextChanged(object sender, EventArgs e)
        {
            dgvPhieuNhap.DataSource = phieuNhapHangBUS.Find(txtFindPhieuNhap.Text);
        }
    }
}
