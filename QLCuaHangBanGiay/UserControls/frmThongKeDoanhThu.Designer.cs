namespace QLCuaHangBanGiay.UserControls
{
    partial class frmThongKeDoanhThu
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dateThang = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(572, 26);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(156, 39);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.Location = new System.Drawing.Point(394, 28);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(171, 35);
            this.btnThongKe.TabIndex = 18;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Crimson;
            this.label10.Location = new System.Drawing.Point(38, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 22);
            this.label10.TabIndex = 16;
            this.label10.Text = "Chọn tháng";
            // 
            // dateThang
            // 
            this.dateThang.CustomFormat = "MM/yyyy";
            this.dateThang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateThang.Location = new System.Drawing.Point(159, 34);
            this.dateThang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateThang.Name = "dateThang";
            this.dateThang.ShowUpDown = true;
            this.dateThang.Size = new System.Drawing.Size(176, 26);
            this.dateThang.TabIndex = 15;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportViewer1.Location = new System.Drawing.Point(26, 98);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1512, 723);
            this.reportViewer1.TabIndex = 19;
            // 
            // frmThongKeDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dateThang);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmThongKeDoanhThu";
            this.Size = new System.Drawing.Size(1565, 845);
            this.Load += new System.EventHandler(this.frmThongKeDoanhThu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateThang;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
