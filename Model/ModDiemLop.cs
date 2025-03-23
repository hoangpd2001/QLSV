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
    class ModDiemLop:MOD
    {
        public DataTable GetData(int IdLop)
        {
            return Get(@"EXEC DiemLop @ClassID = "+ IdLop);
        }
     
    }
}
