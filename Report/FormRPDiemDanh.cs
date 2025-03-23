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
    public partial class FormRPDiemDanh : Form
    {
        int idLop;
        int idMon;
        string tenLop;
        string tenMon;
        CtrDiemDanhLop ctrDiemDanhLop = new CtrDiemDanhLop();
        public FormRPDiemDanh(int IDLop, int IDMon, string tenLop, string tenMon)
        {
            InitializeComponent();
            this.idLop = IDLop;
            this.idMon = IDMon;
            this.tenLop = tenLop;
            this.tenMon = tenMon;
        }

        private void FormRPDiemDanh_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            DataTable dataTable = ctrDiemDanhLop.GetData(idLop, idMon);
            this.reportViewer1.LocalReport.DataSources.Clear();
            var reportDataSource = new ReportDataSource("DataSet1", dataTable);
            OjbLopHoc lop = new OjbLopHoc(tenLop, 0);
            OjbMonHoc mon = new OjbMonHoc(tenMon, 0, 0, 0);
            List<OjbLopHoc> ListLop = new List<OjbLopHoc>();
            List<OjbMonHoc> ListNgay = new List<OjbMonHoc>();
            ListNgay.Add(mon);
            ListLop.Add(lop);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.LocalReport.DataSources.Clear();
            var reportDataSource2 = new ReportDataSource("DataSet2", ListLop);
            var reportDataSource3 = new ReportDataSource("DataSet3", ListNgay);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.RefreshReport();
        }
    }
}
