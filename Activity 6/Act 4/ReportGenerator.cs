using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics.Contracts;

namespace Act_4
{
    public class ReportGenerator
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public ReportGenerator(string server, string database, string uid, string password)
        {
            this.server = server;
            this.database = database;
            this.uid = uid;
            this.password = password;
            Initialize();
        }

        //Initialize Connection
        private void Initialize()
        {
            string connectionString = $"Server={server};Port=3386;Database={database};Uid={uid};Pwd={password};";
            connection = new MySqlConnection(connectionString);
        }

        // Open Connection to Database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    case 1049:
                        MessageBox.Show("Unknown database. Verify the database name.");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
                return false;
            }
        }

        // Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Execute query (SELECT)
        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                CloseConnection();
                return dt;
            }
            else
            {
                return null;
            }
        }

        //Execute command (INSERT, UPDATE, DELETE)
        public bool ExecuteCommand(string query)
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}