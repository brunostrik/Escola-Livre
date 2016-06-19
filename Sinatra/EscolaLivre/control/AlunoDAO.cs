using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace EscolaLivre
{
    public class AlunoDAO
    {
        private Aluno Montar(MySqlDataReader rs)
        {
            Aluno a = new Aluno();
            a.Id = rs.GetInt32("id");
            a.Nome = rs.GetString("nome");
            a.Cartao = rs.GetInt32("cartao");
            a.Foto = CarregaFotoAluno(a.Id);
            a.Ativo = rs.GetBoolean("ativo");
            a.DataNascimento = rs.GetDateTime("data_nascimento");
            a.DataCadastro = rs.GetDateTime("data_cadastro");
            a.Email = rs.GetString("email");
            a.IdUsuario = rs.GetInt32("id_usuario");
            return a;
        }
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
        public Aluno Carregar(int idUsuario)
        {
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "SELECT * FROM aluno WHERE id_usuario = @IdUsuario";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@IdUsuario", MySqlDbType.Int32);
            cmd.Parameters["@IdUsuario"].Value = idUsuario;
            MySqlDataReader rs = cmd.ExecuteReader();
            Aluno a = null;
            if (rs.Read())
            {
                a = Montar(rs);
            }
            con.Close();
            return a;
        }
        public bool ExisteCartao(int num)
        {
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "SELECT id FROM aluno WHERE cartao = @Card";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Card", MySqlDbType.Int32);
            cmd.Parameters["@Card"].Value = num;
            MySqlDataReader rs = cmd.ExecuteReader();
            bool a = rs.Read();
            con.Close();
            return a;
        }
        public Aluno CarregaAluno(int cartao)
        {
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "SELECT * FROM aluno WHERE cartao = @Cartao";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Cartao", MySqlDbType.Int32);
            cmd.Parameters["@Cartao"].Value = cartao;
            con.Open();
            MySqlDataReader rs = cmd.ExecuteReader();
            Aluno a = null;
            if (rs.Read())
            {
                a = Montar(rs);
            }
            con.Close();
            return a;
        }
        public byte[] CarregaFotoAluno(int idAluno)
        {
            MySqlConnection con2 = new MySqlConnection(ConnectionManager.CONNECTION_STRING);
            string CmdString = "SELECT foto FROM aluno WHERE id = @Id";
            MySqlCommand cmd = new MySqlCommand(CmdString, con2);
            cmd.Parameters.Add("@Id", MySqlDbType.Int32);
            cmd.Parameters["@Id"].Value = idAluno;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            byte[] foto = null;
            try
            {
                foto = (byte[])dt.Rows[0][0];
            }
            catch (Exception)
            {
                //feijoada
            }
            con2.Close();
            return foto;
        }
    }
}
