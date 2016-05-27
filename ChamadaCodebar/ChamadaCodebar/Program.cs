using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChamadaCodebar.view;
using ChamadaCodebar.model;

namespace ChamadaCodebar
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static Usuario usuarioLogado { get; set; }
        public static Professor professorLogado { get; set; }
        public static Aluno alunoLogado { get; set; }

        public static MainWindow mainWindow;

        public static Login login;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainWindow = new MainWindow();        
            Application.Run(mainWindow);
        }
       
        //ABRIDOR DE JANELAS
        public static void AbreForm(string form)
        {
            switch (form.ToUpper().Trim())
            {
                case "LOGIN":
                    login = new Login();
                    login.ShowDialog();
                    break;
            }
        }

        //INTERACOES COMUNS UNIFICADAS
        public static void Alerta(string mensagem)
        {
            MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void Erro(string mensagem)
        {
            MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static bool Pergunta(string mensagem)
        {
            return MessageBox.Show(mensagem, "Pergunta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes ;
            
        }
        public static void Ativar()
        {
            //Ativa os menus adequadamente conforme o tipo de usuario logado. Função chamada logo após confirmar o login
            mainWindow.AjustarMenu();
        }
    }
}
