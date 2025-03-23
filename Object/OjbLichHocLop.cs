using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Object
{
    class OjbLichHocLop
    {
        private string tiet;
        private string ngay;
        private string chiTiet;

        public string Tiet { get => tiet; set => tiet = value; }
        public string Ngay { get => ngay; set => ngay = value; }
        public string ChiTiet { get => chiTiet; set => chiTiet = value; }

        public OjbLichHocLop(string tiet, string ngay, string chiTiet)
        {
            this.tiet = tiet;
            this.ngay = ngay;
            this.chiTiet = chiTiet;
        }
    }
}
