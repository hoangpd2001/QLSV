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
    class CtrGiaoVien:CTR
    {
        ModGiaoVien modGiaoVien = new ModGiaoVien();
        CtrKhoa ctrKhoa = new CtrKhoa();

        public int GetIDNganh(int x, string y)
        {
            return modGiaoVien.GetDataID(x, y);
        }

        public int GetIdKhoa(string Khoa)
        {
            return ctrKhoa.GetIdKhoa(Khoa);
        }

        public DataTable GetData()
        {
            return modGiaoVien.GetData();
        }

        public DataTable GetData(int IdKhoa)
        {
            return modGiaoVien.GetData(" and Khoa.ID = " + IdKhoa + "  ");
        }

        public DataTable GetData(OjbGiaoVien ojb)
        {
            return modGiaoVien.GetData(" and Khoa.ID = " + ojb.Id_Khoa + " and GiaoVien.Ten = N'" + ojb.Ten + "' ;");
        }



        public int InsertData(OjbGiaoVien ojb)
        {
            if (checktrung(ojb)) return -1;
            return modGiaoVien.InsertData(ojb);
        }
        public int UpdateData(OjbGiaoVien ojb)
        {
           // if (checktrung(ojb)) return -1;
            return modGiaoVien.UpdateData(ojb);
        }
        public int DeleteData(OjbGiaoVien ojb)
        {
            return modGiaoVien.DeleteData(ojb);
        }

        public bool checktrung(OjbGiaoVien ojb)
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
    }
}
