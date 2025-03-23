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
    public partial class FormKhoaHoc : Form
    {
        CtrKhoaHoc ctrKhoaHoc = new CtrKhoaHoc();


        public FormKhoaHoc()
        {
            InitializeComponent();
        }


        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (textBoxKhoa.Text == "")
            {
                MessageBox.Show("khong duoc de trong ten khoa hoc");
                return;
            }
            OjbKhoaHoc ojb = new OjbKhoaHoc(textBoxKhoa.Text.Trim());

            int x = ctrKhoaHoc.InsertData(ojb);

            if (x == -1)
            {
                MessageBox.Show(" ban ghi khoa hoc " + textBoxKhoa.Text + " da ton tai");
                return;
            }else if(x == 0)
            {
                MessageBox.Show(" them  ban ghi khoa hoc " + textBoxKhoa.Text + " that bai, vui long kiem tra lai ket noi", "Loi",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("them thanh cong khoa hoc " + textBoxKhoa.Text);
            Hien();
        }
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            var check = MessageBox.Show("ban co chac muon xoa khoa hoc "+ dataGridView.CurrentRow.Cells[1].Value.ToString(), "Xac Nhan", MessageBoxButtons.YesNo);

            if (check == DialogResult.No) return;

            OjbKhoaHoc ojb = new OjbKhoaHoc(int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()), dataGridView.CurrentRow.Cells[1].Value.ToString().Trim());

            int x = ctrKhoaHoc.DeleteData(ojb);

            if (x > 0) MessageBox.Show("xoa thanh cong " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            else if (x == 0) MessageBox.Show("xoa that bai  khong tim thay khoa hoc " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            else MessageBox.Show("xoa that bai  ban phai xoa tat ca cac nganh hoc cua khoa hoc " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            Hien();

        }
        private void buttonSua_Click(object sender, EventArgs e)
        {
            var check = MessageBox.Show("ban co chac muon sua khoa hoc " + dataGridView.CurrentRow.Cells[1].Value.ToString(), "Xac Nhan", MessageBoxButtons.YesNo);

            if (check == DialogResult.No) return;

            OjbKhoaHoc ojb = new OjbKhoaHoc(int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()), textBoxKhoa.Text.Trim());

            int x = ctrKhoaHoc.UpdateData(ojb);

            if (x < 0)
            { 
                MessageBox.Show("sua that bai khoa: " + textBoxKhoa.Text + " da ton tai");
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
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Hien()
        {
            try
            {
                dataGridView.Rows.Clear();
                DataTable table = ctrKhoaHoc.GetData();
                foreach (DataRow row in table.Rows)
                {
                    object[] rowdata = { row["ID"], row["TenKhoaHoc"] };
                    dataGridView.Rows.Add(rowdata);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void FormKhoaHoc_Load(object sender, EventArgs e)
        {
            Hien();
            textBoxKhoa.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                textBoxKhoa.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
