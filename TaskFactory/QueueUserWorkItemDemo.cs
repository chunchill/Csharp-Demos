using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ParallelDemos
{
    public class QueueUserWorkItemDemo
    {
        public static void Go()
        {
            Console.WriteLine("Main thread: queuing an asynchronous operation");
            ThreadPool.QueueUserWorkItem(ComputeBoundOp, 5);
            Console.WriteLine("Main thread: Doing other work here...");
            Thread.Sleep(10000);  // Simulating other work (10 seconds)  
            Console.WriteLine("Hit <Enter> to end this program...");
            Console.ReadLine();
        }

        // This method's signature must match the WaitCallback delegate  
        private static void ComputeBoundOp(Object state)
        {
            // This method is executed by a thread pool thread  
            Console.WriteLine("In ComputeBoundOp: state={0}", state);
            Thread.Sleep(1000);  // Simulates other work (1 second)  

            // When this method returns, the thread goes back  
            // to the pool and waits for another task  
        }
    }
}
