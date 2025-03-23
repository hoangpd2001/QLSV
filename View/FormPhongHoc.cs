using QLDSV.Control;
using QLDSV.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV.View
{
    public partial class FormPhongHoc : Form
    {
        public FormPhongHoc()
        {
            InitializeComponent();
        }
        CtrPhongHoc ctrPhongHoc= new CtrPhongHoc();
        private void Hien()
        {
            try
            {
                dataGridView.Rows.Clear();
                DataTable table = ctrPhongHoc.GetData();
                foreach (DataRow row in table.Rows)
                {
                    object[] rowdata = { row["ID"], row["TenPhongHoc"], row["ChoNgoi"],row["LoaiPhong"] };
                    dataGridView.Rows.Add(rowdata);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormPhongHoc_Load(object sender, EventArgs e)
        {
            Hien();
            comboBoxLoaiPhong.Items.Add("Thuc Hanh");
            comboBoxLoaiPhong.Items.Add("Ly Thuyet");
                comboBoxLoaiPhong.Items.Add("Tich Hop");

        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (textBoxTenPhongHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong ten Phong Hoc");
                return;
            }
            if (textBoxChoNgoi.Text == "")
            {
                MessageBox.Show("khong duoc de trong So Cho Ngoi");
                return;
            }
             if (comboBoxLoaiPhong.Text == "")
                {
                    MessageBox.Show("khong duoc de trong So Cho Ngoi");
                    return;
             }
                OjbPhongHoc ojb = new OjbPhongHoc(textBoxTenPhongHoc.Text.Trim(), Convert.ToInt32(textBoxChoNgoi.Text),comboBoxLoaiPhong.Text.Trim());

            int x = ctrPhongHoc.InsertData(ojb);

            if (x == -1)
            {
                MessageBox.Show(" ban ghi Phong Hoc" + textBoxTenPhongHoc.Text + " da ton tai");
                return;
            }
            else if (x == 0)
            {
                MessageBox.Show(" them  ban ghi Phong Hoc " + textBoxTenPhongHoc.Text + " that bai, vui long kiem tra lai ket noi", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("them thanh cong Phong Hoc " + textBoxTenPhongHoc.Text);
            Hien();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (comboBoxLoaiPhong.Text == "")
            {
                MessageBox.Show("khong duoc de trong So Cho Ngoi");
                return;
            }
            if (textBoxTenPhongHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong ten Phong Hoc");
                return;
            }
            if (textBoxChoNgoi.Text == "")
            {
                MessageBox.Show("khong duoc de trong So Cho Ngoi");
                return;
            }
            var check = MessageBox.Show("ban co chac muon sua Phong Hoc " + dataGridView.CurrentRow.Cells[1].Value.ToString(), "Xac Nhan", MessageBoxButtons.YesNo);

            if (check == DialogResult.No) return;

            OjbPhongHoc ojb = new OjbPhongHoc(int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()), textBoxTenPhongHoc.Text.Trim(), int.Parse(textBoxChoNgoi.Text), comboBoxLoaiPhong.Text.Trim());

            int x = ctrPhongHoc.UpdateData(ojb);

            if (x < 0)
            {
                MessageBox.Show("sua that bai Phong Hoc: " + textBoxTenPhongHoc.Text + " da ton tai");
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
            var check = MessageBox.Show("ban co chac muon xoa Phong Hoc " + dataGridView.CurrentRow.Cells[1].Value.ToString(), "Xac Nhan", MessageBoxButtons.YesNo);

            if (check == DialogResult.No) return;

            OjbPhongHoc ojb = new OjbPhongHoc(int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()), dataGridView.CurrentRow.Cells[1].Value.ToString().Trim(), Convert.ToInt32(dataGridView.CurrentRow.Cells[2].Value.ToString()), "");

            int x = ctrPhongHoc.DeleteData(ojb);

            if (x > 0) MessageBox.Show("xoa thanh cong " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            else if (x == 0) MessageBox.Show("xoa that bai  khong tim thay Phong Hoc" + dataGridView.CurrentRow.Cells[1].Value.ToString());

            else MessageBox.Show("xoa that bai  ban phai xoa tat ca cac du lieu lien quan den phong hoc nay" + dataGridView.CurrentRow.Cells[1].Value.ToString());

            Hien();
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxTenPhongHoc.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            textBoxChoNgoi.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
        }

      
    }
}
