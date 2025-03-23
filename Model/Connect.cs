using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace QLDSV
{
    class Connect
    {
        private SqlConnection Conn;
      //  private SqlCommand cmd;
        private string StrCon = null;
        private string err;

        public SqlConnection Connection { get => Conn;}
      //  public SqlCommand Cmd { get => cmd; set => cmd = value; }
        public string Err { get => err; set => err = value; }

        public Connect()
        {
            StrCon = @"Data Source=DESKTOP-7LIEGBK;Initial Catalog=QLDSV;Integrated Security=True";
            Conn = new SqlConnection(StrCon);
        }

        public bool OpenConn()
        {
            try
            {
                if(Conn.State  == ConnectionState.Closed)
                {
                    Conn.Open();
                }
            }
            catch(Exception ex)
            {
                err = ex.Message;
                return false;
            }
            return true;
        }

        public bool CloseConn()
        {
            try
            {
                if(Conn.State == ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }catch(Exception ex)
            {
                err = ex.Message;
                return false;
            }
            return true;
        }
    }
}
