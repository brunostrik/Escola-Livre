using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChamadaCodebar.model;
using ChamadaCodebar.control;

namespace ChamadaCodebar.view
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            Entrar();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter){
                Entrar();
            }
        }
        private void Entrar()
        {
            string msgErro = "";
            //valida preenchimento
            if (txtUsuario.Text.Trim().Length < 4)
            {
                msgErro += "Preencha com um usuário válido\n";
            }
            if (txtSenha.Text.Trim().Length < 4)
            {
                msgErro += "Preencha a senha\n";
            }
            if (msgErro != "")
            {
                Program.Erro(msgErro);
                return;
            }
            //se validou chama o metodo
            Usuario usuario = new UsuarioDAO().Logar(txtUsuario.Text.Trim(), txtSenha.Text.Trim(), cmbAcesso.SelectedIndex);
            //VALIDA O LOGIN
            if (usuario == null)
            {
                Program.Erro("Acesso negado");
                return;
            }
            //coloca o usuario na memoria
            Program.usuarioLogado = usuario;
            //registra no banco o momento do login
            new UsuarioDAO().RegistraMomentoLogin(usuario.Id);
            //carrega a entidade professor ou aluno e coloca na memoria
            if (cmbAcesso.SelectedIndex == 0)
            {
                Program.professorLogado = new ProfessorDAO().LoadByIdUsuario(usuario.Id);
            }else
            {
                Program.alunoLogado = new AlunoDAO().LoadByIdUsuario(usuario.Id);
            }
            //fecha essa coisa e vai pra tela principal, determinando o modo de funcionamento]
            Program.Ativar();        
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            cmbAcesso.SelectedIndex = 0;
        }
    }
}
