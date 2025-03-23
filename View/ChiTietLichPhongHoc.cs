using QLDSV.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDSV.Report;
using QLDSV.Object;
namespace QLDSV.View
{
    public partial class ChiTietLichPhongHoc : Form
    {
        public ChiTietLichPhongHoc()
        {
            InitializeComponent();
        }
        CtrLichDay ctrLichDay = new CtrLichDay();
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable data = ctrLichDay.GetData(dateTimePicker1.Value, comboBox1.Text);
            try
            {
                dataGridView1.Rows.Clear();
              
                foreach (DataRow row in data.Rows)
                {
                    object[] rowdata = { row["TenPhongHoc"], row["LoaiPhong"] };
                    dataGridView1.Rows.Add(rowdata);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void ChiTietLichPhongHoc_Load(object sender, EventArgs e)
        {

        }
    }
}
