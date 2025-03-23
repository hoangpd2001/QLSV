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
    public partial class FormLichDay : Form
    {
        CtrHocKy ctrHocKy = new CtrHocKy();
        CtrKhoaHoc ctrKhoaHoc = new CtrKhoaHoc();
        CtrNganhHoc ctrNganhHoc = new CtrNganhHoc();
        CtrHinhThuc ctrHinhThuc = new CtrHinhThuc();
        CtrMonHoc ctrMonHoc = new CtrMonHoc();
        CtrLopHoc ctrLopHoc = new CtrLopHoc();
        CtrLichDay ctrLichDay = new CtrLichDay();
        CtrGiaoVien ctrGiaoVien = new CtrGiaoVien();
        public FormLichDay()
        {
            InitializeComponent();
        }

        public void Hien()
        {
            DataTable dataTable ;
            if (comboBoxKhoaHoc.Text == "")
            {
                dataTable = ctrLichDay.GetData();
            }
            else
            {

                dataTable = ctrLichDay.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc), SelectIdCombobox(comboBoxHocKy), SelectIdCombobox(comboBoxHinhThuc), SelectIdCombobox(comboBoxMonHoc), SelectIdCombobox(comboBoxLopHoc));

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
            DataTable tablegv = ctrGiaoVien.GetData();
            comboBoxGiaoVien.DataSource = tablegv;
            comboBoxGiaoVien.DisplayMember = "Ten";
            comboBoxGiaoVien.ValueMember = "ID";
            
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
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormLichDay_Load(object sender, EventArgs e)
        {
            setComboBox();
            comboBoxKhoaHoc.Text = "";
            comboBoxGiaoVien.Text = "";
            Hien();
            
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

        private void comboBoxHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = ctrHinhThuc.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc), SelectIdCombobox(comboBoxHocKy));
            comboBoxHinhThuc.DataSource = table;
            comboBoxHinhThuc.DisplayMember = "TenHinhThuc";
            comboBoxHinhThuc.ValueMember = "ID";
            comboBoxHinhThuc.Text = "";
            /*            comboBoxMonHoc.DataSource = null;*/
            
            Hien();
        }

        private void comboBoxHinhThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = ctrMonHoc.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc), SelectIdCombobox(comboBoxHocKy), SelectIdCombobox(comboBoxHinhThuc));
            comboBoxMonHoc.DataSource = table;
            comboBoxMonHoc.DisplayMember = "TenMonHoc";
            comboBoxMonHoc.ValueMember = "ID";
            comboBoxMonHoc.Text = "";
            
            Hien();
        }

        private void comboBoxMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Hien();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
           
            if (comboBoxHinhThuc.Text == "")
            {
                MessageBox.Show("khong duoc de trong ten Hinh Thuc"); return;
            }
            if (comboBoxKhoaHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Khoa Hoc"); return;
            }
            if (comboBoxNganhHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Nganh Hoc"); return;
            }
            if (comboBoxHocKy.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Hoc Ky"); return;
            }
           
            if (comboBoxMonHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Mon Hoc"); return;
            }
            if (comboBoxLopHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Lop Hoc"); return;
            }
            if (comboBoxGiaoVien.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Giao Vien"); return;
            }
            OjbLichDay ojb = new OjbLichDay (SelectIdCombobox(comboBoxGiaoVien), SelectIdCombobox(comboBoxMonHoc ), SelectIdCombobox(comboBoxLopHoc));

            int x = ctrLichDay.InsertData(ojb);

            if (x == -1)
            {
                MessageBox.Show(" ban ghi   da ton tai");
                return;
            }
            else if (x == 0)
            {
                MessageBox.Show(" them  ban ghi  that bai, vui long kiem tra lai ket noi", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("them thanh cong  ");
            Hien(); 
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
                
                ChiTietLichDay chiTietLichDay= new ChiTietLichDay(itenLopHoc, itenMonHoc, itenHinhThuc ,itenGiaoVien,tenLopHoc, tenMonHoc, tenHinhThuc, soBuoi, tenGiaoVien,id);
                chiTietLichDay.MdiParent = this.MdiParent;
                chiTietLichDay.Show();
                
                }
            }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (comboBoxHinhThuc.Text == "")
            {
                MessageBox.Show("khong duoc de trong ten Hinh Thuc"); return;
            }
            if (comboBoxKhoaHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Khoa Hoc"); return;
            }
            if (comboBoxNganhHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Nganh Hoc"); return;
            }
            if (comboBoxHocKy.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Hoc Ky"); return;
            }

            if (comboBoxMonHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Mon Hoc"); return;
            }
            if (comboBoxLopHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Lop Hoc"); return;
            }
            if (comboBoxGiaoVien.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Giao Vien"); return;
            }
            OjbLichDay ojb = new OjbLichDay(SelectIdCombobox(comboBoxGiaoVien), SelectIdCombobox(comboBoxMonHoc), SelectIdCombobox(comboBoxLopHoc));

            int x = ctrLichDay.UpdateData(SelectIdCombobox(comboBoxGiaoVien), SelectIdCombobox(comboBoxMonHoc), SelectIdCombobox(comboBoxLopHoc));
          

            if (x == -1)
            {
                MessageBox.Show("Ban chi co the sua thong tin giao vien");
                return;
            }
            else if (x<=0 )
            {
                MessageBox.Show(" that bai, vui long kiem tra lai ket noi", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("cap nhat thanh cong  ");
            Hien();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView.Columns["ActionButton"].Index && e.RowIndex >= 0)
            {
              
                return;
            }
            comboBoxKhoaHoc.Text = dataGridView.CurrentRow.Cells[9].Value.ToString();
            comboBoxNganhHoc.Text = dataGridView.CurrentRow.Cells[10].Value.ToString();
            comboBoxHocKy.Text = dataGridView.CurrentRow.Cells[11].Value.ToString();
            comboBoxHinhThuc.Text = dataGridView.CurrentRow.Cells[6].Value.ToString();
            comboBoxMonHoc.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            comboBoxLopHoc.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
                comboBoxGiaoVien.Text = dataGridView.CurrentRow.Cells[8].Value.ToString();

        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hien();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            comboBoxKhoaHoc.Text = "";
            comboBoxNganhHoc.Text = "";
            comboBoxHocKy.Text = "";
            comboBoxHinhThuc.Text = "";
            comboBoxMonHoc.Text = "";
            comboBoxLopHoc.Text = "";
            comboBoxGiaoVien.Text = "";
            Hien();
        }
    }
}
