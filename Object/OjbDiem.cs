using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Object
{
    class OjbDiem :OJB
    {
        private int id_SinhVien;
        private int id_LichDay;
        private int diem;
        private int lanThi;
        

        public int Id_SinhVien { get => id_SinhVien; set => id_SinhVien = value; }
        public int Id_LichDay { get => id_LichDay; set => id_LichDay = value; }
        public int Diem { get => diem; set => diem = value; }
        public int LanThi { get => lanThi; set => lanThi = value; }

        public OjbDiem()
        {
        }

        public OjbDiem(int id,int id_SinhVien, int id_LichDay, int diem, int lanThi):base(id)
        {
            this.id_SinhVien = id_SinhVien;
            this.id_LichDay = id_LichDay;
            this.diem = diem;
            this.lanThi = lanThi;
        }

        public OjbDiem(int id_SinhVien, int id_LichDay, int diem, int lanThi)
        {
            this.id_SinhVien = id_SinhVien;
            this.id_LichDay = id_LichDay;
            this.diem = diem;
            this.lanThi = lanThi;
        }
    }
}
