using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleCountdown
{
    public partial class ChangeSettings : Form
    {
        Countdown parentForm;
        public ChangeSettings(Countdown parent)
        {
            InitializeComponent();
            parentForm = parent;

            chkAutoSync.Checked = Properties.Settings.Default.AutoSynchronize;
            tbSyncInterval.Text = Properties.Settings.Default.SynchronizeIntervalInSeconds.ToString();
            chkSendEmail.Checked = Properties.Settings.Default.SendNotificationEmailWhenComplete;
            tbMailTo.Text = Properties.Settings.Default.EmailToAddress;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int parsed;
            if (int.TryParse(tbSyncInterval.Text, out parsed) == false)
            {
                MessageBox.Show("Synchronization Interval should be written as seconds. It should be a number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if(parsed <= 0)
            {
                chkAutoSync.Checked = false;
            }
            Properties.Settings.Default.AutoSynchronize = chkAutoSync.Checked;
            Properties.Settings.Default.SynchronizeIntervalInSeconds = parsed;

            if (string.IsNullOrEmpty(tbMailTo.Text.Trim()))
            {
                chkSendEmail.Checked = false;
            }
            Properties.Settings.Default.SendNotificationEmailWhenComplete = chkSendEmail.Checked;
            Properties.Settings.Default.EmailToAddress = tbMailTo.Text.Trim();

            Properties.Settings.Default.Save();

            parentForm.TriggerSettingsChanged();

            this.Close();
        }

        private void lblSendMail_Click(object sender, EventArgs e)
        {
            chkSendEmail.Checked = !chkSendEmail.Checked;
        }

        private void lblSyncInterval_Click(object sender, EventArgs e)
        {
            tbSyncInterval.Focus();
        }
    }
}
