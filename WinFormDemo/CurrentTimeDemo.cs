﻿using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace SynchronizationContextTaskScheduler
{
    /// <summary>
    /// 每一个从Control类中派生出来的WinForm类（包括Control类）都是依靠底层Windows消息和一个消息泵循环（message pump loop）来执行的
    /// http://msdn.microsoft.com/zh-cn/magazine/gg598924.aspx
    /// WindowsFormsSynchronizationContext（System.Windows.Forms.dll：System.Windows.Forms）
    /// Windows 窗体应用程序会创建并安装一个 WindowsFormsSynchronizationContext 作为创建 UI 控件的任意线程的当前上下文。
    /// 这一 SynchronizationContext 使用 UI 控件的 ISynchronizeInvoke 方法，该方法将委托传递给基础 Win32 消息循环。
    /// WindowsFormsSynchronizationContext 的上下文是一个单独的 UI 线程。
    /// </summary>
    public partial class CurrentTimeDemo : Form
    {
        public CurrentTimeDemo()
        {
            InitializeComponent();

        }

        private Thread _thread;
        void TimerTick(object sender, EventArgs e)
        {
            UpdateUI();
        }


        public void ShowTime1()
        {
            _thread = new Thread(o =>
               {
                   while (true)
                   {
                       UpdateUI();
                   }
                   // ReSharper disable FunctionNeverReturns
               });
            // ReSharper restore FunctionNeverReturns
            _thread.Start();
        }

        public void ShowTime2()
        {
            var timer = new System.Windows.Forms.Timer();
            timer.Tick += TimerTick;
            timer.Interval = 1000;
            timer.Start();
        }

        public delegate void MethodInvoker();

        public void ShowTime3()
        {
            _thread = new Thread(o =>
              {

                  while (true)
                  {
                      var result = BeginInvoke(new MethodInvoker(() =>
                         {
                             UpdateUI();
                         }));
                      EndInvoke(result);
                      Thread.Sleep(1000);
                  }
                  // ReSharper disable FunctionNeverReturns
              }) { IsBackground = true };
            // ReSharper restore FunctionNeverReturns
            _thread.Start();
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
            _thread = new Thread(state =>
            {
                while (true)
                {
                    // grab the context from the state
                    var uictx = state as SynchronizationContext;
                    if (uictx != null) uictx.Post(UpdateUI, null);
                    Thread.Sleep(1000);
                }
                // ReSharper disable FunctionNeverReturns
            });
            // ReSharper restore FunctionNeverReturns

            // start the thread, and pass it the UI context,
            // so this thread will be able to update the UI
            // from within the thread
            _thread.Start(uiContext);
        }

        /// <summary>
        /// This method is executed on the main UI thread.
        /// </summary>
        // ReSharper disable InconsistentNaming
        private void UpdateUI(object state = null)
        // ReSharper restore InconsistentNaming
        {
            label1.Text = DateTime.Now.ToLocalTime().ToString(CultureInfo.InvariantCulture);
        }


        private void TimerDemoLoad(object sender, EventArgs e)
        {
            //ShowTime1();
            //ShowTime2();
            //ShowTime3();
            ShowTime4();
        }

        private void CurrentTimeDemoFormClosed(object sender, FormClosedEventArgs e)
        {
            _thread.Abort();
        }
    }
}
