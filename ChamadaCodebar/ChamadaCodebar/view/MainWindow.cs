using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChamadaCodebar
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Program.AbreForm("LOGIN");
        }
        public void AjustarMenu()
        {
            //Analisa se o usuário é tipo aluno
            if (Program.alunoLogado != null)
            {
                if (Program.alunoLogado.Nome == "TERMINAL") //Analisa se é o aluno terminal, e mostra apenas os menus de terminal
                {

                }
            }
            else //Analisa se é o tipo professor
            {
                if (Program.professorLogado.Nome == "MASTER") //Analisa se é o master, e mostra os menus de administração
                {

                }
            }                   
        }

        private void meusProjetosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrosToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
    }
}
