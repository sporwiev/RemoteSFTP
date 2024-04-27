using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace RemoteSFTP
{
    internal class DB
    {
        
        MySqlConnection conn = new MySqlConnection($"server=localhost;port=3306;username={new MainWindow().UserDB.Text};password={new MainWindow().PassDB.Text}");
        public MySqlConnection getConnection() { return conn; }
        public void openConnection() { if(conn.State == System.Data.ConnectionState.Closed) conn.Open(); }
        public void closeConnection() { if (conn.State == System.Data.ConnectionState.Open) conn.Close(); }
    }
}
