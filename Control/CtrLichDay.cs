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
    class CtrLichDay:CTR
    {
        ModLichDay modLichDay = new ModLichDay();

        public int GetIDNganh(int IDMonHoc, int IDSinhVien)
        {
            return modLichDay.GetDataID(IDMonHoc, IDSinhVien);
        }
        public DataTable GetData()
        {
            return modLichDay.GetData();
        }
        public DataTable GetData2(int id_LopHoc, int ID_HocKy)
        {
            return modLichDay.GetData2(id_LopHoc,  ID_HocKy);
        }
        public DataTable GetData(int ID_MonHoc, int ID_LopHoc)
        {
            return modLichDay.GetData(ID_MonHoc, ID_LopHoc);
        }
        public int GetData(OjbLichDay ojb)
        {
            return modLichDay.GetData( ojb);
        }
        public DataTable GetData(int IDLopHoc, DateTime Ngay, string tiet)
        {
            if(tiet =="Tiet 1" || tiet == "Tiet 2")
            {
                return modLichDay.GetData(IDLopHoc, Ngay, tiet, "Ca Sang");
            }else
            return modLichDay.GetData(IDLopHoc,Ngay, tiet, "Ca Chieu");
        }
        public DataTable GetData(int IDGiaoVien, string tiet, DateTime Ngay)
        {
            if (tiet == "Tiet 1" || tiet == "Tiet 2")
            {
                return modLichDay.GetData(IDGiaoVien, tiet, "Ca Sang", Ngay);
            }
            else
                return modLichDay.GetData(IDGiaoVien, tiet, "Ca Chieu", Ngay);
        }
        public DataTable GetData( DateTime Ngay, string tiet)
        {
            if (tiet == "Tiet 1" || tiet == "Tiet 2")
            {
                return modLichDay.GetData(Ngay, tiet, "Ca Sang");
            }
            else if (tiet == "Tiet 3" || tiet == "Tiet 4") {
                return modLichDay.GetData(Ngay, tiet, "Ca Chieu");
            }
            else if(tiet == "Ca Sang")
            {
                return modLichDay.GetData(Ngay, tiet, "Tiet 1", "Tiet 2");
            }
            else if (tiet == "Ca Chieu")
            {
                return modLichDay.GetData(Ngay, tiet, "Tiet 3", "Tiet 4");
            }
            return null;
        }
        public DataTable GetData(int IdKHoaHoc, int IdNganhHoc, int IdHocKy, int IdHinhThuc, int IdMonHoc, int IDLopHoc)
        {
            if (IdKHoaHoc == 0)
                return modLichDay.GetData();
            if (IdKHoaHoc != 0 && IdNganhHoc == 0)
                return modLichDay.GetData(" and KhoaHoc.ID = " + IdKHoaHoc + "  ");
            if (IdKHoaHoc != 0 && IdNganhHoc != 0 && IdHocKy == 0 && IDLopHoc == 0)
                return modLichDay.GetData(" and NganhHoc.ID = " + IdNganhHoc + "  ");
            string where = "";
            if (IdMonHoc != 0) { where += " and MonHoc.ID = " + IdMonHoc + "  "; }
            else if (IdHinhThuc != 0) { where += " and HinhThuc.ID = " + IdHinhThuc + "  "; }
            else if (IdHocKy != 0) { where += " and HocKy.ID = " + IdHocKy + "  "; }
            else if (IDLopHoc != 0) { where += "  and LopHoc.ID = " + IDLopHoc + "  "; }
            return modLichDay.GetData(where);

        }
/*        public DataTable GetData(OjbLichDay ojb)
        {
            return modLichDay.GetData(" and MonHoc.ID = " + ojb.Id_MonHoc + " and SinhVien.ID = N'" + ojb.Id_SinhVien + "' ;");
        }*/
        /*        public DataTable GetData2(OjbLichDay ojb)
                {
                    return modLichDay.GetData(" and HinhThuc.ID = " + ojb.Id_HinhThuc + " and MonHoc.TenMonHoc = N'" + ojb.TenMonHoc + "' and MonHoc.ID != " + ojb.Id + " ;");
                }*/

        public int InsertData(OjbLichDay ojb)
        {
            if (checktrung(ojb)) return -1;
            return modLichDay.InsertData(ojb);
        }
       public int UpdateData(int id_Lop, int id_Mon,int buoi,int index, object data)
        {
            if( index == 1)
            {
                DateTime newDateValue = Convert.ToDateTime(data);
                return modLichDay.UpdateData(id_Lop, id_Mon,buoi, newDateValue);
            }
            else
            {
                string x = Convert.ToString(data);
                return modLichDay.UpdateData(id_Lop, id_Mon, buoi, x);
            }
           
        }
        public int UpdateData(int id_Giaovien, int id_Mon, int id_Lop)
        {

            if (checktrung2(id_Mon, id_Lop))
            {
                return modLichDay.UpdateData(id_Giaovien, id_Mon, id_Lop);
            }
            else return -1;
                
            

        }
        /*        public int DeleteData(OjbLichDay ojb)
                {
                    return modLichDay.DeleteData(ojb);
                }
        */
        public bool checktrung(OjbLichDay ojb)
        {
            int x = GetData(ojb);
            if (x > 0) return true;
            return false;
        }
        public bool checktrung2(int id_Mon, int id_Lop)
        {
            DataTable table = GetData(id_Mon, id_Lop);
            if (table == null)
            {
                return false;
            }
            if (table.Rows.Count < 1)
            {
                return false;
            }
            return true;
        }
        public int GetDataID(int x, int y)
        {
            return modLichDay.GetDataID(x, y);
        }
        public int DeleteDataAll(int IDLop, int IDMonHoc)
        {
            return modLichDay.DeleteDataAll(IDLop, IDMonHoc);
        }
    }
}
