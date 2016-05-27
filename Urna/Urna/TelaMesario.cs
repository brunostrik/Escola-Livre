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
    public partial class TelaMesario : Form
    {
        public TelaMesario()
        {
            InitializeComponent();
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            if (btnAtivar.Text == "Ativar")
            {
                if (txtSenha.Text != Program.Senha)
                {
                    Program.Erro("Senha incorreta");
                    return;
                }
                //Se chegou aqui validou ok
                txtSenha.Text = string.Empty;
                //Liberar os botões
                btnFinalizar.Enabled = true;
                btnForcar.Enabled = true;
                btnLiberar.Enabled = true;
                btnAtivar.Text = "Cancelar";
            }
            else
            {
                RetornaBtn();
            }
        }
        private void RetornaBtn()
        {
            //retorna os botoes
            btnFinalizar.Enabled = false;
            btnForcar.Enabled = false;
            btnLiberar.Enabled = false;
            btnAtivar.Text = "Ativar";
        }
        public void Logger(String texto)
        {
            txtLog.Text += DateTime.Now + " - " + texto+"\n";
        }
        private void btnLiberar_Click(object sender, EventArgs e)
        {
            Logger("Liberando urna");
            Program.telaVotacao = new TelaVotacao();
            Rectangle bounds = Screen.AllScreens[1].Bounds;
            Program.telaVotacao.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
            Program.telaVotacao.StartPosition = FormStartPosition.Manual;
            Program.telaVotacao.Show();
        }

        private void btnForcar_Click(object sender, EventArgs e)
        {
            Logger("Voto encerrado pelo mesário");
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Logger("Eleição Finalizada");
            Program.telaVotacao.Close();
            RetornaBtn();
            btnAtivar.Enabled = false;
            txtSenha.Enabled = false;
        }
    }
}
