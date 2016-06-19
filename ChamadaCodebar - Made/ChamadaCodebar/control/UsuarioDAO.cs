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
    }
}
