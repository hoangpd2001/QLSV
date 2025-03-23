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
    public partial class FormLopHoc : Form
    {
        CtrLopHoc ctrLopHoc = new CtrLopHoc();
        CtrKhoaHoc ctrKhoaHoc = new CtrKhoaHoc();
        CtrNganhHoc ctrNganhHoc = new CtrNganhHoc();
        public FormLopHoc()
        {
            InitializeComponent();
        }

        private void FormLopHoc_Load(object sender, EventArgs e)
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
            foreach (DataRow row in dataTable.Rows)
            {
                object[] rowdata = { row["ID"], row["TenLopHoc"], row["TenNganhHoc"], row["TenKhoaHoc"] };
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
            Hien();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            comboBoxKhoaHoc.Text = "";
            comboBoxNganhHoc.Text = "";
            textBoxLopHoc.Text = "";
            Hien();
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (textBoxLopHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong ten Hoc Ky");
                return;
            }
            if (comboBoxKhoaHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Khoa Hoc");
                return;
            }
            if (comboBoxNganhHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Nganh Hoc");
                return;
            }
            OjbLopHoc ojb = new OjbLopHoc(textBoxLopHoc.Text.Trim(), SelectIdCombobox(comboBoxNganhHoc));

            int x = ctrLopHoc.InsertData(ojb);

            if (x == -1)
            {
                MessageBox.Show(" ban ghi Lop Hoc: " + textBoxLopHoc.Text + " da ton tai");
                return;
            }
            else if (x == 0)
            {
                MessageBox.Show(" them  ban ghi Lop Hoc " + textBoxLopHoc.Text + " that bai, vui long kiem tra lai ket noi", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("them thanh cong Lop Hoc: " + textBoxLopHoc.Text);
            Hien();
        }
        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (textBoxLopHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong ten Hoc Ky");
                return;
            }
            if (comboBoxKhoaHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Khoa Hoc");
                return;
            }
            if (textBoxLopHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Nganh Hoc");
                return;
            }
            var check = MessageBox.Show("ban co chac muon sua Lop Hoc: " + dataGridView.CurrentRow.Cells[1].Value.ToString() + " thanh : " + textBoxLopHoc.Text + " khong", "Xac Nhan", MessageBoxButtons.YesNo);

            if (check == DialogResult.No) return;


            OjbLopHoc ojb = new OjbLopHoc(int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()), textBoxLopHoc.Text.Trim(), SelectIdCombobox(comboBoxNganhHoc));

            int x = ctrLopHoc.UpdateData(ojb);

            if (x < 0)
            {
                MessageBox.Show("sua that bai Lop Hoc: " + textBoxLopHoc.Text + " da ton tai");
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
            var check = MessageBox.Show("ban co chac muon xoa Lop Hoc " + dataGridView.CurrentRow.Cells[1].Value.ToString(), "Xac Nhan", MessageBoxButtons.YesNo);

            if (check == DialogResult.No) return;

            OjbLopHoc ojb = new OjbLopHoc(int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()), dataGridView.CurrentRow.Cells[1].Value.ToString(), SelectIdCombobox(comboBoxNganhHoc));

            int x = ctrLopHoc.DeleteData(ojb);

            if (x > 0) MessageBox.Show("xoa thanh cong " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            else if (x == 0) MessageBox.Show("xoa that bai  khong tim thay Lop Hoc " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            else MessageBox.Show("xoa that bai  ban phai xoa tat ca cac du lieu lien quan toi Lop Hoc: " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            Hien();
        }
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBoxKhoaHoc.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            comboBoxNganhHoc.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            textBoxLopHoc.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
