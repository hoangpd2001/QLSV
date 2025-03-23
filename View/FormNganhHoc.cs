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
    public partial class FormNganhHoc : Form
    {
        CtrNganhHoc ctrNganhHoc = new CtrNganhHoc();
        CtrKhoaHoc ctrKhoaHoc = new CtrKhoaHoc();
        public FormNganhHoc()
        {
            InitializeComponent();
        }

        private void FormNganhHoc_Load(object sender, EventArgs e)
        {
            
            setComboBox();
            comboBoxKhoa.Text = "";
            Hien();
        }


        public void setComboBox()
        {
            DataTable table = ctrKhoaHoc.GetData();
            comboBoxKhoa.DataSource = table;
            comboBoxKhoa.DisplayMember = "TenKhoaHoc";
            comboBoxKhoa.ValueMember = "ID";
        }
        public void Hien()
        {
            DataTable dataTable;
            if (comboBoxKhoa.Text == "")
            {
                dataTable = ctrNganhHoc.GetData();
            }
            else
            {
                
                dataTable = ctrNganhHoc.GetData(SelectIdCombobox(comboBoxKhoa));
            }
            dataGridView.Rows.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                object[] rowdata = { row["ID"], row["TenNganhHoc"], row["TenKhoaHoc"], row["ID_KhoaHoc"]};
                dataGridView.Rows.Add(rowdata);
            }
        }
        private int SelectIdCombobox(ComboBox x)
        {
            DataRowView selectedDataRowView = (DataRowView)x.SelectedItem;
            return Convert.ToInt32(selectedDataRowView["ID"]);
        }

        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hien();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {

            if (textBoxNganh.Text == "")
            {
                MessageBox.Show("khong duoc de trong ten Nganh hoc");
                return;
            }
            if (comboBoxKhoa.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Khoa Hoc");
                return;
            }
            OjbNganhHoc ojb = new OjbNganhHoc(textBoxNganh.Text.Trim(), SelectIdCombobox(comboBoxKhoa));

            int x = ctrNganhHoc.InsertData(ojb);

            if (x == -1)
            {
                MessageBox.Show(" ban ghi Nganh Hoc: " + textBoxNganh.Text + " da ton tai");
                return;
            }
            else if (x == 0)
            {
                MessageBox.Show(" them  ban ghi Nganh Hoc: " + textBoxNganh.Text + " that bai, vui long kiem tra lai ket noi", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("them thanh cong Nganh Hoc: " + textBoxNganh.Text);
            Hien();
        }
        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (textBoxNganh.Text == "")
            {
                MessageBox.Show("khong duoc de trong ten Nganh hoc");
                return;
            }
            if (comboBoxKhoa.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Khoa Hoc");
                return;
            }
            var check = MessageBox.Show("ban co chac muon sua NganhHoc: " + dataGridView.CurrentRow.Cells[1].Value.ToString() +" thanh : "+ textBoxNganh.Text+" khong", "Xac Nhan", MessageBoxButtons.YesNo);

            if (check == DialogResult.No) return;

           
            OjbNganhHoc ojb = new OjbNganhHoc(int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()), textBoxNganh.Text.Trim(), SelectIdCombobox(comboBoxKhoa));

            int x = ctrNganhHoc.UpdateData(ojb);

            if (x < 0)
            {
                MessageBox.Show("sua that bai Nganh : " + textBoxNganh.Text + " da ton tai");
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
            var check = MessageBox.Show("ban co chac muon xoa NganhHoc " + dataGridView.CurrentRow.Cells[1].Value.ToString(), "Xac Nhan", MessageBoxButtons.YesNo);

            if (check == DialogResult.No) return;

            OjbNganhHoc ojb = new OjbNganhHoc(int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()), dataGridView.CurrentRow.Cells[1].Value.ToString(), SelectIdCombobox(comboBoxKhoa));

            int x = ctrNganhHoc.DeleteData(ojb);

            if (x > 0) MessageBox.Show("xoa thanh cong " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            else if (x == 0) MessageBox.Show("xoa that bai  khong tim thay Nganh Hoc " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            else MessageBox.Show("xoa that bai  ban phai xoa tat ca cac Hoc ki cua Nganh hoc " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            Hien();

        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            comboBoxKhoa.Text = "";
            textBoxNganh.Text = "";
            Hien();
        }
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBoxKhoa.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            textBoxNganh.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
        }

    }
}
