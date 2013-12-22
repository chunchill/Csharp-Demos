using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ParallelDemos
{
    public static class RegisterdWaitHandlerDemo
    {
        public static void Go()
        {
            AutoResetEvent are = new AutoResetEvent(false);
            RegisteredWaitHandle rwh = ThreadPool.RegisterWaitForSingleObject(
                are,
                EventOperation,
                null,
                5000,
                false
                );
            char operation = (char)0;
            while (operation != 'Q')
            {
                Console.WriteLine("S=Signal,Q=Quit?");
                operation = char.ToUpper(Console.ReadKey(true).KeyChar);
                if (operation == 'S') are.Set();
            }

            rwh.Unregister(null);
        }

        private static void EventOperation(object state, bool timedOut)
        {
            Console.WriteLine(timedOut ? "Timeout" : "Event became true");
        }
    }
}
