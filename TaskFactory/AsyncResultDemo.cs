using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;

namespace ParallelDemos
{
    public class AsyncDemo
    {
        // The method to be executed asynchronously.
        public string TestMethod(int callDuration, out int threadId)
        {
            Console.WriteLine("Test method begins.");
            Thread.Sleep(callDuration);
            threadId = Thread.CurrentThread.ManagedThreadId;
            return String.Format("My call time was {0}.", callDuration.ToString());
        }
    }
    // The delegate must have the same signature as the method
    // it will call asynchronously.
    public delegate string AsyncMethodCaller(int callDuration, out int threadId);

    public class AsyncResultDemo
    {
        public static void Go()
        {

            // The asynchronous method puts the thread id here.
            int threadId;

            // Create an instance of the test class.
            AsyncDemo ad = new AsyncDemo();

            // Create the delegate.
            AsyncMethodCaller caller = new AsyncMethodCaller(ad.TestMethod);
            var result = caller.BeginInvoke(3000, out threadId,
               new AsyncCallback(CallbackMethod),
               "The call executed on thread {0}, with return value \"{1}\".");

            Console.WriteLine("The main thread {0} continues to execute...",
                Thread.CurrentThread.ManagedThreadId);
            Console.Read();
#if false
            {
                // Initiate the asychronous call.
                IAsyncResult result = caller.BeginInvoke(30000,
                    out threadId, null, null);

                //http://msdn.microsoft.com/en-us/library/d00bd51t(v=vs.110).aspx
                Thread.Sleep(0);
                Console.WriteLine("Main thread {0} does some work.",
                    Thread.CurrentThread.ManagedThreadId);

            }
#endif

#if false
            {
                // Wait for the WaitHandle to become signaled.(once the async operation is done, then it would get the singal)
                bool done = result.AsyncWaitHandle.WaitOne();
            }
#endif

#if false
            
            
                // Poll while simulating work. 
                while (result.IsCompleted == false)
                {
                    Thread.Sleep(250);
                    Console.Write(".");
                }
            
#endif

#if false

                // Perform additional processing here.
                // Call EndInvoke to retrieve the results.
                string returnValue = caller.EndInvoke(out threadId, result);
                // Close the wait handle.
                result.AsyncWaitHandle.Close();
                Console.WriteLine("The call executed on thread {0}, with return value \"{1}\".",
                threadId, returnValue);
                Console.Read();
#endif

        }

        // The callback method must have the same signature as the 
        // AsyncCallback delegate. 
        static void CallbackMethod(IAsyncResult ar)
        {
            // Retrieve the delegate.
            AsyncResult result = (AsyncResult)ar;
            AsyncMethodCaller caller = (AsyncMethodCaller)result.AsyncDelegate;

            // Retrieve the format string that was passed as state  
            // information. 
            string formatString = (string)ar.AsyncState;

            // Define a variable to receive the value of the out parameter. 
            // If the parameter were ref rather than out then it would have to 
            // be a class-level field so it could also be passed to BeginInvoke. 
            int threadId = 0;

            // Call EndInvoke to retrieve the results. 
            string returnValue = caller.EndInvoke(out threadId, ar);

            // Use the format string to format the output message.
            Console.WriteLine(formatString, threadId, returnValue);
        }



    }
}
