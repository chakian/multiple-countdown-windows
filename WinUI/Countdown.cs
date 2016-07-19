﻿using Business.DataOperations;
using Business.Entities;
using Business.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
//TODO: Learn how to use the taskbarprogress thing
//using System.Windows.Shell;

namespace MultipleCountdown
{
    public partial class Countdown : Form
    {
        public int loggedInUser = 0;
        public bool isLoggedIn
        {
            get
            {
                return loggedInUser > 0;
            }
        }
        List<ucCountdown> countdownList;

        public Countdown()
        {
            InitializeComponent();
            countdownList = new List<ucCountdown>();
            
            tmrProgressState.Enabled = true;

            //Get logged in user id
            string encryptedId = RegistryHelper.ReadRegistryNode(RegistryHelper.MCNode_UserID);
            if(string.IsNullOrEmpty(encryptedId) == false)
            {
                string decipheredId = string.Empty;
                try
                {
                    decipheredId = EncryptionHelper.Decrypt(encryptedId);
                }catch{}

                if(string.IsNullOrEmpty(decipheredId) == false)
                {
                    loggedInUser = ParseHelper.ToInt32(decipheredId, 0);
                    UserData userD = new UserData();
                    User currentUser = userD.GetUserByID(loggedInUser);
                    DoLogin(currentUser.ID, currentUser.Username);
                }
            }

            //if the user is logged in, get saved countdowns of user
            if (isLoggedIn)
            {
                CountdownData cdData = new CountdownData();
                var cds = cdData.GetCountdownsOfUser(loggedInUser);
                //TODO: Do something with these...
            }
            
            //change menu items (login/logout) according to the user's logged in status
            DoLoginLogoutOperations();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog(this);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to log out?", "Logout", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                DoLogout();
        }
        #region Login Logout operations
        private void DoLoginLogoutOperations()
        {
            if (isLoggedIn)
            {
                loginToolStripMenuItem.Visible = false;
                logoutToolStripMenuItem.Visible = true;
            }
            else
            {
                loginToolStripMenuItem.Visible = true;
                logoutToolStripMenuItem.Visible = false;
                mainToolStripMenuItem.Text = "User";
            }
        }

        public bool DoLogin(string username, string password)
        {
            UserData userData = new UserData();

            var user = userData.GetUserByUsernameAndPassword(username, password);
            
            if (user != null)
            {
                DoLogin(user.ID, user.Username);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DoLogin(int userID, string username)
        {
            loggedInUser = userID;
            RegistryHelper.WriteRegistryNode(RegistryHelper.MCNode_UserID, EncryptionHelper.Encrypt(userID.ToString()));
            mainToolStripMenuItem.Text = "User: " + username;
            DoLoginLogoutOperations();
        }

        private void DoLogout()
        {
            loggedInUser = 0;
            RegistryHelper.DeleteRegistryNode(RegistryHelper.MCNode_UserID);
            DoLoginLogoutOperations();
        }

        public bool DoRegister(string username, string email, string password)
        {
            UserData userData = new UserData();

            var user = userData.CreateNewUser(username, email, password);
            if (user != null)
            {
                DoLogin(user.ID, user.Username);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Login Logout operations

        private void btnAddCountdown_Click(object sender, EventArgs e)
        {
            ucCountdown uc = new ucCountdown(new BaseCountdownStructure() { Title = cmbCountdownName.Text, TotalSeconds = 0 });
            uc.ControlGuid = Guid.NewGuid();
            
            countdownList.Add(uc);
            pnlCountdowns.Controls.Add(uc);
            rearrangeControls();
        }

        public void UserControlClosed(ucCountdown closedControl)
        {
            closedControl.Dispose();
            var wanted = countdownList.FirstOrDefault(q => q.ControlGuid == closedControl.ControlGuid);
            if (wanted != null)
            {
                countdownList.Remove(wanted);
            }
            rearrangeControls();
        }

        private void rearrangeControls()
        {
            int height = 90;

            for (int i = 0; i < countdownList.Count; i++)
            {
                if (i == 0)
                {
                    countdownList[i].Top = 10;
                }
                else
                {
                    countdownList[i].Top = countdownList[i - 1].Top + height + 10;
                }
            }
        }

        private void tmrProgressState_Tick(object sender, EventArgs e)
        {
            //get earliest countdown
            ucCountdown earliestCountdown = countdownList.Where(q => q.CountdownEssentials.IsTicking == true).OrderBy(q => q.CountdownEssentials.TickingSeconds).FirstOrDefault();
            if(earliestCountdown != null)
            {
                BaseCountdownStructure _struct = earliestCountdown.CountdownEssentials;
                string _title = "";
                if (_struct.Days > 0) _title += _struct.Days.ToString() + "d. ";
                if (_struct.Hours > 0) _title += _struct.Hours.ToString() + "h. ";
                _title += string.Format("{0}:{1}", _struct.Minutes, _struct.Seconds);

                this.Text = _title;
            }
            else
            {
                this.Text += "";
            }
            
            //Taskbar.ProgressBar
            //this.
            //System.Windows.Forms.VisualStyles.VisualStyleElement.Taskbar taskbar = this.task
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Countdown());
        }
    }
}
