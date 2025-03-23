using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDSV.Control;
using QLDSV.Object;
namespace QLDSV.View
{
    public partial class FromInsertDiem : Form

    {
        CTR ctr = new CTR();
        CtrHocKy ctrHocKy = new CtrHocKy();
        CtrKhoaHoc ctrKhoaHoc = new CtrKhoaHoc();
        CtrNganhHoc ctrNganhHoc = new CtrNganhHoc();
        CtrHinhThuc ctrHinhThuc = new CtrHinhThuc();
        CtrMonHoc ctrMonHoc = new CtrMonHoc();
        CtrLopHoc ctrLopHoc = new CtrLopHoc();
        CtrSinhVien ctrSinhVien = new CtrSinhVien();
        CtrDiem ctrDiem = new CtrDiem();
        bool check = false;
        public FromInsertDiem()
        {
            InitializeComponent();
        }

        private void FromInsertDiem_Load(object sender, EventArgs e)
        {
            setComboBox();
            comboBoxKhoaHoc.Text = "";
            comboBoxNganhHoc.Text = "";
            comboBoxLopHoc.Text = "";
        }

        public void Hien()
        {
            DataTable dataTable;
            if (comboBoxKhoaHoc.Text == "")
            {
                dataTable = null;
            }
            else
            {
                if (comboBoxNganhHoc.Text == "")
                {
                    dataTable = null;
                }
                else
                {
                    if (comboBoxLopHoc.Text == "")
                    {
                        dataTable = null;
                    }
                    else
                    {
                        dataTable = ctrSinhVien.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc), SelectIdCombobox(comboBoxLopHoc));
                    }
                }
            }
            dataGridView.Rows.Clear();
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    DateTime ngaySinh = (DateTime)row["NgaySinh"];
                    string formattedNgaySinh = ngaySinh.ToString("dd-MM-yyyy");
                    object[] rowdata = { row["ID"], row["MaSinhVien"], row["TenSinhVien"] };
                    dataGridView.Rows.Add(rowdata);
                }
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

        }
        private void comboBoxNganhHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = ctrLopHoc.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc));
            comboBoxLopHoc.DataSource = table;
            comboBoxLopHoc.DisplayMember = "TenLopHoc";
            comboBoxLopHoc.ValueMember = "ID";
            DataTable table2 = ctrHocKy.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc));
            comboBoxHocKy.DataSource = table2;
            comboBoxHocKy.DisplayMember = "TenHocKy";
            comboBoxHocKy.ValueMember = "ID";
            comboBoxHocKy.Text = "";
        }
        private void comboBoxLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hien();
        }
        private void comboBoxHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = ctrHinhThuc.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc), SelectIdCombobox(comboBoxHocKy));
            comboBoxHinhThuc.DataSource = table;
            comboBoxHinhThuc.DisplayMember = "TenHinhThuc";
            comboBoxHinhThuc.ValueMember = "ID";
            comboBoxHinhThuc.Text = "";
        }
        private void comboBoxHinhThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = ctrMonHoc.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc), SelectIdCombobox(comboBoxHocKy), SelectIdCombobox(comboBoxHinhThuc));
            comboBoxMonHoc.DataSource = table;
            comboBoxMonHoc.DisplayMember = "TenMonHoc";
            comboBoxMonHoc.ValueMember = "ID";
            comboBoxMonHoc.Text = "";
        }
        private void comboBoxMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Excel File Only | *.xlsx; *.xls";
            op.Title = " chon file";

            if (op.ShowDialog() == DialogResult.OK)
            {
                label1.Text = op.FileName;
            }
            check = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            if (label1.Text == "")
            {
                MessageBox.Show(" Vui long chon FILE can nhap"); return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Vui long nhap ten sheet cua file"); return;
            }
            var table = ctr.ReadExcel(label1.Text, textBox1.Text);
            if (table == null)
            {
                MessageBox.Show("Loi khong doc duoc du lieu tu file, vui long kiem tra lai", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dataGridView2.DataSource = table;
            check = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
          /*  if (!check || dataGridView2 == null)
            {
                MessageBox.Show(" vui long chon xem truoc khi nha du lieu");
                return;
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
            if (comboBoxHocKy.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Hoc Ky"); return;
            }
            if (comboBoxLopHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Lop"); return;
            }
            if (comboBoxMonHoc.Text == "")
            {
                MessageBox.Show("khong duoc de trong Ten Mon Hoc"); return;
            }
            DataTable tableCheck = ctrDiem.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc), SelectIdCombobox(comboBoxHocKy),SelectIdCombobox(comboBoxHinhThuc), SelectIdCombobox(comboBoxMonHoc), SelectIdCombobox(comboBoxLopHoc),0);
            if (tableCheck == null)
            {
                MessageBox.Show(" Loi");
                return;
            }
            if (tableCheck.Rows.Count > 0)
            {
                MessageBox.Show("Lop Hoc da duoc nhap Diem mon hoc nay truoc do, de dam bao an toan du lieu vui long chi nhap nhung lop chua co diem");
                return;
            }
            DataTable table = dataGridView2.DataSource as DataTable;
            int count = 0;
            foreach (DataRow row in table.Rows)
            {
                int idSinhVien = ctrSinhVien.GetDataID(SelectIdCombobox(comboBoxLopHoc), row[0].ToString());
                if (idSinhVien != 0)
                {
                    OjbDiem ojb = new OjbDiem(idSinhVien, SelectIdCombobox(comboBoxMonHoc), int.Parse(row[1].ToString()),1);
                    int x = 0; //ctrDiem.InsertData(ojb);
                    // Kiem tra qua trinh nhap co thanh cong hay khong 
                    if (x == -1)
                    {
                        var res = MessageBox.Show("Sinh Vien :" + row[0] + " da co diem  trong csld co  muon bo qua sinh vien nay va tiep tuc nhap khong", "Loi", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (res == DialogResult.Yes) continue;
                        else
                        {
                            var res2 = MessageBox.Show("Ban co muon giu lai diem cua :" + count + " sinh vien da nhap diem thanh cong khong?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (res2 == DialogResult.Yes) break;
                            else
                            {
                                int c = ctrDiem.DeleteDataAll(SelectIdCombobox(comboBoxLopHoc), SelectIdCombobox(comboBoxMonHoc));
                                if (c > 0) MessageBox.Show("Da xoa thanh cong");
                                else { MessageBox.Show("xoa That Bai"); }
                            }
                            break;
                        }
                    }

                    if (x == 0)
                    {
                        var res = MessageBox.Show("Sinh Vien :" + row[0] + " That Bai co  muon bo qua sinh vien nay va tiep tuc nhap khong", "Loi", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (res == DialogResult.Yes) continue;
                        else
                        {
                            var res2 = MessageBox.Show("Ban co muon giu lai:" + count + " sinh vien da nhap thanh cong khong?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (res2 == DialogResult.Yes) break;
                            else
                            {
                                int c = ctrDiem.DeleteDataAll(SelectIdCombobox(comboBoxLopHoc), SelectIdCombobox(comboBoxMonHoc));
                                if (c > 0) MessageBox.Show("Da xoa thanh cong");
                                else { MessageBox.Show("xoa That Bai"); }
                            }
                            break;
                        }
                    }
                    if (x > 0) { count++; continue; };
                }
                else
                {
                    var res = MessageBox.Show("Sinh Vien :" + row[0] + " khong ton tai ban co muon tiep tuc nhap khong", "Loi", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (res == DialogResult.Yes) continue;
                    else
                    {
                        var res2 = MessageBox.Show("Ban co muon giu lai diem cua :" + count + " sinh vien da nhap diem thanh cong khong?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res2 == DialogResult.Yes) break;
                        else
                        {
                            int c = ctrDiem.DeleteDataAll(SelectIdCombobox(comboBoxLopHoc), SelectIdCombobox(comboBoxMonHoc));
                            if (c > 0) MessageBox.Show("Da xoa thanh cong");
                            else { MessageBox.Show("xoa That Bai"); }
                        }
                        break;
                    }
                }
            }
            MessageBox.Show("Nhập hoàn tất , Nhập thành công:" + count);
*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            check = false;
        }
    }
}
