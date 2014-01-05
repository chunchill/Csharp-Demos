using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ParallelDemos
{
    public class ForegroundAndBackGroundThreads
    {
        public static void Go()
        {
            // Create a new thread (defaults to foreground) 
            Thread t = new Thread(Worker);

            // Make the thread a background thread 
            t.IsBackground = false;

            t.Start(); // Start the thread 
            // If t is a foreground thread, the application won't die for about 10 seconds 
            // If t is a background thread, the application dies immediately 
            Console.WriteLine(string.Format("Is the main thread background? {0}", Thread.CurrentThread.IsBackground));
            Console.WriteLine("Returning from Main");
        }

        private static void Worker()
        {
            Thread.Sleep(10000);  // Simulate doing 10 seconds of work 

            // The following line only gets displayed if this code is executed by a foreground thread 
            Console.WriteLine("Returning from Worker");
        }

    }
}
