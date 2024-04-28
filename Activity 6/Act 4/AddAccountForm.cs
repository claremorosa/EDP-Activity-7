using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Act_4
{
    public partial class AddAccountForm : Form
    {
        public int UserId => int.Parse(txtUserId.Text);
        public string Username => txtUsername.Text;
        public string Email => txtEmail.Text;
        public string Password => txtPassword.Text;

        public AddAccountForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Account added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // Close the AddAccountForm after showing the success message
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the AddAccountForm if the user clicks cancel
        }
    }
}
