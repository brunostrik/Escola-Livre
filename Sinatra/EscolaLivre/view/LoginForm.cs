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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = 0;

            //acelerar processo de login, modo desenvolvimento
            if (Util.MODO_DEVELOPER)
            {
                txtUsuario.Text = "MASTER";
                txtSenha.Text = "mst.asd";
                button1_Click(null, null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                  
            if (txtUsuario.Text.Length == 0 || txtSenha.Text.Length == 0)
            {
                txtUsuario.Focus();
                return;
            }
            button1.Enabled = false;
            Usuario usuario = null;
            UsuarioDAO dao = new UsuarioDAO();
            if (txtUsuario.Text.ToUpper() == "MASTER") //CASO DE USUARIO MASTER
            {
                if (new ConfiguracaoDAO().Obter("MASTER").Valor != txtSenha.Text)
                {
                    Util.Alerta("Senha de acesso master não confere.");
                    button1.Enabled = true;
                    return;
                }
                usuario = new Usuario();
                usuario.Id = 0;
                usuario.Username = "MASTER";
                usuario.Senha = txtSenha.Text;
                usuario.Tipo = -1;
                Util.Alerta("ACESSO MASTER ATIVADO");
            }
            else
            {           
                usuario = dao.Logar(txtUsuario.Text, txtSenha.Text, cmbTipo.SelectedIndex);
                if (usuario == null)
                {
                    Util.Erro("Acesso negado.");
                    button1.Enabled = true;
                    return;
                }               
            }
            dao.RegistraMomentoLogin(usuario.Id);
            Util.usuarioLogado = usuario;
            Util.LoginOk();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSenha.Focus();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }
        }
    }
}
