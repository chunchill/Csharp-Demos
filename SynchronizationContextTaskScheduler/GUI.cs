using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronizationContextTaskScheduler
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
            Text = "Synchronization Context Task Scheduler Demo";
            m_SyncContexTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            Visible = true;
            Width = 400;
            Height = 100;
        }

        private readonly TaskScheduler m_SyncContexTaskScheduler;
        private CancellationTokenSource m_cts;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (m_cts != null)
            {
                m_cts.Cancel();
                m_cts = null;
            }
            else
            {
                Text = "Operation running";
            }
            m_cts = new CancellationTokenSource();

            var t = new Task<Int32>(() => Sum(m_cts.Token, Int32.MaxValue), m_cts.Token);
            t.Start();
            t.ContinueWith(task => { Text = "Result" + task.Result; }, CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, m_SyncContexTaskScheduler);
            t.ContinueWith(task => { Text = "Operation Cancled"; }, CancellationToken.None, TaskContinuationOptions.OnlyOnCanceled, m_SyncContexTaskScheduler);
            t.ContinueWith(task => { Text = "Operation Faulted"; }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, m_SyncContexTaskScheduler);
            base.OnMouseClick(e);
        }

        private static Int32 Sum(CancellationToken ct, Int32 n)
        {
            Int32 sum = 0;
            for (; n > 0; n--)
            {
                ct.ThrowIfCancellationRequested();
                checked { sum += n; }
            }
            return sum;
        }


    }
}
