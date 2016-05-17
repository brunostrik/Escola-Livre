using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ChamadaCodebar.model;

namespace ChamadaCodebar.control
{
    public class AlunoDAO
    {
        public int Salvar(Aluno a)
        {
            MySqlConnection con = ConnectionManager.getConnection();
            string CmdString = "INSERT INTO aluno(nome, cartao, foto) VALUES(@Nome, @Cartao, @Foto)";
            MySqlCommand cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar, 255);
            cmd.Parameters.Add("@Cartao", MySqlDbType.Int32);
            cmd.Parameters.Add("@Foto", MySqlDbType.MediumBlob);
            cmd.Parameters["@Nome"].Value = a.nome;
            cmd.Parameters["@Cartao"].Value = a.cartao;
            cmd.Parameters["@Foto"].Value = a.foto;
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;
        }
    }
}
