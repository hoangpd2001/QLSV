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
    class ModDiem:MOD
    {
        public DataTable GetData()
        {
            return Get("select Diem.ID,Diem,ID_SinhVien,ID_MonHoc,MaSinhVien,TenSinhVien,TenLopHoc,TenMonHoc,SoGioLT,SoTiet1Buoi, TenHinhThuc,TenHocKy,TenNganhHoc,TenKhoaHoc from HinhThuc, HocKy, NganhHoc, KhoaHoc,MonHoc,LopHoc,SinhVien,Diem where NganhHoc.ID_KhoaHoc= KhoaHoc.ID and HocKy.ID_NganhHoc=NganhHoc.ID and HinhThuc.ID_HocKy= HocKy.ID and MonHoc.ID_HinhThuc=HinhThuc.ID and LopHoc.ID_NganhHoc=NganhHoc.ID and SinhVien.ID_LopHoc=LopHoc.ID and Diem.ID_SinhVien = SinhVien.ID and Diem.ID_MonHoc=MonHoc.ID  ");
        }
        public DataTable GetDataReport(string IDSInhVien)
        {
            return Get($@"SELECT 
                    HocKy.TenHocKy,
                    MonHoc.TenMonHoc,
                    HinhThuc.TenHinhThuc,
                    CASE 
                        WHEN MAX(CASE WHEN Diem.LanThi = 2 THEN Diem.Diem END) IS NOT NULL THEN 
                            (MAX(CASE WHEN Diem.LanThi = 1 THEN Diem.Diem END) * 3 + 
                             MAX(CASE WHEN Diem.LanThi = 2 THEN Diem.Diem END) * 7) / 10
                        ELSE 
                            MAX(CASE WHEN Diem.LanThi = 1 THEN Diem.Diem END)
                    END AS Diem
                FROM 
                    MonHoc
                    LEFT JOIN LichDay ON MonHoc.ID = LichDay.ID_MonHoc
                    INNER JOIN Diem ON LichDay.ID = Diem.ID_LichDay
                    INNER JOIN SinhVien ON Diem.ID_SinhVien = SinhVien.ID AND SinhVien.MaSinhVien = '{IDSInhVien}'
                    INNER JOIN HinhThuc ON MonHoc.ID_HinhThuc = HinhThuc.ID
                    INNER JOIN HocKy ON HinhThuc.ID_HocKy = HocKy.ID
                    INNER JOIN NganhHoc ON HocKy.ID_NganhHoc = NganhHoc.ID
                GROUP BY 
                    HocKy.TenHocKy, 
                    MonHoc.TenMonHoc, 
                    HinhThuc.TenHinhThuc
                ORDER BY 
                    HocKy.TenHocKy ASC, 
                    MonHoc.TenMonHoc ASC, 
                    HinhThuc.TenHinhThuc ASC;

                        ");
        }
        public DataTable GetDataReportDiem2( int IDlop)
        {
            return Get("SELECT Diem.ID, Diem, ID_SinhVien, ID_MonHoc, MaSinhVien, TenSinhVien, TenLopHoc, TenMonHoc, SoGioLT, SoTiet1Buoi, TenHinhThuc, TenHocKy, TenNganhHoc, TenKhoaHoc FROM Diem LEFT JOIN SinhVien ON Diem.ID_SinhVien = SinhVien.ID LEFT JOIN MonHoc ON Diem.ID_MonHoc = MonHoc.ID LEFT JOIN LopHoc ON SinhVien.ID_LopHoc = LopHoc.ID LEFT JOIN NganhHoc ON LopHoc.ID_NganhHoc = NganhHoc.ID LEFT JOIN KhoaHoc ON NganhHoc.ID_KhoaHoc = KhoaHoc.ID LEFT JOIN HocKy ON NganhHoc.ID = HocKy.ID_NganhHoc LEFT JOIN HinhThuc ON MonHoc.ID_HinhThuc = HinhThuc.ID WHERE ID_LopHoc = " + IDlop );
        }
        public DataTable GetDataReportDiem(int IDlop)
        {
            return Get($@"SELECT 
                         SinhVien.MaSinhVien,
                        SinhVien.TenSinhVien,
                        LopHoc.TenLopHoc,
                        MonHoc.TenMonHoc,
                        MonHoc.SoGioLT,
                        MonHoc.SoTiet1Buoi,
                        HinhThuc.TenHinhThuc,
                        HocKy.TenHocKy,
                        NganhHoc.TenNganhHoc,
                        KhoaHoc.TenKhoaHoc,
                        CASE 
                            WHEN MAX(CASE WHEN Diem.LanThi = 2 THEN Diem.Diem END) IS NOT NULL THEN 
                                (MAX(CASE WHEN Diem.LanThi = 1 THEN Diem.Diem END) * 3 + 
                                 MAX(CASE WHEN Diem.LanThi = 2 THEN Diem.Diem END) * 7) / 10
                            ELSE 
                                MAX(CASE WHEN Diem.LanThi = 1 THEN Diem.Diem END)
                        END AS Diem
                    FROM 
                        HinhThuc
                        INNER JOIN HocKy ON HinhThuc.ID_HocKy = HocKy.ID
                        INNER JOIN NganhHoc ON HocKy.ID_NganhHoc = NganhHoc.ID
                        INNER JOIN KhoaHoc ON NganhHoc.ID_KhoaHoc = KhoaHoc.ID
                        INNER JOIN MonHoc ON MonHoc.ID_HinhThuc = HinhThuc.ID
                        INNER JOIN LopHoc ON LopHoc.ID_NganhHoc = NganhHoc.ID
                        INNER JOIN SinhVien ON SinhVien.ID_LopHoc = LopHoc.ID
                        INNER JOIN Diem ON Diem.ID_SinhVien = SinhVien.ID
                        INNER JOIN LichDay ON Diem.ID_LichDay = LichDay.ID AND LichDay.ID_MonHoc = MonHoc.ID
                    WHERE 
                        LopHoc.ID = {IDlop}
                    GROUP BY 
                        SinhVien.MaSinhVien,
                        SinhVien.TenSinhVien,
                        LopHoc.TenLopHoc,
                        MonHoc.TenMonHoc,
                        MonHoc.SoGioLT,
                        MonHoc.SoTiet1Buoi,
                        HinhThuc.TenHinhThuc,
                        HocKy.TenHocKy,
                        NganhHoc.TenNganhHoc,
                        KhoaHoc.TenKhoaHoc;
                    ");
        }
        public DataTable GetDataReportDiem3(int MonHoc)
        {
            return Get($@"
                        SELECT
                            SinhVien.MaSinhVien,
                            SinhVien.TenSinhVien,
	                        LopHoc.TenLopHoc,
                            CASE
                                WHEN MAX(CASE WHEN Diem.LanThi = 2 THEN Diem.Diem END) IS NOT NULL THEN
                                    (MAX(CASE WHEN Diem.LanThi = 1 THEN Diem.Diem END) * 3 +
                                     MAX(CASE WHEN Diem.LanThi = 2 THEN Diem.Diem END) * 7) / 10
                                ELSE
                                    MAX(CASE WHEN Diem.LanThi = 1 THEN Diem.Diem END)
                            END AS Diem
                        FROM
                            HinhThuc
                            INNER JOIN HocKy ON HinhThuc.ID_HocKy = HocKy.ID
                            INNER JOIN NganhHoc ON HocKy.ID_NganhHoc = NganhHoc.ID
                            INNER JOIN KhoaHoc ON NganhHoc.ID_KhoaHoc = KhoaHoc.ID
                            INNER JOIN MonHoc ON MonHoc.ID_HinhThuc = HinhThuc.ID
                            INNER JOIN LopHoc ON LopHoc.ID_NganhHoc = NganhHoc.ID
                            INNER JOIN SinhVien ON SinhVien.ID_LopHoc = LopHoc.ID
                            INNER JOIN Diem ON Diem.ID_SinhVien = SinhVien.ID
                            INNER JOIN LichDay ON Diem.ID_LichDay = LichDay.ID AND LichDay.ID_MonHoc = MonHoc.ID
                        WHERE
                            MonHoc.ID = {MonHoc}
                        GROUP BY
                            SinhVien.MaSinhVien,
                            SinhVien.TenSinhVien,
                            LopHoc.TenLopHoc,
                            MonHoc.TenMonHoc,
                            MonHoc.SoGioLT,
                            MonHoc.SoTiet1Buoi,
                            HinhThuc.TenHinhThuc,
                            HocKy.TenHocKy,
                            NganhHoc.TenNganhHoc,
                            KhoaHoc.TenKhoaHoc
                        HAVING
                            CASE
                                WHEN MAX(CASE WHEN Diem.LanThi = 2 THEN Diem.Diem END) IS NOT NULL THEN
                                    (MAX(CASE WHEN Diem.LanThi = 1 THEN Diem.Diem END) * 3 +
                                     MAX(CASE WHEN Diem.LanThi = 2 THEN Diem.Diem END) * 7) / 10
                                ELSE
                                    MAX(CASE WHEN Diem.LanThi = 1 THEN Diem.Diem END)
                            END < 5
                            OR CASE
                                WHEN MAX(CASE WHEN Diem.LanThi = 2 THEN Diem.Diem END) IS NOT NULL THEN
                                    (MAX(CASE WHEN Diem.LanThi = 1 THEN Diem.Diem END) * 3 +
                                     MAX(CASE WHEN Diem.LanThi = 2 THEN Diem.Diem END) * 7) / 10
                                ELSE
                                    MAX(CASE WHEN Diem.LanThi = 1 THEN Diem.Diem END)
                            END IS NULL;

                    ");
        }
        public DataTable GetData(string where)
        {
            string sql = "select Diem.ID,Diem,ID_SinhVien,ID_MonHoc,MaSinhVien,TenSinhVien,TenLopHoc,TenMonHoc,SoGioLT,SoTiet1Buoi, TenHinhThuc,TenHocKy,TenNganhHoc,TenKhoaHoc from HinhThuc, HocKy, NganhHoc, KhoaHoc,MonHoc,LopHoc,SinhVien,Diem where NganhHoc.ID_KhoaHoc= KhoaHoc.ID and HocKy.ID_NganhHoc=NganhHoc.ID and HinhThuc.ID_HocKy= HocKy.ID and MonHoc.ID_HinhThuc=HinhThuc.ID and LopHoc.ID_NganhHoc=NganhHoc.ID and SinhVien.ID_LopHoc=LopHoc.ID and Diem.ID_SinhVien = SinhVien.ID and Diem.ID_MonHoc=MonHoc.ID   " + where;
            return Get(sql);
        }
        public int GetDataID(int IDMonHoc, int IDSinhVien)
        {
            string sql = @"select ID from Diem where ID_SinhVien =" + IDSinhVien + "' and ID_MonHoc= " + IDMonHoc + "";
            return base.GetID(sql);
        }
        public string GetData(int id_SinhVien, int id_LichDay, int LanThi)
        {
            string sql = @"Select Diem from Diem Where ID_SinhVien = @sv and  ID_LichDay= @ld and LanThi = @tt";
            string x = "-1";
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@sv", SqlDbType.Int).Value = id_SinhVien;
                command.Parameters.Add("@ld", SqlDbType.Int).Value = id_LichDay;
                command.Parameters.Add("@tt", SqlDbType.Int).Value = LanThi;
                var result =command.ExecuteReader();
                if (!result.HasRows)
                {
                    x= "-1";
                    result.Close();
                }
                else
                {
                    while (result.Read())
                    {
                        if (result["Diem"] == DBNull.Value)
                        {
                            x=null;
                        }
                        else
                        {
                            x= result["Diem"].ToString();
                        }
                    }
                    result.Close();
                }
              
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
        public int insert(int id_SinhVien, int id_LichDay, int LanThi)
        {
            string sql = @"Insert into Diem(ID_SinhVien, ID_LichDay, LanThi) values (@sv,@ld,@tt)";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@sv", SqlDbType.Int).Value = id_SinhVien;
                command.Parameters.Add("@ld", SqlDbType.Int).Value = id_LichDay;
                command.Parameters.Add("@tt", SqlDbType.Int).Value = LanThi;
                x = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.CloseConn();
            }
            return x;
        }

        public int UpdateData(OjbDiem ojb)
        {
            string sql;
            if (ojb.Diem == -1)
            {
                int q = 0;
                try
                {
                    sql = @"UPDATE Diem SET Diem= @Diem WHERE ID_SinhVien = @sv and ID_LichDay = @ld and LanThi = @LT";
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@Diem", SqlDbType.Int).Value = DBNull.Value;
                command.Parameters.Add("@sv", SqlDbType.Int).Value = ojb.Id_SinhVien;
                command.Parameters.Add("@ld", SqlDbType.Int).Value = ojb.Id_LichDay;
                command.Parameters.Add("@LT", SqlDbType.Int).Value = ojb.LanThi;
                 q = command.ExecuteNonQuery();
                if (ojb.LanThi == 1)
                {
                    DeleteData(ojb.Id_SinhVien, ojb.Id_LichDay, 2);
                }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    conn.CloseConn();
                }
                return q;
            }
            else
             sql = @"UPDATE Diem SET Diem= @Diem WHERE ID_SinhVien = @sv and ID_LichDay = @ld and LanThi = @LT";
            int x = 0;
            try
            {
                

                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@Diem", SqlDbType.Int).Value = ojb.Diem;
                command.Parameters.Add("@sv", SqlDbType.Int).Value = ojb.Id_SinhVien;
                command.Parameters.Add("@ld", SqlDbType.Int).Value = ojb.Id_LichDay;
                command.Parameters.Add("@LT", SqlDbType.Int).Value = ojb.LanThi;
                x = command.ExecuteNonQuery();
                if(ojb.Diem < 5 && ojb.LanThi == 1)
                {
                    insert(ojb.Id_SinhVien, ojb.Id_LichDay, 2);
                }
                else if(ojb.Diem >=5 && ojb.LanThi == 1)
                {
                    DeleteData(ojb.Id_SinhVien, ojb.Id_LichDay, 2);
                }
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

        public int DeleteData(int id_SinhVien, int id_LichDay, int LanThi)
        {
            string sql = @"delete from Diem where ID_SinhVien = @sv and ID_LichDay = @ld and LanThi = @LT";
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                command.Parameters.Clear();
                command.Parameters.Add("@sv", SqlDbType.Int).Value = id_SinhVien;
                command.Parameters.Add("@ld", SqlDbType.Int).Value = id_LichDay;
                command.Parameters.Add("@LT", SqlDbType.Int).Value = LanThi;
                x = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                x = -1;
                MessageBox.Show(ex.Message);
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
