using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Object
{
    class OjbDiemDanh
    {
        private int iD_SinhVien;
        private int iD_ChiTietLichDay;
        private bool trangThai;

        public int ID_SinhVien { get => iD_SinhVien; set => iD_SinhVien = value; }
        public int ID_ChiTietLichDay { get => iD_ChiTietLichDay; set => iD_ChiTietLichDay = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }

        public OjbDiemDanh(int iD_SinhVien, int iD_ChiTietLichDay, bool trangThai)
        {
            this.iD_SinhVien = iD_SinhVien;
            this.iD_ChiTietLichDay = iD_ChiTietLichDay;
            this.trangThai = trangThai;
        }

    }
}
