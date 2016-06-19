using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EscolaLivre.view;

namespace EscolaLivre
{
    public static class Util
    {
        //CONFIGURACOES
        public static bool MODO_DEVELOPER = true;

        //ENTIDADES
        public static Usuario usuarioLogado;
        public static bool isMaster = false;

        //TELAS
        public static MainWindow mainWindow;
        public static LoginForm loginForm;
        public static TrocarSenhaForm trocarSenhaForm;
        public static CadastroUsuarioForm cadastroUsuarioForm;
        public static CadastroProfessorForm cadastroProfessorForm;
        public static CadastroAlunoForm cadastroAlunoForm;

        public static void AbreForm(string nome, object[] parametros = null)
        {
            switch (nome.ToUpper())
            {
                case "TROCARSENHAFORM":
                    trocarSenhaForm = new TrocarSenhaForm();
                    trocarSenhaForm.ShowDialog();
                    break;
                case "CADASTROUSUARIOFORM": //USUARIO, INTERFACE DE RETORNO, TIPO
                    cadastroUsuarioForm = new CadastroUsuarioForm((Usuario) parametros[0], (UsuarioFormInterface)parametros[1], (int)parametros[2]);
                    cadastroUsuarioForm.ShowDialog();
                    break;
                case "CADASTROPROFESSORFORM":
                    cadastroProfessorForm = new CadastroProfessorForm((Professor)parametros[0]);
                    cadastroProfessorForm.ShowDialog();
                    break;
                case "CADASTROALUNOFORM":
                    cadastroAlunoForm = new CadastroAlunoForm((Aluno)parametros[0]);
                    cadastroAlunoForm.ShowDialog();
                    break;
            }
        }

        public static void AbreLogin()
        {
            loginForm = new LoginForm();
            loginForm.ShowDialog();
        }
        public static void LoginOk()
        {
            loginForm.Close();
            loginForm.Dispose();
            mainWindow.LoginOk();
        }

        //INTERACOES COMUNS UNIFICADAS
        public static void Alerta(string mensagem)
        {
            MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void Mensagem(string mensagem)
        {
            MessageBox.Show(mensagem, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        public static void Erro(string mensagem)
        {
            MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static bool Pergunta(string mensagem)
        {
            return MessageBox.Show(mensagem, "Pergunta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
