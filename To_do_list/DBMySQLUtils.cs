using System;
using MySql.Data.MySqlClient;
 
namespace To_do_list
{
    public static class DbMySqlUtils
    {
        public static MySqlConnection GetDbConnection(string host, int port, string database, string username, string password)
        {
            String connString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + password;
            MySqlConnection conn = new MySqlConnection(connString);
            return conn;
        }
        
    }
}
