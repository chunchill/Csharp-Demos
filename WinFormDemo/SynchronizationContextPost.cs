using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SynchronizationContextTaskScheduler
{
    public partial class SynchronizationContextPost : Form
    {
        public SynchronizationContextPost()
        {
            InitializeComponent();
            Text = "Click in the window to start a web request";
            Width = 400;
            Height = 100;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            Text = "Web request starting...";
            var webRequest = WebRequest.Create("http://github.com");
            webRequest.BeginGetResponse(SyncContextCallback(ProcessWebResponse), webRequest);
            base.OnMouseClick(e);
        }

        private void ProcessWebResponse(IAsyncResult ar)
        {
            var webRequest = (WebRequest)ar.AsyncState; 
            using (var webResponse = webRequest.EndGetResponse(ar))
            {
                Text = "Content length:" + webResponse.ContentLength;
            }
        }

        private static AsyncCallback SyncContextCallback(AsyncCallback callback)
        {
            SynchronizationContext sc = SynchronizationContext.Current;
            if (sc == null) return callback;
            //post
            return asynResult => sc.Post(result => callback((IAsyncResult)result), asynResult);
        }
    }
}
