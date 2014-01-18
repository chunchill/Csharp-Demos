using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ParallelDemos
{
   struct SimpleSpinLock
   {
      private Int32 m_ResourceInUse;//0=false;1=true;
      public void Enter()
      {
         // Always set resource to in­use 
         // When this thread changes it from not in­use, return 
         while (Interlocked.Exchange(ref m_ResourceInUse, 1) == 0)
         {
            /*Black magic*/
         }
      }

      public void Leave()
      {
         // Set resource to not in­use 
         Thread.VolatileWrite(ref m_ResourceInUse, 0);
      }
   }

   public sealed class SomeResource
   {
      private SimpleSpinLock m_sl = new SimpleSpinLock();

      public void AccessResource()
      {
         m_sl.Enter();
         //do somthing here
         m_sl.Leave();
      }
   }
}
