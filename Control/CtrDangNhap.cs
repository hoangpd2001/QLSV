using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDSV.Model;
using System.Windows.Forms;
namespace QLDSV.Control
{
    class CtrDangNhap
    {
        public static bool CheckDangNhap = false;
        public static int quyen = 0;
        public static string StrQuyen = "BẠN CHƯA ĐĂNG NHẬP ";
        ModDangNhap modDangNhap = new ModDangNhap();
        public DataTable dangNhap(string tk, string mk)
        {
            return modDangNhap.dangNhap(tk, mk);
        }

        public DataTable GetData()
        {
            return modDangNhap.GetData();
        }
        public DataTable GetDataQuyen()
        {
            return modDangNhap.GetDataQuyen();
        }
        public int InsertData(string TK, string mk, int quyen)
        {
            if (!checktrung(TK)) return -1;
            return modDangNhap.InsertData(TK, mk, quyen);
        }
        public int UpdateData(int ID, string mk, int quyen)
        {
            
            return modDangNhap.UpdateData(ID, mk, quyen);
        }
        public int DeleteData(int Quyen)
        {
            return modDangNhap.DeleteData(Quyen);
        }

        public bool checktrung(string TK)
        {
            DataTable table = modDangNhap.GetData();
            foreach (DataRow row in table.Rows)
            {
                if (TK == row["TK"].ToString().Trim())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
