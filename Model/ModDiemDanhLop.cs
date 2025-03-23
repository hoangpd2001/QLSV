using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Model
{
    class ModDiemDanhLop:MOD
    {
        public DataTable GetData(int ID_Lop, int ID_Mon)
        {
            return Get(@"select SinhVien.MaSinhVien, SinhVien.TenSinhVien, DiemDanh.TrangThai, ChiTietLichDay.Buoi
	                            from ChiTietLichDay, DiemDanh, SinhVien, LichDay
	                            where SinhVien.ID = DiemDanh.ID_SinhVien
	                            and DiemDanh.ID_ChiTietLichDay = ChiTietLichDay.ID
	                            and LichDay.ID =ChiTietLichDay.ID_LichDay
	                            and SinhVien.ID_LopHoc= " + ID_Lop + @"
	                            and LichDay.ID_MonHoc = " + ID_Mon);
        }
            public DataTable GetData2(int ID_Lop, int ID_Mon)
            {
                return Get(@"SELECT 
                            SinhVien.MaSinhVien, 
                            SinhVien.TenSinhVien, 
                            SinhVien.ID,
                            CASE 
                                WHEN DiemDanh.TrangThai = 1 THEN '+'
                                ELSE '-' 
                            END AS TrangThai,
                            ChiTietLichDay.Buoi,
                            CASE 
                                WHEN (SELECT COUNT(CASE WHEN DiemDanh.TrangThai = 1 THEN 1 END) * 100 
                                      / COUNT(*) 
                                      FROM DiemDanh 
                                      JOIN ChiTietLichDay ON DiemDanh.ID_ChiTietLichDay = ChiTietLichDay.ID
                                      JOIN LichDay ON ChiTietLichDay.ID_LichDay = LichDay.ID
                                      WHERE DiemDanh.ID_SinhVien = SinhVien.ID 
                                      AND LichDay.ID_MonHoc =  " + ID_Mon + @") >= 80 THEN 'Lan 1'
                                WHEN (SELECT COUNT(CASE WHEN DiemDanh.TrangThai = 1 THEN 1 END) * 100 
                                      / COUNT(*) 
                                      FROM DiemDanh 
                                      JOIN ChiTietLichDay ON DiemDanh.ID_ChiTietLichDay = ChiTietLichDay.ID
                                      JOIN LichDay ON ChiTietLichDay.ID_LichDay = LichDay.ID
                                      WHERE DiemDanh.ID_SinhVien = SinhVien.ID 
                                      AND LichDay.ID_MonHoc =  " + ID_Mon + @") >= 70 THEN 'Lan 2'
                                ELSE 'Hoc Lai'
                            END AS KetQua
                        FROM 
                            SinhVien
                        JOIN 
                            DiemDanh ON SinhVien.ID = DiemDanh.ID_SinhVien
                        JOIN 
                            ChiTietLichDay ON DiemDanh.ID_ChiTietLichDay = ChiTietLichDay.ID
                        JOIN 
                            LichDay ON ChiTietLichDay.ID_LichDay = LichDay.ID
                        WHERE 
                        SinhVien.ID_LopHoc = " + ID_Lop+ @"
                        AND LichDay.ID_MonHoc = " + ID_Mon + @"
                    GROUP BY 
                        SinhVien.MaSinhVien, 
                        SinhVien.TenSinhVien, 
                        ChiTietLichDay.Buoi,
	                    DiemDanh.TrangThai,
	                    LichDay.ID,
	                    SinhVien.ID
                    ORDER BY 
                           RIGHT(SinhVien.TenSinhVien, CHARINDEX(' ', REVERSE(SinhVien.TenSinhVien) + ' ') - 1),
                            CASE 
                                WHEN CHARINDEX(' ', REVERSE(SinhVien.TenSinhVien) + ' ') < LEN(SinhVien.TenSinhVien) 
                                THEN REVERSE(SUBSTRING(REVERSE(SinhVien.TenSinhVien), 
                                                       CHARINDEX(' ', REVERSE(SinhVien.TenSinhVien) + ' ') + 1, 
                                                       CHARINDEX(' ', REVERSE(SUBSTRING(REVERSE(SinhVien.TenSinhVien), 
                                                       CHARINDEX(' ', REVERSE(SinhVien.TenSinhVien) + ' ') + 1, LEN(SinhVien.TenSinhVien)) + ' ')) - 1))
                                ELSE ''
                            END,

                        ChiTietLichDay.Buoi;");
            } 
		}
}
