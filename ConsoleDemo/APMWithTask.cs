using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelDemos
{
    /// <summary>
    /// http://msdn.microsoft.com/zh-cn/library/dd997423.aspx
    /// </summary>
    class Calculator
    {
        public IAsyncResult BeginCalculate(int decimalPlaces, AsyncCallback ac, object state)
        {
            Console.WriteLine("Calling BeginCalculate on thread {0}", Thread.CurrentThread.ManagedThreadId);
            Task<string> f = Task<string>.Factory.StartNew(_ => Compute(decimalPlaces), state);
            if (ac != null) f.ContinueWith((res) => ac(f));
            return f;
        }

        public string Compute(int numPlaces)
        {
            Console.WriteLine("Calling compute on thread {0}", Thread.CurrentThread.ManagedThreadId);

            // Simulating some heavy work.
            Thread.SpinWait(500000000);

            // Actual implemenation left as exercise for the reader.
            // Several examples are available on the Web.
            return "3.14159265358979323846264338327950288";
        }

        public string EndCalculate(IAsyncResult ar)
        {
            Console.WriteLine("Calling EndCalculate on thread {0}", Thread.CurrentThread.ManagedThreadId);
            return ((Task<string>)ar).Result;
        }
    }

    public class APMWithTask
    {
        static int decimalPlaces = 12;
        public static void Go()
        {
            Calculator calc = new Calculator();
            int places = 35;

            AsyncCallback callBack = new AsyncCallback(PrintResult);
            IAsyncResult ar = calc.BeginCalculate(places, callBack, calc);

            // Do some work on this thread while the calulator is busy.
            Console.WriteLine("Working...");
            Thread.SpinWait(500000);
            Console.ReadLine();
        }

        public static void PrintResult(IAsyncResult result)
        {
            Calculator c = (Calculator)result.AsyncState;
            string piString = c.EndCalculate(result);
            Console.WriteLine("Calling PrintResult on thread {0}; result = {1}",
                        Thread.CurrentThread.ManagedThreadId, piString);
        }
    }
}
