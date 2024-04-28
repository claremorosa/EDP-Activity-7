using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using MySqlX.XDevAPI.Relational;


namespace Act_4
{ 
    public partial class UserManagement : Form
    {
        public UserManagement()
        {
            InitializeComponent();
        }

        private MySqlConnection connection = new MySqlConnection("server=127.0.0.1;port=3386;uid=root;pwd=Clang;database=event");
        private void btnDisplay_Click(object sender, EventArgs e)
        {

            try
            {
                // Open the connection
                connection.Open();

                // Define your query to select the required columns from the users table
                string query = "SELECT user_id, username, email, password FROM users";

                // Create a SqlDataAdapter to execute the query and fill the DataTable
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {


            // Create an instance of the form for adding a new account
            AddAccountForm addAccountForm = new AddAccountForm();

            // Show the form as a dialog
            DialogResult result = addAccountForm.ShowDialog();

            // Check if the user clicked the OK button on the dialog
            if (result == DialogResult.OK)
            {
                // Retrieve the user details from the form
                int userId = addAccountForm.UserId;
                string username = addAccountForm.Username;
                string email = addAccountForm.Email;
                string password = addAccountForm.Password;

                this.Hide();
                
                // Perform the database insertion (you need to write this logic)
                AddUserToDatabase(userId, username, email, password);

                // Refresh the DataGridView to display the updated data
                DisplayUserData();
            }
        }

        // Method to add a new user to the database (you need to implement this)
        private void AddUserToDatabase(int userId, string username, string email, string password)
        {
            try
            {
                // Open the connection
                connection.Open();

                // Define your INSERT query
                string query = $"INSERT INTO users (user_id, username, email, password) VALUES ({userId}, '{username}', '{email}', '{password}')";

                // Execute the query
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void DisplayUserData()
        {
            try
            {
                // Open the connection
                connection.Open();

                // Define your query to select all columns from the users table
                string query = "SELECT user_id, username, email, password FROM users";

                // Create a SqlDataAdapter to execute the query and fill the DataTable
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchUsers(textSearch.Text);
        }
        private void SearchUsers(string searchText)
        {
            string connectionString = "server=127.0.0.1;port=3386;uid=root;pwd=Clang;database=event";
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                   
                        // Check if the search text is a numeric value
                        if (int.TryParse(searchText, out int parsedUserId))
                        {
                            // If it's a numeric value, search by user_id
                            string query = "SELECT user_id, username, email, password FROM users WHERE user_id = @UserId";
                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                            command.Parameters.AddWithValue("@UserId", parsedUserId);

                            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                            // Set AutoGenerateColumns to true
                            dataGridView1.AutoGenerateColumns = true;
                            // Clear existing rows in the dataGridView1
                            dataGridView1.Rows.Clear();
                            dataGridView1.DataSource = null;
                            // Bind the DataTable to the dataGridView1
                            dataGridView1.DataSource = dataTable;
                            }
                        }
                        else
                        {
                            string query = "SELECT user_id, username, email, password FROM users WHERE username LIKE @SearchText OR email LIKE @SearchText";
                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@SearchText", $"%{searchText}%");

                                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                            // Set AutoGenerateColumns to true
                            dataGridView1.AutoGenerateColumns = true;
                            // Clear existing rows in the dataGridView1
                            dataGridView1.Rows.Clear();
                            dataGridView1.DataSource = null;
                            // Bind the DataTable to the dataGridView1
                            dataGridView1.DataSource = dataTable;

                                MessageBox.Show($"Rows found: {dataTable.Rows.Count}");

                                // dataGridView1
                                dataGridView1.DataSource = dataTable;
                                dataGridView1.AutoResizeColumns();
                                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                            }
                        }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            // Create an instance of the form for updating a account
            UpdateAccountForm updateAccountForm = new UpdateAccountForm();

            // Show the form as a dialog
            DialogResult result = updateAccountForm.ShowDialog();

            if (result == DialogResult.OK) 
            {
                // Retrieve the user details from the form
                int userId = updateAccountForm.UserId;
                string username = updateAccountForm.Username;
                string email = updateAccountForm.Email;
                string password = updateAccountForm.Password;

                

                // Perform the database insertion (you need to write this logic)
                UpdateUserToDatabase(userId, username, email, password);

                // Refresh the DataGridView to display the updated data
                DisplayUserDataV2();
            }

        }
        private void UpdateUserToDatabase(int userId, string newUsername, string newEmail, string newPassword)
        {
            try
            {
                // Open the connection
                connection.Open();

                // Define your UPDATE query
                string query = $"UPDATE users SET username = '{newUsername}', email = '{newEmail}', password = '{newPassword}' WHERE user_id = {userId}";

                // Execute the query
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void DisplayUserDataV2()
        {
            try
            {
                // Open the connection
                connection.Open();

                // Define your query to select all columns from the users table
                string query = "SELECT user_id, username, email, password FROM users";

                // Create a SqlDataAdapter to execute the query and fill the DataTable
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
