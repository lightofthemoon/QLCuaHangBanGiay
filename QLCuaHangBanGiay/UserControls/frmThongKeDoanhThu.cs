using Microsoft.Reporting.WinForms;
using QLCuaHangBanGiay.DataTier.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCuaHangBanGiay.UserControls
{
    public partial class frmThongKeDoanhThu : UserControl
    {

        QuanLyBanGiayModels context;
        List<DoanhThuReport> listReport;
        CultureInfo fVND = new CultureInfo("vi-VN");
        public frmThongKeDoanhThu()
        {
            InitializeComponent();
            listReport = new List<DoanhThuReport>();
            context = new QuanLyBanGiayModels();
        }

        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            List<ChiTietHoaDon> listChiTiet = context.ChiTietHoaDons.ToList();
            foreach (ChiTietHoaDon i in listChiTiet)
            {
                DoanhThuReport temp = new DoanhThuReport();
                temp.MaHD = i.MaHD;
                temp.MaSP = i.MaSP;
                temp.Ngay = (DateTime)i.HoaDon.NgayTao;
                temp.ThanhTien = i.ThanhTien;

                listReport.Add(temp);
            }
            this.reportViewer1.LocalReport.ReportPath = "rptThongKeDoanhThu.rdlc";
            var TongDoanhThu = new ReportParameter("TongDoanhThu", "0");
            this.reportViewer1.LocalReport.SetParameters(TongDoanhThu);
            ReportDataSource reportNew = new ReportDataSource("DoanhThuDataSet", listReport);
            LoadThongKe(reportNew);
        }
        private void LoadThongKe(ReportDataSource reportLoad)
        {
            this.reportViewer1.LocalReport.ReportPath = "rptThongKeDoanhThu.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportLoad);
            this.reportViewer1.RefreshReport();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string thang = dateThang.Value.ToString("MM/yyyy");
            List<DoanhThuReport> locThang = listReport.Where(t => t.Ngay.Date.ToString("MM/yyyy") == thang).ToList();
            if (locThang.Count == 0)
            {
                MessageBox.Show("Không có hoá đơn doanh thu trong tháng này");
                return;
            }
            var TongDoanhThu = new ReportParameter("TongDoanhThu", string.Format(fVND, "{0:C0}", locThang.Sum(t => t.ThanhTien)));
            this.reportViewer1.LocalReport.SetParameters(TongDoanhThu);

            ReportDataSource reportThang = new ReportDataSource("DoanhThuDataSet", locThang);
            LoadThongKe(reportThang);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "rptThongKeDoanhThu.rdlc";
            var TongDoanhThu = new ReportParameter("TongDoanhThu", "0");
            this.reportViewer1.LocalReport.SetParameters(TongDoanhThu);
            ReportDataSource reportNew = new ReportDataSource("DoanhThuDataSet", listReport);
            LoadThongKe(reportNew);
        }
    }
}
