using System;
using System.Data.Entity;
using System.Xml.Linq;

namespace SQLProject
{
    /// <summary>
    /// Interaction logic for CreateDatabase.xaml
    /// </summary>
    public partial class Create : Window
    {
        public Create()
        {
            InitializeComponent();
        }
        private void CreateDatabase_Click(object sender, RoutedEventArgs e)
        {
            string Input = InputBox.Text;
            if (Input == null)
            {
                MessageBox.Show("No value input.");
            }
            //var fileName = string.Format($"{Input}");
            //SQLiteConnection.CreateFile(fileName);


            // SQLiteConnection.CreateFile($"{Input}");
            System.Data.SQLite.SQLiteConnection.CreateFile(Input); // Create the file which will be hosting our database


            using var con = new SQLiteConnection($"Data Source={Input}.db;Version=3;");
            con.Open();


            //using var cmd = new SQLiteCommand(con);
            //cmd.CommandText = $"CREATE DATABASE {Input}";
            //cmd.ExecuteNonQuery();

            if (File.Exists($"{Input}.db"))
            {
                MessageBox.Show($"Database: {Input} has been created :)");
                //GlobalVars.Databases.Add();//($"{Input}.db");
                //GlobalVars.Databases.Add(new Database() { Name});
                global.GlobalVars.StoreVariables(Input);
            }

            else
            {
                MessageBox.Show("Database was not able to be created");
            }
            SQLiteConnection.ClearAllPools();
            //con.Dispose();
            //GC.Collect();
            //con.Close();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            main.Show();

        }
    }
}
