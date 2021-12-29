using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AssegnaBambinoRegalo
{
    class Program
    {


        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=mondo;Integrated Security=True");
            SqlCommand cmd, CMD;
            SqlDataReader leggiRegali;
            List<BambinoRegalo> AssegnaRegali(string comando, string IDbambino)
            {
                List<BambinoRegalo> risultato = new List<BambinoRegalo>();
                CMD = new SqlCommand(comando,con);
                leggiRegali = CMD.ExecuteReader();
                while (leggiRegali.Read())
                {
                    risultato.Add(new BambinoRegalo { IDbambino = IDbambino, IDregalo = leggiRegali["ID"].ToString() });
                }
                leggiRegali.Close();
                return risultato;
            }
            BambinoRegalo Speciale(string comando, string IDbambino)
            {
                BambinoRegalo bambino= new BambinoRegalo();
                CMD = new SqlCommand(comando,con);
                leggiRegali = CMD.ExecuteReader();
                while (leggiRegali.Read())
                {
                     bambino= new BambinoRegalo { IDbambino = IDbambino, IDregalo = leggiRegali["ID"].ToString() };
                }
                leggiRegali.Close();
                return bambino;
                
            }
            void InsericiBambinoRegalo(List<BambinoRegalo> bambinoRegalos)
            {
                string inserimentoRegali = "INSERT INTO BAMBINO_REGALO (ID_BAMBINO,ID_REGALO) VALUES ";
                inserimentoRegali += string.Join(",", bambinoRegalos);
                CMD = new SqlCommand(inserimentoRegali, con);
                CMD.ExecuteNonQuery();
            }

            try
            {
                con.Open();
            }
            catch (SqlException err)
            {

                Console.WriteLine(err.Message);
                return;
            }



            string query = "SELECT ID,BONTA FROM BAMBINO";
            cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<BambinoRegalo> inserimento;
            List < Bambino> IDBAMBINI = new List<Bambino>();
            while (reader.Read())
            {
                IDBAMBINI.Add(new Bambino { ID=reader["ID"].ToString(), Bonta=(int)reader["BONTA"]});
            
            }
            reader.Close();
            foreach (Bambino bambino in IDBAMBINI)
            {


                
                
                switch (bambino.Bonta)
                {
                    case int n when n ==100:
                        inserimento = AssegnaRegali("SELECT TOP 3 ID FROM REGALO WHERE SPECIALE IS NULL ORDER BY NEWID()", bambino.ID);
                        inserimento.Add(Speciale("SELECT ID FROM REGALO WHERE SPECIALE='ORSO'", bambino.ID));
                        InsericiBambinoRegalo(inserimento);
                        break;
                    case int n when n >= 70 & n < 100:
                        inserimento = AssegnaRegali("SELECT TOP 3 ID FROM REGALO WHERE SPECIALE IS NULL ORDER BY NEWID()", bambino.ID);
                        InsericiBambinoRegalo(inserimento);
                        break;
                    case int n when n >= 40 & n < 70:
                        inserimento = AssegnaRegali("SELECT TOP 2 ID FROM REGALO WHERE SPECIALE IS NULL ORDER BY NEWID()", bambino.ID);
                        InsericiBambinoRegalo(inserimento);
                        break;
                    case int n when n >= 10 & n < 40:
                        inserimento = AssegnaRegali("SELECT TOP 1 ID FROM REGALO WHERE SPECIALE IS NULL ORDER BY NEWID()", bambino.ID);
                        InsericiBambinoRegalo(inserimento);
                        break;
                    case int n when n < 10:
                        inserimento = AssegnaRegali("SELECT ID FROM REGALO WHERE SPECIALE='CARBONE'", bambino.ID);
                        InsericiBambinoRegalo(inserimento);
                        break;
                }
            }
            
        }
    }
    class Bambino
    {
        public string ID;
        public int Bonta;
    }
    class BambinoRegalo
    {
        public string IDbambino;
        public string IDregalo;
        public override string ToString()
        {
            return $"('{IDbambino}','{IDregalo.Replace("'","''")}')";
        }
    }

}
