using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Object
{
    class OjbDiemDanhLop
    {
        private int id_SinhVien;
        private string maSinhVien;
        private string tenSinhVien;
        private int id_ChiTietDay;
        private int buoi;
        private string trangThai;
        private string ketQua;

        public int Id_SinhVien { get => id_SinhVien; set => id_SinhVien = value; }
        public string MaSinhVien { get => maSinhVien; set => maSinhVien = value; }
        public string TenSinhVien { get => tenSinhVien; set => tenSinhVien = value; }
        public int Id_ChiTietDay { get => id_ChiTietDay; set => id_ChiTietDay = value; }
        public int Buoi { get => buoi; set => buoi = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
        public string KetQua { get => ketQua; set => ketQua = value; }

        public OjbDiemDanhLop(int id_SinhVien, string maSinhVien, string tenSinhVien, int id_ChiTietDay, int buoi, string trangThai, string ketQua)
        {
            this.id_SinhVien = id_SinhVien;
            this.maSinhVien = maSinhVien;
            this.tenSinhVien = tenSinhVien;
            this.id_ChiTietDay = id_ChiTietDay;
            this.buoi = buoi;
            this.trangThai = trangThai;
            this.ketQua = ketQua;
        }

        public OjbDiemDanhLop()
        {
   
        }
    }
}
