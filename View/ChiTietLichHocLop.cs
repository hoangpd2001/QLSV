using QLDSV.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDSV.Report;
using QLDSV.Object;

namespace QLDSV.View
{
    public partial class ChiTietLichHocLop : Form
    {
        DataTable dataTable = null;
        public ChiTietLichHocLop(int ID_LopHoc,  string tenLopHoc)
        {
            InitializeComponent();
            this.ID_LopHoc = ID_LopHoc;
            this.tenLopHoc = tenLopHoc;

        }
        int ID_LopHoc;
        string tenLopHoc;
        CtrLichDay ctrLichDay= new  CtrLichDay();
        private void ChiTietLichHocLop_Load(object sender, EventArgs e)
        {
            label1.Text = $"CHI TIẾT LỊCH HỌC LỚP :{this.tenLopHoc}  ";
           
        }
        public void Hien()
        {
            LoadDatagridview();
            
            SetupDataGridView();

        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

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
                    DataTable data = ctrLichDay.GetData(this.ID_LopHoc, currentColumnDate, "Tiet " + i);
                    if (data != null && data.Rows.Count > 0)
                    {
                        row[j] = data.Rows[0]["TenMonHoc"] + "\n (" + data.Rows[0]["TenHinhThuc"]+")" + "\n (" + data.Rows[0]["TenPhongHoc"] + ")" + "\n (" + data.Rows[0]["Ten"] + ")";
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

        private void button2_Click(object sender, EventArgs e)
        {
            FormReportLichHocLop formReportLichHocLop= new FormReportLichHocLop(dataTable, tenLopHoc,
                dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"),1);
            formReportLichHocLop.ShowDialog();
        }
      
    }
}
