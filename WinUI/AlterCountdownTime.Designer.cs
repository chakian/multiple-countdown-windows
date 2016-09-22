namespace MultipleCountdown
{
    partial class AlterCountdownTime
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabAlterCountdown = new System.Windows.Forms.TabControl();
            this.tabChangeTime = new System.Windows.Forms.TabPage();
            this.btnReset = new System.Windows.Forms.Button();
            this.tabAddTime = new System.Windows.Forms.TabPage();
            this.btnAddTime = new System.Windows.Forms.Button();
            this.tabReduceTime = new System.Windows.Forms.TabPage();
            this.btnReduceTime = new System.Windows.Forms.Button();
            this.tbSecond = new System.Windows.Forms.TextBox();
            this.tbMinute = new System.Windows.Forms.TextBox();
            this.tbHour = new System.Windows.Forms.TextBox();
            this.tbDay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabAlterCountdown.SuspendLayout();
            this.tabChangeTime.SuspendLayout();
            this.tabAddTime.SuspendLayout();
            this.tabReduceTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabAlterCountdown
            // 
            this.tabAlterCountdown.Controls.Add(this.tabChangeTime);
            this.tabAlterCountdown.Controls.Add(this.tabAddTime);
            this.tabAlterCountdown.Controls.Add(this.tabReduceTime);
            this.tabAlterCountdown.Location = new System.Drawing.Point(12, 12);
            this.tabAlterCountdown.Name = "tabAlterCountdown";
            this.tabAlterCountdown.SelectedIndex = 0;
            this.tabAlterCountdown.Size = new System.Drawing.Size(294, 65);
            this.tabAlterCountdown.TabIndex = 9;
            this.tabAlterCountdown.SelectedIndexChanged += new System.EventHandler(this.tabAlterCountdown_SelectedIndexChanged);
            // 
            // tabChangeTime
            // 
            this.tabChangeTime.Controls.Add(this.btnReset);
            this.tabChangeTime.Location = new System.Drawing.Point(4, 22);
            this.tabChangeTime.Name = "tabChangeTime";
            this.tabChangeTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabChangeTime.Size = new System.Drawing.Size(286, 39);
            this.tabChangeTime.TabIndex = 0;
            this.tabChangeTime.Text = "Change Time";
            this.tabChangeTime.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(10, 6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(270, 23);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset Remaining Time";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tabAddTime
            // 
            this.tabAddTime.Controls.Add(this.btnAddTime);
            this.tabAddTime.Location = new System.Drawing.Point(4, 22);
            this.tabAddTime.Name = "tabAddTime";
            this.tabAddTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddTime.Size = new System.Drawing.Size(286, 39);
            this.tabAddTime.TabIndex = 1;
            this.tabAddTime.Text = "Add Time";
            this.tabAddTime.UseVisualStyleBackColor = true;
            // 
            // btnAddTime
            // 
            this.btnAddTime.Location = new System.Drawing.Point(8, 8);
            this.btnAddTime.Name = "btnAddTime";
            this.btnAddTime.Size = new System.Drawing.Size(270, 23);
            this.btnAddTime.TabIndex = 11;
            this.btnAddTime.Text = "Add Time";
            this.btnAddTime.UseVisualStyleBackColor = true;
            this.btnAddTime.Click += new System.EventHandler(this.btnAddTime_Click);
            // 
            // tabReduceTime
            // 
            this.tabReduceTime.Controls.Add(this.btnReduceTime);
            this.tabReduceTime.Location = new System.Drawing.Point(4, 22);
            this.tabReduceTime.Name = "tabReduceTime";
            this.tabReduceTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabReduceTime.Size = new System.Drawing.Size(286, 39);
            this.tabReduceTime.TabIndex = 2;
            this.tabReduceTime.Text = "Reduce Time";
            this.tabReduceTime.UseVisualStyleBackColor = true;
            // 
            // btnReduceTime
            // 
            this.btnReduceTime.Location = new System.Drawing.Point(8, 8);
            this.btnReduceTime.Name = "btnReduceTime";
            this.btnReduceTime.Size = new System.Drawing.Size(270, 23);
            this.btnReduceTime.TabIndex = 12;
            this.btnReduceTime.Text = "Reduce Time";
            this.btnReduceTime.UseVisualStyleBackColor = true;
            this.btnReduceTime.Click += new System.EventHandler(this.btnReduceTime_Click);
            // 
            // tbSecond
            // 
            this.tbSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSecond.Location = new System.Drawing.Point(164, 184);
            this.tbSecond.Name = "tbSecond";
            this.tbSecond.Size = new System.Drawing.Size(58, 26);
            this.tbSecond.TabIndex = 17;
            this.tbSecond.Text = "12";
            // 
            // tbMinute
            // 
            this.tbMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMinute.Location = new System.Drawing.Point(164, 153);
            this.tbMinute.Name = "tbMinute";
            this.tbMinute.Size = new System.Drawing.Size(58, 26);
            this.tbMinute.TabIndex = 16;
            this.tbMinute.Text = "12";
            // 
            // tbHour
            // 
            this.tbHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHour.Location = new System.Drawing.Point(164, 121);
            this.tbHour.Name = "tbHour";
            this.tbHour.Size = new System.Drawing.Size(58, 26);
            this.tbHour.TabIndex = 15;
            this.tbHour.Text = "12";
            // 
            // tbDay
            // 
            this.tbDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDay.Location = new System.Drawing.Point(164, 86);
            this.tbDay.Name = "tbDay";
            this.tbDay.Size = new System.Drawing.Size(58, 26);
            this.tbDay.TabIndex = 14;
            this.tbDay.Text = "12";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(79, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Seconds";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(79, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Minutes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(79, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Hours";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(79, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Days";
            // 
            // AlterCountdownTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 227);
            this.Controls.Add(this.tbSecond);
            this.Controls.Add(this.tbMinute);
            this.Controls.Add(this.tbHour);
            this.Controls.Add(this.tbDay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabAlterCountdown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlterCountdownTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alter Countdown Time";
            this.tabAlterCountdown.ResumeLayout(false);
            this.tabChangeTime.ResumeLayout(false);
            this.tabAddTime.ResumeLayout(false);
            this.tabReduceTime.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabAlterCountdown;
        private System.Windows.Forms.TabPage tabChangeTime;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TabPage tabAddTime;
        private System.Windows.Forms.TextBox tbSecond;
        private System.Windows.Forms.TextBox tbMinute;
        private System.Windows.Forms.TextBox tbHour;
        private System.Windows.Forms.TextBox tbDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddTime;
        private System.Windows.Forms.TabPage tabReduceTime;
        private System.Windows.Forms.Button btnReduceTime;
    }
}