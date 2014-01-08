using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelDemos
{
   class OptimizedAwayDemo
   {
      private static void OptimizedAway()
      {
         // Constant expression is computed at compile time resulting in zero 
         Int32 value = (1 * 100) - (50 * 2);

         // If value is 0, the loop never executes 
         for (Int32 x = 0; x < value; x++)
         {
            // There is no need to compile the code in the loop because it can never execute 
            Console.WriteLine("Jeff");
         }
      }

   }

   /// <summary>
   /// Ensuring building with x86 cpu with optimize code setting
   /// </summary>
   public static class StrangeBehavior
   {
      // As you'll see later, mark this field as volatile to fix the problem 
      private static Boolean s_stopWorker = false;
      //private volatile static Boolean s_stopWorker = false;

      public static void Go()
      {
         Console.WriteLine("Main: letting worker run for 5 seconds");
         Thread t = new Thread(Worker);
         t.Start();
         Thread.Sleep(5000);
         s_stopWorker = true;
         Console.WriteLine("Main: waiting for worker to stop");
         t.Join();
      }
      private static void Worker(Object o)
      {
         Int32 x = 0;
         while (!s_stopWorker) x++;
         Console.WriteLine("Worker: stopped when x={0}", x);
      }
   }

   public sealed class ThreadsSharingData
   {
      private Int32 m_flag = 0;
      private Int32 m_value = 0;

      // This method is executed by one thread  
      public void Thread1(Object o)
      {
         // Note: These could execute in reverse order 
         m_value = 5;
         m_flag = 1;
      }

      // This method is executed by another thread  
      public void Thread2(Object o)
      {
         // Note: m_value could be read before m_flag 
         if (m_flag == 1)
            Console.WriteLine(m_value);
      }

      public void Go()
      {
         Thread t2 = new Thread(Thread2);
         t2.Start();
         Thread t1 = new Thread(Thread1);
         t1.Start();
      }
   }

   internal sealed class ThreadsSharingDataFixed
   {
      private Int32 m_flag = 0;
      private Int32 m_value = 0;

      // This method is executed by one thread  
      public void Thread1()
      {
         // Note: 5 must be written to m_value before 1 is written to m_flag 
         m_value = 5;
         Volatile.Write(ref m_flag, 1);
      }

      // This method is executed by another thread  
      public void Thread2()
      {
         // Note: m_value must be read after m_flag is read  
         if (Volatile.Read(ref m_flag) == 1)
            Console.WriteLine(m_value);
      }
   }
}
