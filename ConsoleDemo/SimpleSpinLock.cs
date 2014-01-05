using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ParallelDemos
{
    struct SimpleSpinLock
    {
        private  Int32 m_ResourceInUse;//0=false;1=true;
        public void Enter()
        {
            while(Interlocked.Exchange(ref m_ResourceInUse,1)==0)
            {
                /*Black magic*/
            }
        }

        public void Leave()
        {
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
