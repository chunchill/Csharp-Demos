using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelDemos
{
    public class SimpleAwaitDemo
    {

        static async Task DoWork()
        {

            Console.WriteLine("Hello World!");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Working..{0}", i);
                await Task.Delay(1000);
            }
        }
        static async Task Wrap()
        {
            //await DoWork();//It's not the first await, as it equally the next two lines codes
            var task = DoWork();
            await task;
            Console.WriteLine("First async Run End");
        }

        public static void Go()
        {
            var t = Wrap();
            Console.WriteLine("...");
            Console.Read();
        }
    }
}
