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
    class CtrMonHoc : CTR
    {
        ModMonHoc modMonHoc= new ModMonHoc();

        public int GetIDNganh(int IDHocKi, string HinhThuc)
        {
            return modMonHoc.GetDataID(IDHocKi, HinhThuc);
        }
        public DataTable GetData()
        {
            return modMonHoc.GetData();
        }
        public DataTable GetDataReport(int IDNganh)
        {
            return modMonHoc.GetDataReport(IDNganh);
        }
        public DataTable GetData(int IdKHoaHoc, int IdNganhHoc, int IdHocKy, int IdHinhThuc)
        {
            if (IdKHoaHoc == 0)
                return modMonHoc.GetData();
            if (IdKHoaHoc != 0 && IdNganhHoc == 0)
                return modMonHoc.GetData(" and KhoaHoc.ID = " + IdKHoaHoc + "  ");
            if (IdKHoaHoc != 0 && IdNganhHoc != 0 && IdHocKy == 0)
                return modMonHoc.GetData(" and NganhHoc.ID = " + IdNganhHoc + "  ");
            if (IdKHoaHoc != 0 && IdNganhHoc != 0 && IdHocKy != 0 && IdHinhThuc == 0)
                return modMonHoc.GetData(" and HocKy.ID = " + IdHocKy + "  ");
            if (IdKHoaHoc != 0 && IdNganhHoc != 0 && IdHocKy != 0 && IdHinhThuc != 0)
                return modMonHoc.GetData(" and HinhThuc.ID = " + IdHinhThuc + "  ");
            return null;
        }
        public DataTable GetData2( int IdHinhThuc)
        {
            
                return modMonHoc.GetData(" and HinhThuc.ID = " + IdHinhThuc + "  ");
            
        }
        public DataTable GetData(OjbMonHoc ojb)
        {
            return modMonHoc.GetData(" and HinhThuc.ID = " + ojb.Id_HinhThuc+ " and MonHoc.TenMonHoc = N'" + ojb.TenMonHoc + "' ;");
        }
        public DataTable GetData2(OjbMonHoc ojb)
        {
            return modMonHoc.GetData(" and HinhThuc.ID = " + ojb.Id_HinhThuc + " and MonHoc.TenMonHoc = N'" + ojb.TenMonHoc + "' and MonHoc.ID != " + ojb.Id + " ;");
        }

        public int InsertData(OjbMonHoc ojb)
        {
            if (checktrung(ojb)) return -1;
            return modMonHoc.InsertData(ojb);
        }
        public int UpdateData(OjbMonHoc ojb)
        {
            if (checktrung2(ojb)) return -1;
            return modMonHoc.UpdateData(ojb);
        }
        public int DeleteData(OjbMonHoc ojb)
        {
            return modMonHoc.DeleteData(ojb);
        }

        public bool checktrung(OjbMonHoc ojb)
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
        public bool checktrung2(OjbMonHoc ojb)
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
        }
        public int GetDataID(int x, string y)
        {
            return modMonHoc.GetDataID(x, y);
        }
        
    }
}
