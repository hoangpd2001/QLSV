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
    class ModGiaoVien:MOD
    {
        public DataTable GetData()
        {
            return Get("select GiaoVien.ID, Ten,LienHe,GhiChu, Khoa.TenKhoa, ID_Khoa from GiaoVien, Khoa where GiaoVien.ID_Khoa= Khoa.ID");
        }
        public DataTable GetData(string where)
        {
            string sql = @"select GiaoVien.ID, Ten,LienHe,GhiChu, Khoa.TenKhoa, ID_Khoa from GiaoVien, Khoa where GiaoVien.ID_Khoa= Khoa.ID" + where;
            return Get(sql);
        }
        public int GetDataID(int IDKhoaHoc, string Ten)
        {
            string sql = @"SELECT GiaoVien.ID from NganhHoc, KhoaHoc where GiaoVien.ID_Khoa= Khoa.ID and Ten = N'" + Ten+ "' and Khoa.ID = " + IDKhoaHoc + "";

            return base.GetID(sql);
        }
        public int InsertData(OjbGiaoVien ojb)
        {
            string sql = @"Insert into GiaoVien(Ten,LienHe,GhiChu,ID_Khoa) values (@ten, @lienHe, @ghiChu,@ID)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ojb.Ten;
                command.Parameters.Add("@lienHe", SqlDbType.NVarChar).Value = ojb.LienHe;
                command.Parameters.Add("@ghiChu", SqlDbType.NVarChar).Value = ojb.GhiChu;
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

        public int UpdateData(OjbGiaoVien ojb)
        {
            string sql = @"UPDATE GiaoVien SET Ten=@ten,LienHe =@lienHe,GhiChu=@ghiChu,ID_Khoa=@ID WHERE (ID = @id2)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ojb.Ten;
                command.Parameters.Add("@id2", SqlDbType.Int).Value = ojb.Id;
                command.Parameters.Add("@lienHe", SqlDbType.NVarChar).Value = ojb.LienHe;
                command.Parameters.Add("@ghiChu", SqlDbType.NVarChar).Value = ojb.GhiChu;
                command.Parameters.Add("@ID", SqlDbType.Int).Value = ojb.Id_Khoa;
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

        public int DeleteData(OjbGiaoVien ojb)
        {
            string sql = @"delete from GiaoVien where ID= @ID";
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
