namespace MultipleCountdown
{
    partial class ucCountdown
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbHour = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbMinute = new System.Windows.Forms.TextBox();
            this.tbSecond = new System.Windows.Forms.TextBox();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.tbDay = new System.Windows.Forms.TextBox();
            this.btnChangeRemainingTime = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.Location = new System.Drawing.Point(4, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(529, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbHour
            // 
            this.tbHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHour.Location = new System.Drawing.Point(88, 37);
            this.tbHour.Name = "tbHour";
            this.tbHour.Size = new System.Drawing.Size(58, 26);
            this.tbHour.TabIndex = 1;
            this.tbHour.Text = "12";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbMinute
            // 
            this.tbMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMinute.Location = new System.Drawing.Point(164, 37);
            this.tbMinute.Name = "tbMinute";
            this.tbMinute.Size = new System.Drawing.Size(58, 26);
            this.tbMinute.TabIndex = 2;
            this.tbMinute.Text = "12";
            // 
            // tbSecond
            // 
            this.tbSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSecond.Location = new System.Drawing.Point(245, 37);
            this.tbSecond.Name = "tbSecond";
            this.tbSecond.Size = new System.Drawing.Size(58, 26);
            this.tbSecond.TabIndex = 3;
            this.tbSecond.Text = "12";
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(323, 40);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(123, 23);
            this.btnStartStop.TabIndex = 4;
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(458, 40);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(9, 74);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(55, 13);
            this.lblEndTime.TabIndex = 6;
            this.lblEndTime.Text = "End Time:";
            // 
            // tbDay
            // 
            this.tbDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDay.Location = new System.Drawing.Point(9, 37);
            this.tbDay.Name = "tbDay";
            this.tbDay.Size = new System.Drawing.Size(58, 26);
            this.tbDay.TabIndex = 0;
            this.tbDay.Text = "12";
            // 
            // btnChangeRemainingTime
            // 
            this.btnChangeRemainingTime.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnChangeRemainingTime.Location = new System.Drawing.Point(323, 65);
            this.btnChangeRemainingTime.Name = "btnChangeRemainingTime";
            this.btnChangeRemainingTime.Size = new System.Drawing.Size(204, 24);
            this.btnChangeRemainingTime.TabIndex = 7;
            this.btnChangeRemainingTime.Text = "Change remaining time";
            this.btnChangeRemainingTime.UseVisualStyleBackColor = true;
            this.btnChangeRemainingTime.Click += new System.EventHandler(this.btnChangeRemainingTime_Click);
            // 
            // ucCountdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.btnChangeRemainingTime);
            this.Controls.Add(this.tbDay);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.tbSecond);
            this.Controls.Add(this.tbMinute);
            this.Controls.Add(this.tbHour);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucCountdown";
            this.Size = new System.Drawing.Size(530, 90);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbHour;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbMinute;
        private System.Windows.Forms.TextBox tbSecond;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.TextBox tbDay;
        private System.Windows.Forms.Button btnChangeRemainingTime;
    }
}
