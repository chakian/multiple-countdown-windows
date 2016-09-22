using System;
using System.Windows.Forms;
using System.IO;
using Business.Entities;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Threading;

namespace MultipleCountdown
{
    public partial class ucCountdown : UserControl
    {
        int UpdateRemainingTimeInterval;
        DateTime RemainingTimeLastUpdated;
        bool sendNotificationEmailWhenComplete;

        public CountdownStructure CountdownEssentials { get; private set; }

        public void SetCountdownEssentials(CountdownStructure cd)
        {
            CountdownEssentials = cd;
            InitializeCountdown();
        }

        public void ReadSettingsValues()
        {
            UpdateRemainingTimeInterval = Properties.Settings.Default.UpdateRemainingTimeIntervalInSeconds;
            sendNotificationEmailWhenComplete = Properties.Settings.Default.SendNotificationEmailWhenComplete;
        }
        
        public ucCountdown()
        {
            InitializeComponent();

            btnStartStop.Text = "Start";
            lblEndTime.Text = string.Empty;
        }
        public ucCountdown(CountdownStructure countdownEssentials)
            : this()
        {
            SetCountdownEssentials(countdownEssentials);
        }

        void InitializeCountdown()
        {
            lblTitle.Text = CountdownEssentials.Title;
            SetTextBoxValuesFromSeconds();

            if (CountdownEssentials.IsInProgress)
            {
                startTimer();
            }
        }

        private void SetTextBoxValuesFromSeconds()
        {
            double Days = CountdownEssentials.remainingTime.Days;
            double Hours = CountdownEssentials.remainingTime.Hours;
            double Minutes = CountdownEssentials.remainingTime.Minutes;
            double Seconds = CountdownEssentials.remainingTime.Seconds;

            if (Days == 0) tbDay.Text = string.Empty;
            else tbDay.Text = Days.ToString();

            if(Hours == 0 && Days == 0) tbHour.Text = string.Empty;
            else tbHour.Text = Hours.ToString();

            if (Minutes == 0 && Hours == 0 && Days == 0) tbMinute.Text = string.Empty;
            else tbMinute.Text = Minutes.ToString();

            if (Seconds == 0 && Minutes == 0 && Hours == 0 && Days == 0) tbSecond.Text = string.Empty;
            else tbSecond.Text = Seconds.ToString();
        }

        private double GetSecondsFromTextBoxes()
        {
            int day, hour, minute, second;
            if (int.TryParse(tbDay.Text.Trim(), out day) == false) day = 0;
            if (int.TryParse(tbHour.Text.Trim(), out hour) == false) hour = 0;
            if (int.TryParse(tbMinute.Text.Trim(), out minute) == false) minute = 0;
            if (int.TryParse(tbSecond.Text.Trim(), out second) == false) second = 0;
            return GetTotalSeconds(day, hour, minute, second);
        }
        private double GetTotalSeconds(int day, int hour, int minute, int second)
        {
            return (day * 24 * 60 * 60) + (hour * 60 * 60) + (minute * 60) + (second);
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            switchTimer();
            startSyncInParent();
        }

        private void toggleTextboxEditable(bool editable)
        {
            tbDay.Enabled = editable;
            tbHour.Enabled = editable;
            tbMinute.Enabled = editable;
            tbSecond.Enabled = editable;
        }

        void startTimer()
        {
            CountdownEssentials.IsInProgress = true;
            CountdownEssentials.SetTotalSeconds(GetSecondsFromTextBoxes());
            timer1.Enabled = true;
            RemainingTimeLastUpdated = DateTime.Now;
            btnStartStop.Text = "Stop";
            lblEndTime.Text = string.Format("End Time: {0}", CountdownEssentials.EndTimeUtc.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss"));
            toggleTextboxEditable(false);
        }
        void stopTimer()
        {
            CountdownEssentials.IsInProgress = false;
            timer1.Enabled = false;
            btnStartStop.Text = "Start";
            lblEndTime.Text = string.Empty;
            toggleTextboxEditable(true);
        }

        void switchTimer()
        {
            if (timer1.Enabled)
            {
                stopTimer();
            }
            else
            {
                startTimer();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CountdownEssentials.IsDeleted = true;

            ((Countdown)Parent.Parent).UserControlClosed(this);

            startSyncInParent();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CountdownEssentials.remainingTime.TickingSeconds > 0)
            {
                CountdownEssentials.remainingTime.TickingSeconds--;
                if((DateTime.Now - RemainingTimeLastUpdated).TotalSeconds >= UpdateRemainingTimeInterval)
                {
                    CountdownEssentials.UpdateRemainingTime();
                    RemainingTimeLastUpdated = DateTime.Now;
                }
                SetTextBoxValuesFromSeconds();
            }
            else
            {
                switchTimer();

                if (sendNotificationEmailWhenComplete)
                {
                    SendEmail();
                }

                try
                {
                    string filePath = Path.Combine(Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf("\\")), "notification_sound.mp3");

                    NAudio.Wave.IWavePlayer waveOutDevice = new NAudio.Wave.WaveOut();
                    NAudio.Wave.AudioFileReader audioFileReader = new NAudio.Wave.AudioFileReader(filePath);

                    waveOutDevice.Init(audioFileReader);
                    waveOutDevice.Play();
                }catch(Exception ex)
                {
                    //TODO: Log it
                }

                AlertForm alert = new AlertForm(CountdownEssentials.Title);
                alert.Top = 0;
                alert.Left = 0;
                alert.TopMost = true;
                alert.ShowDialog();
            }
        }

        async void SendEmail()
        {
            string smtpAddress = Properties.Settings.Default.EmailSmtpServer;
            int portNumber = Properties.Settings.Default.EmailSmtpPortNumber;
            bool enableSSL = Properties.Settings.Default.EmailSmtpRequiresSSL;

            string emailFrom = Properties.Settings.Default.EmailFromAddress;
            string password = Properties.Settings.Default.EmailFromPassword;
            string emailTo = Properties.Settings.Default.EmailToAddress;
            string subject = string.Format("Countdown Finished - {0}", CountdownEssentials.Title);
            string body = string.Format("Your countdown with title '{0}' has finished. <br/>End time: {1}", CountdownEssentials.Title, CountdownEssentials.EndTimeUtc.ToLocalTime().ToString("dd MMMM yyyy - HH:mm:ss"));

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
                    mail.Subject = subject;
                    mail.Body = body;
                    // Can set to false, if you are sending pure text.
                    mail.IsBodyHtml = true;

                    //mail.Attachments.Add(new Attachment("C:\\SomeFile.txt"));
                    //mail.Attachments.Add(new Attachment("C:\\SomeZip.zip"));

                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        bool result = await sendMailAsync(smtp, mail);
                        if(result == true)
                        {
                            //TODO: Probably we'll do nothing here
                        }else
                        {
                            //TODO: There was an error but we'll probably just do nothing here too
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                //TODO: Logging logging
            }
        }

        async Task<bool> sendMailAsync(SmtpClient smtp, MailMessage mail)
        {
            try
            {
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                //TODO: Logging logging
                return false;
            }
        }

        void startSyncInParent()
        {
            CountdownEssentials.UpdatedNow();
            //trigger synchronization
            if (Parent != null && Parent.Parent != null)
            {
                ((Countdown)Parent.Parent).StartAutoSync();
            }
        }

        private void btnChangeRemainingTime_Click(object sender, EventArgs e)
        {
            AlterCountdownTime alterForm = new AlterCountdownTime(this);

            alterForm.ShowDialog();
        }
        public void ChangeTime(int day, int hour, int minute, int second)
        {
            double totalSeconds = GetTotalSeconds(day, hour, minute, second);
            CountdownEssentials.SetTotalSeconds(totalSeconds);

            CountdownEssentials.UpdatedNow();
        }
        public void AddTime(int day, int hour, int minute, int second)
        {
            double totalSeconds = GetTotalSeconds(day, hour, minute, second);
            CountdownEssentials.SetTotalSeconds(CountdownEssentials.remainingTime.TickingSeconds + totalSeconds);

            CountdownEssentials.UpdatedNow();
        }
        public void ReduceTime(int day, int hour, int minute, int second)
        {
            double totalSeconds = GetTotalSeconds(day, hour, minute, second);
            CountdownEssentials.SetTotalSeconds(CountdownEssentials.remainingTime.TickingSeconds - totalSeconds);

            CountdownEssentials.UpdatedNow();
        }
    }
}
