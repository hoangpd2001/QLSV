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
    class CtrNganhHoc : CTR
    {
        ModNganhHoc modNganhHoc = new ModNganhHoc();
        CtrKhoaHoc ctrKhoaHoc = new CtrKhoaHoc();
        //Lay ID nganh hoc
        public int GetIDNganh(int x, string y)
        {
            return modNganhHoc.GetDataID(x, y);
        }
        //Lay ID khoa hoc cua nganh hoc
        public int GetIdKhoa(string Khoa)
        {
            return ctrKhoaHoc.GetIdKhoa(Khoa);
        }

        // lay du lieu bang Nganh hoc  trong 3 truong hop
        public DataTable GetData()
        {
            return modNganhHoc.GetData();
        }

        public DataTable GetData(int IdKhoa)
        {
            return modNganhHoc.GetData(" and KhoaHoc.ID = " + IdKhoa + "  ");
        }

        public DataTable GetData(OjbNganhHoc ojb)
        {
            return modNganhHoc.GetData(" and KhoaHoc.ID = " + ojb.Id_Khoa + " and NganhHoc.TenNganhHoc = N'" +ojb.TenNganhHoc+"' ;");
        }

        

        public int InsertData(OjbNganhHoc ojb)
        {
            if (checktrung(ojb)) return -1;
            return modNganhHoc.InsertData(ojb);
        }
        public int UpdateData(OjbNganhHoc ojb)
        {
            if (checktrung(ojb)) return -1;
            return modNganhHoc.UpdateData(ojb);
        }
        public int DeleteData(OjbNganhHoc ojb)
        {
            return modNganhHoc.DeleteData(ojb);
        }

        public bool checktrung(OjbNganhHoc ojb)
        {
            DataTable table = GetData(ojb);
           if(table == null)
            {
                return false;
            }
            if (table.Rows.Count < 1)
            {
                return false;
            }
            return true;
        }
    }
}
