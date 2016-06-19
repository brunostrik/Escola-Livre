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
    public partial class CadastroUsuarioForm : Form
    {
        public UsuarioFormInterface retornar = null;
        public Usuario usuario;

        public CadastroUsuarioForm(Usuario u, UsuarioFormInterface classeRetorno, int tipo)
        {
            this.usuario = u;
            InitializeComponent();
            this.retornar = classeRetorno;
            if (tipo >= 0)
            {
                cmbTipo.SelectedIndex = tipo;
                cmbTipo.Enabled = false;
            }
            if (usuario.Username != string.Empty)
            {
                txtUsuario.Text = usuario.Username;
                txtSenha1.Text = usuario.Senha;
                txtSenha2.Text = usuario.Senha;
            }
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
            if (txtSenha1.Text.Length < 6)
            {
                Util.Alerta("A senha é muito curta, por favor use 6 ou mais caracteres.");
                txtSenha1.Focus();
                return;
            }
            if (txtUsuario.Text.Length < 6)
            {
                Util.Alerta("O usuário de acesso é muito curto, por favor use 6 ou mais caracteres.");
                txtUsuario.Focus();
                return;
            }
            //VALIDAR DUPLICIDADE DE USERNAME
            if (new UsuarioDAO().Existe(txtUsuario.Text))
            {
                Util.Alerta("O nome de usuário escolhido já existe, por favor escolha um diferente.");
                txtUsuario.Focus();
                return;
            }
            if (usuario == null)
            {
                usuario = new Usuario();
            }
            usuario.Username = txtUsuario.Text;
            usuario.Tipo = cmbTipo.SelectedIndex;
            usuario.Senha = txtSenha1.Text;
            if (retornar != null) //É UMA CRIAÇÃO ACOPLADA, DEVE RETORNAR PARA FORM DE RETORNO
            {
                retornar.RetornaUsuario(usuario);
                this.Close();
            }
            else //É UMA CRIAÇÃO SIMPLES, SALVA DIRETO
            {
                new UsuarioDAO().Salvar(usuario);
            }
            this.Close();
        }

        private void CadastroUsuarioForm_Load(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = 0;
        }
    }
}
