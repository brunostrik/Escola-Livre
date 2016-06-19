using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EscolaLivre;

namespace Sinatra
{
    public partial class Reader : Form
    {

        private AlunoDAO alunoDao = new AlunoDAO();

        public Reader()
        {
            InitializeComponent();
        }

        private void lblRelogio_Click(object sender, EventArgs e)
        {

        }

        private void timerRelogio_Tick(object sender, EventArgs e)
        {
            lblRelogio.Text = string.Format("{0:HH:mm:ss}", DateTime.Now);
        }

        private void Reader_Load(object sender, EventArgs e)
        {
        }

        private void txtCartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return; //Valida para acionar apenas com enter

            //Obtem o numero inserido pelo leitor
            int card = Convert.ToInt32(txtCartao.Text.Trim());

            //procura no banco de dados o nome do aluno
            Aluno a = alunoDao.CarregaAluno(card);

            //mostra o nome dele na tela
            lblNome.Text = a.Nome.ToUpper();

            //procura no banco de dados o projeto planejado pelo horario e dia

            //mostra o projeto na tela

            //monta a entidade

            //salva

            //alertas sonoros ou na tela

            //registro no log

            //aguarda 2 segundos

            //limpa a tela

            
        }

        private void txtCartao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
