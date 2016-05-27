using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urna
{
    public partial class TelaVotacao : Form
    {
        public TelaVotacao()
        {
            InitializeComponent();
        }

        string rxString;
        public Chapa chapaVotada;

        private void TelaVotacao_Load(object sender, EventArgs e)
        {
            //Ativa a interface serial
            if (!serialPort.IsOpen)
            {
                try
                {
                    serialPort.PortName = Program.SerialArduino;
                    serialPort.Open();
                    Program.telaMesario.Logger("Serial OK");
                }
                catch
                {
                    Program.telaMesario.Logger("FALHA NA PORTA SERIAL - VERIFIQUE TECLADO");
                    this.Close();
                    return;
                }
            }
            MontarTela(null);
            //Mostra para o mesario que esta tudo pronto
            Program.telaMesario.Logger("Urna pronta para votação");
        }

        private void TelaVotacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            rxString = serialPort.ReadExisting();
            Invoke(new EventHandler(TratarDados));
        }
        private void TratarDados(object sender, EventArgs e)
        {
            //BIPE SIMPLES
            Program.telaMesario.Logger("Tecla apertada");
            switch (rxString.Trim())
            {
                case "A": //CONFIRMA
                    Confirma();
                    break;
                case "B": //CORRIGE
                    Corrige();
                    break;                   
                case "C": //BRANCO
                    Branco();
                    break;
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    Numero(rxString.Trim());
                    break;           
            }
        }
        private void Confirma()
        {
            if (lblPresidente.Text.Trim().Length == 0) return;
            int ret = new ChapaDAO().Votar(txtNumero.Text);
            if (ret < 1)
            {
                Program.telaMesario.Logger("FALHA AO REGISTRAR VOTO");
                Corrige();
                return;
            }
            Program.telaMesario.Logger("Voto computado com suceso");
            //MOSTRA MENSAGEM FIM NA TELA
            //BIPE LONGO
            Corrige();

            boxRodape.Visible = false;
            picPresidente.Visible = false;
            picVicePresidente.Visible = false;
            picRelator.Visible = false;
            picViceRelator.Visible = false;
            lblSeuVotoPara.Visible = false;
            lblRepublica.Visible = false;
            lblIfpr.Visible = false;
            lblNumero.Visible = false;
            txtNumero.Visible = false;
            lblC.Visible = false;
            lblChapa.Visible = false;
            lblP.Visible = false;
            lblPresidente.Visible = false;
            lblVP.Visible = false;
            lblVicePresidente.Visible = false;
            lblR.Visible = false;
            lblRelator.Visible = false;
            lblVR.Visible = false;
            lblViceRelator.Visible = false;




            lblFim.Visible = true;
        }
        private void Corrige()
        {
            MontarTela(null);
        }
        private void Branco()
        {
            if (lblPresidente.Text.Trim().Length != 0) return;
            Chapa ch = new Chapa();
            ch.Nome = "BRANCO";
            ch.Presidente = "BRANCO";
            ch.VicePresidente = "BRANCO";
            ch.Relator = "BRANCO";
            ch.ViceRelator = "BRANCO";
            ch.Numero = "B";
            txtNumero.Text = "B";
            MontarTela(ch);
        }
        private void Numero(string num)
        {
            if (lblPresidente.Text.Trim().Length != 0) return;
            txtNumero.Text = num;
            Chapa ch = new ChapaDAO().CarregarChapa(num);
            if (ch == null)
            {
                //VOTOU NULO
                ch = new Chapa();
                ch.Nome = "NULO";
                ch.Presidente = "NULO";
                ch.VicePresidente = "NULO";
                ch.Relator = "NULO";
                ch.ViceRelator = "NULO";
                ch.Numero = "N";
            }
            MontarTela(ch);
        }
        private void MontarTela(Chapa c)
        {
            chapaVotada = c;
            if (c != null)
            {
                lblChapa.Text = c.Nome;
                lblPresidente.Text = c.Presidente;
                lblVicePresidente.Text = c.VicePresidente;
                lblRelator.Text = c.Relator;
                lblViceRelator.Text = c.ViceRelator;
                if (c.Nome == "NULO")
                {
                    txtNumero.Text = "N";
                }
                if (c.Nome == "BRANCO")
                {
                    txtNumero.Text = "B";
                }
            }
            else
            {
                lblChapa.Text = "";
                lblPresidente.Text = "";
                lblVicePresidente.Text = "";
                lblRelator.Text = "";
                lblViceRelator.Text = "";
                picPresidente.Image = null;
                picVicePresidente.Image = null;
                picRelator.Image = null;
                picViceRelator.Image = null;
                txtNumero.Text = string.Empty;
            }

        }
    }
}
