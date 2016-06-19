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
    }
}
