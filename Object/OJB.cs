using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Object
{
    class OJB
    {
        private int id ;

        public int Id { get => id; set => id = value; }

        public OJB(int iD)
        {
            Id = iD;
        }

        public OJB()
        {
        }

    }
    class Ngay
    {
        private string ngay1;

        private string ngay2;

        public string Ngay1 { get => ngay1; set => ngay1 = value; }
        public string Ngay2 { get => ngay2; set => ngay2 = value; }

        public Ngay(string ngay1, string ngay2)
        {
            this.ngay1 = ngay1;
            this.ngay2 = ngay2;
        }

        public Ngay()
        {
        }

    }
}
