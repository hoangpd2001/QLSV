using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;
using ExcelDataReader;
using System.IO;
using QLDSV.Control;
using QLDSV.Object;
namespace QLDSV
{
    public partial class Form1 : Form
    {


        CtrHocKy ctrHocKy = new CtrHocKy();
        CtrKhoaHoc ctrKhoaHoc = new CtrKhoaHoc();
        CtrNganhHoc ctrNganhHoc = new CtrNganhHoc();
        CtrHinhThuc ctrHinhThuc = new CtrHinhThuc();
        CtrMonHoc ctrMonHoc = new CtrMonHoc();
        public Form1()
        {
            InitializeComponent();
        }
        CTR ctr = new CTR();
        private void Form1_Load(object sender, EventArgs e)
        {
            setComboBox();
            setComboBox2();
            comboBox1.Text = "";
        }
      
        public void setComboBox()
        {
            DataTable table = ctrKhoaHoc.GetData();
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "TenKhoaHoc";
            comboBox1.ValueMember = "ID";
          
        }
        public void setComboBox2()
        {
            DataTable table = ctrKhoaHoc.GetData();
            comboBox2.DataSource = table;
            comboBox2.DisplayMember = "TenKhoaHoc";
            comboBox2.ValueMember = "ID";

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

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tableCheck = ctrNganhHoc.GetData(SelectIdCombobox(comboBox2));
            if(tableCheck == null)
            {
                MessageBox.Show("khoa hoc: " + SelectIdCombobox(comboBox2) + " da co du lieu, de dam bao an toan du lieu vui long chi chon nhung khoa hoc chua co du lieu","LOI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tableCheck.Rows.Count >0)
            {
                MessageBox.Show("khoa hoc: " + SelectIdCombobox(comboBox2) + " da co du lieu, de dam bao an toan du lieu vui long chi chon nhung khoa hoc chua co du lieu", "LOI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DataTable tableNganhHoc = ctrNganhHoc.GetData(SelectIdCombobox(comboBox1));
                foreach (DataRow rowNganhHoc in tableNganhHoc.Rows)
                {
                    OjbNganhHoc ojbNganhHoc = new OjbNganhHoc(rowNganhHoc["TenNganhHoc"].ToString(), SelectIdCombobox(comboBox2));
                    ctrNganhHoc.InsertData(ojbNganhHoc);
                    int IDNganhHoc = ctrNganhHoc.GetIDNganh(SelectIdCombobox(comboBox2), rowNganhHoc["TenNganhHoc"].ToString());
                    DataTable tableHocKy = ctrHocKy.GetData(SelectIdCombobox(comboBox1), int.Parse(rowNganhHoc["ID"].ToString()));

                    //lap dung dong hoc ki
                    foreach (DataRow rowHocKy in tableHocKy.Rows)
                    {
                        OjbHocKy ojbHocKy = new OjbHocKy(rowHocKy["TenHocKy"].ToString(), IDNganhHoc);
                        ctrHocKy.InsertData(ojbHocKy);
                        int IdHocKy = ctrHocKy.GetIDNganh(IDNganhHoc, rowHocKy["TenHocKy"].ToString());
                        DataTable tableHinhThuc = ctrHinhThuc.GetData(SelectIdCombobox(comboBox1), int.Parse(rowNganhHoc["ID"].ToString()), int.Parse(rowHocKy["ID"].ToString()));


                        //lap tung dong hinh thuc
                        foreach (DataRow rowHinhThuc in tableHinhThuc.Rows)
                        {
                            OjbHinhThuc ojbHinhThuc = new OjbHinhThuc(rowHinhThuc["TenHinhThuc"].ToString(), IdHocKy);
                            ctrHinhThuc.InsertData(ojbHinhThuc);
                            int IdHinhThuc = ctrHinhThuc.GetIDNganh(IdHocKy, rowHinhThuc["TenHinhThuc"].ToString());
                            DataTable tableMonHoc = ctrMonHoc.GetData(SelectIdCombobox(comboBox1), int.Parse(rowNganhHoc["ID"].ToString()), int.Parse(rowHocKy["ID"].ToString()), int.Parse(rowHinhThuc["ID"].ToString()));


                            //Lap tung dong mon hoc
                            foreach (DataRow rowMonHoc in tableMonHoc.Rows)
                            {
                                OjbMonHoc ojbMonHoc = new OjbMonHoc(rowMonHoc["TenMonHoc"].ToString(), int.Parse(rowMonHoc["SoGioLT"].ToString()), int.Parse(rowMonHoc["SoGioTH"].ToString()), IdHinhThuc);
                                ctrMonHoc.InsertData(ojbMonHoc);

                            }

                        }

                    }

                }
            }catch(Exception ex)
            {
                MessageBox.Show("nhap du lieu That Bai");
            }
            MessageBox.Show("nhap du lieu thanh cong");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

