using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDSV.Model;
using QLDSV.Object;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLDSV.Control
{
    class CtrKhoa:CTR
    {

        ModKhoa modK = new ModKhoa();

        public DataTable GetData()
        {
            return modK.GetData();
        }
        public int GetIdKhoa(string x)
        {
            return modK.GetIDKhoa(x);
        }
        public int InsertData(OjbKhoa ojb)
        {
            if (!checktrung(ojb)) return -1;
            return modK.InsertData(ojb);
        }
        public int UpdateData(OjbKhoa ojb)
        {
            if (!checktrung(ojb)) return -1;
            return modK.UpdateData(ojb);
        }
        public int DeleteData(OjbKhoa ojb)
        {
            return modK.DeleteData(ojb);
        }

        public bool checktrung(OjbKhoa ojb)
        {
            DataTable table = modK.GetData();
            foreach (DataRow row in table.Rows)
            {
                if (string.Equals(ojb.TenKhoa, row["TenKhoa"].ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
