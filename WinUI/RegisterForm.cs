using System;
using System.Windows.Forms;

namespace MultipleCountdown
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Usrename empty");
                return;
            }

            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Email empty");
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Password empty");
                return;
            }
            
            LoginForm owner = (LoginForm)this.Owner;
            if (owner.DoRegister(txtUsername.Text, txtEmail.Text, txtPassword.Text))
            {
                this.Close();
            }
            else
            {
                //TODO: Show nice error messages
                MessageBox.Show("Something wrong");
            }
        }
    }
}
