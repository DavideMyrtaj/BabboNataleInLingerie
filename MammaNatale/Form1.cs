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
        public List<int> FusiOrariEsistenti = new List<int>();
        List<Nazione> Nazioni = new List<Nazione>();
        
      
        int _fusoOrarioIndex = -1;
        int _statoAttualeFusoOrarioIndex = 0;
        /// <summary>
        /// attributo che, ogni volta che viene modificato "il fuso orario sul quale si è", aggiorna la lista delle nazioni presenti
        /// </summary>
        int fusoOrarioIndex
        {
            get { return _fusoOrarioIndex; }
            set
            {
                StatiDelFusoOrario.DataSource = null;

                if (value == FusiOrariEsistenti.Count)
                {
                    timer1.Stop();
                    MessageBox.Show( "Hai consegnato i regali a tutti i bambini del mondo\nOra il programma verrà chiuso", "COMPLIMENTI!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    _fusoOrarioIndex = value;
                    pictureBox1.Image = new Bitmap($"FusIOrari\\{FusiOrariEsistenti[_fusoOrarioIndex]}.JPG");
                    StatiDelFusoOrario.DataSource = Modello.ListaNazioniFusoOrarioOrdinate(FusiOrariEsistenti[_fusoOrarioIndex],ref Nazioni);
                }
            }
        }
        /// <summary>
        /// attributo che, ogni volta che "si passa alla nazione successiva" della lista ordinata, mostra i dettagli dello stato e la lista dei bambini del relativo
        /// </summary>
        int statoAttualeFusoOrarioIndex
        {
            get { return _statoAttualeFusoOrarioIndex; }
            set
            {
                
                if (_fusoOrarioIndex == -1)//stato iniziale del programma che fa avviare il timer modificando l'indice da -1 a 0
                {
                    fusoOrarioIndex++;
                    ListaBambiniStato.DataSource = Modello.BambiniNazioneConRegali(Nazioni[_statoAttualeFusoOrarioIndex].Codice);
                    DnomeStato.Text = $"STATO:\t{Nazioni[_statoAttualeFusoOrarioIndex].Nome}";
                    DCodice.Text = $"CODICE:\t{Nazioni[_statoAttualeFusoOrarioIndex].Codice}";
                    DLatitudine.Text = $"LATITUDINE:\t{Nazioni[_statoAttualeFusoOrarioIndex].Latitudine}";
                    UTC.Text = $"FUSO ORARIO:\tUTC {FusiOrariEsistenti[fusoOrarioIndex]/60}";
                    timer1.Enabled = true;
                    return;

                }
                ListaBambiniStato.DataSource = null;
                

                if (value == Nazioni.Count)
                {
                    if (oraLocale.Hour < 1)
                    {
                        MessageBox.Show( "Per poter passare al fuso orario sucessivo è necessario aspettare che siano almeno le 01:00 locali\n(In questo caso il tempo trascorrerà automaticamente per poter proseguire)","ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        oraLocale = new DateTime(2022, 1, 1, 1, 0, 0);

                    }
                    oraLocale = oraLocale.AddHours(-1);
                    oraAttuale.Text = oraLocale.ToString("HH:mm");
                    _statoAttualeFusoOrarioIndex = 0;
                    fusoOrarioIndex++;
                }
                else
                {
                    _statoAttualeFusoOrarioIndex = value;

                }
                //informazioni del singolo stato
                DnomeStato.Text = $"STATO:\t{Nazioni[_statoAttualeFusoOrarioIndex].Nome}";
                DCodice.Text = $"CODICE:\t{Nazioni[_statoAttualeFusoOrarioIndex].Codice}";
                DLatitudine.Text = $"LATITUDINE:\t{Nazioni[_statoAttualeFusoOrarioIndex].Latitudine}";
                UTC.Text = $"FUSO ORARIO:\tUTC {FusiOrariEsistenti[fusoOrarioIndex]/60} ";
                //datagrid di tutti i bambini
                ListaBambiniStato.DataSource = Modello.BambiniNazioneConRegali(Nazioni[_statoAttualeFusoOrarioIndex].Codice);
                 
            }
        }
        DateTime oraLocale = new DateTime(2022, 1, 1, 0, 0, 0);
        public Form1()
        {
            InitializeComponent();
            Modello = new modello();
            //inizio in pausa ma dati pronti
            FusiOrariEsistenti = Modello.ListaFusiOrariEsistenti();//viene caricata la lista dei fusi orari esistenti
            MessageBox.Show("Per avviare il programma e passare allo stato successivo basta premere il pulsante centrale", "BENVENUTO",MessageBoxButtons.OK,MessageBoxIcon.Information);

             

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            oraLocale = oraLocale.AddMinutes(1);
            oraAttuale.Text = oraLocale.ToString("HH:mm");
            if (oraLocale.Hour == 6)//se si arriva alle 6 del mattino
            {
                timer1.Stop();
                button1.Enabled = false;
                MessageBox.Show( "I regali non sono stati consegnati in tempo.\nIl Natale è stato rovinato :'(.\nIl programma può essere chiuso", "ERRORE IRREVERSIBILE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            statoAttualeFusoOrarioIndex++;
            
        }
    }
}
