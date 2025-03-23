using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Object
{
    class OjbKhoa:OJB
    {

        string tenKhoa;

            public string TenKhoa { get => tenKhoa; set => tenKhoa = value; }

            public OjbKhoa(int id, string tenKhoa) : base(id)
            {
                this.tenKhoa = tenKhoa;
            }
            public OjbKhoa(string tenKhoa)
            {
                this.tenKhoa = tenKhoa;
            }
            public OjbKhoa()
            {
            }
        
    }
}
