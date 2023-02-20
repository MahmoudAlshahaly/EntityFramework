using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay2
{
   public  class databaselayer
    {
        SqlConnection con;
        public databaselayer()
        {
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ITIS;Integrated Security=True");
        }

        public DataTable select(string cmd)
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd,con);
            DataTable tbl = new DataTable();
            da.Fill(tbl);
            return tbl;
        }
        public int execute(string cmd)
        {
            SqlCommand sqlCommand = new SqlCommand(cmd,con);
            con.Open();
            int affected = sqlCommand.ExecuteNonQuery();
            con.Close();
            return affected;

        }
    }
}
