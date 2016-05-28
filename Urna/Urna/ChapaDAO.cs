using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Urna
{
    public class ChapaDAO
    {
        private const string CONNECTION_STRING = "Server=127.0.0.1;" +
                                                    "Database=urna;" +
                                                    "Uid=root;" +
                                                    "Pwd=;";
        public int Votar (string Numero)
        {
            MySqlConnection conn = new MySqlConnection(CONNECTION_STRING);
            string cmdString = "UPDATE chapas SET votos = votos + 1 WHERE numero = @Numero";
            MySqlCommand cmd = new MySqlCommand(cmdString, conn);
            cmd.Parameters.Add("@Numero", MySqlDbType.VarChar);
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
        public Chapa CarregarChapa(string num)
        {
            MySqlConnection conn = new MySqlConnection(CONNECTION_STRING);
            string cmdString = "SELECT nome, presidente, vice_presidente, relator, vice_relator, "+
                "foto_presidente, foto_vice_presidente, foto_relator, foto_vice_relator FROM chapas "+
                "WHERE numero = @Numero";
            MySqlCommand cmd = new MySqlCommand(cmdString, conn);
            cmd.Parameters.Add("@Numero", MySqlDbType.Int32);
            cmd.Parameters["@Numero"].Value = num;
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();         
            Chapa c = null;
            if (dr.Read())
            {
                c = new Chapa();
                c.Numero = num;
                c.Nome = dr.GetString("nome");
                c.Presidente = dr.GetString("presidente");
                c.VicePresidente = dr.GetString("vice_presidente");
                c.Relator = dr.GetString("relator");
                c.ViceRelator = dr.GetString("vice_relator");               
            }
            //OBTER FOTOS
            conn.Close();
            return CarregarFotos(c);
        }
        public Chapa CarregarFotos(Chapa c)
        {
            if (c != null)
            {
                MySqlConnection conn = new MySqlConnection(CONNECTION_STRING);
                string CmdString = "SELECT foto_presidente, foto_vice_presidente, " +
                    "foto_relator, foto_vice_relator FROM chapas WHERE numero = @Numero";
                MySqlCommand cmd = new MySqlCommand(CmdString, conn);
                cmd.Parameters.Add("@Numero", MySqlDbType.VarChar);
                cmd.Parameters["@Numero"].Value = c.Numero;
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                c.FotoPresidente = (byte[])dt.Rows[0][0];
                c.FotoVicePresidente = (byte[])dt.Rows[0][1];
                c.FotoRelator = (byte[])dt.Rows[0][2];
                c.FotoViceRelator = (byte[])dt.Rows[0][3];
                conn.Close();
            }
            return c;
        }
        public int Cadastrar(Chapa c)
        {
            MySqlConnection conn = new MySqlConnection(CONNECTION_STRING);
            string CmdString = "INSERT INTO chapas " +
                "(numero, nome, presidente, vice_presidente, relator, vice_relator, votos) " +
                "VALUES(@Numero, @Nome, @Presidente, @VicePresidente, @Relator, @ViceRelator, @Votos)";
            MySqlCommand cmd = new MySqlCommand(CmdString, conn);
            cmd.Parameters.Add("@Numero", MySqlDbType.VarChar);
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar);
            cmd.Parameters.Add("@Presidente", MySqlDbType.VarChar);
            cmd.Parameters.Add("@VicePresidente", MySqlDbType.VarChar);
            cmd.Parameters.Add("@Relator", MySqlDbType.VarChar);
            cmd.Parameters.Add("@ViceRelator", MySqlDbType.VarChar);          
            cmd.Parameters.Add("@Votos", MySqlDbType.Int32);
            cmd.Parameters["@Numero"].Value = c.Numero;
            cmd.Parameters["@Nome"].Value = c.Nome;
            cmd.Parameters["@Presidente"].Value = c.Presidente;
            cmd.Parameters["@VicePresidente"].Value = c.VicePresidente;
            cmd.Parameters["@Relator"].Value = c.Relator;
            cmd.Parameters["@ViceRelator"].Value = c.ViceRelator;
            cmd.Parameters["@Votos"].Value = c.Votos;
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            //AGORA INSERIR A FOTO DO PRESIDENTE
            conn = new MySqlConnection(CONNECTION_STRING);
            CmdString = "UPDATE chapas SET foto_presidente = @Foto WHERE numero = @Numero";
            cmd = new MySqlCommand(CmdString, conn);
            cmd.Parameters.Add("@Foto", MySqlDbType.MediumBlob);
            cmd.Parameters.Add("@Numero", MySqlDbType.VarChar);
            cmd.Parameters["@Numero"].Value = c.Numero;
            cmd.Parameters["@Foto"].Value = c.FotoPresidente;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            //AGORA INSERIR A FOTO DO VICE PRESIDENTE
            conn = new MySqlConnection(CONNECTION_STRING);
            CmdString = "UPDATE chapas SET foto_vice_presidente = @Foto WHERE numero = @Numero";
            cmd = new MySqlCommand(CmdString, conn);
            cmd.Parameters.Add("@Foto", MySqlDbType.MediumBlob);
            cmd.Parameters.Add("@Numero", MySqlDbType.VarChar);
            cmd.Parameters["@Numero"].Value = c.Numero;
            cmd.Parameters["@Foto"].Value = c.FotoVicePresidente;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            //AGORA INSERIR A FOTO DO RELATOR
            conn = new MySqlConnection(CONNECTION_STRING);
            CmdString = "UPDATE chapas SET foto_relator = @Foto WHERE numero = @Numero";
            cmd = new MySqlCommand(CmdString, conn);
            cmd.Parameters.Add("@Foto", MySqlDbType.MediumBlob);
            cmd.Parameters.Add("@Numero", MySqlDbType.VarChar);
            cmd.Parameters["@Numero"].Value = c.Numero;
            cmd.Parameters["@Foto"].Value = c.FotoRelator;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            //AGORA INSERIR A FOTO DO VICE RELATOR
            conn = new MySqlConnection(CONNECTION_STRING);
            CmdString = "UPDATE chapas SET foto_vice_relator = @Foto WHERE numero = @Numero";
            cmd = new MySqlCommand(CmdString, conn);
            cmd.Parameters.Add("@Foto", MySqlDbType.MediumBlob);
            cmd.Parameters.Add("@Numero", MySqlDbType.VarChar);
            cmd.Parameters["@Numero"].Value = c.Numero;
            cmd.Parameters["@Foto"].Value = c.FotoViceRelator;
            conn.Open();
            cmd.ExecuteNonQuery();
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
