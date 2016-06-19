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
    public partial class CadastroProfessorForm : Form, UsuarioFormInterface
    {
        private Professor professor;
        private Usuario usuario;

        public CadastroProfessorForm(Professor p)
        {
            InitializeComponent();
            this.professor = p;
            PrepararTela();
        }
        private void PrepararTela()
        {
            if (this.professor == null)
            {
                this.professor = new Professor();
            }
            if (this.professor.Id == 0) //INSERCAO DE NOVO
            {
                txtEmail.Text = string.Empty;
                txtNome.Text = string.Empty;
                txtUsuario.Text = string.Empty;
                btnConfigurarUsuario.Enabled = true;
                cmbAtivo.SelectedIndex = 0;
                this.usuario = new Usuario();
            }
            else //EDICAO
            {
                this.usuario = new UsuarioDAO().Carregar(professor.IdUsuario);
                txtEmail.Text = professor.Email;
                txtNome.Text = professor.Nome;
                txtUsuario.Text = usuario.Username;
                btnConfigurarUsuario.Enabled = false;
                cmbAtivo.SelectedIndex = 0;
            }
        }
        public void RetornaUsuario(Usuario usuario)
        {
            this.usuario = usuario;
            txtUsuario.Text = usuario.Username;
        }

        private void CadastroProfessorForm_Load(object sender, EventArgs e)
        {
            cmbAtivo.SelectedIndex = 0;
        }

        private void btnConfigurarUsuario_Click(object sender, EventArgs e)
        {
            Object[] prms = {usuario, this, 0 };
            Util.AbreForm("CADASTROUSUARIOFORM", prms);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //VALIDACOES
            string msgErro = string.Empty;
            if (txtNome.Text.Trim().Length < 1)
            {
                msgErro += "Preencha o nome corretamente\n";
            }
            if (txtEmail.Text.Trim().Length < 1)
            {
                msgErro += "Preencha o email corretamente\n";
            }
            if (txtUsuario.Text.Trim().Length < 1)
            {
                msgErro += "Crie um usuário do sistema para este professor\n";
            }
            if (msgErro.Length > 0)
            {
                Util.Alerta(msgErro);
                return;
            }
            //VALIDOU OK, SALVAR
            professor.Nome = txtNome.Text;
            professor.Email = txtEmail.Text;
            professor.Ativo = cmbAtivo.Text == "Ativo";
            //Salvar ou atualizar o usuario
            professor.IdUsuario = new UsuarioDAO().Persistir(usuario); //Persistir é saveOrUpdate
            if (professor.IdUsuario == 0)
            {
                Util.Erro("Falha ao salvar o usuário do professor");
                return;
            }
            if (new ProfessorDAO().Persistir(professor) > 0) //Persistir é saveOrUpdate
            {
                Util.Mensagem("Professor " + professor.Nome + " adicionado ao sistema");
                this.Close();
            }else
            {
                Util.Erro("Falha ao salvar o professor");
                //Apagar o usuario restante, caso seja inserção de novo
                if (professor.Id == 0)
                {
                    try { new UsuarioDAO().Apagar(professor.IdUsuario); } catch (Exception) { }
                }
                return;
            }
        }

        private void cmbAtivo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
