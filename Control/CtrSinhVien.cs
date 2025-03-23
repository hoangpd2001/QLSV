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
    class CtrSinhVien : CTR
    {
        ModSinhVien modSinhVien = new ModSinhVien();

        public int GetDataID(int IDLopHoc, string SinhVien)
        {
            return modSinhVien.GetDataID(IDLopHoc, SinhVien);
        }
        public DataTable GetData()
        {
            return modSinhVien.GetData();
        }
        public DataTable GetData(string MaSinhVien)
        {
            return modSinhVien.GetData(" and MaSinhVien = '" + MaSinhVien + "'  ");
        }
        public DataTable GetData2()
        {
            return modSinhVien.GetData2();
        }
        public DataTable GetData(int IDLop)
        {
            return modSinhVien.GetData(" and LopHoc.ID = '" + IDLop+ "'  ");
        }
        public DataTable GetData(int IdKHoaHoc, int IdNganhHoc, int IdLop)
        {
            if (IdKHoaHoc == 0)
                return modSinhVien.GetData();
            if (IdKHoaHoc != 0 && IdNganhHoc == 0)
                return modSinhVien.GetData(" and KhoaHoc.ID = " + IdKHoaHoc + "  ");
            if (IdKHoaHoc != 0 && IdNganhHoc != 0 && IdLop == 0)
                return modSinhVien.GetData(" and NganhHoc.ID = " + IdNganhHoc + "  ");
            if (IdKHoaHoc != 0 && IdNganhHoc != 0 && IdLop != 0)
                return modSinhVien.GetData(" and LopHoc.ID = " + IdLop + "  ");
            return null;
        }
        public DataTable GetData(OjbSinhVien ojb)
        {
            return modSinhVien.GetData(" and MaSinhVien = N'" + ojb.MaSinhVien + "' ;");
        }
        public DataTable GetData2(OjbSinhVien ojb)
        {
            return modSinhVien.GetData(" and MaSinhVien = N'" + ojb.MaSinhVien + "' and SinhVien.ID != " + ojb.Id + " ;");
        }
        public int InsertData(OjbSinhVien ojb)
        {
            if (checktrung(ojb)) return -1;
            return modSinhVien.InsertData(ojb);
        }
        public int UpdateData(OjbSinhVien ojb)
        {
            if (checktrung2(ojb)) return -1;
            return modSinhVien.UpdateData(ojb);
        }
        public int DeleteData(OjbSinhVien ojb)
        {
            return modSinhVien.DeleteData(ojb);
        }
        public int DeleteDataAll(int IDLop)
        {
            return modSinhVien.DeleteDataAll(IDLop);
        }



        public bool checktrung(OjbSinhVien ojb)
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
        public bool checktrung2(OjbSinhVien ojb)
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


    }
}
