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
            string CmdString = "INSERT INTO aluno(nome, cartao, foto, ativo, email, data_nascimento, data_cadastro, id_usuario) VALUES(@Nome, @Cartao, @Foto, @Ativo, @Email, @Nascimento, CURRENT_TIMESTAMP, @IdUsuario)";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar, 255);
            cmd.Parameters.Add("@Cartao", MySqlDbType.Int32);
            cmd.Parameters.Add("@Foto", MySqlDbType.MediumBlob);
            cmd.Parameters.Add("@Ativo", MySqlDbType.Bit);
            cmd.Parameters.Add("@Email", MySqlDbType.VarChar);
            cmd.Parameters.Add("@Nascimento", MySqlDbType.DateTime);
            cmd.Parameters.Add("@IdUsuario", MySqlDbType.Int32);
            cmd.Parameters["@Nome"].Value = a.Nome;
            cmd.Parameters["@Cartao"].Value = a.Cartao;
            cmd.Parameters["@Foto"].Value = a.Foto;
            cmd.Parameters["@Ativo"].Value = a.Ativo;
            cmd.Parameters["@Email"].Value = a.Email;
            cmd.Parameters["@Nascimento"].Value = a.DataNascimento;
            cmd.Parameters["@IdUsuario"].Value = a.IdUsuario;
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            if (rowsAffected > 0)
            {
                int id = Convert.ToInt32(cmd.LastInsertedId);
                return id;
            }
            else
            {
                return 0;
            }
        }
        public int Atualizar(Aluno a)
        {
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "UPDATE aluno SET (nome = @Nome, cartao = @Cartao, email = @Email, foto = @Foto, ativo = @Ativo, data_nascimento = @Nascimento, id_usuario = @IdUsuario) WHERE id = @Id";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar);
            cmd.Parameters.Add("@Cartao", MySqlDbType.Int32);
            cmd.Parameters.Add("@Foto", MySqlDbType.MediumBlob);
            cmd.Parameters.Add("@Ativo", MySqlDbType.Bit);
            cmd.Parameters.Add("@Id", MySqlDbType.Int32);
            cmd.Parameters.Add("@Nascimento", MySqlDbType.DateTime);
            cmd.Parameters.Add("@IdUsuario", MySqlDbType.Int32);
            cmd.Parameters.Add("@Email", MySqlDbType.VarChar);
            cmd.Parameters["@Nome"].Value = a.Nome;
            cmd.Parameters["@Cartao"].Value = a.Cartao;
            cmd.Parameters["@Foto"].Value = a.Foto;
            cmd.Parameters["@Ativo"].Value = a.Ativo;
            cmd.Parameters["@Id"].Value = a.Id;
            cmd.Parameters["@Email"].Value = a.Ativo;
            cmd.Parameters["@Nascimento"].Value = a.DataNascimento;
            cmd.Parameters["@IdUsuario"].Value = a.Ativo;
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            if (rowsAffected > 0)
            {
                int id = Convert.ToInt32(cmd.LastInsertedId);
                return id;
            }
            else
            {
                return 0;
            }
        }
        public int Persistir (Aluno a)
        {
            if (a.Id != 0)
            {
                return Atualizar(a);
            }
            else
            {
                return Salvar(a);
            }
        }
        public Aluno Carregar(int idUsuario)
        {
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "SELECT * FROM aluno WHERE id_usuario = @IdUsuario";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@IdUsuario", MySqlDbType.Int32);
            cmd.Parameters["@IdUsuario"].Value = idUsuario;
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
        public bool ExisteCartao(int num)
        {
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "SELECT id FROM aluno WHERE cartao = @Card";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Card", MySqlDbType.Int32);
            cmd.Parameters["@Card"].Value = num;
            con.Open();
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
