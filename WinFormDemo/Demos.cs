using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SynchronizationContextTaskScheduler
{
    public partial class Demos : Form
    {
        public Demos()
        {
            InitializeComponent();
        }

        private void btnTaskSchedulerDemo_Click(object sender, EventArgs e)
        {
            TaskSchedulers demo = new TaskSchedulers();
            demo.Show();
        }

        private void btnAsyncAwait_Click(object sender, EventArgs e)
        {
            AsyncAndAwait demo = new AsyncAndAwait();
            demo.Show();
        }

        private void btnSynchonizationContextDemo_Click(object sender, EventArgs e)
        {
            SynchronizationContextPost demo = new SynchronizationContextPost();
            demo.Show();
        }

        private void btnEAPDemo_Click(object sender, EventArgs e)
        {
            EAPDemo demo = new EAPDemo();
            demo.Show();
        }
    }
}
