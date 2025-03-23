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
    class CtrPhongHoc
    {
        ModPhongHoc modK = new ModPhongHoc();

        public DataTable GetData()
        {
            return modK.GetData();
        }
      
        public int InsertData(OjbPhongHoc ojb)
        {
            if (!checktrung(ojb)) return -1;
            return modK.InsertData(ojb);
        }
        public int UpdateData(OjbPhongHoc ojb)
        {
            if (!checktrung2(ojb)) return -1;
            return modK.UpdateData(ojb);
        }
        public int DeleteData(OjbPhongHoc ojb)
        {
            return modK.DeleteData(ojb);
        }

        public bool checktrung(OjbPhongHoc ojb)
        {
            DataTable table = modK.GetData();
            foreach (DataRow row in table.Rows)
            {
                if (string.Equals(ojb.TenPhonHoc, row["TenPhongHoc"].ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
            return true;
        }
        public bool checktrung2(OjbPhongHoc ojb)
        {
            DataTable table = modK.GetData();
            foreach (DataRow row in table.Rows)
            {
                if (string.Equals(ojb.TenPhonHoc, row["TenPhongHoc"].ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    if (ojb.Id == Convert.ToInt32(row["ID"].ToString()))
                    {
                        return true;
                    }
                    return false;
                }
            }
            return true;
        }
    }
}
