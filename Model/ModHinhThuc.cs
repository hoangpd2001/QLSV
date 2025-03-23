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
    class ModHinhThuc:MOD
    {
        public DataTable GetData()
        {
            return Get("select HinhThuc.ID, TenHinhThuc,TenHocKy,ID_HocKy, ID_NganhHoc,TenNganhHoc,ID_KhoaHoc,TenKhoaHoc from HinhThuc, HocKy, NganhHoc, KhoaHoc where NganhHoc.ID_KhoaHoc= KhoaHoc.ID and HocKy.ID_NganhHoc=NganhHoc.ID and HinhThuc.ID_HocKy= HocKy.ID");
        }
        public DataTable GetData(string where)
        {
            string sql = @"select HinhThuc.ID, TenHinhThuc,TenHocKy,ID_HocKy, ID_NganhHoc,TenNganhHoc,ID_KhoaHoc,TenKhoaHoc from HinhThuc, HocKy, NganhHoc, KhoaHoc where NganhHoc.ID_KhoaHoc= KhoaHoc.ID and HocKy.ID_NganhHoc=NganhHoc.ID and HinhThuc.ID_HocKy= HocKy.ID  " + where;
            return Get(sql);
        }
        public int GetDataID(int IdHocKy, string HinhThuc)
        {
            string sql = @"select HinhThuc.ID from HinhThuc, HocKy, NganhHoc, KhoaHoc where NganhHoc.ID_KhoaHoc= KhoaHoc.ID and HocKy.ID_NganhHoc=NganhHoc.ID and HinhThuc.ID_HocKy= HocKy.ID 
            and TenHinhThuc = N'" + HinhThuc + "' and HocKy.ID = " + IdHocKy+ "";
            return base.GetID(sql);
        }
        public int InsertData(OjbHinhThuc ojb)
        {
            string sql = @"Insert into HinhThuc(TenHinhThuc, ID_HocKy) values (@ten, @ID)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ojb.TenHinhThuc;
                command.Parameters.Add("@ID", SqlDbType.Int).Value = ojb.Id_HocKy;
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

        public int UpdateData(OjbHinhThuc ojb)
        {
            string sql = @"UPDATE HinhThuc SET TenHinhThuc = @ten WHERE (ID = @id)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ojb.TenHinhThuc;
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

        public int DeleteData(OjbHinhThuc ojb)
        {
            string sql = @"delete from HinhThuc where ID= @ID";
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
