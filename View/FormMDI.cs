using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDSV.View;
using QLDSV.Report;
using QLDSV.Control;
namespace QLDSV
{
    public partial class FormMDI : Form
    {
        CtrDangNhap CtrDangNhap = new CtrDangNhap();
        public FormMDI()
        {
            InitializeComponent();
        }

        private void FormMDI_Load(object sender, EventArgs e)
        {
            check();
        }

        private void diemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDiem F = new FormDiem();
            F.MdiParent = this;
            F.Show();
        }

     
        private void khóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKhoaHoc F = new FormKhoaHoc();
            F.MdiParent = this;
            F.Show();
           // this.Close();
        }

        private void ngànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNganhHoc F = new FormNganhHoc();
            F.MdiParent = this;
            F.Show();
        }

        private void họcKìToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHocKi F = new FormHocKi();
            F.MdiParent = this;
            F.Show();
        }

        private void hinhThucToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHinhThuc F = new FormHinhThuc();
            F.MdiParent = this;
            F.Show();
        }

        private void mônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMonHoc F = new FormMonHoc();
            F.MdiParent = this;
            F.Show();
        }

        private void lớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLopHoc F = new FormLopHoc();
            F.MdiParent = this;
            F.Show();
        }

        private void sInhVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSinhVien F = new FormSinhVien();
            F.MdiParent = this;
            F.Show();
        }

        private void sinhVienToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormInsertSV F = new FormInsertSV();
            F.MdiParent = this;
            F.Show();
        }

        private void asToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 F = new Form1();
            F.MdiParent = this;
            F.Show();
        }

        private void diemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FromInsertDiem F = new FromInsertDiem();
            F.MdiParent = this;
            F.Show();
        }

        private void bảngĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*FormReport F = new FormReport();
            F.MdiParent = this;
            F.Show();*/
        }

        private void dsChưaQuaMônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDiemLop F = new FormDiemLop();
            F.MdiParent = this;
            F.Show();
        }

        private void danhSáchSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSinhVienLop F = new FormSinhVienLop();
            F.MdiParent = this;
            F.Show();
        }

        private void danhSáchLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormLopKhoa F = new FormLopKhoa();
            F.MdiParent = this;
            F.Show();
        }

        private void danhSáchMônNgànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMonNganh F = new FormMonNganh();
            F.MdiParent = this;
            F.Show();
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDangNhap F = new FormDangNhap();
            F.MdiParent = this;
            F.Show();
        }
        private void khoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKhoa F = new FormKhoa();
            F.MdiParent = this;
            F.Show();
        }
        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

            check();


        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {

            check();
        }

        private void nhapDLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            check();
        }

        private void bảngĐiểmSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDiemSinhVien F = new FormDiemSinhVien();
            F.MdiParent = this;
            F.Show();
        }

        private void giáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGiaoVien F = new FormGiaoVien() ;
            F.MdiParent = this;
            F.Show();
        }
        private void phòngHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPhongHoc F = new FormPhongHoc();
            F.MdiParent = this;
            F.Show();
        }
        private void lịchDạyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLichDay  F = new FormLichDay ();
            F.MdiParent = this;
            F.Show();
        }
        private void điểmDanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDiemDanh F = new FormDiemDanh();
            F.MdiParent = this;
            F.Show();
        }
        private void uToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormLichHocLop F = new FormLichHocLop();
            F.MdiParent = this;
            F.Show();
        }
        private void lịchDạyGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChiTietLichDayGiaoVien F = new ChiTietLichDayGiaoVien();
            F.MdiParent = this;
            F.Show();
        }
        private void phòngTrốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChiTietLichPhongHoc F = new ChiTietLichPhongHoc();
            F.MdiParent = this;
            F.Show();
        }

        private void hocLaiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormHocLai F = new FormHocLai();
            F.MdiParent = this;
            F.Show();
        }
        private void check()
        {
            /* int x = CtrDangNhap.quyen;
             CtrDangNhap.CheckDangNhap = true;
             bảngĐiểmToolStripMenuItem.Enabled = CtrDangNhap.CheckDangNhap;
             danhSáchLớpToolStripMenuItem.Enabled = CtrDangNhap.CheckDangNhap;
             danhSáchSinhViênToolStripMenuItem.Enabled = CtrDangNhap.CheckDangNhap;
             dsChưaQuaMônToolStripMenuItem.Enabled = CtrDangNhap.CheckDangNhap;
             danhSáchMônNgànhToolStripMenuItem.Enabled = CtrDangNhap.CheckDangNhap;
             bảngĐiểmSinhViênToolStripMenuItem.Enabled = CtrDangNhap.CheckDangNhap;
             sinhVienToolStripMenuItem1.Enabled = false;
             asToolStripMenuItem.Enabled = false;
             diemToolStripMenuItem1.Enabled = false;

             tàiKhoảnToolStripMenuItem.Enabled = false;*/
            int x = 1;
            CtrDangNhap.CheckDangNhap = true;
            bảngĐiểmToolStripMenuItem.Enabled = true;
            danhSáchLớpToolStripMenuItem.Enabled = true;
            danhSáchSinhViênToolStripMenuItem.Enabled = true;
            dsChưaQuaMônToolStripMenuItem.Enabled = true;
            danhSáchMônNgànhToolStripMenuItem.Enabled = true;
            bảngĐiểmSinhViênToolStripMenuItem.Enabled = true;
            sinhVienToolStripMenuItem1.Enabled = false;
            asToolStripMenuItem.Enabled = false;
            diemToolStripMenuItem1.Enabled = false;

            tàiKhoảnToolStripMenuItem.Enabled = false;
            if (x == 1)
            {
                khóaToolStripMenuItem.Enabled = true;
                ngànhToolStripMenuItem.Enabled = true;
                họcKìToolStripMenuItem.Enabled = true;
                hinhThucToolStripMenuItem.Enabled = true;
                mônToolStripMenuItem.Enabled = true;
                lớpToolStripMenuItem.Enabled = true;
                diemToolStripMenuItem.Enabled = true;
                sInhVienToolStripMenuItem.Enabled = true;


                sinhVienToolStripMenuItem1.Enabled = true;
                asToolStripMenuItem.Enabled = true;
                diemToolStripMenuItem1.Enabled = true;

                tàiKhoảnToolStripMenuItem.Enabled = true;
            }
            else if (x == 2)
            {
                khóaToolStripMenuItem.Enabled = true;
                ngànhToolStripMenuItem.Enabled = true;
                họcKìToolStripMenuItem.Enabled = true;
                hinhThucToolStripMenuItem.Enabled = true;
                mônToolStripMenuItem.Enabled = true;
                lớpToolStripMenuItem.Enabled = true;
                diemToolStripMenuItem.Enabled = true;
                sInhVienToolStripMenuItem.Enabled = true;
            }
            else if (x == 3)
            {
                /*khóaToolStripMenuItem.Enabled = false;
                ngànhToolStripMenuItem.Enabled = true;
                họcKìToolStripMenuItem.Enabled = true;
                hinhThucToolStripMenuItem.Enabled = true;
                mônToolStripMenuItem.Enabled = true;
                lớpToolStripMenuItem.Enabled = false;
                diemToolStripMenuItem.Enabled = true;
                sInhVienToolStripMenuItem.Enabled = false;*/
                khóaToolStripMenuItem.Enabled = true;
                ngànhToolStripMenuItem.Enabled = true;
                họcKìToolStripMenuItem.Enabled = true;
                hinhThucToolStripMenuItem.Enabled = true;
                mônToolStripMenuItem.Enabled = true;
                lớpToolStripMenuItem.Enabled = true;
                diemToolStripMenuItem.Enabled = true;
                sInhVienToolStripMenuItem.Enabled = true;
            }
            else if (x == 4)
            {
                /* khóaToolStripMenuItem.Enabled = false;
                 ngànhToolStripMenuItem.Enabled = false;
                 họcKìToolStripMenuItem.Enabled = false;
                 hinhThucToolStripMenuItem.Enabled = false;
                 mônToolStripMenuItem.Enabled = false;
                 diemToolStripMenuItem.Enabled = false;
                 lớpToolStripMenuItem.Enabled = true;
                 sInhVienToolStripMenuItem.Enabled = true;*/
                khóaToolStripMenuItem.Enabled = true;
                ngànhToolStripMenuItem.Enabled = true;
                họcKìToolStripMenuItem.Enabled = true;
                hinhThucToolStripMenuItem.Enabled = true;
                mônToolStripMenuItem.Enabled = true;
                lớpToolStripMenuItem.Enabled = true;
                diemToolStripMenuItem.Enabled = true;
                sInhVienToolStripMenuItem.Enabled = true;
            }
            else
            {
                /*  khóaToolStripMenuItem.Enabled = false;
                  ngànhToolStripMenuItem.Enabled = false;
                  họcKìToolStripMenuItem.Enabled = false;
                  hinhThucToolStripMenuItem.Enabled = false;
                  mônToolStripMenuItem.Enabled = false;
                  diemToolStripMenuItem.Enabled = false;
                  lớpToolStripMenuItem.Enabled = false;
                  sInhVienToolStripMenuItem.Enabled = false;*/
                khóaToolStripMenuItem.Enabled = true;
                ngànhToolStripMenuItem.Enabled = true;
                họcKìToolStripMenuItem.Enabled = true;
                hinhThucToolStripMenuItem.Enabled = true;
                mônToolStripMenuItem.Enabled = true;
                lớpToolStripMenuItem.Enabled = true;
                diemToolStripMenuItem.Enabled = true;
                sInhVienToolStripMenuItem.Enabled = true;
            }
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTaiKhoan F = new FormTaiKhoan();
            F.MdiParent = this;
            F.Show();
        }

    }
}
