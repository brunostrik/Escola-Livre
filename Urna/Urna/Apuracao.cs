using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Urna
{
    public partial class Apuracao : Form
    {
        public Apuracao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSenha.Text != Program.Senha)
            {
                Program.Erro("Senha incorreta");
                return;
            }
            //Senha correta, carregar os resultados
            dataGridView.DataSource = new ChapaDAO().Resultado();
            dataGridView.Refresh();
        }
    }
}
