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
    public partial class AlterCountdownTime : Form
    {
        ucCountdown parentCountdown;
        public AlterCountdownTime(ucCountdown parent)
        {
            InitializeComponent();
            
            parentCountdown = parent;
            setTextboxesToRemainingTime();
        }



        private void tabAlterCountdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabAlterCountdown.SelectedTab.Name)
            {
                case "tabChangeTime":
                    setTextboxesToRemainingTime();
                    break;
                case "tabAddTime":
                    emptyTextboxes();
                    break;
                case "tabReduceTime":
                    emptyTextboxes();
                    break;
                default:
                    break;
            }
        }

        void setTextboxesToRemainingTime()
        {
            tbDay.Text = parentCountdown.CountdownEssentials.remainingTime.Days.ToString();
            tbHour.Text = parentCountdown.CountdownEssentials.remainingTime.Hours.ToString();
            tbMinute.Text = parentCountdown.CountdownEssentials.remainingTime.Minutes.ToString();
            tbSecond.Text = parentCountdown.CountdownEssentials.remainingTime.Seconds.ToString();
        }
        void emptyTextboxes()
        {
            tbDay.Text = string.Empty;
            tbHour.Text = string.Empty;
            tbMinute.Text = string.Empty;
            tbSecond.Text = string.Empty;
        }
        void getValuesFromTextboxes(out int day, out int hour, out int minute, out int second)
        {
            if (int.TryParse(tbDay.Text.Trim(), out day) == false) day = 0;
            if (int.TryParse(tbHour.Text.Trim(), out hour) == false) hour = 0;
            if (int.TryParse(tbMinute.Text.Trim(), out minute) == false) minute = 0;
            if (int.TryParse(tbSecond.Text.Trim(), out second) == false) second = 0;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            int day, hour, minute, second;
            getValuesFromTextboxes(out day, out hour, out minute, out second);
            parentCountdown.ChangeTime(day, hour, minute, second);
            this.Close();
        }
        
        private void btnAddTime_Click(object sender, EventArgs e)
        {
            int day, hour, minute, second;
            getValuesFromTextboxes(out day, out hour, out minute, out second);
            parentCountdown.AddTime(day, hour, minute, second);
            this.Close();
        }

        private void btnReduceTime_Click(object sender, EventArgs e)
        {
            int day, hour, minute, second;
            getValuesFromTextboxes(out day, out hour, out minute, out second);
            parentCountdown.ReduceTime(day, hour, minute, second);
            this.Close();
        }
    }
}
