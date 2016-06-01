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
                if (txtSenha.Text != new SenhaDAO().ObterSenhaMesario())
                {
                    Program.Erro("Senha incorreta");
                    txtSenha.Focus();
                    return;
                }
                //Se chegou aqui validou ok
                txtSenha.Text = string.Empty;
                //Liberar os botões
                btnFinalizar.Enabled = true;
                btnForcar.Enabled = false;
                btnLiberar.Enabled = true;
                btnAtivar.Text = "Cancelar";
            }
            else
            {
                RetornaBtn();
                try { Program.telaVotacao.Close(); } catch { }
            }
        }
        private void RetornaBtn()
        {
            //retorna os botoes
            btnFinalizar.Enabled = false;
            btnForcar.Enabled = false;
            btnLiberar.Enabled = false;
            btnAtivar.Enabled = true;
            btnAtivar.Text = "Ativar";
        }
        public void Logger(String texto)
        {
            txtLog.Text += DateTime.Now + " - " + texto + "\r\n";
        }
        private void btnLiberar_Click(object sender, EventArgs e)
        {
            Logger("Liberando urna");
            Program.telaVotacao = new TelaVotacao();
            Rectangle bounds = Screen.AllScreens[1].Bounds;
            Program.telaVotacao.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
            Program.telaVotacao.StartPosition = FormStartPosition.Manual;
            btnLiberar.Enabled = false;
            btnFinalizar.Enabled = false;
            btnForcar.Enabled = true;
            btnAtivar.Enabled = false;
            Program.telaVotacao.Show();
        }

        private void btnForcar_Click(object sender, EventArgs e)
        {
            Program.telaVotacao.Close();
            Logger("Voto encerrado pelo mesário");
            RetornaBtn();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Logger("Eleição Finalizada");
            try { Program.telaVotacao.Close(); } catch { }
            RetornaBtn();
            btnAtivar.Enabled = false;
            txtSenha.Enabled = false;
            
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAtivar_Click(null, null);
            }
        }

        private void TelaMesario_Load(object sender, EventArgs e)
        {
            if (Program.SerialArduino.Length == 0)
            {
                Program.Erro("A porta serial ainda não foi configurada, verifique");
                this.Close();
            }
        }
    }
}
