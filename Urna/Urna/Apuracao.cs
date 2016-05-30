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

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSenha.Text != Program.SenhaSupervisor)
            {
                Program.Erro("Senha incorreta");
                txtSenha.Text = string.Empty;
                txtSenha.Focus();
                return;
            }
            txtSenha.Text = string.Empty;
            //Senha correta, carregar os resultados
            dataGridView.DataSource = new ChapaDAO().Resultado();
            dataGridView.Refresh();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtSenha.Text != Program.SenhaSupervisor)
            {
                Program.Erro("Senha incorreta");
                txtSenha.Text = string.Empty;
                txtSenha.Focus();
                return;
            }
            txtSenha.Text = string.Empty;
            new ChapaDAO().VotarArquivo("N");
            Program.Mensagem("Arquivo criado, conferir por gentileza.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtSenha.Text != Program.SenhaSupervisor)
            {
                Program.Erro("Senha incorreta");
                txtSenha.Text = string.Empty;
                txtSenha.Focus();
                return;
            }
            txtSenha.Text = string.Empty;
            if (!Program.Pergunta("Tem certeza? Todos os votos serão perdidos")) return;
            ChapaDAO cd = new ChapaDAO();
            cd.DeletarArquivo();
            cd.ZerarBd();
        }
    }
}
