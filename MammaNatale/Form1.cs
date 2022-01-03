using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MammaNatale
{
    public partial class Form1 : Form
    {
        modello Modello;
        List<int> FusiOrariEsistenti = new List<int>();
        List<Nazione> Nazioni = new List<Nazione>();
        List<Bambino> Bambino = new List<Bambino>();
        public Form1()
        {
            InitializeComponent();
            Modello = new modello();
            FusiOrariEsistenti = Modello.ListaFusiOrariEsistenti();
            
                if ((FusiOrariEsistenti[0]/60)%2==0)
                {
                    Nazioni = Modello.ListaNazioniFusoOrarioOrdinate(FusiOrariEsistenti[0], "DESC");
                }
                else
                {
                    Nazioni = Modello.ListaNazioniFusoOrarioOrdinate(FusiOrariEsistenti[0], "");
                }
                
                   DataTable table = Modello.BambiniNazioneConRegali(Nazioni[2].Codice);
                    ListaBambiniStato.DataSource = table;
                
            

            /*
             lista fusi orari
             lista nazioni del fuso orario
             lista bambini per nazione
             */

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }
    }
}
