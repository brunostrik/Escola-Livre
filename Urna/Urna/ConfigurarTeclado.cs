using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Urna
{
    public partial class ConfigurarTeclado : Form
    {

        string rxString;

        public ConfigurarTeclado()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AtualizarPortas();            
        }
        private void AtualizarPortas()
        {
            cmbPortas.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
            {
                cmbPortas.Items.Add(s);
            }
            if (cmbPortas.Items.Count > 0)
            {
                cmbPortas.SelectedIndex = 0;
            }
        }

        private void ConfigurarTeclado_Load(object sender, EventArgs e)
        {
            AtualizarPortas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                try
                {
                    serialPort.PortName = cmbPortas.SelectedItem.ToString();
                    serialPort.Open();

                }
                catch
                {
                    return;
                }
                if (serialPort.IsOpen)
                {
                    button1.Text = "Desconectar";
                    cmbPortas.Enabled = false;

                }
            }
            else
            {

                try
                {
                    serialPort.Close();
                    cmbPortas.Enabled = true;
                    button1.Text = "Conectar";
                }
                catch
                {
                    return;
                }

            }
        }

        private void ConfigurarTeclado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            rxString = serialPort.ReadExisting();
            Invoke(new EventHandler(TratarDados));
        }

        private void TratarDados(object sender, EventArgs e)
        {
            txtRetorno.AppendText(rxString + "\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.SerialArduino = cmbPortas.SelectedItem.ToString();
            Program.Mensagem("Teclado configurado na porta " + Program.SerialArduino);
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            this.Close();
        }
    }
}
