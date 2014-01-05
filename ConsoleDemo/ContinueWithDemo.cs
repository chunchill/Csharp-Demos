using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelDemos
{
    internal class ContinueWithDemo
    {
        public static void Go()
        {
            // Create and start a Task, continue with another task 
            Task<Int32> t = Task.Run(() => Sum(CancellationToken.None, 10000));
            // ContinueWith returns a Task but you usually don't care 
            Task cwt = t.ContinueWith(task =>
            {
                Console.WriteLine("The sum is: " + task.Result);
                //Console.Read(); //Remember the background vs Foreground thread ?
            });
            Console.Read();
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
