using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace ParallelDemos
{
    public class TimerDemo
    {
        private static Timer s_timer;
        public static void Go()
        {
            Console.WriteLine("Main thread:starting a timer...");
            using (s_timer = new Timer(ComputeBoundOp, 5, 0, Timeout.Infinite))
            {
                Console.WriteLine("Main thread:Doing other work here...");
                Thread.Sleep(10000);
            }
        }

        private static void ComputeBoundOp(Object state)
        {
            Console.WriteLine("In ComputeBoundOp:state={0}", state);
            Thread.Sleep(1000);
            //error should be thrown as the timer was disposed
            s_timer.Change(2000, Timeout.Infinite);
        }
    }
}
