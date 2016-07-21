using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EscolaLivre
{
    class ConnectionManager
    {
        public const string CONNECTION_STRING =    "Server=127.0.0.1;"+
                                                    "Database=trial;"+
                                                    "Uid=root;"+
                                                    "Pwd=;";

        private static MySqlConnection connection;

        public static MySqlConnection getConnection()
        {
            if (connection == null)
            {
                connection = new MySqlConnection(CONNECTION_STRING);
            }
            return connection;
        }
        public static bool TestConnection()
        {
            try
            {
                MySqlConnection con = ConnectionManager.getConnection();
                string CmdString = "SELECT 1+1";
                MySqlCommand cmd = new MySqlCommand(CmdString, con);
                con.Open();
                MySqlDataReader rs = cmd.ExecuteReader();
                con.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
