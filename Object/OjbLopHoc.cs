using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Object
{
    class OjbLopHoc : OJB
    {
        private string tenLopHoc;
        private int id_NganhHoc;
        private int tongSV;
        private string ten_NganhHoc;

        public string TenLopHoc { get => tenLopHoc; set => tenLopHoc = value; }
        public int Id_NganhHoc { get => id_NganhHoc; set => id_NganhHoc = value; }
        public int TongSV { get => tongSV; set => tongSV = value; }
        public string Ten_NganhHoc { get => ten_NganhHoc; set => ten_NganhHoc = value; }

        public OjbLopHoc(int id,string tenLopHoc, int id_NganhHoc):base(id)
        {
            this.tenLopHoc = tenLopHoc;
            this.id_NganhHoc = id_NganhHoc;
        }
        public OjbLopHoc(string tenLopHoc, int id_NganhHoc)
        {
            this.tenLopHoc = tenLopHoc;
            this.id_NganhHoc = id_NganhHoc;
        }

        public OjbLopHoc(string tenLopHoc, int id_NganhHoc, int tongSV, string ten_NganhHoc) : this(tenLopHoc, id_NganhHoc)
        {
            this.tongSV = tongSV;
            this.ten_NganhHoc = ten_NganhHoc;
        }

        public OjbLopHoc()
        {
        }
    }
}
