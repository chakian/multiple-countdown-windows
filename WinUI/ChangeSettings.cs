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

            tbSyncInterval.Text = Properties.Settings.Default.SynchronizeIntervalInSeconds.ToString();
            chkSendEmail.Checked = Properties.Settings.Default.SendNotificationEmailWhenComplete;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            tbSyncInterval.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            chkSendEmail.Checked = !chkSendEmail.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int parsed;
            if(int.TryParse(tbSyncInterval.Text, out parsed) == false)
            {
                MessageBox.Show("Synchronization Interval should be written as seconds. It should be a number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Properties.Settings.Default.SynchronizeIntervalInSeconds = parsed;

            Properties.Settings.Default.SendNotificationEmailWhenComplete = chkSendEmail.Checked;

            Properties.Settings.Default.Save();

            parentForm.TriggerSettingsChanged();

            this.Close();
        }
    }
}
