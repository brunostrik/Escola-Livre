using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EscolaLivre
{
    public partial class CadastroAluno : Form
    {
        public CadastroAluno()
        {
            InitializeComponent();
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Imagens | *.jpg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtFoto.Text = ofd.FileName;
                    picFoto.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            //Validar preenchimento
            String msgErro = "";
            if (txtNome.Text.Trim().Length < 4)
            {
                msgErro += "Preencha o nome\n";
            }
            if (nstCartao.Value == 0)
            {
                msgErro += "Preencha o número do cartão\n";
            }
            if (txtFoto.Text.Trim().Length < 1)
            {
                msgErro += "Selecione a foto\n";
            }
            if (msgErro.Trim() != "")
            {
                MessageBox.Show(msgErro,"Atenção",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            //Confirmação
            if (DialogResult.Yes != MessageBox.Show("Os dados estão corretos?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                return; //O user abortou o salvamento
            }
            //pode salvar, chama a funcao
            Aluno aluno = new Aluno();
            aluno.Nome = txtNome.Text.Trim();
            aluno.Cartao = Convert.ToInt32(nstCartao.Value);
            
            //Gerar a imagem em array de bytes
            string FileName = txtFoto.Text;
            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            aluno.Foto = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            try
            {
                new AlunoDAO().Salvar(aluno);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            this.Close();
            this.Dispose();
            
        }
    }
}
