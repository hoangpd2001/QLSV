using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Object
{
    class OjbDiemLopMon
    {
        private string maSV;
        private string hoTen;
        private string diemLan1;
        private string diemLan2;
        private string trungBinh;
        public OjbDiemLopMon()
        {
        }

        public OjbDiemLopMon(string maSV, string hoTen, string diemLan1, string diemLan2, string trungBinh)
        {
            this.maSV = maSV;
            this.hoTen = hoTen;
            this.diemLan1 = diemLan1;
            this.diemLan2 = diemLan2;
            this.trungBinh = trungBinh;
        }

        public string MaSV { get => maSV; set => maSV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string DiemLan1 { get => diemLan1; set => diemLan1 = value; }
        public string DiemLan2 { get => diemLan2; set => diemLan2 = value; }
        public string TrungBinh { get => trungBinh; set => trungBinh = value; }
    }
}
