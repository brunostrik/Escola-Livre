using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urna
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.telaMesario = new TelaMesario();
            Program.telaMesario.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new CadastroChapa().ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new ConfigurarTeclado().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Apuracao().ShowDialog();
        }
    }
}
