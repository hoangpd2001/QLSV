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
    public partial class ChiTietDiemDanh : Form
    {
        CtrChiTietLichDay ctrChiTietLichDay = new CtrChiTietLichDay();
        CtrPhongHoc ctrPhongHoc = new CtrPhongHoc();
        CtrSinhVien ctrSinhVien = new CtrSinhVien();
        CtrDiemDanh ctrDiemDanh = new CtrDiemDanh();
        public ChiTietDiemDanh(int ID_LopHoc, int ID_MonHoc, int ID_HinhThuc, int ID_GiaoVien, string tenLopHoc, string tenMonHoc, string tenHinhThuc, int soBuoi, string tenGiaoVien, int id)
        {
            InitializeComponent();
            this.ID_LopHoc = ID_LopHoc;
            this.ID_MonHoc = ID_MonHoc;
            this.ID_HinhThuc = ID_HinhThuc;
            this.ID_GiaoVien = ID_GiaoVien;
            this.tenLopHoc = tenLopHoc;
            this.tenMonHoc = tenMonHoc;
            this.tenHinhThuc = tenHinhThuc;
            this.soBuoi = soBuoi;
            this.tenGiaoVien = tenGiaoVien;
            this.id = id;
        }
        int ID_LopHoc;
        int ID_MonHoc;
        int ID_HinhThuc;
        int ID_GiaoVien;
        string tenLopHoc;
        string tenMonHoc;
        string tenHinhThuc;
        int soBuoi;
        int id;
        string tenGiaoVien;

        public void Hien()
        {
            LoadDatagridview();
            dataGridView.Columns["IDSV"].Visible = false;
            HighlightLastColumnCells();
            setcombobox();
        }
        private void HighlightLastColumnCells()
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
              {
                int lastColumnIndex = dataGridView.Columns.Count - 1;
                if (row.IsNewRow) continue;
                DataGridViewCell cell = row.Cells[lastColumnIndex];
                if (cell.Value != null && cell.Value.ToString().Contains("/"))
                {
                    string[] parts = cell.Value.ToString().Split('/');
                    if (parts.Length == 2 &&
                        int.TryParse(parts[0], out int numerator) &&
                        int.TryParse(parts[1], out int denominator) &&
                        denominator != 0)
                    {
                        double percentage = (double)numerator / denominator * 100;
                        if (percentage >= 80)
                        {
                            cell.Style.BackColor = Color.LightGreen;
                            cell.Style.ForeColor = Color.Black;
                        }
                        else if (percentage >= 70)
                        {
                            cell.Style.BackColor = Color.Orange;
                            cell.Style.ForeColor = Color.Black;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                            row.DefaultCellStyle.ForeColor = Color.White;
                        }
                    }
                }
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ChiTietDiemDanh_Load(object sender, EventArgs e)
        {
            label1.Text = $"CHI TIẾT ĐIỂM DANH ";
            label2.Text = $"Tên Môn Học: {this.tenMonHoc}       Tên Hình Thức: {this.tenHinhThuc}";
            label3.Text = $"Tên Giáo Viên: {this.tenGiaoVien}       Tên Lớp : {this.tenLopHoc}";
            Hien();

        }
        private void setcombobox()
        {
            DataTable buoiHocList = ctrChiTietLichDay.GetDataBuoiHoc(id);
            comboBox1.Items.Clear();
            comboBox1.Items.Add("ALL");

            foreach (DataRow buoiHoc in buoiHocList.Rows)
            {

                string columnHeader = buoiHoc[2] == null || Convert.ToString(buoiHoc[2]).Length < 10
                     ? $"Buổi {buoiHoc[0]}\n()\n{buoiHoc[3]}\\{buoiHoc[4]}"
                     : $"Buổi {buoiHoc[0]}\n({Convert.ToString(buoiHoc[2]).Substring(0, 10)})\n{buoiHoc[3]}\\{buoiHoc[4]}";

                DataColumn column = new DataColumn(columnHeader, typeof(bool));
                column.ExtendedProperties["ID_BuoiHoc"] = buoiHoc[1];
                bool exists = false;
                foreach (var item in comboBox1.Items)
                {
                    if (item.ToString() == columnHeader)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    comboBox1.Items.Add(columnHeader);
                }
            }
        }
        private DataTable CreateTableData()
        {
            DataTable table = new DataTable();

            
            table.Columns.Add("IDSV", typeof(string));
            table.Columns.Add("Mã SV", typeof(string));
            table.Columns.Add("Sinh viên", typeof(string));
            
            DataTable buoiHocList = ctrChiTietLichDay.GetDataBuoiHoc(id);
                   
            foreach (DataRow buoiHoc in buoiHocList.Rows)
            {

                string columnHeader = buoiHoc[2] == null || Convert.ToString(buoiHoc[2]).Length < 10
                     ? $"Buổi {buoiHoc[0]}\n()\n{buoiHoc[3]}\\{buoiHoc[4]}"
                     : $"Buổi {buoiHoc[0]}\n({Convert.ToString(buoiHoc[2]).Substring(0, 10)})\n{buoiHoc[3]}\\{buoiHoc[4]}";

                DataColumn column = new DataColumn(columnHeader, typeof(bool));
                table.Columns.Add(column);

             
                column.ExtendedProperties["ID_BuoiHoc"] = buoiHoc[1];
             
            }
            table.Columns.Add("Tong", typeof(string));
            
            DataTable sinhVienList = ctrSinhVien.GetData(this.ID_LopHoc);
           

            foreach (DataRow sinhVien in sinhVienList.Rows)
            {
                DataRow row = table.NewRow();
                row["IDSV"] = sinhVien[0];
                row["Mã SV"] = sinhVien[1];
                row["Sinh viên"] = sinhVien[2];
                int dem = 0;
                 foreach (DataRow buoiHoc in buoiHocList.Rows)
                 {
                    bool diemDanh = ctrDiemDanh.GetData(Convert.ToInt32(sinhVien[0]),Convert.ToInt32(buoiHoc[1]));
                    if (diemDanh) dem++;
                    
                    
                    if (buoiHoc[2] == null || Convert.ToString(buoiHoc[2]).Length <10)
                    {
                      
                        row[$"Buổi {buoiHoc[0]}\n()\n{buoiHoc[3]}\\{buoiHoc[4]}"] = diemDanh;
                    }
                    else
                    {
                        
                        row[$"Buổi {buoiHoc[0]}\n({Convert.ToString(buoiHoc[2]).Substring(0,10)})\n{buoiHoc[3]}\\{buoiHoc[4]}"] = diemDanh;
                    }
                }
                row["Tong"] = $"{dem}/{buoiHocList.Rows.Count}";
                table.Rows.Add(row);
            }

            return table;
        }
        private void LoadDatagridview()
        {
            DataTable attendanceTable = CreateTableData();
            dataGridView.DataSource = attendanceTable;

            
            for (int i = 3; i < dataGridView.Columns.Count-1; i++) 
            {
                DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = dataGridView.Columns[i].HeaderText,
                    DataPropertyName = dataGridView.Columns[i].DataPropertyName, 
                    Name = dataGridView.Columns[i].Name,
                    TrueValue = true,
                    FalseValue = false
                };

                dataGridView.Columns.RemoveAt(i);
                dataGridView.Columns.Insert(i, checkboxColumn);
            }
            
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 3 && e.RowIndex >= 0)
            {
                
                string columnName = dataGridView.Columns[e.ColumnIndex].HeaderText;
                DataColumn column = ((DataTable)dataGridView.DataSource).Columns[columnName];

                if (column.ExtendedProperties.ContainsKey("ID_BuoiHoc"))
                {
                    int idBuoiHoc = (int)column.ExtendedProperties["ID_BuoiHoc"];
                    ctrDiemDanh.Update(Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value.ToString()), idBuoiHoc, !(bool)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    Hien();
                }  
                return;
            }
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRPDiemDanh formRPDiemDanh = new FormRPDiemDanh(this.ID_LopHoc, this.ID_MonHoc, tenLopHoc, tenMonHoc);
            formRPDiemDanh.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
                return;

            string selectedColumnHeader = comboBox1.SelectedItem.ToString();

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if(selectedColumnHeader == "ALL")
                {
                    column.Visible = true;
                    if(column.HeaderText == "IDSV")
                    {
                        column.Visible = false;   
                    }
                }
                else
                if (column.HeaderText == "Mã SV" || column.HeaderText == "Sinh viên" || column.HeaderText == "Tong")
                {
                    column.Visible = true;
                }
                else if (column.HeaderText == selectedColumnHeader)
                {
                    column.Visible = true; 
                }
                else
                {
                    column.Visible = false; 
                }
            }
        }
    }
}
