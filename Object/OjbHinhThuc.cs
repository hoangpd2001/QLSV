using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Object
{
    class OjbHinhThuc : OJB
    {
        private string tenHinhThuc;
        private int id_HocKy;

        public string TenHinhThuc { get => tenHinhThuc; set => tenHinhThuc = value; }
        public int Id_HocKy { get => id_HocKy; set => id_HocKy = value; }

        public OjbHinhThuc(int id,string tenHinhThuc, int id_HocKy):base(id)
        {
            this.tenHinhThuc = tenHinhThuc;
            this.id_HocKy = id_HocKy;
        }
        public OjbHinhThuc( string tenHinhThuc, int id_HocKy)
        {
            this.tenHinhThuc = tenHinhThuc;
            this.id_HocKy = id_HocKy;
        }
        public OjbHinhThuc()
        {
        }
    }
}
