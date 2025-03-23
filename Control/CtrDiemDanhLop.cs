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
    class CtrDiemDanhLop
    {
        ModDiemDanhLop modDiemDanhLop = new ModDiemDanhLop();

        public DataTable GetData(int id_lop, int id_Mon)
        {
            return modDiemDanhLop.GetData2(id_lop, id_Mon);
        }
       
    }
}
