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
    public partial class FormLopKhoa : Form
    {
        CtrKhoaHoc ctrKhoaHoc = new CtrKhoaHoc();
        CtrLopHoc ctrLopHoc = new CtrLopHoc();
        public FormLopKhoa()
        {
            InitializeComponent();
        }

    
        private void FormLopKhoa_Load(object sender, EventArgs e)
        {
            setComboBox();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        public void setComboBox()
        {
            DataTable table = ctrKhoaHoc.GetData();
            comboBoxKhoaHoc.DataSource = table;
            comboBoxKhoaHoc.DisplayMember = "TenKhoaHoc";
            comboBoxKhoaHoc.ValueMember = "ID";
        }
        private int SelectIdCombobox(ComboBox x)
        {
            if (x.Text == "") return 0;
            DataRowView selectedDataRowView = (DataRowView)x.SelectedItem;
            int y = -1;
            try
            {
                y = Convert.ToInt32(selectedDataRowView["ID"]);
            }
            catch (Exception)
            {
                MessageBox.Show("du lieu khong hop le, vui long kiem tra lai lua chon ", " loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return y;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (comboBoxKhoaHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Khoa Hoc"); return;
            }
            DataTable table = null;
            List<OjbLopHoc> list = new List<OjbLopHoc>();
            int STT = 1;
            table = ctrLopHoc.GetDataReport(SelectIdCombobox(comboBoxKhoaHoc));
            foreach (DataRow row in table.Rows)
            {
             
                OjbLopHoc ojb = new OjbLopHoc(row[0].ToString(), STT,int.Parse(row[3].ToString()), row[1].ToString());
                list.Add(ojb);
                STT++;
            }
            OjbKhoaHoc ojbKhoaHoc = new OjbKhoaHoc(comboBoxKhoaHoc.Text);
            List<OjbKhoaHoc> listKhoa = new List<OjbKhoaHoc>();
            listKhoa.Add(ojbKhoaHoc);
            var reportDataSource = new ReportDataSource("DataSet1", list);
            var reportDataSource2 = new ReportDataSource("DataSet2", listKhoa);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.RefreshReport();
        }
    }
}
