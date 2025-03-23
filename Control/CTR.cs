using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLDSV.Object;
using QLDSV.Model;
using System.Windows.Forms;

namespace QLDSV.Control
{
    class CTR
    {

        public DataTable ReadExcel(string file, string sheet)
        {
            DataTable table = new DataTable();


            try {
                    Microsoft.Office.Interop.Excel.Application xlapp;
                    Microsoft.Office.Interop.Excel.Workbook xlwordbook;
                    Microsoft.Office.Interop.Excel.Worksheet xlwordsheet;
                    Microsoft.Office.Interop.Excel.Range xlrange;

                    xlapp = new Microsoft.Office.Interop.Excel.Application();
                    xlwordbook = xlapp.Workbooks.Open(file);
                    xlwordsheet = xlwordbook.Worksheets[sheet];
                    xlrange = xlwordsheet.UsedRange;

                    for (int i = 1; i <= xlrange.Columns.Count; i++)
                    {
                        DataColumn column = new DataColumn("Column" + i);
                        table.Columns.Add(column);
                    }
                    for (int row = 1; row <= xlrange.Rows.Count; row++)
                    {
                        DataRow newRow = table.NewRow();
                        for (int col = 1; col <= xlrange.Columns.Count; col++)
                        {
                            newRow[col - 1] = xlrange.Cells[row, col].Value;
                        }
                        table.Rows.Add(newRow);
                    }
                    xlwordbook.Close();
                    xlapp.Quit();
                
            }
            catch (Exception ex)
            {
                return null;
            }
          
            
            return table;
        }
        
    }


}

