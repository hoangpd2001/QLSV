using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QLDSV.Control;
using QLDSV.Object;
namespace QLDSV.Report
{
    public partial class FormReport : Form
    {
        private DataTable dataTable;
        string TenLop;
        string TenMon;
        public FormReport(DataTable table, string TenLop, string TenMon)
        {
            InitializeComponent();
            this.dataTable = table;
            this.TenLop = TenLop;
            this.TenMon = TenMon;
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            List<OjbDiemLopMon> dataList = ConvertDataTableToList(dataTable);

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLDSV.Report.ReportDIemLopMon.rdlc"; // Đường dẫn file .rdlc
            this.reportViewer1.LocalReport.DataSources.Clear();
            var reportDataSource = new ReportDataSource("DataSet1", dataList);
            
            OjbLopHoc ojbLop = new OjbLopHoc(0, TenLop, 0);

            OjbMonHoc ojbMonHoc = new OjbMonHoc(0,TenMon,0,0,0);
            List<OjbLopHoc> listLop = new List<OjbLopHoc>();
            List<OjbMonHoc> listMon= new List<OjbMonHoc>();
            listLop.Add(ojbLop);
            listMon.Add(ojbMonHoc);
            this.reportViewer1.LocalReport.DataSources.Clear();

            var reportDataSource2 = new ReportDataSource("DataSet2", listLop);
            var reportDataSource3 = new ReportDataSource("DataSet3", listMon);

            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }

        private List<OjbDiemLopMon> ConvertDataTableToList(DataTable table)
        {
            List<OjbDiemLopMon> list = new List<OjbDiemLopMon>();

            foreach (DataRow row in table.Rows)
            {
                string diemLan1;
                string diemLan2;
                if (row["Điểm"].ToString() == "" || row["Điểm"].ToString() == null)
                {
                    diemLan1 = "-";
                }
                else
                {
                    diemLan1 = row["Điểm"].ToString();
                }
                if (row["Điểm2"].ToString() == "" || row["Điểm2"].ToString() == null|| row["Điểm2"].ToString() == "-1")
                {
                    diemLan2 = "-";
                }
                else
                {
                    diemLan2 = row["Điểm2"].ToString();
                }
                string maSV = row["Mã SV"].ToString();
                string hoTen = row["Sinh viên"].ToString();
        
                string trungBinh = row["Trung Bình"].ToString();

                list.Add(new OjbDiemLopMon(maSV, hoTen, diemLan1, diemLan2, trungBinh));
            }

            return list;
        }
    }

}