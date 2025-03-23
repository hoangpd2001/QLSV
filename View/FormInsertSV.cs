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
    public partial class FormInsertSV : Form
    {
        CTR ctr = new CTR();
        CtrKhoaHoc ctrKhoaHoc = new CtrKhoaHoc();
        CtrNganhHoc ctrNganhHoc = new CtrNganhHoc();
        CtrLopHoc ctrLopHoc = new CtrLopHoc();
        CtrSinhVien ctrSinhVien = new CtrSinhVien();
        bool check = false;
        public FormInsertSV()
        {
            InitializeComponent();
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
        private void FormInsertSV_Load(object sender, EventArgs e)
        {
            setComboBox();
            comboBoxKhoaHoc.Text = "";
            comboBoxNganhHoc.Text = "";
            comboBoxLopHoc.Text = "";

        }
        private void comboBoxKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = ctrNganhHoc.GetData(SelectIdCombobox(comboBoxKhoaHoc));
            comboBoxNganhHoc.DataSource = table;
            comboBoxNganhHoc.DisplayMember = "TenNganhHoc";
            comboBoxNganhHoc.ValueMember = "ID";
            comboBoxNganhHoc.Text = "";
        }
        private void comboBoxNganhHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = ctrLopHoc.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc));
            comboBoxLopHoc.DataSource = table;
            comboBoxLopHoc.DisplayMember = "TenLopHoc";
            comboBoxLopHoc.ValueMember = "ID";
            comboBoxLopHoc.Text = "";
        }
        private void comboBoxLopHoc_SelectedIndexChanged(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (!check || dataGridView1 == null)
            {
                MessageBox.Show(" vui long chon xem truoc khi nha du lieu");
                return;
            }
            if (comboBoxKhoaHoc.Text == "")
            {
                MessageBox.Show(" vui long chon khoa hoc");
                return;
            }
            if (comboBoxNganhHoc.Text == "")
            {
                MessageBox.Show(" vui long chon Nganh Hoc");
                return;
            }
            if (comboBoxLopHoc.Text == "")
            {
                MessageBox.Show(" vui long chon Lop Hoc");
                return;
            }
            DataTable tableCheck = ctrSinhVien.GetData(SelectIdCombobox(comboBoxKhoaHoc), SelectIdCombobox(comboBoxNganhHoc), SelectIdCombobox(comboBoxLopHoc));
            if(tableCheck == null)
            {
                MessageBox.Show(" Lop Hoc da duoc nhap thong tin sinh vien truoc do, de dam bao an toan du lieu vui long luu lai thong tin sinh vien cua lop hoc do roi xoa tat ca sinh vien da duoc nhap");
                return;
            }
            if (tableCheck.Rows.Count>0)
            {
                MessageBox.Show(" Lop Hoc da duoc nhap thong tin sinh vien truoc do, de dam bao an toan du lieu vui long luu lai thong tin sinh vien cua lop hoc do roi xoa tat ca sinh vien da duoc nhap");
                return;
            }
            DataTable table = dataGridView1.DataSource as DataTable;
            int count = 0;
            foreach(DataRow row in table.Rows)
            {
                string ngaySinhString = row[2].ToString();
                DateTime ngaySinh = DateTime.ParseExact(ngaySinhString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                OjbSinhVien ojb = new OjbSinhVien(row[0].ToString(), row[1].ToString(), ngaySinh, SelectIdCombobox(comboBoxLopHoc));
                int x =ctrSinhVien.InsertData(ojb);
                // Kiem tra qua trinh nhap co thanh cong hay khong 
                if (x == -1) {
                   var res =  MessageBox.Show("Sinh Vien :"+row[0] +" da ton tai trong csld co  muon bo qua sinh vien nay va tiep tuc nhap khong","Loi",MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (res == DialogResult.Yes) continue;
                    else
                    {
                        var res2 = MessageBox.Show("Ban co muon giu lai:"+count+" sinh vien da nhap thanh cong khong?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res2 == DialogResult.Yes) break;
                        else
                        {
                            int c =ctrSinhVien.DeleteDataAll(SelectIdCombobox(comboBoxLopHoc));
                            if(c> 0) MessageBox.Show("Da xoa thanh cong");
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
                            int c = ctrSinhVien.DeleteDataAll(SelectIdCombobox(comboBoxLopHoc));
                            if (c > 0) MessageBox.Show("Da xoa thanh cong");
                            else { MessageBox.Show("xoa That Bai"); }
                        }
                        break;
                    }
                }
                if (x > 0) { continue; };
            }
            MessageBox.Show("Nhập hoàn tất , Nhập thành công:" + count);
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            if(label1.Text == "")
            {
                MessageBox.Show(" Vui long chon FILE can nhap");return;
            }
            if(textBox1.Text == "")
            {
                MessageBox.Show("Vui long nhap ten sheet cua file");return;
            }
            var table = ctr.ReadExcel(label1.Text, textBox1.Text);
            if(table == null)
            {
                MessageBox.Show("Loi khong doc duoc du lieu tu file, vui long kiem tra lai", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dataGridView1.DataSource = table;
            check = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            check = false;
        }
    }
}
