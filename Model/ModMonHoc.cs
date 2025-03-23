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
    class ModMonHoc:MOD
    {
        public DataTable GetData()
        {
            return Get("select MonHoc.ID,TenMonHoc,SoGioLT,SoTiet1Buoi,  HinhThuc.ID, ID_HinhThuc, TenHinhThuc,TenHocKy,TenNganhHoc,TenKhoaHoc from HinhThuc, HocKy, NganhHoc, KhoaHoc,MonHoc where NganhHoc.ID_KhoaHoc= KhoaHoc.ID and HocKy.ID_NganhHoc=NganhHoc.ID and HinhThuc.ID_HocKy= HocKy.ID and MonHoc.ID_HinhThuc=HinhThuc.ID  ");
        }
        public DataTable GetDataReport(int IDNganh)
        {
            return Get("select MonHoc.ID,TenMonHoc,SoGioLT,SoTiet1Buoi,  TenHinhThuc,TenHocKy from HinhThuc, HocKy, NganhHoc, KhoaHoc, MonHoc where NganhHoc.ID_KhoaHoc = KhoaHoc.ID    and HocKy.ID_NganhHoc = NganhHoc.ID  and HinhThuc.ID_HocKy = HocKy.ID and MonHoc.ID_HinhThuc = HinhThuc.ID and NganhHoc.ID = " + IDNganh + " order by TenHocKy ASC, TenMonHoc ASC, TenHinhThuc ASC ");
        }
        public DataTable GetData(string where)
        {
            string sql = "select MonHoc.ID ,TenMonHoc,SoGioLT,SoTiet1Buoi,  HinhThuc.ID, TenHinhThuc,TenHocKy,TenNganhHoc,TenKhoaHoc from HinhThuc, HocKy, NganhHoc, KhoaHoc,MonHoc where NganhHoc.ID_KhoaHoc= KhoaHoc.ID and HocKy.ID_NganhHoc=NganhHoc.ID and HinhThuc.ID_HocKy= HocKy.ID and MonHoc.ID_HinhThuc=HinhThuc.ID  " + where;
            return Get(sql);
        }
        public DataTable GetDataHocLai(string where)
        {
            string sql = "select MonHoc.ID ,TenMonHoc,SoGioLT,SoTiet1Buoi,  HinhThuc.ID, TenHinhThuc,TenHocKy,TenNganhHoc,TenKhoaHoc from HinhThuc, HocKy, NganhHoc, KhoaHoc,MonHoc where NganhHoc.ID_KhoaHoc= KhoaHoc.ID and HocKy.ID_NganhHoc=NganhHoc.ID and HinhThuc.ID_HocKy= HocKy.ID and MonHoc.ID_HinhThuc=HinhThuc.ID  " + where;
            return Get(sql);
        }
        public int GetDataID(int IDHinhThuc, string TenMonHoc)
        {
            string sql = @"select ID from MonHoc where TenMonHoc = N'" + TenMonHoc+ "' and MonHoc.ID_HinhThuc= " + IDHinhThuc + "";
            return base.GetID(sql);
        }
        public int InsertData(OjbMonHoc ojb)
        {
            string sql = @"Insert into MonHoc(TenMonHoc, SoGioLT, SoTiet1Buoi, ID_HinhThuc) values (@ten,@LT,@TH, @ID)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ojb.TenMonHoc;
                command.Parameters.Add("@LT", SqlDbType.Int).Value = ojb.SoGioLT;
                command.Parameters.Add("@TH", SqlDbType.Int).Value = ojb.SoGioTH;
                command.Parameters.Add("@ID", SqlDbType.Int).Value = ojb.Id_HinhThuc;
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

        public int UpdateData(OjbMonHoc ojb)
        {
            string sql = @"UPDATE MonHoc SET TenMonHoc= @ten, SoGioLT = @LT, SoTiet1Buoi = @TH WHERE ID = @id";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ojb.TenMonHoc;
                command.Parameters.Add("@LT", SqlDbType.Int).Value = ojb.SoGioLT;
                command.Parameters.Add("@TH", SqlDbType.Int).Value = ojb.SoGioTH;
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

        public int DeleteData(OjbMonHoc ojb)
        {
            string sql = @"delete from MonHoc where ID= @ID";
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
