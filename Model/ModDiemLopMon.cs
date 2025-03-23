using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLDSV.Object;
using System.Windows.Forms;
namespace QLDSV.Model
{
    class ModDiemLopMon:MOD
    {
        public DataTable GetData()
        {
            return Get("SELECT   SinhVien.MaSinhVien, SinhVien.TenSinhVien, Diem.Diem FROM   Diem INNER JOIN  MonHoc ON Diem.ID_MonHoc = MonHoc.ID Right JOIN  SinhVien ON Diem.ID_SinhVien = SinhVien.ID INNER JOIN  LopHoc ON SinhVien.ID_LopHoc = LopHoc.ID");
        }
        public DataTable GetData(int IDmon, int IDLop)
        {
            string sql = @"		 SELECT   SinhVien.MaSinhVien, SinhVien.TenSinhVien, Diem.Diem  FROM  SinhVien left JOIN Diem ON Diem.ID_SinhVien = SinhVien.ID and Diem.ID_MonHoc = "+IDmon+ "  where SinhVien.ID_LopHoc= " + IDLop ;
            return Get(sql);
        }
    
    }
}
