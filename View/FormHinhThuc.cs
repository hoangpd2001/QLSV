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
    public partial class FormHinhThuc : Form
    {
        CtrHocKy ctrHocKy = new CtrHocKy();
        CtrKhoaHoc ctrKhoaHoc = new CtrKhoaHoc();
        CtrNganhHoc ctrNganhHoc = new CtrNganhHoc();
        CtrHinhThuc ctrHinhThuc = new CtrHinhThuc();
        public FormHinhThuc()
        {
            InitializeComponent();
        }

        private void FormHinhThuc_Load(object sender, EventArgs e)
        {
            setComboBox();
            comboBoxKhoaHoc.Text = "";
            comboBoxNganhHoc.Text = "";
            comboBoxHocKi.Text = "";
            Hien();
        }


        public void Hien()
        {
            DataTable dataTable;
            if (comboBoxKhoaHoc.Text == "")
            {
                dataTable = ctrHinhThuc.GetData();
            }
            else
            {
                if (comboBoxNganhHoc.Text == "")
                {
                    dataTable = ctrHinhThuc.GetData(SelectIdCombobox(comboBoxKhoaHoc), 0,0);
                }
                else
                {
                    if (comboBoxHocKi.Text == "")
                    {
                        dataTable = ctrHinhThuc.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc), 0);
                    }
                    else
                    {
                        dataTable = ctrHinhThuc.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc), SelectIdCombobox(comboBoxHocKi));
                    }
                }
            }
            dataGridView.Rows.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                object[] rowdata = { row["ID"], row["TenHinhThuc"], row["TenHocKy"],row["TenNganhHoc"], row["TenKhoaHoc"] };
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
            DataTable table = ctrHocKy.GetData(SelectIdCombobox(comboBoxKhoaHoc),SelectIdCombobox(comboBoxNganhHoc));
            comboBoxHocKi.DataSource = table;
            comboBoxHocKi.DisplayMember = "TenHocKy";
            comboBoxHocKi.ValueMember = "ID";
            comboBoxHocKi.Text = "";
            Hien();
        }
        private void comboBoxHocKi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hien();
        }


        private void buttonReset_Click(object sender, EventArgs e)
        {

            comboBoxKhoaHoc.Text = "";
            comboBoxNganhHoc.Text = "";
            comboBoxHocKi.Text = "";
            comboBoxHinhThuc.Text = "";
            Hien();
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {

            if (comboBoxHinhThuc.Text == "")
            {
                MessageBox.Show("khong duoc de trong ten Hinh Thuc");return;
            }
            if (comboBoxKhoaHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Khoa Hoc");return;
            }
            if (comboBoxNganhHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Nganh Hoc");return;
            }
            if (comboBoxHocKi.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Hoc Ky");return;
            }
            OjbHinhThuc ojb = new OjbHinhThuc(comboBoxHinhThuc.Text.Trim(), SelectIdCombobox(comboBoxHocKi));

            int x = ctrHinhThuc.InsertData(ojb);

            if (x == -1)
            {
                MessageBox.Show(" ban ghi Hinh Thuc: " + comboBoxHinhThuc.Text + " da ton tai");
                return;
            }
            else if (x == 0)
            {
                MessageBox.Show(" them  ban ghi Hinh Thuc: " + comboBoxHinhThuc.Text + " that bai, vui long kiem tra lai ket noi", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("them thanh cong Hinh Thuc: " + comboBoxHinhThuc.Text);
            Hien();
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
            if (comboBoxHocKi.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Hoc Ky"); return;
            }
            var check = MessageBox.Show("ban co chac muon sua Hinh thuc: " + dataGridView.CurrentRow.Cells[1].Value.ToString() + " thanh : " + comboBoxHinhThuc.Text + " khong", "Xac Nhan", MessageBoxButtons.YesNo);

            if (check == DialogResult.No) return;


            OjbHinhThuc ojb = new OjbHinhThuc(int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()), comboBoxHinhThuc.Text.Trim(), SelectIdCombobox(comboBoxHocKi));

            int x = ctrHinhThuc.UpdateData(ojb);

            if (x < 0)
            {
                MessageBox.Show("sua that bai Hoc Ky: " + comboBoxHinhThuc.Text + " da ton tai");
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
            var check = MessageBox.Show("ban co chac muon xoa HinhThuc " + dataGridView.CurrentRow.Cells[1].Value.ToString(), "Xac Nhan", MessageBoxButtons.YesNo);

            if (check == DialogResult.No) return;

            OjbHinhThuc ojb = new OjbHinhThuc(int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()), dataGridView.CurrentRow.Cells[1].Value.ToString(), SelectIdCombobox(comboBoxHocKi));

            int x = ctrHinhThuc.DeleteData(ojb);

            if (x > 0) MessageBox.Show("xoa thanh cong " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            else if (x == 0) MessageBox.Show("xoa that bai  khong tim thay Hinh Thuc: " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            else MessageBox.Show("xoa that bai  ban phai xoa tat ca cac du lieu lien quan toi Hinh Thuc: " + dataGridView.CurrentRow.Cells[1].Value.ToString()+" cua hoc ki " + dataGridView.CurrentRow.Cells[2].Value.ToString());

            Hien();
        }
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBoxKhoaHoc.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
            comboBoxNganhHoc.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            comboBoxHocKi.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            comboBoxHinhThuc.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
