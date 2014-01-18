using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ParallelDemos
{

   internal sealed class SimpleWaitLockWithSemaphore : IDisposable
   {
      private readonly Semaphore m_available;

      public SimpleWaitLockWithSemaphore(Int32 maxConcurrent)
      {
         m_available = new Semaphore(maxConcurrent, maxConcurrent);
      }

      public void Enter()
      {
         // Block in kernel until resource available 
         m_available.WaitOne();
      }

      public void Leave()
      {
         // Let another thread access the resource 
         m_available.Release(1);
      }

      public void Dispose() { m_available.Close(); }
   }

   internal sealed class SimpleWaitLock : IDisposable
   {
      private readonly AutoResetEvent m_available;

      public SimpleWaitLock()
      {
         m_available = new AutoResetEvent(true); // Initially free 
      }

      public void Enter()
      {
         // Block in kernel until resource available 
         m_available.WaitOne();
      }

      public void Leave()
      {
         // Let another thread access the resource 
         m_available.Set();
      }

      public void Dispose() { m_available.Dispose(); }
   }

   public class SimpleWaitLockVsSimpleSpinLockDemo
   {
      public static void Go()
      {
         Int32 x = 0;
         const Int32 iterations = 10000000; // 10 million 

         // How long does it take to increment x 10 million times? 
         Stopwatch sw = Stopwatch.StartNew();
         for (Int32 i = 0; i < iterations; i++)
         {
            x++;
         }
         Console.WriteLine("Incrementing x: {0:N0}", sw.ElapsedMilliseconds);

         // How long does it take to increment x 10 million times  
         // adding the overhead of calling a method that does nothing? 
         sw.Restart();
         for (Int32 i = 0; i < iterations; i++)
         {
            M();
            x++;
            M();
         }
         Console.WriteLine("Incrementing x in M: {0:N0}", sw.ElapsedMilliseconds);

         // How long does it take to increment x 10 million times  
         // adding the overhead of calling an uncontended SimpleSpinLock? 
         SpinLock sl = new SpinLock(false);
         sw.Restart();
         for (Int32 i = 0; i < iterations; i++)
         {
            Boolean taken = false;
            sl.Enter(ref taken);
            x++;
            sl.Exit();
         }
         Console.WriteLine("Incrementing x in SpinLock: {0:N0}", sw.ElapsedMilliseconds);

         // How long does it take to increment x 10 million times  
         // adding the overhead of calling an uncontended SimpleWaitLock? 
         using (SimpleWaitLock swl = new SimpleWaitLock())
         {
            sw.Restart();
            for (Int32 i = 0; i < iterations; i++)
            {
               swl.Enter();
               x++;
               swl.Leave();
            }
            Console.WriteLine("Incrementing x in SimpleWaitLock: {0:N0}", sw.ElapsedMilliseconds);
         }
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void M() { /* This method does nothing but return */ }
   }



}
