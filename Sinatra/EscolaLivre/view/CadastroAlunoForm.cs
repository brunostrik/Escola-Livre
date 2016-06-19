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
    public partial class CadastroAlunoForm : Form, UsuarioFormInterface
    {

        private Usuario usuario;
        private Aluno aluno;

        public CadastroAlunoForm(Aluno a)
        {
            InitializeComponent();
            this.aluno = a;
            PrepararTela();
        }
        private void PrepararTela()
        {
            if (aluno == null)
            {
                aluno = new Aluno();
            }
            if (aluno.Id == 0) //NOVO
            {
                txtNome.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtCartao.Value = 0;
                txtFoto.Text = string.Empty;
                picFoto.Image = null;
                txtUsuario.Text = string.Empty;
            }else //EDICAO
            {
                txtNome.Text = aluno.Nome;
                txtEmail.Text = aluno.Email;
                txtCartao.Value = aluno.Cartao;
                picFoto.Image = new ImagesDAO().CarregarAlunoFoto(aluno.Id);
                this.usuario = new UsuarioDAO().Carregar(aluno.IdUsuario);
                txtUsuario.Text = usuario.Username;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Escolher foto
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagens | *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFoto.Text = ofd.FileName;
                picFoto.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void CadastroAlunoForm_Load(object sender, EventArgs e)
        {
            cmbAtivo.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //VALIDACAO
            string msgErro = string.Empty;
            if (txtNome.Text.Trim().Length < 4)
            {
                msgErro += "Preencha um nome válido\n";
            }
            if (txtEmail.Text.Trim().Length < 4)
            {
                msgErro += "Preencha um email válido\n";
            }            
            if (Convert.ToInt32(txtCartao.Value) < 1)
            {
                msgErro += "Preencha um número de RA (cartão) válido\n";
            }
            if (txtUsuario.Text.Trim().Length < 1)
            {
                msgErro += "Configure o usuário deste aluno\n";
            }
            if (Convert.ToInt32(txtCartao.Value) < 1)        
            {
                msgErro += "Preencha um número de RA (cartão) válido\n";
            }
            //VALIDACAO DE RA DUPLICADO
            if (new AlunoDAO().ExisteCartao(Convert.ToInt32(txtCartao.Value)))
            {
                msgErro += "Este número de RA (Cartão) já está associado a outro aluno, verifique se digitou corretamente ou não está cadastrando o aluno em duplicidade";
            }
            if (msgErro != string.Empty)
            {
                Util.Mensagem(msgErro);
                return;
            }
            //OK, validou, agora é só adicionar na entidade
            implementar aqui o resto;
            
        }

        private void btnConfigurarUsuario_Click(object sender, EventArgs e)
        {
            Object[] prms = { usuario, this, 0 };
            Util.AbreForm("CADASTROUSUARIOFORM", prms);
        }

        public void RetornaUsuario(Usuario usuario)
        {
            this.usuario = usuario;
            txtUsuario.Text = usuario.Username;
        }
    }
}
