using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDSV.Object;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace QLDSV.Model
{
    class ModNganhHoc : MOD
    {
        public DataTable GetData()
        {
            return Get("select NganhHoc.ID, NganhHoc.TenNganhHoc, NganhHoc.ID_KhoaHoc, KhoaHoc.TenKhoaHoc from NganhHoc, KhoaHoc where NganhHoc.ID_KhoaHoc= KhoaHoc.ID");
        }
        public DataTable GetData(string where)
        {
            string sql = @"select NganhHoc.ID, NganhHoc.TenNganhHoc, NganhHoc.ID_KhoaHoc, KhoaHoc.TenKhoaHoc from NganhHoc, KhoaHoc where NganhHoc.ID_KhoaHoc= KhoaHoc.ID " + where;
            return Get(sql);
        }
        public int GetDataID(int IDKhoaHoc, string tenNganhHoc)
        {
            string sql = @"SELECT NganhHoc.ID from NganhHoc, KhoaHoc where NganhHoc.ID_KhoaHoc= KhoaHoc.ID and TenNganhHoc = N'" + tenNganhHoc + "' and KhoaHoc.ID = " + IDKhoaHoc + "";
            
            return base.GetID(sql);
        }
        public int InsertData(OjbNganhHoc ojb)
        {
            string sql = @"Insert into NganhHoc(TenNganhHoc, ID_KhoaHoc) values (@ten, @ID)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ojb.TenNganhHoc;
                command.Parameters.Add("@ID", SqlDbType.Int).Value = ojb.Id_Khoa;
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

        public int UpdateData(OjbNganhHoc ojb)
        {
            string sql = @"UPDATE NganhHoc SET TenNganhHoc = @ten WHERE (ID = @id)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ojb.TenNganhHoc;
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

        public int DeleteData(OjbNganhHoc ojb)
        {
            string sql = @"delete from NganhHoc where ID= @ID";
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
