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
namespace QLDSV.View
{
    public partial class FormTaiKhoan : Form
    {
        CtrDangNhap ctrDangNhap = new CtrDangNhap();
        public FormTaiKhoan()
        {
            InitializeComponent();
        }


        private void FormTaiKhoan_Load(object sender, EventArgs e)
        {
            setComboBox();
            comboBox.Text = "";
            Hien();
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

        private void Hien()
        {
            try
            {
                dataGridView.Rows.Clear();
                DataTable table = ctrDangNhap.GetData();
                foreach (DataRow row in table.Rows)
                {
                    object[] rowdata = { row["ID"], row["TK"],row["MK"] ,row["Ten"]};
                    dataGridView.Rows.Add(rowdata);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        public void setComboBox()
        {
            DataTable table = ctrDangNhap.GetDataQuyen();
            comboBox.DataSource = table;
            comboBox.DisplayMember = "Ten";
            comboBox.ValueMember = "ID";
        }


        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (textBoxMK.Text == "")
            {
                MessageBox.Show("khong duoc de trong mat khau");
                return;
            }
            if (texBoxTK.Text == "")
            {
                MessageBox.Show("khong duoc de trong Tai Khoan");
                return;
            }

            int x = ctrDangNhap.InsertData(texBoxTK.Text.ToString().Trim(), textBoxMK.Text.ToString().Trim(), SelectIdCombobox(comboBox));

            if (x == -1)
            {
                MessageBox.Show(" Tai Khoan: " + texBoxTK.Text + " da ton tai");
                return;
            }
            else if (x == 0)
            {
                MessageBox.Show(" them  ban ghi Tai Khoan:" + texBoxTK.Text + " that bai, vui long kiem tra lai ket noi", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("them thanh cong Tai Khoan:" + texBoxTK.Text);
            Hien();
        }
        private void buttonSua_Click(object sender, EventArgs e)
        {

            if(texBoxTK.Text.Trim() != dataGridView.CurrentRow.Cells[1].Value.ToString().Trim())
            {
                MessageBox.Show("Bạn không thể sửa tên tài khoản");
                return;
            }
            var check = MessageBox.Show("ban co chac muon sua Tai Khoan " + dataGridView.CurrentRow.Cells[1].Value.ToString(), "Xac Nhan", MessageBoxButtons.YesNo);

            if (check == DialogResult.No) return;

          
            int x = ctrDangNhap.UpdateData(int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()), textBoxMK.Text, SelectIdCombobox(comboBox));

            if (x < 0)
            {
                MessageBox.Show("sua that bai");
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
        private void button4_Click(object sender, EventArgs e)
        {
            var check = MessageBox.Show("ban co chac muon xoa Tai khoan khong");

            if (check == DialogResult.No) return;



            int x = ctrDangNhap.DeleteData(int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()));

            if (x > 0) MessageBox.Show("xoa thanh cong " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            else if (x == 0) MessageBox.Show("xoa that bai  khong tim thay TK" + dataGridView.CurrentRow.Cells[1].Value.ToString());

            else MessageBox.Show("xoa that bai  ban phai xoa tat ca cac dl cua TK truoc" + dataGridView.CurrentRow.Cells[1].Value.ToString());

            Hien();


        }
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            texBoxTK.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            textBoxMK.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            comboBox.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
        }

    }
}
