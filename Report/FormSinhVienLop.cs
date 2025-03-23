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
    public partial class FormSinhVienLop : Form
    {
        CtrKhoaHoc ctrKhoaHoc = new CtrKhoaHoc();
        CtrNganhHoc ctrNganhHoc = new CtrNganhHoc();
        CtrLopHoc ctrLopHoc = new CtrLopHoc();
        CtrSinhVien ctrSinhVien = new CtrSinhVien();
        public FormSinhVienLop()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormSinhVienLop_Load(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

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
            DataTable table2 = ctrLopHoc.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc));
            comboBoxLopHoc.DataSource = table2;
            comboBoxLopHoc.DisplayMember = "TenLopHoc";
            comboBoxLopHoc.ValueMember = "ID";
            comboBoxLopHoc.Text = "";
        }

        private void comboBoxLopHoc_SelectedIndexChanged(object sender, EventArgs e)
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
            if (comboBoxLopHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Lop"); return;
            }
            DataTable table = null;
            List<OjbSinhVien> list = new List<OjbSinhVien>();
            int Stt = 1;
            table = ctrSinhVien.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc), SelectIdCombobox(comboBoxLopHoc));
            foreach (DataRow row in table.Rows)
            {
                DateTime dateTime = (DateTime)row[3];
                OjbSinhVien ojb = new OjbSinhVien(row[1].ToString(), row[2].ToString(), dateTime,Stt);
                list.Add(ojb);
                Stt++;
            }
            OjbLopHoc ojbLop = new OjbLopHoc(0, comboBoxLopHoc.Text, 0);
            
            OjbKhoaHoc ojbKhoaHoc= new OjbKhoaHoc(comboBoxKhoaHoc.Text);
            List<OjbLopHoc> listLop = new List<OjbLopHoc>();
            List<OjbKhoaHoc> listKhoa = new List<OjbKhoaHoc>();
            listLop.Add(ojbLop);
            listKhoa.Add(ojbKhoaHoc);
            var reportDataSource = new ReportDataSource("DataSet1", list);
            var reportDataSource2 = new ReportDataSource("DataSet2", listLop);
            var reportDataSource3 = new ReportDataSource("DataSet3", listKhoa);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.RefreshReport();

        }
    }
}
