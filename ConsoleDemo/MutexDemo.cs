using System;
using System.Threading;

namespace ParallelDemos
{
   internal class MutexDemo : IDisposable
   {
      private readonly Mutex m_lock = new Mutex();

      public void Method1()
      {
         m_lock.WaitOne();
         // Do whatever... 
         Method2(); // Method2 recursively acquires the lock 
         m_lock.ReleaseMutex();
      }

      public void Method2()
      {
         m_lock.WaitOne();
         // Do whatever... 
         m_lock.ReleaseMutex();
      }

      public void Dispose()
      {
         m_lock.Dispose();
      }
   }

   internal sealed class RecursiveAutoResetEvent : IDisposable
   {
      private AutoResetEvent m_lock = new AutoResetEvent(true);
      private Int32 m_owningThreadId = 0;
      private Int32 m_recursionCount = 0;

      public void Enter()
      {
         // Obtain the calling thread's unique Int32 ID 
         Int32 currentThreadId = Thread.CurrentThread.ManagedThreadId;

         // If the calling thread owns the lock, increment the recursion count 
         if (m_owningThreadId == currentThreadId)
         {
            m_recursionCount++;
            return;
         }
         // The calling thread doesn't own the lock, wait for it 
         m_lock.WaitOne();

         // The calling now owns the lock, initialize the owning thread ID & recursion count 
         m_owningThreadId = currentThreadId;
         m_recursionCount = 1;
      }

      public void Leave()
      {
         // If the calling thread doesn't own the lock, we have an error 
         if (m_owningThreadId != Thread.CurrentThread.ManagedThreadId)
            throw new InvalidOperationException();

         // Subtract 1 from the recursion count 
         if (m_recursionCount == 0)
         {
            // If the recursion count is 0, then no thread owns the lock 
            m_owningThreadId = 0;
            m_lock.Set(); // Wake up 1 waiting thread (if any) 
         }
      }

      public void Dispose()
      {
         m_lock.Dispose();
      }
   }
}


