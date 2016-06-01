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
    public partial class GeraSenha : Form
    {
        public GeraSenha()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msgErro = "";
            if (txtSenha1_1.Text != txtSenha1_2.Text)
            {
                msgErro += "As senhas do professor responsável não conferem \r\n";
            }
            if (txtSenha2_1.Text != txtSenha2_2.Text)
            {
                msgErro += "As senhas do presidente da comissão não conferem \r\n";
            }
            if (txtSenha1_1.Text.Length < 4 || txtSenha2_1.Text.Length < 4)
            {
                msgErro += "As senhas são muito curtas, por favor use uma senha mais segura";
            }
            if (msgErro != "")
            {
                Program.Erro(msgErro);
                return;
            }
            Senha s = new Senha();
            s.Senha1 = txtSenha1_1.Text;
            s.Senha2 = txtSenha2_1.Text;
            if (new SenhaDAO().AtualizarSenha(s) > 0)
            {
                Program.Mensagem("Senhas configuradas");
                this.Close();
            }
            else
            {
                Program.Erro("Erro ao atualizar a senha, contate o administrador do sistema");
            }
        }
    }
}
