using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Object
{
    class OjbPhongHoc:OJB
    {
        private string tenPhonHoc;
        private int choNgoi;
        private string loaiPhong;
        public string TenPhonHoc { get => tenPhonHoc; set => tenPhonHoc = value; }
        public int ChoNgoi { get => choNgoi; set => choNgoi = value; }
        public string LoaiPhong { get => loaiPhong; set => loaiPhong = value; }

        public OjbPhongHoc(string tenPhonHoc, int choNgoi, string loaiPhong)
        {
            this.tenPhonHoc = tenPhonHoc;
            this.choNgoi = choNgoi;
            this.loaiPhong = loaiPhong;
        }
        public OjbPhongHoc(int id,string tenPhonHoc, int choNgoi, string loaiPhong):base(id)
        {
            this.tenPhonHoc = tenPhonHoc;
            this.choNgoi = choNgoi;
            this.loaiPhong = loaiPhong;
        }

    }
}
