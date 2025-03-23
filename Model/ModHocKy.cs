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
    class ModHocKy: MOD
    {
        public DataTable GetData()
        {
            return Get("select HocKy.ID,TenHocKy, ID_NganhHoc,TenNganhHoc,ID_KhoaHoc,TenKhoaHoc from HocKy, NganhHoc, KhoaHoc where NganhHoc.ID_KhoaHoc= KhoaHoc.ID and HocKy.ID_NganhHoc=NganhHoc.ID");
        }
        public DataTable GetData(string where)
        {
            string sql = @"select HocKy.ID,TenHocKy, ID_NganhHoc,TenNganhHoc,ID_KhoaHoc,TenKhoaHoc from NganhHoc,HocKy, KhoaHoc where NganhHoc.ID_KhoaHoc= KhoaHoc.ID and HocKy.ID_NganhHoc=NganhHoc.ID " + where;
            return Get(sql);
        }
        public int GetDataID(int IDNganhHoc, string TenHocKy)
        {
            string sql = @"select HocKy.ID from NganhHoc,HocKy, KhoaHoc where NganhHoc.ID_KhoaHoc = KhoaHoc.ID and HocKy.ID_NganhHoc=NganhHoc.ID  and TenHocKy = N'" + TenHocKy + "' and NganhHoc.ID = " + IDNganhHoc + "";

            return base.GetID(sql);
        }

        public int InsertData(OjbHocKy ojb)
        {
            string sql = @"Insert into HocKy(TenHocKy, ID_NganhHoc) values (@ten, @ID)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ojb.TenHocKy;
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

        public int UpdateData(OjbHocKy ojb)
        {
            string sql = @"UPDATE HocKy SET TenHocKy = @ten WHERE (ID = @id)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ojb.TenHocKy;
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

        public int DeleteData(OjbHocKy ojb)
        {
            string sql = @"delete from HocKy where ID= @ID";
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
            catch (Exception ex)
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
