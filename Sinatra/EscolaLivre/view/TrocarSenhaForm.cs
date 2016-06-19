using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscolaLivre.view
{
    public partial class TrocarSenhaForm : Form
    {
        public TrocarSenhaForm()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtSenha1.Focus();
        }

        private void txtSenhaAtual_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSenha1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtSenha2.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //VALIDACOES
            if (txtSenha1.Text != txtSenha2.Text)
            {
                Util.Alerta("As senhas não conferem.");
                txtSenha1.Focus();
                return;
            }
            if (txtSenhaAtual.Text != Util.usuarioLogado.Senha)
            {
                Util.Alerta("A senha atual está incorreta.");
                txtSenhaAtual.Focus();
                return;
            }
            if (txtSenha1.Text.Length < 6)
            {
                Util.Alerta("A senha é muito curta, por favor use 6 ou mais caracteres.");
                txtSenha1.Focus();
                return;
            }
            Usuario usuarioAtualizado = Util.usuarioLogado;
            usuarioAtualizado.Senha = txtSenha1.Text;
            new UsuarioDAO().AtualizarSenha(Util.usuarioLogado);
            Util.usuarioLogado = usuarioAtualizado;
            Util.Mensagem("Sua senha foi atualizada com sucesso.");
            this.Close();
        }

        private void txtSenha2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1_Click(null, null);
        }
    }
}
