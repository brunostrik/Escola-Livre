using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urna
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }

        public static string SerialArduino = "";
        public static string Senha = "democracia";
        public static string SenhaSupervisor = "jabuticaba";
        public static TelaMesario telaMesario;
        public static TelaVotacao telaVotacao;

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
