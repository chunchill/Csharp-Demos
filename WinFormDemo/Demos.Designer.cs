namespace SynchronizationContextTaskScheduler
{
    partial class Demos
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
            this.btnTaskSchedulerDemo = new System.Windows.Forms.Button();
            this.btnAsyncAwait = new System.Windows.Forms.Button();
            this.btnSynchonizationContextDemo = new System.Windows.Forms.Button();
            this.btnEAPDemo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTaskSchedulerDemo
            // 
            this.btnTaskSchedulerDemo.Location = new System.Drawing.Point(119, 46);
            this.btnTaskSchedulerDemo.Name = "btnTaskSchedulerDemo";
            this.btnTaskSchedulerDemo.Size = new System.Drawing.Size(155, 23);
            this.btnTaskSchedulerDemo.TabIndex = 0;
            this.btnTaskSchedulerDemo.Text = "Task Schedulers Demo";
            this.btnTaskSchedulerDemo.UseVisualStyleBackColor = true;
            this.btnTaskSchedulerDemo.Click += new System.EventHandler(this.btnTaskSchedulerDemo_Click);
            // 
            // btnAsyncAwait
            // 
            this.btnAsyncAwait.Location = new System.Drawing.Point(119, 91);
            this.btnAsyncAwait.Name = "btnAsyncAwait";
            this.btnAsyncAwait.Size = new System.Drawing.Size(155, 23);
            this.btnAsyncAwait.TabIndex = 1;
            this.btnAsyncAwait.Text = "Async and Await Demo";
            this.btnAsyncAwait.UseVisualStyleBackColor = true;
            this.btnAsyncAwait.Click += new System.EventHandler(this.btnAsyncAwait_Click);
            // 
            // btnSynchonizationContextDemo
            // 
            this.btnSynchonizationContextDemo.Location = new System.Drawing.Point(119, 137);
            this.btnSynchonizationContextDemo.Name = "btnSynchonizationContextDemo";
            this.btnSynchonizationContextDemo.Size = new System.Drawing.Size(193, 23);
            this.btnSynchonizationContextDemo.TabIndex = 2;
            this.btnSynchonizationContextDemo.Text = "SynchronizationContext Demo";
            this.btnSynchonizationContextDemo.UseVisualStyleBackColor = true;
            this.btnSynchonizationContextDemo.Click += new System.EventHandler(this.btnSynchonizationContextDemo_Click);
            // 
            // btnEAPDemo
            // 
            this.btnEAPDemo.Location = new System.Drawing.Point(119, 184);
            this.btnEAPDemo.Name = "btnEAPDemo";
            this.btnEAPDemo.Size = new System.Drawing.Size(75, 23);
            this.btnEAPDemo.TabIndex = 3;
            this.btnEAPDemo.Text = "EAPDemo";
            this.btnEAPDemo.UseVisualStyleBackColor = true;
            this.btnEAPDemo.Click += new System.EventHandler(this.btnEAPDemo_Click);
            // 
            // Demos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 355);
            this.Controls.Add(this.btnEAPDemo);
            this.Controls.Add(this.btnSynchonizationContextDemo);
            this.Controls.Add(this.btnAsyncAwait);
            this.Controls.Add(this.btnTaskSchedulerDemo);
            this.Name = "Demos";
            this.Text = "Demos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTaskSchedulerDemo;
        private System.Windows.Forms.Button btnAsyncAwait;
        private System.Windows.Forms.Button btnSynchonizationContextDemo;
        private System.Windows.Forms.Button btnEAPDemo;
    }
}