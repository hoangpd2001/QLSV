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
    class ModLopHoc:MOD
    {

        public DataTable GetData()
        {
            return Get("select LopHoc.ID,TenLopHoc,TenNganhHoc,TenKhoaHoc from LopHoc, NganhHoc, KhoaHoc where NganhHoc.ID_KhoaHoc= KhoaHoc.ID and LopHoc.ID_NganhHoc=NganhHoc.ID");
        }
        public DataTable GetDataReport(int IDKHoa)
        {
            return Get("select TenLopHoc,TenNganhHoc,TenKhoaHoc, count(SinhVien.ID) as TongSV FROM LopHoc LEFT JOIN SinhVien ON LopHoc.ID = SinhVien.ID_LopHoc INNER JOIN NganhHoc ON LopHoc.ID_NganhHoc = NganhHoc.ID INNER JOIN KhoaHoc ON NganhHoc.ID_KhoaHoc = KhoaHoc.ID  and ID_KhoaHoc = " + IDKHoa + "GROUP BY TenLopHoc, TenNganhHoc, TenKhoaHoc ");
        }
        public DataTable GetData(string where)
        {
            string sql = @"select LopHoc.ID,TenLopHoc, TenNganhHoc,TenKhoaHoc from NganhHoc,LopHoc, KhoaHoc where NganhHoc.ID_KhoaHoc= KhoaHoc.ID and LopHoc.ID_NganhHoc=NganhHoc.ID " + where;
            return Get(sql);
        }
        public int GetDataID(int IDNganhHoc, string TenLop)
        {
            string sql = @"select  LopHoc.ID from NganhHoc,LopHoc, KhoaHoc where NganhHoc.ID_KhoaHoc = KhoaHoc.ID and LopHoc.ID_NganhHoc=NganhHoc.ID  and TenHocKy = N'" + TenLop + "' and NganhHoc.ID = " + IDNganhHoc + "";

            return base.GetID(sql);
        }

        public int InsertData(OjbLopHoc ojb)
        {
            string sql = @"Insert into LopHoc(TenLopHoc, ID_NganhHoc) values (@ten, @ID)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ojb.TenLopHoc;
                command.Parameters.Add("@ID", SqlDbType.Int).Value = ojb.Id_NganhHoc;
                x = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.CloseConn();
            }
            return x;
        }

        public int UpdateData(OjbLopHoc ojb)
        {
            string sql = @"UPDATE LopHoc SET TenLopHoc = @ten WHERE (ID = @id)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ojb.TenLopHoc;
                command.Parameters.Add("@id", SqlDbType.Int).Value = ojb.Id;
                x = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.CloseConn();
            }
            return x;
        }

        public int DeleteData(OjbLopHoc ojb)
        {
            string sql = @"delete from LopHoc where ID= @ID";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ID", SqlDbType.Int).Value = ojb.Id;
                x = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                x = -1;
            }
            finally
            {
                conn.CloseConn();
            }
            return x;
        }
    }
}
