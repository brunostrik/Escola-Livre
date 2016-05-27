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
    public partial class TelaVotacao : Form
    {
        public TelaVotacao()
        {
            InitializeComponent();
        }

        private void TelaVotacao_Load(object sender, EventArgs e)
        {
            Program.telaMesario.Logger("Urna pronta para votação");
        }
    }
}
