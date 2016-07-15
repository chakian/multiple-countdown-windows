namespace MultipleCountdown
{
    partial class AlertForm
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
            this.lblStaticFinished = new System.Windows.Forms.Label();
            this.lblFinishedCountdown = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStaticFinished
            // 
            this.lblStaticFinished.Location = new System.Drawing.Point(13, 13);
            this.lblStaticFinished.Name = "lblStaticFinished";
            this.lblStaticFinished.Size = new System.Drawing.Size(205, 23);
            this.lblStaticFinished.TabIndex = 0;
            this.lblStaticFinished.Text = "Finished";
            this.lblStaticFinished.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFinishedCountdown
            // 
            this.lblFinishedCountdown.Location = new System.Drawing.Point(13, 45);
            this.lblFinishedCountdown.Name = "lblFinishedCountdown";
            this.lblFinishedCountdown.Size = new System.Drawing.Size(205, 41);
            this.lblFinishedCountdown.TabIndex = 1;
            this.lblFinishedCountdown.Text = "What finished";
            this.lblFinishedCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AlertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 95);
            this.Controls.Add(this.lblFinishedCountdown);
            this.Controls.Add(this.lblStaticFinished);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AlertForm";
            this.Text = "AlertForm";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AlertForm_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStaticFinished;
        private System.Windows.Forms.Label lblFinishedCountdown;
    }
}