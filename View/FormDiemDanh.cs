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
    public partial class FormDiemDanh : Form
    {
        CtrHocKy ctrHocKy = new CtrHocKy();
        CtrKhoaHoc ctrKhoaHoc = new CtrKhoaHoc();
        CtrNganhHoc ctrNganhHoc = new CtrNganhHoc();
        CtrHinhThuc ctrHinhThuc = new CtrHinhThuc();
        CtrMonHoc ctrMonHoc = new CtrMonHoc();
        CtrLopHoc ctrLopHoc = new CtrLopHoc();
      
        CtrDiemDanh ctrDiemDanh = new CtrDiemDanh();
        public FormDiemDanh()
        {
            InitializeComponent();
        }

        private void FormDiemDanh_Load(object sender, EventArgs e)
        {
            setComboBox();

            Hien();
        }
        public void Hien()
        {
            DataTable dataTable;
            if (comboBoxKhoaHoc.Text == "")
            {
                dataTable = ctrDiemDanh.GetData();
            }
            else
            {

                dataTable = ctrDiemDanh.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc), SelectIdCombobox(comboBoxHocKy),  SelectIdCombobox(comboBoxLopHoc));

            }
            dataGridView.Rows.Clear();
            if (dataTable != null)
            {

                if (!dataGridView.Columns.Contains("ActionButton"))
                {

                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.HeaderText = "Chi Tiết";
                    buttonColumn.Name = "ActionButton";
                    buttonColumn.Text = "Chi Tiết";
                    buttonColumn.UseColumnTextForButtonValue = true;

                    dataGridView.Columns.Add(buttonColumn);
                }


                dataGridView.Rows.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    object[] rowdata = {  row["ID_LopHoc"],   row["ID_MonHoc"], row["ID_HinhThuc"], row["ID_GiaoVien"],row["TenLopHoc"], row["TenMonHoc"], row["TenHinhThuc"], row["SoBuoi"], row["TenGiaoVien"],  row["TenKhoaHoc"], row["TenNganhHoc"], row["TenHocKy"],row["ID"],
                      };
                    dataGridView.Rows.Add(rowdata);
                }
            }
        }
        public void setComboBox()
        {
            DataTable table = ctrKhoaHoc.GetData();
            comboBoxKhoaHoc.DataSource = table;
            comboBoxKhoaHoc.DisplayMember = "TenKhoaHoc";
            comboBoxKhoaHoc.ValueMember = "ID";
            comboBoxKhoaHoc.Text = "";
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

            Hien();
        }

        private void comboBoxNganhHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = ctrHocKy.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc));
            comboBoxHocKy.DataSource = table;
            comboBoxHocKy.DisplayMember = "TenHocKy";
            comboBoxHocKy.ValueMember = "ID";
            comboBoxHocKy.Text = "";
            DataTable table3 = ctrLopHoc.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc));
            comboBoxLopHoc.DataSource = table3;
            comboBoxLopHoc.DisplayMember = "TenLopHoc";
            comboBoxLopHoc.ValueMember = "ID";
            comboBoxLopHoc.Text = "";
            Hien();
        }

        private void comboBoxLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hien();
        }

        private void comboBoxHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hien();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView.Columns["ActionButton"].Index && e.RowIndex >= 0)
            {
                
                DataGridViewRow currentRow = dataGridView.Rows[e.RowIndex];

                
                string tenLopHoc = currentRow.Cells["TenLopHoc"].Value?.ToString();
                string tenMonHoc = currentRow.Cells["TenMonHoc"].Value?.ToString();
                string tenHinhThuc = currentRow.Cells["TenHinhThuc"].Value?.ToString();
                int soBuoi = currentRow.Cells["SoBuoi"].Value != null ? Convert.ToInt32(currentRow.Cells["SoBuoi"].Value) : 0;
                string tenGiaoVien = currentRow.Cells["TenGiaoVien"].Value?.ToString();
                int itenLopHoc = Convert.ToInt32(currentRow.Cells["ID_LopHoc"].Value?.ToString());
                int itenMonHoc = Convert.ToInt32(currentRow.Cells["ID_MonHoc"].Value?.ToString());
                int itenHinhThuc = Convert.ToInt32(currentRow.Cells["ID_HinhThuc"].Value?.ToString());
                int itenGiaoVien = Convert.ToInt32(currentRow.Cells["ID_GiaoVien"].Value?.ToString());
                int id = Convert.ToInt32(currentRow.Cells["ID"].Value?.ToString());
                
                ChiTietDiemDanh chiTietDiem = new ChiTietDiemDanh(itenLopHoc, itenMonHoc, itenHinhThuc, itenGiaoVien, tenLopHoc, tenMonHoc, tenHinhThuc, soBuoi, tenGiaoVien, id);
                //   chiTietDiem.MdiParent = this.MdiParent;
                // chiTietDiem.Show();
                chiTietDiem.ShowDialog();
                 
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
