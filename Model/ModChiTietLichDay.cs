using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDSV.Object;
using System.Windows.Forms;
using System.Data;

namespace QLDSV.Model
{
    class ModChiTietLichDay:MOD
    {
        public DataTable GetData()
        {
            return Get(@"select GiaoVien.ID as ID_GiaoVien, GiaoVien.Ten as TenGiaoVien , MonHoc.ID as ID_MonHoc,MonHoc.TenMonHoc,HinhThuc.ID as ID_HinhThuc,
			                   HinhThuc.TenHinhThuc, LopHoc.ID as ID_LopHoc,LopHoc.TenLopHoc , MonHoc.SoGioLT/MonHoc.SoTiet1Buoi as SoBuoi
                               , TenKHoaHoc, TenNganhHoc, TenHocKy 
                        from  HinhThuc, HocKy, NganhHoc, KhoaHoc,MonHoc,LopHoc,GiaoVien,LichDay 
                        where NganhHoc.ID_KhoaHoc= KhoaHoc.ID 
	                        and HocKy.ID_NganhHoc=NganhHoc.ID
	                        and HinhThuc.ID_HocKy= HocKy.ID 
	                        and MonHoc.ID_HinhThuc=HinhThuc.ID 
	                        and LopHoc.ID_NganhHoc=NganhHoc.ID 
	                        and LichDay.ID_LopHoc = LopHoc.ID 
	                        and LichDay.ID_MonHoc = Monhoc.ID 
	                        and LichDay.ID_GiaoVien = GiaoVien.ID 
	                        group by GiaoVien.ID,MonHoc.ID, GiaoVien.Ten ,HinhThuc.ID,LopHoc.ID, MonHoc.TenMonHoc, HinhThuc.TenHinhThuc, LopHoc.TenLopHoc,MonHoc.SoGioLT/MonHoc.SoTiet1Buoi , TenKHoaHoc, TenNganhHoc, TenHocKy ");
        }
        public DataTable GetData(int id)
        {
            return Get($"select * from ChiTietLichDay Where ID_LichDay ={ id}");
        }
        public DataTable GetDataBuoiHoc(int LichDay)
        {
            return Get($"SELECT ChiTietLichDay.Buoi, ChiTietLichDay.ID, ChiTietLichDay.Ngay,COUNT(CASE WHEN DiemDanh.TrangThai = 1 THEN 1 END) AS TongDD,    COUNT(DiemDanh.ID_SinhVien) AS Tong FROM     ChiTietLichDay JOIN      DiemDanh     ON DiemDanh.ID_ChiTietLichDay = ChiTietLichDay.ID WHERE     ChiTietLichDay.ID_LichDay = {LichDay} GROUP BY     ChiTietLichDay.Buoi,      ChiTietLichDay.ID,     ChiTietLichDay.Ngay ORDER BY  ChiTietLichDay.Buoi; ");
        }
        public int GetData(OjbChiTietLichDay ojb)
        {
            string sql = @"select ID from LichDay where ID_LopHoc=" +   " and ID_MonHoc= " ;
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                object y = command.ExecuteScalar();
                x = Convert.ToInt32(y);
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
        public DataTable GetData(string where)
        {
            string sql = "select Diem.ID,Diem,ID_SinhVien,ID_MonHoc,MaSinhVien,TenSinhVien,TenLopHoc,TenMonHoc,SoGioLT,SoTiet1Buoi, TenHinhThuc,TenHocKy,TenNganhHoc,TenKhoaHoc  from HinhThuc, HocKy, NganhHoc, KhoaHoc,MonHoc,LopHoc,SinhVien,Diem where NganhHoc.ID_KhoaHoc= KhoaHoc.ID and HocKy.ID_NganhHoc=NganhHoc.ID and HinhThuc.ID_HocKy= HocKy.ID and MonHoc.ID_HinhThuc=HinhThuc.ID and LopHoc.ID_NganhHoc=NganhHoc.ID and SinhVien.ID_LopHoc=LopHoc.ID and Diem.ID_SinhVien = SinhVien.ID and Diem.ID_MonHoc=MonHoc.ID   " + where;
            return Get(sql);
        }
        public DataTable GetDatatrungGV(int idgv, DateTime Ngay, string tiet1, string tiet2, string tiet3)
        {
       
            string formattedDate = Ngay.ToString("yyyy-MM-dd");

            string sql = $@"
                            SELECT Tiet
                            FROM ChiTietLichDay
                            JOIN LichDay ON LichDay.ID = ChiTietLichDay.ID_LichDay
                            WHERE Ngay = '{formattedDate}' 
                              AND ID_GiaoVien = {idgv}
                              AND (Tiet = N'{tiet1}' OR Tiet = N'{tiet2}' OR Tiet = N'{tiet3}')
                        ";
            return Get(sql);
        }
        public DataTable GetDatatrungLop(int idL, DateTime Ngay, string tiet1, string tiet2, string tiet3)
        {

            string formattedDate = Ngay.ToString("yyyy-MM-dd");

            string sql = $@"
                            SELECT Tiet
                            FROM ChiTietLichDay
                            JOIN LichDay ON LichDay.ID = ChiTietLichDay.ID_LichDay
                            WHERE Ngay = '{formattedDate}' 
                              AND ID_LopHoc = {idL}
                              AND (Tiet = N'{tiet1}' OR Tiet = N'{tiet2}' OR Tiet = N'{tiet3}')
                        ";
            return Get(sql);
        }
        public DataTable GetDatatrungPH(int idph, DateTime Ngay, string tiet1, string tiet2, string tiet3)
        {

            string formattedDate = Ngay.ToString("yyyy-MM-dd");

            string sql = $@"
                            SELECT Tiet
                            FROM ChiTietLichDay
                            JOIN LichDay ON LichDay.ID = ChiTietLichDay.ID_LichDay
                            WHERE Ngay = '{formattedDate}' 
                              AND ID_Phong = {idph}
                              AND (Tiet = N'{tiet1}' OR Tiet = N'{tiet2}' OR Tiet = N'{tiet3}')
                        ";
            return Get(sql);
        }
        public int GetDataID(int IDMonHoc, int IDSinhVien)
        {
            string sql = @"select ID from Diem where ID_SinhVien =" + IDSinhVien + "' and ID_MonHoc= " + IDMonHoc + "";
            return base.GetID(sql);
        }
        public int UpdateData(int ID_Lop,int buoi, DateTime ngay)
        {
            string sql = @"UPDATE ChiTietLichDay SET Ngay= @Ngay WHERE ID_LichDay = @id_Lop and Buoi= @buoi";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@Ngay", SqlDbType.Date).Value = ngay;
                command.Parameters.Add("@id_Lop", SqlDbType.Int).Value = ID_Lop;
     
                command.Parameters.Add("buoi", SqlDbType.Int).Value = buoi;
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
        public int UpdateData(int ID_Lop, int buoi, string tiet)
        {
            string sql = @"UPDATE ChiTietLichDay SET Tiet= @Ngay WHERE ID_LichDay = @id_Lop and Buoi= @buoi";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@Ngay", SqlDbType.NVarChar).Value = tiet;
                command.Parameters.Add("@id_Lop", SqlDbType.Int).Value = ID_Lop;

                command.Parameters.Add("buoi", SqlDbType.Int).Value = buoi;
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

        public int UpdateData(int ID_Lop,  int buoi, int phong)
        {
            string sql = @"UPDATE ChiTietLichDay SET ID_Phong= @Ngay WHERE ID_LichDay = @id_Lop and Buoi= @buoi";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@Ngay", SqlDbType.Int).Value = phong;
                command.Parameters.Add("@id_Lop", SqlDbType.Int).Value = ID_Lop;
        
                command.Parameters.Add("buoi", SqlDbType.Int).Value = buoi;
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
        public int DeleteDataAll(int IdLop, int idMonHoc)
        {
            string sql = @"DELETE FROM Diem where ID_MonHoc = @IDMonHoc
					 and ID_SinhVien in (select ID_SinhVien from SinhVien where ID_LopHoc = @IDLopHoc)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@IDLopHoc", SqlDbType.Int).Value = IdLop;
                command.Parameters.Add("@IDMonHoc", SqlDbType.Int).Value = idMonHoc;
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
