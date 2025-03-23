using Microsoft.Reporting.WinForms;
using QLDSV.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV.Report
{
    public partial class FormReportLichHocLop : Form
    {
        DataTable dataTable;
        string TenLop;
        string Ngay1;
        string Ngay2;
        int Loai;
        public FormReportLichHocLop(DataTable table, string TenLop, string Ngay1, string Ngay2, int loai)
        {
            this.dataTable = table;
            InitializeComponent();
            this.TenLop = TenLop;
            this.Ngay1 = Ngay1;
            this.Ngay2 = Ngay2;
            this.Loai = loai;
        }

        private void FormReportLichHocLop_Load(object sender, EventArgs e)
        {
            List<OjbLichHocLop> dataList = ConvertDataTableToList(dataTable);
            if(Loai == 1)
            {
                this.TenLop = $"LỊCH HỌC LỚP : {this.TenLop}";
            }
            else
            {
                this.TenLop = $"LỊCH DẠY GIÁO VIÊN : {this.TenLop}";
            }
            OjbLopHoc ojbLopHoc = new OjbLopHoc(this.TenLop, 0);
            Ngay ngay = new Ngay(Ngay1, Ngay2);
            List<OjbLopHoc> ListLop = new List<OjbLopHoc>();
            List<Ngay> ListNgay = new List<Ngay>();
            ListNgay.Add(ngay);
            ListLop.Add(ojbLopHoc);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.LocalReport.DataSources.Clear();
            var reportDataSource = new ReportDataSource("DataSet1", dataList);
            var reportDataSource2 = new ReportDataSource("DataSet2", ListLop);
            var reportDataSource3 = new ReportDataSource("DataSet3", ListNgay);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.RefreshReport();
            
        }
        private List<OjbLichHocLop> ConvertDataTableToList(DataTable table)
        {
            List<OjbLichHocLop> list = new List<OjbLichHocLop>();

            foreach (DataRow row in table.Rows)
            {
                string tiet = row["Tiet"].ToString();

                for (int i = 1; i < table.Columns.Count; i++) 
                {
                    string ngay = table.Columns[i].ColumnName;
                    string chiTiet = row[i] != DBNull.Value ? row[i].ToString() : string.Empty;

                    list.Add(new OjbLichHocLop(tiet, ngay, chiTiet));
                }
            }

            return list;
        }
    }
}
