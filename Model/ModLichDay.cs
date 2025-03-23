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
    class ModLichDay:MOD 
    {
        ModDiemDanh modDiemDanh = new ModDiemDanh();
        ModDiem modDiem = new ModDiem();
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
        public DataTable GetData(int ID_MonHoc, int ID_LopHoc)
        {
            return Get($"select * from LichDay Where ID_MonHoc = {ID_MonHoc} and ID_LopHoc = { ID_LopHoc}");
        }
        public DataTable GetData2(int ID_LopHoc, int ID_HocKy)
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
                            and LopHoc.ID = "+ID_LopHoc+@" 
                            and HocKy.ID = " +ID_HocKy +@"
	                        group by GiaoVien.ID,MonHoc.ID, GiaoVien.Ten ,HinhThuc.ID,LopHoc.ID, MonHoc.TenMonHoc, HinhThuc.TenHinhThuc, LopHoc.TenLopHoc,MonHoc.SoGioLT/MonHoc.SoTiet1Buoi , TenKHoaHoc, TenNganhHoc, TenHocKy, LichDay.ID ");
        }
        public int GetData(OjbLichDay ojb)
        {
            string sql = @"select ID from LichDay where ID_LopHoc=" + ojb.Id_LopHoc + " and ID_MonHoc= " + ojb.Id_MonHoc;
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
        public int GetDataID(int IDMonHoc, int IDSinhVien)
        {
            string sql = @"select ID from Diem where ID_SinhVien =" + IDSinhVien + "' and ID_MonHoc= " + IDMonHoc + "";
            return base.GetID(sql);
        }
        public DataTable GetData(int IDLopHoc, DateTime Ngay,string tiet, string tiet2)
        {
            string sql = $@"select MonHoc.TenMonHoc,HinhThuc.TenHinhThuc, PhongHoc.TenPhongHoc, GiaoVien.Ten
                        from MonHoc, LichDay, ChiTietLichDay, GiaoVien, HinhThuc, PhongHoc
                        where MonHoc.ID = LichDay.ID_MonHoc 
                            and PhongHoc.ID = ChiTietLichDay.ID_Phong
	                        and MonHoc.ID_HinhThuc = HinhThuc.ID
	                        and LichDay.ID = ChiTietLichDay.ID_LichDay
	                        and LichDay.ID_GiaoVien = GiaoVien.ID
	                        and ChiTietLichDay.Ngay = '{Ngay.ToString("yyyy-MM-dd")}'
	                        and LichDay.ID_LopHoc = {IDLopHoc}
	                        and (ChiTietLichDay.Tiet = N'{tiet}' or ChiTietLichDay.Tiet = N'{tiet2}')";
            return base.Get(sql);
        }
        public DataTable GetData(int IDGiaoVien, string tiet, string tiet2, DateTime Ngay )
        {
            string sql = $@"select MonHoc.TenMonHoc,HinhThuc.TenHinhThuc, PhongHoc.TenPhongHoc, LopHoc.TenLopHoc
                        from MonHoc, LichDay, ChiTietLichDay, GiaoVien, HinhThuc, PhongHoc, LopHoc
                        where MonHoc.ID = LichDay.ID_MonHoc
                            and LopHoc.ID = LichDay.ID_LopHoc
                            and PhongHoc.ID = ChiTietLichDay.ID_Phong
	                        and MonHoc.ID_HinhThuc = HinhThuc.ID
	                        and LichDay.ID = ChiTietLichDay.ID_LichDay
	                        and LichDay.ID_GiaoVien = GiaoVien.ID
	                        and ChiTietLichDay.Ngay = '{Ngay.ToString("yyyy-MM-dd")}'
	                        and LichDay.ID_GiaoVien = {IDGiaoVien}
	                        and (ChiTietLichDay.Tiet = N'{tiet}' or ChiTietLichDay.Tiet = N'{tiet2}')";
            return base.Get(sql);
        }
        public DataTable GetData( DateTime Ngay, string tiet, string tiet2)
        {
            string sql = $@"SELECT PhongHoc.TenPhongHoc, PhongHoc.LoaiPhong
                            FROM PhongHoc
                            WHERE PhongHoc.ID NOT IN (
                                SELECT PhongHoc.ID
                                FROM MonHoc, LichDay, ChiTietLichDay, GiaoVien, HinhThuc, PhongHoc
                                WHERE MonHoc.ID = LichDay.ID_MonHoc 
                                  AND PhongHoc.ID = ChiTietLichDay.ID_Phong
                                  AND MonHoc.ID_HinhThuc = HinhThuc.ID
                                  AND LichDay.ID = ChiTietLichDay.ID_LichDay
                                  AND LichDay.ID_GiaoVien = GiaoVien.ID
                                  AND ChiTietLichDay.Ngay = '{Ngay.ToString("yyyy-MM-dd")}'
                                  AND (ChiTietLichDay.Tiet = N'{tiet}' or ChiTietLichDay.Tiet = N'{tiet2}')
)";
            return base.Get(sql);
        }
        public DataTable GetData(DateTime Ngay, string tiet, string tiet2, string tiet3)
        {
            string sql = $@"SELECT PhongHoc.TenPhongHoc, PhongHoc.LoaiPhong
                            FROM PhongHoc
                            WHERE PhongHoc.ID NOT IN (
                                SELECT PhongHoc.ID
                                FROM MonHoc, LichDay, ChiTietLichDay, GiaoVien, HinhThuc, PhongHoc
                                WHERE MonHoc.ID = LichDay.ID_MonHoc 
                                  AND PhongHoc.ID = ChiTietLichDay.ID_Phong
                                  AND MonHoc.ID_HinhThuc = HinhThuc.ID
                                  AND LichDay.ID = ChiTietLichDay.ID_LichDay
                                  AND LichDay.ID_GiaoVien = GiaoVien.ID
                                  AND ChiTietLichDay.Ngay = '{Ngay.ToString("yyyy-MM-dd")}'
                                  AND (ChiTietLichDay.Tiet = N'{tiet}' or ChiTietLichDay.Tiet = N'{tiet2}' or ChiTietLichDay.Tiet = N'{tiet3}')
)";
            return base.Get(sql);
        }
        public int InsertData(OjbLichDay ojb)
        {
         
            int x = 0;
            try
            {
                conn.OpenConn();
             
                    string sql4 = @"Insert into LichDay(ID_GiaoVien, ID_LopHoc,ID_MonHoc) values (@ID_GiaoVien3, @ID_LopHoc3,@ID_MonHoc3) ;SELECT SCOPE_IDENTITY();";
                    command.CommandText = sql4;
                    command.Connection = conn.Connection;
                    command.Parameters.Add("@ID_GiaoVien3", SqlDbType.Int).Value = ojb.Id_GiaoVien;
                    command.Parameters.Add("@ID_LopHoc3", SqlDbType.Int).Value = ojb.Id_LopHoc;
                    command.Parameters.Add("@ID_MonHoc3", SqlDbType.Int).Value = ojb.Id_MonHoc;
                    int id_LichDay = Convert.ToInt32(command.ExecuteScalar());


                string sql5 = ($"select SinhVien.ID from SinhVien where ID_LopHoc = {ojb.Id_LopHoc}");
                DataTable dataSinhVien = base.Get(sql5);


                string sql3 = ("select (SoGioLT/SoTiet1Buoi) as soBuoi from MonHoc where ID= @ID_MonHoc2");
                command.CommandText = sql3;
                command.Parameters.Clear();
                command.Parameters.Add("@ID_MonHoc2", SqlDbType.Int).Value = ojb.Id_MonHoc;
                object result = command.ExecuteScalar();
                int soBuoi = Convert.ToInt32(result);

                for(int i = 1; i<= soBuoi; i++)
                {
                    string sql = @"Insert into ChiTietLichDay(ID_LichDay, Buoi) values (@ID_LichDay"+i+ ", @Buoi" + i + ");SELECT SCOPE_IDENTITY();";
                    command.CommandText = sql;
                    command.Connection = conn.Connection;
                    command.Parameters.Add("@ID_LichDay"+i, SqlDbType.Int).Value = id_LichDay;
                    command.Parameters.Add("@Buoi"+i, SqlDbType.Int).Value = i;
                    int id_CTLD = Convert.ToInt32(command.ExecuteScalar());
                  
                    foreach(DataRow row in dataSinhVien.Rows)
                    {
                        modDiemDanh.insert(Convert.ToInt32(row[0]), id_CTLD);
                    }
                }
                foreach (DataRow row in dataSinhVien.Rows)
                {
                    modDiem.insert(Convert.ToInt32(row[0]), id_LichDay, 1);
                }
                x = 1;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
                x = 0;
            }
            finally
            {
                conn.CloseConn();
            }
            return x;
        }

        public int UpdateData(int ID_Lop, int ID_Mon,int buoi, DateTime ngay)
        {
            string sql = @"UPDATE LichDay SET Ngay= @Ngay WHERE ID_LopHoc = @id_Lop and ID_MonHoc = @ID_Mon and Buoi= @buoi";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@Ngay", SqlDbType.Date).Value = ngay;
                command.Parameters.Add("@id_Lop", SqlDbType.Int).Value = ID_Lop;
                command.Parameters.Add("ID_Mon", SqlDbType.Int).Value = ID_Mon;
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
        public int UpdateData(int ID_Lop, int ID_Mon, int buoi,string tiet)
        {
            string sql = @"UPDATE LichDay SET Tiet= @Ngay WHERE ID_LopHoc = @id_Lop and ID_MonHoc = @ID_Mon and Buoi= @buoi";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@Ngay", SqlDbType.NVarChar).Value = tiet;
                command.Parameters.Add("@id_Lop", SqlDbType.Int).Value = ID_Lop;
                command.Parameters.Add("ID_Mon", SqlDbType.Int).Value = ID_Mon;
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
        public int UpdateData(int id_Giaovien, int id_Mon, int id_Lop)
        {
            string sql = @"UPDATE LichDay SET ID_GiaoVien= @ID_GiaoVien WHERE ID_LopHoc = @id_Lop and ID_MonHoc = @ID_Mon";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@ID_GiaoVien", SqlDbType.Int).Value = id_Giaovien;
                command.Parameters.Add("@id_Lop", SqlDbType.Int).Value = id_Lop;
                command.Parameters.Add("ID_Mon", SqlDbType.Int).Value = id_Mon;

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

        public int DeleteData(OjbDiem ojb)
        {
            string sql = @"delete from Diem where ID= @ID";
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
