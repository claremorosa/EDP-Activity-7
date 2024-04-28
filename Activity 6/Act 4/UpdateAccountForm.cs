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
    public partial class UpdateAccountForm : Form
    {

        public int UserId => int.Parse(txtUserId.Text);
        public string Username => txtUsername.Text;
        public string Email => txtEmail.Text;
        public string Password => txtPassword.Text;

        public UpdateAccountForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Account updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // Close the UpdateAccountForm after showing the success message
                          // Set the DialogResult to OK before closing the form
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close(); // Close the UpdateAccountForm if the user clicks cancel
        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
