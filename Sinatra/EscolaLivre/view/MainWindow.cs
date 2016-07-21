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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            menuStrip.Enabled = false;
            //testa o banco de dados
            if (!ConnectionManager.TestConnection())
            {
                Util.Mensagem("Falha ao conectar ao banco de dados. Verifique se sua conexão está correta na rede do IFPR. Se o problema persistir contate o CPGTIC.");
                Application.Exit();
            }
            //Chama o login
            Util.AbreLogin();
        }
        public void LoginOk()
        {
            menuStrip.Enabled = true;
            ConfiguraMenu();
        }
        private void ConfiguraMenu()
        {
            if (Util.usuarioLogado.Tipo == -1) //MASTER
            {
                cadastrosToolStripMenuItem.Visible = true;
                projetosToolStripMenuItem.Visible = true;
                professoresToolStripMenuItem.Visible = false;
                configuraçõesToolStripMenuItem.Visible = true;
                alunosToolStripMenuItem.Visible = false;
                opçõesToolStripMenuItem.Visible = false;
            }
            else  if (Util.usuarioLogado.Tipo == 0) //PROFESSOR
            {
                cadastrosToolStripMenuItem.Visible = false;
                projetosToolStripMenuItem.Visible = false;
                configuraçõesToolStripMenuItem.Visible = false;
                alunosToolStripMenuItem.Visible = false;

                professoresToolStripMenuItem.Visible = true;
                opçõesToolStripMenuItem.Visible = true;

            }
            else //ALUNO
            {
                cadastrosToolStripMenuItem.Visible = false;
                projetosToolStripMenuItem.Visible = false;
                professoresToolStripMenuItem.Visible = false;
                configuraçõesToolStripMenuItem.Visible = false;

                alunosToolStripMenuItem.Visible = true;

                opçõesToolStripMenuItem.Visible = true;
            }
        }

        private void trocarSenhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.AbreForm("TROCARSENHAFORM");
        }

        private void professoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void meuCadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void alunosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void adicionarUmNovoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Object[] prms = { new Professor() };
            Util.AbreForm("CADASTROPROFESSORFORM", prms);
        }

        private void adicionarUmNovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Object[] prms = { new Aluno() };
            Util.AbreForm("CADASTROALUNOFORM", prms);
        }

        private void projetosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void adicionarUmNovoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            object[] prms = { new Epoca() };
            Util.AbreForm("CADASTROEPOCAFORM", prms);
        }
    }
}
