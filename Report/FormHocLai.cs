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
using QLDSV.Model;
using QLDSV.Object;

namespace QLDSV.Report
{
    public partial class FormHocLai : Form
    {
        int MaMon;

        CtrHocKy ctrHocKy = new CtrHocKy();
        CtrKhoaHoc ctrKhoaHoc = new CtrKhoaHoc();
        CtrNganhHoc ctrNganhHoc = new CtrNganhHoc();
        CtrHinhThuc ctrHinhThuc = new CtrHinhThuc();
        CtrMonHoc ctrMonHoc = new CtrMonHoc();
        CtrLopHoc ctrLopHoc = new CtrLopHoc();
        CtrSinhVien ctrSinhVien = new CtrSinhVien();
        CtrDiem ctrDiem = new CtrDiem();
        CtrDiemDanh ctrDiemDanh = new CtrDiemDanh();
        ModDiem mod = new ModDiem();
        public FormHocLai()
        {
            InitializeComponent();
            
        }

        private void FormHocLai_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            setComboBox();

        }
        public void Hien()
        {

         
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



     
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable table = mod.GetDataReportDiem3(SelectIdCombobox(comboBoxMonHoc));
           OjbMonHoc ojbLop = new OjbMonHoc(0,comboBoxMonHoc.Text, 0,0,0);

         //   OjbKhoaHoc ojbKhoaHoc = new OjbKhoaHoc(comboBoxKhoaHoc.Text);
            List<OjbMonHoc> listLop = new List<OjbMonHoc>();
           // List<OjbKhoaHoc> listKhoa = new List<OjbKhoaHoc>();
            listLop.Add(ojbLop);
           // listKhoa.Add(ojbKhoaHoc);
            this.reportViewer1.LocalReport.DataSources.Clear();
            var reportDataSource = new ReportDataSource("DataSet1", table);
            var reportDataSource2 = new ReportDataSource("DataSet2", listLop);
          //  var reportDataSource3 = new ReportDataSource("DataSet3", listKhoa);

            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
           // this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }

        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = ctrNganhHoc.GetData(SelectIdCombobox(comboBoxKhoaHoc));
            comboBoxNganhHoc.DataSource = table;
            comboBoxNganhHoc.DisplayMember = "TenNganhHoc";
            comboBoxNganhHoc.ValueMember = "ID";
            comboBoxNganhHoc.Text = "";


            Hien();
        }
        
        private void comboBoxNganhHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = ctrHocKy.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc));
            comboBoxHocky.DataSource = table;
            comboBoxHocky.DisplayMember = "TenHocKy";
            comboBoxHocky.ValueMember = "ID";
            comboBoxHocky.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = ctrMonHoc.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc), SelectIdCombobox(comboBoxHocky), SelectIdCombobox(comboBoxHinhThuc));
            comboBoxMonHoc.DataSource = table;
            comboBoxMonHoc.DisplayMember = "TenMonHoc";
            comboBoxMonHoc.ValueMember = "ID";
            comboBoxMonHoc.Text = "";
            Hien();

        }

        private void comboBoxHocky_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = ctrHinhThuc.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc), SelectIdCombobox(comboBoxHocky));
            comboBoxHinhThuc.DataSource = table;
            comboBoxHinhThuc.DisplayMember = "TenHinhThuc";
            comboBoxHinhThuc.ValueMember = "ID";
            comboBoxHinhThuc.Text = "";
            Hien();
        }

        private void comboBoxMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
