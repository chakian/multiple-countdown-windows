namespace MultipleCountdown
{
    partial class Countdown
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Countdown));
            this.btnAddCountdown = new System.Windows.Forms.Button();
            this.pnlCountdowns = new System.Windows.Forms.Panel();
            this.cmbCountdownName = new System.Windows.Forms.ComboBox();
            this.tmrProgressState = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddCountdown
            // 
            this.btnAddCountdown.Location = new System.Drawing.Point(269, 39);
            this.btnAddCountdown.Name = "btnAddCountdown";
            this.btnAddCountdown.Size = new System.Drawing.Size(299, 45);
            this.btnAddCountdown.TabIndex = 1;
            this.btnAddCountdown.Text = "Add countdown with this name";
            this.btnAddCountdown.UseVisualStyleBackColor = true;
            this.btnAddCountdown.Click += new System.EventHandler(this.btnAddCountdown_Click);
            // 
            // pnlCountdowns
            // 
            this.pnlCountdowns.AutoScroll = true;
            this.pnlCountdowns.Location = new System.Drawing.Point(12, 91);
            this.pnlCountdowns.Name = "pnlCountdowns";
            this.pnlCountdowns.Size = new System.Drawing.Size(556, 583);
            this.pnlCountdowns.TabIndex = 2;
            // 
            // cmbCountdownName
            // 
            this.cmbCountdownName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbCountdownName.FormattingEnabled = true;
            this.cmbCountdownName.Location = new System.Drawing.Point(12, 44);
            this.cmbCountdownName.Name = "cmbCountdownName";
            this.cmbCountdownName.Size = new System.Drawing.Size(251, 31);
            this.cmbCountdownName.TabIndex = 0;
            // 
            // tmrProgressState
            // 
            this.tmrProgressState.Tick += new System.EventHandler(this.tmrProgressState_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(581, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem});
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.mainToolStripMenuItem.Text = "Main";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loginToolStripMenuItem.Text = "Login";
            // 
            // Countdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 689);
            this.Controls.Add(this.cmbCountdownName);
            this.Controls.Add(this.pnlCountdowns);
            this.Controls.Add(this.btnAddCountdown);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Countdown";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddCountdown;
        private System.Windows.Forms.Panel pnlCountdowns;
        private System.Windows.Forms.ComboBox cmbCountdownName;
        private System.Windows.Forms.Timer tmrProgressState;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
    }
}

