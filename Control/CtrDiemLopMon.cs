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
    class CtrDiemLopMon
    {
        ModDiemLopMon modDiemLopMon = new ModDiemLopMon();

      /*  public int GetIDNganh(int IDMonHoc, int IDSinhVien)
        {
            return modDiemLopMon.GetDataID(IDMonHoc, IDSinhVien);
        }*/
        public DataTable GetData()
        {
            return modDiemLopMon.GetData();
        }
        public DataTable GetData(int IdMonHoc, int IDLopHoc)
        {
                return modDiemLopMon.GetData(IdMonHoc,IDLopHoc);

        }
      
    }
}
