using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLDSV.Model;
using QLDSV.Object;
namespace QLDSV.Control
{
    class CtrHocKy : CTR
    {
        ModHocKy  modHocKy= new ModHocKy();
       // CtrKhoaHoc ctrKhoaHoc = new CtrKhoaHoc();
        //CtrNganhHoc ctrNganhHoc = new CtrNganhHoc();
        public int GetIDNganh(int IdNganhHoc, string HocKy)
        {
            return modHocKy.GetDataID(IdNganhHoc, HocKy);
        }
        public DataTable GetData()
        {
                return modHocKy.GetData();
        }
        public DataTable GetData( int IdKhoaHoc , int IdnganhHoc)
        {
            if (IdKhoaHoc == 0 )
            {
                return modHocKy.GetData();
            }
            if(IdKhoaHoc != 0 && IdnganhHoc == 0)
            {
                return modHocKy.GetData(" and KhoaHoc.ID = " + IdKhoaHoc + "  ");
            }
            return modHocKy.GetData(" and NganhHoc.ID = " + IdnganhHoc + "  ");
        }
        public DataTable GetData(OjbHocKy ojb)
        {
            return modHocKy.GetData(" and NganhHoc.ID = " + ojb.Id_NganhHoc + " and HocKy.TenHocKy = N'" + ojb.TenHocKy + "' ;");
        }

        public int InsertData(OjbHocKy ojb)
        {
            if (checktrung(ojb)) return -1;
            return modHocKy.InsertData(ojb);
        }
        public int UpdateData(OjbHocKy ojb)
        {
            if (checktrung(ojb)) return -1;
            return modHocKy.UpdateData(ojb);
        }
        public int DeleteData(OjbHocKy ojb)
        {
            return modHocKy.DeleteData(ojb);
        }

        public bool checktrung(OjbHocKy ojb)
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


        public int GetDataID(int x, string y)
        {
            return modHocKy.GetDataID(x, y);
        }

    }
}


