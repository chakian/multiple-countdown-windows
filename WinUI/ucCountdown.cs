using System;
using System.Windows.Forms;
using System.IO;
using Business.Entities;

namespace MultipleCountdown
{
    public partial class ucCountdown : UserControl
    {
        public CountdownStructure CountdownEssentials { get; private set; }
        public void SetCountdownEssentials(CountdownStructure cd)
        {
            CountdownEssentials = cd;
            InitializeCountdown();
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
            double day, hour, minute, second;
            if (double.TryParse(tbDay.Text.Trim(), out day) == false) day = 0;
            if (double.TryParse(tbHour.Text.Trim(), out hour) == false) hour = 0;
            if (double.TryParse(tbMinute.Text.Trim(), out minute) == false) minute = 0;
            if (double.TryParse(tbSecond.Text.Trim(), out second) == false) second = 0;
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
                SetTextBoxValuesFromSeconds();
            }
            else
            {
                switchTimer();

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

        void startSyncInParent()
        {
            CountdownEssentials.UpdateTimeUtc = DateTime.UtcNow;
            //trigger synchronization
            if (Parent != null && Parent.Parent != null)
            {
                ((Countdown)Parent.Parent).StartSynchronization();
            }
        }
    }
}
