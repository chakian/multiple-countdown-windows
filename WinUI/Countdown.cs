using Business.DataOperations;
using Business.Entities;
using Business.Helpers;
using Business.LogicalOperations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//TODO: Learn how to use the taskbarprogress thing
//using System.Windows.Shell;

namespace MultipleCountdown
{
    public partial class Countdown : Form
    {
        enum MessageTypes { Error, Information, Warning }

        int _loggedInUser = 0;
        bool IsSynchronizing = false;
        DateTime LastSynchronizeTime = DateTime.Now;
        int SynchronizeIntervalInSeconds;
        List<ucCountdown> countdownList;
        DateTime messageDisplayedTime = DateTime.MinValue;
        int minimumMessageDisplayInSeconds = 1;

        public int LoggedInUser
        {
            get
            {
                return _loggedInUser;
            }
            set
            {
                _loggedInUser = value;
                countdownList.ForEach(q => q.CountdownEssentials.UserID = _loggedInUser);
            }
        }
        public bool isLoggedIn
        {
            get
            {
                return LoggedInUser > 0;
            }
        }
        
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
                    LoggedInUser = ParseHelper.ToInt32(decipheredId, 0);
                    UserData userD = new UserData();
                    User currentUser = userD.GetUserByID(LoggedInUser);
                    DoLogin(currentUser.ID, currentUser.Username);
                }
            }
            
            //change menu items (login/logout) according to the user's logged in status
            DoLoginLogoutOperations();

            //TODO: Learn how to manipulate the panel's scrollbar
            //pnlCountdowns.AutoScroll = false;
            //pnlCountdowns.HorizontalScroll.Enabled = false;
            //pnlCountdowns.HorizontalScroll.Visible = false;
            //pnlCountdowns.HorizontalScroll.Maximum = 0;
            //pnlCountdowns.VerticalScroll.Enabled = true;
            //pnlCountdowns.VerticalScroll.Visible = true;
            //if(pnlCountdowns.ClientSize.Height <= pnlCountdowns.Height)
            //{
            //    pnlCountdowns.VerticalScroll.Maximum = 3;
            //}
            //pnlCountdowns.AutoScroll = true;

            TriggerSettingsChanged();
        }
        
        #region Login Logout operations
        private void DoLoginLogoutOperations()
        {
            if (isLoggedIn)
            {
                loginToolStripMenuItem.Visible = false;
                logoutToolStripMenuItem.Visible = true;
                settingsToolStripMenuItem.Visible = true;
            }
            else
            {
                loginToolStripMenuItem.Visible = true;
                logoutToolStripMenuItem.Visible = false;
                mainToolStripMenuItem.Text = "User";
                settingsToolStripMenuItem.Visible = false;
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
            LoggedInUser = userID;
            RegistryHelper.WriteRegistryNode(RegistryHelper.MCNode_UserID, EncryptionHelper.Encrypt(userID.ToString()));
            mainToolStripMenuItem.Text = "User: " + username;
            StartSynchronization();
            DoLoginLogoutOperations();
        }

        private void DoLogout()
        {
            LoggedInUser = 0;
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
        #endregion Login Logout operations

        #region Countdown User Control operations
        private void AddCountdown(string title, DateTime endTimeUtc)
        {
            CountdownStructure cdStruct = new CountdownStructure(title, endTimeUtc);
            AddCountdown(cdStruct);
        }
        
        private void AddCountdown(string title, double totalSeconds)
        {
            CountdownStructure cdStruct = new CountdownStructure(title, totalSeconds);
            AddCountdown(cdStruct);
        }

        private void AddCountdown(CountdownStructure cdStruct)
        {
            cdStruct.UserID = LoggedInUser;
            if (string.IsNullOrEmpty(cdStruct.CountdownGuid))
            {
                cdStruct.CountdownGuid = Guid.NewGuid().ToString();
            }

            ucCountdown uc = new ucCountdown(cdStruct);

            countdownList.Add(uc);
            pnlCountdowns.Controls.Add(uc);
            rearrangeControls();
        }

        private void btnAddCountdown_Click(object sender, EventArgs e)
        {
            AddCountdown(cmbCountdownName.Text, 0);
            cmbCountdownName.Text = string.Empty;
        }

        public void UserControlClosed(ucCountdown closedControl)
        {
            if (closedControl != null)
            {
                countdownList.Remove(closedControl);
            }
            RemoveCountdownFromScreen(closedControl);
        }
        void RemoveCountdownFromScreen(ucCountdown closedControl)
        {
            if (closedControl != null)
            {
                CountdownData cdata = new CountdownData();
                cdata.DeleteCountdown(closedControl.CountdownEssentials);

                closedControl.Dispose();
            }
            rearrangeControls();
        }

        private void rearrangeControls()
        {
            //TODO: Learn how to manipulate the panel's scrollbar
            //int initialScrollValue = pnlCountdowns.VerticalScroll.Value;
            pnlCountdowns.VerticalScroll.Value = 0;

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

            //TODO: Learn how to manipulate the panel's scrollbar
            //int currentMaxValue = pnlCountdowns.VerticalScroll.Maximum - pnlCountdowns.Height;
            //if (currentMaxValue <= initialScrollValue)
            //{
            //    setPanelScrollbarValue(currentMaxValue);
            //}
            //else
            //{
            //    setPanelScrollbarValue(initialScrollValue);
            //}
        }
        //TODO: Learn how to manipulate the panel's scrollbar
        //private void setPanelScrollbarValue(int value)
        //{
        //    pnlCountdowns.AutoScroll = false;
        //    pnlCountdowns.AutoScrollPosition = new System.Drawing.Point(0, value * (-1));
        //    pnlCountdowns.AutoScroll = true;
        //}

        public void StartSynchronization()
        {
            if (IsSynchronizing == false && isLoggedIn)
            {
                DisplayMessage(MessageTypes.Information, "Synchronizing...");
                IsSynchronizing = true;

                try
                {
                    List<CountdownStructure> listOnScreen = countdownList.Select(q => q.CountdownEssentials).ToList();
                    List<CountdownStructure> newListForScreen = CountdownSynchronization.Synchronize(listOnScreen, LoggedInUser);

                    //removed countdowns are removed from screen as well
                    foreach (var item in listOnScreen.ToList())
                    {
                        if(newListForScreen.Any(q=>q.Title == item.Title && q.CountdownGuid == item.CountdownGuid) == false)
                        {
                            var ucToRemove = countdownList.SingleOrDefault(q => q.CountdownEssentials.Title == item.Title && q.CountdownEssentials.CountdownGuid == item.CountdownGuid);
                            UserControlClosed(ucToRemove);
                        }
                    }

                    //newly added and updated countdowns are updated on screen
                    foreach (var item in newListForScreen)
                    {
                        var onscreen = listOnScreen.SingleOrDefault(q => q.Title == item.Title && q.CountdownGuid == item.CountdownGuid);
                        if(onscreen == null)
                        {
                            AddCountdown(item);
                        }
                        else
                        {
                            var compareStatus = onscreen.Compare(item);
                            if(compareStatus == CountdownStructure.EqualityStatus.SecondIsNew)
                            {
                                var ucToUpdate = countdownList.SingleOrDefault(q => q.CountdownEssentials.Title == item.Title && q.CountdownEssentials.CountdownGuid == item.CountdownGuid);
                                if(ucToUpdate != null)
                                {
                                    ucToUpdate.SetCountdownEssentials(item);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //TODO: Log
                }
                finally
                {
                    IsSynchronizing = false;
                    LastSynchronizeTime = DateTime.Now;
                    HideMessage();
                }
            }
        }
        #endregion Countdown User Control operations
        
        private void DisplayMessage(MessageTypes messageType, string messageText)
        {
            switch (messageType)
            {
                case MessageTypes.Error:
                    lblMessage.BackColor = Color.Red;
                    break;
                case MessageTypes.Information:
                    lblMessage.BackColor = Color.LightBlue;
                    break;
                case MessageTypes.Warning:
                    lblMessage.BackColor = Color.Yellow;
                    break;
                default:
                    break;
            }
            changeMessageLabelText(messageText);
            messageDisplayedTime = DateTime.Now;
            toggleMessageLabel(true);
        }
        private void HideMessage()
        {
            if((DateTime.Now - messageDisplayedTime).Seconds < minimumMessageDisplayInSeconds)
            {
                Thread hider = new Thread(hideMessageAsync);
                hider.Start();
            }else
            {
                toggleMessageLabel(false);
            }
        }
        private void hideMessageAsync()
        {
            double waitTime = minimumMessageDisplayInSeconds - ((DateTime.Now - messageDisplayedTime).TotalSeconds);
            Thread.Sleep((int)waitTime);
            HideMessage();
        }
        delegate void changeMessageLabelTextCallback(string text);
        private void changeMessageLabelText(string text)
        {
            if (lblMessage.InvokeRequired)
            {
                changeMessageLabelTextCallback d = new changeMessageLabelTextCallback(changeMessageLabelText);
                this.Invoke(d, new object[] { text });
            }else
            {
                lblMessage.Text = text;
            }
        }
        delegate void toggleMessageLabelCallback(bool visible);
        private void toggleMessageLabel(bool visible)
        {
            if (lblMessage.InvokeRequired)
            {
                toggleMessageLabelCallback d = new toggleMessageLabelCallback(toggleMessageLabel);
                this.Invoke(d, new object[] { visible });
            }
            else
            {
                lblMessage.Visible = visible;
            }
        }

        private void tmrProgressState_Tick(object sender, EventArgs e)
        {
            //get earliest countdown
            ucCountdown earliestCountdown = countdownList.Where(q => q.CountdownEssentials.IsInProgress == true).OrderBy(q => q.CountdownEssentials.remainingTime.TickingSeconds).FirstOrDefault();
            if(earliestCountdown != null)
            {
                CountdownStructure _struct = earliestCountdown.CountdownEssentials;
                string _title = "";
                if (_struct.remainingTime.Days > 0) _title += _struct.remainingTime.Days.ToString() + "d. ";
                if (_struct.remainingTime.Hours > 0) _title += _struct.remainingTime.Hours.ToString() + "h. ";
                _title += string.Format("{0}:{1}", _struct.remainingTime.Minutes, _struct.remainingTime.Seconds);

                this.Text = _title;
            }
            else
            {
                this.Text += "";
            }

            //synchronize data
            if((DateTime.Now - LastSynchronizeTime).TotalSeconds >= SynchronizeIntervalInSeconds)
            {
                StartSynchronization();
            }
            
            //Taskbar.ProgressBar
            //this.
            //System.Windows.Forms.VisualStyles.VisualStyleElement.Taskbar taskbar = this.task
        }

        private void synchronizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartSynchronization();
        }

        private void cmbCountdownName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnAddCountdown_Click(sender, e);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSettings settings = new ChangeSettings(this);
            settings.ShowDialog(this);
        }

        public void TriggerSettingsChanged()
        {
            SynchronizeIntervalInSeconds = Properties.Settings.Default.SynchronizeIntervalInSeconds;

            countdownList.ForEach(c => c.ReadSettingsValues());
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
