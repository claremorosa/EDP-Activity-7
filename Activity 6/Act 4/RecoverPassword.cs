using MySql.Data.MySqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Act_4
{
    public partial class RecoverPassword : Form
    {
        private string myConnectionString = "Server=127.0.0.1;Port=3386;Database=event;User=root;Password=Clang;";
        public RecoverPassword()
        {
            InitializeComponent();
        }

        private void RecoverPassword_Load(object sender, EventArgs e)
        {

        }

        private void btnRecoverPassword_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text; // Assuming you want to recover based on the login username

            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                PerformPasswordRecovery(username, conn);
            }
        }
       

        private void PerformPasswordRecovery(string username, MySqlConnection connection)
        {
            try
            {
                string recoverySql = "SELECT password FROM users WHERE username = @username";
                MySqlCommand recoveryCmd = new MySqlCommand(recoverySql, connection);
                recoveryCmd.Parameters.AddWithValue("@username", username);

                object result = recoveryCmd.ExecuteScalar();

                if (result != null)
                {
                    MessageBox.Show($"Your password is: {result.ToString()}", "Password Recovery", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Password retrieval failed", "Password Recovery", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    
                    {
                        Application.Exit();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error recovering password: {ex.Message}");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }



}

