using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Object
{
    class OjbGiaoVien:OJB
    {
        private string ten ;
        private string lienHe;
        private string ghiChu;
        private int id_Khoa;


        public OjbGiaoVien() : base()
        {
        }

        public OjbGiaoVien(int id,string ten, string lienHe, string ghiChu, int id_Khoa):base(id)
        {
            this.ten = ten;
            this.lienHe = lienHe;
            this.ghiChu = ghiChu;
            this.id_Khoa = id_Khoa;
        }

        public OjbGiaoVien(string ten, string lienHe, string ghiChu, int id_Khoa)
        {
            this.ten = ten;
            this.lienHe = lienHe;
            this.ghiChu = ghiChu;
            this.id_Khoa = id_Khoa;
        }

        public int Id_Khoa { get => id_Khoa; set => id_Khoa = value; }
        public string Ten { get => ten ; set => ten  = value; }
        public string LienHe { get => lienHe; set => lienHe = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
