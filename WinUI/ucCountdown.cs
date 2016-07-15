using System;
using System.Windows.Forms;
using System.IO;

namespace MultipleCountdown
{
    public partial class ucCountdown : UserControl
    {
        public Guid ControlGuid { get; set; }

        public BaseCountdownStructure CountdownEssentials { get; set; }
        
        public ucCountdown()
        {
            InitializeComponent();

            btnStartStop.Text = "Start";
            lblEndTime.Text = string.Empty;
        }
        public ucCountdown(BaseCountdownStructure countdownEssentials)
            : this()
        {
            CountdownEssentials = countdownEssentials;
            SetTextBoxValuesFromSeconds();
            lblTitle.Text = CountdownEssentials.Title;
        }

        private void SetTextBoxValuesFromSeconds()
        {
            decimal Days = CountdownEssentials.Days;
            decimal Hours = CountdownEssentials.Hours;
            decimal Minutes = CountdownEssentials.Minutes;
            decimal Seconds = CountdownEssentials.Seconds;

            if (Days == 0) tbDay.Text = string.Empty;
            else tbDay.Text = Days.ToString();

            if(Hours == 0 && Days == 0) tbHour.Text = string.Empty;
            else tbHour.Text = Hours.ToString();

            if (Minutes == 0 && Hours == 0 && Days == 0) tbMinute.Text = string.Empty;
            else tbMinute.Text = Minutes.ToString();

            if (Seconds == 0 && Minutes == 0 && Hours == 0 && Days == 0) tbSecond.Text = string.Empty;
            else tbSecond.Text = Seconds.ToString();
        }

        private decimal GetSecondsFromTextBoxes()
        {
            decimal day, hour, minute, second;
            if (decimal.TryParse(tbDay.Text.Trim(), out day) == false) day = 0;
            if (decimal.TryParse(tbHour.Text.Trim(), out hour) == false) hour = 0;
            if (decimal.TryParse(tbMinute.Text.Trim(), out minute) == false) minute = 0;
            if (decimal.TryParse(tbSecond.Text.Trim(), out second) == false) second = 0;
            return (day * 24 * 60 * 60) + (hour * 60 * 60) + (minute * 60) + (second);
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            switchTimer();
        }

        private void toggleTextboxEditable(bool editable)
        {
            tbDay.Enabled = editable;
            tbHour.Enabled = editable;
            tbMinute.Enabled = editable;
            tbSecond.Enabled = editable;
        }

        void switchTimer()
        {
            if (timer1.Enabled)
            {
                //stop
                CountdownEssentials.IsTicking = false;
                timer1.Enabled = false;
                btnStartStop.Text = "Start";
                lblEndTime.Text = string.Empty;
                toggleTextboxEditable(true);
            }
            else
            {
                //start
                CountdownEssentials.IsTicking = true;
                CountdownEssentials.TotalSeconds = GetSecondsFromTextBoxes();
                timer1.Enabled = true;
                btnStartStop.Text = "Stop";
                DateTime endTime = DateTime.Now.AddSeconds((double)CountdownEssentials.TotalSeconds);
                lblEndTime.Text = string.Format("End Time: {0}", endTime.ToString("dd/MM/yyyy HH:mm:ss"));
                toggleTextboxEditable(false);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ((Countdown)Parent.Parent).UserControlClosed(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CountdownEssentials.TickingSeconds > 0)
            {
                CountdownEssentials.TickingSeconds--;
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
    }
}
