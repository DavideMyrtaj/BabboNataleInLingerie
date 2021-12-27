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
    }
}
