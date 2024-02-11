using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using C969.Data;
using C969.Resources;
using Google.Protobuf;

namespace C969
{
    public partial class Login : Form
    {
        public Login()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentUICulture;
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");

            InitializeComponent();
            AttachEventHandlers();

            SetLocalizedText();
        }

        private void AttachEventHandlers()
        {
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        private void SetLocalizedText()
        {
            lblUsername.Text = Messages.UsernameLabel; 
            lblPassword.Text = Messages.PasswordLabel;
            btnLogin.Text = Messages.LoginButton;
            btnCancel.Text = Messages.CancelButton;
            this.Text = Messages.LoginFormTitle;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text; 

            if (DatabaseHelper.ValidateUser(username, password))
            {
                Dashboard dashboardForm = new Dashboard();
                LogUserActivity(username);
                dashboardForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(Resources.Messages.LoginErrorMessage, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void LogUserActivity(string username)
        {
            string filePath = "UserActivityLog.txt";
            string logEntry = $"{DateTime.Now}: {username} logged in.";

            using (StreamWriter file = new StreamWriter(filePath, append: true))
            {
                file.WriteLine(logEntry);
            }
        }

    }
}