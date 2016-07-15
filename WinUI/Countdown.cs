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
        List<ucCountdown> countdownList;
        //BaseCountdown countdownValues;

        public Countdown()
        {
            InitializeComponent();
            countdownList = new List<ucCountdown>();

            //countdownValues = new TornCountdown();
            //cmbCountdownName.Items.AddRange(countdownValues.CountdownCounts.Select(q=>q.Title).ToArray<object>());

            tmrProgressState.Enabled = true;
        }

        private void btnAddCountdown_Click(object sender, EventArgs e)
        {
            ucCountdown uc = new ucCountdown(new BaseCountdownStructure() { Title = cmbCountdownName.Text, TotalSeconds = 0 });
            uc.ControlGuid = Guid.NewGuid();
            //uc.CountdownEssentials = countdownValues.GetCountdownByTitle(cmbCountdownName.Text);
            
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
