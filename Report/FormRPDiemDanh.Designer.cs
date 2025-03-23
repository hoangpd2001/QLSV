
namespace QLDSV.Report
{
    partial class FormRPDiemDanh
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.OjbDiemDanhLopBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OjbDiemDanhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OjbChiTietLichDayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OjbLichDayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OjbDiemDanhLopBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OjbDiemDanhBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OjbChiTietLichDayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OjbLichDayBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.OjbDiemDanhLopBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLDSV.Report.ReportDiemDanh.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // OjbDiemDanhLopBindingSource
            // 
            this.OjbDiemDanhLopBindingSource.DataSource = typeof(QLDSV.Object.OjbDiemDanhLop);
            // 
            // OjbDiemDanhBindingSource
            // 
            this.OjbDiemDanhBindingSource.DataSource = typeof(QLDSV.Object.OjbDiemDanh);
            // 
            // OjbChiTietLichDayBindingSource
            // 
            this.OjbChiTietLichDayBindingSource.DataSource = typeof(QLDSV.Object.OjbChiTietLichDay);
            // 
            // OjbLichDayBindingSource
            // 
            this.OjbLichDayBindingSource.DataSource = typeof(QLDSV.Object.OjbLichDay);
            // 
            // FormRPDiemDanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormRPDiemDanh";
            this.Text = "FormRPDiemDanh";
            this.Load += new System.EventHandler(this.FormRPDiemDanh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OjbDiemDanhLopBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OjbDiemDanhBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OjbChiTietLichDayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OjbLichDayBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource OjbDiemDanhBindingSource;
        private System.Windows.Forms.BindingSource OjbChiTietLichDayBindingSource;
        private System.Windows.Forms.BindingSource OjbLichDayBindingSource;
        private System.Windows.Forms.BindingSource OjbDiemDanhLopBindingSource;
    }
}