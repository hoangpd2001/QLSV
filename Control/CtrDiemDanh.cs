using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDSV.Model;
using QLDSV.Object;
using System.Data;
namespace QLDSV.Control
{
    class CtrDiemDanh
    {
        ModDiemDanh modDiemDanh = new ModDiemDanh();

        public bool GetData(int id_SinhVien, int ID_ChiTietLichDay)
        {
            return modDiemDanh.GetData(id_SinhVien,ID_ChiTietLichDay);
        }
        public DataTable GetData()
        {
            return modDiemDanh.GetData();
        }
        public int Update(int id_SinhVien, int ID_ChiTietLichDay, bool trangthai)
        {
            return modDiemDanh.update(id_SinhVien, ID_ChiTietLichDay, trangthai);
        }
        public DataTable GetData(int IdKHoaHoc, int IdNganhHoc, int IdHocKy,int IDLopHoc)
        {
            if (IdKHoaHoc == 0)
                return modDiemDanh.GetData();
            if (IdKHoaHoc != 0 && IdNganhHoc == 0)
                return modDiemDanh.GetData(" and KhoaHoc.ID = " + IdKHoaHoc + "  ");
            if (IdKHoaHoc != 0 && IdNganhHoc != 0 && IdHocKy == 0 && IDLopHoc == 0)
                return modDiemDanh.GetData(" and NganhHoc.ID = " + IdNganhHoc + "  ");
            string where = "";
             if (IdHocKy != 0) { where += " and HocKy.ID = " + IdHocKy + "  "; }
             if (IDLopHoc != 0) { where += "  and LopHoc.ID = " + IDLopHoc + "  "; }
            return modDiemDanh.GetData(where);

        }
    }
}
