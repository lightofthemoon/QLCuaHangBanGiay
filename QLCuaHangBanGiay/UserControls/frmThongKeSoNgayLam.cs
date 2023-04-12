using Microsoft.Reporting.WinForms;
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
    public partial class frmThongKeSoNgayLam : UserControl
    {
        QuanLyBanGiayModels context;
        List<SoNgayLamReport> listReport;
        public frmThongKeSoNgayLam()
        {
            InitializeComponent();
            listReport = new List<SoNgayLamReport>();
        }

        private void frmThongKeSoNgayLam_Load(object sender, EventArgs e)
        {
            reportViewer1.Visible = true;

            QuanLyBanGiayModels context = new QuanLyBanGiayModels();

            List<LichLamViec> list = context.LichLamViecs.ToList();


            foreach (LichLamViec i in list)
            {
                SoNgayLamReport temp = new SoNgayLamReport();
                temp.MaNV = i.MaNV;
                temp.MaCaLam = i.MaCaLam;
                temp.GioVaoLam = i.GioVaoLam;
                temp.GioTanCa = i.GioTanCa;
                temp.NgayLamViec = i.NgayLamViec;

                listReport.Add(temp);
            }

            this.reportViewer1.LocalReport.ReportPath = "rptThongKeSoNgayLam.rdlc";
            var reportDataSource = new ReportDataSource("SoNgayLamDataSet", listReport);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên cần thống kê, vui lòng nhập đầy đủ mã nhân viên", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string maNV = txtMaNV.Text;
                string thang = dateThang.Value.ToString("yyyy-MM");
                List<SoNgayLamReport> locMaNV = listReport.Where(id => id.MaNV == maNV && id.NgayLamViec.Date.ToString("yyyy-MM") == thang).ToList();
                var TongNgay = new ReportParameter("TongNgay", locMaNV.Count().ToString());
                this.reportViewer1.LocalReport.SetParameters(TongNgay);
                this.reportViewer1.LocalReport.ReportPath = "rptThongKeSoNgayLam.rdlc";
                var reportDataSource = new ReportDataSource("SoNgayLamDataSet", locMaNV);

                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "rptThongKeSoNgayLam.rdlc";
            var reportDataSource = new ReportDataSource("SoNgayLamDataSet", listReport);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
