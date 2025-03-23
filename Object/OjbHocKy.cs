using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Object
{
    class OjbHocKy : OJB
    {
        private string tenHocKy;
        private int id_NganhHoc;

        public string TenHocKy { get => tenHocKy; set => tenHocKy = value; }
        public int Id_NganhHoc { get => id_NganhHoc; set => id_NganhHoc = value; }

        public OjbHocKy(int id, string tenHocKy, int id_NganhHoc):base(id)
        {
            this.tenHocKy = tenHocKy;
            this.id_NganhHoc = id_NganhHoc;
        }
        public OjbHocKy( string tenHocKy, int id_NganhHoc)
        {
            this.tenHocKy = tenHocKy;
            this.id_NganhHoc = id_NganhHoc;
        }

        public OjbHocKy()
        {
        }
    }
}
