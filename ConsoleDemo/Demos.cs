using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelDemos
{
   public class Demos
   {
      static void Main()
      {
         //TaskFactory.Go();
         //ParallerLoop.Go();
         //TimerDemo.Go();
         //APMExceptionHandling.Go();
         //RegisterdWaitHandlerDemo.Go();
         //APMWithTask.Go();
         //AsyncResultDemo.Go();
         //CancellationDemo.Go();
         //CancellationRegistDemo.Go();
         //ContinueWithDemo.Go();
         //ExecutionContextsDemo.Go();
         //ForegroundAndBackGroundThreads.Go();
         //QueueUserWorkItemDemo.Go();
         //TaskDemo.Go();
         //TaskFactory.Go();
         //TaskLogger.Go();
         //SimpleAwaitDemo.Go();
         //StrangeBehavior.Go();
         new ThreadsSharingData().Go();
         Console.Read();
      }
   }
}
