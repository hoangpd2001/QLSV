
namespace QLDSV.Report
{
    partial class FormSinhVienLop
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
            this.OjbSinhVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OjbLopHocBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OjbKhoaHocBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxKhoaHoc = new System.Windows.Forms.ComboBox();
            this.comboBoxNganhHoc = new System.Windows.Forms.ComboBox();
            this.comboBoxLopHoc = new System.Windows.Forms.ComboBox();
            this.button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OjbSinhVienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OjbLopHocBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OjbKhoaHocBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OjbSinhVienBindingSource
            // 
            this.OjbSinhVienBindingSource.DataSource = typeof(QLDSV.Object.OjbSinhVien);
            // 
            // OjbLopHocBindingSource
            // 
            this.OjbLopHocBindingSource.DataSource = typeof(QLDSV.Object.OjbLopHoc);
            // 
            // OjbKhoaHocBindingSource
            // 
            this.OjbKhoaHocBindingSource.DataSource = typeof(QLDSV.Object.OjbKhoaHoc);
            // 
            // reportViewer1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.reportViewer1, 2);
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.DocumentMapWidth = 32;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.OjbSinhVienBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.OjbLopHocBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.OjbKhoaHocBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLDSV.Report.ReportSinhVienLop.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(38, 157);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(630, 279);
            this.reportViewer1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.reportViewer1, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxKhoaHoc, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxNganhHoc, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxLopHoc, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.button, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(707, 439);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(38, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(630, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Report Danh sách sinh viên -Lớp";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(38, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Khóa Học";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(38, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngành Học";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(38, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 27);
            this.label4.TabIndex = 3;
            this.label4.Text = "Lớp học";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxKhoaHoc
            // 
            this.comboBoxKhoaHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxKhoaHoc.FormattingEnabled = true;
            this.comboBoxKhoaHoc.Location = new System.Drawing.Point(250, 43);
            this.comboBoxKhoaHoc.Name = "comboBoxKhoaHoc";
            this.comboBoxKhoaHoc.Size = new System.Drawing.Size(418, 21);
            this.comboBoxKhoaHoc.TabIndex = 4;
            this.comboBoxKhoaHoc.SelectedIndexChanged += new System.EventHandler(this.comboBoxKhoaHoc_SelectedIndexChanged);
            // 
            // comboBoxNganhHoc
            // 
            this.comboBoxNganhHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxNganhHoc.FormattingEnabled = true;
            this.comboBoxNganhHoc.Location = new System.Drawing.Point(250, 70);
            this.comboBoxNganhHoc.Name = "comboBoxNganhHoc";
            this.comboBoxNganhHoc.Size = new System.Drawing.Size(418, 21);
            this.comboBoxNganhHoc.TabIndex = 5;
            this.comboBoxNganhHoc.SelectedIndexChanged += new System.EventHandler(this.comboBoxNganhHoc_SelectedIndexChanged);
            // 
            // comboBoxLopHoc
            // 
            this.comboBoxLopHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxLopHoc.FormattingEnabled = true;
            this.comboBoxLopHoc.Location = new System.Drawing.Point(250, 97);
            this.comboBoxLopHoc.Name = "comboBoxLopHoc";
            this.comboBoxLopHoc.Size = new System.Drawing.Size(418, 21);
            this.comboBoxLopHoc.TabIndex = 6;
            this.comboBoxLopHoc.SelectedIndexChanged += new System.EventHandler(this.comboBoxLopHoc_SelectedIndexChanged);
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(250, 124);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(138, 27);
            this.button.TabIndex = 7;
            this.button.Text = "Xác Nhận";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // FormSinhVienLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 439);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormSinhVienLop";
            this.Text = "FormSinhVienLop";
            this.Load += new System.EventHandler(this.FormSinhVienLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OjbSinhVienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OjbLopHocBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OjbKhoaHocBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource OjbSinhVienBindingSource;
        private System.Windows.Forms.BindingSource OjbLopHocBindingSource;
        private System.Windows.Forms.BindingSource OjbKhoaHocBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxKhoaHoc;
        private System.Windows.Forms.ComboBox comboBoxNganhHoc;
        private System.Windows.Forms.ComboBox comboBoxLopHoc;
        private System.Windows.Forms.Button button;
    }
}