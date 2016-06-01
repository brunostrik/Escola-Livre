using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Urna
{
    public class SenhaDAO
    {
        public Senha ObterSenhaAtual()
        {
            string CmdString = "SELECT senha1, senha2 FROM senhas";
            MySqlConnection conn = new MySqlConnection(ChapaDAO.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand(CmdString, conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            Senha s = new Senha();
            while (dr.Read())
            {
                s.Senha1 = dr.GetString("senha1");
                s.Senha2 = dr.GetString("senha2");
            }
            conn.Close();
            return s;
        }
        public string ObterSenhaMesario()
        {
            string CmdString = "SELECT senha3 FROM senhas";
            MySqlConnection conn = new MySqlConnection(ChapaDAO.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand(CmdString, conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            string s = "";
            while (dr.Read())
            {
                s = dr.GetString("senha3");
            }
            conn.Close();
            return s;
        }
        public int AtualizarSenha(Senha s)
        {
            string CmdString = "UPDATE senhas SET senha1 = @S1, senha2 = @S2";
            MySqlConnection conn = new MySqlConnection(ChapaDAO.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand(CmdString, conn);
            cmd.Parameters.Add("@S1", MySqlDbType.VarChar);
            cmd.Parameters.Add("@S2", MySqlDbType.VarChar);
            cmd.Parameters["@S1"].Value = s.Senha1;
            cmd.Parameters["@S2"].Value = s.Senha2;
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsAffected;
        }
        public int AtualizarSenhaMesario(String NovaSenhaMesario)
        {
            string CmdString = "UPDATE senhas SET senha3 = @S";
            MySqlConnection conn = new MySqlConnection(ChapaDAO.CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand(CmdString, conn);
            cmd.Parameters.Add("@S", MySqlDbType.VarChar);
            cmd.Parameters["@S"].Value = NovaSenhaMesario;
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsAffected;
        }
        public bool TesteBD()
        {
            try
            {
                string CmdString = "SELECT 1+1 as res";
                MySqlConnection conn = new MySqlConnection(ChapaDAO.CONNECTION_STRING);
                MySqlCommand cmd = new MySqlCommand(CmdString, conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                Program.Erro("FALHA AO CONECTAR AO BANCO DE DADOS: \r\n"+e.Message);
                return false;
            }
        }
    }
}
