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
        public Form1()
        {
            InitializeComponent();
            Modello = new modello();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Bambino> listaBambini = Modello.BambiniNazione("AU");
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
