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
            
            
            

            try
            {
                con.Open();
            }
            catch (SqlException err)
            {

                Console.WriteLine(err.Message);
                return;
            }




            string query = "SELECT ID,BONTA from BAMBINO left join BAMBINO_REGALO on BAMBINO.ID = BAMBINO_REGALO.ID_BAMBINO WHERE BAMBINO_REGALO.ID_BAMBINO IS NULL;";
            cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<BambinoRegalo> inserimento;
            List <Bambino> IDBAMBINI = new List<Bambino>();
            while (reader.Read())
            {
                IDBAMBINI.Add(new Bambino { ID=reader["ID"].ToString(), Bonta=(int)reader["BONTA"]});
            
            }
            reader.Close();


            query = "SELECT ID FROM REGALO WHERE SPECIALE IS NULL";
            cmd = new SqlCommand(query, con);
            reader = cmd.ExecuteReader();
            List<string> RegaliNormali= new List<string>();
            while (reader.Read())
            {
                RegaliNormali.Add(reader["ID"].ToString());

            }
            reader.Close();

            query = "SELECT ID,SPECIALE FROM REGALO WHERE SPECIALE IS NOT NULL";
            cmd = new SqlCommand(query, con);
            reader = cmd.ExecuteReader();
            List<RegaloSpeciale> RegaloSpeciale= new List<RegaloSpeciale>();
            while (reader.Read())
            {
                RegaloSpeciale.Add(new RegaloSpeciale { ID = reader["ID"].ToString(), Speciale = reader["SPECIALE"].ToString() });

            }
            reader.Close();


            string inserimentoRegali;
            List<BambinoRegalo> DaInserire = new List<BambinoRegalo>();
            foreach (Bambino bambino in IDBAMBINI)
            {
                if (DaInserire.Count>996)
                {
                    inserimentoRegali = "INSERT INTO BAMBINO_REGALO (ID_BAMBINO,ID_REGALO) VALUES ";
                    inserimentoRegali += string.Join(",", DaInserire);
                    CMD = new SqlCommand(inserimentoRegali, con);
                    CMD.ExecuteNonQuery();
                    DaInserire = new List<BambinoRegalo>();
                }
                Random r = new Random();
               
                RegaliNormali=RegaliNormali.OrderBy(x => r.Next()).ToList();


                switch (bambino.Bonta)
                {
                    case int n when n ==100:

                        for (int i = 0; i < 3; i++)
                        {
                            DaInserire.Add(new BambinoRegalo {IDbambino=bambino.ID, IDregalo=RegaliNormali[i]});
                        }
                        DaInserire.Add(new BambinoRegalo { IDbambino=bambino.ID,IDregalo=RegaloSpeciale.Find(x=> x.Speciale=="ORSO").ID});
                        
                        
                        break;
                    case int n when n >= 70 & n < 100:
                        for (int i = 0; i < 3; i++)
                        {
                            DaInserire.Add(new BambinoRegalo { IDbambino = bambino.ID, IDregalo = RegaliNormali[i] });
                        }
                       
                        break;
                    case int n when n >= 40 & n < 70:
                        for (int i = 0; i < 2; i++)
                        {
                            DaInserire.Add(new BambinoRegalo { IDbambino = bambino.ID, IDregalo = RegaliNormali[i] });
                        }
                       
                        break;
                    case int n when n >= 10 & n < 40:
                        for (int i = 0; i < 1; i++)
                        {
                            DaInserire.Add(new BambinoRegalo { IDbambino = bambino.ID, IDregalo = RegaliNormali[i] });
                        }
                        
                        break;
                    case int n when n < 10:
                        DaInserire.Add(new BambinoRegalo { IDbambino = bambino.ID, IDregalo = RegaloSpeciale.Find(x => x.Speciale == "CARBONE").ID });

                        break;
                }
            }
            if (DaInserire.Count>0)
            {
                inserimentoRegali = "INSERT INTO BAMBINO_REGALO (ID_BAMBINO,ID_REGALO) VALUES ";
                inserimentoRegali += string.Join(",", DaInserire);
                CMD = new SqlCommand(inserimentoRegali, con);
                CMD.ExecuteNonQuery();
                
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
    class RegaloSpeciale
    {
        public string ID;
        public string Speciale;
    }
}
