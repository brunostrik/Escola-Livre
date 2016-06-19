using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EscolaLivre
{
    public class UsuarioDAO
    {
        public Usuario Logar(string usr, string pwd, int tipo)
        {
            Usuario usuario = null;
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "";
            if (tipo == 0) //Professor
            {
                CmdString = "SELECT usuario.* FROM usuario JOIN professor ON professor.id_usuario = usuario.id WHERE professor.ativo = 1 AND username = @User AND senha = @Pass";
            }else //Aluno
            {
                CmdString = "SELECT usuario.* FROM usuario JOIN aluno ON aluno.id_usuario = usuario.id WHERE aluno.ativo = 1 AND username = @User AND senha = @Pass";
            }
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@User", MySqlDbType.VarChar, 255);
            cmd.Parameters.Add("@Pass", MySqlDbType.VarChar, 255);
            cmd.Parameters["@User"].Value = usr;
            cmd.Parameters["@Pass"].Value = pwd;
            con.Open();
            MySqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                usuario = new Usuario();
                usuario.Id = rs.GetInt32("id");
                usuario.Username = rs.GetString("username");
                usuario.Senha = rs.GetString("senha");
                usuario.UltimoAcesso = rs.GetDateTime("ultimo_acesso");
                usuario.Tipo = tipo;
            }
            con.Close();
            return usuario;
        }
        public Usuario Carregar(int id)
        {
            Usuario usuario = null;
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "SELECT * FROM usuario WHERE id = @Id";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Id", MySqlDbType.Int32);
            cmd.Parameters["@Id"].Value = id;
            con.Open();
            MySqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                usuario = new Usuario();
                usuario.Id = rs.GetInt32("id");
                usuario.Username = rs.GetString("username");
                usuario.Senha = rs.GetString("senha");
                usuario.UltimoAcesso = rs.GetDateTime("ultimo_acesso");
            }
            con.Close();
            return usuario;
        }
        public bool Existe(String username)
        {
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "SELECT id FROM usuario WHERE username = @Username";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Username", MySqlDbType.VarChar);
            cmd.Parameters["@Username"].Value = username;
            con.Open();
            MySqlDataReader rs = cmd.ExecuteReader();
            bool result = rs.Read();
            con.Close();
            return result;
        }
        public void RegistraMomentoLogin(int id)
        {
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "UPDATE usuario SET ultimo_acesso = CURRENT_TIMESTAMP WHERE id = @Id";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Id", MySqlDbType.Int32);
            cmd.Parameters["@Id"].Value = id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void AtualizarSenha(Usuario usuario)
        {
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "UPDATE usuario SET senha = @Senha WHERE id = @Id";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar);
            cmd.Parameters.Add("@Id", MySqlDbType.Int32);
            cmd.Parameters["@Id"].Value = usuario.Id;
            cmd.Parameters["@Senha"].Value = usuario.Senha;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public int Salvar(Usuario usuario)
        {
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "INSERT INTO usuario (username, senha) VALUES (@Username, @Senha)";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar);
            cmd.Parameters.Add("@Username", MySqlDbType.VarChar);
            cmd.Parameters["@Username"].Value = usuario.Username;
            cmd.Parameters["@Senha"].Value = usuario.Senha;
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
        public void Apagar(int id)
        {
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "DELETE FROM usuario WHERE id = @Id";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Id", MySqlDbType.Int32);
            cmd.Parameters["@Id"].Value = id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
