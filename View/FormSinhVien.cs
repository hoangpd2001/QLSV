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
    public partial class FormSinhVien : Form
    {
        CTR ctr = new CTR();
        CtrKhoaHoc ctrKhoaHoc = new CtrKhoaHoc();
        CtrNganhHoc ctrNganhHoc = new CtrNganhHoc();
        CtrLopHoc ctrLopHoc = new CtrLopHoc();
        CtrSinhVien ctrSinhVien = new CtrSinhVien();
        public FormSinhVien()
        {
            InitializeComponent();
        }
        private void FormSinhVien_Load(object sender, EventArgs e)
        {
            setComboBox();
            comboBoxKhoaHoc.Text = "";
            comboBoxNganhHoc.Text = "";
            comboBoxLopHoc.Text = "";
            Hien();
        }

        public void Hien()
        {
            DataTable dataTable;
            if (comboBoxKhoaHoc.Text == "")
            {
                dataTable = ctrSinhVien.GetData();
            }
            else
            {
                if (comboBoxNganhHoc.Text == "")
                {
                    dataTable = ctrSinhVien.GetData(SelectIdCombobox(comboBoxKhoaHoc), 0, 0);
                }
                else
                {
                    if (comboBoxLopHoc.Text == "")
                    {
                        dataTable = ctrSinhVien.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc), 0);
                    }
                    else
                    {
                        dataTable = ctrSinhVien.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc), SelectIdCombobox(comboBoxLopHoc));
                    }
                }
            }
            dataGridView.Rows.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                DateTime ngaySinh = (DateTime)row["NgaySinh"];
                string formattedNgaySinh = ngaySinh.ToString("dd-MM-yyyy");
                object[] rowdata = { row["ID"], row["MaSinhVien"],row["TenSinhVien"], formattedNgaySinh, row["TenLopHoc"], row["TenNganhHoc"], row["TenKhoaHoc"] };
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
            DataTable table = ctrLopHoc.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc));
            comboBoxLopHoc.DataSource = table;
            comboBoxLopHoc.DisplayMember = "TenLopHoc";
            comboBoxLopHoc.ValueMember = "ID";
            comboBoxLopHoc.Text = "";
            Hien();
        }
        private void comboBoxLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hien();
        }




        private void buttonReset_Click(object sender, EventArgs e)
        {
            comboBoxKhoaHoc.Text = "";
            comboBoxNganhHoc.Text = "";
            comboBoxLopHoc.Text = "";
            textBoxMSV.Text = "";
            textBoxTenSV.Text = "";
            Hien();
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (textBoxMSV.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ma Sinh Vien"); return;
            }
            if (textBoxTenSV.Text == "")
            {
                MessageBox.Show("khong duoc de trong ten Sinh Vien"); return;
            }
            if (comboBoxKhoaHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Khoa Hoc"); return;
            }
            if (comboBoxNganhHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Nganh Hoc"); return;
            }
            if (comboBoxLopHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Lop"); return;
            }
            OjbSinhVien ojb = new OjbSinhVien(textBoxMSV.Text.Trim(), textBoxTenSV.Text.Trim(), dateTimePicker.Value, SelectIdCombobox(comboBoxLopHoc));

            int x = ctrSinhVien.InsertData(ojb);

            if (x == -1)
            {
                MessageBox.Show(" ban ghi SinhVien: " + textBoxMSV.Text + " da ton tai");
                return;
            }
            else if (x == 0)
            {
                MessageBox.Show(" them  ban ghi SinhVien: " + textBoxMSV.Text + " that bai, vui long kiem tra lai ket noi", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("them thanh cong Sinh Vien " + textBoxMSV.Text);
            Hien();
        }
        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (textBoxMSV.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ma Sinh Vien"); return;
            }
            if (textBoxTenSV.Text == "")
            {
                MessageBox.Show("khong duoc de trong ten Sinh Vien"); return;
            }
            if (comboBoxKhoaHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Khoa Hoc"); return;
            }
            if (comboBoxNganhHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Nganh Hoc"); return;
            }
            if (comboBoxLopHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Lop"); return;
            }
            var check = MessageBox.Show("ban co chac muon sua Sinh Vien: " + dataGridView.CurrentRow.Cells[1].Value.ToString()  + " khong", "Xac Nhan", MessageBoxButtons.YesNo);

            if (check == DialogResult.No) return;


            OjbSinhVien ojb = new OjbSinhVien(int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()), textBoxMSV.Text.Trim(), textBoxTenSV.Text.Trim(), dateTimePicker.Value, SelectIdCombobox(comboBoxLopHoc));

            int x = ctrSinhVien.UpdateData(ojb);

            if (x < 0)
            {
                MessageBox.Show("sua that bai Sinh Vien: " + textBoxMSV.Text + " da ton tai");
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
            var check = MessageBox.Show("ban co chac muon xoa Sinh Vien " + dataGridView.CurrentRow.Cells[1].Value.ToString(), "Xac Nhan", MessageBoxButtons.YesNo);

            if (check == DialogResult.No) return;

            OjbSinhVien ojb = new OjbSinhVien(int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()), textBoxMSV.Text.Trim(), textBoxTenSV.Text.Trim(), dateTimePicker.Value, SelectIdCombobox(comboBoxLopHoc));

            int x = ctrSinhVien.DeleteData(ojb);

            if (x > 0) MessageBox.Show("xoa thanh cong " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            else if (x == 0) MessageBox.Show("xoa that bai  khong tim thay Sinh Vien: " + dataGridView.CurrentRow.Cells[1].Value.ToString());

            else MessageBox.Show("xoa that bai  ban phai xoa tat ca cac du lieu lien quan toi Sinh Vien: " + dataGridView.CurrentRow.Cells[1].Value.ToString() );

            Hien();
        }
        private void buttonThoat_Click(object sender, EventArgs e)
        {

        }




        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBoxKhoaHoc.Text = dataGridView.CurrentRow.Cells[6].Value.ToString();
            comboBoxNganhHoc.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            comboBoxLopHoc.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
            textBoxMSV.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            textBoxTenSV.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            string dateString = dataGridView.CurrentRow.Cells[3].Value.ToString();
            DateTime dateTimeValue;
            if (DateTime.TryParse(dateString, out dateTimeValue))
            {
                dateTimePicker.Value = dateTimeValue;
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
