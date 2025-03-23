using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLDSV.Control;
using QLDSV.Object;
namespace QLDSV
{
    public partial class FormMonHoc : Form
    {

        CtrHocKy ctrHocKy = new CtrHocKy();
        CtrKhoaHoc ctrKhoaHoc = new CtrKhoaHoc();
        CtrNganhHoc ctrNganhHoc = new CtrNganhHoc();
        CtrHinhThuc ctrHinhThuc = new CtrHinhThuc();
        CtrMonHoc ctrMonHoc = new CtrMonHoc();
        public FormMonHoc()
        {
            InitializeComponent();
        }

        private void FormMonHoc_Load(object sender, EventArgs e)
        {
            setComboBox();
            comboBoxKhoaHoc.Text = "";
            comboBoxNganhHoc.Text = "";
            comboBoxHocKi.Text = "";
            comboBoxHinhThuc.Text = "";
            Hien();
        }



        public void Hien()
        {
            DataTable dataTable;
            if (comboBoxKhoaHoc.Text == "")
            {
                dataTable = ctrMonHoc.GetData();
            }
            else
            {   
                 dataTable = ctrMonHoc.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc), SelectIdCombobox(comboBoxHocKi),SelectIdCombobox(comboBoxHinhThuc));
            }
            dataGridView.Rows.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                object[] rowdata = { row["ID"], row["TenMonHoc"],row["SoGioLT"], row["SoTiet1Buoi"], row["TenHinhThuc"], row["TenHocKy"], row["TenNganhHoc"], row["TenKhoaHoc"] };
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
            comboBoxHocKi.DataSource = table;
            comboBoxHocKi.DisplayMember = "TenHocKy";
            comboBoxHocKi.ValueMember = "ID";
            comboBoxHocKi.Text = "";
            Hien();
        }
        private void comboBoxHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = ctrHinhThuc.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc), SelectIdCombobox(comboBoxHocKi));
            comboBoxHinhThuc.DataSource = table;
            comboBoxHinhThuc.DisplayMember = "TenHinhThuc";
            comboBoxHinhThuc.ValueMember = "ID";
            comboBoxHinhThuc.Text = "";
            Hien();
        }
        private void comboBoxHinhThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hien();
        }



        private void buttonReset_Click(object sender, EventArgs e)
        {
            comboBoxKhoaHoc.Text = "";
            comboBoxNganhHoc.Text = "";
            comboBoxHocKi.Text = "";
            comboBoxHinhThuc.Text = "";
            textBoxTen.Text = "";
            textBoxTH.Text = "";
            textBoxLT.Text = "";
            Hien();
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (textBoxTen.Text == "")
            {
                MessageBox.Show("khong duoc de trong ten Mon Hoc"); return;
            }
            if (textBoxLT.Text == "")
            {
                MessageBox.Show("khong duoc de trong So Gio Li Thuyet"); return;
            }
            if (textBoxTH.Text == "")
            {
                MessageBox.Show("khong duoc de trong So Gio Thuc Hanh"); return;
            }
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
            if (comboBoxHocKi.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Hoc Ky"); return;
            }
            OjbMonHoc ojb = new OjbMonHoc(textBoxTen.Text.Trim(),int.Parse(textBoxLT.Text), int.Parse(textBoxTH.Text), SelectIdCombobox(comboBoxHinhThuc));

            int x = ctrMonHoc.InsertData(ojb);

            if (x == -1)
            {
                MessageBox.Show(" ban ghi Mon Hoc: " + textBoxTen.Text + " da ton tai");
                return;
            }
            else if (x == 0)
            {
                MessageBox.Show(" them  ban ghi Mon Hoc: " + textBoxTen.Text + " that bai, vui long kiem tra lai ket noi", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("them thanh cong Mon Hoc: " + textBoxTen.Text);
            Hien();
        }
        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (textBoxTen.Text == "")
            {
                MessageBox.Show("khong duoc de trong ten Mon Hoc"); return;
            }
            if (textBoxLT.Text == "")
            {
                MessageBox.Show("khong duoc de trong So Gio Li Thuyet"); return;
            }
            if (textBoxTH.Text == "")
            {
                MessageBox.Show("khong duoc de trong So Gio Thuc Hanh"); return;
            }
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
            if (comboBoxHocKi.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Hoc Ky"); return;
            }
            var check = MessageBox.Show("ban co chac muon sua MonHoc: " + dataGridView.CurrentRow.Cells[1].Value.ToString() + " thanh : " + textBoxTen.Text + " khong", "Xac Nhan", MessageBoxButtons.YesNo);

            if (check == DialogResult.No) return;


            OjbMonHoc ojb = new OjbMonHoc(int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()), textBoxTen.Text.Trim(), int.Parse(textBoxLT.Text), int.Parse(textBoxTH.Text), SelectIdCombobox(comboBoxHinhThuc));

            int x = ctrMonHoc.UpdateData(ojb);

            if (x < 0)
            {
                MessageBox.Show("sua that bai MonHoc: " + textBoxTen.Text + " da ton tai");
                return;
            }
            else if (x == 0)
            {
                MessageBox.Show("sua that bai vui long kiem tra lai ket noi", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("sua thanh cong ");
            Hien();
        }
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            var check = MessageBox.Show("ban co chac muon xoa Mon Hoc" + dataGridView.CurrentRow.Cells[1].Value.ToString(), "Xac Nhan", MessageBoxButtons.YesNo);

            if (check == DialogResult.No) return;

            OjbMonHoc ojb = new OjbMonHoc(int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()), dataGridView.CurrentRow.Cells[1].Value.ToString(),1,1, SelectIdCombobox(comboBoxHinhThuc));

            int x = ctrMonHoc.DeleteData(ojb);

            if (x > 0) MessageBox.Show("xoa thanh cong Mon Hoc: " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            else if (x == 0) MessageBox.Show("xoa that bai  khong tim thay Mon Hoc: " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            else MessageBox.Show("xoa that bai  ban phai xoa tat ca cac du lieu lien quan toi Mon Hoc: " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            Hien();
        }
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBoxKhoaHoc.Text = dataGridView.CurrentRow.Cells[7].Value.ToString();
            comboBoxNganhHoc.Text = dataGridView.CurrentRow.Cells[6].Value.ToString();
            comboBoxHocKi.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            comboBoxHinhThuc.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
            textBoxLT.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            textBoxTH.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            textBoxTen.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
