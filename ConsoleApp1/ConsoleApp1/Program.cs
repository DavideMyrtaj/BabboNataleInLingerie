using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Stato> ListaStati = JsonConvert.DeserializeObject<List<Stato>>(File.ReadAllText("ListaStati.json"));
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

            /* #region sium
             List<Coordinate> ListaLatitudine = JsonConvert.DeserializeObject<List<Coordinate>>(File.ReadAllText("Latitudine.json"));
             List<Nazione> Nazione = new List<Nazione>();


             foreach (Stato stato in ListaStati)
             {
                 Nazione.Add(new Nazione { NOME = stato.Name, CODICE = stato.Code2, LATITUDINE = ListaLatitudine.Find(x => x.Code == stato.Code2).Latitude });
             }

             SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MVIRBBM;Initial Catalog=mondo;Integrated Security=True");
             con.Open();
             for (int i = 0; i < Nazione.Count; i++)
             {
                 string query = $"INSERT INTO NAZIONE (NOME,CODICE,LATITUDINE) VALUES {Nazione[i].ToString()};";
                 SqlCommand cmd = new SqlCommand(query, con);
                 cmd.ExecuteNonQuery();
                 cmd.Dispose();
             }

             #endregion*/
            List<FusiOrari> ListaFusiOrari= JsonConvert.DeserializeObject<List<FusiOrari>>(File.ReadAllText("FusiOrari.json"));
            //List<Giocattoli> regali = JsonConvert.DeserializeObject<List<Giocattoli>>(File.ReadAllText("tabellaRegali.json"));
            con = new SqlConnection(@"Data Source=DESKTOP-MVIRBBM;Initial Catalog=mondo;Integrated Security=True");
            con.Open();
            
            for (int i = 0; i < nazioni.Count; i++)
            {

                List<FusiOrari> paeseCorrente = ListaFusiOrari.FindAll(x => x.Codice == nazioni[i]);
                if (paeseCorrente.Count==0)
                {
                    Console.WriteLine(nazioni[i]);
                }
                /* for (int j = 0; j < paeseCorrente.Count; j++)
                 {
                     query = $"INSERT INTO FUSO_ORARIO (NAZIONE,TIME_ZONE) VALUES {paeseCorrente[j].ToString()}";
                    cmd = new SqlCommand(query, con);
                     try
                     {
                         cmd.ExecuteNonQuery();
                     }
                     catch (SqlException) { }
                     

                 }*/
                /*string query = $@"INSERT INTO REGALO (TIPO,DESCRIZIONE) VALUES ('{regali[i].Regalo}','{regali[i].Descrizione}')";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();*/
            }
            Console.ReadKey();

        }
    }
    class Stato
    {
        public string Name;
        public string Code2;
        
    }
    class Coordinate
    {
        public string Latitude;
        public string Code;
    }
    
    class FusiOrari
    {
        public string Codice;
        public string TimeZone;

        public override string ToString()
        {
            string[] minuti= DateTime.Parse(TimeZone.Split(' ')[1].Substring(1)).ToString("hh:mm").Split(':');
            int tempo = int.Parse(minuti[0]) * 60 + int.Parse(minuti[1]);
            if (TimeZone.Split(' ')[1][0]=='-')
            {
                tempo = tempo * -1;
            }
            return $"('{Codice}','{tempo}')";
        }
    }
    class Giocattoli
    {
        public string Regalo;
        public string Descrizione;
    }
    class Nazione
    {
        public string NOME;
        public string CODICE;
        public string LATITUDINE;

        public override string ToString()
        {
            return $"('{NOME}','{CODICE}','{LATITUDINE}')";
        }
    }
}
