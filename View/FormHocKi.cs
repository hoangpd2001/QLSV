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
    public partial class FormHocKi : Form
    {
        CtrHocKy ctrHocKy = new CtrHocKy();
        CtrKhoaHoc ctrKhoaHoc = new CtrKhoaHoc();
        CtrNganhHoc ctrNganhHoc = new CtrNganhHoc();
        public FormHocKi()
        {
            InitializeComponent();
        }

        private void FormHocKi_Load(object sender, EventArgs e)
        {
            setComboBox();
            comboBoxKhoaHoc.Text = "";
            comboNganhHoc.Text = "";
            Hien();
        }


        public void Hien()
        {
            DataTable dataTable;
            if (comboBoxKhoaHoc.Text == "")
            {
                dataTable = ctrHocKy.GetData();
            }
            else
            {
               if(comboNganhHoc.Text == "")
                {
                    dataTable = ctrHocKy.GetData(SelectIdCombobox(comboBoxKhoaHoc),0);
                }
                else
                {
                    dataTable = ctrHocKy.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboNganhHoc));
                }
            }
            dataGridView.Rows.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                object[] rowdata = { row["ID"], row["TenHocKy"], row["TenNganhHoc"], row["TenKhoaHoc"] };
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
                MessageBox.Show("du lieu khong hop le, vui long kiem tra lai lua chon " , " loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return y;
        }


        private void comboBoxKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = ctrNganhHoc.GetData(SelectIdCombobox(comboBoxKhoaHoc));
            comboNganhHoc.DataSource = table;
            comboNganhHoc.DisplayMember = "TenNganhHoc";
            comboNganhHoc.ValueMember = "ID";
            comboNganhHoc.Text = "";
            Hien();

        }
        private void comboNganhHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hien();
        }


        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBoxKhoaHoc.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            comboNganhHoc.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            textBoxHocKy.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
        }


        private void Sua_Click(object sender, EventArgs e)
        {
            if (textBoxHocKy.Text == "")
            {
                MessageBox.Show("khong duoc de trong ten Hoc Ky");
                return;
            }
            if (comboBoxKhoaHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Khoa Hoc");
                return;
            }
            if (comboNganhHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Nganh Hoc");
                return;
            }
            var check = MessageBox.Show("ban co chac muon sua Hoc Ki: " + dataGridView.CurrentRow.Cells[1].Value.ToString() + " thanh : " + textBoxHocKy.Text + " khong", "Xac Nhan", MessageBoxButtons.YesNo);

            if (check == DialogResult.No) return;


            OjbHocKy ojb = new OjbHocKy(int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()), textBoxHocKy.Text.Trim(), SelectIdCombobox(comboNganhHoc));

            int x = ctrHocKy.UpdateData(ojb);

            if (x < 0)
            {
                MessageBox.Show("sua that bai Hoc Ky: " + textBoxHocKy.Text + " da ton tai");
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
        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (textBoxHocKy.Text == "")
            {
                MessageBox.Show("khong duoc de trong ten Hoc Ky");
                return;
            }
            if (comboBoxKhoaHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Khoa Hoc");
                return;
            }
            if (comboNganhHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Nganh Hoc");
                return;
            }
            OjbHocKy ojb = new OjbHocKy(textBoxHocKy.Text.Trim(), SelectIdCombobox(comboNganhHoc));

            int x = ctrHocKy.InsertData(ojb);

            if (x == -1)
            {
                MessageBox.Show(" ban ghi Hoc Ky: " + textBoxHocKy.Text + " da ton tai");
                return;
            }
            else if (x == 0)
            {
                MessageBox.Show(" them  ban ghi Hoc Ky: " + textBoxHocKy.Text + " that bai, vui long kiem tra lai ket noi", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("them thanh cong Hoc Ky: " + textBoxHocKy.Text);
            Hien();
        }
        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            var check = MessageBox.Show("ban co chac muon xoa HocKy " + dataGridView.CurrentRow.Cells[1].Value.ToString(), "Xac Nhan", MessageBoxButtons.YesNo);

            if (check == DialogResult.No) return;

            OjbHocKy ojb = new OjbHocKy(int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()), dataGridView.CurrentRow.Cells[1].Value.ToString(), SelectIdCombobox(comboNganhHoc));

            int x = ctrHocKy.DeleteData(ojb);

            if (x > 0) MessageBox.Show("xoa thanh cong " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            else if (x == 0) MessageBox.Show("xoa that bai  khong tim thay Hoc Ki " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            else MessageBox.Show("xoa that bai  ban phai xoa tat ca cac du lieu lien quan toi Hoc ki: " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            Hien();
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            comboBoxKhoaHoc.Text = "";
            comboNganhHoc.Text = "";
            textBoxHocKy.Text = "";
            Hien();
        }
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


      
    
}
