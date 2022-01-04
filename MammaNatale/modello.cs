using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
namespace MammaNatale
{
    class modello
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader leggi;
        DataTable table;
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
        public DataTable BambiniNazioneConRegali(string Nazione)
        {
            List<Bambino> lista = new List<Bambino>();
            string query = $@"SELECT BAMBINO.ID, BAMBINO.NOME ,BAMBINO.COGNOME,BAMBINO_REGALO.ID_REGALO,REGALO.TIPO ,REGALO.DESCRIZIONE  FROM BAMBINO  
inner join BAMBINO_REGALO on BAMBINO.ID = BAMBINO_REGALO.ID_BAMBINO
INNER JOIN REGALO on BAMBINO_REGALO.ID_REGALO = REGALO.ID
WHERE BAMBINO.NAZIONE = '{Nazione}'
ORDER BY BAMBINO.ID ";
            cmd = new SqlCommand(query, con);
            leggi=cmd.ExecuteReader();
            table = new DataTable();
            table.Load(leggi);
            leggi.Close();
           
            return table;
        }

        /// <summary>
        /// restituisce una lista ordinata per latitudine, crescente o decrescente, di tutti i paesi di quel fuso orario
        /// </summary>
        /// <param name="TimeZone"></param>
        /// <param name="ordine"></param>
        /// <returns></returns>
        public DataTable ListaNazioniFusoOrarioOrdinate(int TimeZone, ref List<Nazione>Nazioni)
        {
            DataTable tabella = new DataTable();
            Nazioni = new List<Nazione>();
            string ordine;
            if ((TimeZone/60)%2==0)
            {
                ordine = "DESC";//se fuso orario pari (+12,+10...-8,-10) allora ordina per latitudine decrescente (dall'alto verso il basso)
            }
            else
            {
                ordine = "";//se fuso orario dispari (+11,+19...-9,-11) allora ordina per latitudine crescnte di default(dal basso verso l'alto)
            }
            cmd = new SqlCommand($"SELECT ora.NAZIONE, NAZIONE.NOME,NAZIONE.LATITUDINE  FROM FUSO_ORARIO as ora inner join NAZIONE on ora.NAZIONE = NAZIONE.CODICE AND ora.TIME_ZONE = '{TimeZone}' ORDER BY NAZIONE.LATITUDINE {ordine}", con);
            leggi = cmd.ExecuteReader();
            tabella.Load(leggi);
            foreach (DataRow item in tabella.Rows)
            {
                Nazioni.Add(new Nazione { Codice = item["NAZIONE"].ToString(), Nome = item["NOME"].ToString(), Latitudine = item["LATITUDINE"].ToString() });
            }
            
                
            
            leggi.Close();
            return tabella;
        }
        
        public List<int> ListaFusiOrariEsistenti()
        {
            List<int> lista = new List<int>();
            cmd = new SqlCommand("SELECT DISTINCT TIME_ZONE from FUSO_ORARIO order by TIME_ZONE DESC", con);
            leggi = cmd.ExecuteReader();
            while (leggi.Read())
            {
                lista.Add((int)leggi["TIME_ZONE"]);
            }
            leggi.Close();
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
    class Nazione
    {
        public string Codice;
        public string Nome;
        public string Latitudine;
    }
}
