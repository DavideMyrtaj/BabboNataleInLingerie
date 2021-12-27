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
        SqlCommand cmd;
        SqlDataReader leggi;
        public modello()
        {
            con = new SqlConnection(@"Data Source=.;Initial Catalog=mondo;Integrated Security=True");
            try
            {
                con.Open();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);

            }
        }
        
        /// <summary>
        /// inserisci il codice nazione per farti restituire una lista di bambini appartenenti a quella Nazione
        /// </summary>
        /// <param name="Nazione"></param>
        /// <returns></returns>
        public List<Bambino> BambiniNazione(string Nazione)
        {
            List<Bambino> lista = new List<Bambino>();
            string query = $"SELECT * FROM BAMBINO WHERE NAZIONE='{Nazione}'";
            cmd = new SqlCommand(query, con);
            leggi=cmd.ExecuteReader();

            while (leggi.Read())
            {
                lista.Add(new Bambino {Nome=leggi["NOME"].ToString(),Cognome=leggi["COGNOME"].ToString(),Data_Nascita=DateTime.Parse(leggi["DATA_NASCITA"].ToString()),Bonta=int.Parse( leggi["BONTA"].ToString()),Nazione=leggi["NAZIONE"].ToString() });
            }
            return lista;
        }

    }
    class Bambino
    {
        public string Nome;
        public string Cognome;
        public DateTime Data_Nascita;
        public int Bonta;
        public string Nazione;
    }
}
