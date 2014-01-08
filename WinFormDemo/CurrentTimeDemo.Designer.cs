namespace SynchronizationContextTaskScheduler
{
    partial class CurrentTimeDemo
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
         this.label1 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
         this.label1.Location = new System.Drawing.Point(1, 104);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(281, 35);
         this.label1.TabIndex = 0;
         this.label1.Text = "lblCurrentTime";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // CurrentTimeDemo
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(394, 295);
         this.Controls.Add(this.label1);
         this.Name = "CurrentTimeDemo";
         this.Text = "Timer";
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CurrentTimeDemoFormClosed);
         this.Load += new System.EventHandler(this.TimerDemoLoad);
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}