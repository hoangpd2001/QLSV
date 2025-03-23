using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Object
{
    class OjbLichDay:OJB
    {

        private int id_GiaoVien;
        private int id_MonHoc;
        private int id_LopHoc;
    

        public int Id_GiaoVien { get => id_GiaoVien; set => id_GiaoVien = value; }
        public int Id_MonHoc { get => id_MonHoc; set => id_MonHoc = value; }
        public int Id_LopHoc { get => id_LopHoc; set => id_LopHoc = value; }
 

        public OjbLichDay()
        {
        }

        public OjbLichDay(int id_GiaoVien, int id_MonHoc, int id_LopHoc)
        {
            this.id_GiaoVien = id_GiaoVien;
            this.id_MonHoc = id_MonHoc;
            this.id_LopHoc = id_LopHoc;

        }
        public OjbLichDay(int id,int id_GiaoVien, int id_MonHoc, int id_LopHoc):base(id)
        {
            this.id_GiaoVien = id_GiaoVien;
            this.id_MonHoc = id_MonHoc;
            this.id_LopHoc = id_LopHoc;

        }

    }
}
