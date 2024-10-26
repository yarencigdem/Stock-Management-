using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
   public static  class Connection

    {
        public static SqlConnection GetConnection() {
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Stock"].ConnectionString;



            return con;
        }




    }
}
