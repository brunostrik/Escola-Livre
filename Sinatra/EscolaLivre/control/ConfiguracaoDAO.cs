using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EscolaLivre
{
    public class ConfiguracaoDAO
    {
        public Configuracao Obter(string nome)
        {
            Configuracao config = null;
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "SELECT * FROM configuracao WHERE nome = @Nome";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar, 255);
            cmd.Parameters["@Nome"].Value = nome;
            con.Open();
            MySqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                config = new Configuracao();
                config.Nome = rs.GetString("nome");
                config.Valor = rs.GetString("valor");
            }
            con.Close();
            return config; 
        }
        public void Criar(Configuracao config)
        {
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "INSERT INTO configuracao (nome, valor) VALUES (@Nome, @Valor)";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar, 255);
            cmd.Parameters.Add("@Valor", MySqlDbType.VarChar, 255);
            cmd.Parameters["@Nome"].Value = config.Nome;
            cmd.Parameters["@Valor"].Value = config.Valor;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Atualizar(Configuracao config)
        {
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "UPDATE configuracao SET valor = @Valor WHERE nome = @Nome";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Valor", MySqlDbType.VarChar, 255);
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar, 255);
            cmd.Parameters["@Valor"].Value = config.Valor;
            cmd.Parameters["@Nome"].Value = config.Nome;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Apagar(string nomeConfig)
        {
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "DELETE FROM configuracao WHERE nome = @Nome";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar, 255);
            cmd.Parameters["@Nome"].Value = nomeConfig;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
