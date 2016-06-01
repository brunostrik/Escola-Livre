using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Urna
{
    public partial class Apuracao : Form
    {
        public Apuracao()
        {
            InitializeComponent();
        }

        private bool LoginDuplo()
        {
            Senha s = new SenhaDAO().ObterSenhaAtual();
            if (txtSenha1.Text != s.Senha1 || txtSenha2.Text != s.Senha2)
            {
                Program.Erro("Senhas não conferem");
                txtSenha1.Text = string.Empty;
                txtSenha2.Text = string.Empty;
                txtSenha1.Focus();
                return false;
            }
            else
            {
                txtSenha1.Text = string.Empty;
                txtSenha2.Text = string.Empty;
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!LoginDuplo()) return;
            //Senha correta, carregar os resultados
            dataGridView.DataSource = new ChapaDAO().Resultado();
            dataGridView.Refresh();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!LoginDuplo()) return;
            txtSenha1.Text = string.Empty;
            new ChapaDAO().VotarArquivo("N");
            Program.Mensagem("Arquivo criado, conferir por gentileza.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!LoginDuplo()) return;
            txtSenha1.Text = string.Empty;
            if (!Program.Pergunta("Tem certeza? Todos os votos serão perdidos")) return;
            ChapaDAO cd = new ChapaDAO();
            cd.DeletarArquivo();
            cd.ZerarBd();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!LoginDuplo()) return; //Valida com a senha anterior
            new GeraSenha().ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!LoginDuplo()) return; //Valida com a senha anterior
            new GeraSenhaMesario().ShowDialog();
        }
    }
}
