using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;


namespace SynchronizationContextTaskScheduler
{
    public partial class AsyncAndAwait : Form
    {
        public AsyncAndAwait()
        {
            InitializeComponent();
        }

        private async void startBtn_Click(object sender, EventArgs e)
        {
            // Call and await separately.
            Task<int> getLengthTask = AccessTheWebAsync();
            // You can do independent work here.
            DosomthingElse();
            int contentLength = await getLengthTask;
            //int contentLength = await AccessTheWebAsync();

            resultsTextBox.Text +=
                String.Format("\r\nLength of the downloaded string: {0}.\r\n", contentLength);
        }

        private void DosomthingElse()
        {
            for (int i = 0; i < 5; i++)
            {
                resultsTextBox.Text += "Something else in entry method!\r\n";
            }
        }

        // Three things to note in the signature:
        //  - The method has an async modifier. 
        //  - The return type is Task or Task<T>. (See "Return Types" section.)
        //    Here, it is Task<int> because the return statement returns an integer.
        //  - The method name ends in "Async."
        async Task<int> AccessTheWebAsync()
        {
            // You need to add a reference to System.Net.Http to declare client.
            HttpClient client = new HttpClient();

            // GetStringAsync returns a Task<string>. That means that when you await the
            // task you'll get a string (urlContents).
            Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");

            // You can do work here that doesn't rely on the string from GetStringAsync.
            DoIndependentWork();

            // The await operator suspends AccessTheWebAsync.
            //  - AccessTheWebAsync can't continue until getStringTask is complete.
            //  - Meanwhile, control returns to the caller of AccessTheWebAsync.
            //  - Control resumes here when getStringTask is complete. 
            //  - The await operator then retrieves the string result from getStringTask.
            string urlContents = await getStringTask;
            resultsTextBox.Text += "Task finished!\r\n";
            // The return statement specifies an integer result.
            // Any methods that are awaiting AccessTheWebAsync retrieve the length value.
            return urlContents.Length;
        }


        void DoIndependentWork()
        {
            resultsTextBox.Text += "Working . . . . . . .\r\n";
        }
    }
}
