using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QLDSV.Object
{
    class OjbKhoaHoc : OJB
    {
        string tenKhoaHoc;
        
        public string TenKhoaHoc { get => tenKhoaHoc; set => tenKhoaHoc = value; }

        public OjbKhoaHoc(int id,string tenKhoaHoc ) :base(id)
        {
            this.tenKhoaHoc = tenKhoaHoc;
        }
        public OjbKhoaHoc(string tenKhoaHoc)
        {
            this.tenKhoaHoc = tenKhoaHoc;
        }
        public OjbKhoaHoc()
        {
        }
    }
}
