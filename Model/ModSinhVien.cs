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
    class ModSinhVien:MOD
    {
        public DataTable GetData()
        {
            return Get("select SinhVien.ID, MaSinhVien,TenSinhVien,NgaySinh,TenLopHoc,TenNganhHoc,TenKhoaHoc  from SinhVien, LopHoc, NganhHoc, KhoaHoc where NganhHoc.ID_KhoaHoc= KhoaHoc.ID and LopHoc.ID_NganhHoc=NganhHoc.ID and LopHoc.ID= SinhVien.ID_LopHoc");
        }
        public DataTable GetData(string where)
        {
            string sql = @"select SinhVien.ID, MaSinhVien,TenSinhVien,NgaySinh,TenLopHoc,TenNganhHoc,TenKhoaHoc, ID_NganhHoc from SinhVien, LopHoc, NganhHoc, KhoaHoc where NganhHoc.ID_KhoaHoc= KhoaHoc.ID and LopHoc.ID_NganhHoc=NganhHoc.ID and LopHoc.ID= SinhVien.ID_LopHoc  " + where;
            return Get(sql);
        }
        public int GetDataID(int IdLopHoc, string MaSV)
        {
            string sql = @"select SinhVien.ID from SinhVien, LopHoc where  LopHoc.ID= SinhVien.ID_LopHoc  
            and MaSinhVien = N'" + MaSV + "' and LopHoc.ID = " + IdLopHoc+ "  ";
            return base.GetID(sql);
        }
        public int InsertData(OjbSinhVien ojb)
        {
            string sql = @"Insert into SinhVien(MaSinhVien,TenSinhVien, NgaySinh, ID_LopHoc) values (@ma,@ten,@NS, @ID)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = ojb.MaSinhVien;
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ojb.TenSinhVien;
                command.Parameters.Add("@NS", SqlDbType.DateTime).Value = ojb.NgaySinh;
                command.Parameters.Add("@ID", SqlDbType.Int).Value = ojb.Id_Lop;
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

        public int UpdateData(OjbSinhVien ojb)
        {
            string sql = @"UPDATE SinhVien SET TenSinhVien= @ten, MaSinhVien=@Ma, NgaySinh = @NS WHERE (ID = @id)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@Ma", SqlDbType.NVarChar).Value = ojb.MaSinhVien;
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ojb.TenSinhVien;
                command.Parameters.Add("@NS", SqlDbType.DateTime).Value = ojb.NgaySinh;
                command.Parameters.Add("@ID", SqlDbType.Int).Value = ojb.Id;
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

        public int DeleteData(OjbSinhVien ojb)
        {
            string sql = @"delete from SinhVien where ID= @ID";
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
        public int DeleteDataAll(int IdLop)
        {
            string sql = @"delete from SinhVien where ID_LopHoc= @ID";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ID", SqlDbType.Int).Value = IdLop;
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

        public DataTable GetData2()
        {
            return Get("select *  from SinhVien");
        }
    }
}
