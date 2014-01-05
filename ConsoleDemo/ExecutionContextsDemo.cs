using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;

namespace ParallelDemos
{
    public class ExecutionContextsDemo
    {
        public static void Go()
        {
            // Put some data into the Main thread's logical call context 
            CallContext.LogicalSetData("Name", "Jeffrey");

            // Initiate some work to be done by a thread pool thread 
            // The thread pool thread can access the logical call context data  
            ThreadPool.QueueUserWorkItem(
               state => Console.WriteLine("Name={0}", CallContext.LogicalGetData("Name")));


            // Now, suppress the flowing of the Main thread's execution context 
            ExecutionContext.SuppressFlow();
            // Initiate some work to be done by a thread pool thread 
            // The thread pool thread CANNOT access the logical call context data 
            ThreadPool.QueueUserWorkItem(
               state => Console.WriteLine("Name={0}", CallContext.LogicalGetData("Name")));

            // Restore the flowing of the Main thread's execution context in case 
            // it employs more thread pool threads in the future 
            ExecutionContext.RestoreFlow();
            //... 
            Console.ReadLine();
        }
    }
}
