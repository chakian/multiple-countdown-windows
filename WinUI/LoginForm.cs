using System;
using System.Windows.Forms;

namespace MultipleCountdown
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Countdown owner = (Countdown)this.Owner;
            if (owner.DoLogin(txtUsername.Text, txtPassword.Text))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong credentials");
                //TODO: Error display
            }
        }

        public bool DoRegister(string username, string email, string password)
        {
            Countdown owner = (Countdown)this.Owner;
            if (owner.DoRegister(username, email, password))
            {
                this.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog(this);
        }
    }
}
