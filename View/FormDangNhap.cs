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
namespace QLDSV
{
    public partial class FormDangNhap : Form
    {
        CtrDangNhap ctrDangNhap = new CtrDangNhap();
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Không được để trống tài khoản mật khẩu");
                return;
            }
            DataTable table = ctrDangNhap.dangNhap(textBox1.Text, textBox2.Text);
            if (table == null || table.Rows.Count == 0)
            {
                MessageBox.Show("Đăng nhập thất bại!! Sai tài khoản hoặc mật khẩu");
                return;
            }
            else
            {
                DataRow row = table.Rows[0];
                CtrDangNhap.quyen = int.Parse(row[1].ToString());
                CtrDangNhap.StrQuyen = row[2].ToString();
                CtrDangNhap.CheckDangNhap = true;
                FormMDI.label2.Text = CtrDangNhap.StrQuyen;
                MessageBox.Show("Đăng Nhập thành công");
                this.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CtrDangNhap.quyen = 0;
            CtrDangNhap.StrQuyen = "Chưa đăng nhập";
            CtrDangNhap.CheckDangNhap = false;
            MessageBox.Show("Đăng xuất thành công");
            FormMDI.label2.Text = CtrDangNhap.StrQuyen;
            this.Close();
        }
    }
}
