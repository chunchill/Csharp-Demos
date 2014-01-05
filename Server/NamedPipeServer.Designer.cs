namespace Server
{
    partial class NamedPipeServer
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
            this.listMsgBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listMsgBox
            // 
            this.listMsgBox.FormattingEnabled = true;
            this.listMsgBox.ItemHeight = 12;
            this.listMsgBox.Location = new System.Drawing.Point(13, 13);
            this.listMsgBox.Name = "listMsgBox";
            this.listMsgBox.Size = new System.Drawing.Size(434, 388);
            this.listMsgBox.TabIndex = 0;
            // 
            // NamedPipeServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 416);
            this.Controls.Add(this.listMsgBox);
            this.Name = "NamedPipeServer";
            this.Text = "Server of NamedPipe";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listMsgBox;
    }
}

