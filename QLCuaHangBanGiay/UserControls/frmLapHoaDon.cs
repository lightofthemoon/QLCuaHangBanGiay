using QLCuaHangBanGiay.DataTier;
using QLCuaHangBanGiay.DataTier.Models;
using ServiceStack.Messaging;
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
    public partial class frmLapHoaDon : UserControl
    {
        KhachHangBUS khBUS;
        SanPhamBUS spBUS;
        HoaDonBUS hdBUS;
        ChiTietHoaDonBUS chiTietHDBUS;
        LoaiKHBUS loaiKHBUS;
        public string maNV;
        public float totalPricre = 0;
        public string tenKH = "";
        public int diem = 0;
        public int giamGia = 0;
        public int sLSP = 0;
        public frmLapHoaDon(string id) //constructor khoi tao frmLapHoaDon truyen vao id lay MaNV
        {
            InitializeComponent();
            khBUS = new KhachHangBUS();
            spBUS = new SanPhamBUS();
            hdBUS = new HoaDonBUS();
            chiTietHDBUS = new ChiTietHoaDonBUS();
            loaiKHBUS = new LoaiKHBUS();
            maNV = id;
        }
        private void loadData() //load data vao datagridview 
        {
            dgvKhachHang.DataSource = khBUS.GetKhachHang();
            dgvSanPham.DataSource = spBUS.GetData();
            lbHD.Text = "Số hóa đơn: " + hdBUS.GetSL();
        }
        private void clear()
        {
            txtMaKH.Clear();
            txtLoaiKH.Clear();
            txtDonGia.Clear();
            txtMaSP.Clear();
            txtGiamGia.Clear();
            txtHinhThucThanhToan.Clear();
            dgvThongTin.Rows.Clear();
        }
        private void frmLapHoaDon_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập đúng số lượng giảm giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int diemTichLuy = 0;
            if (e.RowIndex < 0) return;
            DataGridViewRow rowKH = dgvKhachHang.Rows[e.RowIndex];
            txtMaKH.Text = rowKH.Cells[0].Value.ToString();
            txtLoaiKH.Text = rowKH.Cells[2].Value.ToString();
            tenKH = rowKH.Cells[1].Value.ToString();
            diemTichLuy = (int)rowKH.Cells[4].Value;
            if (diemTichLuy < 21)
                giamGia = 5;
            else if (diemTichLuy < 101)
                giamGia = 10;
            else giamGia = 15;
        }
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow rowSP = dgvSanPham.Rows[e.RowIndex];
            txtMaSP.Text = rowSP.Cells[1].Value.ToString();
            txtDonGia.Text = rowSP.Cells[5].Value.ToString();
            if (e.ColumnIndex == 0)
            {
                try
                {
                    if (txtGiamGia.Text == "" || int.Parse(txtGiamGia.Text) > 70 || int.Parse(txtGiamGia.Text) < 0)
                    {
                        MessageBox.Show("Vui lòng nhập đúng giá trị giảm giá", "Thông báo");
                        return;
                    }
                    if (numSL.Value == 0 || numSL.Value > int.Parse(rowSP.Cells[4].Value.ToString()))
                    {
                        MessageBox.Show("Vui lòng nhập đúng số lượng", "Thông báo");
                        return;
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo!"); }
                int dong = -1;
                if (dgvThongTin.Rows.Count == 1)
                {
                    dgvThongTin.Rows.Add();
                    dgvThongTin.Rows[dgvThongTin.Rows.Count - 2].Cells[0].Value = "";
                    dgvThongTin.Rows[dgvThongTin.Rows.Count - 2].Cells[1].Value = txtMaSP.Text;
                    dgvThongTin.Rows[dgvThongTin.Rows.Count - 2].Cells[2].Value = txtMaKH.Text;
                    dgvThongTin.Rows[dgvThongTin.Rows.Count - 2].Cells[3].Value = numSL.Value.ToString();
                    dgvThongTin.Rows[dgvThongTin.Rows.Count - 2].Cells[4].Value = txtDonGia.Text;
                    dgvThongTin.Rows[dgvThongTin.Rows.Count - 2].Cells[5].Value = numSL.Value * Convert.ToInt32(txtDonGia.Text);
                    dgvThongTin.Rows[dgvThongTin.Rows.Count - 2].Cells[6].Value = txtGiamGia.Text;
                    dgvThongTin.Rows[dgvThongTin.Rows.Count - 2].Cells[7].Value = txtMoTa.Text;
                    sLSP++;
                    totalPricre = totalPricre + (int)((numSL.Value * Convert.ToInt32(txtDonGia.Text)) - (numSL.Value * Convert.ToInt32(txtDonGia.Text)*(Convert.ToInt32(txtGiamGia.Text)/100)) - (numSL.Value * Convert.ToInt32(txtDonGia.Text))*(giamGia/100));
                }
                else
                {
                    for (int i = 0; i < dgvThongTin.Rows.Count - 1; i++) //find row has the same MaHD && MaSP to change number
                    {
                        if (dgvThongTin.Rows[i].Cells[1].Value.ToString() == txtMaSP.Text)
                        {
                            dong = i;
                            break;
                        }
                    }
                    if(dong != -1)
                    {
                        dgvThongTin.Rows[dong].Cells[3].Value = numSL.Value.ToString();
                    }
                    else // if sp don't exist --> create new row
                    {
                        dgvThongTin.Rows.Add();
                        dgvThongTin.Rows[dgvThongTin.Rows.Count - 2].Cells[0].Value = "";
                        dgvThongTin.Rows[dgvThongTin.Rows.Count - 2].Cells[1].Value = txtMaSP.Text;
                        dgvThongTin.Rows[dgvThongTin.Rows.Count - 2].Cells[2].Value = txtMaKH.Text;
                        dgvThongTin.Rows[dgvThongTin.Rows.Count - 2].Cells[3].Value = numSL.Value.ToString();
                        dgvThongTin.Rows[dgvThongTin.Rows.Count - 2].Cells[4].Value = txtDonGia.Text;
                        dgvThongTin.Rows[dgvThongTin.Rows.Count - 2].Cells[5].Value = numSL.Value * Convert.ToInt32(txtDonGia.Text);
                        dgvThongTin.Rows[dgvThongTin.Rows.Count - 2].Cells[6].Value = txtGiamGia.Text;
                        dgvThongTin.Rows[dgvThongTin.Rows.Count - 2].Cells[7].Value = txtMoTa.Text;
                        sLSP++;
                        totalPricre = totalPricre + (int)((numSL.Value * Convert.ToInt32(txtDonGia.Text)) - (numSL.Value * Convert.ToInt32(txtDonGia.Text) * (Convert.ToInt32(txtGiamGia.Text) / 100)) - (numSL.Value * Convert.ToInt32(txtDonGia.Text)) * giamGia/100);
                    }
                }
            }
        }
        private string checkPoint(int? point)
        {
            var temp = loaiKHBUS.GetLoaiKH().Where(x => x.SoDiemTichLuyToiThieu <= point).Last();
            return temp.MaLoaiKH;
        }
        private void capNhatDiem()
        {
            if (totalPricre < 1000001)
                diem = 10;
            else if (totalPricre < 2000001)
                diem = 25;
            else if (totalPricre < 3000001)
                diem = 40;
            else if (totalPricre < 4000001)
                diem = 55;
            else
                diem = 70;
            KhachHang temp = khBUS.GetKhachHangData().FirstOrDefault(x => x.MaKH == txtMaKH.Text);
            temp.DiemTichLuy = temp.DiemTichLuy + diem;
            temp.MaLoaiKH = checkPoint(temp.DiemTichLuy);
            try
            {
                if (khBUS.CapNhatKH(temp))
                    MessageBox.Show("Cập nhật điểm tích lũy cho khách hàng: " + temp.MaKH + " thành công", "Notification");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo!"); }
        }           
        private void capNhatSL()
        {
            for (int i = 0; i < dgvThongTin.Rows.Count - 1; i++)
            {
                string maSP = dgvThongTin.Rows[dgvThongTin.Rows.Count - 2].Cells[1].Value.ToString();
                SanPham sp = spBUS.GetSanPhamData().FirstOrDefault(x => x.MaSP == maSP);
                sp.SLTonKho = sp.SLTonKho - int.Parse(dgvThongTin.Rows[dgvThongTin.Rows.Count - 2].Cells[3].Value.ToString());
                try
                {
                    if(spBUS.CapNhatSanPham(sp))
                        MessageBox.Show("Cập nhật số lượng tồn kho cho sản phẩm: " + sp.TenSP + " thành công!", "Notification");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo!"); }
            }
        }
        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("CÔNG TY TNHH MTV BÁN GIÀY NIKE VIỆT NAM ", new Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, new Point(90, 20));
            e.Graphics.DrawString("HOÁ ĐƠN BÁN HÀNG", new Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, new Point(269, 130));
            e.Graphics.DrawString("Địa chỉ: 215 Điện Biên Phủ, P.15, Q.Bình Thạnh, TP.HCM", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(170, 60));
            e.Graphics.DrawString("Ngày lập hoá đơn: " + DateTime.Now, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 180));
            e.Graphics.DrawString("Mã hoá đơn: " , new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(500, 180));
            e.Graphics.DrawString("Khách hàng: " + tenKH, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 209));
            e.Graphics.DrawString("Nhân viên: " + maNV, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(500, 209));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 235));
            e.Graphics.DrawString("Tên sản phẩm: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 255));
            e.Graphics.DrawString("Số lượng: " , new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(380, 255));
            e.Graphics.DrawString("Đơn giá: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(510, 255));
            e.Graphics.DrawString("Thành tiền", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(660, 255));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 270));
            int dongIn = 295;
            for (int i = 0; i < dgvThongTin.Rows.Count - 1; i++)
            {
                string tenSP = "";
                for (int j = 0; j < dgvSanPham.Rows.Count; j++)
                {
                    if (dgvThongTin.Rows[i].Cells[1].Value.ToString() == dgvSanPham.Rows[j].Cells[1].Value.ToString())
                    {
                        tenSP = dgvSanPham.Rows[j].Cells[2].Value.ToString();
                        break;
                    } 
                }
                e.Graphics.DrawString("" + tenSP, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, dongIn));
                e.Graphics.DrawString(dgvThongTin.Rows[i].Cells[3].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(410, dongIn));
                e.Graphics.DrawString(dgvThongTin.Rows[i].Cells[4].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(508, dongIn));
                e.Graphics.DrawString(dgvThongTin.Rows[i].Cells[5].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(682, dongIn));
                dongIn += 30;
            }
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, dongIn += 30));
            e.Graphics.DrawString("Điểm tích lũy ", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(30, dongIn += 30));
            e.Graphics.DrawString(""+diem, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(682, dongIn));
            e.Graphics.DrawString("Giảm giá: " , new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(30, dongIn += 30));
            e.Graphics.DrawString("" + giamGia + "%", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(682, dongIn));
            e.Graphics.DrawString("Tổng cộng (Đã bao gồm thuế): ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(30, dongIn += 30));
            e.Graphics.DrawString("" + Math.Round(totalPricre,2), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(682, dongIn));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, dongIn += 30));
            e.Graphics.DrawString("THÔNG TIN KHUYẾN MÃI", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(300, dongIn += 30));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, dongIn += 30));
            e.Graphics.DrawString("Phiếu tính tiền chỉ có giá trị xuất đơn thời gian thực trong ngày", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(180, dongIn += 30));
            e.Graphics.DrawString("Quý khách liên hệ cửa hàng để xuất hoá đơn điện tử", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, dongIn += 30));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, dongIn += 30));
            e.Graphics.DrawString("XIN CHÂN THÀNH CẢM ƠN!", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(310, dongIn += 30));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, dongIn += 30));
            // reset the variables
            loadData();
            clear();
        }      
        string SetMaHD()
        {
            string digit = "HD";
            string id = "";
            var count = hdBUS.GetSL();
            if (count > 0)
            {
                var str = hdBUS.GetHoaDon().OrderByDescending(a => a.MaHD).Select(a => a.MaHD).First();
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Tên khách hàng hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtLoaiKH.Text))
            {
                MessageBox.Show("Loại khách hàng hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtHinhThucThanhToan.Text))
            {
                MessageBox.Show("Hình thức thanh toán hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Mã sản phẩm hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(numSL.Text))
            {
                MessageBox.Show("Số lượng sản phẩm hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show("Đơn giá sản phẩm hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtGiamGia.Text))
            {
                MessageBox.Show("Giảm giá sản phẩm hiện đang trống, Xin vui lòng kiểm tra lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                HoaDon hd = new HoaDon();
                hd.MaHD = SetMaHD();
                hd.MaNV = maNV;
                hd.MaKH = txtMaKH.Text;
                hd.NgayTao = DateTime.Now;
                var temp = hdBUS.GetDataHD(hd.MaHD).ToList();
                if (temp.Count != 0)
                {
                    MessageBox.Show("Mã hóa đơn đã tồn tại! Vui lòng nhập lại mã hóa đơn", "Notification");
                    return;
                }
                try
                {
                    if (hdBUS.ThemHoaDon(hd))
                        MessageBox.Show("Thêm hóa đơn " + hd.MaHD + " thành công!", "Notification");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo!");
                }
                for (int i = 0; i < dgvThongTin.Rows.Count - 1; i++)
                {
                    ChiTietHoaDon chiTiet = new ChiTietHoaDon();
                    chiTiet.MaHD = hd.MaHD;
                    chiTiet.MaSP = dgvThongTin.Rows[i].Cells[1].Value.ToString();
                    chiTiet.MoTa = dgvThongTin.Rows[i].Cells[7].Value.ToString();
                    chiTiet.SL = int.Parse(dgvThongTin.Rows[i].Cells[3].Value.ToString());
                    chiTiet.DonGia = int.Parse(dgvThongTin.Rows[i].Cells[4].Value.ToString());
                    chiTiet.ThanhTien = int.Parse(dgvThongTin.Rows[i].Cells[5].Value.ToString());
                    try
                    {
                        chiTietHDBUS.ThemChiTietHoaDon(chiTiet);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo!"); }

                }
                capNhatSL();
                capNhatDiem();
                loadData();
            }            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
            clear();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Đơn giá phải là số và không chứa kí tự chữ, ký tự đặc biệt, Xin vui lòng kiểm tra lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
