using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLDSV.Object;
using System.Data;

namespace QLDSV.Model
{
    class MOD
    {
        protected Connect conn = new Connect();
        protected SqlCommand command = new SqlCommand();
        protected SqlDataAdapter adapter = new SqlDataAdapter();

        public DataTable Get(string sql)
        {
            DataTable table = new DataTable();
            try
            {
                    conn.OpenConn();
                    command.CommandText = sql;
                    command.Connection = conn.Connection;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    return table;
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
        public int GetID(string sql)
        {
            int x = 0;
            try
            {
                conn.OpenConn();
                command.CommandText = sql;
                command.Connection = conn.Connection;
                object ojb = command.ExecuteScalar();
                if(ojb != null)
                {
                    x = int.Parse(ojb.ToString());
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                x= -1;
            }
            finally
            {
                conn.CloseConn();
            }
            return x;
        }
        


    }
}
