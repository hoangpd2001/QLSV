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
    class CtrHinhThuc : CTR
    {
        ModHinhThuc modHinhThuc = new ModHinhThuc();

        public int GetIDNganh(int IDHocKy, string HinhThuc)
        {
            return modHinhThuc.GetDataID(IDHocKy, HinhThuc);
        }
        public int GetDataID(int IDHocKi, string HinhThuc)
        {
            return modHinhThuc.GetDataID(IDHocKi, HinhThuc);
        }
        public DataTable GetData()
        {
            return modHinhThuc.GetData();
        }
        public DataTable GetData(int IdKHoaHoc, int IdNganhHoc, int IdHocKy)
        {
            if (IdKHoaHoc == 0)
                return modHinhThuc.GetData();
            if (IdKHoaHoc != 0 && IdNganhHoc == 0)
                return modHinhThuc.GetData(" and KhoaHoc.ID = " +IdKHoaHoc+ "  ");
            if(IdKHoaHoc != 0 && IdNganhHoc != 0 && IdHocKy== 0)
                return modHinhThuc.GetData(" and NganhHoc.ID = " + IdNganhHoc + "  ");
            if(IdKHoaHoc != 0 && IdNganhHoc != 0 && IdHocKy != 0)
                return modHinhThuc.GetData(" and HocKy.ID = " + IdHocKy + "  ");
            return null;
        }
        public DataTable GetData(OjbHinhThuc ojb)
        {
            return modHinhThuc.GetData(" and HocKy.ID = " + ojb.Id_HocKy+ " and HinhThuc.TenHinhThuc = N'" + ojb.TenHinhThuc+ "' ;");
        } 

        public int InsertData(OjbHinhThuc ojb)
        {
            if (checktrung(ojb)) return -1;
            return modHinhThuc.InsertData(ojb);
        }
        public int UpdateData(OjbHinhThuc ojb)
        {
            if (checktrung(ojb)) return -1;
            return modHinhThuc.UpdateData(ojb);
        }
        public int DeleteData(OjbHinhThuc ojb)
        {
            return modHinhThuc.DeleteData(ojb);
        }

        public bool checktrung(OjbHinhThuc ojb)
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
