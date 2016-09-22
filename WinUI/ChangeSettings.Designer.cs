namespace MultipleCountdown
{
    partial class ChangeSettings
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
            this.chkSendEmail = new System.Windows.Forms.CheckBox();
            this.lblSendMail = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlAutoSync = new System.Windows.Forms.Panel();
            this.tbSyncInterval = new System.Windows.Forms.TextBox();
            this.lblSyncInterval = new System.Windows.Forms.Label();
            this.lblAutoSync = new System.Windows.Forms.Label();
            this.chkAutoSync = new System.Windows.Forms.CheckBox();
            this.pnlSendMail = new System.Windows.Forms.Panel();
            this.tbMailTo = new System.Windows.Forms.TextBox();
            this.lblMailTo = new System.Windows.Forms.Label();
            this.pnlAutoSync.SuspendLayout();
            this.pnlSendMail.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkSendEmail
            // 
            this.chkSendEmail.AutoSize = true;
            this.chkSendEmail.Location = new System.Drawing.Point(232, 126);
            this.chkSendEmail.Name = "chkSendEmail";
            this.chkSendEmail.Size = new System.Drawing.Size(15, 14);
            this.chkSendEmail.TabIndex = 15;
            this.chkSendEmail.UseVisualStyleBackColor = true;
            // 
            // lblSendMail
            // 
            this.lblSendMail.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSendMail.Location = new System.Drawing.Point(22, 124);
            this.lblSendMail.Name = "lblSendMail";
            this.lblSendMail.Size = new System.Drawing.Size(204, 26);
            this.lblSendMail.TabIndex = 16;
            this.lblSendMail.Text = "Send notification email";
            this.lblSendMail.Click += new System.EventHandler(this.lblSendMail_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 241);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(424, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlAutoSync
            // 
            this.pnlAutoSync.Controls.Add(this.tbSyncInterval);
            this.pnlAutoSync.Controls.Add(this.lblSyncInterval);
            this.pnlAutoSync.Location = new System.Drawing.Point(12, 39);
            this.pnlAutoSync.Name = "pnlAutoSync";
            this.pnlAutoSync.Size = new System.Drawing.Size(424, 44);
            this.pnlAutoSync.TabIndex = 18;
            // 
            // tbSyncInterval
            // 
            this.tbSyncInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSyncInterval.Location = new System.Drawing.Point(220, 7);
            this.tbSyncInterval.Name = "tbSyncInterval";
            this.tbSyncInterval.Size = new System.Drawing.Size(58, 26);
            this.tbSyncInterval.TabIndex = 16;
            this.tbSyncInterval.Text = "12";
            // 
            // lblSyncInterval
            // 
            this.lblSyncInterval.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSyncInterval.Location = new System.Drawing.Point(10, 13);
            this.lblSyncInterval.Name = "lblSyncInterval";
            this.lblSyncInterval.Size = new System.Drawing.Size(204, 26);
            this.lblSyncInterval.TabIndex = 15;
            this.lblSyncInterval.Text = "Synchronize interval (seconds)";
            this.lblSyncInterval.Click += new System.EventHandler(this.lblSyncInterval_Click);
            // 
            // lblAutoSync
            // 
            this.lblAutoSync.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAutoSync.Location = new System.Drawing.Point(22, 10);
            this.lblAutoSync.Name = "lblAutoSync";
            this.lblAutoSync.Size = new System.Drawing.Size(204, 26);
            this.lblAutoSync.TabIndex = 20;
            this.lblAutoSync.Text = "Enable automatic synchronization";
            // 
            // chkAutoSync
            // 
            this.chkAutoSync.AutoSize = true;
            this.chkAutoSync.Location = new System.Drawing.Point(232, 12);
            this.chkAutoSync.Name = "chkAutoSync";
            this.chkAutoSync.Size = new System.Drawing.Size(15, 14);
            this.chkAutoSync.TabIndex = 19;
            this.chkAutoSync.UseVisualStyleBackColor = true;
            // 
            // pnlSendMail
            // 
            this.pnlSendMail.Controls.Add(this.tbMailTo);
            this.pnlSendMail.Controls.Add(this.lblMailTo);
            this.pnlSendMail.Location = new System.Drawing.Point(12, 153);
            this.pnlSendMail.Name = "pnlSendMail";
            this.pnlSendMail.Size = new System.Drawing.Size(424, 44);
            this.pnlSendMail.TabIndex = 19;
            // 
            // tbMailTo
            // 
            this.tbMailTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMailTo.Location = new System.Drawing.Point(220, 7);
            this.tbMailTo.Name = "tbMailTo";
            this.tbMailTo.Size = new System.Drawing.Size(188, 26);
            this.tbMailTo.TabIndex = 16;
            this.tbMailTo.Text = "a@a.a";
            // 
            // lblMailTo
            // 
            this.lblMailTo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMailTo.Location = new System.Drawing.Point(10, 13);
            this.lblMailTo.Name = "lblMailTo";
            this.lblMailTo.Size = new System.Drawing.Size(204, 26);
            this.lblMailTo.TabIndex = 15;
            this.lblMailTo.Text = "Send notification email to:";
            // 
            // ChangeSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 276);
            this.Controls.Add(this.pnlSendMail);
            this.Controls.Add(this.lblAutoSync);
            this.Controls.Add(this.chkAutoSync);
            this.Controls.Add(this.pnlAutoSync);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblSendMail);
            this.Controls.Add(this.chkSendEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Application settings";
            this.pnlAutoSync.ResumeLayout(false);
            this.pnlAutoSync.PerformLayout();
            this.pnlSendMail.ResumeLayout(false);
            this.pnlSendMail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkSendEmail;
        private System.Windows.Forms.Label lblSendMail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlAutoSync;
        private System.Windows.Forms.TextBox tbSyncInterval;
        private System.Windows.Forms.Label lblSyncInterval;
        private System.Windows.Forms.Label lblAutoSync;
        private System.Windows.Forms.CheckBox chkAutoSync;
        private System.Windows.Forms.Panel pnlSendMail;
        private System.Windows.Forms.TextBox tbMailTo;
        private System.Windows.Forms.Label lblMailTo;
    }
}