using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Register_Form
{
     class DBcon
    {
     
        private SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-HP4VRMA2\SQLEXPRESS;Initial Catalog=RegistrationDB;Integrated Security=True");
        public SqlConnection GetCon() 
        { return con; }
        public void Opencon()
        {
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
        }
        public void Closecon()
        {
            if (con.State == ConnectionState.Open)
            { con.Close(); }
        }
    }
}
