using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Object
{
    class OjbMonHoc : OJB
    {
        private string tenMonHoc;
        private int soGioLT;
        private int soGioTH;
        private int id_HinhThuc;
        private string tenHinhThuc;
        private string tenHocKy;
        public string TenMonHoc { get => tenMonHoc; set => tenMonHoc = value; }
        public int SoGioLT { get => soGioLT; set => soGioLT = value; }
        public int SoGioTH { get => soGioTH; set => soGioTH = value; }
        public int Id_HinhThuc { get => id_HinhThuc; set => id_HinhThuc = value; }
        public string TenHinhThuc { get => tenHinhThuc; set => tenHinhThuc = value; }
        public string TenHocKy { get => tenHocKy; set => tenHocKy = value; }

        public OjbMonHoc(int id, string tenMonHoc, int soGioLT, int soGioTH, int id_HinhThuc) : base(id)
        {
            this.tenMonHoc = tenMonHoc;
            this.soGioLT = soGioLT;
            this.soGioTH = soGioTH;
            this.id_HinhThuc = id_HinhThuc;
        }

        public OjbMonHoc(string tenMonHoc, int soGioLT, int soGioTH, int id_HinhThuc, string tenHinhThuc, string tenHocKy) : this(tenMonHoc, soGioLT, soGioTH, id_HinhThuc)
        {
            this.tenHinhThuc = tenHinhThuc;
            this.tenHocKy = tenHocKy;
        }

        public OjbMonHoc( string tenMonHoc, int soGioLT, int soGioTH, int id_HinhThuc)
        {
            this.tenMonHoc = tenMonHoc;
            this.soGioLT = soGioLT;
            this.soGioTH = soGioTH;
            this.id_HinhThuc = id_HinhThuc;
        }

        public OjbMonHoc()
        {
        }
    }
}
