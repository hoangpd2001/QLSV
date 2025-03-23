using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Object
{
    class OjbSinhVien : OJB
    {
        private string maSinhVien;
        private string tenSinhVien;
        private DateTime ngaySinh;
        private int id_Lop;
        private string tenLopHoc;
        public string MaSinhVien { get => maSinhVien; set => maSinhVien = value; }
        public string TenSinhVien { get => tenSinhVien; set => tenSinhVien = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public int Id_Lop { get => id_Lop; set => id_Lop = value; }
        public string TenLopHoc { get => tenLopHoc; set => tenLopHoc = value; }

        public OjbSinhVien(int id,string maSinhVien, string tenSinhVien, DateTime ngaySinh, int id_Lop):base(id)
        {
            this.maSinhVien = maSinhVien;
            this.tenSinhVien = tenSinhVien;
            this.ngaySinh = ngaySinh;
            this.id_Lop = id_Lop;
        }
        public OjbSinhVien(string maSinhVien, string tenSinhVien, DateTime ngaySinh, int id_Lop) 
        {
            this.maSinhVien = maSinhVien;
            this.tenSinhVien = tenSinhVien;
            this.ngaySinh = ngaySinh;
            this.id_Lop = id_Lop;
        }
        public OjbSinhVien()
        {
        }
    }
}
