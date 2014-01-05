using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SynchronizationContextTaskScheduler
{
    public partial class EAPDemo : Form
    {
        public EAPDemo()
        {
            InitializeComponent();
        }

        protected override void OnClick(EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += PrcessString;
            wc.DownloadStringAsync(new Uri("https://github.com"));
            base.OnClick(e);

        }

        private void PrcessString(object sender, DownloadStringCompletedEventArgs e)
        {
            MessageBox.Show(e.Error != null ? e.Error.Message : e.Result);
        }
    }
}
