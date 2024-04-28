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
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOpenReport_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report report = new Report(); // Pass report content or generate it as needed
            report.ShowDialog();
        }
    }
}
