using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MammaNatale
{
    class modello
    {
        SqlConnection con;
        public modello()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-MVIRBBM;Initial Catalog=mondo;Integrated Security=True");
            try
            {
                con.Open();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);

            }
        }
        

    }
}
