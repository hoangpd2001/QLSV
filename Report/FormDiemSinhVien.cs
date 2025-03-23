using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QLDSV.Control;
using QLDSV.Object;
namespace QLDSV.Report
{
    public partial class FormDiemSinhVien : Form
    {
        CtrHocKy ctrHocKy = new CtrHocKy();
        CtrKhoaHoc ctrKhoaHoc = new CtrKhoaHoc();
        CtrNganhHoc ctrNganhHoc = new CtrNganhHoc();
        CtrHinhThuc ctrHinhThuc = new CtrHinhThuc();
        CtrMonHoc ctrMonHoc = new CtrMonHoc();
        CtrLopHoc ctrLopHoc = new CtrLopHoc();
        CtrSinhVien ctrSinhVien = new CtrSinhVien();
        CtrDiem ctrDiem = new CtrDiem();
        CtrDiemLopMon ctrDiemLopMon = new CtrDiemLopMon();
        public FormDiemSinhVien()
        {
            InitializeComponent();
        }

        private void FormDiemSinhVien_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (textBoxMa.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ma Sinh Vien"); return;
            }
            DataTable table = null;
            List<OjbMonHoc> list = new List<OjbMonHoc>();

            DataTable table1 = ctrSinhVien.GetData(textBoxMa.Text);
            if (table1 == null || table1.Rows.Count == 0) { MessageBox.Show("Mã sinh viên không hợp lệ"); return; }
            DataRow rowSV = table1.Rows[0];
            table = ctrDiem.GetDataReport(textBoxMa.Text);
            int stt = 1;
            foreach (DataRow row in table.Rows)
            {
                int x;
                if(row[3].ToString() == "" || row[3].ToString() == null)
                {
                     x = 0;
                }
                else
                {
                     x = int.Parse(row[3].ToString());
                }
                OjbMonHoc ojb = new OjbMonHoc(row[1].ToString(), stt,0,x, row[2].ToString(), row[0].ToString());
                list.Add(ojb);
                stt++;
            }
        
            OjbLopHoc ojbLop = new OjbLopHoc(0, rowSV[4].ToString(), 0);
            List<OjbSinhVien> listSinhVien = new List<OjbSinhVien>();
            OjbSinhVien ojbSinhVien = new OjbSinhVien(rowSV[1].ToString(), rowSV[2].ToString(),DateTime.Now,0);
            List<OjbLopHoc> listLop = new List<OjbLopHoc>();
            List<OjbKhoaHoc> listKhoaHoc= new List<OjbKhoaHoc>();
            OjbKhoaHoc ojbKhoaHoc= new OjbKhoaHoc(rowSV[6].ToString());
            listLop.Add(ojbLop);
            listSinhVien.Add(ojbSinhVien);
            listKhoaHoc.Add(ojbKhoaHoc);
            var reportDataSource = new ReportDataSource("DataSet1", list);
            var reportDataSource2 = new ReportDataSource("DataSet2", listSinhVien);
            var reportDataSource3 = new ReportDataSource("DataSet3", listLop);
            var reportDataSource4 = new ReportDataSource("DataSet4", listKhoaHoc);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);

            this.reportViewer1.RefreshReport();


        }
    }
}
