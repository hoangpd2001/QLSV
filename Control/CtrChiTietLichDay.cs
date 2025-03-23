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
    class CtrChiTietLichDay:CTR
    {
       
        ModChiTietLichDay modChiTietLichDay = new ModChiTietLichDay();
        public int GetIDNganh(int IDMonHoc, int IDSinhVien)
        {
            return modChiTietLichDay.GetDataID(IDMonHoc, IDSinhVien);
        }
        public DataTable GetData()
        {
            return modChiTietLichDay.GetData();
        }
        public DataTable GetDataBuoiHoc(int id_LichHoc)
        {
            return modChiTietLichDay.GetDataBuoiHoc(id_LichHoc);
        }
        public DataTable GetData(int id)
        {
            return modChiTietLichDay.GetData(id);
        }
        public int GetData(OjbChiTietLichDay ojb)
        {
            return modChiTietLichDay.GetData(ojb);
        }
        public DataTable GetData(int IdKHoaHoc, int IdNganhHoc, int IdHocKy, int IdHinhThuc, int IdMonHoc, int IDLopHoc, int IDSinhVien)
        {
            if (IdKHoaHoc == 0)
                return modChiTietLichDay.GetData();
            if (IdKHoaHoc != 0 && IdNganhHoc == 0)
                return modChiTietLichDay.GetData(" and KhoaHoc.ID = " + IdKHoaHoc + "  ;");
            if (IdKHoaHoc != 0 && IdNganhHoc != 0 && IdHocKy == 0 && IDLopHoc == 0)
                return modChiTietLichDay.GetData(" and NganhHoc.ID = " + IdNganhHoc + "  ;");
            string where = "";
            if (IdMonHoc != 0) { where += " and MonHoc.ID = " + IdMonHoc + "  "; }
            else if (IdHinhThuc != 0) { where += " and HinhThuc.ID = " + IdHinhThuc + "  "; }
            else if (IdHocKy != 0) { where += " and HocKy.ID = " + IdHocKy + "  "; }

            if (IDSinhVien != 0) { where += "  and SinhVien.ID = " + IDSinhVien + "  "; }
            else if (IDLopHoc != 0) { where += "  and LopHoc.ID = " + IDLopHoc + "  "; }
            return modChiTietLichDay.GetData(where);

        }
        public int UpdateData(int id_lichday,int buoi, int index, object data)
        {
            if (index == 1)
            {
                DateTime newDateValue = Convert.ToDateTime(data);
                return modChiTietLichDay.UpdateData(id_lichday, buoi, newDateValue);
            }
            else if (index == 2)
            {
                string x = Convert.ToString(data);
                return modChiTietLichDay.UpdateData(id_lichday, buoi, x);
            }
            else if (index == 3)
            {
                int x = Convert.ToInt32(data);
                return modChiTietLichDay.UpdateData(id_lichday,buoi, x);
            }
            else return 0;

        }
        public int UpdateDataCheck(int id_lichday, int buoi, int index, object data, int id_GiaoViem ,int id_LopHoc, DateTime Ngay, string tiet, string HinhThuc)
        {
           
            if (index == 1)
            {
                DateTime newDateValue = Convert.ToDateTime(data);
               
                if (checktrunggv(id_GiaoViem, Ngay, tiet, HinhThuc))
                {
                    return -4;
                }
                if (checktrungLop(id_LopHoc, Ngay, tiet, HinhThuc))
                {
                    return -2;
                }

                return modChiTietLichDay.UpdateData(id_lichday, buoi, newDateValue);
            }
            else if (index == 2)
            {
                string x = Convert.ToString(data);     
                if (checktrunggv(id_GiaoViem, Ngay, tiet, HinhThuc))
                {

                    return -4;
                }
                if (checktrungLop(id_LopHoc, Ngay, tiet, HinhThuc))
                {
                    return -2;
                }
                return modChiTietLichDay.UpdateData(id_lichday, buoi, x);
            }
            else if (index == 3)
            {
                int x = Convert.ToInt32(data);
                if (checktrungph(x, Ngay, tiet, HinhThuc))
                {

                    return -3;
                }

                return modChiTietLichDay.UpdateData(id_lichday, buoi, x);
            }
            else return 0;

        }
        public int UpdateDataCheck2(int id_lichday, int buoi, int index, object data, int id_GiaoViem, int id_LopHoc, DateTime Ngay, string tiet, string HinhThuc, int idph)
        {

            if (index == 1)
            {
                DateTime newDateValue = Convert.ToDateTime(data);
            
                if (checktrunggv(id_GiaoViem, Ngay, tiet, HinhThuc))
                {

                    return -4;
                }
                if (checktrungLop(id_LopHoc, Ngay, tiet, HinhThuc))
                {
                    return -2;
                }
                if (checktrungph(idph, Ngay, tiet, HinhThuc))
                {

                    return -3;
                }
                return modChiTietLichDay.UpdateData(id_lichday, buoi, newDateValue);
            }
            else if (index == 2)
            {
                string x = Convert.ToString(data);
                if (checktrunggv(id_GiaoViem, Ngay, tiet, HinhThuc))
                {

                    return -4;
                }
                if (checktrungLop(id_LopHoc, Ngay, tiet, HinhThuc))
                {
                    return -2;
                }
                if (checktrungph(idph, Ngay, tiet, HinhThuc))
                {

                    return -3;
                }
                return modChiTietLichDay.UpdateData(id_lichday, buoi, x);

            }
            else if (index == 3)
            {
                int x = Convert.ToInt32(data);
                if (checktrungph(x, Ngay, tiet, HinhThuc))
                {

                    return -3;
                }
                return modChiTietLichDay.UpdateData(id_lichday, buoi, x);
            }
            else return 0;

        }
        public bool checktrunggv(int idgv, DateTime Ngay, string tiet, string HinhThuc)
        {
            
            if(HinhThuc == "Thuc Hanh" || HinhThuc =="Tich Hop")
            {
                string tiet2= "Banana";
                string tiet3= "Banana";
                if(tiet =="Ca Sang")
                {
                    tiet2 = "Tiet 1";
                    tiet3 = "Tiet 2";
                }
                if (tiet == "Ca Chieu")
                {
                    tiet2 = "Tiet 3";
                    tiet3 = "Tiet 4";
                }
                DataTable dt =  modChiTietLichDay.GetDatatrungGV(idgv, Ngay, tiet, tiet2, tiet3);
                return dt.Rows.Count != 0;
            }
            if (HinhThuc == "Ly Thuyet" )
            {
                string tiet2 = "Banana";
                if (tiet == "Tiet 1" || tiet == "Tiet 2")
                {
                    tiet2 = "Ca Sang";
                }
                if (tiet == "Tiet 3" || tiet == "Tiet 4")
                {
                    tiet2 = "Ca Chieu";
                }
                DataTable dt = modChiTietLichDay.GetDatatrungGV(idgv, Ngay, tiet, tiet2, "Banana");
                return dt.Rows.Count != 0;
            }
            return false;
        }
        public bool checktrungLop(int idl, DateTime Ngay, string tiet, string HinhThuc)
        {

            if (HinhThuc == "Thuc Hanh" || HinhThuc == "Tich Hop")
            {
                string tiet2 = "Banana";
                string tiet3 = "Banana";
                if (tiet == "Ca Sang")
                {
                    tiet2 = "Tiet 1";
                    tiet3 = "Tiet 2";
                }
                if (tiet == "Ca Chieu")
                {
                    tiet2 = "Tiet 3";
                    tiet3 = "Tiet 4";
                }
                DataTable dt = modChiTietLichDay.GetDatatrungLop(idl, Ngay, tiet, tiet2, tiet3);
                return dt.Rows.Count != 0;
            }
            if (HinhThuc == "Ly Thuyet")
            {
                string tiet2 = "Banana";
                if (tiet == "Tiet 1" || tiet == "Tiet 2")
                {
                    tiet2 = "Ca Sang";
                }
                if (tiet == "Tiet 3" || tiet == "Tiet 4")
                {
                    tiet2 = "Ca Chieu";
                }
                DataTable dt = modChiTietLichDay.GetDatatrungLop(idl, Ngay, tiet, tiet2, "Banana");
                return dt.Rows.Count != 0;
            }
            return false;
        }
        public bool checktrungph(int idph, DateTime Ngay, string tiet, string HinhThuc)
        {

            if (HinhThuc == "Thuc Hanh" || HinhThuc == "Tich Hop")
            {
                string tiet2 = "Banana";
                string tiet3 = "Banana";
                if (tiet == "Ca Sang")
                {
                    tiet2 = "Tiet 1";
                    tiet3 = "Tiet 2";
                }
                if (tiet == "Ca Chieu")
                {
                    tiet2 = "Tiet 3";
                    tiet3 = "Tiet 4";
                }
                DataTable dt = modChiTietLichDay.GetDatatrungPH(idph, Ngay, tiet, tiet2, tiet3);
                return dt.Rows.Count != 0;
            }
            if (HinhThuc == "Ly Thuyet")
            {
                string tiet2 = "Banana";
                if (tiet == "Tiet 1" || tiet == "Tiet 2")
                {
                    tiet2 = "Ca Sang";
                }
                if (tiet == "Tiet 3" || tiet == "Tiet 4")
                {
                    tiet2 = "Ca Chieu";
                }
                DataTable dt = modChiTietLichDay.GetDatatrungPH(idph, Ngay, tiet, tiet2, "Banana");
                return dt.Rows.Count != 0;
            }
            return false;
        }
        public int DeleteDataAll(int IDLop, int IDMonHoc)
        {
            return modChiTietLichDay.DeleteDataAll(IDLop, IDMonHoc);
        }
    }
}
