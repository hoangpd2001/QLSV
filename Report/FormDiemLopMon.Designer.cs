
namespace QLDSV.Report
{
    partial class FormReport
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.OjbLopHocBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OjbMonHocBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OjbDiemLopMonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OjbSinhVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.OjbLopHocBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OjbMonHocBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OjbDiemLopMonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OjbSinhVienBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // OjbLopHocBindingSource
            // 
            this.OjbLopHocBindingSource.DataSource = typeof(QLDSV.Object.OjbLopHoc);
            // 
            // OjbMonHocBindingSource
            // 
            this.OjbMonHocBindingSource.DataSource = typeof(QLDSV.Object.OjbMonHoc);
            // 
            // OjbDiemLopMonBindingSource
            // 
            this.OjbDiemLopMonBindingSource.DataSource = typeof(QLDSV.Object.OjbDiemLopMon);
            // 
            // OjbSinhVienBindingSource
            // 
            this.OjbSinhVienBindingSource.DataSource = typeof(QLDSV.Object.OjbSinhVien);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.OjbLopHocBindingSource;
            reportDataSource2.Name = "DataSet3";
            reportDataSource2.Value = this.OjbMonHocBindingSource;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.OjbDiemLopMonBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLDSV.Report.ReportDIemLopMon.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(725, 520);
            this.reportViewer1.TabIndex = 0;
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 520);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormReport";
            this.Text = "FormReport";
            this.Load += new System.EventHandler(this.FormReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OjbLopHocBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OjbMonHocBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OjbDiemLopMonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OjbSinhVienBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource OjbSinhVienBindingSource;
        private System.Windows.Forms.BindingSource OjbDiemLopMonBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource OjbLopHocBindingSource;
        private System.Windows.Forms.BindingSource OjbMonHocBindingSource;
    }
}