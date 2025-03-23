using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDSV.Control;
using QLDSV.Object;
namespace QLDSV.View
{
    public partial class FormLichHocLop : Form
    {
        CtrHocKy ctrHocKy = new CtrHocKy();
        CtrKhoaHoc ctrKhoaHoc = new CtrKhoaHoc();
        CtrNganhHoc ctrNganhHoc = new CtrNganhHoc();
        CtrHinhThuc ctrHinhThuc = new CtrHinhThuc();
        CtrMonHoc ctrMonHoc = new CtrMonHoc();
        CtrLopHoc ctrLopHoc = new CtrLopHoc();
        CtrSinhVien ctrSinhVien = new CtrSinhVien();
        CtrDiem ctrDiem = new CtrDiem();
        CtrDiemDanh ctrDiemDanh = new CtrDiemDanh();
        public FormLichHocLop()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
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
            Hien();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormLichHocLop_Load(object sender, EventArgs e)
        {

            setComboBox();
            comboBoxKhoaHoc.Text = "";
            comboBoxNganhHoc.Text = "";
            Hien();
        }
        public void Hien()
        {

            DataTable dataTable;
            if (comboBoxKhoaHoc.Text == "")
            {
                dataTable = ctrLopHoc.GetData();
            }
            else
            {
                if (comboBoxNganhHoc.Text == "")
                {
                    dataTable = ctrLopHoc.GetData(SelectIdCombobox(comboBoxKhoaHoc), 0);
                }
                else
                {
                    dataTable = ctrLopHoc.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc));
                }
            }

            dataGridView.Rows.Clear();

            if (!dataGridView.Columns.Contains("ActionButton"))
            {

                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = "Chi Tiết";
                buttonColumn.Name = "ActionButton";
                buttonColumn.Text = "Chi Tiết";
                buttonColumn.UseColumnTextForButtonValue = true;

                dataGridView.Columns.Add(buttonColumn);
            }
            foreach (DataRow row in dataTable.Rows)
            {
                object[] rowdata = {row["TenLopHoc"] , row["ID"]};
                dataGridView.Rows.Add(rowdata);
            }
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

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView.Columns["ActionButton"].Index && e.RowIndex >= 0)
            {
                
                DataGridViewRow currentRow = dataGridView.Rows[e.RowIndex];

                
                string tenLopHoc = currentRow.Cells["TenLopHoc"].Value?.ToString();
               
                int itenLopHoc = Convert.ToInt32(currentRow.Cells["ID_LopHoc"].Value?.ToString());
             
                
                ChiTietLichHocLop chiTietDiem = new ChiTietLichHocLop(itenLopHoc,tenLopHoc);
                chiTietDiem.MdiParent = this.MdiParent;
                chiTietDiem.Show(); 
            }
        }
    }
}
