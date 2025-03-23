using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QLDSV.Model
{
    class ModDiemDanh:MOD
    {
        public DataTable GetData()
        {
            return Get(@"select GiaoVien.ID as ID_GiaoVien, GiaoVien.Ten as TenGiaoVien , MonHoc.ID as ID_MonHoc,MonHoc.TenMonHoc,HinhThuc.ID as ID_HinhThuc,
			                   HinhThuc.TenHinhThuc, LopHoc.ID as ID_LopHoc,LopHoc.TenLopHoc , MonHoc.SoGioLT/MonHoc.SoTiet1Buoi as SoBuoi
                               , TenKHoaHoc, TenNganhHoc, TenHocKy , LichDay.ID as ID
                        from  HinhThuc, HocKy, NganhHoc, KhoaHoc,MonHoc,LopHoc,GiaoVien,LichDay 
                        where NganhHoc.ID_KhoaHoc= KhoaHoc.ID 
	                        and HocKy.ID_NganhHoc=NganhHoc.ID
	                        and HinhThuc.ID_HocKy= HocKy.ID 
	                        and MonHoc.ID_HinhThuc=HinhThuc.ID 
	                        and LopHoc.ID_NganhHoc=NganhHoc.ID 
	                        and LichDay.ID_LopHoc = LopHoc.ID 
	                        and LichDay.ID_MonHoc = Monhoc.ID 
	                        and LichDay.ID_GiaoVien = GiaoVien.ID 
	                        group by GiaoVien.ID,MonHoc.ID, GiaoVien.Ten ,HinhThuc.ID,LopHoc.ID, MonHoc.TenMonHoc, HinhThuc.TenHinhThuc, LopHoc.TenLopHoc,MonHoc.SoGioLT/MonHoc.SoTiet1Buoi , TenKHoaHoc, TenNganhHoc, TenHocKy, LichDay.ID ");
          
        }
        public DataTable GetData(string where)
        {
            string sql = @"select GiaoVien.ID as ID_GiaoVien, GiaoVien.Ten as TenGiaoVien , MonHoc.ID as ID_MonHoc,MonHoc.TenMonHoc,HinhThuc.ID as ID_HinhThuc,
			                   HinhThuc.TenHinhThuc, LopHoc.ID as ID_LopHoc,LopHoc.TenLopHoc , MonHoc.SoGioLT/MonHoc.SoTiet1Buoi as SoBuoi
                               , TenKHoaHoc, TenNganhHoc, TenHocKy , LichDay.ID as ID
                        from  HinhThuc, HocKy, NganhHoc, KhoaHoc,MonHoc,LopHoc,GiaoVien,LichDay 
                        where NganhHoc.ID_KhoaHoc= KhoaHoc.ID 
	                        and HocKy.ID_NganhHoc=NganhHoc.ID
	                        and HinhThuc.ID_HocKy= HocKy.ID 
	                        and MonHoc.ID_HinhThuc=HinhThuc.ID 
	                        and LopHoc.ID_NganhHoc=NganhHoc.ID 
	                        and LichDay.ID_LopHoc = LopHoc.ID 
	                        and LichDay.ID_MonHoc = Monhoc.ID 
	                        and LichDay.ID_GiaoVien = GiaoVien.ID  " + where + @" 
	                         group by GiaoVien.ID,MonHoc.ID, GiaoVien.Ten ,HinhThuc.ID,LopHoc.ID, MonHoc.TenMonHoc, HinhThuc.TenHinhThuc, LopHoc.TenLopHoc,MonHoc.SoGioLT/MonHoc.SoTiet1Buoi , TenKHoaHoc, TenNganhHoc, TenHocKy, LichDay.ID";
            return Get(sql);
        }
        public bool GetData(int IDSinhVien, int IDChiTietDay)
        {
            bool x = false;
            try
            {
                conn.OpenConn();
                string sql3 = ("select TrangThai from DiemDanh where ID_SinhVien = @idsv and ID_ChiTietLichDay = @idct");
                command.CommandText = sql3;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@idsv", SqlDbType.Int).Value = IDSinhVien;
                command.Parameters.Add("@idct", SqlDbType.Int).Value = IDChiTietDay;
                object result = command.ExecuteScalar();
                 x = Convert.ToBoolean(result);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                x = false;
            }
            finally
            {
                conn.CloseConn();
            }
            return x;
        }
        public int insert(int id_SinhVien, int id_ChiTietLichDay)
        {
            string sql = @"Insert into DiemDanh(ID_SinhVien, ID_ChiTietLichDay, TrangThai) values (@sv,@ld,@tt)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@sv", SqlDbType.Int).Value = id_SinhVien;
                command.Parameters.Add("@ld", SqlDbType.Int).Value = id_ChiTietLichDay;
                command.Parameters.Add("@tt", SqlDbType.Bit).Value = 1;
                x = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.CloseConn();
            }
            return x;
        }
        public int update(int id_SinhVien, int id_ChiTietLichDay, bool trangthai)
        {
            string sql = @"Update DiemDanh SET TrangThai = @trangthai where ID_SinhVien = @sv and ID_ChiTietLichDay = @ld";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@sv", SqlDbType.Int).Value = id_SinhVien;
                command.Parameters.Add("@ld", SqlDbType.Int).Value = id_ChiTietLichDay;
                command.Parameters.Add("@trangthai", SqlDbType.Bit).Value = trangthai;
                x = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.CloseConn();
            }
            return x;
        }
    }
}
