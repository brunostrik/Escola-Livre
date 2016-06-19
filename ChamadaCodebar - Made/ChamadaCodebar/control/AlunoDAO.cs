using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EscolaLivre
{
    public class AlunoDAO
    {
        public int Salvar(Aluno a)
        {
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "INSERT INTO aluno(nome, cartao, foto, ativo) VALUES(@Nome, @Cartao, @Foto, @Ativo)";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar, 255);
            cmd.Parameters.Add("@Cartao", MySqlDbType.Int32);
            cmd.Parameters.Add("@Foto", MySqlDbType.MediumBlob);
            cmd.Parameters.Add("@Ativo", MySqlDbType.Bit);
            cmd.Parameters["@Nome"].Value = a.Nome;
            cmd.Parameters["@Cartao"].Value = a.Cartao;
            cmd.Parameters["@Foto"].Value = a.Foto;
            cmd.Parameters["@Ativo"].Value = a.Ativo;
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;
        }
        public Aluno LoadByIdUsuario(int idUsuario)
        {
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "SELECT id, nome, cartao, ativo, data_nascimento, data_cadastro, email FROM aluno WHERE id_usuario = @IdUsuario";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@IdUsuario", MySqlDbType.Int32);
            cmd.Parameters["@IdUsuario"].Value = idUsuario;
            MySqlDataReader rs = cmd.ExecuteReader();
            Aluno a = null;
            if (rs.Read())
            {
                a = new Aluno();
                a.Id = rs.GetInt32("id");
                a.Nome = rs.GetString("nome");
                a.Cartao = rs.GetInt32("cartao");
                a.Ativo = rs.GetBoolean("ativo");
                a.DataNascimento = rs.GetDateTime("data_nascimento");
                a.DataCadastro = rs.GetDateTime("data_cadastro");
                a.Email = rs.GetString("email");
                a.IdUsuario = idUsuario;
            }
            con.Close();
            return a;
        }
    }
}
