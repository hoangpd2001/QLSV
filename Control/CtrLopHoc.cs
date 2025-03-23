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
    class CtrLopHoc : CTR
    {
        ModLopHoc modLopHoc = new ModLopHoc();
        public int GetIDNganh(int IdNganhHoc, string LopHoc)
        {
            return modLopHoc.GetDataID(IdNganhHoc, LopHoc);
        }
        public DataTable GetData()
        {
            return modLopHoc.GetData();
        }
        public DataTable GetDataReport(int IDKhoa)
        {
            return modLopHoc.GetDataReport(IDKhoa);
        }
        public DataTable GetData(int IdKhoaHoc, int IdnganhHoc)
        {
            if (IdKhoaHoc == 0)
            {
                return modLopHoc.GetData();
            }
            if (IdKhoaHoc != 0 && IdnganhHoc == 0)
            {
                return modLopHoc.GetData(" and KhoaHoc.ID = " + IdKhoaHoc + "  ");
            }
            return modLopHoc.GetData(" and NganhHoc.ID = " + IdnganhHoc + "  ");
        }
        public DataTable GetData(OjbLopHoc ojb)
        {
            return modLopHoc.GetData(" and NganhHoc.ID = " + ojb.Id_NganhHoc + " and TenLopHoc = N'" + ojb.TenLopHoc + "' ;");
        }

        public int InsertData(OjbLopHoc ojb)
        {
            if (checktrung(ojb)) return -1;
            return modLopHoc.InsertData(ojb);
        }
        public int UpdateData(OjbLopHoc ojb)
        {
            if (checktrung(ojb)) return -1;
            return modLopHoc.UpdateData(ojb);
        }
        public int DeleteData(OjbLopHoc ojb)
        {
            return modLopHoc.DeleteData(ojb);
        }

        public bool checktrung(OjbLopHoc ojb)
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
            return modLopHoc.GetDataID(x, y);

        }
    }
}
