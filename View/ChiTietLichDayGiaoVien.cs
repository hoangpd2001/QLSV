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
using QLDSV.Report;

namespace QLDSV.View
{
    public partial class ChiTietLichDayGiaoVien : Form
    {
        CtrGiaoVien ctrGiaoVien = new CtrGiaoVien();
        CtrLichDay ctrLichDay = new CtrLichDay();
        DataTable dataTable = null;
        string TenGiaoVien = "";
        public ChiTietLichDayGiaoVien()
        {
            InitializeComponent();
            setComboBox();
        }
        public void setComboBox()
        {
            DataTable table = ctrGiaoVien.GetData();
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "Ten";
            comboBox1.ValueMember = "ID";
        }
        private int SelectIdCombobox(ComboBox x)
        {
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
        public void Hien()
        {
            LoadDatagridview();

            SetupDataGridView();

        }
        private void SetupDataGridView()
        {

            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            dataGridView.RowTemplate.Height = 60;


            dataGridView.Columns["Tiet"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private DataTable CreateTableData()
        {
            DataTable table = new DataTable();
            DateTime dateStart = dateTimePicker1.Value;
            DateTime dateEnd = dateTimePicker2.Value;
            table.Columns.Add("Tiet", typeof(string));
            DateTime currentDate = dateStart;
            while (currentDate <= dateEnd)
            {
                table.Columns.Add(currentDate.ToString("yyyy-MM-dd"), typeof(string));
                currentDate = currentDate.AddDays(1);
            }


            for (int i = 1; i <= 4; i++)
            {
                DataRow row = table.NewRow();
                row["Tiet"] = "Tiet " + i;

                for (int j = 1; j <= table.Columns.Count - 1; j++)
                {
                    DateTime currentColumnDate = DateTime.Parse(table.Columns[j].ColumnName);
                    row[j] = DBNull.Value;
                    DataTable data = ctrLichDay.GetData(SelectIdCombobox(comboBox1), "Tiet " + i, currentColumnDate);
                    if (data != null && data.Rows.Count > 0)
                    {
                        row[j] = data.Rows[0]["TenMonHoc"] + "\n (" + data.Rows[0]["TenHinhThuc"] + ")" + "\n (" + data.Rows[0]["TenPhongHoc"] + ")" + "\n (" + data.Rows[0]["TenLopHoc"] + ")";
                    }
                    else
                    {
                        row[j] = DBNull.Value;
                    }
                }
                table.Rows.Add(row);
            }

            return table;
        }

        private void LoadDatagridview()
        {
            DataTable attendanceTable = CreateTableData();
            dataGridView.DataSource = attendanceTable;
            dataTable = attendanceTable;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Hien();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TenGiaoVien = comboBox1.Text;
        }

        private void ChiTietLichDayGiaoVien_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormReportLichHocLop formReportLichHocLop = new FormReportLichHocLop(dataTable, TenGiaoVien, dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"),2);
            formReportLichHocLop.ShowDialog();
        }
    }
}
