using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SynchronizationContextTaskScheduler
{
    /// <summary>
    /// UI 控件的 ISynchronizeInvoke 方法，该方法将委托传递给基础 Win32 消息循环
    /// </summary>
    public partial class CurrentTimeDemo : Form
    {
        public CurrentTimeDemo()
        {
            InitializeComponent();

        }
        void timer_Tick(object sender, EventArgs e)
        {
            UpdateUI();
        }


        public void ShowTime1()
        {
            var thread = new Thread(new ParameterizedThreadStart((o) =>
            {
                while (true)
                {
                    UpdateUI();
                }
            }));
            thread.Start();
        }

        public void ShowTime2()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000;
            timer.Start();
        }

        public delegate void MethodInvoker();

        public void ShowTime3()
        {
            var thread = new Thread(new ParameterizedThreadStart((o) =>
            {

                while (true)
                {
                    var result = this.BeginInvoke(new MethodInvoker(() =>
                    {
                        UpdateUI();
                    }));
                    this.EndInvoke(result);
                    Thread.Sleep(1000);
                }
            }));
            thread.IsBackground = true;
            thread.Start();
        }

        public void ShowTime4()
        {
            // grab the sync context associated to this
            // thread (the UI thread), and save it in uiContext
            // note that this context is set by the UI thread
            // during Form creation (outside of your control)
            // also note, that not every thread has a sync context attached to it.
            SynchronizationContext uiContext = SynchronizationContext.Current;

            // create a thread and associate it to the run method
            Thread thread = new Thread((state) =>
            {
                while (true)
                {
                    // grab the context from the state
                    SynchronizationContext uictx = state as SynchronizationContext;
                    uictx.Post(UpdateUI, null);
                    Thread.Sleep(1000);
                }
            });

            // start the thread, and pass it the UI context,
            // so this thread will be able to update the UI
            // from within the thread
            thread.Start(uiContext);
        }

        /// <summary>
        /// This method is executed on the main UI thread.
        /// </summary>
        private void UpdateUI(object state = null)
        {
            this.label1.Text = DateTime.Now.ToLocalTime().ToString();
        }


        private void TimerDemo_Load(object sender, EventArgs e)
        {
            //ShowTime1();
            //ShowTime2();
            ShowTime3();
            //ShowTime4();
        }
    }
}
