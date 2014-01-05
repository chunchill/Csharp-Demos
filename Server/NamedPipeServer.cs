using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class NamedPipeServer : Form
    {
        NamedPipeServerStream pipeServer = new NamedPipeServerStream("TestNamePipe", PipeDirection.InOut, 4, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
        public NamedPipeServer()
        {
            InitializeComponent();
            this.Load += NamedPipeServer_Load;
        }

        private void NamedPipeServer_Load(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                pipeServer.BeginWaitForConnection((o) =>
                {
                    NamedPipeServerStream server = (NamedPipeServerStream)o.AsyncState;
                    server.EndWaitForConnection(o);
                    StreamReader sr = new StreamReader(server);
                    StreamWriter sw = new StreamWriter(server);
                    string result = null;
                    string clientName = server.GetImpersonationUserName();
                    while (true)
                    {
                        result = sr.ReadLine();
                        if (result == null || result == "N/A")
                            break;
                        this.Invoke((MethodInvoker)delegate { this.listMsgBox.Items.Add(clientName + " : " + result); });
                    }
                }, pipeServer);
            });
        }
    }
}
