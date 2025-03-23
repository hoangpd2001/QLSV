using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Object
{
    class OjbLopMon:OJB
    {
        private int id_LopHoc;
        private int id_MonHoc;
        

        public OjbLopMon()
        {
        }

        public OjbLopMon(int iD) : base(iD)
        {
        }
        

        public int Id_LopHoc { get => id_LopHoc; set => id_LopHoc = value; }
        public int Id_MonHoc { get => id_MonHoc; set => id_MonHoc = value; }

    }
}
