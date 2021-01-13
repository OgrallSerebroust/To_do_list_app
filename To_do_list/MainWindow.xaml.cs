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
            InitializeComponent();
            GetContent();
        }

        private void GetContent()
        {
            MySqlConnection connection = DbUtils.GetDbConnection();
            connection.Open();
            try
            {
                string queryForReading = "SELECT * FROM table_with_tasks";
                MySqlCommand commandForReading = connection.CreateCommand();
                commandForReading.CommandText = queryForReading;
                MySqlDataReader dataFromOurTaskTable = commandForReading.ExecuteReader();
                if(dataFromOurTaskTable.HasRows)
                {
                    while(dataFromOurTaskTable.Read())
                    {
                        object id = dataFromOurTaskTable.GetValue(0);
                        string text = dataFromOurTaskTable.GetValue(1).ToString();
                        OurTasksBlock.AppendText(text + "\n");
                    }
                    dataFromOurTaskTable.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close(); 
                connection.Dispose();
                connection = null;
            }
        }

        private void ButtonOfAdding_OnClick(object sender, RoutedEventArgs e)
        {
            string textOfOurNewTask = BlockOfNewTaskText.Text;
            MySqlConnection connectionForInsertNewTask = DbUtils.GetDbConnection();
            connectionForInsertNewTask.Open();
            try
            {
                string queryForInserting = "Insert into table_with_tasks(task_text) " + " values (@task_text)";
                MySqlCommand commandInInserting = connectionForInsertNewTask.CreateCommand();
                commandInInserting.CommandText = queryForInserting;
                MySqlParameter taskTextParam = new MySqlParameter("@task_text", MySqlDbType.String);
                taskTextParam.Value = textOfOurNewTask;
                commandInInserting.Parameters.Add(taskTextParam);
                commandInInserting.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Error: " + exc);
                Console.WriteLine(exc.StackTrace);
            }
            finally
            {
                connectionForInsertNewTask.Close(); 
                connectionForInsertNewTask.Dispose();
                connectionForInsertNewTask = null;
            }
        }
    }
}