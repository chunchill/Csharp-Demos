using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class NamedPipeClient : Form
    {

        NamedPipeClientStream pipeClient = new NamedPipeClientStream("127.0.0.1", "TestNamePipe",
                    PipeDirection.InOut, PipeOptions.Asynchronous,
                    TokenImpersonationLevel.None);
        StreamWriter sw = null;

        public NamedPipeClient()
        {
            InitializeComponent();
            this.Load += NamedPipeClient_Load;
        }

        private void NamedPipeClient_Load(object sender, EventArgs e)
        {
            pipeClient.Connect();
            sw = new StreamWriter(pipeClient);
            sw.AutoFlush = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            sw.WriteLine(txtContent.Text);
        }
    }
}
