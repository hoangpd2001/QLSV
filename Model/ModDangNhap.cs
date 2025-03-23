using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDSV.Object;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace QLDSV.Model
{
    class ModDangNhap:MOD
    {
        public DataTable dangNhap(string tk, string mk)
        {
            try
            {
                DataTable table = new DataTable();
                conn.OpenConn();
                command.CommandText = "select TK, Quyen, Ten from TaiKhoan, Quyen where TaiKhoan.Quyen = Quyen.ID and TK = @tk and MK = @mk";
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@tk", SqlDbType.NChar).Value = tk;
                command.Parameters.Add("@mk", SqlDbType.NChar).Value = mk;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table == null || table.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    return table;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conn.CloseConn();
            }
        }
        public DataTable GetData()
        {
            string sql = @"Select TaiKhoan.ID, TK, MK, Ten from TaiKhoan, Quyen where TaiKhoan.Quyen = Quyen.ID";
            return base.Get(sql);
        }
        public DataTable GetDataQuyen()
        {
            string sql = @"Select * from Quyen ";
            return base.Get(sql);
        }
        /*  public int GetIDKhoa(string Khoa)
          {
              string sql = @"Select ID from KhoaHoc where TenKhoaHoc = '" + Khoa + "' ";
              return base.GetID(sql);
          }*/
        public int InsertData(string TK, string MK, int quyen)
        {
            string sql = @"insert into TaiKhoan(TK, MK, Quyen) values (@tk,@mk,@quyen)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@tk", SqlDbType.VarChar).Value = TK;
                command.Parameters.Add("@mk", SqlDbType.VarChar).Value = MK;
                command.Parameters.Add("@quyen", SqlDbType.Int).Value = quyen;
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
        public int UpdateData(int IDTK, string MK, int quyen)
        {
            string sql = @"UPDATE TaiKhoan SET MK = @mk, Quyen = @quyen WHERE ID = @id";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@mk", SqlDbType.VarChar).Value = MK;
                command.Parameters.Add("@quyen", SqlDbType.Int).Value = quyen;
                command.Parameters.Add("@id", SqlDbType.Int).Value = IDTK;

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

        public int DeleteData(int ID)
        {
            string sql = @"delete from TaiKhoan where ID= @ID";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
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
