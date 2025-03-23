using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Object
{
    class OjbNganhHoc : OJB
    {
        private string tenNganhHoc;
        private int id_Khoa;

        public OjbNganhHoc():base()
        {
        }

        public OjbNganhHoc(int id, string tenNganhHoc, int id_Khoa) : base(id)
        {
            this.tenNganhHoc = tenNganhHoc;
            this.id_Khoa = id_Khoa;
        }
        public OjbNganhHoc( string tenNganhHoc, int id_Khoa)
        {
            this.tenNganhHoc = tenNganhHoc;
            this.id_Khoa = id_Khoa;
        }

        public int Id_Khoa { get => id_Khoa; set => id_Khoa = value; }
        public string TenNganhHoc { get => tenNganhHoc; set => tenNganhHoc = value; }
        
    }
}
