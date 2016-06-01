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
    public partial class GeraSenhaMesario : Form
    {
        public GeraSenhaMesario()
        {
            InitializeComponent();
        }

        private void GeraSenhaMesario_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSenha1.Text != txtSenha2.Text)
            {
                Program.Alerta("As senhas digitadas não conferem");
                txtSenha1.Focus();
                return;
            }
            if (txtSenha1.Text.Length < 4)
            {
                Program.Alerta("A senha é muito curta, por favor escolha uma senha mais segura");
                txtSenha1.Focus();
                return;
            }
            if (new SenhaDAO().AtualizarSenhaMesario(txtSenha1.Text) < 1)
            {
                Program.Erro("Falha ao salvar a nova senha");
                return;
            }
            else
            {
                Program.Mensagem("Senha do mesário configurada");
                this.Close();
            }
        }
    }
}
