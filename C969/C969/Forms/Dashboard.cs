using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            Customers customersForm = new Customers();
            customersForm.Show();
        }

        private void btnViewCalendar_Click(object sender, EventArgs e)
        {
            Calendar calendarForm = new Calendar();
            calendarForm.Show();
        }

        private void btnGenerateReports_Click(object sender, EventArgs e)
        {
            Reports reportsForm = new Reports();
            reportsForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();

            Login loginForm = new Login();
            loginForm.Show();
        }
    }
}
