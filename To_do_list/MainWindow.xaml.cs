using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace To_do_list
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MySqlConnection conn = To_do_list.DbUtils.GetDbConnection();
            conn.Open();
            try
            {
                string sql = "Insert into table_with_tasks (id) " + " values (@id) ";
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                MySqlParameter idParam = new MySqlParameter("@id", SqlDbType.Int) {Value = 2};
                cmd.Parameters.Add(idParam);
                //MySqlParameter taskTextParam = new MySqlParameter("@task_text",SqlDbType.Text);
                //taskTextParam.Value = "Hello";
                //cmd.Parameters.Add(taskTextParam);
                int a = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close(); 
                conn.Dispose();
                conn = null;
            }
            InitializeComponent();
        }
    }
}