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
    class CtrDiem : CTR
    {
        ModDiem modDiem= new ModDiem();

     
        public DataTable GetDataReport( string IDSinhVien)
        {
            return modDiem.GetDataReport( IDSinhVien);
        }
        public string GetData(int ID_SinhVien, int ID_LichDay, int lan)
        {
            return modDiem.GetData(ID_SinhVien, ID_LichDay, lan);

        }
        public DataTable GetData(OjbDiem ojb)
        {
            return modDiem.GetData(" and MonHoc.ID = " + ojb.Id_LichDay + " and SinhVien.ID = N'" + ojb.Id_SinhVien + "' ;");
        }
/*        public DataTable GetData2(OjbDiem ojb)
        {
            return modDiem.GetData(" and HinhThuc.ID = " + ojb.Id_HinhThuc + " and MonHoc.TenMonHoc = N'" + ojb.TenMonHoc + "' and MonHoc.ID != " + ojb.Id + " ;");
        }*/

      
        public int UpdateData(OjbDiem ojb)
        {
         
            return modDiem.UpdateData(ojb);
        }
        public int DeleteData(OjbDiem ojb)
        {
            // return modDiem.DeleteData(ojb);
            return 1;
        }

        public bool checktrung(OjbDiem ojb)
        {
            DataTable table = GetData(ojb);
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
/*        public bool checktrung2(OjbMonHoc ojb)
        {
            DataTable table = GetData2(ojb);
            if (table == null)
            {
                return false;
            }
            if (table.Rows.Count < 1)
            {
                return false;
            }
            return true;
        }*/
        public int GetDataID(int x, int y)
        {
            return modDiem.GetDataID(x, y);
        }
        public int DeleteDataAll(int IDLop, int IDMonHoc)
        {
            return modDiem.DeleteDataAll(IDLop, IDMonHoc);
        }
    }
}
