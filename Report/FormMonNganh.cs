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
    public partial class FormMonNganh : Form
    {
        CtrKhoaHoc ctrKhoaHoc = new CtrKhoaHoc();
        CtrNganhHoc ctrNganhHoc = new CtrNganhHoc();
        CtrMonHoc ctrMonHoc = new CtrMonHoc();
        public FormMonNganh()
        {
            InitializeComponent();
        }

        private void FormMonNganh_Load(object sender, EventArgs e)
        {
            setComboBox();
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
        private void comboBoxKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = ctrNganhHoc.GetData(SelectIdCombobox(comboBoxKhoaHoc));
            comboBoxNganhHoc.DataSource = table;
            comboBoxNganhHoc.DisplayMember = "TenNganhHoc";
            comboBoxNganhHoc.ValueMember = "ID";
            comboBoxNganhHoc.Text = "";
        }

        private void comboBoxNganhHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            if (comboBoxKhoaHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Khoa Hoc"); return;
            }
            if (comboBoxNganhHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Nganh Hoc"); return;
            }
            DataTable table = null;
            List<OjbMonHoc> list = new List<OjbMonHoc>();

            table = ctrMonHoc.GetDataReport(SelectIdCombobox(comboBoxNganhHoc));
            int stt = 1;
            foreach (DataRow row in table.Rows)
            {
                OjbMonHoc ojb = new OjbMonHoc(row[1].ToString(), int.Parse(row[2].ToString()), int.Parse(row[3].ToString()),stt,row[4].ToString(),row[5].ToString());
                list.Add(ojb);
                stt++;
            }
            OjbNganhHoc ojbNganhHoc= new OjbNganhHoc( comboBoxNganhHoc.Text, 0);

            OjbKhoaHoc ojbKhoaHoc = new OjbKhoaHoc(comboBoxKhoaHoc.Text);
            List<OjbNganhHoc> listNganhHoc = new List<OjbNganhHoc>();
            List<OjbKhoaHoc> listKhoa = new List<OjbKhoaHoc>();
            listNganhHoc.Add(ojbNganhHoc);
            listKhoa.Add(ojbKhoaHoc);
            var reportDataSource = new ReportDataSource("DataSet1", list);
            var reportDataSource2 = new ReportDataSource("DataSet2", listKhoa);
            var reportDataSource3 = new ReportDataSource("DataSet3", listNganhHoc);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.RefreshReport();

        }

    }
}
