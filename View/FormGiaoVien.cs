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
namespace QLDSV.View
{
    public partial class FormGiaoVien : Form
    {
        CtrGiaoVien ctrGiaoVien = new CtrGiaoVien();
        CtrKhoa ctrKhoa = new CtrKhoa();
        public FormGiaoVien()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormGiaoVien_Load(object sender, EventArgs e)
        {
            setComboBox();
            comboBoxKhoa.Text = "";
            Hien();
        }


        public void setComboBox()
        {
            DataTable table = ctrKhoa.GetData();
            comboBoxKhoa.DataSource = table;
            comboBoxKhoa.DisplayMember = "TenKhoa";
            comboBoxKhoa.ValueMember = "ID";
        }
        public void Hien()
        {
            DataTable dataTable;
            if (comboBoxKhoa.Text == "")
            {
                dataTable = ctrGiaoVien.GetData();
            }
            else
            {

                dataTable = ctrGiaoVien.GetData(SelectIdCombobox(comboBoxKhoa));
            }
            dataGridView.Rows.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                object[] rowdata = { row["ID"], row["Ten"], row["LienHe"], row["GhiChu"], row["TenKhoa"] };
                dataGridView.Rows.Add(rowdata);
            }
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

        private void buttonThem_Click(object sender, EventArgs e)
        {


            if (comboBoxKhoa.Text == "")
            {
                MessageBox.Show("khong duoc de trong ten Khoa");
                return;
            }
            if (textBoxTen.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Giao Vien");
                return;
            }
            if (textBoxLienHe.Text == "")
            {
                MessageBox.Show("khong duoc de trong Liên Hệ");
                return;
            }
            if (textBoxGhiChu.Text == "")
            {
                MessageBox.Show("khong duoc de trong ghi chú");
                return;
            }
            OjbGiaoVien ojb = new OjbGiaoVien(textBoxTen.Text.Trim(), textBoxLienHe.Text.Trim(), textBoxGhiChu.Text.Trim(), SelectIdCombobox(comboBoxKhoa));

            int x = ctrGiaoVien.InsertData(ojb);

            if (x == -1)
            {
                MessageBox.Show(" ban ghi Nganh Hoc: " + textBoxTen.Text + " da ton tai");
                return;
            }
            else if (x == 0)
            {
                MessageBox.Show(" them  ban ghi Nganh Hoc: " + textBoxTen.Text + " that bai, vui long kiem tra lai ket noi", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("them thanh cong Nganh Hoc: " + textBoxTen.Text);
            Hien();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {

            if (comboBoxKhoa.Text == "")
            {
                MessageBox.Show("khong duoc de trong ten Khoa");
                return;
            }
            if (textBoxTen.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Giao Vien");
                return;
            }
            if (textBoxLienHe.Text == "")
            {
                MessageBox.Show("khong duoc de trong Liên Hệ");
                return;
            }
            if (textBoxGhiChu.Text == "")
            {
                MessageBox.Show("khong duoc de trong ghi chú");
                return;
            }
            var check = MessageBox.Show("ban co chac muon sua Giáo viên: " + dataGridView.CurrentRow.Cells[1].Value.ToString(), "Xac Nhan", MessageBoxButtons.YesNo);

            if (check == DialogResult.No) return;


            OjbGiaoVien ojb = new OjbGiaoVien(Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value.ToString()),textBoxTen.Text.Trim(),textBoxLienHe.Text.Trim(), textBoxGhiChu.Text.Trim(), SelectIdCombobox(comboBoxKhoa));

            int x = ctrGiaoVien.UpdateData(ojb);

            if (x < 0)
            {
                MessageBox.Show("sua that bai Giao Vien : " + textBoxTen.Text + " da ton tai");
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

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxTen.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            textBoxLienHe.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            textBoxGhiChu.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            comboBoxKhoa.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            var check = MessageBox.Show("ban co chac muon xoa Giao Vien " + dataGridView.CurrentRow.Cells[1].Value.ToString(), "Xac Nhan", MessageBoxButtons.YesNo);

            if (check == DialogResult.No) return;

            OjbGiaoVien ojb = new OjbGiaoVien(Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value.ToString()), textBoxTen.Text.Trim(), textBoxLienHe.Text.Trim(), textBoxGhiChu.Text.Trim(), SelectIdCombobox(comboBoxKhoa));

            int x = ctrGiaoVien.DeleteData(ojb);

            if (x > 0) MessageBox.Show("xoa thanh cong " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            else if (x == 0) MessageBox.Show("xoa that bai  khong tim thay Giao Vien " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            else MessageBox.Show("xoa that bai  ban phai xoa tat ca cac cac du lieu cua giao vien  " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            Hien();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxTen.Text = "";
            textBoxLienHe.Text = "";
            textBoxGhiChu.Text = "";
            comboBoxKhoa.Text = "";
            Hien();
        }

        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
