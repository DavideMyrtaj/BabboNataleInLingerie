using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Data.SqlClient;

namespace ConsoleApp2
{
    class Program
    {
        static Random gen = new Random();
        static DateTime RandomDay()
        {
            DateTime start = new DateTime(2012, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MVIRBBM;Initial Catalog=mondo;Integrated Security=True");
            string query = "SELECT CODICE FROM NAZIONE";
            List<string> nazioni = new List<string>();
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader leggi;
            leggi = cmd.ExecuteReader();
            while (leggi.Read())
            {
                nazioni.Add(leggi["CODICE"].ToString());
            }
            leggi.Close();
            cmd.Dispose();


            List<string> queryList = new List<string>();
           
            for (int i = 0; i < 2000; i++)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                Random random = rand;
                RandomName nameGen = new RandomName(rand);
                List<Bambino> ListaBambini = new List<Bambino>();
                List<string> Names = nameGen.RandomNames(500, 0);
                
                query = "INSERT INTO BAMBINO (NOME,COGNOME,DATA_NASCITA,BONTA,NAZIONE) VALUES ";

                foreach (string fr in Names)
                {
                    string[] nome = fr.Split(' ');
                    ListaBambini.Add(new Bambino { Nome = nome[0], Cognome = nome[1], Data_Nascita = RandomDay().ToString("dd/MM/yyyy"), Bonta = random.Next(101), Nazione = nazioni[random.Next(nazioni.Count)] });
                }
                Names.Clear();
                string dati = string.Join(",", ListaBambini);
                ListaBambini.Clear();
                query += dati + ";";
                queryList.Add(query);
                
            }
            foreach (string item in queryList)
            {
                cmd = new SqlCommand(item, con);
                cmd.ExecuteNonQuery();
            }


        }

    }
    class Bambino
    {
       
        public string Nome;
        public string Cognome;
        public string Data_Nascita;
        public int Bonta;
        public string Nazione;
        public override string ToString()
        {

            return $"('{Nome}','{Cognome}','{Data_Nascita}','{Bonta}','{Nazione}')";
        }
    }
}
