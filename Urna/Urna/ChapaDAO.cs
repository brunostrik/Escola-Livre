using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Urna
{
    public class ChapaDAO
    {
        private const string CONNECTION_STRING = "Server=127.0.0.1;" +
                                                    "Database=urna;" +
                                                    "Uid=root;" +
                                                    "Pwd=;";
        public int Votar (int Numero)
        {
            MySqlConnection conn = new MySqlConnection(CONNECTION_STRING);
            string cmdString = "UPDATE chapas SET votos = votos + 1 WHERE numero = @Numero";
            MySqlCommand cmd = new MySqlCommand(cmdString, conn);
            cmd.Parameters.Add("@Numero", MySqlDbType.Int32);
            cmd.Parameters["@Numero"].Value = Numero;
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsAffected;
        }
        public int VotarNulo()
        {
            MySqlConnection conn = new MySqlConnection(CONNECTION_STRING);
            string cmdString = "UPDATE chapas SET votos = votos + 1 WHERE numero = -1";
            MySqlCommand cmd = new MySqlCommand(cmdString, conn);
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsAffected;
        }
        public int VotarBranco()
        {
            MySqlConnection conn = new MySqlConnection(CONNECTION_STRING);
            string cmdString = "UPDATE chapas SET votos = votos + 1 WHERE numero = 0";
            MySqlCommand cmd = new MySqlCommand(cmdString, conn);
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsAffected;
        }
        public int Cadastrar(Chapa c)
        {
            MySqlConnection conn = new MySqlConnection(CONNECTION_STRING);
            string CmdString = "INSERT INTO chapas "+
                "(numero, nome, presidente, vice_presidente, relator, vice_relator, "+
                "foto_presidente, foto_vice_presidente, foto_relator, foto_vice_relator, votos) "+
                "VALUES(@Numero, @Nome, @Presidente, @VicePresidente, @Relator, @ViceRelator "+
                "@FotoPresidente, @FotoVicePresidente, @FotoRelator, @FotoViceRelator, @Votos)";
            MySqlCommand cmd = new MySqlCommand(CmdString, conn);
            cmd.Parameters.Add("@Numero", MySqlDbType.Int32);
            cmd.Parameters.Add("@Presidente", MySqlDbType.VarChar);
            cmd.Parameters.Add("@VicePresidente", MySqlDbType.VarChar);
            cmd.Parameters.Add("@Relator", MySqlDbType.VarChar);
            cmd.Parameters.Add("@ViceRelator", MySqlDbType.VarChar);
            cmd.Parameters.Add("@FotoPresidente", MySqlDbType.MediumBlob);
            cmd.Parameters.Add("@FotoVicePresidente", MySqlDbType.MediumBlob);
            cmd.Parameters.Add("@FotoRelator", MySqlDbType.MediumBlob);
            cmd.Parameters.Add("@FotoViceRelator", MySqlDbType.MediumBlob);
            cmd.Parameters.Add("@Votos", MySqlDbType.Int32);
            cmd.Parameters["@Numero"].Value = c.Numero;
            cmd.Parameters["@Nome"].Value = c.Nome;
            cmd.Parameters["@Presidente"].Value = c.Presidente;
            cmd.Parameters["@VicePresidente"].Value = c.VicePresidente;
            cmd.Parameters["@Relator"].Value = c.Relator;
            cmd.Parameters["@ViceRelator"].Value = c.ViceRelator;
            cmd.Parameters["@FotoPresidente"].Value = c.FotoPresidente;
            cmd.Parameters["@FotoVicePresidente"].Value = c.FotoVicePresidente;
            cmd.Parameters["@FotoRelator"].Value = c.FotoRelator;
            cmd.Parameters["@FotoViceRelator"].Value = c.FotoViceRelator;
            cmd.Parameters["@Votos"].Value = c.Votos;
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsAffected;
        }
        public List<ApuracaoDTO> Resultado()
        {
            string CmdString = "SELECT nome, votos FROM chapas ORDER BY votos DESC";
            MySqlConnection conn = new MySqlConnection(CONNECTION_STRING);
            MySqlCommand cmd = new MySqlCommand(CmdString, conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            List<ApuracaoDTO> l = new List<ApuracaoDTO>();
            while (dr.Read())
            {
                ApuracaoDTO a = new ApuracaoDTO();
                a.Nome = dr.GetString("nome");
                a.Votos = dr.GetInt32("votos");
                l.Add(a);
            }
            conn.Close();
            return l;
        }
    }
}
