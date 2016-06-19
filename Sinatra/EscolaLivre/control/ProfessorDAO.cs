using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EscolaLivre
{
    public class ProfessorDAO
    {
        public Professor LoadByIdUsuario(int idUsuario)
        {
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "SELECT id, nome, ativo, data_cadastro, email FROM professor WHERE id_usuario = @IdUsuario";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@IdUsuario", MySqlDbType.Int32);
            cmd.Parameters["@IdUsuario"].Value = idUsuario;
            con.Open();
            MySqlDataReader rs = cmd.ExecuteReader();
            Professor p = null;
            if (rs.Read())
            {
                p = new Professor();
                p.Id = rs.GetInt32("id");
                p.Nome = rs.GetString("nome");
                p.Email = rs.GetString("email");
                p.DataCadastro = rs.GetDateTime("data_cadastro");
                p.Ativo = rs.GetBoolean("ativo");
                p.IdUsuario = idUsuario;
            }
            con.Close();
            return p;
        }
        public Professor Carregar(int id)
        {
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "SELECT * FROM professor WHERE id = @Id";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Id", MySqlDbType.Int32);
            cmd.Parameters["@Id"].Value = id;
            con.Open();
            MySqlDataReader rs = cmd.ExecuteReader();
            Professor p = null;
            if (rs.Read())
            {
                p = new Professor();
                p.Id = rs.GetInt32("id");
                p.Nome = rs.GetString("nome");
                p.Email = rs.GetString("email");
                p.DataCadastro = rs.GetDateTime("data_cadastro");
                p.Ativo = rs.GetBoolean("ativo");
                p.IdUsuario = rs.GetInt32("id_usuario");
            }
            con.Close();
            return p;
        }
        public int Salvar(Professor p)
        {
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "INSERT INTO professor (nome, email, data_cadastro, ativo, id_usuario) " +
                                "VALUES (@Nome, @Email, CURRENT_TIMESTAMP, @Ativo, @Usuario)";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar);
            cmd.Parameters.Add("@Email", MySqlDbType.VarChar);
            cmd.Parameters.Add("@Ativo", MySqlDbType.Bit);
            cmd.Parameters.Add("@Usuario", MySqlDbType.Int32);
            cmd.Parameters["@Nome"].Value = p.Nome;
            cmd.Parameters["@Email"].Value = p.Email;
            cmd.Parameters["@Ativo"].Value = p.Ativo;
            cmd.Parameters["@Usuario"].Value = p.IdUsuario;
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                int id = Convert.ToInt32(cmd.LastInsertedId);
                con.Close();
                return id;
            }
            else
            {
                con.Close();
                return 0;
            }
        }
    }
}
