/**********IMPORTS*******IMPORTS*******IMPORTS*******IMPORTS*******IMPORTS*******IMPORTS*******IMPORTS*******IMPORTS*******IMPORTS*******IMPORTS*******/

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

/********PROGRAM************PROGRAM************PROGRAM************PROGRAM************PROGRAM************PROGRAM************PROGRAM************PROGRAM******/
namespace InfoV1x0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            while (true)
            {
                /******DIALOGUE*********DIALOGUE**********/
            SQLiSwitch();
                /********EXIT******EXIT******EXIT******/
                Console.WriteLine("Do you want to exit?");
                string textExit = Console.ReadLine();
                if (textExit == "yes" || textExit == "y")
                {
                    break; //EXIT
                }
            }
            End();
        }
        /*********SQLITE MAIN DIALOGUE*********SQLITE MAIN DIALOGUE*********SQLITE MAIN DIALOGUE*********SQLITE MAIN DIALOGUE*********/
        static void SQLiSwitch()
        {
            /****DATA*********DATA*********DATA*********/
            bool answer = false;
            // New keywords: Insert.
            const string KEYWORDS = "the end; read; insert; create table; delete; drop table; watch; clear";
            /***COMMANDS********COMMANDS********COMMANDS***/
            while (!answer)
            {
                Console.WriteLine("What do you want? Type 'help' to see list of keywords.");
                string input = Console.ReadLine();
                switch (input)
                {/*****FUNCTION CALL*****FUNCTION CALL*****/
                    case "help":
                        Console.WriteLine($"Keywords: {KEYWORDS}."); break;
                    case "the end":
                        Console.WriteLine("Okay."); answer = true; break;
                    case "read":
                        ReadDialoge(); break;
                    case "insert":
                        InsertDialoge(); break;
                    case "create table":
                        CreateDatabaseUserDialogue(); break;
                    case "watch":
                        PageUp(); break;
                    case "clear":
                        Console.Clear(); break;
                    case "delete":
                        DeleteDialogue(); break;
                    case "drop table":
                        DropDatabaseUserDialogue(); break;
                    case "proba":
                        Proba("FirstTable"); break;
                    case "I don't know-":
                        Console.WriteLine("...Okay. Well, the show is over."); answer= true; break;
                    default:
                        Console.WriteLine("Not possible."); break;
                }
            }
        }

        /**********SQLITE FUNCTIONS**********SQLITE FUNCTIONS**********SQLITE FUNCTIONS**********SQLITE FUNCTIONS**********SQLITE FUNCTIONS**********/

        /***************READ***********READ***********READ***********READ***********READ***********READ***********READ***********READ***********READ*******/
        static void ReadDialoge()
        {
            Console.WriteLine("Table name?");
            string table = Console.ReadLine();
            string[] columns = new string[10];
            for (int i = 0; i < columns.Length; i++)
            {
                Console.WriteLine("Column name? Write 'the end' to end.");
                string input = Console.ReadLine();
                if (input == "the end") break;
                else columns[i] = input;

            }
            Console.WriteLine("Where?");
            string where = Console.ReadLine();
            RetrieveData(table, columns, where);
        }
        static void RetrieveData(string table, string[] columns, string where)
        {
            string connectionString = "Data Source=ymdatabase.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand selectData = new SQLiteCommand($"SELECT * FROM {table} WHERE {where};", connection))
                using (SQLiteDataReader reader = selectData.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < columns.Length; i++)
                        {
                            if (string.IsNullOrEmpty(columns[i])) { Console.Write("\n"); break; }
                            Console.Write($"{columns[i]}: {reader[$"{columns[i]}"]}, ");
                        }
                    }
                }
            }
        }
        /****************INSERT*********INSERT*********INSERT*********INSERT*********INSERT*********INSERT*********INSERT*********INSERT*********/
        static void InsertDialoge()
        {
            Console.WriteLine("Table name?");
            string table = Console.ReadLine();
            Console.WriteLine("Column names? (Be careful!)");
            string columns = Console.ReadLine();
            Console.WriteLine("Value names? (Be careful!)");
            string values = Console.ReadLine();
            PopulateDatabase(table, columns, values);
        }
        static void PopulateDatabase(string table, string columns, string values)
        {
            string connectionString = "Data Source=ymdatabase.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand insertData = new SQLiteCommand($"INSERT INTO {table} ({columns}) VALUES ({values});", connection))
                {
                    insertData.ExecuteNonQuery();
                }
            }
        }
        /************CREATE TABLE***********CREATE TABLE***********CREATE TABLE***********CREATE TABLE***********CREATE TABLE***********CREATE TABLE***********/
        static void CreateDatabaseUserDialogue()
        {
            Console.WriteLine("Table name?");
            string name = Console.ReadLine();
            Console.WriteLine("Column names? (Be careful!)");
            string columns = Console.ReadLine();
            CreateDatabase(name, columns);
        }
        static void CreateDatabase(string name, string columns)
        {
            string connectionString = "Data Source=ymdatabase.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                // QUERY
                using (SQLiteCommand createTable = new SQLiteCommand($"CREATE TABLE IF NOT EXISTS {name} ({columns});", connection))
                {
                    createTable.ExecuteNonQuery();
                }
                PopulateDatabase("TableNames", "Name", $"'{name}'");
            }
        }
        /********DROP TABLE**********DROP TABLE**********DROP TABLE**********DROP TABLE**********DROP TABLE**********DROP TABLE**********DROP TABLE**********/
        static void DropDatabaseUserDialogue()
        {
            Console.WriteLine("Table name?");
            string name = Console.ReadLine();
            Console.WriteLine("Are you sure? (y/n)");
            string inpuut = Console.ReadLine();
            if (inpuut == "y")
            {
                DropDatabase(name);
            }
            
        }
        static void DropDatabase(string name)
        {
            string connectionString = "Data Source=ymdatabase.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                // QUERY
                int id = -1;
                using (SQLiteCommand selectData = new SQLiteCommand($"SELECT Id FROM TableNames WHERE Name = '{name}';", connection))
                using (SQLiteDataReader reader = selectData.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                }
                if (id < 0)
                {
                    Console.WriteLine("Didn't do it.");
                }
                else
                {
                    using (SQLiteCommand createTable = new SQLiteCommand($"DROP TABLE {name};", connection))
                    {
                        createTable.ExecuteNonQuery();
                    }
                    DeleteRecordById("TableNames", id);
                }
                
                
                //Console.Write($"{columns[i]}: {reader[$"{columns[i]}"]}, ");


                /*int id;
                using (SQLiteCommand selectData = new SQLiteCommand($"SELECT Id FROM TableNames WHERE Name = {name};", connection))
                using (SQLiteDataReader reader = selectData.ExecuteReader())
                {
                    //id = reader["Id"];
                }*/

                //DeleteRecordById("TableNames", ID??);
            }
        }
        /***********DELETE**********DELETE**********DELETE**********DELETE**********DELETE**********DELETE**********DELETE**********DELETE**********DELETE********/
        static void DeleteDialogue()
        {
            Console.WriteLine("Table name?");
            string table = Console.ReadLine();
            Console.WriteLine("id?");
            int name = int.Parse(Console.ReadLine());

            Console.WriteLine("Are you sure? (y/n)");
            string inpuut = Console.ReadLine();
            if (inpuut == "y")
            {
                DeleteRecordById(table, name);
            }

        }
        //static void DeleteRecordById(string table, int id)
        static void DeleteRecordById(string table, int id)
        {
            string connectionString = "Data Source=ymdatabase.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Define the SQL command to delete a record by ID
                string deleteSql = $"DELETE FROM {table} WHERE Id = @Id";

                using (SQLiteCommand deleteCommand = new SQLiteCommand(deleteSql, connection))
                {
                    // Add a parameter for the ID value
                    deleteCommand.Parameters.AddWithValue("@Id", id);

                    // Execute the DELETE command
                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Record with ID {id} was deleted.");
                    }
                    else
                    {
                        Console.WriteLine($"No record with ID {id} found.");
                    }
                }
            }
        }

        
        /***********************************************************OTHER USER DIALOGUES*******************************************************************/
        static void End()
        {
            Console.WriteLine("The End. Press button to close.");
            Console.ReadKey();
        }
        /***********WATCH*******WATCH*******WATCH*******WATCH*******WATCH*******WATCH*******WATCH*******WATCH*******WATCH*******WATCH*******WATCH*******/
        static void PageUp()
        {
            Console.WriteLine("Now you can use PageUp, nothing else. Press ESC to finish.");
            int visibleHeight = Console.WindowHeight - 1; // Number of visible lines (excluding the status bar).
            int bufferHeight = Console.LargestWindowHeight; // Total buffer height.

            Console.SetBufferSize(Console.WindowWidth, bufferHeight);
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey();
                /*// DOESN'T WORK, DON'T USE!
                if (keyInfo.Key == ConsoleKey.PageDown)
                {
                    Console.MoveBufferArea(0, 0, Console.WindowWidth, visibleHeight, 0, -visibleHeight);
                }*/
                // Simulate "page up" by scrolling the buffer down.
                if (keyInfo.Key == ConsoleKey.PageUp)
                {
                    Console.MoveBufferArea(0, 0, Console.WindowWidth, visibleHeight, 0, visibleHeight);
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    Console.MoveBufferArea(0, 0, Console.WindowWidth, visibleHeight, 0, visibleHeight/4);
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }
        
        /*******************************************************************UNUSED FUNCTIONS*******************************************************************/
        static void Proba(string name)
        {
            /*string connectionString = "Data Source=ymdatabase.db;Version=3;";
            int id = -1;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                // QUERY
            }*/
            
        }
        /*******IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****/
        static void UpdateDialogue()
        {

        }
        static void UpdateRecord()
        {

        }
        /****GOOD******GOOD******GOOD******GOOD******GOOD******GOOD******GOOD******GOOD******GOOD******GOOD******GOOD******GOOD******GOOD******GOOD******/
    }
}

/*******IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****IDK*****/
/****GOOD******GOOD******GOOD******GOOD******GOOD******GOOD******GOOD******GOOD******GOOD******GOOD******GOOD******GOOD******GOOD******GOOD******/