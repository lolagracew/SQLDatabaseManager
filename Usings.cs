global using System.Windows;
global using System.Data.SQLite;
global using System.Windows.Controls;
global using System.IO;
global using global;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Security.Policy;

namespace global
{
    static class GlobalVars
    {
        public static bool setup = false;
        public static string CurrentDatabase;
        public static ObservableCollection<string> Databases = new ObservableCollection<string>();
        //public static int NumberOfDatabases = Databases.Count;

        internal static void Init()
        {
            using var con = new SQLiteConnection($"Data Source=GlobalVars.db;Version=3;");
            using var cmd = new SQLiteCommand(con);
            con.Open();

            //cmd.CommandText = "CREATE DATABASE GlobalVars";
            //cmd.ExecuteNonQuery();
            //CREATE DATABASE MyFirstDatabase;

            //cmd.CommandText = $"CREATE TABLE GlobalVars.Databases(ID INT PRIMARY KEY, Name STRING)"; 
            //cmd.ExecuteNonQuery();

            //cmd.CommandText = $"SELECT TA* AS Name FROM Sales.Customers";
            //DataTable schemaTable = con.GetSchema("Tables");
            //foreach (DataRow row in schemaTable.Rows)
            //{
            //    Databases.Add(row.ToString());
            //}
            setup = true;
            //NOT STORING AS NAME!
            System.Data.SQLite.SQLiteConnection.ClearAllPools();
        }

        internal static void StoreVariables(string Input)
        {   
            using var con = new SQLiteConnection($"Data Source=GlobalVars.db;Version=3;");
            using var cmd = new SQLiteCommand(con);
            con.Open();

            Databases.Add(Input);

            cmd.CommandText = $"INSERT INTO tables {Input}";
            //cmd.CommandText = $"CREATE TABLE {Input}(id INTEGER PRIMARY KEY)";
            cmd.ExecuteNonQuery();

            System.Data.SQLite.SQLiteConnection.ClearAllPools();
        }

        internal static void DeleteVariables(string Input)
        {
            using var con = new SQLiteConnection($"Data Source=GlobalVars.db;Version=3;");
            using var cmd = new SQLiteCommand(con);
            con.Open();

            Databases.Remove(Input);    

            cmd.CommandText = $"DROP TABLE {Input}";
            cmd.ExecuteNonQuery();

            System.Data.SQLite.SQLiteConnection.ClearAllPools();
        }
    }
}
