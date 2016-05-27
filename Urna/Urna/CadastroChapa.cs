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

namespace Urna
{
    public partial class CadastroChapa : Form
    {
        public CadastroChapa()
        {
            InitializeComponent();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Validação dos Dados
            string msg = "";
            if (txtNome.Text.Trim().Length < 3)
            {
                msg += "Preencha o nome da chapa\n";
            }
            if (txtPresidente.Text.Trim().Length < 3)
            {
                msg += "Prencha o nome do candidato a presidente\n";
            }
            if (txtVicePresidente.Text.Trim().Length < 3)
            {
                msg += "Prencha o nome do candidato a vice presidente\n";
            }
            if (txtRelator.Text.Trim().Length < 3)
            {
                msg += "Prencha o nome do candidato a relator\n";
            }
            if (txtViceRelator.Text.Trim().Length < 3)
            {
                msg += "Prencha o nome do candidato a vice relator\n";
            }
            if (txtFotoPresidente.Text.Trim().Length < 3)
            {
                msg += "Adicione a foto do candidato a presidente\n";
            }
            if (txtFotoVicePresidente.Text.Trim().Length < 3)
            {
                msg += "Adicione a foto do candidato a vice presidente\n";
            }
            if (txtFotoRelator.Text.Trim().Length < 3)
            {
                msg += "Adicione a foto do candidato a relator\n";
            }
            if (txtFotoViceRelator.Text.Trim().Length < 3)
            {
                msg += "Adicione a foto do candidato a vice relator\n";
            }
            if (msg != "")
            {
                Program.Alerta(msg);
                return;
            }

            //Se chegou a este ponto validou tudo certo
            //Constroi a entidade
            Chapa c = new Chapa();
            c.Numero = Convert.ToInt32(txtNumero.Value);
            c.Nome = txtNome.Text.Trim();
            c.Presidente = txtPresidente.Text.Trim();
            c.VicePresidente = txtVicePresidente.Text.Trim();
            c.Relator = txtRelator.Text.Trim();
            c.ViceRelator = txtViceRelator.Text.Trim();

            //Prepara o buffer para caregar array de bytes
            FileStream fs;
            BinaryReader br;
            string FileName;
            //Foto do PRESIDENTE
            FileName = txtFotoPresidente.Text;
            fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(fs);
            c.FotoPresidente = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            //Foto do VICE-PRESIDENTE
            FileName = txtFotoVicePresidente.Text;
            fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(fs);
            c.FotoVicePresidente = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            //Foto do RELATOR
            FileName = txtFotoRelator.Text;
            fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(fs);
            c.FotoRelator = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            //Foto do VICE RELATOR
            FileName = txtFotoViceRelator.Text;
            fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(fs);
            c.FotoViceRelator = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();

            if (!Program.Pergunta("Os dados estão corretos?")) return;
            //Zera os votos da chapa recém-criada
            c.Votos = 0;
            int res = new ChapaDAO().Cadastrar(c);

            if (res == 0)
            {
                Program.Erro("Falha ao salvar");
            }else
            {
                Program.Mensagem("Dados salvos com sucesso.\nPara votar nesta chapa use o número " + c.Numero);
                this.Close();
            }
        }

        private void btnFotoPresidente_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Imagens | *.jpg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtFotoPresidente.Text = ofd.FileName;
                    picPresidente.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                Program.Erro(ex.Message);
            }
        }

        private void btnFotoVicePresidente_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Imagens | *.jpg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtFotoVicePresidente.Text = ofd.FileName;
                    picVicePresidente.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                Program.Erro(ex.Message);
            }
        }

        private void btnFotoRelator_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Imagens | *.jpg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtFotoRelator.Text = ofd.FileName;
                    picRelator.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                Program.Erro(ex.Message);
            }
        }

        private void btnFotoViceRelator_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Imagens | *.jpg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtFotoViceRelator.Text = ofd.FileName;
                    picViceRelator.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                Program.Erro(ex.Message);
            }
        }
    }
}
