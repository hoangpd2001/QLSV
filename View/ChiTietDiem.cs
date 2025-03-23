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
using QLDSV.Report;
namespace QLDSV.View
{
    public partial class ChiTietDiem : Form
    {
        CtrChiTietLichDay ctrChiTietLichDay = new CtrChiTietLichDay();
        CtrPhongHoc ctrPhongHoc = new CtrPhongHoc();
        CtrSinhVien ctrSinhVien = new CtrSinhVien();
        CtrDiemDanh ctrDiemDanh = new CtrDiemDanh();
        CtrDiem ctrDiem = new CtrDiem();
        DataTable dataTable = new DataTable();
        public ChiTietDiem(int ID_LopHoc, int ID_MonHoc, int ID_HinhThuc, int ID_GiaoVien, string tenLopHoc, string tenMonHoc, string tenHinhThuc, int soBuoi, string tenGiaoVien, int id)
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
        private void ChiTietDiem_Load(object sender, EventArgs e)
        {
            label1.Text = $"CHI TIẾT ĐIỂM  ";
            label2.Text = $"Tên Môn Học: {this.tenMonHoc}       Tên Hình Thức: {this.tenHinhThuc}";
            label3.Text = $"Tên Giáo Viên: {this.tenGiaoVien}       Tên Lớp : {this.tenLopHoc}";
            Hien();
        }
        public void Hien()
        {
            LoadDatagridview();
            dataGridView.Columns["IDSV"].Visible = false;

        }
        private DataTable CreateTableData()
        {
            DataTable table = new DataTable();


            table.Columns.Add("IDSV", typeof(string));
            table.Columns.Add("Mã SV", typeof(string));
            table.Columns.Add("Sinh viên", typeof(string));
            table.Columns.Add("Điểm", typeof(string));
            table.Columns.Add("Điểm2", typeof(string));
            table.Columns.Add("Trung Bình", typeof(string));

            DataTable sinhVienList = ctrSinhVien.GetData(this.ID_LopHoc);


            foreach (DataRow sinhVien in sinhVienList.Rows)
            {
                DataRow row = table.NewRow();
                row["IDSV"] = sinhVien[0];
                row["Mã SV"] = sinhVien[1];
                row["Sinh viên"] = sinhVien[2];

                string diem = ctrDiem.GetData(Convert.ToInt32(sinhVien[0]), id, 1);
                string diem2 = ctrDiem.GetData(Convert.ToInt32(sinhVien[0]), id, 2);
                row["Điểm"] = diem;
                row["Điểm2"] = diem2;
                if(diem == ""||diem==null)
                {
                    row["Trung Bình"] = "0";
                }
                else
                {
                    if(diem2 == "-1")
                    {
                        row["Trung Bình"] = diem;
                    }
                    else
                    {
                        int diemtb;
                        if (diem2 == null)
                        {
                            diemtb = ((Convert.ToInt32(diem) * 3) + (0 * 7)) / 10;
                        }
                        diemtb = ((Convert.ToInt32(diem)*3) + (Convert.ToInt32(diem2) * 7))/10;
                        row["Trung Bình"] = diemtb.ToString();
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

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString() == "-1")
                    {
                        cell.Style.BackColor = Color.Beige;
                        cell.Style.ForeColor = Color.Beige;
                        cell.ReadOnly = true;
                    }
                    if (dataGridView.Columns[cell.ColumnIndex].Name == "Mã SV" || dataGridView.Columns[cell.ColumnIndex].Name == "Sinh viên" || dataGridView.Columns[cell.ColumnIndex].Name == "Trung Bình")
                    {
                        cell.ReadOnly = true;
                    }

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView.CellValueChanged -= dataGridView_CellValueChanged;

            try
            {
                if (e.ColumnIndex >= 3 && e.RowIndex >= 0)

                {
                    if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
                    {
                        OjbDiem ojb = new OjbDiem(Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value.ToString()), id, -1, (e.ColumnIndex - 2));
                        ctrDiem.UpdateData(ojb);
                        Hien();
                        return;
                    }
                    try
                    {
                        int diem = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                        if (diem < 0 || diem > 10)
                        {
                            MessageBox.Show("Diem Khong hop Le");
                            Hien();
                            return;
                        }
                        OjbDiem ojb = new OjbDiem(Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value.ToString()), id, diem, (e.ColumnIndex - 2));
                        ctrDiem.UpdateData(ojb);
                        Hien();
                        return;
                    }
                    catch
                    {
                        MessageBox.Show("Diem Khong Hop Le");
                        Hien();
                        return;
                    }

                }
                Hien();
            }

            finally
            {
                // Bật lại sự kiện khi hoàn tất
                dataGridView.CellValueChanged += dataGridView_CellValueChanged;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormReport formReportLichHocLop = new FormReport(dataTable, this.tenLopHoc, this.tenMonHoc);
            formReportLichHocLop.ShowDialog();
        }
    }
}
