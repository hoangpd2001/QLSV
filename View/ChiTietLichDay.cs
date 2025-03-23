using System;
using System.Collections.Generic;
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
    public partial class ChiTietLichDay : Form
    {
        private DateTimePicker dtp;
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
        CtrChiTietLichDay ctrChiTietLichDay = new CtrChiTietLichDay();
        CtrPhongHoc ctrPhongHoc = new CtrPhongHoc();
        public ChiTietLichDay(int ID_LopHoc, int ID_MonHoc, int ID_HinhThuc, int ID_GiaoVien, string tenLopHoc, string tenMonHoc, string tenHinhThuc, int soBuoi, string tenGiaoVien, int id)
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

        public void Hien()
        {
            DataTable dataTable = ctrChiTietLichDay.GetData(this.id);
          
            if (dataTable != null)
            {
                dataGridView.Rows.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    string formattedDate = row["Ngay"] != DBNull.Value
              ? Convert.ToDateTime(row["Ngay"]).ToString("dd/MM/yyyy") // Use your preferred date format here
              : string.Empty;
                    
                    object[] rowdata = { row["Buoi"], formattedDate, row["Tiet"], row["ID_Phong"] };
                    dataGridView.Rows.Add(rowdata);
                }
            }
        }

        private void ChiTietLichDay_Load(object sender, EventArgs e)
        {
            label1.Text = $"CHI TIẾT LỊCH DẠY";
            label2.Text = $"Tên Môn Học: {this.tenMonHoc}       Tên Hình Thức: {this.tenHinhThuc}";
            label3.Text = $"Tên Giáo Viên: {this.tenGiaoVien}       Tên Lớp : {this.tenLopHoc}";
            DataGridViewComboBoxColumn tietColumn = new DataGridViewComboBoxColumn
            {
                HeaderText = "Tiết",
                Name = "Tiet",
                DataPropertyName = "Tiet", 
                DropDownWidth = 100,
                FlatStyle = FlatStyle.Flat
            };
             
            int sobuoi;
            if(this.tenHinhThuc == "Thuc Hanh" || this.tenHinhThuc=="Tich Hop")
            {
                tietColumn.Items.Add($"Ca Sang");
                tietColumn.Items.Add($"Ca Chieu");
            }
            
            else for (int i = 1; i <= 4; i++)
            {
                tietColumn.Items.Add($"Tiet {i}");
            }
            DataTable dataPhongHoc = ctrPhongHoc.GetData();
            
            DataGridViewComboBoxColumn phongColumn = new DataGridViewComboBoxColumn
            {
                HeaderText = "Phòng",
                Name = "PhongHoc",
                DataPropertyName = "PhongHoc",
                DropDownWidth = 100,
                FlatStyle = FlatStyle.Flat
            };
            DataView filteredPhongHoc = new DataView(dataPhongHoc);
            if (this.tenHinhThuc == "Ly Thuyet")
            {
                
                filteredPhongHoc.RowFilter = "LoaiPhong = 'Ly Thuyet' OR LoaiPhong = 'Tich Hop'";
            }
            if (this.tenHinhThuc == "Thuc Hanh")
            {

                filteredPhongHoc.RowFilter = "LoaiPhong = 'Thuc Hanh' OR LoaiPhong = 'Tich Hop'";
            }
            phongColumn.DataSource = filteredPhongHoc;
            phongColumn.DisplayMember = "TenPhongHoc";
            phongColumn.ValueMember = "ID";
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Buổi", Name = "Buoi" });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngày", Name = "Ngay" });
            dataGridView.Columns.Add(tietColumn);
            dataGridView.Columns.Add(phongColumn);
            Hien();
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dataGridView.Columns[e.ColumnIndex].Name == "Ngay")
            {
                
                if (dtp != null && dataGridView.Controls.Contains(dtp))
                {
                    dataGridView.Controls.Remove(dtp);
                    dtp.Dispose();
                }

                object cellValue = dataGridView.CurrentCell.Value;

                
                DateTime selectedDate;
                if (cellValue != null && DateTime.TryParse(cellValue.ToString(), out selectedDate))
                {
                    selectedDate = selectedDate.Date; 
                    dtp = new DateTimePicker
                    {
                        Format = DateTimePickerFormat.Short,
                        Visible = true,
                        Value = selectedDate
                    };
                }
                else
                {
                    dtp = new DateTimePicker
                    {
                        Format = DateTimePickerFormat.Short,
                        Visible = true,
                        Value = DateTime.Now.Date 
                    };
                }

                
                var rect = dataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dtp.Size = new Size(rect.Width, rect.Height);
                dtp.Location = new Point(rect.X, rect.Y);

                
                dtp.CloseUp += new EventHandler(dtp_CloseUp);
                dtp.TextChanged += new EventHandler(dtp_OnTextChange);
                dataGridView.Controls.Add(dtp);
            }
        }



        private void dtp_OnTextChange(object sender, EventArgs e)
        {
            
            if (dataGridView.CurrentCell != null)
            {
                dataGridView.CurrentCell.Value = dtp.Value.ToString("dd/MM/yyyy");
            }
        }

        
        private void dtp_CloseUp(object sender, EventArgs e)
        {
            dtp.Visible = false;
            dataGridView.Controls.Remove(dtp); 
            dtp.Dispose(); 
        }

        private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the column name
               
                
                object newValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                object firstCellValue = dataGridView.Rows[e.RowIndex].Cells[0].Value;
                int x;
                if (dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString() != "" && dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString() != "" && dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString() != null && dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString() != null)
                {
                    if (dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString() != "" && dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString() != null)
                    {
                        x = ctrChiTietLichDay.UpdateDataCheck2(this.id, Convert.ToInt32(firstCellValue), e.ColumnIndex, newValue, this.ID_GiaoVien, this.ID_LopHoc, Convert.ToDateTime(dataGridView.Rows[e.RowIndex].Cells[1].Value), dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString(), this.tenHinhThuc, Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[3].Value));
                    }


                    else
                    {
                        x = ctrChiTietLichDay.UpdateDataCheck(this.id, Convert.ToInt32(firstCellValue), e.ColumnIndex, newValue, this.ID_GiaoVien, this.ID_LopHoc, Convert.ToDateTime(dataGridView.Rows[e.RowIndex].Cells[1].Value), dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString(), this.tenHinhThuc );
                    }
                }
                else
                {

                    x = ctrChiTietLichDay.UpdateData(this.id, Convert.ToInt32(firstCellValue), e.ColumnIndex, newValue);
                }
                if(x == -4)
                {
                    MessageBox.Show("Sua That Bai, Giao Vien da Co Lich Day");
                   
                    Hien();
                    return;
                }
                if (x == -3)
                {
                    MessageBox.Show("Sua That Bai, Phong Hoc da Co Lich");

                    Hien();
                    return;
                }
                if (x == -2)
                {
                    MessageBox.Show("Sua That Bai, Lop Hoc da Co Lich Hoc");

                    Hien();
                    return;
                }

                if (x < 0)
                {
                    MessageBox.Show("sua that bai, dl không hợp lệ ");
                    return;
                }
                else if (x == 0)
                {
                    MessageBox.Show("sua that bai vui long kiem tra lai ket noi", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               
                Hien();
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
