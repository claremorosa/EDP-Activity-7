using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Act_4
{
    public partial class Form1 : Form
    {
        private string myConnectionString = "Server=127.0.0.1;Port=3386;Database=event;User=root;Password=Clang;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
           
            myConnectionString = "server=127.0.0.1;port=3386;uid=root;pwd=Clang;database=event";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MessageBox.Show("Connected");
            
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to the server. Contact administrator.");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again", "Password Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show($"MySQL Error Number: {ex.Number}\n{ex.Message}", "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex) // To catch any other exceptions that are not MySQL-specific
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnLoGin_Click_1(object sender, EventArgs e)
        {
            string myusername = this.txtusername.Text;
            string mypassword = this.txtpassword.Text;

            string myConnectionString = "Server=127.0.0.1;Port=3386;Database=event;User=root;Password=Clang;";

            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();

                    // Check if the username and password are valid
                    string sql = "SELECT COUNT(*) FROM users WHERE username = @myuser AND password = @mypass";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@myuser", myusername);
                    cmd.Parameters.AddWithValue("@mypass", mypassword);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        // Set all users to inactive first
                        string updateInactiveSql = "UPDATE users SET status = 'inactive'";
                        MySqlCommand updateInactiveCmd = new MySqlCommand(updateInactiveSql, conn);
                        updateInactiveCmd.ExecuteNonQuery();

                        // Set the status of the logged-in user to active
                        string updateActiveSql = "UPDATE users SET status = 'active' WHERE username = @myuser";
                        MySqlCommand updateActiveCmd = new MySqlCommand(updateActiveSql, conn);
                        updateActiveCmd.Parameters.AddWithValue("@myuser", myusername);
                        updateActiveCmd.ExecuteNonQuery();

                        this.Hide();
                        var myform = new UserManagement();
                        myform.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                    }
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 0:
                            MessageBox.Show("Cannot connect to server. Contact administrator");
                            break;
                        case 1045:
                            MessageBox.Show("Invalid username/password, please try again", "Password Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        default:
                            MessageBox.Show($"Database error: {ex.Message}");
                            break;
                    }
                }
            }
        }

        

        

        private void RecoverPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var myform = new RecoverPassword();
            myform.ShowDialog();
        }
    }
}
    
 
