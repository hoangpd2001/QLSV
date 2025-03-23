using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Object
{
    class OjbChiTietLichDay:OJB
    {
        private int id_LichDay;
        private int buoi;
        private DateTime ngay;
        private int tiet;
        private string id_Phong;

        public int Id_LichDay { get => id_LichDay; set => id_LichDay = value; }
        public int Buoi { get => buoi; set => buoi = value; }
        public DateTime Ngay { get => ngay; set => ngay = value; }
        public int Tiet { get => tiet; set => tiet = value; }
        public string Id_Phong { get => id_Phong; set => id_Phong = value; }

        public OjbChiTietLichDay()
        {
        }

        public OjbChiTietLichDay(int id_LichDay, int id_MonHoc, int id_LopHoc, int buoi, DateTime ngay, int tiet, string id_Phong)
        {
            this.id_LichDay = id_LichDay;
            this.buoi = buoi;
            this.ngay = ngay;
            this.tiet = tiet;
            this.id_Phong = id_Phong;
        }
        public OjbChiTietLichDay(int id, int id_LichDay, int id_MonHoc, int id_LopHoc, int buoi, DateTime ngay, int tiet, string id_Phong) : base(id)
        {
            this.id_LichDay = id_LichDay;
            this.buoi = buoi;
            this.ngay = ngay;
            this.tiet = tiet;
            this.id_Phong = id_Phong;
        }
    }
}
