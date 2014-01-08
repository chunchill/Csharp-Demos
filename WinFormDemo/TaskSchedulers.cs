using System;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronizationContextTaskScheduler
{
    public partial class TaskSchedulers : Form
    {
        public TaskSchedulers()
        {
            InitializeComponent();
            Text = "Synchronization Context Task Scheduler Demo";
            _mSyncContexTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            Visible = true;
            Width = 400;
            Height = 100;
        }

       public override sealed string Text
       {
          get { return base.Text; }
          set { base.Text = value; }
       }

       private readonly TaskScheduler _mSyncContexTaskScheduler;
        private CancellationTokenSource _mCts;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (_mCts != null)
            {
                _mCts.Cancel();
                _mCts = null;
            }
            else
            {
                Text = "Operation running";
            }
            _mCts = new CancellationTokenSource();

            var t = new Task<Int32>(() => Sum(_mCts.Token, Int32.MaxValue), _mCts.Token);
            t.Start();
            t.ContinueWith(task => { Text = "Result" + task.Result; }, CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, _mSyncContexTaskScheduler);
            t.ContinueWith(task => { Text = "Operation Cancled"; }, CancellationToken.None, TaskContinuationOptions.OnlyOnCanceled, _mSyncContexTaskScheduler);
            t.ContinueWith(task => { Text = "Operation Faulted"; }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, _mSyncContexTaskScheduler);
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
