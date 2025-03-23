using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Object
{
    class OjbTest
    {
        private string tK;
        private string mK;
        private int quyen;

        public OjbTest()
        {
        }

        public string TK { get => tK; set => tK = value; }
        public string MK { get => mK; set => mK = value; }
        public int Quyen { get => quyen; set => quyen = value; }

        public OjbTest(string tK, string mK, int quyen)
        {
            this.tK = tK;
            this.mK = mK;
            this.quyen = quyen;
        }
    }
}
