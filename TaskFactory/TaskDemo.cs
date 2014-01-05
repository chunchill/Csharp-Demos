using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelDemos
{
    public class TaskDemo
    {
        public static void Go()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Task<Int32> t = Task.Run(() => Sum(cts.Token, 1000000000), cts.Token);
            // Sometime later, cancel the CancellationTokenSource to cancel the Task 
            cts.Cancel(); // This is an asynchronous request, the Task may have completed already 

            try
            {
                // If the task got canceled, Result will throw an AggregateException 
                Console.WriteLine("The sum is: " + t.Result);   // An Int32 value 
            }
            catch (AggregateException x)
            {
                // Consider any OperationCanceledException objects as handled.  
                // Any other exceptions cause a new AggregateException containing 
                // only the unhandled exceptions to be thrown 
                x.Handle(e => e is OperationCanceledException);

                // If all the exceptions were handled, the following executes 
                Console.WriteLine("Sum was canceled");
                Console.Read();
            }
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
