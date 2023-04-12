namespace QLCuaHangBanGiay.UserControls
{
    partial class frmThongKeSoNgayLam
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.dateThang = new System.Windows.Forms.DateTimePicker();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(361, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 22);
            this.label1.TabIndex = 55;
            this.label1.Text = "Nhập mã nhân viên";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Crimson;
            this.label10.Location = new System.Drawing.Point(22, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 22);
            this.label10.TabIndex = 56;
            this.label10.Text = "Chọn tháng";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(572, 19);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(191, 26);
            this.txtMaNV.TabIndex = 53;
            // 
            // dateThang
            // 
            this.dateThang.CustomFormat = "MM/yyyy";
            this.dateThang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateThang.Location = new System.Drawing.Point(141, 18);
            this.dateThang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateThang.Name = "dateThang";
            this.dateThang.ShowUpDown = true;
            this.dateThang.Size = new System.Drawing.Size(169, 26);
            this.dateThang.TabIndex = 52;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Image = global::QLCuaHangBanGiay.Properties.Resources.refresh_button1;
            this.btnLamMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLamMoi.Location = new System.Drawing.Point(804, 14);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(190, 38);
            this.btnLamMoi.TabIndex = 57;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnView
            // 
            this.btnView.Image = global::QLCuaHangBanGiay.Properties.Resources.views__2_2;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(1023, 14);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(190, 38);
            this.btnView.TabIndex = 54;
            this.btnView.Text = "Thống kê";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCuaHangBanGiay.rptThongKeDoanhThu.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(27, 86);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1482, 807);
            this.reportViewer1.TabIndex = 58;
            // 
            // frmThongKeSoNgayLam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.dateThang);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmThongKeSoNgayLam";
            this.Size = new System.Drawing.Size(1530, 906);
            this.Load += new System.EventHandler(this.frmThongKeSoNgayLam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.DateTimePicker dateThang;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
