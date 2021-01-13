using MySql.Data.MySqlClient;

namespace To_do_list
{
    public static class DbUtils
    {
        public static MySqlConnection GetDbConnection( )
        {
            const string host = "127.0.0.1";
            const int port = 3306;
            const string database = "to_do_tasks_list";
            const string username = "athena";
            const string password = "0MechTa8";
 
            return DbMySqlUtils.GetDbConnection(host, port, database, username, password);
        }
    }
}