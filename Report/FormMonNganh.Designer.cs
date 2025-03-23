
namespace QLDSV.Report
{
    partial class FormMonNganh
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
            this.OjbMonHocBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OjbKhoaHocBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OjbNganhHocBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxKhoaHoc = new System.Windows.Forms.ComboBox();
            this.comboBoxNganhHoc = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.OjbMonHocBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OjbKhoaHocBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OjbNganhHocBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OjbMonHocBindingSource
            // 
            this.OjbMonHocBindingSource.DataSource = typeof(QLDSV.Object.OjbMonHoc);
            // 
            // OjbKhoaHocBindingSource
            // 
            this.OjbKhoaHocBindingSource.DataSource = typeof(QLDSV.Object.OjbKhoaHoc);
            // 
            // OjbNganhHocBindingSource
            // 
            this.OjbNganhHocBindingSource.DataSource = typeof(QLDSV.Object.OjbNganhHoc);
            // 
            // reportViewer1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.reportViewer1, 2);
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.DocumentMapWidth = 32;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.OjbMonHocBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.OjbKhoaHocBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.OjbNganhHocBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLDSV.Report.ReportMonNganh.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(42, 126);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(696, 371);
            this.reportViewer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Controls.Add(this.button, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxKhoaHoc, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxNganhHoc, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.reportViewer1, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(780, 500);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(276, 97);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 0;
            this.button.Text = "Xác Nhận ";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(42, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(696, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Report Môn Học-Ngành Học";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(42, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Khóa Học";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(42, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 27);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ngành Học";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxKhoaHoc
            // 
            this.comboBoxKhoaHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxKhoaHoc.FormattingEnabled = true;
            this.comboBoxKhoaHoc.Location = new System.Drawing.Point(276, 43);
            this.comboBoxKhoaHoc.Name = "comboBoxKhoaHoc";
            this.comboBoxKhoaHoc.Size = new System.Drawing.Size(462, 21);
            this.comboBoxKhoaHoc.TabIndex = 4;
            this.comboBoxKhoaHoc.SelectedIndexChanged += new System.EventHandler(this.comboBoxKhoaHoc_SelectedIndexChanged);
            // 
            // comboBoxNganhHoc
            // 
            this.comboBoxNganhHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxNganhHoc.FormattingEnabled = true;
            this.comboBoxNganhHoc.Location = new System.Drawing.Point(276, 70);
            this.comboBoxNganhHoc.Name = "comboBoxNganhHoc";
            this.comboBoxNganhHoc.Size = new System.Drawing.Size(462, 21);
            this.comboBoxNganhHoc.TabIndex = 5;
            this.comboBoxNganhHoc.SelectedIndexChanged += new System.EventHandler(this.comboBoxNganhHoc_SelectedIndexChanged);
            // 
            // FormMonNganh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 500);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormMonNganh";
            this.Text = "FormMonNganh";
            this.Load += new System.EventHandler(this.FormMonNganh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OjbMonHocBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OjbKhoaHocBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OjbNganhHocBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxKhoaHoc;
        private System.Windows.Forms.ComboBox comboBoxNganhHoc;
        private System.Windows.Forms.BindingSource OjbMonHocBindingSource;
        private System.Windows.Forms.BindingSource OjbKhoaHocBindingSource;
        private System.Windows.Forms.BindingSource OjbNganhHocBindingSource;
    }
}