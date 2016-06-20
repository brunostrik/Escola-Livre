using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Drawing;

namespace EscolaLivre
{
    public class ImagesDAO
    {
        public Image ByteArray2Image(byte[] img)
        {
            MemoryStream ms = new MemoryStream(img);
            return Image.FromStream(ms);
        }
        public byte[] LoadBytesFromFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] bytes = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            return bytes;
        }
        public byte[] CarregarAlunoFoto (int idAluno)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionManager.CONNECTION_STRING);
            string CmdString = "SELECT foto FROM aluno WHERE id = @Id";
            MySqlCommand cmd = new MySqlCommand(CmdString, conn);
            cmd.Parameters.Add("@Id", MySqlDbType.VarChar);
            cmd.Parameters["@Id"].Value = idAluno;
            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Object obj = dt.Rows[0][0];
            conn.Close();
            dt.Dispose();
            byte[] img = null;
            if (obj != null)
            {
                img = (byte[])obj;
                return img;
            }else
            {
                return null;
            }            
        }
    }
}
