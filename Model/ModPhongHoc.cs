using QLDSV.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV.Model
{
    class ModPhongHoc:MOD
    {
        public DataTable GetData()
        {
            string sql = @"Select * from PhongHoc";
            return base.Get(sql);
        }
    
        public int InsertData(OjbPhongHoc ojb)
        {
            string sql = @"Insert into PhongHoc(TenPhongHoc, ChoNgoi,LoaiPhong) values (@ten, @cho,@loai)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ojb.TenPhonHoc;
                command.Parameters.Add("@cho", SqlDbType.Int).Value = ojb.ChoNgoi;
                command.Parameters.Add("@loai", SqlDbType.NVarChar).Value = ojb.LoaiPhong;
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

        public int UpdateData(OjbPhongHoc ojb)
        {
            string sql = @"UPDATE PhongHoc SET TenPhongHoc = @ten, ChoNgoi = @cho ,LoaiPhong= @loai WHERE (ID = @id)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ojb.TenPhonHoc;
                command.Parameters.Add("@cho", SqlDbType.Int).Value = ojb.ChoNgoi;
                command.Parameters.Add("@loai", SqlDbType.NVarChar).Value = ojb.LoaiPhong;
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

        public int DeleteData(OjbPhongHoc ojb)
        {
            string sql = @"delete from PhongHoc where ID= @ID";
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
