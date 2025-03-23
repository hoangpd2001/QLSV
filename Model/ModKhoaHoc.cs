using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using QLDSV.Object;

namespace QLDSV.Model
{

    class ModKhoaHoc:MOD
    {
        public DataTable GetData()
        {
            string sql = @"Select * from KhoaHoc";
            return base.Get(sql);
        }
        public int GetIDKhoa(string Khoa)
        {
            string sql = @"Select ID from KhoaHoc where TenKhoaHoc = '"+ Khoa + "' ";
            return base.GetID(sql);
        }
        public int InsertData(OjbKhoaHoc ojb)
        {
            string sql = @"Insert into KhoaHoc(TenKhoaHoc) values (@ten)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ojb.TenKhoaHoc;
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

        public int UpdateData(OjbKhoaHoc ojb)
        {
            string sql = @"UPDATE KhoaHoc SET TenKhoaHoc = @ten WHERE (ID = @id)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ojb.TenKhoaHoc; 
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

        public int DeleteData(OjbKhoaHoc ojb)
        {
            string sql = @"delete from KhoaHoc where ID= @ID";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ID", SqlDbType.Int).Value = ojb.Id;
                x = command.ExecuteNonQuery();
            }catch(Exception ex)
            {
                x= -1;
            }
            finally
            {
                conn.CloseConn();
            }
            return x;
        }
    }
}
